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
    /// Used to create new and read existing statement exports. Statement exports can be created in either CSV, MT940 or
    /// PDF file format.
    /// </summary>
    public class CustomerStatementExport : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/customer-statement";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/customer-statement/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/customer-statement";
        private const string ENDPOINT_URL_DELETE = "user/{0}/monetary-account/{1}/customer-statement/{2}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATEMENT_FORMAT = "statement_format";
        public const string FIELD_DATE_START = "date_start";
        public const string FIELD_DATE_END = "date_end";
        public const string FIELD_REGIONAL_FORMAT = "regional_format";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "CustomerStatementExport";
    
        /// <summary>
        /// The id of the customer statement model.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp of the statement model's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp of the statement model's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The date from when this statement shows transactions.
        /// </summary>
        [JsonProperty(PropertyName = "date_start")]
        public string DateStart { get; private set; }
    
        /// <summary>
        /// The date until which statement shows transactions.
        /// </summary>
        [JsonProperty(PropertyName = "date_end")]
        public string DateEnd { get; private set; }
    
        /// <summary>
        /// The status of the export.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// MT940 Statement number. Unique per monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "statement_number")]
        public int? StatementNumber { get; private set; }
    
        /// <summary>
        /// The format of statement.
        /// </summary>
        [JsonProperty(PropertyName = "statement_format")]
        public string StatementFormat { get; private set; }
    
        /// <summary>
        /// The regional format of a CSV statement.
        /// </summary>
        [JsonProperty(PropertyName = "regional_format")]
        public string RegionalFormat { get; private set; }
    
        /// <summary>
        /// The monetary account for which this statement was created.
        /// </summary>
        [JsonProperty(PropertyName = "alias_monetary_account")]
        public MonetaryAccountReference AliasMonetaryAccount { get; private set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<CustomerStatementExport> Get(ApiContext apiContext, int userId, int monetaryAccountId, int customerStatementExportId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, customerStatementExportId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<CustomerStatementExport>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<CustomerStatementExport>> List(ApiContext apiContext, int userId, int monetaryAccountId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), urlParams, customHeaders);
    
            return FromJsonList<CustomerStatementExport>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int monetaryAccountId, int customerStatementExportId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, userId, monetaryAccountId, customerStatementExportId), customHeaders);
    
            return new BunqResponse<object>(null, responseRaw.Headers);
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
    
            if (this.StatementNumber != null)
            {
                return false;
            }
    
            if (this.StatementFormat != null)
            {
                return false;
            }
    
            if (this.RegionalFormat != null)
            {
                return false;
            }
    
            if (this.AliasMonetaryAccount != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CustomerStatementExport CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CustomerStatementExport>(json);
        }
    }
}
