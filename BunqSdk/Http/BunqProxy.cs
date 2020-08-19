using System;
using System.Net;

namespace Bunq.Sdk.Http
{
    public class BunqProxy : IWebProxy
    {
        public BunqProxy(string proxyUri)
            : this(new Uri(proxyUri))
        {
        }

        public BunqProxy(Uri proxyUri)
        {
            ProxyUri = proxyUri;
        }

        public Uri ProxyUri { get; set; }

        public ICredentials Credentials { get; set; }

        public Uri GetProxy(Uri destination)
        {
            return ProxyUri;
        }

        public bool IsBypassed(Uri host)
        {
            return false; /* Proxy all requests */
        }
    }
}