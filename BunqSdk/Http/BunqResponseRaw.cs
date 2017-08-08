using System.Collections.Generic;

namespace Bunq.Sdk.Http
{
    public class BunqResponseRaw
    {
        public byte[] BodyBytes { get; private set; }
        public IDictionary<string, string> Headers { get; private set; }

        public BunqResponseRaw(byte[] bodyBytes, IDictionary<string, string> headers)
        {
            BodyBytes = bodyBytes;
            Headers = headers;
        }
    }
}
