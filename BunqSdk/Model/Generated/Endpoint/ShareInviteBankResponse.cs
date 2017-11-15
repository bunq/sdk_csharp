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
    /// Used to view or respond to shares a user was invited to. See 'share-invite-bank-inquiry' for more information
    /// about the inquiring endpoint.
    /// </summary>
    public class ShareInviteBankResponse : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "user/{0}/share-invite-bank-response/{1}";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/share-invite-bank-response/{1}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/share-invite-bank-response";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ShareInviteBankResponse";
    
        /// <summary>
        /// The monetary account and user who created the share.
        /// </summary>
        [JsonProperty(PropertyName = "counter_alias")]
        public MonetaryAccountReference CounterAlias { get; private set; }
    
        /// <summary>
        /// The user who cancelled the share if it has been revoked or rejected.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_cancelled")]
        public LabelUser UserAliasCancelled { get; private set; }
    
        /// <summary>
        /// The id of the monetary account the ACCEPTED share applies to. null otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; private set; }
    
        /// <summary>
        /// The id of the draft share invite bank.
        /// </summary>
        [JsonProperty(PropertyName = "draft_share_invite_bank_id")]
        public int? DraftShareInviteBankId { get; private set; }
    
        /// <summary>
        /// The share details.
        /// </summary>
        [JsonProperty(PropertyName = "share_detail")]
        public ShareDetail ShareDetail { get; private set; }
    
        /// <summary>
        /// The status of the share. Can be PENDING, REVOKED (the user deletes the share inquiry before it's accepted),
        /// ACCEPTED, CANCELLED (the user deletes an active share) or CANCELLATION_PENDING, CANCELLATION_ACCEPTED,
        /// CANCELLATION_REJECTED (for canceling mutual connects)
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// The share type: STANDARD.
        /// </summary>
        [JsonProperty(PropertyName = "share_type")]
        public string ShareType { get; private set; }
    
        /// <summary>
        /// The start date of this share.
        /// </summary>
        [JsonProperty(PropertyName = "start_date")]
        public string StartDate { get; private set; }
    
        /// <summary>
        /// The expiration date of this share.
        /// </summary>
        [JsonProperty(PropertyName = "end_date")]
        public string EndDate { get; private set; }
    
        /// <summary>
        /// The description of this share. It is basically the monetary account description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }
    
        /// <summary>
        /// Return the details of a specific share a user was invited to.
        /// </summary>
        public static BunqResponse<ShareInviteBankResponse> Get(ApiContext apiContext, int userId, int shareInviteBankResponseId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, shareInviteBankResponseId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<ShareInviteBankResponse>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// Accept or reject a share a user was invited to.
        /// </summary>
        public static BunqResponse<ShareInviteBankResponse> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int shareInviteBankResponseId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, shareInviteBankResponseId), requestBytes, customHeaders);
    
            return FromJson<ShareInviteBankResponse>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// Return all the shares a user was invited to.
        /// </summary>
        public static BunqResponse<List<ShareInviteBankResponse>> List(ApiContext apiContext, int userId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId), urlParams, customHeaders);
    
            return FromJsonList<ShareInviteBankResponse>(responseRaw, OBJECT_TYPE);
        }
    }
}
