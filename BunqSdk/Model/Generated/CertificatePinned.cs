using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// This endpoint allow you to pin the certificate chains to your account. These certificate chains are used for SSL
    /// validation whenever a callback is initiated to one of your https callback urls.
    /// </summary>
    public class CertificatePinned : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_CERTIFICATE_CHAIN = "certificate_chain";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/certificate-pinned";
        private const string ENDPOINT_URL_DELETE = "user/{0}/certificate-pinned/{1}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/certificate-pinned";
        private const string ENDPOINT_URL_READ = "user/{0}/certificate-pinned/{1}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "CertificatePinned";

        /// <summary>
        /// The certificate chain in .PEM format.
        /// </summary>
        [JsonProperty(PropertyName = "certificate_chain")]
        public List<Certificate> CertificateChain { get; private set; }

        /// <summary>
        /// The id generated for the pinned certificate chain.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }

        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId)
        {
            return Create(apiContext, requestMap, userId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Pin the certificate chain.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId), requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int certificatePinnedId)
        {
            return Delete(apiContext, userId, certificatePinnedId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Remove the pinned certificate chain with the specific ID.
        /// </summary>
        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int certificatePinnedId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, userId, certificatePinnedId),
                customHeaders);

            return new BunqResponse<object>(null, responseRaw.Headers);
        }

        public static BunqResponse<List<CertificatePinned>> List(ApiContext apiContext, int userId)
        {
            return List(apiContext, userId, new Dictionary<string, string>());
        }

        /// <summary>
        /// List all the pinned certificate chain for the given user.
        /// </summary>
        public static BunqResponse<List<CertificatePinned>> List(ApiContext apiContext, int userId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId), customHeaders);

            return FromJsonList<CertificatePinned>(responseRaw, OBJECT_TYPE);
        }

        public static BunqResponse<CertificatePinned> Get(ApiContext apiContext, int userId, int certificatePinnedId)
        {
            return Get(apiContext, userId, certificatePinnedId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get the pinned certificate chain with the specified ID.
        /// </summary>
        public static BunqResponse<CertificatePinned> Get(ApiContext apiContext, int userId, int certificatePinnedId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, certificatePinnedId),
                customHeaders);

            return FromJson<CertificatePinned>(responseRaw, OBJECT_TYPE);
        }
    }
}
