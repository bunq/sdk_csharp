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
    /// Used to share a monetary account with another bunq user, as in the 'Connect' feature in the bunq app. Allow the
    /// creation of share inquiries that, in the same way as request inquiries, can be revoked by the user creating them
    /// or accepted/rejected by the other party.
    /// </summary>
    public class ShareInviteBankInquiry : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/share-invite-bank-inquiry";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/share-invite-bank-inquiry/{2}";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/share-invite-bank-inquiry/{2}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/share-invite-bank-inquiry";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_COUNTER_USER_ALIAS = "counter_user_alias";
        public const string FIELD_DRAFT_SHARE_INVITE_BANK_ID = "draft_share_invite_bank_id";
        public const string FIELD_SHARE_DETAIL = "share_detail";
        public const string FIELD_STATUS = "status";
        public const string FIELD_SHARE_TYPE = "share_type";
        public const string FIELD_START_DATE = "start_date";
        public const string FIELD_END_DATE = "end_date";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ShareInviteBankInquiry";
    
        /// <summary>
        /// The label of the monetary account that's being shared.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; private set; }
    
        /// <summary>
        /// The user who created the share.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_created")]
        public LabelUser UserAliasCreated { get; private set; }
    
        /// <summary>
        /// The user who revoked the share.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_revoked")]
        public LabelUser UserAliasRevoked { get; private set; }
    
        /// <summary>
        /// The label of the user to share with.
        /// </summary>
        [JsonProperty(PropertyName = "counter_user_alias")]
        public LabelUser CounterUserAlias { get; private set; }
    
        /// <summary>
        /// The id of the monetary account the share applies to.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; private set; }
    
        /// <summary>
        /// The id of the draft share invite bank.
        /// </summary>
        [JsonProperty(PropertyName = "draft_share_invite_bank_id")]
        public int? DraftShareInviteBankId { get; private set; }
    
        /// <summary>
        /// The share details. Only one of these objects is returned.
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
        /// The share type, either STANDARD or MUTUAL.
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
        /// The id of the newly created share invite.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// Create a new share inquiry for a monetary account, specifying the permission the other bunq user will have
        /// on it.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Get the details of a specific share inquiry.
        /// </summary>
        public static BunqResponse<ShareInviteBankInquiry> Get(ApiContext apiContext, int userId, int monetaryAccountId, int shareInviteBankInquiryId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, shareInviteBankInquiryId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<ShareInviteBankInquiry>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// Update the details of a share. This includes updating status (revoking or cancelling it), granted permission
        /// and validity period of this share.
        /// </summary>
        public static BunqResponse<ShareInviteBankInquiry> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int shareInviteBankInquiryId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, shareInviteBankInquiryId), requestBytes, customHeaders);
    
            return FromJson<ShareInviteBankInquiry>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// Get a list with all the share inquiries for a monetary account, only if the requesting user has permission
        /// to change the details of the various ones.
        /// </summary>
        public static BunqResponse<List<ShareInviteBankInquiry>> List(ApiContext apiContext, int userId, int monetaryAccountId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId), urlParams, customHeaders);
    
            return FromJsonList<ShareInviteBankInquiry>(responseRaw, OBJECT_TYPE);
        }
    }
}
