using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Register a Payment Service Provider and provide credentials
    /// </summary>
    public class PaymentServiceProviderCredential : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "payment-service-provider-credential/{0}";

        protected const string ENDPOINT_URL_CREATE = "payment-service-provider-credential";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_CLIENT_PAYMENT_SERVICE_PROVIDER_CERTIFICATE =
            "client_payment_service_provider_certificate";

        public const string FIELD_CLIENT_PAYMENT_SERVICE_PROVIDER_CERTIFICATE_CHAIN =
            "client_payment_service_provider_certificate_chain";

        public const string FIELD_CLIENT_PUBLIC_KEY_SIGNATURE = "client_public_key_signature";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "CredentialPasswordIp";

        /// <summary>
        /// Payment Services Directive 2 compatible QSEAL certificate
        /// </summary>
        [JsonProperty(PropertyName = "client_payment_service_provider_certificate")]
        public string ClientPaymentServiceProviderCertificate { get; set; }

        /// <summary>
        /// Intermediate and root certificate belonging to the provided certificate.
        /// </summary>
        [JsonProperty(PropertyName = "client_payment_service_provider_certificate_chain")]
        public string ClientPaymentServiceProviderCertificateChain { get; set; }

        /// <summary>
        /// The Base64 encoded signature of the public key provided during installation and with the installation token
        /// appended as a nonce. Signed with the private key belonging to the QSEAL certificate.
        /// </summary>
        [JsonProperty(PropertyName = "client_public_key_signature")]
        public string ClientPublicKeySignature { get; set; }

        /// <summary>
        /// The id of the credential.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the credential object's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the credential object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The status of the credential.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// When the status is PENDING_FIRST_USE: when the credential expires.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_time")]
        public string ExpiryTime { get; set; }

        /// <summary>
        /// When the status is PENDING_FIRST_USE: the value of the token.
        /// </summary>
        [JsonProperty(PropertyName = "token_value")]
        public string TokenValue { get; set; }

        /// <summary>
        /// When the status is ACTIVE: the details of the device that may use the credential.
        /// </summary>
        [JsonProperty(PropertyName = "permitted_device")]
        public PermittedDevice PermittedDevice { get; set; }

        /// <summary>
        /// </summary>
        public static BunqResponse<PaymentServiceProviderCredential> Get(int paymentServiceProviderCredentialId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, paymentServiceProviderCredentialId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<PaymentServiceProviderCredential>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        /// <param name="clientPaymentServiceProviderCertificate">Payment Services Directive 2 compatible QSEAL certificate</param>
        /// <param name="clientPaymentServiceProviderCertificateChain">Intermediate and root certificate belonging to the provided certificate.</param>
        /// <param name="clientPublicKeySignature">The Base64 encoded signature of the public key provided during installation and with the installation token appended as a nonce. Signed with the private key belonging to the QSEAL certificate.</param>
        public static BunqResponse<int> Create(string clientPaymentServiceProviderCertificate,
            string clientPaymentServiceProviderCertificateChain, string clientPublicKeySignature,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_CLIENT_PAYMENT_SERVICE_PROVIDER_CERTIFICATE, clientPaymentServiceProviderCertificate},
                {FIELD_CLIENT_PAYMENT_SERVICE_PROVIDER_CERTIFICATE_CHAIN, clientPaymentServiceProviderCertificateChain},
                {FIELD_CLIENT_PUBLIC_KEY_SIGNATURE, clientPublicKeySignature},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(ENDPOINT_URL_CREATE, requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }

            if (this.Created != null)
            {
                return false;
            }

            if (this.Updated != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.ExpiryTime != null)
            {
                return false;
            }

            if (this.TokenValue != null)
            {
                return false;
            }

            if (this.PermittedDevice != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static PaymentServiceProviderCredential CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentServiceProviderCredential>(json);
        }
    }
}