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
    /// See how many trees this user has planted.
    /// </summary>
    public class TreeProgress : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/tree-progress";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "TreeProgress";
    
        /// <summary>
        /// The number of trees this user and all users have planted.
        /// </summary>
        [JsonProperty(PropertyName = "number_of_tree")]
        public double? NumberOfTree { get; set; }
    
        /// <summary>
        /// The progress towards the next tree.
        /// </summary>
        [JsonProperty(PropertyName = "progress_tree_next")]
        public double? ProgressTreeNext { get; set; }
    
        /// <summary>
        /// The label of the user the progress belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "label_user")]
        public LabelUser LabelUser { get; set; }
    
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<TreeProgress>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<TreeProgress>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.NumberOfTree != null)
            {
                return false;
            }
    
            if (this.ProgressTreeNext != null)
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
        public static TreeProgress CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TreeProgress>(json);
        }
    }
}
