using System.Collections.Generic;

namespace Bunq.Sdk.Exception
{
    /// <summary>
    /// Exception triggered by API requests failed on the server side.
    /// </summary>
    public class ApiException : BunqError
    {
        public ApiException(int responseCode, string messages) : base(responseCode, messages)
        {
        }
    }
}
