namespace Bunq.Sdk.Exception
{
    public class ForbiddenException : ApiException
    {
        public ForbiddenException(int responseCode, string message, string responseId)
            : base(responseCode, message, responseId)
        {
        }
    }
}