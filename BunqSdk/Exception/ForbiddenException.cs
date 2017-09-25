namespace Bunq.Sdk.Exception
{
    public class ForbiddenException : ApiException
    {
        public ForbiddenException(int responseCode, string message) : base(responseCode, message)
        {
        }
    }
}
