using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class CoOwner : BunqModel
    {
        /// <summary>
        /// The Alias of the co-owner.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public List<LabelUser> Alias { get; set; }

        /// <summary>
        /// Can be: ACCEPTED, REJECTED, PENDING or REVOKED
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        public CoOwner(List<LabelUser> alias)
        {
            Alias = alias;
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Alias != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static CoOwner CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CoOwner>(json);
        }
    }
}