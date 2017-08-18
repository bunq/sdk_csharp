using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Used to show the MonetaryAccounts that you can access. Currently the only MonetaryAccount type is
    /// MonetaryAccountBank. See also: monetary-account-bank.<br/><br/>Notification filters can be set on a monetary
    /// account level to receive callbacks. For more information check the <a href="/api/2/page/callbacks">dedicated
    /// callbacks page</a>.
    /// </summary>
    public class MonetaryAccount : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "MonetaryAccount";

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountBank")]
        public MonetaryAccountBank MonetaryAccountBank { get; private set; }

        public static BunqResponse<MonetaryAccount> Get(ApiContext apiContext, int userId, int monetaryAccountId)
        {
            return Get(apiContext, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a specific MonetaryAccount.
        /// </summary>
        public static BunqResponse<MonetaryAccount> Get(ApiContext apiContext, int userId, int monetaryAccountId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId), customHeaders);

            return FromJson<MonetaryAccount>(responseRaw);
        }

        public static BunqResponse<List<MonetaryAccount>> List(ApiContext apiContext, int userId)
        {
            return List(apiContext, userId, new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a collection of all your MonetaryAccounts.
        /// </summary>
        public static BunqResponse<List<MonetaryAccount>> List(ApiContext apiContext, int userId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId), customHeaders);

            return FromJsonList<MonetaryAccount>(responseRaw);
        }
    }
}
