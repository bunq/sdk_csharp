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
    /// Used to view bunq.me TabResultResponse objects belonging to a tab. A TabResultResponse is an object that holds
    /// details on a tab which has been paid from the provided monetary account.
    /// </summary>
    public class BunqMeTabResultResponse : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/bunqme-tab-result-response/{2}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "BunqMeTabResultResponse";

        /// <summary>
        /// The payment made for the bunq.me tab.
        /// </summary>
        [JsonProperty(PropertyName = "payment")]
        public Payment Payment { get; set; }

        /// <summary>
        /// </summary>
        public static BunqResponse<BunqMeTabResultResponse> Get(int bunqMeTabResultResponseId,
            int? monetaryAccountId = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        bunqMeTabResultResponseId), new Dictionary<string, string>(), customHeaders);

            return FromJson<BunqMeTabResultResponse>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Payment != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static BunqMeTabResultResponse CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BunqMeTabResultResponse>(json);
        }
    }
}