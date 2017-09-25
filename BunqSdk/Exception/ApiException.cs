
namespace Bunq.Sdk.Exception
{
    public class ApiException : System.Exception
    {
        private readonly string message;
        public int ResponseCode { get; private set; }

        public override string Message
        {
            get { return message; }
        }

        /// <param name="responseCode">The HTTP Response code of the failed request.</param>
        /// <param name="message">The list of messages related to this exception.</param>
        public ApiException(int responseCode, string message) : base(message)
        {
            ResponseCode = responseCode;
            this.message = message;
        }
    }   
}
