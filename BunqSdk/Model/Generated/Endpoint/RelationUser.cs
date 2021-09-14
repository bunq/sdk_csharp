using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Manage the relation user details.
    /// </summary>
    public class RelationUser : BunqModel
    {
        /// <summary>
        /// The user's ID.
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }
    
        /// <summary>
        /// The counter user's ID.
        /// </summary>
        [JsonProperty(PropertyName = "counter_user_id")]
        public string CounterUserId { get; set; }
    
        /// <summary>
        /// The user's label.
        /// </summary>
        [JsonProperty(PropertyName = "label_user")]
        public LabelUser LabelUser { get; set; }
    
        /// <summary>
        /// The counter user's label.
        /// </summary>
        [JsonProperty(PropertyName = "counter_label_user")]
        public LabelUser CounterLabelUser { get; set; }
    
        /// <summary>
        /// The requested relation type.
        /// </summary>
        [JsonProperty(PropertyName = "relationship")]
        public string Relationship { get; set; }
    
        /// <summary>
        /// The request's status, only for UPDATE.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.UserId != null)
            {
                return false;
            }
    
            if (this.CounterUserId != null)
            {
                return false;
            }
    
            if (this.LabelUser != null)
            {
                return false;
            }
    
            if (this.CounterLabelUser != null)
            {
                return false;
            }
    
            if (this.Relationship != null)
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
        public static RelationUser CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<RelationUser>(json);
        }
    }
}
