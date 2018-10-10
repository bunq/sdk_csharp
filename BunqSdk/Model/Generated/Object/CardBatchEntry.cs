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
        /// The activation code required to set status to ACTIVE initially. Can only set status to ACTIVE using
        /// activation code when order_status is ACCEPTED_FOR_PRODUCTION and status is DEACTIVATED.
        /// </summary>
        [JsonProperty(PropertyName = "activation_code")]
        public string ActivationCode { get; set; }

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
        /// The limits to define for the card, among CARD_LIMIT_ATM and CARD_LIMIT_POS_ICC. All the limits must be
        /// provided on update.
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public List<CardLimit> Limit { get; set; }

        /// <summary>
        /// Whether or not it is allowed to use the mag stripe for the card.
        /// </summary>
        [JsonProperty(PropertyName = "mag_stripe_permission")]
        public CardMagStripePermission MagStripePermission { get; set; }

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