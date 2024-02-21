using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for getting the Card Replacement of a card.
    /// </summary>
    public class CardReplacement : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";
        public const string FIELD_ADDRESS_MAIN = "address_main";
        public const string FIELD_ADDRESS_POSTAL = "address_postal";
    
    
        /// <summary>
        /// The status of the CardReplacement.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The user's main address.
        /// </summary>
        [JsonProperty(PropertyName = "address_main")]
        public Address AddressMain { get; set; }
        /// <summary>
        /// The user's postal address.
        /// </summary>
        [JsonProperty(PropertyName = "address_postal")]
        public Address AddressPostal { get; set; }
        /// <summary>
        /// The original card that belongs to the CardReplacement.
        /// </summary>
        [JsonProperty(PropertyName = "card_id")]
        public int? CardId { get; set; }
        /// <summary>
        /// The new card that replaces the original card in the CardReplacement.
        /// </summary>
        [JsonProperty(PropertyName = "card_new_id")]
        public int? CardNewId { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.CardId != null)
            {
                return false;
            }
    
            if (this.CardNewId != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CardReplacement CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardReplacement>(json);
        }
    }
}
