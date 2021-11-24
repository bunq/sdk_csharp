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
    /// Fetch the raw content of a card statement export. The returned file format could be CSV or PDF depending on the
    /// statement format specified during the statement creation. The doc won't display the response of a request to get
    /// the content of a statement export.
    /// </summary>
    public class ExportStatementCardContent : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/card/{1}/card-statement/{2}/content";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "ExportStatementCardContent";
    
        /// <summary>
        /// </summary>
        public static BunqResponse<byte[]> List(int cardId, int cardStatementId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), cardId, cardStatementId), new Dictionary<string, string>(), customHeaders);
    
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
        public static ExportStatementCardContent CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ExportStatementCardContent>(json);
        }
    }
}
