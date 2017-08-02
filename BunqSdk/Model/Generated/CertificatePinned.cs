using System;
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

        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId)
        {
            return Create(apiContext, requestMap, userId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Pin the certificate chain.
        /// </summary>
        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var response = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId), requestBytes, customHeaders);

            return ProcessForId(response.Content.ReadAsStringAsync().Result);
        }

        public static void Delete(ApiContext apiContext, int userId, int certificatePinnedId)
        {
            Delete(apiContext, userId, certificatePinnedId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Remove the pinned certificate chain with the specific ID.
        /// </summary>
        public static void Delete(ApiContext apiContext, int userId, int certificatePinnedId,
            IDictionary<String, String> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, userId, certificatePinnedId), customHeaders);
        }

        public static List<CertificatePinned> List(ApiContext apiContext, int userId)
        {
            return List(apiContext, userId, new Dictionary<string, string>());
        }

        /// <summary>
        /// List all the pinned certificate chain for the given user.
        /// </summary>
        public static List<CertificatePinned> List(ApiContext apiContext, int userId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId), customHeaders);

            return FromJsonList<CertificatePinned>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }

        public static CertificatePinned Get(ApiContext apiContext, int userId, int certificatePinnedId)
        {
            return Get(apiContext, userId, certificatePinnedId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get the pinned certificate chain with the specified ID.
        /// </summary>
        public static CertificatePinned Get(ApiContext apiContext, int userId, int certificatePinnedId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, certificatePinnedId), customHeaders);

            return FromJson<CertificatePinned>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
