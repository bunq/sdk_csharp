using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Show the authenticated user, if it is a company.
    /// </summary>
    public class UserCompany : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_NAME = "name";
        public const string FIELD_PUBLIC_NICK_NAME = "public_nick_name";
        public const string FIELD_AVATAR_UUID = "avatar_uuid";
        public const string FIELD_ADDRESS_MAIN = "address_main";
        public const string FIELD_ADDRESS_POSTAL = "address_postal";
        public const string FIELD_LANGUAGE = "language";
        public const string FIELD_REGION = "region";
        public const string FIELD_COUNTRY = "country";
        public const string FIELD_UBO = "ubo";
        public const string FIELD_CHAMBER_OF_COMMERCE_NUMBER = "chamber_of_commerce_number";
        public const string FIELD_STATUS = "status";
        public const string FIELD_SUB_STATUS = "sub_status";
        public const string FIELD_SESSION_TIMEOUT = "session_timeout";
        public const string FIELD_DAILY_LIMIT_WITHOUT_CONFIRMATION_LOGIN = "daily_limit_without_confirmation_login";
        public const string FIELD_COUNTER_BANK_IBAN = "counter_bank_iban";
        public const string FIELD_NOTIFICATION_FILTERS = "notification_filters";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "user-company/{0}";
        private const string ENDPOINT_URL_UPDATE = "user-company/{0}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "UserCompany";

        /// <summary>
        /// The id of the modified company.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }

        /// <summary>
        /// The timestamp of the company object's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }

        /// <summary>
        /// The timestamp of the company object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }

        /// <summary>
        /// The company's public UUID.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; private set; }

        /// <summary>
        /// The company name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// The company's display name.
        /// </summary>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; private set; }

        /// <summary>
        /// The company's public nick name.
        /// </summary>
        [JsonProperty(PropertyName = "public_nick_name")]
        public string PublicNickName { get; private set; }

        /// <summary>
        /// The aliases of the account.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public List<Pointer> Alias { get; private set; }

        /// <summary>
        /// The company's chamber of commerce number.
        /// </summary>
        [JsonProperty(PropertyName = "chamber_of_commerce_number")]
        public string ChamberOfCommerceNumber { get; private set; }

        /// <summary>
        /// The type of business entity.
        /// </summary>
        [JsonProperty(PropertyName = "type_of_business_entity")]
        public string TypeOfBusinessEntity { get; private set; }

        /// <summary>
        /// The sector of industry.
        /// </summary>
        [JsonProperty(PropertyName = "sector_of_industry")]
        public string SectorOfIndustry { get; private set; }

        /// <summary>
        /// The company's other bank account IBAN, through which we verify it.
        /// </summary>
        [JsonProperty(PropertyName = "counter_bank_iban")]
        public string CounterBankIban { get; private set; }

        /// <summary>
        /// The company's avatar.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public Avatar Avatar { get; private set; }

        /// <summary>
        /// The company's main address.
        /// </summary>
        [JsonProperty(PropertyName = "address_main")]
        public Address AddressMain { get; private set; }

        /// <summary>
        /// The company's postal address.
        /// </summary>
        [JsonProperty(PropertyName = "address_postal")]
        public Address AddressPostal { get; private set; }

        /// <summary>
        /// The version of the terms of service accepted by the user.
        /// </summary>
        [JsonProperty(PropertyName = "version_terms_of_service")]
        public string VersionTermsOfService { get; private set; }

        /// <summary>
        /// The existing bunq user alias for the company's director.
        /// </summary>
        [JsonProperty(PropertyName = "director_alias")]
        public LabelUser DirectorAlias { get; private set; }

        /// <summary>
        /// The person's preferred language. Formatted as a ISO 639-1 language code plus a ISO 3166-1 alpha-2 country
        /// code, seperated by an underscore.
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public string Language { get; private set; }

        /// <summary>
        /// The country as an ISO 3166-1 alpha-2 country code..
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; private set; }

        /// <summary>
        /// The person's preferred region. Formatted as a ISO 639-1 language code plus a ISO 3166-1 alpha-2 country
        /// code, seperated by an underscore.
        /// </summary>
        [JsonProperty(PropertyName = "region")]
        public string Region { get; private set; }

        /// <summary>
        /// The names of the company's ultimate beneficiary owners. Minimum zero, maximum four.
        /// </summary>
        [JsonProperty(PropertyName = "ubo")]
        public List<Ubo> Ubo { get; private set; }

        /// <summary>
        /// The user status. Can be: ACTIVE, SIGNUP, RECOVERY.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }

        /// <summary>
        /// The user sub-status. Can be: NONE, FACE_RESET, APPROVAL, APPROVAL_DIRECTOR, APPROVAL_PARENT,
        /// APPROVAL_SUPPORT, COUNTER_IBAN, IDEAL or SUBMIT.
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; private set; }

        /// <summary>
        /// The setting for the session timeout of the company in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "session_timeout")]
        public int? SessionTimeout { get; private set; }

        /// <summary>
        /// The amount the company can pay in the session without asking for credentials.
        /// </summary>
        [JsonProperty(PropertyName = "daily_limit_without_confirmation_login")]
        public Amount DailyLimitWithoutConfirmationLogin { get; private set; }

        /// <summary>
        /// The types of notifications that will result in a push notification or URL callback for this UserCompany.
        /// </summary>
        [JsonProperty(PropertyName = "notification_filters")]
        public List<NotificationFilter> NotificationFilters { get; private set; }

        /// <summary>
        /// The customer profile of the company.
        /// </summary>
        [JsonProperty(PropertyName = "customer")]
        public Customer Customer { get; private set; }

        /// <summary>
        /// The customer limits of the company.
        /// </summary>
        [JsonProperty(PropertyName = "customer_limit")]
        public CustomerLimit CustomerLimit { get; private set; }

        /// <summary>
        /// The subscription of the company.
        /// </summary>
        [JsonProperty(PropertyName = "billing_contract")]
        public List<BillingContractSubscription> BillingContract { get; private set; }

        /// <summary>
        /// Get a specific company.
        /// </summary>
        public static BunqResponse<UserCompany> Get(ApiContext apiContext, int userCompanyId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userCompanyId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<UserCompany>(responseRaw, OBJECT_TYPE);
        }

        /// <summary>
        /// Modify a specific company's data.
        /// </summary>
        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap,
            int userCompanyId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userCompanyId), requestBytes,
                customHeaders);

            return ProcessForId(responseRaw);
        }
    }
}
