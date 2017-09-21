using System.Collections.Generic;

namespace Bunq.Sdk.Exception
{
    public class UnauthorizedException : ApiException
    {
        public UnauthorizedException(int responseCode, string messages) : base(responseCode, messages)
        {
        }
    }
}