using System;
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
        /// Default assumed value for session timeout.
        /// </summary>
        private const double SessionTimeoutDefault = 0.0;

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

        [JsonConstructor]
        private SessionContext()
        {
        }

        public SessionContext(SessionServer sessionServer)
        {
            Token = sessionServer.SessionToken.Token;
            ExpiryTime = DateTime.Now.AddSeconds(GetSessionTimeout(sessionServer));
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

            return SessionTimeoutDefault;
        }
    }
}
