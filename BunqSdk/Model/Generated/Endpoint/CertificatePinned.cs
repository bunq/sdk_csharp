using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// This endpoint allow you to pin the certificate chains to your account. These certificate chains are used for SSL
    /// validation whenever a callback is initiated to one of your https callback urls.
    /// </summary>
    public class CertificatePinned : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/certificate-pinned";
        protected const string ENDPOINT_URL_DELETE = "user/{0}/certificate-pinned/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/certificate-pinned";
        protected const string ENDPOINT_URL_READ = "user/{0}/certificate-pinned/{1}";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_CERTIFICATE_CHAIN = "certificate_chain";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "CertificatePinned";

        /// <summary>
        /// The certificate chain in .PEM format. Certificates are glued with newline characters.
        /// </summary>
        [JsonProperty(PropertyName = "certificate_chain")]
        public string CertificateChain { get; set; }

        /// <summary>
        /// The id generated for the pinned certificate chain.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }


        /// <summary>
        /// Pin the certificate chain.
        /// </summary>
        /// <param name="certificateChain">The certificate chain in .PEM format.</param>
        public static BunqResponse<int> Create(List<Certificate> certificateChain,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_CERTIFICATE_CHAIN, certificateChain},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes,
                customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Remove the pinned certificate chain with the specific ID.
        /// </summary>
        public static BunqResponse<object> Delete(int certificatePinnedId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, DetermineUserId(), certificatePinnedId),
                    customHeaders);

            return new BunqResponse<object>(null, responseRaw.Headers);
        }

        /// <summary>
        /// List all the pinned certificate chain for the given user.
        /// </summary>
        public static BunqResponse<List<CertificatePinned>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<CertificatePinned>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Get the pinned certificate chain with the specified ID.
        /// </summary>
        public static BunqResponse<CertificatePinned> Get(int certificatePinnedId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), certificatePinnedId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<CertificatePinned>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.CertificateChain != null)
            {
                return false;
            }

            if (this.Id != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static CertificatePinned CreateFromJsonString(string json)
        {
            return CreateFromJsonString<CertificatePinned>(json);
        }
    }
}