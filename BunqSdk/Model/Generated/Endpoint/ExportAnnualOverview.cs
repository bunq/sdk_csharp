using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to create new and read existing annual overviews of all the user's monetary accounts. Once created, annual
    /// overviews can be downloaded in PDF format via the 'export-annual-overview/{id}/content' endpoint.
    /// </summary>
    public class ExportAnnualOverview : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/export-annual-overview";
        protected const string ENDPOINT_URL_READ = "user/{0}/export-annual-overview/{1}";
        protected const string ENDPOINT_URL_DELETE = "user/{0}/export-annual-overview/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/export-annual-overview";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_YEAR = "year";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "ExportAnnualOverview";

        /// <summary>
        /// The year for which the overview is.
        /// </summary>
        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        /// <summary>
        /// The id of the annual overview as created on the server.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the annual overview 's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the annual overview 's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The user to which this annual overview belongs.
        /// </summary>
        [JsonProperty(PropertyName = "alias_user")]
        public LabelUser AliasUser { get; set; }


        /// <summary>
        /// Create a new annual overview for a specific year. An overview can be generated only for a past year.
        /// </summary>
        /// <param name="year">The year for which the overview is.</param>
        public static BunqResponse<int> Create(int? year, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_YEAR, year},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes,
                customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Get an annual overview for a user by its id.
        /// </summary>
        public static BunqResponse<ExportAnnualOverview> Get(int exportAnnualOverviewId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), exportAnnualOverviewId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<ExportAnnualOverview>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<object> Delete(int exportAnnualOverviewId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, DetermineUserId(), exportAnnualOverviewId),
                    customHeaders);

            return new BunqResponse<object>(null, responseRaw.Headers);
        }

        /// <summary>
        /// List all the annual overviews for a user.
        /// </summary>
        public static BunqResponse<List<ExportAnnualOverview>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<ExportAnnualOverview>(responseRaw, OBJECT_TYPE_GET);
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

            if (this.Year != null)
            {
                return false;
            }

            if (this.AliasUser != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static ExportAnnualOverview CreateFromJsonString(string json)
        {
            return CreateFromJsonString<ExportAnnualOverview>(json);
        }
    }
}