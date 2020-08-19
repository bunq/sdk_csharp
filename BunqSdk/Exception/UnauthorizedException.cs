namespace Bunq.Sdk.Exception
{
    public class UnauthorizedException : ApiException
    {
        public UnauthorizedException(int responseCode, string message, string responseId)
            : base(responseCode, message, responseId)
        {
        }
    }
}