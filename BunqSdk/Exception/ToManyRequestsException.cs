using System.Collections.Generic;

namespace Bunq.Sdk.Exception
{
    public class ToManyRequestsException : BunqError
    {
        public ToManyRequestsException(int responseCode, string messages) : base(responseCode, messages)
        {
        }
    }
}