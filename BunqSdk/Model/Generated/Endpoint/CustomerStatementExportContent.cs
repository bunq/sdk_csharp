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
    
        /// <summary>
        /// </summary>
        public static BunqResponse<byte[]> List(ApiContext apiContext, int userId, int monetaryAccountId, int customerStatementId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, customerStatementId), new Dictionary<string, string>(), customHeaders);
    
            return new BunqResponse<byte[]>(responseRaw.BodyBytes, responseRaw.Headers);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
        {
            return true;
        }
    }
}
