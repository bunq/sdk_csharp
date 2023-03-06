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
    /// A RequestResponse is what a user on the other side of a RequestInquiry gets when he is sent one. So a
    /// RequestInquiry is the initiator and visible for the user that sent it and that wants to receive the money. A
    /// RequestResponse is what the other side sees, i.e. the user that pays the money to accept the request. The
    /// content is almost identical.
    /// </summary>
    public class RequestResponse : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/request-response/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/request-response";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/request-response/{2}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_AMOUNT_RESPONDED = "amount_responded";
        public const string FIELD_STATUS = "status";
        public const string FIELD_ADDRESS_SHIPPING = "address_shipping";
        public const string FIELD_ADDRESS_BILLING = "address_billing";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_PUT = "RequestResponse";
        private const string OBJECT_TYPE_GET = "RequestResponse";
    
        /// <summary>
        /// The Amount the RequestResponse was accepted with.
        /// </summary>
        [JsonProperty(PropertyName = "amount_responded")]
        public Amount AmountResponded { get; set; }
    
        /// <summary>
        /// The status of the RequestResponse. Can be ACCEPTED, PENDING, REJECTED, REFUND_REQUESTED, REFUNDED or
        /// REVOKED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The shipping address provided by the accepting user if an address was requested.
        /// </summary>
        [JsonProperty(PropertyName = "address_shipping")]
        public Address AddressShipping { get; set; }
    
        /// <summary>
        /// The billing address provided by the accepting user if an address was requested.
        /// </summary>
        [JsonProperty(PropertyName = "address_billing")]
        public Address AddressBilling { get; set; }
    
        /// <summary>
        /// The id of the Request Response.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        /// <summary>
        /// The timestamp when the Request Response was created.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
    
        /// <summary>
        /// The timestamp when the Request Response was last updated (will be updated when chat messages are received).
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
    
        /// <summary>
        /// The timestamp of when the RequestResponse was responded to.
        /// </summary>
        [JsonProperty(PropertyName = "time_responded")]
        public string TimeResponded { get; set; }
    
        /// <summary>
        /// The timestamp of when the RequestResponse expired or will expire.
        /// </summary>
        [JsonProperty(PropertyName = "time_expiry")]
        public string TimeExpiry { get; set; }
    
        /// <summary>
        /// The timestamp of when a refund request for the RequestResponse was claimed.
        /// </summary>
        [JsonProperty(PropertyName = "time_refund_requested")]
        public string TimeRefundRequested { get; set; }
    
        /// <summary>
        /// The timestamp of when the RequestResponse was refunded.
        /// </summary>
        [JsonProperty(PropertyName = "time_refunded")]
        public string TimeRefunded { get; set; }
    
        /// <summary>
        /// The label of the user that requested the refund.
        /// </summary>
        [JsonProperty(PropertyName = "user_refund_requested")]
        public MonetaryAccountReference UserRefundRequested { get; set; }
    
        /// <summary>
        /// The id of the MonetaryAccount the RequestResponse was received on.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }
    
        /// <summary>
        /// The requested Amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount_inquired")]
        public Amount AmountInquired { get; set; }
    
        /// <summary>
        /// The description for the RequestResponse provided by the requesting party. Maximum 9000 characters.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    
        /// <summary>
        /// The LabelMonetaryAccount with the public information of the MonetaryAccount this RequestResponse was
        /// received on.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
    
        /// <summary>
        /// The LabelMonetaryAccount with the public information of the MonetaryAccount that is requesting money with
        /// this RequestResponse.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
    
        /// <summary>
        /// The Attachments attached to the RequestResponse.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<Attachment> Attachment { get; set; }
    
        /// <summary>
        /// The minimum age the user accepting the RequestResponse must have.
        /// </summary>
        [JsonProperty(PropertyName = "minimum_age")]
        public int? MinimumAge { get; set; }
    
        /// <summary>
        /// Whether or not an address must be provided on accept.
        /// </summary>
        [JsonProperty(PropertyName = "require_address")]
        public string RequireAddress { get; set; }
    
        /// <summary>
        /// The Geolocation where the RequestResponse was created.
        /// </summary>
        [JsonProperty(PropertyName = "geolocation")]
        public Geolocation Geolocation { get; set; }
    
        /// <summary>
        /// The type of the RequestInquiry. Can be DIRECT_DEBIT, DIRECT_DEBIT_B2B, IDEAL, SOFORT or INTERNAL.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    
        /// <summary>
        /// The subtype of the RequestInquiry. Can be ONCE or RECURRING for DIRECT_DEBIT RequestInquiries and NONE for
        /// all other.
        /// </summary>
        [JsonProperty(PropertyName = "sub_type")]
        public string SubType { get; set; }
    
        /// <summary>
        /// The URL which the user is sent to after accepting or rejecting the Request.
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }
    
        /// <summary>
        /// The credit scheme id provided by the counterparty for DIRECT_DEBIT inquiries.
        /// </summary>
        [JsonProperty(PropertyName = "credit_scheme_identifier")]
        public string CreditSchemeIdentifier { get; set; }
    
        /// <summary>
        /// The mandate id provided by the counterparty for DIRECT_DEBIT inquiries.
        /// </summary>
        [JsonProperty(PropertyName = "mandate_identifier")]
        public string MandateIdentifier { get; set; }
    
        /// <summary>
        /// The whitelist id for this action or null.
        /// </summary>
        [JsonProperty(PropertyName = "eligible_whitelist_id")]
        public int? EligibleWhitelistId { get; set; }
    
        /// <summary>
        /// The reference to the object used for split the bill. Can be RequestInquiry or RequestInquiryBatch
        /// </summary>
        [JsonProperty(PropertyName = "request_reference_split_the_bill")]
        public List<RequestInquiryReference> RequestReferenceSplitTheBill { get; set; }
    
        /// <summary>
        /// The ID of the latest event for the request.
        /// </summary>
        [JsonProperty(PropertyName = "event_id")]
        public int? EventId { get; set; }
    
    
        /// <summary>
        /// Update the status to accept or reject the RequestResponse.
        /// </summary>
        /// <param name="amountResponded">The Amount the user decides to pay.</param>
        /// <param name="status">The responding status of the RequestResponse. Can be ACCEPTED or REJECTED.</param>
        /// <param name="addressShipping">The shipping Address to return to the user who created the RequestInquiry. Should only be provided if 'require_address' is set to SHIPPING, BILLING_SHIPPING or OPTIONAL.</param>
        /// <param name="addressBilling">The billing Address to return to the user who created the RequestInquiry. Should only be provided if 'require_address' is set to BILLING, BILLING_SHIPPING or OPTIONAL.</param>
        public static BunqResponse<RequestResponse> Update(int requestResponseId, int? monetaryAccountId= null, Amount amountResponded = null, string status = null, Address addressShipping = null, Address addressBilling = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_AMOUNT_RESPONDED, amountResponded},
    {FIELD_STATUS, status},
    {FIELD_ADDRESS_SHIPPING, addressShipping},
    {FIELD_ADDRESS_BILLING, addressBilling},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), requestResponseId), requestBytes, customHeaders);
    
            return FromJson<RequestResponse>(responseRaw, OBJECT_TYPE_PUT);
        }
    
        /// <summary>
        /// Get all RequestResponses for a MonetaryAccount.
        /// </summary>
        public static BunqResponse<List<RequestResponse>> List(int? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);
    
            return FromJsonList<RequestResponse>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// Get the details for a specific existing RequestResponse.
        /// </summary>
        public static BunqResponse<RequestResponse> Get(int requestResponseId, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), requestResponseId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<RequestResponse>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.TimeResponded != null)
            {
                return false;
            }
    
            if (this.TimeExpiry != null)
            {
                return false;
            }
    
            if (this.TimeRefundRequested != null)
            {
                return false;
            }
    
            if (this.TimeRefunded != null)
            {
                return false;
            }
    
            if (this.UserRefundRequested != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.AmountInquired != null)
            {
                return false;
            }
    
            if (this.AmountResponded != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.Description != null)
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
    
            if (this.Attachment != null)
            {
                return false;
            }
    
            if (this.MinimumAge != null)
            {
                return false;
            }
    
            if (this.RequireAddress != null)
            {
                return false;
            }
    
            if (this.Geolocation != null)
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
    
            if (this.RedirectUrl != null)
            {
                return false;
            }
    
            if (this.AddressBilling != null)
            {
                return false;
            }
    
            if (this.AddressShipping != null)
            {
                return false;
            }
    
            if (this.CreditSchemeIdentifier != null)
            {
                return false;
            }
    
            if (this.MandateIdentifier != null)
            {
                return false;
            }
    
            if (this.EligibleWhitelistId != null)
            {
                return false;
            }
    
            if (this.RequestReferenceSplitTheBill != null)
            {
                return false;
            }
    
            if (this.EventId != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static RequestResponse CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<RequestResponse>(json);
        }
    }
}
