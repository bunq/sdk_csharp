using System.Collections.Generic;

namespace Bunq.Sdk.Http
{
    public class BunqResponse<T>
    {
        public T Value { get; private set; }
        public IDictionary<string, string> Headers { get; private set; }
        public Pagination Pagination { get; private set; }

        public BunqResponse(T value, IDictionary<string, string> headers, Pagination pagination = null)
        {
            Value = value;
            Headers = headers;
            Pagination = pagination;
        }
    }
}