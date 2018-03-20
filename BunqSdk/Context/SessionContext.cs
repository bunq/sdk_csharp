using System;
using System.Diagnostics;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Core;
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
        private const string ErrorSessionserverUsercompanyIdNull = "sessionServer.UserCompany.Id != null";
        private const string ErrorsessionserverUserpersonIdNull = "sessionServer.UserPerson.Id != null";

        /// <summary>
        /// Default assumed value for session timeout.
        /// </summary>
        private const double SESSION_TIMEOUT_DEFAULT = 0.0;

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
            if (sessionServer.UserCompany != null && sessionServer.UserPerson == null)
            {
                Debug.Assert(sessionServer.UserCompany.Id != null, ErrorSessionserverUsercompanyIdNull);
                return sessionServer.UserCompany.Id.Value;
            }
            else if (sessionServer.UserPerson != null && sessionServer.UserCompany == null)
            {
                Debug.Assert(sessionServer.UserPerson.Id != null, ErrorsessionserverUserpersonIdNull);
                return sessionServer.UserPerson.Id.Value;
            }
            else
            {
                throw new BunqException(ErrorCouldNotDetermineUserId);
            }
        }

        private static double GetSessionTimeout(SessionServer sessionServer)
        {
            if (sessionServer.UserCompany != null && sessionServer.UserCompany.SessionTimeout != null)
            {
                return (double) sessionServer.UserCompany.SessionTimeout;
            }

            if (sessionServer.UserPerson != null && sessionServer.UserPerson.SessionTimeout != null)
            {
                return (double) sessionServer.UserPerson.SessionTimeout;
            }

            return SESSION_TIMEOUT_DEFAULT;
        }
    }
}
