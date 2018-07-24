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
    /// Using this call you create a request for payment from an external token provided with an ideal transaction. Make
    /// sure your iDEAL payments are compliant with the iDEAL standards, by following the following manual:
    /// https://www.bunq.com/terms-idealstandards. It's very important to keep these points in mind when you are using
    /// the endpoint to make iDEAL payments from your application.
    /// </summary>
    public class TokenQrRequestIdeal : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/token-qr-request-ideal";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_TOKEN = "token";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_POST = "RequestResponse";

        /// <summary>
        /// The id of the RequestResponse.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

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
        /// The Amount the RequestResponse was accepted with.
        /// </summary>
        [JsonProperty(PropertyName = "amount_responded")]
        public Amount AmountResponded { get; set; }

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
        /// The description for the RequestResponse provided by the requesting party. Maximum 9000 characters.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The Attachments attached to the RequestResponse.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<Attachment> Attachment { get; set; }

        /// <summary>
        /// The status of the created RequestResponse. Can only be PENDING.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

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
        /// The Geolocation where the RequestResponse was created.
        /// </summary>
        [JsonProperty(PropertyName = "geolocation")]
        public Geolocation Geolocation { get; set; }

        /// <summary>
        /// The URL which the user is sent to after accepting or rejecting the Request.
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// The type of the RequestResponse. Can be only be IDEAL.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The subtype of the RequestResponse. Can be only be NONE.
        /// </summary>
        [JsonProperty(PropertyName = "sub_type")]
        public string SubType { get; set; }

        /// <summary>
        /// Whether or not chat messages are allowed.
        /// </summary>
        [JsonProperty(PropertyName = "allow_chat")]
        public bool? AllowChat { get; set; }

        /// <summary>
        /// The whitelist id for this action or null.
        /// </summary>
        [JsonProperty(PropertyName = "eligible_whitelist_id")]
        public int? EligibleWhitelistId { get; set; }

        /// <summary>
        /// Create a request from an ideal transaction.
        /// </summary>
        /// <param name="token">The token passed from a site or read from a QR code.</param>
        public static BunqResponse<TokenQrRequestIdeal> Create(string token,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_TOKEN, token},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes,
                customHeaders);

            return FromJson<TokenQrRequestIdeal>(responseRaw, OBJECT_TYPE_POST);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
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

            if (this.Attachment != null)
            {
                return false;
            }

            if (this.Status != null)
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

            if (this.RedirectUrl != null)
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

            if (this.AllowChat != null)
            {
                return false;
            }

            if (this.EligibleWhitelistId != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static TokenQrRequestIdeal CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TokenQrRequestIdeal>(json);
        }
    }
}