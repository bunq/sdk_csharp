using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
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

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/request-inquiry";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/request-inquiry/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/request-inquiry";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/request-inquiry/{2}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "RequestInquiry";

        /// <summary>
        /// The id of the created RequestInquiry.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }

        /// <summary>
        /// The timestamp of the payment request's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }

        /// <summary>
        /// The timestamp of the payment request's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }

        /// <summary>
        /// The timestamp of when the payment request was responded to.
        /// </summary>
        [JsonProperty(PropertyName = "time_responded")]
        public string TimeResponded { get; private set; }

        /// <summary>
        /// The timestamp of when the payment request expired.
        /// </summary>
        [JsonProperty(PropertyName = "time_expiry")]
        public string TimeExpiry { get; private set; }

        /// <summary>
        /// The id of the monetary account the request response applies to.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; private set; }

        /// <summary>
        /// The requested amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount_inquired")]
        public Amount AmountInquired { get; private set; }

        /// <summary>
        /// The responded amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount_responded")]
        public Amount AmountResponded { get; private set; }

        /// <summary>
        /// The label that's displayed to the counterparty with the mutation. Includes user.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_created")]
        public LabelUser UserAliasCreated { get; private set; }

        /// <summary>
        /// The label that's displayed to the counterparty with the mutation. Includes user.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_revoked")]
        public LabelUser UserAliasRevoked { get; private set; }

        /// <summary>
        /// The LabelMonetaryAccount with the public information of the MonetaryAccount the money was requested from.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; private set; }

        /// <summary>
        /// The description of the inquiry.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }

        /// <summary>
        /// The client's custom reference that was attached to the request and the mutation.
        /// </summary>
        [JsonProperty(PropertyName = "merchant_reference")]
        public string MerchantReference { get; private set; }

        /// <summary>
        /// The attachments attached to the payment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<BunqId> Attachment { get; private set; }

        /// <summary>
        /// The status of the request.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }

        /// <summary>
        /// The id of the batch if the request was part of a batch.
        /// </summary>
        [JsonProperty(PropertyName = "batch_id")]
        public int? BatchId { get; private set; }

        /// <summary>
        /// The id of the scheduled job if the request was scheduled.
        /// </summary>
        [JsonProperty(PropertyName = "scheduled_id")]
        public int? ScheduledId { get; private set; }

        /// <summary>
        /// The minimum age the user accepting the RequestInquiry must have.
        /// </summary>
        [JsonProperty(PropertyName = "minimum_age")]
        public int? MinimumAge { get; private set; }

        /// <summary>
        /// Whether or not an address must be provided on accept.
        /// </summary>
        [JsonProperty(PropertyName = "require_address")]
        public string RequireAddress { get; private set; }

        /// <summary>
        /// The url that points to the bunq.me request.
        /// </summary>
        [JsonProperty(PropertyName = "bunqme_share_url")]
        public string BunqmeShareUrl { get; private set; }

        /// <summary>
        /// The URL which the user is sent to after accepting or rejecting the Request.
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; private set; }

        /// <summary>
        /// The shipping address provided by the accepting user if an address was requested.
        /// </summary>
        [JsonProperty(PropertyName = "address_shipping")]
        public Address AddressShipping { get; private set; }

        /// <summary>
        /// The billing address provided by the accepting user if an address was requested.
        /// </summary>
        [JsonProperty(PropertyName = "address_billing")]
        public Address AddressBilling { get; private set; }

        /// <summary>
        /// The geolocation where the payment was done.
        /// </summary>
        [JsonProperty(PropertyName = "geolocation")]
        public Geolocation Geolocation { get; private set; }

        /// <summary>
        /// Whether or not chat messages are allowed.
        /// </summary>
        [JsonProperty(PropertyName = "allow_chat")]
        public bool? AllowChat { get; private set; }

        /// <summary>
        /// Create a new payment request.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Revoke a request for payment, by updating the status to REVOKED.
        /// </summary>
        public static BunqResponse<RequestInquiry> Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userId, int monetaryAccountId, int requestInquiryId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, requestInquiryId),
                    requestBytes, customHeaders);

            return FromJson<RequestInquiry>(responseRaw, OBJECT_TYPE);
        }

        /// <summary>
        /// Get all payment requests for a user's monetary account.
        /// </summary>
        public static BunqResponse<List<RequestInquiry>> List(ApiContext apiContext, int userId, int monetaryAccountId,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), urlParams,
                customHeaders);

            return FromJsonList<RequestInquiry>(responseRaw, OBJECT_TYPE);
        }

        /// <summary>
        /// Get the details of a specific payment request, including its status.
        /// </summary>
        public static BunqResponse<RequestInquiry> Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int requestInquiryId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(apiContext);
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, requestInquiryId),
                    new Dictionary<string, string>(), customHeaders);

            return FromJson<RequestInquiry>(responseRaw, OBJECT_TYPE);
        }
    }
}
