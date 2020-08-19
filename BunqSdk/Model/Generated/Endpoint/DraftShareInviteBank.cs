using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to create a draft share invite for a monetary account with another bunq user, as in the 'Connect' feature
    /// in the bunq app. The user that accepts the invite can share one of their MonetaryAccounts with the user that
    /// created the invite.
    /// </summary>
    public class DraftShareInviteBank : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/draft-share-invite-bank";
        protected const string ENDPOINT_URL_READ = "user/{0}/draft-share-invite-bank/{1}";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/draft-share-invite-bank/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/draft-share-invite-bank";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";
        public const string FIELD_EXPIRATION = "expiration";
        public const string FIELD_DRAFT_SHARE_SETTINGS = "draft_share_settings";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "DraftShareInviteBank";

        /// <summary>
        /// The status of the draft share invite. Can be USED, CANCELLED and PENDING.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The moment when this draft share invite expires.
        /// </summary>
        [JsonProperty(PropertyName = "expiration")]
        public string Expiration { get; set; }

        /// <summary>
        /// The draft share invite details.
        /// </summary>
        [JsonProperty(PropertyName = "draft_share_settings")]
        public DraftShareInviteEntry DraftShareSettings { get; set; }

        /// <summary>
        /// The user who created the draft share invite.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_created")]
        public LabelUser UserAliasCreated { get; set; }

        /// <summary>
        /// The id of the share invite bank response this draft share belongs to.
        /// </summary>
        [JsonProperty(PropertyName = "share_invite_bank_response_id")]
        public int? ShareInviteBankResponseId { get; set; }

        /// <summary>
        /// The URL redirecting user to the draft share invite in the app. Only works on mobile devices.
        /// </summary>
        [JsonProperty(PropertyName = "draft_share_url")]
        public string DraftShareUrl { get; set; }

        /// <summary>
        /// The id of the newly created draft share invite.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }


        /// <summary>
        /// </summary>
        /// <param name="expiration">The moment when this draft share invite expires.</param>
        /// <param name="draftShareSettings">The draft share invite details.</param>
        /// <param name="status">The status of the draft share invite. Can be CANCELLED (the user cancels the draft share before it's used).</param>
        public static BunqResponse<int> Create(string expiration, DraftShareInviteEntry draftShareSettings,
            string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_STATUS, status},
                {FIELD_EXPIRATION, expiration},
                {FIELD_DRAFT_SHARE_SETTINGS, draftShareSettings},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes,
                customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Get the details of a specific draft of a share invite.
        /// </summary>
        public static BunqResponse<DraftShareInviteBank> Get(int draftShareInviteBankId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), draftShareInviteBankId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<DraftShareInviteBank>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Update a draft share invite. When sending status CANCELLED it is possible to cancel the draft share invite.
        /// </summary>
        /// <param name="status">The status of the draft share invite. Can be CANCELLED (the user cancels the draft share before it's used).</param>
        /// <param name="expiration">The moment when this draft share invite expires.</param>
        /// <param name="draftShareSettings">The draft share invite details.</param>
        public static BunqResponse<int> Update(int draftShareInviteBankId, string status = null,
            string expiration = null, DraftShareInviteEntry draftShareSettings = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_STATUS, status},
                {FIELD_EXPIRATION, expiration},
                {FIELD_DRAFT_SHARE_SETTINGS, draftShareSettings},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), draftShareInviteBankId),
                    requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<DraftShareInviteBank>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<DraftShareInviteBank>(responseRaw, OBJECT_TYPE_GET);
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

            if (this.Expiration != null)
            {
                return false;
            }

            if (this.ShareInviteBankResponseId != null)
            {
                return false;
            }

            if (this.DraftShareUrl != null)
            {
                return false;
            }

            if (this.DraftShareSettings != null)
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
        public static DraftShareInviteBank CreateFromJsonString(string json)
        {
            return CreateFromJsonString<DraftShareInviteBank>(json);
        }
    }
}