using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    ///     Used to create new and read existing statement exports. Statement exports can be created in either CSV, MT940 or
    ///     PDF file format.
    /// </summary>
    public class ExportStatement : BunqModel
    {
        /// <summary>
        ///     Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/customer-statement";

        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/customer-statement/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/customer-statement";
        protected const string ENDPOINT_URL_DELETE = "user/{0}/monetary-account/{1}/customer-statement/{2}";

        /// <summary>
        ///     Field constants.
        /// </summary>
        public const string FIELD_STATEMENT_FORMAT = "statement_format";

        public const string FIELD_DATE_START = "date_start";
        public const string FIELD_DATE_END = "date_end";
        public const string FIELD_REGIONAL_FORMAT = "regional_format";
        public const string FIELD_INCLUDE_ATTACHMENT = "include_attachment";

        /// <summary>
        ///     Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "CustomerStatement";

        /// <summary>
        ///     The format of statement.
        /// </summary>
        [JsonProperty(PropertyName = "statement_format")]
        public string StatementFormat { get; set; }

        /// <summary>
        ///     The date from when this statement shows transactions.
        /// </summary>
        [JsonProperty(PropertyName = "date_start")]
        public string DateStart { get; set; }

        /// <summary>
        ///     The date until which statement shows transactions.
        /// </summary>
        [JsonProperty(PropertyName = "date_end")]
        public string DateEnd { get; set; }

        /// <summary>
        ///     The regional format of a CSV statement.
        /// </summary>
        [JsonProperty(PropertyName = "regional_format")]
        public string RegionalFormat { get; set; }

        /// <summary>
        ///     Only for PDF exports. Includes attachments to mutations in the export, such as scanned receipts.
        /// </summary>
        [JsonProperty(PropertyName = "include_attachment")]
        public bool? IncludeAttachment { get; set; }

        /// <summary>
        ///     The id of the customer statement model.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        ///     The timestamp of the statement model's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        ///     The timestamp of the statement model's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        ///     The status of the export.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        ///     MT940 Statement number. Unique per monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "statement_number")]
        public int? StatementNumber { get; set; }

        /// <summary>
        ///     The monetary account for which this statement was created.
        /// </summary>
        [JsonProperty(PropertyName = "alias_monetary_account")]
        public MonetaryAccountReference AliasMonetaryAccount { get; set; }


        /// <summary>
        /// </summary>
        /// <param name="statementFormat">The format type of statement. Allowed values: MT940, CSV, PDF.</param>
        /// <param name="dateStart">The start date for making statements.</param>
        /// <param name="dateEnd">The end date for making statements.</param>
        /// <param name="regionalFormat">
        ///     Required for CSV exports. The regional format of the statement, can be UK_US
        ///     (comma-separated) or EUROPEAN (semicolon-separated).
        /// </param>
        /// <param name="includeAttachment">
        ///     Only for PDF exports. Includes attachments to mutations in the export, such as scanned
        ///     receipts.
        /// </param>
        public static BunqResponse<int> Create(string statementFormat, string dateStart, string dateEnd,
            int? monetaryAccountId = null, string regionalFormat = null, bool? includeAttachment = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_STATEMENT_FORMAT, statementFormat},
                {FIELD_DATE_START, dateStart},
                {FIELD_DATE_END, dateEnd},
                {FIELD_REGIONAL_FORMAT, regionalFormat},
                {FIELD_INCLUDE_ATTACHMENT, includeAttachment}
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Post(
                    string.Format(ENDPOINT_URL_CREATE, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId)), requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<ExportStatement> Get(int exportStatementId, int? monetaryAccountId = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        exportStatementId), new Dictionary<string, string>(), customHeaders);

            return FromJson<ExportStatement>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<ExportStatement>> List(int? monetaryAccountId = null,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_LISTING, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);

            return FromJsonList<ExportStatement>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<object> Delete(int exportStatementId, int? monetaryAccountId = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Delete(
                    string.Format(ENDPOINT_URL_DELETE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        exportStatementId), customHeaders);

            return new BunqResponse<object>(null, responseRaw.Headers);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Id != null) return false;

            if (Created != null) return false;

            if (Updated != null) return false;

            if (DateStart != null) return false;

            if (DateEnd != null) return false;

            if (Status != null) return false;

            if (StatementNumber != null) return false;

            if (StatementFormat != null) return false;

            if (RegionalFormat != null) return false;

            if (AliasMonetaryAccount != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static ExportStatement CreateFromJsonString(string json)
        {
            return CreateFromJsonString<ExportStatement>(json);
        }
    }
}