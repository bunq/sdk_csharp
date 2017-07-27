using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Fetch the raw content of a statement export. The returned file format could be MT940, CSV or PDF depending on
    /// the statement format specified during the statement creation. The doc won't display the response of a request to
    /// get the content of a statement export.
    /// </summary>
    public class CustomerStatementExportContent : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/customer-statement/{2}/content";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "CustomerStatementExportContent";

        public static byte[] List(ApiContext apiContext, int userId, int monetaryAccountId, int customerStatementId)
        {
            return List(apiContext, userId, monetaryAccountId, customerStatementId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static byte[] List(ApiContext apiContext, int userId, int monetaryAccountId, int customerStatementId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);

            return apiClient
                .Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, customerStatementId), customHeaders)
                .Content.ReadAsByteArrayAsync().Result;
        }
    }
}
