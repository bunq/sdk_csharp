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
    /// bunq.me public profile of the user.
    /// </summary>
    public class BunqMeFundraiserProfileUser : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/bunqme-fundraiser-profile/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/bunqme-fundraiser-profile";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_MONETARY_ACCOUNT_ID = "monetary_account_id";
        public const string FIELD_COLOR = "color";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_ATTACHMENT_PUBLIC_UUID = "attachment_public_uuid";
        public const string FIELD_POINTER = "pointer";
        public const string FIELD_REDIRECT_URL = "redirect_url";
        public const string FIELD_STATUS = "status";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "BunqMeFundraiserProfileModel";
    
        /// <summary>
        /// Id of the monetary account on which you want to receive bunq.me payments.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }
    
        /// <summary>
        /// The color chosen for the bunq.me fundraiser profile in hexadecimal format.
        /// </summary>
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }
    
        /// <summary>
        /// The description of the bunq.me fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    
        /// <summary>
        /// The public UUID of the public attachment from which an avatar image must be created.
        /// </summary>
        [JsonProperty(PropertyName = "attachment_public_uuid")]
        public string AttachmentPublicUuid { get; set; }
    
        /// <summary>
        /// The pointer (url) which will be used to access the bunq.me fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "pointer")]
        public MonetaryAccountReference Pointer { get; set; }
    
        /// <summary>
        /// The URL which the user is sent to when a payment is completed.
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }
    
        /// <summary>
        /// The status of the bunq.me fundraiser profile, can be ACTIVE or DEACTIVATED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// Id of the user owning the profile.
        /// </summary>
        [JsonProperty(PropertyName = "owner_user_id")]
        public int? OwnerUserId { get; set; }
    
        /// <summary>
        /// The LabelMonetaryAccount with the public information of the User and the MonetaryAccount that created the
        /// bunq.me fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
    
        /// <summary>
        /// The currency of the MonetaryAccount that created the bunq.me fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
    
        /// <summary>
        /// The attachment used for the background of the bunq.me fundraiser profile.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public AttachmentPublic Attachment { get; set; }
    
    
        /// <summary>
        /// </summary>
        public static BunqResponse<BunqMeFundraiserProfileUser> Get(int bunqMeFundraiserProfileUserId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), bunqMeFundraiserProfileUserId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<BunqMeFundraiserProfileUser>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<BunqMeFundraiserProfileUser>> List( IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams, customHeaders);
    
            return FromJsonList<BunqMeFundraiserProfileUser>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.MonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.OwnerUserId != null)
            {
                return false;
            }
    
            if (this.Color != null)
            {
                return false;
            }
    
            if (this.Alias != null)
            {
                return false;
            }
    
            if (this.Currency != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.Attachment != null)
            {
                return false;
            }
    
            if (this.Pointer != null)
            {
                return false;
            }
    
            if (this.RedirectUrl != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static BunqMeFundraiserProfileUser CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BunqMeFundraiserProfileUser>(json);
        }
    }
}
