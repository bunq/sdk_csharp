using System.Collections.Generic;

namespace Bunq.Sdk.Exception
{
    public class NotFoundException : BunqError
    {
        public NotFoundException(int responseCode, string messages) : base(responseCode, messages)
        {
        }
    }
}