using System;
using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Used to create new and read existing statement exports. Statement exports can be created in either CSV, MT940 or
    /// PDF file format.
    /// </summary>
    public class CustomerStatementExport : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATEMENT_FORMAT = "statement_format";
        public const string FIELD_DATE_START = "date_start";
        public const string FIELD_DATE_END = "date_end";
        public const string FIELD_REGIONAL_FORMAT = "regional_format";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/customer-statement";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/customer-statement/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/customer-statement";
        private const string ENDPOINT_URL_DELETE = "user/{0}/monetary-account/{1}/customer-statement/{2}";

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

        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId)
        {
            return Create(apiContext, requestMap, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            int monetaryAccountId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var response = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId), requestBytes,
                customHeaders);

            return ProcessForId(response.Content.ReadAsStringAsync().Result);
        }

        public static CustomerStatementExport Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int customerStatementExportId)
        {
            return Get(apiContext, userId, monetaryAccountId, customerStatementExportId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static CustomerStatementExport Get(ApiContext apiContext, int userId, int monetaryAccountId,
            int customerStatementExportId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, customerStatementExportId),
                    customHeaders);

            return FromJson<CustomerStatementExport>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }

        public static List<CustomerStatementExport> List(ApiContext apiContext, int userId, int monetaryAccountId)
        {
            return List(apiContext, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static List<CustomerStatementExport> List(ApiContext apiContext, int userId, int monetaryAccountId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), customHeaders);

            return FromJsonList<CustomerStatementExport>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }

        public static void Delete(ApiContext apiContext, int userId, int monetaryAccountId,
            int customerStatementExportId)
        {
            Delete(apiContext, userId, monetaryAccountId, customerStatementExportId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static void Delete(ApiContext apiContext, int userId, int monetaryAccountId,
            int customerStatementExportId, IDictionary<String, String> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, userId, monetaryAccountId, customerStatementExportId),
                customHeaders);
        }
    }
}
