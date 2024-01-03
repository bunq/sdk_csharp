using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to manage Slice group payment.
    /// </summary>
    public class RegistryEntry : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_ID = "id";
        public const string FIELD_UUID = "uuid";
        public const string FIELD_UPDATED = "updated";
        public const string FIELD_STATUS = "status";
        public const string FIELD_MEMBERSHIP_UUID_OWNER = "membership_uuid_owner";
        public const string FIELD_MEMBERSHIP_TRICOUNT_ID_OWNER = "membership_tricount_id_owner";
        public const string FIELD_ALIAS_OWNER = "alias_owner";
        public const string FIELD_AMOUNT = "amount";
        public const string FIELD_AMOUNT_LOCAL = "amount_local";
        public const string FIELD_EXCHANGE_RATE = "exchange_rate";
        public const string FIELD_OBJECT_REFERENCE = "object_reference";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_ALLOCATIONS = "allocations";
        public const string FIELD_ATTACHMENT = "attachment";
        public const string FIELD_CATEGORY = "category";
        public const string FIELD_CATEGORY_CUSTOM = "category_custom";
        public const string FIELD_DATE = "date";
        public const string FIELD_TYPE_TRANSACTION = "type_transaction";
        public const string FIELD_TRICOUNT_ID = "tricount_id";
    
    
        /// <summary>
        /// The id of the RegistryEntry.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
        /// <summary>
        /// The uuid of the RegistryEntry. If it was provided by the client on creation, then the client can use it to
        /// match the returned RegistryEntry to the row stored locally.
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }
        /// <summary>
        /// The timestamp of the RegistryEntry's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
        /// <summary>
        /// The status of the RegistryEntry.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The UUID of the RegistryMembership of the party we are allocating money for. Can be provided instead of the
        /// "alias_owner" field.
        /// </summary>
        [JsonProperty(PropertyName = "membership_uuid_owner")]
        public string MembershipUuidOwner { get; set; }
        /// <summary>
        /// The original tricount id of the membership for backwards compatibility, to ensure clients are able to sync
        /// updates to transactions made offline before the Tricount migration to the bunq backend.
        /// </summary>
        [JsonProperty(PropertyName = "membership_tricount_id_owner")]
        public int? MembershipTricountIdOwner { get; set; }
        /// <summary>
        /// The Alias of the party we are allocating money for.
        /// </summary>
        [JsonProperty(PropertyName = "alias_owner")]
        public MonetaryAccountReference AliasOwner { get; set; }
        /// <summary>
        /// The Amount of the RegistryEntry.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
        /// <summary>
        /// The Amount of the RegistryEntry in a local currency.
        /// </summary>
        [JsonProperty(PropertyName = "amount_local")]
        public Amount AmountLocal { get; set; }
        /// <summary>
        /// The exchange rate used to convert between amount and amount_local.
        /// </summary>
        [JsonProperty(PropertyName = "exchange_rate")]
        public string ExchangeRate { get; set; }
        /// <summary>
        /// The object linked to the RegistryEntry.
        /// </summary>
        [JsonProperty(PropertyName = "object_reference")]
        public RegistryEntryReference ObjectReference { get; set; }
        /// <summary>
        /// A description about the RegistryEntry.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// An array of AllocationItems.
        /// </summary>
        [JsonProperty(PropertyName = "allocations")]
        public List<AllocationItem> Allocations { get; set; }
        /// <summary>
        /// The attachments attached to the payment.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<RegistryEntryAttachment> Attachment { get; set; }
        /// <summary>
        /// The category of this RegistryEntry. Supported values: UNCATEGORIZED, OTHER, ACCOMODATION, ENTERTAINMENT,
        /// GROCERIES, HEALTHCARE, INSURANCE, RENT, RESTAURANTS, SHOPPING, TRANSPORT
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
        /// <summary>
        /// A custom user-provided category description for this RegistryEntry. Only allowed if `category` is set to
        /// "OTHER".
        /// </summary>
        [JsonProperty(PropertyName = "category_custom")]
        public string CategoryCustom { get; set; }
        /// <summary>
        /// A user provided date for this RegistryEntry. Returns a full timestamp to allow apps to also use this to sort
        /// transactions client-side.
        /// </summary>
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        /// <summary>
        /// The RegistryEntry transaction type. NORMAL, INCOME, or BALANCE.
        /// </summary>
        [JsonProperty(PropertyName = "type_transaction")]
        public string TypeTransaction { get; set; }
        /// <summary>
        /// The original tricount id for backwards compatibility, to ensure clients are able to sync updates to
        /// transactions made offline before the Tricount migration to the bunq backend.
        /// </summary>
        [JsonProperty(PropertyName = "tricount_id")]
        public int? TricountId { get; set; }
        /// <summary>
        /// The timestamp of the RegistryEntry's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
        /// <summary>
        /// The id of the Registry.
        /// </summary>
        [JsonProperty(PropertyName = "registry_id")]
        public int? RegistryId { get; set; }
        /// <summary>
        /// The RegistryEntry type. AUTO if created by Auto Slice, MANUAL for manually added entries.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        /// <summary>
        /// The LabelUser with the public information of the party of this RegistryEntry.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
        /// <summary>
        /// The LabelUser with the public information of the counter party of this RegistryEntry.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
        /// <summary>
        /// The LabelUser with the public information of the User that created the RegistryEntry.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_created")]
        public MonetaryAccountReference UserAliasCreated { get; set; }
        /// <summary>
        /// The membership of the creator.
        /// </summary>
        [JsonProperty(PropertyName = "membership_created")]
        public RegistryMembership MembershipCreated { get; set; }
        /// <summary>
        /// The membership of the owner.
        /// </summary>
        [JsonProperty(PropertyName = "membership_owned")]
        public RegistryMembership MembershipOwned { get; set; }
    
    
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
    
            if (this.Created != null)
            {
                return false;
            }
    
            if (this.Updated != null)
            {
                return false;
            }
    
            if (this.RegistryId != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.Amount != null)
            {
                return false;
            }
    
            if (this.AmountLocal != null)
            {
                return false;
            }
    
            if (this.ExchangeRate != null)
            {
                return false;
            }
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.TypeTransaction != null)
            {
                return false;
            }
    
            if (this.Alias != null)
            {
                return false;
            }
    
            if (this.CounterpartyAlias != null)
            {
                return false;
            }
    
            if (this.UserAliasCreated != null)
            {
                return false;
            }
    
            if (this.MembershipCreated != null)
            {
                return false;
            }
    
            if (this.MembershipOwned != null)
            {
                return false;
            }
    
            if (this.Allocations != null)
            {
                return false;
            }
    
            if (this.Attachment != null)
            {
                return false;
            }
    
            if (this.Category != null)
            {
                return false;
            }
    
            if (this.CategoryCustom != null)
            {
                return false;
            }
    
            if (this.Date != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static RegistryEntry CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<RegistryEntry>(json);
        }
    }
}
