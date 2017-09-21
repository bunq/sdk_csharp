using System.Collections.Generic;

namespace Bunq.Sdk.Exception
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(int responseCode, string messages) : base(responseCode, messages)
        {
        }
    }
}