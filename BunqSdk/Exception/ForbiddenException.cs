using System.Collections.Generic;

namespace Bunq.Sdk.Exception
{
    public class ForbiddenException : BunqError
    {
        public ForbiddenException(int responseCode, string messages) : base(responseCode, messages)
        {
        }
    }
}