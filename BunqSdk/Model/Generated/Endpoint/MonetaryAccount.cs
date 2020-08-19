using System.Collections.Generic;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to show the MonetaryAccounts that you can access. Currently the only MonetaryAccount type is
    /// MonetaryAccountBank. See also: monetary-account-bank.<br/><br/>Notification filters can be set on a monetary
    /// account level to receive callbacks. For more information check the <a href="/api/2/page/callbacks">dedicated
    /// callbacks page</a>.
    /// </summary>
    public class MonetaryAccount : BunqModel, IAnchorObjectInterface
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ERROR_NULL_FIELDS = "All fields of an extended model or object are null.";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "MonetaryAccount";

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountBank")]
        public MonetaryAccountBank MonetaryAccountBank { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountJoint")]
        public MonetaryAccountJoint MonetaryAccountJoint { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountLight")]
        public MonetaryAccountLight MonetaryAccountLight { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MonetaryAccountSavings")]
        public MonetaryAccountSavings MonetaryAccountSavings { get; set; }


        /// <summary>
        /// Get a specific MonetaryAccount.
        /// </summary>
        public static BunqResponse<MonetaryAccount> Get(int monetaryAccountId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)),
                    new Dictionary<string, string>(), customHeaders);

            return FromJson<MonetaryAccount>(responseRaw);
        }

        /// <summary>
        /// Get a collection of all your MonetaryAccounts.
        /// </summary>
        public static BunqResponse<List<MonetaryAccount>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<MonetaryAccount>(responseRaw);
        }


        /// <summary>
        /// </summary>
        public BunqModel GetReferencedObject()
        {
            if (this.MonetaryAccountBank != null)
            {
                return this.MonetaryAccountBank;
            }

            if (this.MonetaryAccountJoint != null)
            {
                return this.MonetaryAccountJoint;
            }

            if (this.MonetaryAccountLight != null)
            {
                return this.MonetaryAccountLight;
            }

            if (this.MonetaryAccountSavings != null)
            {
                return this.MonetaryAccountSavings;
            }

            throw new BunqException(ERROR_NULL_FIELDS);
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.MonetaryAccountBank != null)
            {
                return false;
            }

            if (this.MonetaryAccountJoint != null)
            {
                return false;
            }

            if (this.MonetaryAccountLight != null)
            {
                return false;
            }

            if (this.MonetaryAccountSavings != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static MonetaryAccount CreateFromJsonString(string json)
        {
            return CreateFromJsonString<MonetaryAccount>(json);
        }
    }
}