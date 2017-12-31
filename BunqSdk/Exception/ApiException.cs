
namespace Bunq.Sdk.Exception
{
    public class ApiException : System.Exception
    {
        public int ResponseCode { get; private set; }
        public string ResponseId { get; private set; }

        /// <inheritdoc />
        /// <param name="responseCode">The HTTP Response code of the failed request.</param>
        /// <param name="message">The error message related to this exception.</param>
        /// <param name="responseId"></param>
        protected ApiException(int responseCode, string message, string responseId) : base(message)
        {
            ResponseCode = responseCode;
            ResponseId = responseId;
        }
    }   
}
