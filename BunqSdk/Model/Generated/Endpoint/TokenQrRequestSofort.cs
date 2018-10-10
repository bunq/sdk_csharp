using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Using this call you can create a SOFORT Request assigned to your User by providing the Token of the request.
    /// </summary>
    public class TokenQrRequestSofort : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/token-qr-request-sofort";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_TOKEN = "token";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_POST = "RequestResponse";

        /// <summary>
        /// The token passed from a site or read from a QR code.
        /// </summary>
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        /// <summary>
        /// Create a request from an SOFORT transaction.
        /// </summary>
        /// <param name="token">The token passed from a site or read from a QR code.</param>
        public static BunqResponse<TokenQrRequestSofort> Create(string token,
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

            return FromJson<TokenQrRequestSofort>(responseRaw, OBJECT_TYPE_POST);
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }

        /// <summary>
        /// </summary>
        public static TokenQrRequestSofort CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TokenQrRequestSofort>(json);
        }
    }
}