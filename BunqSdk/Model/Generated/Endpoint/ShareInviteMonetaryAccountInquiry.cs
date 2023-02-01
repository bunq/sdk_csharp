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
    /// [DEPRECATED - use /share-invite-monetary-account-response] Used to share a monetary account with another bunq
    /// user, as in the 'Connect' feature in the bunq app. Allow the creation of share inquiries that, in the same way
    /// as request inquiries, can be revoked by the user creating them or accepted/rejected by the other party.
    /// </summary>
    public class ShareInviteMonetaryAccountInquiry : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/share-invite-monetary-account-inquiry";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/share-invite-monetary-account-inquiry/{2}";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/share-invite-monetary-account-inquiry/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/share-invite-monetary-account-inquiry";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_COUNTER_USER_ALIAS = "counter_user_alias";
        public const string FIELD_ACCESS_TYPE = "access_type";
        public const string FIELD_DRAFT_SHARE_INVITE_BANK_ID = "draft_share_invite_bank_id";
        public const string FIELD_SHARE_DETAIL = "share_detail";
        public const string FIELD_STATUS = "status";
        public const string FIELD_RELATIONSHIP = "relationship";
        public const string FIELD_SHARE_TYPE = "share_type";
        public const string FIELD_START_DATE = "start_date";
        public const string FIELD_END_DATE = "end_date";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "ShareInviteMonetaryAccountInquiry";
    
        /// <summary>
        /// The label of the user to share with.
        /// </summary>
        [JsonProperty(PropertyName = "counter_user_alias")]
        public MonetaryAccountReference CounterUserAlias { get; set; }
    
        /// <summary>
        /// Type of access that is in place.
        /// </summary>
        [JsonProperty(PropertyName = "access_type")]
        public string AccessType { get; set; }
    
        /// <summary>
        /// DEPRECATED: USE `access_type` INSTEAD | The id of the draft share invite bank.
        /// </summary>
        [JsonProperty(PropertyName = "draft_share_invite_bank_id")]
        public int? DraftShareInviteBankId { get; set; }
    
        /// <summary>
        /// DEPRECATED: USE `access_type` INSTEAD | The share details. Only one of these objects may be passed.
        /// </summary>
        [JsonProperty(PropertyName = "share_detail")]
        public ShareDetail ShareDetail { get; set; }
    
        /// <summary>
        /// The status of the share. Can be ACTIVE, REVOKED, REJECTED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The relationship: COMPANY_DIRECTOR, COMPANY_EMPLOYEE, etc
        /// </summary>
        [JsonProperty(PropertyName = "relationship")]
        public string Relationship { get; set; }
    
        /// <summary>
        /// DEPRECATED: USE `access_type` INSTEAD | The share type, either STANDARD or MUTUAL.
        /// </summary>
        [JsonProperty(PropertyName = "share_type")]
        public string ShareType { get; set; }
    
        /// <summary>
        /// DEPRECATED: USE `access_type` INSTEAD | The start date of this share.
        /// </summary>
        [JsonProperty(PropertyName = "start_date")]
        public string StartDate { get; set; }
    
        /// <summary>
        /// DEPRECATED: USE `access_type` INSTEAD | The expiration date of this share.
        /// </summary>
        [JsonProperty(PropertyName = "end_date")]
        public string EndDate { get; set; }
    
        /// <summary>
        /// The label of the monetary account that's being shared.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
    
        /// <summary>
        /// The user who created the share.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_created")]
        public MonetaryAccountReference UserAliasCreated { get; set; }
    
        /// <summary>
        /// The user who revoked the share.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_revoked")]
        public MonetaryAccountReference UserAliasRevoked { get; set; }
    
        /// <summary>
        /// The id of the monetary account the share applies to.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }
    
        /// <summary>
        /// The id of the newly created share invite.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
    
        /// <summary>
        /// [DEPRECATED - use /share-invite-monetary-account-response] Create a new share inquiry for a monetary
        /// account, specifying the permission the other bunq user will have on it.
        /// </summary>
        /// <param name="counterUserAlias">The pointer of the user to share with.</param>
        /// <param name="accessType">Type of access that is wanted, one of VIEW_BALANCE, VIEW_TRANSACTION, DRAFT_PAYMENT or FULL_TRANSIENT</param>
        /// <param name="draftShareInviteBankId">DEPRECATED: USE `access_type` INSTEAD | The id of the draft share invite bank.</param>
        /// <param name="shareDetail">DEPRECATED: USE `access_type` INSTEAD | The share details. Only one of these objects may be passed.</param>
        /// <param name="status">The status of the share. Can be ACTIVE, REVOKED, REJECTED.</param>
        /// <param name="relationship">The relationship: COMPANY_DIRECTOR, COMPANY_EMPLOYEE, etc</param>
        /// <param name="shareType">DEPRECATED: USE `access_type` INSTEAD | The share type, either STANDARD or MUTUAL.</param>
        /// <param name="startDate">DEPRECATED: USE `access_type` INSTEAD | The start date of this share.</param>
        /// <param name="endDate">DEPRECATED: USE `access_type` INSTEAD | The expiration date of this share.</param>
        public static BunqResponse<int> Create(Pointer counterUserAlias, int? monetaryAccountId= null, string accessType = null, int? draftShareInviteBankId = null, ShareDetail shareDetail = null, string status = null, string relationship = null, string shareType = null, string startDate = null, string endDate = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_COUNTER_USER_ALIAS, counterUserAlias},
    {FIELD_ACCESS_TYPE, accessType},
    {FIELD_DRAFT_SHARE_INVITE_BANK_ID, draftShareInviteBankId},
    {FIELD_SHARE_DETAIL, shareDetail},
    {FIELD_STATUS, status},
    {FIELD_RELATIONSHIP, relationship},
    {FIELD_SHARE_TYPE, shareType},
    {FIELD_START_DATE, startDate},
    {FIELD_END_DATE, endDate},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// [DEPRECATED - use /share-invite-monetary-account-response] Get the details of a specific share inquiry.
        /// </summary>
        public static BunqResponse<ShareInviteMonetaryAccountInquiry> Get(int shareInviteMonetaryAccountInquiryId, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), shareInviteMonetaryAccountInquiryId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<ShareInviteMonetaryAccountInquiry>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// [DEPRECATED - use /share-invite-monetary-account-response] Update the details of a share. This includes
        /// updating status (revoking or cancelling it), granted permission and validity period of this share.
        /// </summary>
        /// <param name="accessType">Type of access that is wanted, one of VIEW_BALANCE, VIEW_TRANSACTION, DRAFT_PAYMENT or FULL_TRANSIENT</param>
        /// <param name="shareDetail">DEPRECATED: USE `access_type` INSTEAD | The share details. Only one of these objects may be passed.</param>
        /// <param name="status">The status of the share. Can be ACTIVE, REVOKED, REJECTED.</param>
        /// <param name="startDate">DEPRECATED: USE `access_type` INSTEAD | The start date of this share.</param>
        /// <param name="endDate">DEPRECATED: USE `access_type` INSTEAD | The expiration date of this share.</param>
        public static BunqResponse<int> Update(int shareInviteMonetaryAccountInquiryId, int? monetaryAccountId= null, string accessType = null, ShareDetail shareDetail = null, string status = null, string startDate = null, string endDate = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_ACCESS_TYPE, accessType},
    {FIELD_SHARE_DETAIL, shareDetail},
    {FIELD_STATUS, status},
    {FIELD_START_DATE, startDate},
    {FIELD_END_DATE, endDate},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), shareInviteMonetaryAccountInquiryId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// [DEPRECATED - use /share-invite-monetary-account-response] Get a list with all the share inquiries for a
        /// monetary account, only if the requesting user has permission to change the details of the various ones.
        /// </summary>
        public static BunqResponse<List<ShareInviteMonetaryAccountInquiry>> List(int? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);
    
            return FromJsonList<ShareInviteMonetaryAccountInquiry>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Alias != null)
            {
                return false;
            }
    
            if (this.UserAliasCreated != null)
            {
                return false;
            }
    
            if (this.UserAliasRevoked != null)
            {
                return false;
            }
    
            if (this.CounterUserAlias != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.AccessType != null)
            {
                return false;
            }
    
            if (this.Relationship != null)
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
        public static ShareInviteMonetaryAccountInquiry CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ShareInviteMonetaryAccountInquiry>(json);
        }
    }
}
