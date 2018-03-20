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
    /// The public endpoint for retrieving and updating a promotion display model.
    /// </summary>
    public class PromotionDisplay : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/promotion-display/{1}";

        protected const string ENDPOINT_URL_UPDATE = "user/{0}/promotion-display/{1}";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "PromotionDisplay";

        /// <summary>
        /// The id of the promotion.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The alias of the user you received the promotion from.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }

        /// <summary>
        /// The event description of the promotion appearing on time line.
        /// </summary>
        [JsonProperty(PropertyName = "event_description")]
        public string EventDescription { get; set; }

        /// <summary>
        /// The status of the promotion. (CREATED, CLAIMED, EXPIRED, DISCARDED)
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        public static BunqResponse<PromotionDisplay> Get(int promotionDisplayId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), promotionDisplayId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<PromotionDisplay>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        /// <param name="status">The status of the promotion. User can set it to discarded.</param>
        public static BunqResponse<int> Update(int promotionDisplayId, string status = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_STATUS, status},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), promotionDisplayId),
                requestBytes, customHeaders);

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