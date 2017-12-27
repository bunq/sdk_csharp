﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Security;
using Newtonsoft.Json;

namespace Bunq.Sdk.Context
{
    /// <summary>
    /// The context to make the API calls in. Consists of:
    ///  > Environment type (SANDBOX or PRODUCTION)
    ///  > Bunq API Key for the corresponding environment
    ///  > Installation context
    ///  > Session context
    /// </summary>
    public class ApiContext
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ErrorCouldNotSaveApiContext = "Could not save the API context.";
        private const string ErrorCouldNotRestoreApiContext = "Could not restore the API context.";

        /// <summary>
        /// Measure of any time unit when none of it is needed.
        /// </summary>
        private const int TimeUnitCountNone = 0;

        /// <summary>
        /// Minimum time to session expiry not requiring session reset.
        /// </summary>
        private const int TimeToSessionExpiryMinimumSeconds = 30;

        /// <summary>
        /// Default path to store the serialized context.
        /// </summary>
        private const string PathApiContextDefault = "bunq.conf";

        /// <summary>
        /// Dummy ID to pass to Session endpoint.
        /// </summary>
        private const int SessionIdDummy = 0;

        /// <summary>
        /// Encoding of the serialized context.
        /// </summary>
        private static readonly Encoding EncodingBunqConf = Encoding.UTF8;

        [JsonProperty(PropertyName = "environment_type")]
        public ApiEnvironmentType EnvironmentType { get; private set; }

        [JsonProperty(PropertyName = "api_key")]
        public string ApiKey { get; private set; }

        [JsonProperty(PropertyName = "installation_context")]
        public InstallationContext InstallationContext { get; private set; }

        [JsonProperty(PropertyName = "session_context")]
        public SessionContext SessionContext { get; private set; }

        [JsonProperty(PropertyName = "proxy")]
        public string Proxy { get; private set; }

        [JsonConstructor]
        private ApiContext()
        {
        }

        /// <summary>
        /// Create and initialize an API Context with current IP as permitted.
        /// </summary>
        public static ApiContext Create(ApiEnvironmentType environmentType, string apiKey, string deviceDescription,
            string proxy = null)
        {
            return Create(environmentType, apiKey, deviceDescription, new List<string>(), proxy);
        }

        /// <summary>
        /// Create and initialize an API Context.
        /// </summary>
        public static ApiContext Create(ApiEnvironmentType environmentType, string apiKey, string deviceDescription,
            IList<string> permittedIps, string proxy = null)
        {
            var apiContext = new ApiContext
            {
                ApiKey = apiKey,
                EnvironmentType = environmentType,
                Proxy = proxy,
            };
            apiContext.Initialize(deviceDescription, permittedIps);

            return apiContext;
        }

        /// <summary>
        /// Initializes an API context with Installation, DeviceServer and a SessionServer.
        /// </summary>
        private void Initialize(string deviceDescription, IList<string> permittedIps)
        {
            /* The calls below are order-sensitive: to initialize a Device Registration, we need an
             * Installation, and to initialize a Session we need a Device Registration. */
            InitializeInstallationContext();
            RegisterDevice(deviceDescription, permittedIps);
            InitializeSessionContext();
        }

        /// <summary>
        /// Create a new installation and store its data in installation context.
        /// </summary>
        private void InitializeInstallationContext()
        {
            var keyPairClient = SecurityUtils.GenerateKeyPair();
            var publicKeyFormattedString = SecurityUtils.GetPublicKeyFormattedString(keyPairClient);
            var installationResponse = Installation.Create(this, publicKeyFormattedString);
            InstallationContext = new InstallationContext(installationResponse.Value, keyPairClient);
        }

        private void RegisterDevice(string deviceDescription, IList<string> permittedIps)
        {
            DeviceServer.Create(this, GenerateRequestBodyBytes(deviceDescription, permittedIps));
        }

        private IDictionary<string, object> GenerateRequestBodyBytes(string description, IList<string> permittedIps)
        {
            return new Dictionary<string, object>
            {
                {DeviceServer.FIELD_DESCRIPTION, description},
                {DeviceServer.FIELD_SECRET, ApiKey},
                {DeviceServer.FIELD_PERMITTED_IPS, permittedIps}
            };
        }

        /// <summary>
        /// Create a new session and its data in a SessionContext.
        /// </summary>
        private void InitializeSessionContext()
        {
            SessionContext = new SessionContext(SessionServer.Create(this).Value);
        }

        /// <summary>
        /// Closes the current session and opens a new one.
        /// </summary>
        public void ResetSession()
        {
            DropSessionContext();
            InitializeSessionContext();
        }

        private void DropSessionContext()
        {
            SessionContext = null;
        }

        /// <summary>
        /// Closes the current session.
        /// </summary>
        public void CloseSession()
        {
            DeleteSession();
            DropSessionContext();
        }

        private void DeleteSession()
        {
            Session.Delete(this, SessionIdDummy);
        }

        /// <summary>
        /// Check if current time is too close to the saved session expiry time and reset session if needed.
        /// </summary>
        public void EnsureSessionActive()
        {
            if (!IsSessionActive())
            {
                ResetSession();
            }
        }

        public bool IsSessionActive()
        {
            if (SessionContext == null)
            {
                return false;
            }
            
            var timeToExpiry = SessionContext.ExpiryTime.Subtract(DateTime.Now);
            var timeToExpiryMinimum = new TimeSpan(
                TimeUnitCountNone,
                TimeUnitCountNone,
                TimeToSessionExpiryMinimumSeconds
            );

            return timeToExpiry > timeToExpiryMinimum;
        }

        /// <summary>
        /// Save a JSON representation of the API Context to the default location.
        /// </summary>
        public void Save()
        {
            Save(PathApiContextDefault);
        }

        /// <summary>
        /// Save a JSON representation of the API Context to a given file.
        /// </summary>
        public void Save(string fileName)
        {
            try
            {
                File.WriteAllText(fileName, ToJson(), EncodingBunqConf);
            }
            catch (IOException exception)
            {
                throw new BunqException(ErrorCouldNotSaveApiContext, exception);
            }
        }

        /// <summary>
        /// Serialize the API Context to JSON.
        /// </summary>
        public string ToJson()
        {
            return BunqJsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Restores a context from a default location.
        /// </summary>
        public static ApiContext Restore()
        {
            return Restore(PathApiContextDefault);
        }

        /// <summary>
        /// Restores a context from a given file.
        /// </summary>
        public static ApiContext Restore(string fileName)
        {
            try
            {
                return FromJson(File.ReadAllText(fileName, EncodingBunqConf));
            }
            catch (IOException exception)
            {
                throw new BunqException(ErrorCouldNotRestoreApiContext, exception);
            }
        }

        /// <summary>
        /// De-serializes a context from JSON.
        /// </summary>
        public static ApiContext FromJson(string json)
        {
            return BunqJsonConvert.DeserializeObject<ApiContext>(json);
        }

        /// <summary>
        /// Returns the base URI of the environment assigned to the API context.
        /// </summary>
        public string GetBaseUri()
        {
            return EnvironmentType.BaseUri;
        }

        /// <returns> The session token, installation token if the session isn't created yet, or null if no installation
        /// is created either. </returns>
        public string GetSessionToken()
        {
            if (SessionContext != null) return SessionContext.Token;

            return InstallationContext == null ? null : InstallationContext.Token;
        }
    }
}
