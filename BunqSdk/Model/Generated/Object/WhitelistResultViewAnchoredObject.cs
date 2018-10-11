using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class WhitelistResultViewAnchoredObject : BunqModel
    {
        /// <summary>
        /// The ID of the whitelist entry.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The RequestResponse object
        /// </summary>
        [JsonProperty(PropertyName = "requestResponse")]
        public RequestResponse RequestResponse { get; set; }

        /// <summary>
        /// The DraftPayment object
        /// </summary>
        [JsonProperty(PropertyName = "draftPayment")]
        public DraftPayment DraftPayment { get; set; }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }

            if (this.RequestResponse != null)
            {
                return false;
            }

            if (this.DraftPayment != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static WhitelistResultViewAnchoredObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<WhitelistResultViewAnchoredObject>(json);
        }
    }
}