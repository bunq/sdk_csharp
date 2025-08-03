using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Read the publicly available information of a partner’s promotion.
    /// </summary>
    public class PartnerPromotionCashbackApiObject : BunqModel
    {
        /// <summary>
        /// The public UUID of the cashback promotion.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; set; }
        /// <summary>
        /// The status of the cashback promotion.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The promotion code used in signup to indicate the partner that referred the user.
        /// </summary>
        [JsonProperty(PropertyName = "promotion_code")]
        public string PromotionCode { get; set; }
        /// <summary>
        /// The amount of cashback per transaction, will not be higher than the amount of the transaction.
        /// </summary>
        [JsonProperty(PropertyName = "amount_cashback_per_transaction_maximum")]
        public AmountObject AmountCashbackPerTransactionMaximum { get; set; }
        /// <summary>
        /// The maximum number of transactions that can be made.
        /// </summary>
        [JsonProperty(PropertyName = "number_of_transaction_maximum")]
        public long? NumberOfTransactionMaximum { get; set; }
        /// <summary>
        /// The minimum amount of a transaction.
        /// </summary>
        [JsonProperty(PropertyName = "amount_transaction_minimum")]
        public AmountObject AmountTransactionMinimum { get; set; }
        /// <summary>
        /// The URL to the Together page with FAQs about this promotion.
        /// </summary>
        [JsonProperty(PropertyName = "url_together")]
        public string UrlTogether { get; set; }
        /// <summary>
        /// The deeplink to the cashback promotion.
        /// </summary>
        [JsonProperty(PropertyName = "deeplink")]
        public string Deeplink { get; set; }
        /// <summary>
        /// The name of the partner.
        /// </summary>
        [JsonProperty(PropertyName = "partner_name")]
        public string PartnerName { get; set; }
        /// <summary>
        /// The avatar of the partner.
        /// </summary>
        [JsonProperty(PropertyName = "partner_avatar")]
        public AvatarObject PartnerAvatar { get; set; }
        /// <summary>
        /// The short title of the promotion.
        /// </summary>
        [JsonProperty(PropertyName = "promotion_title_short")]
        public List<string> PromotionTitleShort { get; set; }
        /// <summary>
        /// The long title of the promotion.
        /// </summary>
        [JsonProperty(PropertyName = "promotion_title_long")]
        public List<string> PromotionTitleLong { get; set; }
        /// <summary>
        /// The description of the promotion.
        /// </summary>
        [JsonProperty(PropertyName = "promotion_description")]
        public List<string> PromotionDescription { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.PublicUuid != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.PromotionCode != null)
            {
                return false;
            }
    
            if (this.AmountCashbackPerTransactionMaximum != null)
            {
                return false;
            }
    
            if (this.NumberOfTransactionMaximum != null)
            {
                return false;
            }
    
            if (this.AmountTransactionMinimum != null)
            {
                return false;
            }
    
            if (this.UrlTogether != null)
            {
                return false;
            }
    
            if (this.Deeplink != null)
            {
                return false;
            }
    
            if (this.PartnerName != null)
            {
                return false;
            }
    
            if (this.PartnerAvatar != null)
            {
                return false;
            }
    
            if (this.PromotionTitleShort != null)
            {
                return false;
            }
    
            if (this.PromotionTitleLong != null)
            {
                return false;
            }
    
            if (this.PromotionDescription != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static PartnerPromotionCashbackApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PartnerPromotionCashbackApiObject>(json);
        }
    }
}
