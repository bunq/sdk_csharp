using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class LabelCard : BunqModel
    {
        /// <summary>
        /// The public UUID.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }
    
        /// <summary>
        /// The type of the card.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    
        /// <summary>
        /// The second line on the card.
        /// </summary>
        [JsonProperty(PropertyName = "second_line")]
        public string SecondLine { get; set; }
    
        /// <summary>
        /// The date this card will expire.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_date")]
        public string ExpiryDate { get; set; }
    
        /// <summary>
        /// The status of the card.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The owner of this card.
        /// </summary>
        [JsonProperty(PropertyName = "label_user")]
        public LabelUser LabelUser { get; set; }
    
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Uuid != null)
            {
                return false;
            }
    
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.SecondLine != null)
            {
                return false;
            }
    
            if (this.ExpiryDate != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.LabelUser != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static LabelCard CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<LabelCard>(json);
        }
    }
}
