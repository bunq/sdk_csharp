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
    /// It is possible to order a card replacement with the bunq API.<br/><br/>You can order up to three free card
    /// replacements per year. Additional replacement requests will be billed.<br/><br/>The card replacement will have
    /// the same expiry date and the same pricing as the old card, but it will have a new card number. You can change
    /// the description and PIN through the card replacement endpoint.
    /// </summary>
    public class CardReplace : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlCreate = "user/{0}/card/{1}/replace";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FieldPinCode = "pin_code";
        public const string FieldSecondLine = "second_line";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "CardReplace";
    
        /// <summary>
        /// The id of the new card.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// Request a card replacement.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int cardId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            requestBytes = SecurityUtils.Encrypt(apiContext, requestBytes, customHeaders);
            var responseRaw = apiClient.Post(string.Format(EndpointUrlCreate, userId, cardId), requestBytes, customHeaders);
    
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
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CardReplace CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardReplace>(json);
        }
    }
}
