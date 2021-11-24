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
    public class ShareInviteMonetaryAccountResponse : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/share-invite-monetary-account-response/{1}";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/share-invite-monetary-account-response/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/share-invite-monetary-account-response";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";
        public const string FIELD_CARD_ID = "card_id";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "ShareInviteMonetaryAccountResponse";
    
        /// <summary>
        /// The status of the share. Can be PENDING, REVOKED (the user deletes the share inquiry before it's accepted),
        /// ACCEPTED, CANCELLED (the user deletes an active share) or CANCELLATION_PENDING, CANCELLATION_ACCEPTED,
        /// CANCELLATION_REJECTED (for canceling mutual connects)
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The card to link to the shared monetary account. Used only if share_detail is ShareDetailCardPayment.
        /// </summary>
        [JsonProperty(PropertyName = "card_id")]
        public int? CardId { get; set; }
    
        /// <summary>
        /// The id of the ShareInviteBankResponse.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        /// <summary>
        /// The timestamp of the ShareInviteBankResponse creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
    
        /// <summary>
        /// The timestamp of the ShareInviteBankResponse last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
    
        /// <summary>
        /// The monetary account and user who created the share.
        /// </summary>
        [JsonProperty(PropertyName = "counter_alias")]
        public MonetaryAccountReference CounterAlias { get; set; }
    
        /// <summary>
        /// The user who cancelled the share if it has been revoked or rejected.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_cancelled")]
        public MonetaryAccountReference UserAliasCancelled { get; set; }
    
        /// <summary>
        /// The id of the monetary account the ACCEPTED share applies to. null otherwise.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }
    
        /// <summary>
        /// The id of the draft share invite bank.
        /// </summary>
        [JsonProperty(PropertyName = "draft_share_invite_bank_id")]
        public int? DraftShareInviteBankId { get; set; }
    
        /// <summary>
        /// The share details.
        /// </summary>
        [JsonProperty(PropertyName = "share_detail")]
        public ShareDetail ShareDetail { get; set; }
    
        /// <summary>
        /// All of the relation users towards this MA.
        /// </summary>
        [JsonProperty(PropertyName = "relation_user")]
        public RelationUser RelationUser { get; set; }
    
        /// <summary>
        /// The share type, either STANDARD or MUTUAL.
        /// </summary>
        [JsonProperty(PropertyName = "share_type")]
        public string ShareType { get; set; }
    
        /// <summary>
        /// The start date of this share.
        /// </summary>
        [JsonProperty(PropertyName = "start_date")]
        public string StartDate { get; set; }
    
        /// <summary>
        /// The expiration date of this share.
        /// </summary>
        [JsonProperty(PropertyName = "end_date")]
        public string EndDate { get; set; }
    
        /// <summary>
        /// The description of this share. It is basically the monetary account description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    
    
        /// <summary>
        /// Return the details of a specific share a user was invited to.
        /// </summary>
        public static BunqResponse<ShareInviteMonetaryAccountResponse> Get(int shareInviteMonetaryAccountResponseId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), shareInviteMonetaryAccountResponseId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<ShareInviteMonetaryAccountResponse>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// Accept or reject a share a user was invited to.
        /// </summary>
        /// <param name="status">The status of the share. Can be PENDING, REVOKED (the user deletes the share inquiry before it's accepted), ACCEPTED, CANCELLED (the user deletes an active share) or CANCELLATION_PENDING, CANCELLATION_ACCEPTED, CANCELLATION_REJECTED (for canceling mutual connects)</param>
        /// <param name="cardId">The card to link to the shared monetary account. Used only if share_detail is ShareDetailCardPayment.</param>
        public static BunqResponse<int> Update(int shareInviteMonetaryAccountResponseId, string status = null, int? cardId = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
    
            var requestMap = new Dictionary<string, object>
    {
    {FIELD_STATUS, status},
    {FIELD_CARD_ID, cardId},
    };
    
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), shareInviteMonetaryAccountResponseId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Return all the shares a user was invited to.
        /// </summary>
        public static BunqResponse<List<ShareInviteMonetaryAccountResponse>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<ShareInviteMonetaryAccountResponse>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            if (this.Created != null)
            {
                return false;
            }
    
            if (this.Updated != null)
            {
                return false;
            }
    
            if (this.CounterAlias != null)
            {
                return false;
            }
    
            if (this.UserAliasCancelled != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.DraftShareInviteBankId != null)
            {
                return false;
            }
    
            if (this.ShareDetail != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.RelationUser != null)
            {
                return false;
            }
    
            if (this.ShareType != null)
            {
                return false;
            }
    
            if (this.StartDate != null)
            {
                return false;
            }
    
            if (this.EndDate != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static ShareInviteMonetaryAccountResponse CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ShareInviteMonetaryAccountResponse>(json);
        }
    }
}
