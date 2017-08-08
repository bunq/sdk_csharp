using System.Collections.Generic;

namespace Bunq.Sdk.Model
{
    public class BunqResponse<T>
    {
        public T Value { get; private set; }
        public IDictionary<string, string> Headers { get; private set; }

        public BunqResponse(T value, IDictionary<string, string> headers)
        {
            Value = value;
            Headers = headers;
        }
    }
}
