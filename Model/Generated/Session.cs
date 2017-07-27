using System;
using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;

namespace Bunq.Sdk.Model.Generated
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

        public static void Delete(ApiContext apiContext, int sessionId)
        {
            Delete(apiContext, sessionId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Deletes the current session. No response is returned for this request.
        /// </summary>
        public static void Delete(ApiContext apiContext, int sessionId, IDictionary<String, String> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, sessionId), customHeaders);
        }
    }
}
