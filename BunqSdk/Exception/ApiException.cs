
namespace Bunq.Sdk.Exception
{
    public class ApiException : System.Exception
    {
        public int ResponseCode { get; private set; }

        /// <param name="responseCode">The HTTP Response code of the failed request.</param>
        /// <param name="message">The list of messages related to this exception.</param>
        public ApiException(int responseCode, string message) : base(message)
        {
            ResponseCode = responseCode;
        }
    }   
}
