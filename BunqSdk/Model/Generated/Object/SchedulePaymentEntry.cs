using System.Collections.Generic;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class SchedulePaymentEntry : BunqModel
    {
        public SchedulePaymentEntry(Amount amount, MonetaryAccountReference counterpartyAlias, string description)
        {
            Amount = amount;
            CounterpartyAlias = counterpartyAlias;
            Description = description;
        }

        /// <summary>
        ///     The Amount transferred by the Payment. Will be negative for outgoing Payments and positive for incoming
        ///     Payments (relative to the MonetaryAccount indicated by monetary_account_id).
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }

        /// <summary>
        ///     The LabelMonetaryAccount containing the public information of the other (counterparty) side of the Payment.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }

        /// <summary>
        ///     The description for the Payment. Maximum 140 characters for Payments to external IBANs, 9000 characters for
        ///     Payments to only other bunq MonetaryAccounts.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        ///     The Attachments attached to the Payment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<AttachmentMonetaryAccountPayment> Attachment { get; set; }

        /// <summary>
        ///     Optional data included with the Payment specific to the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference")]
        public string MerchantReference { get; set; }

        /// <summary>
        ///     Whether or not sending a bunq.to payment is allowed.
        /// </summary>
        [JsonProperty(PropertyName = "allow_bunqto")]
        public bool? AllowBunqto { get; set; }

        /// <summary>
        ///     The LabelMonetaryAccount containing the public information of 'this' (party) side of the Payment.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Amount != null) return false;

            if (Alias != null) return false;

            if (CounterpartyAlias != null) return false;

            if (Description != null) return false;

            if (Attachment != null) return false;

            if (MerchantReference != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static SchedulePaymentEntry CreateFromJsonString(string json)
        {
            return CreateFromJsonString<SchedulePaymentEntry>(json);
        }
    }
}