using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    ///     Used to determine the recipient account requirements for Transferwise transfers.
    /// </summary>
    public class TransferwiseAccountRequirement : BunqModel
    {
        /// <summary>
        ///     Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE =
            "user/{0}/transferwise-quote/{1}/transferwise-recipient-requirement";

        protected const string ENDPOINT_URL_LISTING =
            "user/{0}/transferwise-quote/{1}/transferwise-recipient-requirement";

        /// <summary>
        ///     Field constants.
        /// </summary>
        public const string FIELD_COUNTRY = "country";

        public const string FIELD_NAME_ACCOUNT_HOLDER = "name_account_holder";
        public const string FIELD_TYPE = "type";
        public const string FIELD_DETAIL = "detail";

        /// <summary>
        ///     Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "TransferwiseRequirement";

        /// <summary>
        ///     The country of the receiving account.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        ///     The name of the account holder.
        /// </summary>
        [JsonProperty(PropertyName = "name_account_holder")]
        public string NameAccountHolder { get; set; }

        /// <summary>
        ///     A possible recipient account type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        ///     The fields which were specified as "required" and have since been filled by the user. Always provide the
        ///     full list.
        /// </summary>
        [JsonProperty(PropertyName = "detail")]
        public List<TransferwiseRequirementField> Detail { get; set; }

        /// <summary>
        ///     The label of the possible recipient account type to show to the user.
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        ///     The fields which the user needs to fill.
        /// </summary>
        [JsonProperty(PropertyName = "fields")]
        public List<TransferwiseRequirementField> Fields { get; set; }


        /// <summary>
        /// </summary>
        /// <param name="nameAccountHolder">The name of the account holder.</param>
        /// <param name="type">
        ///     The chosen recipient account type. The possible options are provided dynamically in the response
        ///     endpoint.
        /// </param>
        /// <param name="country">The country of the receiving account.</param>
        /// <param name="detail">
        ///     The fields which were specified as "required" and have since been filled by the user. Always
        ///     provide the full list.
        /// </param>
        public static BunqResponse<int> Create(int transferwiseQuoteId, string nameAccountHolder, string type,
            string country = null, List<TransferwiseRequirementField> detail = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_COUNTRY, country},
                {FIELD_NAME_ACCOUNT_HOLDER, nameAccountHolder},
                {FIELD_TYPE, type},
                {FIELD_DETAIL, detail}
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), transferwiseQuoteId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<TransferwiseAccountRequirement>> List(int transferwiseQuoteId,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), transferwiseQuoteId),
                urlParams, customHeaders);

            return FromJsonList<TransferwiseAccountRequirement>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Type != null) return false;

            if (Label != null) return false;

            if (Fields != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static TransferwiseAccountRequirement CreateFromJsonString(string json)
        {
            return CreateFromJsonString<TransferwiseAccountRequirement>(json);
        }
    }
}