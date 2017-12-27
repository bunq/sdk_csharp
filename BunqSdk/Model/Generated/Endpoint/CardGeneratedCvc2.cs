using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Security;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for generating and retrieving a new CVC2 code.
    /// </summary>
    public class CardGeneratedCvc2 : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlCreate = "user/{0}/card/{1}/generated-cvc2";
        private const string EndpointUrlRead = "user/{0}/card/{1}/generated-cvc2/{2}";
        private const string EndpointUrlListing = "user/{0}/card/{1}/generated-cvc2";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "CardGeneratedCvc2";
    
        /// <summary>
        /// The id of the cvc code.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp of the cvc code's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp of the cvc code's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The cvc2 code.
        /// </summary>
        [JsonProperty(PropertyName = "cvc2")]
        public string Cvc2 { get; private set; }
    
        /// <summary>
        /// The status of the cvc2. Can be AVAILABLE, USED, EXPIRED, BLOCKED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// Expiry time of the cvc2.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_time")]
        public string ExpiryTime { get; private set; }
    
        /// <summary>
        /// Generate a new CVC2 code for a card.
        /// </summary>
        public static BunqResponse<CardGeneratedCvc2> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int cardId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            requestBytes = SecurityUtils.Encrypt(apiContext, requestBytes, customHeaders);
            var responseRaw = apiClient.Post(string.Format(EndpointUrlCreate, userId, cardId), requestBytes, customHeaders);
    
            return FromJson<CardGeneratedCvc2>(responseRaw, ObjectType);
        }
    
        /// <summary>
        /// Get the details for a specific generated CVC2 code.
        /// </summary>
        public static BunqResponse<CardGeneratedCvc2> Get(ApiContext apiContext, int userId, int cardId, int cardGeneratedCvc2Id, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlRead, userId, cardId, cardGeneratedCvc2Id), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<CardGeneratedCvc2>(responseRaw, ObjectType);
        }
    
        /// <summary>
        /// Get all generated CVC2 codes for a card.
        /// </summary>
        public static BunqResponse<List<CardGeneratedCvc2>> List(ApiContext apiContext, int userId, int cardId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlListing, userId, cardId), urlParams, customHeaders);
    
            return FromJsonList<CardGeneratedCvc2>(responseRaw, ObjectType);
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
    
            if (this.Cvc2 != null)
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
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CardGeneratedCvc2 CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardGeneratedCvc2>(json);
        }
    }
}
