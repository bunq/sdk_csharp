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
    /// Used to settle a Slice group.
    /// </summary>
    public class RegistrySettlement : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/registry/{1}/registry-settlement";
        protected const string ENDPOINT_URL_READ = "user/{0}/registry/{1}/registry-settlement/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/registry/{1}/registry-settlement";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "RegistrySettlement";
    
        /// <summary>
        /// The id of the RegistrySettlement.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
        /// <summary>
        /// The timestamp of the RegistrySettlement's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
        /// <summary>
        /// The timestamp of the RegistrySettlement's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
        /// <summary>
        /// The timestamp of the Registry's settlement.
        /// </summary>
        [JsonProperty(PropertyName = "settlement_time")]
        public string SettlementTime { get; set; }
        /// <summary>
        /// The total amount spent for the RegistrySettlement.
        /// </summary>
        [JsonProperty(PropertyName = "total_amount_spent")]
        public Amount TotalAmountSpent { get; set; }
        /// <summary>
        /// The number of RegistryEntry's associated with this RegistrySettlement.
        /// </summary>
        [JsonProperty(PropertyName = "number_of_entries")]
        public int? NumberOfEntries { get; set; }
        /// <summary>
        /// The membership of the user that settled the Registry.
        /// </summary>
        [JsonProperty(PropertyName = "settled_by_alias")]
        public RegistryMembership SettledByAlias { get; set; }
        /// <summary>
        /// The membership of the user that has settled the registry.
        /// </summary>
        [JsonProperty(PropertyName = "membership_settled")]
        public RegistryMembership MembershipSettled { get; set; }
        /// <summary>
        /// List of RegistrySettlementItems
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public List<RegistrySettlementItem> Items { get; set; }
    
        /// <summary>
        /// Create a new Slice group settlement.
        /// </summary>
        public static BunqResponse<int> Create(int registryId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), registryId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Get a specific Slice group settlement.
        /// </summary>
        public static BunqResponse<RegistrySettlement> Get(int registryId, int registrySettlementId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), registryId, registrySettlementId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<RegistrySettlement>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// Get a listing of all Slice group settlements.
        /// </summary>
        public static BunqResponse<List<RegistrySettlement>> List(int registryId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), registryId), urlParams, customHeaders);
    
            return FromJsonList<RegistrySettlement>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.SettlementTime != null)
            {
                return false;
            }
    
            if (this.TotalAmountSpent != null)
            {
                return false;
            }
    
            if (this.NumberOfEntries != null)
            {
                return false;
            }
    
            if (this.SettledByAlias != null)
            {
                return false;
            }
    
            if (this.MembershipSettled != null)
            {
                return false;
            }
    
            if (this.Items != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static RegistrySettlement CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<RegistrySettlement>(json);
        }
    }
}
