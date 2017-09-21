namespace Bunq.Sdk.Exception
{
    public class ToManyRequestsException : ApiException
    {
        public ToManyRequestsException(int responseCode, string messages) : base(responseCode, messages)
        {
        }
    }
}
