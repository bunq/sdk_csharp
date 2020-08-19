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
    /// Used to manage Slice group payment.
    /// </summary>
    public class RegistryEntry : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/registry/{1}/registry-entry";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/registry/{1}/registry-entry/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/registry/{1}/registry-entry";
        protected const string ENDPOINT_URL_READ = "user/{0}/registry/{1}/registry-entry/{2}";
        protected const string ENDPOINT_URL_DELETE = "user/{0}/registry/{1}/registry-entry/{2}";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_ALIAS_OWNER = "alias_owner";
        public const string FIELD_AMOUNT = "amount";
        public const string FIELD_OBJECT_REFERENCE = "object_reference";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_ALLOCATIONS = "allocations";
        public const string FIELD_ATTACHMENT = "attachment";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "RegistryEntry";

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
        /// The id of the RegistryEntry.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the MonetaryAccountBank's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the MonetaryAccountBank's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The id of the Registry.
        /// </summary>
        [JsonProperty(PropertyName = "registry_id")]
        public int? RegistryId { get; set; }

        /// <summary>
        /// The status of the RegistryEntry.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The RegistryEntry type. AUTO if created by Auto Slice, MANUAL for manually added entries.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The LabelUser with the public information of the party of this RegistryEntry.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public LabelUser Alias { get; set; }

        /// <summary>
        /// The LabelUser with the public information of the counter party of this RegistryEntry.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public LabelUser CounterpartyAlias { get; set; }

        /// <summary>
        /// The LabelUser with the public information of the User that created the RegistryEntry.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_created")]
        public LabelUser UserAliasCreated { get; set; }

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
        /// Create a new Slice group payment.
        /// </summary>
        /// <param name="amount">The Amount of the RegistryEntry.</param>
        /// <param name="allocations">An array of AllocationItems.</param>
        /// <param name="aliasOwner">The Alias of the party we are allocating money for.</param>
        /// <param name="objectReference">The object linked to the RegistryEntry.</param>
        /// <param name="description">A description about the RegistryEntry.</param>
        /// <param name="attachment">The attachments attached to the payment.</param>
        public static BunqResponse<int> Create(int registryId, Amount amount, List<AllocationItem> allocations,
            Pointer aliasOwner = null, RegistryEntryReference objectReference = null, string description = null,
            List<RegistryEntryAttachment> attachment = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_ALIAS_OWNER, aliasOwner},
                {FIELD_AMOUNT, amount},
                {FIELD_OBJECT_REFERENCE, objectReference},
                {FIELD_DESCRIPTION, description},
                {FIELD_ALLOCATIONS, allocations},
                {FIELD_ATTACHMENT, attachment},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), registryId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Update a specific Slice group payment.
        /// </summary>
        /// <param name="description">A description about the RegistryEntry.</param>
        /// <param name="allocations">An array of AllocationItems.</param>
        /// <param name="attachment">The attachments attached to the payment.</param>
        public static BunqResponse<int> Update(int registryId, int registryEntryId, string description = null,
            List<AllocationItem> allocations = null, List<RegistryEntryAttachment> attachment = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_DESCRIPTION, description},
                {FIELD_ALLOCATIONS, allocations},
                {FIELD_ATTACHMENT, attachment},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), registryId, registryEntryId),
                    requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Get a listing of all Slice group payments.
        /// </summary>
        public static BunqResponse<List<RegistryEntry>> List(int registryId,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), registryId),
                urlParams, customHeaders);

            return FromJsonList<RegistryEntry>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Get a specific Slice group payment.
        /// </summary>
        public static BunqResponse<RegistryEntry> Get(int registryId, int registryEntryId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), registryId, registryEntryId),
                    new Dictionary<string, string>(), customHeaders);

            return FromJson<RegistryEntry>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Delete a specific Slice group payment.
        /// </summary>
        public static BunqResponse<object> Delete(int registryId, int registryEntryId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, DetermineUserId(), registryId, registryEntryId),
                    customHeaders);

            return new BunqResponse<object>(null, responseRaw.Headers);
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

            if (this.Description != null)
            {
                return false;
            }

            if (this.Type != null)
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

            return true;
        }

        /// <summary>
        /// </summary>
        public static RegistryEntry CreateFromJsonString(string json)
        {
            return CreateFromJsonString<RegistryEntry>(json);
        }
    }
}