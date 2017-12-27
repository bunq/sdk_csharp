using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

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
        private const string EndpointUrlCreate = "user/{0}/certificate-pinned";
        private const string EndpointUrlDelete = "user/{0}/certificate-pinned/{1}";
        private const string EndpointUrlListing = "user/{0}/certificate-pinned";
        private const string EndpointUrlRead = "user/{0}/certificate-pinned/{1}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FieldCertificateChain = "certificate_chain";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "CertificatePinned";
    
        /// <summary>
        /// The certificate chain in .PEM format. Certificates are glued with newline characters.
        /// </summary>
        [JsonProperty(PropertyName = "certificate_chain")]
        public string CertificateChain { get; private set; }
    
        /// <summary>
        /// The id generated for the pinned certificate chain.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// Pin the certificate chain.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(EndpointUrlCreate, userId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Remove the pinned certificate chain with the specific ID.
        /// </summary>
        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int certificatePinnedId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Delete(string.Format(EndpointUrlDelete, userId, certificatePinnedId), customHeaders);
    
            return new BunqResponse<object>(null, responseRaw.Headers);
        }
    
        /// <summary>
        /// List all the pinned certificate chain for the given user.
        /// </summary>
        public static BunqResponse<List<CertificatePinned>> List(ApiContext apiContext, int userId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlListing, userId), urlParams, customHeaders);
    
            return FromJsonList<CertificatePinned>(responseRaw, ObjectType);
        }
    
        /// <summary>
        /// Get the pinned certificate chain with the specified ID.
        /// </summary>
        public static BunqResponse<CertificatePinned> Get(ApiContext apiContext, int userId, int certificatePinnedId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlRead, userId, certificatePinnedId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<CertificatePinned>(responseRaw, ObjectType);
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
            return BunqModel.CreateFromJsonString<CertificatePinned>(json);
        }
    }
}
