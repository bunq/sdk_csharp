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
    /// Used to manage Slice groups.
    /// </summary>
    public class Registry : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/registry";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/registry/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/registry";
        protected const string ENDPOINT_URL_READ = "user/{0}/registry/{1}";
        protected const string ENDPOINT_URL_DELETE = "user/{0}/registry/{1}";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_CURRENCY = "currency";
        public const string FIELD_TITLE = "title";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_STATUS = "status";
        public const string FIELD_LAST_REGISTRY_ENTRY_SEEN_ID = "last_registry_entry_seen_id";
        public const string FIELD_PREVIOUS_UPDATED_TIMESTAMP = "previous_updated_timestamp";
        public const string FIELD_MEMBERSHIPS = "memberships";
        public const string FIELD_MEMBERSHIPS_PREVIOUS = "memberships_previous";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "Registry";

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
        /// The timestamp of the Registry's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The number of RegistryEntries in this Registry that the user has not seen.
        /// </summary>
        [JsonProperty(PropertyName = "unseen_entries_count")]
        public int? UnseenEntriesCount { get; set; }

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
        /// The settings for this Registry.
        /// </summary>
        [JsonProperty(PropertyName = "setting")]
        public RegistrySetting Setting { get; set; }

        /// <summary>
        /// The ID of the registry that currently has auto_add_card_transaction set to ALL.
        /// </summary>
        [JsonProperty(PropertyName = "registry_auto_add_card_transaction_enabled_id")]
        public int? RegistryAutoAddCardTransactionEnabledId { get; set; }


        /// <summary>
        /// Create a new Slice group.
        /// </summary>
        /// <param name="currency">The currency for the Registry as an ISO 4217 formatted currency code.</param>
        /// <param name="title">The title of the Registry.</param>
        /// <param name="description">A description about the Registry.</param>
        /// <param name="status">The status of the Registry.</param>
        /// <param name="lastRegistryEntrySeenId">The id of the last RegistryEntry that the user has seen.</param>
        /// <param name="previousUpdatedTimestamp">The previous updated timestamp that you received for this Registry.</param>
        /// <param name="memberships">New list of memberships.</param>
        /// <param name="membershipsPrevious">Previous list of memberships.</param>
        public static BunqResponse<int> Create(string currency, string title = null, string description = null,
            string status = null, int? lastRegistryEntrySeenId = null, string previousUpdatedTimestamp = null,
            List<RegistryMembership> memberships = null, List<RegistryMembership> membershipsPrevious = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_CURRENCY, currency},
                {FIELD_TITLE, title},
                {FIELD_DESCRIPTION, description},
                {FIELD_STATUS, status},
                {FIELD_LAST_REGISTRY_ENTRY_SEEN_ID, lastRegistryEntrySeenId},
                {FIELD_PREVIOUS_UPDATED_TIMESTAMP, previousUpdatedTimestamp},
                {FIELD_MEMBERSHIPS, memberships},
                {FIELD_MEMBERSHIPS_PREVIOUS, membershipsPrevious},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes,
                customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Update a specific Slice group.
        /// </summary>
        /// <param name="title">The title of the Registry.</param>
        /// <param name="description">A description about the Registry.</param>
        /// <param name="status">The status of the Registry.</param>
        /// <param name="lastRegistryEntrySeenId">The id of the last RegistryEntry that the user has seen.</param>
        /// <param name="previousUpdatedTimestamp">The previous updated timestamp that you received for this Registry.</param>
        /// <param name="memberships">New list of memberships.</param>
        /// <param name="membershipsPrevious">Previous list of memberships.</param>
        public static BunqResponse<int> Update(int registryId, string title = null, string description = null,
            string status = null, int? lastRegistryEntrySeenId = null, string previousUpdatedTimestamp = null,
            List<RegistryMembership> memberships = null, List<RegistryMembership> membershipsPrevious = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_TITLE, title},
                {FIELD_DESCRIPTION, description},
                {FIELD_STATUS, status},
                {FIELD_LAST_REGISTRY_ENTRY_SEEN_ID, lastRegistryEntrySeenId},
                {FIELD_PREVIOUS_UPDATED_TIMESTAMP, previousUpdatedTimestamp},
                {FIELD_MEMBERSHIPS, memberships},
                {FIELD_MEMBERSHIPS_PREVIOUS, membershipsPrevious},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), registryId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Get a listing of all Slice groups.
        /// </summary>
        public static BunqResponse<List<Registry>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<Registry>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Get a specific Slice group.
        /// </summary>
        public static BunqResponse<Registry> Get(int registryId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), registryId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<Registry>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Delete a specific Slice group.
        /// </summary>
        public static BunqResponse<object> Delete(int registryId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, DetermineUserId(), registryId),
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

            if (this.Currency != null)
            {
                return false;
            }

            if (this.Title != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.UnseenEntriesCount != null)
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

            if (this.Memberships != null)
            {
                return false;
            }

            if (this.Setting != null)
            {
                return false;
            }

            if (this.RegistryAutoAddCardTransactionEnabledId != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static Registry CreateFromJsonString(string json)
        {
            return CreateFromJsonString<Registry>(json);
        }
    }
}