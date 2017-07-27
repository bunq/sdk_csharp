using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Fetch the raw content of an annual overview. The annual overview is always in PDF format. Doc won't display the
    /// response of a request to get the content of an annual overview.
    /// </summary>
    public class ExportAnnualOverviewContent : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING = "user/{0}/export-annual-overview/{1}/content";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ExportAnnualOverviewContent";

        public static byte[] List(ApiContext apiContext, int userId, int exportAnnualOverviewId)
        {
            return List(apiContext, userId, exportAnnualOverviewId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Used to retrieve the raw content of an annual overview.
        /// </summary>
        public static byte[] List(ApiContext apiContext, int userId, int exportAnnualOverviewId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);

            return apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, exportAnnualOverviewId), customHeaders)
                .Content.ReadAsByteArrayAsync().Result;
        }
    }
}
