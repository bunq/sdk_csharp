namespace Bunq.Sdk.Exception
{
    public class PleaseContactBunqException : ApiException
    {
        public PleaseContactBunqException(int responseCode, string message, string responseId) :
            base(responseCode, message, responseId)
        {
        }
    }
}
