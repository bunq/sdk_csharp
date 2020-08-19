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
        /// Error constatns.
        /// </summary>
        private const string ErrorCouldNotDetermineUserId = "Could not determine user id.";
        private const string ErrorSessionserverUserapikeyIdNull = "sessionServer.UserApiKey.Id != null";
        private const string ErrorSessionserverUserpaymentserviceproviderkeyIdNull =
            "sessionServer.UserPaymentServiceProvider.Id != null";
        private const string ErrorSessionserverUsercompanyIdNull = "sessionServer.UserCompany.Id != null";
        private const string ErrorsessionserverUserpersonIdNull = "sessionServer.UserPerson.Id != null";
        private const string ErrorCouldNotDetermineSessionTimeout = "Could not determine session timeout.";
        private const string ErrorSessionTimeoutIsNull = "Session timeout is null.";

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

        [JsonConstructor]
        private SessionContext()
        {
        }

        public SessionContext(SessionServer sessionServer)
        {
            Token = sessionServer.SessionToken.Token;
            ExpiryTime = DateTime.Now.AddSeconds(GetSessionTimeout(sessionServer));
            UserId = GetUserId(sessionServer);
        }

        private static int GetUserId(SessionServer sessionServer)
        {
            if (sessionServer.UserCompany != null)
            {
                Debug.Assert(sessionServer.UserCompany.Id != null, ErrorSessionserverUsercompanyIdNull);

                return sessionServer.UserCompany.Id.Value;
            }
            else if (sessionServer.UserPerson != null)
            {
                Debug.Assert(sessionServer.UserPerson.Id != null, ErrorsessionserverUserpersonIdNull);

                return sessionServer.UserPerson.Id.Value;
            }
            else if (sessionServer.UserApiKey != null)
            {
                Debug.Assert(sessionServer.UserApiKey.Id != null, ErrorSessionserverUserapikeyIdNull);

                return sessionServer.UserApiKey.Id.Value;
            }
            else if (sessionServer.UserPaymentServiceProvider != null)
            {
                Debug.Assert(
                    sessionServer.UserPaymentServiceProvider.Id != null,
                    ErrorSessionserverUserpaymentserviceproviderkeyIdNull
                );

                return sessionServer.UserPaymentServiceProvider.Id.Value;
            }
            else
            {
                throw new BunqException(ErrorCouldNotDetermineUserId);
            }
        }

        private static double GetSessionTimeout(SessionServer sessionServer)
        {
            if (sessionServer.UserApiKey != null)
            {
                return GetSessionTimeOutForUser(sessionServer.UserApiKey.RequestedByUser.GetReferencedObject());
            }
            else if (sessionServer.UserCompany != null)
            {
                return GetSessionTimeOutForUser(sessionServer.UserCompany);
            }
            else if (sessionServer.UserPerson != null)
            {
                return GetSessionTimeOutForUser(sessionServer.UserPerson);
            }
            else if (sessionServer.UserPaymentServiceProvider != null)
            {
                return GetSessionTimeOutForUser(sessionServer.UserPaymentServiceProvider);
            }
            else
            {
                throw new BunqException(ErrorCouldNotDetermineSessionTimeout);
            }
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
                throw new BunqException(ErrorCouldNotDetermineSessionTimeout);
            }

            return GetDoubleFromSessionTimeout(sessionTimeout);
        }

        private static double GetDoubleFromSessionTimeout(int? sessionTimeout)
        {
            if (sessionTimeout == null)
            {
                throw new BunqException(ErrorSessionTimeoutIsNull);
            }
            else
            {
                return (double) sessionTimeout;
            }
        }
    }
}