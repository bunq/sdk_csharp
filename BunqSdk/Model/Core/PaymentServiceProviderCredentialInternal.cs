using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Endpoint;

namespace Bunq.Sdk.Model.Core
{
    public class PaymentServiceProviderCredentialInternal : PaymentServiceProviderCredential
    {
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "CredentialPasswordIp";

        public static BunqResponse<PaymentServiceProviderCredential> CreateWithApiContext(
            string clientPaymentServiceProviderCertificate,
            string clientPaymentServiceProviderCertificateChain, string clientPublicKeySignature,
            IDictionary<string, string> customHeaders, ApiContext apiContext)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(apiContext);

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_CLIENT_PAYMENT_SERVICE_PROVIDER_CERTIFICATE, clientPaymentServiceProviderCertificate},
                {FIELD_CLIENT_PAYMENT_SERVICE_PROVIDER_CERTIFICATE_CHAIN, clientPaymentServiceProviderCertificateChain},
                {FIELD_CLIENT_PUBLIC_KEY_SIGNATURE, clientPublicKeySignature},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(ENDPOINT_URL_CREATE, requestBytes, customHeaders);

            return FromJson<PaymentServiceProviderCredential>(responseRaw, OBJECT_TYPE_GET);
        }
    }
}