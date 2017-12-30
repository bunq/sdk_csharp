namespace Bunq.Sdk.Exception
{
    public class MethodNotAllowedException : ApiException
    {
        public MethodNotAllowedException(int responseCode, string message, string responseId) :
            base(responseCode, message, responseId)
        {
        }
    }
}
