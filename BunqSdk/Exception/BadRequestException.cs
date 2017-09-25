namespace Bunq.Sdk.Exception
{
    public class BadRequestException : ApiException
    {
        public BadRequestException(int responseCode, string message) : base(responseCode, message)
        {
        }
    }
}
