using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
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
        private const string EndpointUrlListing = "user/{0}/export-annual-overview/{1}/content";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "ExportAnnualOverviewContent";
    
        /// <summary>
        /// Used to retrieve the raw content of an annual overview.
        /// </summary>
        public static BunqResponse<byte[]> List(ApiContext apiContext, int userId, int exportAnnualOverviewId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlListing, userId, exportAnnualOverviewId), new Dictionary<string, string>(), customHeaders);
    
            return new BunqResponse<byte[]>(responseRaw.BodyBytes, responseRaw.Headers);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static ExportAnnualOverviewContent CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ExportAnnualOverviewContent>(json);
        }
    }
}
