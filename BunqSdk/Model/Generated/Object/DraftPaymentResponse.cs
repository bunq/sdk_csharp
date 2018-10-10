using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class DraftPaymentResponse : BunqModel
    {
        /// <summary>
        /// The status with which was responded.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The user that responded to the DraftPayment.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_created")]
        public LabelUser UserAliasCreated { get; set; }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Status != null)
            {
                return false;
            }

            if (this.UserAliasCreated != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static DraftPaymentResponse CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<DraftPaymentResponse>(json);
        }
    }
}