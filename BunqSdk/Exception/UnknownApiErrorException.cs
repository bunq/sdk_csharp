namespace Bunq.Sdk.Exception
{
    /// <summary>
    /// Exception triggered by API requests failed on the server side.
    /// </summary>
    public class UnknownApiErrorException : ApiException
    {
        public UnknownApiErrorException(int responseCode, string message, string responseId)
            : base(responseCode, message, responseId)
        {
        }
    }
}
