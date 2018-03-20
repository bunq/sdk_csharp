using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to create a draft share invite for a user with another bunq user. The user that accepts the invite can
    /// share his MAs with the user that created the invite.
    /// </summary>
    public class DraftShareInviteApiKey : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/draft-share-invite-api-key";

        protected const string ENDPOINT_URL_READ = "user/{0}/draft-share-invite-api-key/{1}";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/draft-share-invite-api-key/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/draft-share-invite-api-key";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";

        public const string FIELD_SUB_STATUS = "sub_status";
        public const string FIELD_EXPIRATION = "expiration";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "DraftShareInviteApiKey";

        private const string OBJECT_TYPE_PUT = "DraftShareInviteApiKey";

        /// <summary>
        /// The user who created the draft share invite.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_created")]
        public LabelUser UserAliasCreated { get; set; }

        /// <summary>
        /// The status of the draft share invite. Can be USED, CANCELLED and PENDING.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The sub-status of the draft share invite. Can be NONE, ACCEPTED or REJECTED.
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; set; }

        /// <summary>
        /// The moment when this draft share invite expires.
        /// </summary>
        [JsonProperty(PropertyName = "expiration")]
        public string Expiration { get; set; }

        /// <summary>
        /// The URL redirecting user to the draft share invite in the app. Only works on mobile devices.
        /// </summary>
        [JsonProperty(PropertyName = "draft_share_url")]
        public string DraftShareUrl { get; set; }

        /// <summary>
        /// The API key generated for this DraftShareInviteApiKey.
        /// </summary>
        [JsonProperty(PropertyName = "api_key")]
        public string ApiKey { get; set; }

        /// <summary>
        /// The id of the newly created draft share invite.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="expiration">The moment when this draft share invite expires.</param>
        /// <param name="status">The status of the draft share invite. Can be CANCELLED (the user cancels the draft share before it's used).</param>
        /// <param name="subStatus">The sub-status of the draft share invite. Can be NONE, ACCEPTED or REJECTED.</param>
        public static BunqResponse<int> Create(string expiration, string status = null, string subStatus = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_STATUS, status},
                {FIELD_SUB_STATUS, subStatus},
                {FIELD_EXPIRATION, expiration},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes,
                customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Get the details of a specific draft of a share invite.
        /// </summary>
        public static BunqResponse<DraftShareInviteApiKey> Get(int draftShareInviteApiKeyId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), draftShareInviteApiKeyId),
                    new Dictionary<string, string>(), customHeaders);

            return FromJson<DraftShareInviteApiKey>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Update a draft share invite. When sending status CANCELLED it is possible to cancel the draft share invite.
        /// </summary>
        /// <param name="status">The status of the draft share invite. Can be CANCELLED (the user cancels the draft share before it's used).</param>
        /// <param name="subStatus">The sub-status of the draft share invite. Can be NONE, ACCEPTED or REJECTED.</param>
        /// <param name="expiration">The moment when this draft share invite expires.</param>
        public static BunqResponse<DraftShareInviteApiKey> Update(int draftShareInviteApiKeyId, string status = null,
            string subStatus = null, string expiration = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_STATUS, status},
                {FIELD_SUB_STATUS, subStatus},
                {FIELD_EXPIRATION, expiration},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), draftShareInviteApiKeyId),
                    requestBytes, customHeaders);

            return FromJson<DraftShareInviteApiKey>(responseRaw, OBJECT_TYPE_PUT);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<DraftShareInviteApiKey>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<DraftShareInviteApiKey>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.UserAliasCreated != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.SubStatus != null)
            {
                return false;
            }

            if (this.Expiration != null)
            {
                return false;
            }

            if (this.DraftShareUrl != null)
            {
                return false;
            }

            if (this.ApiKey != null)
            {
                return false;
            }

            if (this.Id != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static DraftShareInviteApiKey CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<DraftShareInviteApiKey>(json);
        }
    }
}