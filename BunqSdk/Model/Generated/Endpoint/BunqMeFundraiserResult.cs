using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// bunq.me fundraiser result containing all payments.
    /// </summary>
    public class BunqMeFundraiserResult : BunqModel
    {
        /// <summary>
        /// The id of the bunq.me.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp when the bunq.me was created.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp when the bunq.me was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The bunq.me fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "bunqme_fundraiser_profile")]
        public BunqMeFundraiserProfile BunqmeFundraiserProfile { get; private set; }
    
        /// <summary>
        /// The list of payments, paid to the bunq.me fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "payments")]
        public List<Payment> Payments { get; private set; }
    
    
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
    
            if (this.BunqmeFundraiserProfile != null)
            {
                return false;
            }
    
            if (this.Payments != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static BunqMeFundraiserResult CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BunqMeFundraiserResult>(json);
        }
    }
}
