using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class CardVirtualPrimaryAccountNumber : BunqModel
    {
        /// <summary>
        /// The ID for this Virtual PAN.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        /// <summary>
        /// The description for this Virtual PAN.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    
        /// <summary>
        /// The status for this Virtual PAN.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The ID of the monetary account to assign to this Virtual PAN.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }
    
        /// <summary>
        /// The UUID for this Virtual PAN.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }
    
        /// <summary>
        /// The last four digits of the Virtual PAN.
        /// </summary>
        [JsonProperty(PropertyName = "four_digit")]
        public string FourDigit { get; set; }
    
    
        public CardVirtualPrimaryAccountNumber(int? id)
        {
            Id = id;
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            if (this.Uuid != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.FourDigit != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CardVirtualPrimaryAccountNumber CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardVirtualPrimaryAccountNumber>(json);
        }
    }
}
