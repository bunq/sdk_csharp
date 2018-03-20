using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Security;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for generating and retrieving a new CVC2 code.
    /// </summary>
    public class CardGeneratedCvc2 : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/card/{1}/generated-cvc2";

        protected const string ENDPOINT_URL_READ = "user/{0}/card/{1}/generated-cvc2/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/card/{1}/generated-cvc2";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "CardGeneratedCvc2";

        /// <summary>
        /// The id of the cvc code.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the cvc code's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the cvc code's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The cvc2 code.
        /// </summary>
        [JsonProperty(PropertyName = "cvc2")]
        public string Cvc2 { get; set; }

        /// <summary>
        /// The status of the cvc2. Can be AVAILABLE, USED, EXPIRED, BLOCKED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Expiry time of the cvc2.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_time")]
        public string ExpiryTime { get; set; }

        /// <summary>
        /// Generate a new CVC2 code for a card.
        /// </summary>
        public static BunqResponse<int> Create(int cardId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            requestBytes = SecurityUtils.Encrypt(GetApiContext(), requestBytes, customHeaders);
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), cardId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Get the details for a specific generated CVC2 code.
        /// </summary>
        public static BunqResponse<CardGeneratedCvc2> Get(int cardId, int cardGeneratedCvc2Id,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), cardId, cardGeneratedCvc2Id),
                    new Dictionary<string, string>(), customHeaders);

            return FromJson<CardGeneratedCvc2>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Get all generated CVC2 codes for a card.
        /// </summary>
        public static BunqResponse<List<CardGeneratedCvc2>> List(int cardId,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), cardId), urlParams,
                customHeaders);

            return FromJsonList<CardGeneratedCvc2>(responseRaw, OBJECT_TYPE_GET);
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

            if (this.Cvc2 != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.ExpiryTime != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static CardGeneratedCvc2 CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardGeneratedCvc2>(json);
        }
    }
}