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
    /// Endpoint for operations over the current session.
    /// </summary>
    public class Session : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_DELETE = "session/{0}";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "Session";
    
        /// <summary>
        /// Deletes the current session. No response is returned for this request.
        /// </summary>
        public static BunqResponse<object> Delete(ApiContext apiContext, int sessionId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, sessionId), customHeaders);
    
            return new BunqResponse<object>(null, responseRaw.Headers);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static Session CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Session>(json);
        }
    }
}
