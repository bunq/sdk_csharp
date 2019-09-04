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
    /// Used to update multiple cards in a batch.
    /// </summary>
    public class CardBatch : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/card-batch";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_CARDS = "cards";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_POST = "CardBatch";
    
        /// <summary>
        /// The cards that need to be updated.
        /// </summary>
        [JsonProperty(PropertyName = "cards")]
        public List<CardBatchEntry> Cards { get; set; }
    
        /// <summary>
        /// The ids of the cards that have been updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated_card_ids")]
        public List<BunqId> UpdatedCardIds { get; set; }
    
    
        /// <summary>
        /// </summary>
        /// <param name="cards">The cards that need to be updated.</param>
        public static BunqResponse<CardBatch> Create(List<CardBatchEntry> cards, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_CARDS, cards},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes, customHeaders);
    
            return FromJson<CardBatch>(responseRaw, OBJECT_TYPE_POST);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.UpdatedCardIds != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CardBatch CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardBatch>(json);
        }
    }
}
