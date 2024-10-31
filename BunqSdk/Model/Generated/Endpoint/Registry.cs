using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to manage Slice groups.
    /// </summary>
    public class Registry : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_UPDATED = "updated";
        public const string FIELD_UUID = "uuid";
        public const string FIELD_PUBLIC_IDENTIFIER_TOKEN = "public_identifier_token";
        public const string FIELD_CURRENCY = "currency";
        public const string FIELD_TITLE = "title";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_CATEGORY = "category";
        public const string FIELD_STATUS = "status";
        public const string FIELD_LAST_REGISTRY_ENTRY_SEEN_ID = "last_registry_entry_seen_id";
        public const string FIELD_PREVIOUS_UPDATED_TIMESTAMP = "previous_updated_timestamp";
        public const string FIELD_MEMBERSHIP_UUID_ACTIVE = "membership_uuid_active";
        public const string FIELD_MEMBERSHIPS = "memberships";
        public const string FIELD_MEMBERSHIPS_PREVIOUS = "memberships_previous";
        public const string FIELD_DELETED_MEMBERSHIP_IDS = "deleted_membership_ids";
        public const string FIELD_AUTO_ADD_CARD_TRANSACTION = "auto_add_card_transaction";
        public const string FIELD_MEMBERSHIP_SETTING = "membership_setting";
        public const string FIELD_AVATAR_UUID = "avatar_uuid";
        public const string FIELD_SETTING = "setting";
        public const string FIELD_ALL_REGISTRY_ENTRY = "all_registry_entry";
        public const string FIELD_ALIAS_CREATOR = "alias_creator";
    
    
        /// <summary>
        /// The timestamp of the Registry's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
        /// <summary>
        /// The uuid of the Registry. If it was provided by the client on creation, then the client can use it to match
        /// the returned Registry to the row stored locally.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }
        /// <summary>
        /// Public identifier token provided by the client. Will remain null if not provided in the POST call.
        /// </summary>
        [JsonProperty(PropertyName = "public_identifier_token")]
        public string PublicIdentifierToken { get; set; }
        /// <summary>
        /// The currency for the Registry as an ISO 4217 formatted currency code.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
        /// <summary>
        /// The title of the Registry.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        /// <summary>
        /// A description about the Registry.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// The category of the Registry. Can be one of the following values: GENERAL, TRIP, SHARED_HOUSE, COUPLE,
        /// EVENT, PROJECT, OTHER
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
        /// <summary>
        /// The status of the Registry.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The id of the last RegistryEntry that the user has seen.
        /// </summary>
        [JsonProperty(PropertyName = "last_registry_entry_seen_id")]
        public int? LastRegistryEntrySeenId { get; set; }
        /// <summary>
        /// The previous updated timestamp that you received for this Registry.
        /// </summary>
        [JsonProperty(PropertyName = "previous_updated_timestamp")]
        public string PreviousUpdatedTimestamp { get; set; }
        /// <summary>
        /// The UUID of the membership which is currently linked to the logged in user.
        /// </summary>
        [JsonProperty(PropertyName = "membership_uuid_active")]
        public string MembershipUuidActive { get; set; }
        /// <summary>
        /// List of memberships to replace the current one.
        /// </summary>
        [JsonProperty(PropertyName = "memberships")]
        public List<RegistryMembership> Memberships { get; set; }
        /// <summary>
        /// Previous list of memberships.
        /// </summary>
        [JsonProperty(PropertyName = "memberships_previous")]
        public List<RegistryMembership> MembershipsPrevious { get; set; }
        /// <summary>
        /// The ids of the memberships that have been deleted.
        /// </summary>
        [JsonProperty(PropertyName = "deleted_membership_ids")]
        public List<string> DeletedMembershipIds { get; set; }
        /// <summary>
        /// The setting for adding automatically card transactions to the registry for the creator. (deprecated)
        /// </summary>
        [JsonProperty(PropertyName = "auto_add_card_transaction")]
        public string AutoAddCardTransaction { get; set; }
        /// <summary>
        /// User creator registry membership setting.
        /// </summary>
        [JsonProperty(PropertyName = "membership_setting")]
        public RegistryMembershipSetting MembershipSetting { get; set; }
        /// <summary>
        /// The UUID of the avatar. Use the calls /attachment-public and /avatar to create a new Avatar and get its
        /// UUID.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_uuid")]
        public string AvatarUuid { get; set; }
        /// <summary>
        /// The settings for this Registry.
        /// </summary>
        [JsonProperty(PropertyName = "setting")]
        public RegistrySetting Setting { get; set; }
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "all_registry_entry")]
        public List<RegistryEntry> AllRegistryEntry { get; set; }
        /// <summary>
        /// The alias of the creator, so we can send a confirmation even when the creator doesn't yet have an alias
        /// saved for their user.
        /// </summary>
        [JsonProperty(PropertyName = "alias_creator")]
        public MonetaryAccountReference AliasCreator { get; set; }
        /// <summary>
        /// The id of the Registry.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
        /// <summary>
        /// The timestamp of the Registry's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
        /// <summary>
        /// The total amount spent in this Registry since the last settlement.
        /// </summary>
        [JsonProperty(PropertyName = "total_amount_spent")]
        public Amount TotalAmountSpent { get; set; }
        /// <summary>
        /// Whether the Registry has previously been settled.
        /// </summary>
        [JsonProperty(PropertyName = "is_previously_settled")]
        public bool? IsPreviouslySettled { get; set; }
        /// <summary>
        /// The registry's avatar.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public Avatar Avatar { get; set; }
        /// <summary>
        /// The optional ID of the last settlement of this activity.
        /// </summary>
        [JsonProperty(PropertyName = "last_settlement_id")]
        public int? LastSettlementId { get; set; }
        /// <summary>
        /// The timestamp of the latest activity seen for this registry.
        /// </summary>
        [JsonProperty(PropertyName = "last_activity_timestamp")]
        public string LastActivityTimestamp { get; set; }
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "all_registry_gallery_attachment")]
        public List<RegistryGalleryAttachment> AllRegistryGalleryAttachment { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            if (this.Uuid != null)
            {
                return false;
            }
    
            if (this.PublicIdentifierToken != null)
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
    
            if (this.Currency != null)
            {
                return false;
            }
    
            if (this.Title != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.Category != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.TotalAmountSpent != null)
            {
                return false;
            }
    
            if (this.IsPreviouslySettled != null)
            {
                return false;
            }
    
            if (this.MembershipUuidActive != null)
            {
                return false;
            }
    
            if (this.Memberships != null)
            {
                return false;
            }
    
            if (this.Setting != null)
            {
                return false;
            }
    
            if (this.Avatar != null)
            {
                return false;
            }
    
            if (this.LastSettlementId != null)
            {
                return false;
            }
    
            if (this.LastActivityTimestamp != null)
            {
                return false;
            }
    
            if (this.AllRegistryEntry != null)
            {
                return false;
            }
    
            if (this.AllRegistryGalleryAttachment != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static Registry CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Registry>(json);
        }
    }
}
