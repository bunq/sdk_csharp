using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class CardPrimaryAccountNumberObject : BunqModel
    {
        /// <summary>
        /// The ID for this Virtual PAN.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }
        /// <summary>
        /// The description for this PAN.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// The status for this PAN, only for Online Cards.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The ID of the monetary account to assign to this PAN, only for Online Cards.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public long? MonetaryAccountId { get; set; }
        /// <summary>
        /// The UUID for this Virtual PAN.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }
        /// <summary>
        /// The last four digits of the PAN.
        /// </summary>
        [JsonProperty(PropertyName = "four_digit")]
        public string FourDigit { get; set; }
        /// <summary>
        /// The type of the PAN.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    
        public CardPrimaryAccountNumberObject(long? id)
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
    
            if (this.Type != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CardPrimaryAccountNumberObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardPrimaryAccountNumberObject>(json);
        }
    }
}
