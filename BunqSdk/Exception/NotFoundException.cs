namespace Bunq.Sdk.Exception
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(int responseCode, string message) : base(responseCode, message)
        {
        }
    }
}
