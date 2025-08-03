using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// MasterCard transaction view.
    /// </summary>
    public class MasterCardPaymentApiObject : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/mastercard-action/{2}/payment";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "Payment";
    
        /// <summary>
        /// The id of the Payment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }
        /// <summary>
        /// The timestamp when the Payment was done.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
        /// <summary>
        /// The timestamp when the Payment was last updated (will be updated when chat messages are received).
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
        /// <summary>
        /// The id of the MonetaryAccount the Payment was made to or from (depending on whether this is an incoming or
        /// outgoing Payment).
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public long? MonetaryAccountId { get; set; }
        /// <summary>
        /// The Amount transferred by the Payment. Will be negative for outgoing Payments and positive for incoming
        /// Payments (relative to the MonetaryAccount indicated by monetary_account_id).
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public AmountObject Amount { get; set; }
        /// <summary>
        /// The LabelMonetaryAccount containing the public information of 'this' (party) side of the Payment.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
        /// <summary>
        /// The LabelMonetaryAccount containing the public information of the other (counterparty) side of the Payment.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
        /// <summary>
        /// The description for the Payment. Maximum 140 characters for Payments to external IBANs, 9000 characters for
        /// Payments to only other bunq MonetaryAccounts.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// The type of Payment, can be BUNQ, EBA_SCT, EBA_SDD, IDEAL, SWIFT or FIS (card).
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        /// <summary>
        /// The sub-type of the Payment, can be PAYMENT, WITHDRAWAL, REVERSAL, REQUEST, BILLING, SCT, SDD or NLO.
        /// </summary>
        [JsonProperty(PropertyName = "sub_type")]
        public string SubType { get; set; }
        /// <summary>
        /// Information about the expected arrival of the payment.
        /// </summary>
        [JsonProperty(PropertyName = "payment_arrival_expected")]
        public PaymentArrivalExpectedObject PaymentArrivalExpected { get; set; }
        /// <summary>
        /// The status of the bunq.to payment.
        /// </summary>
        [JsonProperty(PropertyName = "bunqto_status")]
        public string BunqtoStatus { get; set; }
        /// <summary>
        /// The sub status of the bunq.to payment.
        /// </summary>
        [JsonProperty(PropertyName = "bunqto_sub_status")]
        public string BunqtoSubStatus { get; set; }
        /// <summary>
        /// The status of the bunq.to payment.
        /// </summary>
        [JsonProperty(PropertyName = "bunqto_share_url")]
        public string BunqtoShareUrl { get; set; }
        /// <summary>
        /// When bunq.to payment is about to expire.
        /// </summary>
        [JsonProperty(PropertyName = "bunqto_expiry")]
        public string BunqtoExpiry { get; set; }
        /// <summary>
        /// The timestamp of when the bunq.to payment was responded to.
        /// </summary>
        [JsonProperty(PropertyName = "bunqto_time_responded")]
        public string BunqtoTimeResponded { get; set; }
        /// <summary>
        /// The Attachments attached to the Payment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<AttachmentMonetaryAccountPaymentObject> Attachment { get; set; }
        /// <summary>
        /// Optional data included with the Payment specific to the merchant.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference")]
        public string MerchantReference { get; set; }
        /// <summary>
        /// The id of the PaymentBatch if this Payment was part of one.
        /// </summary>
        [JsonProperty(PropertyName = "batch_id")]
        public long? BatchId { get; set; }
        /// <summary>
        /// The id of the JobScheduled if the Payment was scheduled.
        /// </summary>
        [JsonProperty(PropertyName = "scheduled_id")]
        public long? ScheduledId { get; set; }
        /// <summary>
        /// A shipping Address provided with the Payment, currently unused.
        /// </summary>
        [JsonProperty(PropertyName = "address_shipping")]
        public AddressObject AddressShipping { get; set; }
        /// <summary>
        /// A billing Address provided with the Payment, currently unused.
        /// </summary>
        [JsonProperty(PropertyName = "address_billing")]
        public AddressObject AddressBilling { get; set; }
        /// <summary>
        /// The Geolocation where the Payment was done from.
        /// </summary>
        [JsonProperty(PropertyName = "geolocation")]
        public GeolocationObject Geolocation { get; set; }
        /// <summary>
        /// The reference to the object used for split the bill. Can be RequestInquiry or RequestInquiryBatch
        /// </summary>
        [JsonProperty(PropertyName = "request_reference_split_the_bill")]
        public List<RequestInquiryReferenceObject> RequestReferenceSplitTheBill { get; set; }
        /// <summary>
        /// The new balance of the monetary account after the mutation.
        /// </summary>
        [JsonProperty(PropertyName = "balance_after_mutation")]
        public AmountObject BalanceAfterMutation { get; set; }
        /// <summary>
        /// A reference to the PaymentAutoAllocateInstance if it exists.
        /// </summary>
        [JsonProperty(PropertyName = "payment_auto_allocate_instance")]
        public PaymentAutoAllocateInstanceApiObject PaymentAutoAllocateInstance { get; set; }
        /// <summary>
        /// A reference to the PaymentSuspendedOutgoing if it exists.
        /// </summary>
        [JsonProperty(PropertyName = "payment_suspended_outgoing")]
        public PaymentSuspendedOutgoingApiObject PaymentSuspendedOutgoing { get; set; }
        /// <summary>
        /// Incurred fee for the payment.
        /// </summary>
        [JsonProperty(PropertyName = "payment_fee")]
        public PaymentFeeObject PaymentFee { get; set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<MasterCardPaymentApiObject>> List(long mastercardActionId, long? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), mastercardActionId), urlParams, customHeaders);
    
            return FromJsonList<MasterCardPaymentApiObject>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            if (this.Created != null)
            {
                return false;
            }
    
            if (this.Updated != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.Amount != null)
            {
                return false;
            }
    
            if (this.Alias != null)
            {
                return false;
            }
    
            if (this.CounterpartyAlias != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.SubType != null)
            {
                return false;
            }
    
            if (this.PaymentArrivalExpected != null)
            {
                return false;
            }
    
            if (this.BunqtoStatus != null)
            {
                return false;
            }
    
            if (this.BunqtoSubStatus != null)
            {
                return false;
            }
    
            if (this.BunqtoShareUrl != null)
            {
                return false;
            }
    
            if (this.BunqtoExpiry != null)
            {
                return false;
            }
    
            if (this.BunqtoTimeResponded != null)
            {
                return false;
            }
    
            if (this.Attachment != null)
            {
                return false;
            }
    
            if (this.MerchantReference != null)
            {
                return false;
            }
    
            if (this.BatchId != null)
            {
                return false;
            }
    
            if (this.ScheduledId != null)
            {
                return false;
            }
    
            if (this.AddressShipping != null)
            {
                return false;
            }
    
            if (this.AddressBilling != null)
            {
                return false;
            }
    
            if (this.Geolocation != null)
            {
                return false;
            }
    
            if (this.RequestReferenceSplitTheBill != null)
            {
                return false;
            }
    
            if (this.BalanceAfterMutation != null)
            {
                return false;
            }
    
            if (this.PaymentAutoAllocateInstance != null)
            {
                return false;
            }
    
            if (this.PaymentSuspendedOutgoing != null)
            {
                return false;
            }
    
            if (this.PaymentFee != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static MasterCardPaymentApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MasterCardPaymentApiObject>(json);
        }
    }
}
