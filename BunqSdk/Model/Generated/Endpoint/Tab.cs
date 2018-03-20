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
    /// Used to read a single publicly visible tab.
    /// </summary>
    public class Tab : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "tab/{0}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "Tab";

        /// <summary>
        /// The uuid of the tab.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        /// <summary>
        /// The label of the party that owns this tab.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }

        /// <summary>
        /// The avatar of this tab.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// The reference of the tab, as defined by the owner.
        /// </summary>
        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }

        /// <summary>
        /// The short description of the tab.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The status of the tab.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The moment when this tab expires.
        /// </summary>
        [JsonProperty(PropertyName = "expiration")]
        public string Expiration { get; set; }

        /// <summary>
        /// The total amount of the tab.
        /// </summary>
        [JsonProperty(PropertyName = "amount_total")]
        public Amount AmountTotal { get; set; }

        /// <summary>
        /// Get a publicly visible tab.
        /// </summary>
        public static BunqResponse<Tab> Get(string tabUuid, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, tabUuid), new Dictionary<string, string>(),
                customHeaders);

            return FromJson<Tab>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Uuid != null)
            {
                return false;
            }

            if (this.Alias != null)
            {
                return false;
            }

            if (this.Avatar != null)
            {
                return false;
            }

            if (this.Reference != null)
            {
                return false;
            }

            if (this.Description != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.Expiration != null)
            {
                return false;
            }

            if (this.AmountTotal != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static Tab CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Tab>(json);
        }
    }
}