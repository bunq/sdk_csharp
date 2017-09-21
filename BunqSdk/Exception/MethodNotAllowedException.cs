using System.Collections.Generic;

namespace Bunq.Sdk.Exception
{
    public class MethodNotAllowedException : ApiException
    {
        public MethodNotAllowedException(int responseCode, string messages) : base(responseCode, messages)
        {
        }
    }
}