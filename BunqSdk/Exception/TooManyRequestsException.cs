namespace Bunq.Sdk.Exception
{
    public class TooManyRequestsException : ApiException
    {
        public TooManyRequestsException(int responseCode, string message, string responseId)
            : base(responseCode, message, responseId)
        {
        }
    }
}