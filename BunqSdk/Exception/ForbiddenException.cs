namespace Bunq.Sdk.Exception
{
    public class ForbiddenException : ApiException
    {
        public ForbiddenException(int responseCode, string messages) : base(responseCode, messages)
        {
        }
    }
}
