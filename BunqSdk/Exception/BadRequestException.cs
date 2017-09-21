using System.Collections.Generic;

namespace Bunq.Sdk.Exception
{
    public class BadRequestException : ApiException
    {
        public BadRequestException(int responseCode, string messages) : base(responseCode, messages)
        {
        }
    }
}