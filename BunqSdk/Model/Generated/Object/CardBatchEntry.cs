using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class CardBatchEntry : BunqModel
    {
        /// <summary>
        /// The ID of the card that needs to be updated.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The status to set for the card. Can be ACTIVE, DEACTIVATED, LOST, STOLEN or CANCELLED, and can only be set
        /// to LOST/STOLEN/CANCELLED when order status is
        /// ACCEPTED_FOR_PRODUCTION/DELIVERED_TO_CUSTOMER/CARD_UPDATE_REQUESTED/CARD_UPDATE_SENT/CARD_UPDATE_ACCEPTED.
        /// Can only be set to DEACTIVATED after initial activation, i.e. order_status is
        /// DELIVERED_TO_CUSTOMER/CARD_UPDATE_REQUESTED/CARD_UPDATE_SENT/CARD_UPDATE_ACCEPTED. Mind that all the
        /// possible choices (apart from ACTIVE and DEACTIVATED) are permanent and cannot be changed after.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The spending limit for the card.
        /// </summary>
        [JsonProperty(PropertyName = "card_limit")]
        public Amount CardLimit { get; set; }

        /// <summary>
        /// The ATM spending limit for the card.
        /// </summary>
        [JsonProperty(PropertyName = "card_limit_atm")]
        public Amount CardLimitAtm { get; set; }

        /// <summary>
        /// The countries for which to grant (temporary) permissions to use the card.
        /// </summary>
        [JsonProperty(PropertyName = "country_permission")]
        public List<CardCountryPermission> CountryPermission { get; set; }

        /// <summary>
        /// ID of the MA to be used as fallback for this card if insufficient balance. Fallback account is removed if
        /// not supplied.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id_fallback")]
        public int? MonetaryAccountIdFallback { get; set; }

        public CardBatchEntry(int? id)
        {
            Id = id;
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }

        /// <summary>
        /// </summary>
        public static CardBatchEntry CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardBatchEntry>(json);
        }
    }
}