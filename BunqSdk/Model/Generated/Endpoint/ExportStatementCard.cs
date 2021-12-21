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
    /// Used to create new and read existing card statement exports. Statement exports can be created in either CSV or
    /// PDF file format.
    /// </summary>
    public class ExportStatementCard : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/card/{1}/export-statement-card/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/card/{1}/export-statement-card";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "ExportStatementCard";
    
        /// <summary>
        /// The id of the customer statement model.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        /// <summary>
        /// The timestamp of the statement model's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
    
        /// <summary>
        /// The timestamp of the statement model's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
    
        /// <summary>
        /// The date from when this statement shows transactions.
        /// </summary>
        [JsonProperty(PropertyName = "date_start")]
        public string DateStart { get; set; }
    
        /// <summary>
        /// The date until which statement shows transactions.
        /// </summary>
        [JsonProperty(PropertyName = "date_end")]
        public string DateEnd { get; set; }
    
        /// <summary>
        /// The status of the export.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The regional format of a CSV statement.
        /// </summary>
        [JsonProperty(PropertyName = "regional_format")]
        public string RegionalFormat { get; set; }
    
        /// <summary>
        /// The card for which this statement was created.
        /// </summary>
        [JsonProperty(PropertyName = "card_id")]
        public int? CardId { get; set; }
    
    
        /// <summary>
        /// </summary>
        public static BunqResponse<ExportStatementCard> Get(int cardId, int exportStatementCardId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), cardId, exportStatementCardId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<ExportStatementCard>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<ExportStatementCard>> List(int cardId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), cardId), urlParams, customHeaders);
    
            return FromJsonList<ExportStatementCard>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.DateStart != null)
            {
                return false;
            }
    
            if (this.DateEnd != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.RegionalFormat != null)
            {
                return false;
            }
    
            if (this.CardId != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static ExportStatementCard CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ExportStatementCard>(json);
        }
    }
}
