namespace Bunq.Sdk.Exception
{
    public class PleaseContactBunqException : ApiException
    {
        public PleaseContactBunqException(int responseCode, string message) : base(responseCode, message)
        {
        }
    }
}
