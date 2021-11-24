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
    /// RequestInquiry, aka 'RFP' (Request for Payment), is one of the innovative features that bunq offers. To request
    /// payment from another bunq account a new Request Inquiry is created. As with payments you can add attachments to
    /// a RFP. Requests for Payment are the foundation for a number of consumer features like 'Split the bill' and
    /// 'Request forwarding'. We invite you to invent your own based on the bunq api!
    /// </summary>
    public class RequestInquiry : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/request-inquiry";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/request-inquiry/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/request-inquiry";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/request-inquiry/{2}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_AMOUNT_INQUIRED = "amount_inquired";
        public const string FIELD_COUNTERPARTY_ALIAS = "counterparty_alias";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_ATTACHMENT = "attachment";
        public const string FIELD_MERCHANT_REFERENCE = "merchant_reference";
        public const string FIELD_STATUS = "status";
        public const string FIELD_MINIMUM_AGE = "minimum_age";
        public const string FIELD_REQUIRE_ADDRESS = "require_address";
        public const string FIELD_WANT_TIP = "want_tip";
        public const string FIELD_ALLOW_AMOUNT_LOWER = "allow_amount_lower";
        public const string FIELD_ALLOW_AMOUNT_HIGHER = "allow_amount_higher";
        public const string FIELD_ALLOW_BUNQME = "allow_bunqme";
        public const string FIELD_REDIRECT_URL = "redirect_url";
        public const string FIELD_EVENT_ID = "event_id";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_PUT = "RequestInquiry";
        private const string OBJECT_TYPE_GET = "RequestInquiry";
    
        /// <summary>
        /// The requested amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount_inquired")]
        public Amount AmountInquired { get; set; }
    
        /// <summary>
        /// The LabelMonetaryAccount with the public information of the MonetaryAccount the money was requested from.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
    
        /// <summary>
        /// The description of the inquiry.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    
        /// <summary>
        /// The attachments attached to the payment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<BunqId> Attachment { get; set; }
    
        /// <summary>
        /// The client's custom reference that was attached to the request and the mutation.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference")]
        public string MerchantReference { get; set; }
    
        /// <summary>
        /// The status of the request.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The minimum age the user accepting the RequestInquiry must have.
        /// </summary>
        [JsonProperty(PropertyName = "minimum_age")]
        public int? MinimumAge { get; set; }
    
        /// <summary>
        /// Whether or not an address must be provided on accept.
        /// </summary>
        [JsonProperty(PropertyName = "require_address")]
        public string RequireAddress { get; set; }
    
        /// <summary>
        /// [DEPRECATED] Whether or not the accepting user can give an extra tip on top of the requested Amount.
        /// Defaults to false.
        /// </summary>
        [JsonProperty(PropertyName = "want_tip")]
        public bool? WantTip { get; set; }
    
        /// <summary>
        /// [DEPRECATED] Whether or not the accepting user can choose to accept with a lower amount than requested.
        /// Defaults to false.
        /// </summary>
        [JsonProperty(PropertyName = "allow_amount_lower")]
        public bool? AllowAmountLower { get; set; }
    
        /// <summary>
        /// [DEPRECATED] Whether or not the accepting user can choose to accept with a higher amount than requested.
        /// Defaults to false.
        /// </summary>
        [JsonProperty(PropertyName = "allow_amount_higher")]
        public bool? AllowAmountHigher { get; set; }
    
        /// <summary>
        /// Whether or not sending a bunq.me request is allowed.
        /// </summary>
        [JsonProperty(PropertyName = "allow_bunqme")]
        public bool? AllowBunqme { get; set; }
    
        /// <summary>
        /// The URL which the user is sent to after accepting or rejecting the Request.
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }
    
        /// <summary>
        /// The ID of the associated event if the request was made using 'split the bill'.
        /// </summary>
        [JsonProperty(PropertyName = "event_id")]
        public int? EventId { get; set; }
    
        /// <summary>
        /// The id of the created RequestInquiry.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        /// <summary>
        /// The timestamp of the payment request's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
    
        /// <summary>
        /// The timestamp of the payment request's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
    
        /// <summary>
        /// The timestamp of when the payment request was responded to.
        /// </summary>
        [JsonProperty(PropertyName = "time_responded")]
        public string TimeResponded { get; set; }
    
        /// <summary>
        /// The timestamp of when the payment request expired.
        /// </summary>
        [JsonProperty(PropertyName = "time_expiry")]
        public string TimeExpiry { get; set; }
    
        /// <summary>
        /// The id of the monetary account the request response applies to.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }
    
        /// <summary>
        /// The responded amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount_responded")]
        public Amount AmountResponded { get; set; }
    
        /// <summary>
        /// The label that's displayed to the counterparty with the mutation. Includes user.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_created")]
        public MonetaryAccountReference UserAliasCreated { get; set; }
    
        /// <summary>
        /// The label that's displayed to the counterparty with the mutation. Includes user.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_revoked")]
        public MonetaryAccountReference UserAliasRevoked { get; set; }
    
        /// <summary>
        /// The id of the batch if the request was part of a batch.
        /// </summary>
        [JsonProperty(PropertyName = "batch_id")]
        public int? BatchId { get; set; }
    
        /// <summary>
        /// The id of the scheduled job if the request was scheduled.
        /// </summary>
        [JsonProperty(PropertyName = "scheduled_id")]
        public int? ScheduledId { get; set; }
    
        /// <summary>
        /// The url that points to the bunq.me request.
        /// </summary>
        [JsonProperty(PropertyName = "bunqme_share_url")]
        public string BunqmeShareUrl { get; set; }
    
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
        /// The geolocation where the payment was done.
        /// </summary>
        [JsonProperty(PropertyName = "geolocation")]
        public Geolocation Geolocation { get; set; }
    
        /// <summary>
        /// The reference to the object used for split the bill. Can be Payment, PaymentBatch, ScheduleInstance,
        /// RequestResponse and MasterCardAction
        /// </summary>
        [JsonProperty(PropertyName = "reference_split_the_bill")]
        public RequestReferenceSplitTheBillAnchorObject ReferenceSplitTheBill { get; set; }
    
    
        /// <summary>
        /// Create a new payment request.
        /// </summary>
        /// <param name="amountInquired">The Amount requested to be paid by the person the RequestInquiry is sent to. Must be bigger than 0.</param>
        /// <param name="counterpartyAlias">The Alias of the party we are requesting the money from. Can be an Alias of type EMAIL, PHONE_NUMBER or IBAN. In case the EMAIL or PHONE_NUMBER Alias does not refer to a bunq monetary account, 'allow_bunqme' needs to be 'true' in order to trigger the creation of a bunq.me request. Otherwise no request inquiry will be sent.</param>
        /// <param name="description">The description for the RequestInquiry. Maximum 9000 characters. Field is required but can be an empty string.</param>
        /// <param name="allowBunqme">Whether or not sending a bunq.me request is allowed.</param>
        /// <param name="attachment">The Attachments to attach to the RequestInquiry.</param>
        /// <param name="merchantReference">Optional data to be included with the RequestInquiry specific to the merchant. Has to be unique for the same source MonetaryAccount.</param>
        /// <param name="status">The status of the RequestInquiry. Ignored in POST requests but can be used for revoking (cancelling) the RequestInquiry by setting REVOKED with a PUT request.</param>
        /// <param name="minimumAge">The minimum age the user accepting the RequestInquiry must have. Defaults to not checking. If set, must be between 12 and 100 inclusive.</param>
        /// <param name="requireAddress">Whether a billing and shipping address must be provided when paying the request. Possible values are: BILLING, SHIPPING, BILLING_SHIPPING, NONE, OPTIONAL. Default is NONE.</param>
        /// <param name="wantTip">[DEPRECATED] Whether or not the accepting user can give an extra tip on top of the requested Amount. Defaults to false.</param>
        /// <param name="allowAmountLower">[DEPRECATED] Whether or not the accepting user can choose to accept with a lower amount than requested. Defaults to false.</param>
        /// <param name="allowAmountHigher">[DEPRECATED] Whether or not the accepting user can choose to accept with a higher amount than requested. Defaults to false.</param>
        /// <param name="redirectUrl">The URL which the user is sent to after accepting or rejecting the Request.</param>
        /// <param name="eventId">The ID of the associated event if the request was made using 'split the bill'.</param>
        public static BunqResponse<int> Create(Amount amountInquired, Pointer counterpartyAlias, string description, bool? allowBunqme, int? monetaryAccountId= null, List<BunqId> attachment = null, string merchantReference = null, string status = null, int? minimumAge = null, string requireAddress = null, bool? wantTip = null, bool? allowAmountLower = null, bool? allowAmountHigher = null, string redirectUrl = null, int? eventId = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_AMOUNT_INQUIRED, amountInquired},
    {FIELD_COUNTERPARTY_ALIAS, counterpartyAlias},
    {FIELD_DESCRIPTION, description},
    {FIELD_ATTACHMENT, attachment},
    {FIELD_MERCHANT_REFERENCE, merchantReference},
    {FIELD_STATUS, status},
    {FIELD_MINIMUM_AGE, minimumAge},
    {FIELD_REQUIRE_ADDRESS, requireAddress},
    {FIELD_WANT_TIP, wantTip},
    {FIELD_ALLOW_AMOUNT_LOWER, allowAmountLower},
    {FIELD_ALLOW_AMOUNT_HIGHER, allowAmountHigher},
    {FIELD_ALLOW_BUNQME, allowBunqme},
    {FIELD_REDIRECT_URL, redirectUrl},
    {FIELD_EVENT_ID, eventId},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Revoke a request for payment, by updating the status to REVOKED.
        /// </summary>
        /// <param name="status">The status of the RequestInquiry. Ignored in POST requests but can be used for revoking (cancelling) the RequestInquiry by setting REVOKED with a PUT request.</param>
        public static BunqResponse<RequestInquiry> Update(int requestInquiryId, int? monetaryAccountId= null, string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_STATUS, status},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), requestInquiryId), requestBytes, customHeaders);
    
            return FromJson<RequestInquiry>(responseRaw, OBJECT_TYPE_PUT);
        }
    
        /// <summary>
        /// Get all payment requests for a user's monetary account. bunqme_share_url is always null if the counterparty
        /// is a bunq user.
        /// </summary>
        public static BunqResponse<List<RequestInquiry>> List(int? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);
    
            return FromJsonList<RequestInquiry>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// Get the details of a specific payment request, including its status. bunqme_share_url is always null if the
        /// counterparty is a bunq user.
        /// </summary>
        public static BunqResponse<RequestInquiry> Get(int requestInquiryId, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), requestInquiryId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<RequestInquiry>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.UserAliasCreated != null)
            {
                return false;
            }
    
            if (this.UserAliasRevoked != null)
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
    
            if (this.MerchantReference != null)
            {
                return false;
            }
    
            if (this.Attachment != null)
            {
                return false;
            }
    
            if (this.Status != null)
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
    
            if (this.MinimumAge != null)
            {
                return false;
            }
    
            if (this.RequireAddress != null)
            {
                return false;
            }
    
            if (this.BunqmeShareUrl != null)
            {
                return false;
            }
    
            if (this.RedirectUrl != null)
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
    
            if (this.ReferenceSplitTheBill != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static RequestInquiry CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<RequestInquiry>(json);
        }
    }
}
