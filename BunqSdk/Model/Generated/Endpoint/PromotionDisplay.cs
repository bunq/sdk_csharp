using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// The public endpoint for retrieving and updating a promotion display model.
    /// </summary>
    public class PromotionDisplay : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlRead = "user/{0}/promotion-display/{1}";
        private const string EndpointUrlUpdate = "user/{0}/promotion-display/{1}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FieldStatus = "status";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "PromotionDisplay";
    
        /// <summary>
        /// The id of the promotion.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The alias of the user you received the promotion from.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; private set; }
    
        /// <summary>
        /// The event description of the promotion appearing on time line.
        /// </summary>
        [JsonProperty(PropertyName = "event_description")]
        public string EventDescription { get; private set; }
    
        /// <summary>
        /// The status of the promotion. (CREATED, CLAIMED, EXPIRED, DISCARDED)
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<PromotionDisplay> Get(ApiContext apiContext, int userId, int promotionDisplayId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlRead, userId, promotionDisplayId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<PromotionDisplay>(responseRaw, ObjectType);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int promotionDisplayId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(EndpointUrlUpdate, userId, promotionDisplayId), requestBytes, customHeaders);
    
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
    
            if (this.CounterpartyAlias != null)
            {
                return false;
            }
    
            if (this.EventDescription != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static PromotionDisplay CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PromotionDisplay>(json);
        }
    }
}
