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
    /// bunq.me fundraiser result containing all payments.
    /// </summary>
    public class BunqMeFundraiserResultApiObject : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/bunqme-fundraiser-result/{2}";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "BunqMeFundraiserResult";
    
        /// <summary>
        /// The id of the bunq.me.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }
        /// <summary>
        /// The timestamp when the bunq.me was created.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
        /// <summary>
        /// The timestamp when the bunq.me was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
        /// <summary>
        /// The bunq.me fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "bunqme_fundraiser_profile")]
        public BunqMeFundraiserProfileApiObject BunqmeFundraiserProfile { get; set; }
        /// <summary>
        /// The list of payments, paid to the bunq.me fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "payments")]
        public List<PaymentApiObject> Payments { get; set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<BunqMeFundraiserResultApiObject> Get(long bunqMeFundraiserResultId, long? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), bunqMeFundraiserResultId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<BunqMeFundraiserResultApiObject>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
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
        public static BunqMeFundraiserResultApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BunqMeFundraiserResultApiObject>(json);
        }
    }
}
