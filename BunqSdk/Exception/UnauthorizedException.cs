namespace Bunq.Sdk.Exception
{
    public class UnauthorizedException : ApiException
    {
        public UnauthorizedException(int responseCode, string message) : base(responseCode, message)
        {
        }
    }
}
