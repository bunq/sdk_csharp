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
    /// A RequestResponse is what a user on the other side of a RequestInquiry gets when he is sent one. So a
    /// RequestInquiry is the initiator and visible for the user that sent it and that wants to receive the money. A
    /// RequestResponse is what the other side sees, i.e. the user that pays the money to accept the request. The
    /// content is almost identical.
    /// </summary>
    public class RequestResponse : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_AMOUNT_RESPONDED = "amount_responded";
        public const string FIELD_STATUS = "status";
        public const string FIELD_ADDRESS_SHIPPING = "address_shipping";
        public const string FIELD_ADDRESS_BILLING = "address_billing";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/request-response/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/request-response";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/request-response/{2}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "RequestResponse";

        /// <summary>
        /// The id of the Request Response.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }

        /// <summary>
        /// The timestamp when the Request Response was created.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }

        /// <summary>
        /// The timestamp when the Request Response was last updated (will be updated when chat messages are received).
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }

        /// <summary>
        /// The timestamp of when the RequestResponse was responded to.
        /// </summary>
        [JsonProperty(PropertyName = "time_responded")]
        public string TimeResponded { get; private set; }

        /// <summary>
        /// The timestamp of when the RequestResponse expired or will expire.
        /// </summary>
        [JsonProperty(PropertyName = "time_expiry")]
        public string TimeExpiry { get; private set; }

        /// <summary>
        /// The id of the MonetaryAccount the RequestResponse was received on.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; private set; }

        /// <summary>
        /// The requested Amount.
        /// </summary>
        [JsonProperty(PropertyName = "amount_inquired")]
        public Amount AmountInquired { get; private set; }

        /// <summary>
        /// The Amount the RequestResponse was accepted with.
        /// </summary>
        [JsonProperty(PropertyName = "amount_responded")]
        public Amount AmountResponded { get; private set; }

        /// <summary>
        /// The status of the RequestResponse. Can be ACCEPTED, PENDING, REJECTED or REVOKED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }

        /// <summary>
        /// The description for the RequestResponse provided by the requesting party. Maximum 9000 characters.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }

        /// <summary>
        /// The LabelMonetaryAccount with the public information of the MonetaryAccount this RequestResponse was
        /// received on.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; private set; }

        /// <summary>
        /// The LabelMonetaryAccount with the public information of the MonetaryAccount that is requesting money with
        /// this RequestResponse.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; private set; }

        /// <summary>
        /// The Attachments attached to the RequestResponse.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<Attachment> Attachment { get; private set; }

        /// <summary>
        /// The minimum age the user accepting the RequestResponse must have.
        /// </summary>
        [JsonProperty(PropertyName = "minimum_age")]
        public int? MinimumAge { get; private set; }

        /// <summary>
        /// Whether or not an address must be provided on accept.
        /// </summary>
        [JsonProperty(PropertyName = "require_address")]
        public string RequireAddress { get; private set; }

        /// <summary>
        /// The Geolocation where the RequestResponse was created.
        /// </summary>
        [JsonProperty(PropertyName = "geolocation")]
        public Geolocation Geolocation { get; private set; }

        /// <summary>
        /// The type of the RequestInquiry. Can be DIRECT_DEBIT, IDEAL or INTERNAL.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// The subtype of the RequestInquiry. Can be ONCE or RECURRING for DIRECT_DEBIT RequestInquiries and NONE for
        /// all other.
        /// </summary>
        [JsonProperty(PropertyName = "sub_type")]
        public string SubType { get; private set; }

        /// <summary>
        /// The URL which the user is sent to after accepting or rejecting the Request.
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; private set; }

        /// <summary>
        /// The billing address provided by the accepting user if an address was requested.
        /// </summary>
        [JsonProperty(PropertyName = "address_billing")]
        public Address AddressBilling { get; private set; }

        /// <summary>
        /// The shipping address provided by the accepting user if an address was requested.
        /// </summary>
        [JsonProperty(PropertyName = "address_shipping")]
        public Address AddressShipping { get; private set; }

        /// <summary>
        /// Whether or not chat messages are allowed.
        /// </summary>
        [JsonProperty(PropertyName = "allow_chat")]
        public bool? AllowChat { get; private set; }

        /// <summary>
        /// The whitelist id for this action or null.
        /// </summary>
        [JsonProperty(PropertyName = "eligible_whitelist_id")]
        public int? EligibleWhitelistId { get; private set; }

        public static BunqResponse<RequestResponse> Update(ApiContext apiContext,
            IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int requestResponseId)
        {
            return Update(apiContext, requestMap, userId, monetaryAccountId, requestResponseId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Update the status to accept or reject the RequestResponse.
        /// </summary>
        public static BunqResponse<RequestResponse> Update(ApiContext apiContext,
            IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int requestResponseId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, requestResponseId),
                    requestBytes, customHeaders);

            return FromJson<RequestResponse>(responseRaw, OBJECT_TYPE);
        }

        public static BunqResponse<List<RequestResponse>> List(ApiContext apiContext, int userId, int monetaryAccountId)
        {
            return List(apiContext, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get all RequestResponses for a MonetaryAccount.
        /// </summary>
        public static BunqResponse<List<RequestResponse>> List(ApiContext apiContext, int userId, int monetaryAccountId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId),
                customHeaders);

            return FromJsonList<RequestResponse>(responseRaw, OBJECT_TYPE);
        }

        public static BunqResponse<RequestResponse> Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int requestResponseId)
        {
            return Get(apiContext, userId, monetaryAccountId, requestResponseId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get the details for a specific existing RequestResponse.
        /// </summary>
        public static BunqResponse<RequestResponse> Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int requestResponseId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, requestResponseId),
                    customHeaders);

            return FromJson<RequestResponse>(responseRaw, OBJECT_TYPE);
        }
    }
}
