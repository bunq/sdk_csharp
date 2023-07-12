using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// MasterCard report view.
    /// </summary>
    public class MasterCardActionReport : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_MASTERCARD_ACTION_ID = "mastercard_action_id";
        public const string FIELD_TYPE = "type";
        public const string FIELD_STATUS = "status";
    
    
        /// <summary>
        /// The id of mastercard action being reported.
        /// </summary>
        [JsonProperty(PropertyName = "mastercard_action_id")]
        public int? MastercardActionId { get; set; }
    
        /// <summary>
        /// The id of mastercard action being reported.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    
        /// <summary>
        /// The id of mastercard action being reported.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The reported merchant.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_id")]
        public string MerchantId { get; set; }
    
        /// <summary>
        /// The name of the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_name")]
        public string MerchantName { get; set; }
    
        /// <summary>
        /// The monetary account label of the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
    
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.MastercardActionId != null)
            {
                return false;
            }
    
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.MerchantId != null)
            {
                return false;
            }
    
            if (this.MerchantName != null)
            {
                return false;
            }
    
            if (this.CounterpartyAlias != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static MasterCardActionReport CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MasterCardActionReport>(json);
        }
    }
}
