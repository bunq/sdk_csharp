using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint to specify that a user signed up using a promotion code.
    /// </summary>
    public class UserPartnerPromotionCashbackApiObject : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_PROMOTION_CODE = "promotion_code";
    
    
        /// <summary>
        /// The promotion code used in signup to indicate the partner that referred the user.
        /// </summary>
        [JsonProperty(PropertyName = "promotion_code")]
        public string PromotionCode { get; set; }
        /// <summary>
        /// The status of the user partner promotion.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The number of transactions that are still eligible for this promotion.
        /// </summary>
        [JsonProperty(PropertyName = "number_of_transaction_remaining")]
        public long? NumberOfTransactionRemaining { get; set; }
        /// <summary>
        /// The promotion that the user signed up with.
        /// </summary>
        [JsonProperty(PropertyName = "partner_promotion")]
        public PartnerPromotionCashbackApiObject PartnerPromotion { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.NumberOfTransactionRemaining != null)
            {
                return false;
            }
    
            if (this.PartnerPromotion != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static UserPartnerPromotionCashbackApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<UserPartnerPromotionCashbackApiObject>(json);
        }
    }
}
