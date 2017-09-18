using System.Collections.Generic;

namespace Bunq.Sdk.Exception
{
    public class PleaseContactBunqException : BunqError
    {
        public PleaseContactBunqException(int responseCode, string messages) : base(responseCode, messages)
        {
        }
    }
}