using System.Collections.Generic;

namespace Bunq.Sdk.Exception
{
    public class BadRequestException : BunqError
    {
        public BadRequestException(int responseCode, string messages) : base(responseCode, messages)
        {
        }
    }
}