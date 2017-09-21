namespace Bunq.Sdk.Exception
{
    public class PleaseContactBunqException : ApiException
    {
        public PleaseContactBunqException(int responseCode, string messages) : base(responseCode, messages)
        {
        }
    }
}
