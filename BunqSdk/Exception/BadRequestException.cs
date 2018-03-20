namespace Bunq.Sdk.Exception
{
    public class BadRequestException : ApiException
    {
        public BadRequestException(int responseCode, string message, string responseId)
            : base(responseCode, message, responseId)
        {
        }
    }
}
