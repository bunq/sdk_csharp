using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for getting information fulfillments for a user.
    /// </summary>
    public class Fulfillment : BunqModel
    {
        /// <summary>
        /// Type of the information fulfillment.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        /// <summary>
        /// The reason why this fulfillment is requested.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }
        /// <summary>
        /// The translated reason why this fulfillment is requested.
        /// </summary>
        [JsonProperty(PropertyName = "reason_translated")]
        public string ReasonTranslated { get; set; }
        /// <summary>
        /// Status of this fulfillment.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// Time when the information fulfillment becomes mandatory.
        /// </summary>
        [JsonProperty(PropertyName = "time_mandatory")]
        public string TimeMandatory { get; set; }
        /// <summary>
        /// The user id this fulfillment is required for.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId { get; set; }
        /// <summary>
        /// The allowed statusses for this fulfillment.
        /// </summary>
        [JsonProperty(PropertyName = "all_status_allowed")]
        public List<string> AllStatusAllowed { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.Reason != null)
            {
                return false;
            }
    
            if (this.ReasonTranslated != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.TimeMandatory != null)
            {
                return false;
            }
    
            if (this.UserId != null)
            {
                return false;
            }
    
            if (this.AllStatusAllowed != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static Fulfillment CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Fulfillment>(json);
        }
    }
}
