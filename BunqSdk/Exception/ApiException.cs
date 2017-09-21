
namespace Bunq.Sdk.Exception
{
    public class ApiException : System.Exception
    {
        public int ResponseCode { get; private set; }
        public string Messages { get; private set; }

        /// <param name="responseCode">The HTTP Response code of the failed request.</param>
        /// <param name="messages">The list of messages related to this exception.</param>
        public ApiException(int responseCode, string messages) : base(messages)
        {
            ResponseCode = responseCode;
            Messages = messages;
        }
    }   
}
