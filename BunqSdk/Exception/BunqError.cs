using System.Collections.Generic;

namespace Bunq.Sdk.Exception
{
    public class BunqError : System.Exception
    {
        public int ResponseCode { get; private set; }
        public string Messages { get; private set; }

        /// <param name="responseCode">The HTTP Response code of the failed request.</param>
        /// <param name="messages">The list of messages related to this exception.</param>
        public BunqError(int responseCode, string messages) : base(messages)
        {
            ResponseCode = responseCode;
            Messages = messages;
        }

        protected BunqError()
        {
            throw new System.NotImplementedException();
        }
    }   
}