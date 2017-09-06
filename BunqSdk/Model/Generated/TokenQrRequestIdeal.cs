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
    /// Using this call you create a request for payment from an external token provided with an ideal transaction. Make
    /// sure your iDEAL payments are compliant with the iDEAL standards, by following the following manual: <a
    /// href="https://www.bunq.com/files/media/legal/en/20170315_ideal_standards_en.pdf">https://www.bunq.com/files/media/legal/en/20170315_ideal_standards_en.pdf</a>.
    /// It's very important to keep these points in mind when you are using the endpoint to make iDEAL payments from
    /// your application.
    /// </summary>
    public class TokenQrRequestIdeal : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_TOKEN = "token";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/token-qr-request-ideal";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "TokenQrRequestIdeal";

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
        /// The description for the RequestResponse provided by the requesting party. Maximum 9000 characters.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }

        /// <summary>
        /// The Attachments attached to the RequestResponse.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<Attachment> Attachment { get; private set; }

        /// <summary>
        /// The status of the created RequestResponse. Can only be PENDING.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }

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
        /// The Geolocation where the RequestResponse was created.
        /// </summary>
        [JsonProperty(PropertyName = "geolocation")]
        public Geolocation Geolocation { get; private set; }

        /// <summary>
        /// The URL which the user is sent to after accepting or rejecting the Request.
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; private set; }

        /// <summary>
        /// The type of the RequestResponse. Can be only be IDEAL.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// The subtype of the RequestResponse. Can be only be NONE.
        /// </summary>
        [JsonProperty(PropertyName = "sub_type")]
        public string SubType { get; private set; }

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

        /// <summary>
        /// Create a request from an ideal transaction.
        /// </summary>
        public static BunqResponse<TokenQrRequestIdeal> Create(ApiContext apiContext,
            IDictionary<string, object> requestMap, int userId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId), requestBytes, customHeaders);

            return FromJson<TokenQrRequestIdeal>(responseRaw, OBJECT_TYPE);
        }
    }
}
