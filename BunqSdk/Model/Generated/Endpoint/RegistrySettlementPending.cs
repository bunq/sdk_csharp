using System.Collections.Generic;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to manage pending Slice group settlements.
    /// </summary>
    public class RegistrySettlementPending : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/registry/{1}/registry-settlement-pending";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "RegistrySettlementPending";

        /// <summary>
        /// List of RegistrySettlementItems
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public List<RegistrySettlementItem> Items { get; set; }

        /// <summary>
        /// Get a listing of all pending Slice group settlements.
        /// </summary>
        public static BunqResponse<List<RegistrySettlementPending>> List(int registryId,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), registryId),
                urlParams, customHeaders);

            return FromJsonList<RegistrySettlementPending>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Items != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static RegistrySettlementPending CreateFromJsonString(string json)
        {
            return CreateFromJsonString<RegistrySettlementPending>(json);
        }
    }
}