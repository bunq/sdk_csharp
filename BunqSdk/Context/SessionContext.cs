using System;
using System.Diagnostics;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;

namespace Bunq.Sdk.Context
{
    /// <summary>
    /// Context of the bunq API session.
    /// </summary>
    public class SessionContext
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string FIELD_ERROR_COULD_NOT_DETERMINE_USER_ID = "Could not determine user id.";
        private const string FIELD_ERROR_SESSION_SERVER_USER_API_KEY_ID_NULL = "sessionServer.UserApiKey.Id != null";
        private const string FIELD_ERROR_SESSION_SERVER_USER_PAYMENT_SERVICE_PROVIDER_KEY_ID_NULL =
            "sessionServer.UserPaymentServiceProvider.Id != null";
        private const string FIELD_ERROR_SESSION_SERVER_USER_COMPANY_ID_NULL = "sessionServer.UserCompany.Id != null";
        private const string FIELD_ERROR_SESSION_SERVER_USER_PERSON_ID_NULL = "sessionServer.UserPerson.Id != null";
        private const string FIELD_ERROR_COULD_NOT_DETERMINE_SESSION_TIMEOUT = "Could not determine session timeout.";
        private const string FIELD_ERROR_SESSION_TIMEOUT_IS_NULL = "Session timeout is null.";
        private const string FIELD_ERROR_ALL_FIELD_NULL = "All fields of an extended model or object are null.";

        /// <summary>
        /// Session token returned as a response to POST /session-server.
        /// </summary>
        [JsonProperty(PropertyName = "token")]
        public string Token { get; private set; }

        /// <summary>
        /// The time the session will expire.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_time")]
        public DateTime ExpiryTime { get; private set; }

        [JsonProperty(PropertyName = "user_id")]
        public int UserId { get; private set; }

        [JsonProperty(PropertyName = "user_person")]
        public UserPerson UserPerson { get; private set; }

        [JsonProperty(PropertyName = "user_company")]
        public UserCompany UserCompany { get; private set; }

        [JsonProperty(PropertyName = "user_api_key")]
        public UserApiKey UserApiKey { get; private set; }

        [JsonProperty(PropertyName = "user_payment_service_provider")]
        public UserPaymentServiceProvider UserPaymentServiceProvider { get; private set; }

        [JsonConstructor]
        private SessionContext()
        {
        }

        public SessionContext(SessionServer sessionServer)
        {
            Token = sessionServer.SessionToken.Token;
            ExpiryTime = DateTime.Now.AddSeconds(GetSessionTimeout(sessionServer));
            UserId = GetUserId(sessionServer);
            SetUser(sessionServer.GetUserReference());
        }

        private void SetUser(BunqModel user)
        {
            if (user.GetType() == typeof(UserPerson))
            {
                UserPerson = (UserPerson) user;
            }
            else if (user.GetType() == typeof(UserCompany))
            {
                UserCompany = (UserCompany) user;
            }
            else if (user.GetType() == typeof(UserApiKey))
            {
                UserApiKey = (UserApiKey) user;
            }
            else if (user.GetType() == typeof(UserPaymentServiceProvider))
            {
                UserPaymentServiceProvider = (UserPaymentServiceProvider) user;
            }
            else
            {
                throw new BunqException(FIELD_ERROR_COULD_NOT_DETERMINE_SESSION_TIMEOUT);
            }
        }

        private static int GetUserId(SessionServer sessionServer)
        {
            if (sessionServer.UserCompany != null)
            {
                Debug.Assert(sessionServer.UserCompany.Id != null,
                    FIELD_ERROR_SESSION_SERVER_USER_COMPANY_ID_NULL);

                return sessionServer.UserCompany.Id.Value;
            }

            if (sessionServer.UserPerson != null)
            {
                Debug.Assert(sessionServer.UserPerson.Id != null,
                    FIELD_ERROR_SESSION_SERVER_USER_PERSON_ID_NULL);

                return sessionServer.UserPerson.Id.Value;
            }

            if (sessionServer.UserApiKey != null)
            {
                Debug.Assert(sessionServer.UserApiKey.Id != null,
                    FIELD_ERROR_SESSION_SERVER_USER_API_KEY_ID_NULL);

                return sessionServer.UserApiKey.Id.Value;
            }

            if (sessionServer.UserPaymentServiceProvider != null)
            {
                Debug.Assert(
                    sessionServer.UserPaymentServiceProvider.Id != null,
                    FIELD_ERROR_SESSION_SERVER_USER_PAYMENT_SERVICE_PROVIDER_KEY_ID_NULL
                );

                return sessionServer.UserPaymentServiceProvider.Id.Value;
            }

            throw new BunqException(FIELD_ERROR_COULD_NOT_DETERMINE_USER_ID);
        }

        private static double GetSessionTimeout(SessionServer sessionServer)
        {
            if (sessionServer.UserApiKey != null)
            {
                return GetSessionTimeOutForUser(sessionServer.UserApiKey.RequestedByUser.GetReferencedObject());
            }

            if (sessionServer.UserCompany != null)
            {
                return GetSessionTimeOutForUser(sessionServer.UserCompany);
            }

            if (sessionServer.UserPerson != null)
            {
                return GetSessionTimeOutForUser(sessionServer.UserPerson);
            }

            if (sessionServer.UserPaymentServiceProvider != null)
            {
                return GetSessionTimeOutForUser(sessionServer.UserPaymentServiceProvider);
            }

            throw new BunqException(FIELD_ERROR_COULD_NOT_DETERMINE_SESSION_TIMEOUT);
        }

        private static double GetSessionTimeOutForUser(BunqModel user)
        {
            int? sessionTimeout;

            if (user.GetType() == typeof(UserPerson))
            {
                sessionTimeout = ((UserPerson) user).SessionTimeout;
            }
            else if (user.GetType() == typeof(UserCompany))
            {
                sessionTimeout = ((UserCompany) user).SessionTimeout;
            }
            else if (user.GetType() == typeof(UserPaymentServiceProvider))
            {
                sessionTimeout = ((UserPaymentServiceProvider) user).SessionTimeout;
            }
            else
            {
                throw new BunqException(FIELD_ERROR_COULD_NOT_DETERMINE_SESSION_TIMEOUT);
            }

            return GetDoubleFromSessionTimeout(sessionTimeout);
        }

        private static double GetDoubleFromSessionTimeout(int? sessionTimeout)
        {
            if (sessionTimeout == null)
            {
                throw new BunqException(FIELD_ERROR_SESSION_TIMEOUT_IS_NULL);
            }

            return (double) sessionTimeout;
        }

        public BunqModel GetUserReference()
        {
            if (UserCompany == null && UserApiKey == null && UserPerson != null && UserPaymentServiceProvider == null)
            {
                return UserPerson;
            }

            if (UserPerson == null && UserApiKey == null && UserCompany != null &&
                UserPaymentServiceProvider == null)
            {
                return UserCompany;
            }

            if (UserPerson == null && UserCompany == null && UserApiKey != null &&
                UserPaymentServiceProvider == null)
            {
                return UserApiKey;
            }

            if (UserPerson == null && UserCompany == null && UserApiKey == null &&
                UserPaymentServiceProvider != null)
            {
                return UserPaymentServiceProvider;
            }

            throw new BunqException(FIELD_ERROR_ALL_FIELD_NULL);
        }
    }
}