namespace Bunq.Sdk.Exception
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(int responseCode, string message, string responseId) :
            base(responseCode, message, responseId)
        {
        }
    }
}
