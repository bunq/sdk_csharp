using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Used to create new and read existing annual overviews of all the user's monetary accounts. Once created, annual
    /// overviews can be downloaded in PDF format via the 'export-annual-overview/{id}/content' endpoint.
    /// </summary>
    public class ExportAnnualOverview : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_YEAR = "year";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/export-annual-overview";
        private const string ENDPOINT_URL_READ = "user/{0}/export-annual-overview/{1}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/export-annual-overview";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ExportAnnualOverview";

        /// <summary>
        /// The id of the annual overview as created on the server.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }

        /// <summary>
        /// The timestamp of the annual overview 's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }

        /// <summary>
        /// The timestamp of the annual overview 's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }

        /// <summary>
        /// The year for which the overview is.
        /// </summary>
        [JsonProperty(PropertyName = "year")]
        public int? Year { get; private set; }

        /// <summary>
        /// The user to which this annual overview belongs.
        /// </summary>
        [JsonProperty(PropertyName = "alias_user")]
        public LabelUser AliasUser { get; private set; }

        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId)
        {
            return Create(apiContext, requestMap, userId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Create a new annual overview for a specific year. An overview can be generated only for a past year.
        /// </summary>
        public static int Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var response = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId), requestBytes, customHeaders);

            return ProcessForId(response.Content.ReadAsStringAsync().Result);
        }

        public static ExportAnnualOverview Get(ApiContext apiContext, int userId, int exportAnnualOverviewId)
        {
            return Get(apiContext, userId, exportAnnualOverviewId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get an annual overview for a user by its id.
        /// </summary>
        public static ExportAnnualOverview Get(ApiContext apiContext, int userId, int exportAnnualOverviewId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, exportAnnualOverviewId),
                customHeaders);

            return FromJson<ExportAnnualOverview>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }

        public static List<ExportAnnualOverview> List(ApiContext apiContext, int userId)
        {
            return List(apiContext, userId, new Dictionary<string, string>());
        }

        /// <summary>
        /// List all the annual overviews for a user.
        /// </summary>
        public static List<ExportAnnualOverview> List(ApiContext apiContext, int userId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var response = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId), customHeaders);

            return FromJsonList<ExportAnnualOverview>(response.Content.ReadAsStringAsync().Result, OBJECT_TYPE);
        }
    }
}
