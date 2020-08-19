using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to manage Slice group settings.
    /// </summary>
    public class RegistrySetting : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/registry/{1}/registry-setting/{2}";
        protected const string ENDPOINT_URL_READ = "user/{0}/registry/{1}/registry-setting/{2}";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_AUTO_ADD_CARD_TRANSACTION = "auto_add_card_transaction";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "RegistrySetting";

        /// <summary>
        /// The setting for for adding automatically card transactions to the registry.
        /// </summary>
        [JsonProperty(PropertyName = "auto_add_card_transaction")]
        public string AutoAddCardTransaction { get; set; }

        /// <summary>
        /// Update a specific Slice group setting.
        /// </summary>
        /// <param name="autoAddCardTransaction">The setting for for adding automatically card transactions to the registry.</param>
        public static BunqResponse<int> Update(int registryId, int registrySettingId,
            string autoAddCardTransaction = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_AUTO_ADD_CARD_TRANSACTION, autoAddCardTransaction},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), registryId, registrySettingId),
                    requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Get a specific Slice group setting.
        /// </summary>
        public static BunqResponse<RegistrySetting> Get(int registryId, int registrySettingId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), registryId, registrySettingId),
                    new Dictionary<string, string>(), customHeaders);

            return FromJson<RegistrySetting>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.AutoAddCardTransaction != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static RegistrySetting CreateFromJsonString(string json)
        {
            return CreateFromJsonString<RegistrySetting>(json);
        }
    }
}