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
    /// With UserCompany you can retrieve information regarding the authenticated UserCompany and update specific
    /// fields.<br/><br/>Notification filters can be set on a UserCompany level to receive callbacks. For more
    /// information check the <a href="/api/1/page/callbacks">dedicated callbacks page</a>.
    /// </summary>
    public class UserCompany : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user-company/{0}";

        protected const string ENDPOINT_URL_UPDATE = "user-company/{0}";

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
        public const string FIELD_LEGAL_FORM = "legal_form";
        public const string FIELD_STATUS = "status";
        public const string FIELD_SUB_STATUS = "sub_status";
        public const string FIELD_SESSION_TIMEOUT = "session_timeout";
        public const string FIELD_DAILY_LIMIT_WITHOUT_CONFIRMATION_LOGIN = "daily_limit_without_confirmation_login";
        public const string FIELD_NOTIFICATION_FILTERS = "notification_filters";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "UserCompany";

        /// <summary>
        /// The company name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The company's public nick name.
        /// </summary>
        [JsonProperty(PropertyName = "public_nick_name")]
        public string PublicNickName { get; set; }

        /// <summary>
        /// The public UUID of the company's avatar.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_uuid")]
        public string AvatarUuid { get; set; }

        /// <summary>
        /// The company's main address.
        /// </summary>
        [JsonProperty(PropertyName = "address_main")]
        public Address AddressMain { get; set; }

        /// <summary>
        /// The company's postal address.
        /// </summary>
        [JsonProperty(PropertyName = "address_postal")]
        public Address AddressPostal { get; set; }

        /// <summary>
        /// The person's preferred language. Formatted as a ISO 639-1 language code plus a ISO 3166-1 alpha-2 country
        /// code, seperated by an underscore.
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        /// <summary>
        /// The person's preferred region. Formatted as a ISO 639-1 language code plus a ISO 3166-1 alpha-2 country
        /// code, seperated by an underscore.
        /// </summary>
        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        /// <summary>
        /// The country as an ISO 3166-1 alpha-2 country code..
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// The names of the company's ultimate beneficiary owners. Minimum zero, maximum four.
        /// </summary>
        [JsonProperty(PropertyName = "ubo")]
        public List<Ubo> Ubo { get; set; }

        /// <summary>
        /// The company's chamber of commerce number.
        /// </summary>
        [JsonProperty(PropertyName = "chamber_of_commerce_number")]
        public string ChamberOfCommerceNumber { get; set; }

        /// <summary>
        /// The company's legal form.
        /// </summary>
        [JsonProperty(PropertyName = "legal_form")]
        public string LegalForm { get; set; }

        /// <summary>
        /// The user status. Can be: ACTIVE, SIGNUP, RECOVERY.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The user sub-status. Can be: NONE, FACE_RESET, APPROVAL, APPROVAL_DIRECTOR, APPROVAL_PARENT,
        /// APPROVAL_SUPPORT, COUNTER_IBAN, IDEAL or SUBMIT.
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; set; }

        /// <summary>
        /// The setting for the session timeout of the company in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "session_timeout")]
        public int? SessionTimeout { get; set; }

        /// <summary>
        /// The amount the company can pay in the session without asking for credentials.
        /// </summary>
        [JsonProperty(PropertyName = "daily_limit_without_confirmation_login")]
        public Amount DailyLimitWithoutConfirmationLogin { get; set; }

        /// <summary>
        /// The types of notifications that will result in a push notification or URL callback for this UserCompany.
        /// </summary>
        [JsonProperty(PropertyName = "notification_filters")]
        public List<NotificationFilter> NotificationFilters { get; set; }

        /// <summary>
        /// The id of the modified company.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the company object's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the company object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The company's public UUID.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; set; }

        /// <summary>
        /// The company's display name.
        /// </summary>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The aliases of the account.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public List<Pointer> Alias { get; set; }

        /// <summary>
        /// The type of business entity.
        /// </summary>
        [JsonProperty(PropertyName = "type_of_business_entity")]
        public string TypeOfBusinessEntity { get; set; }

        /// <summary>
        /// The sector of industry.
        /// </summary>
        [JsonProperty(PropertyName = "sector_of_industry")]
        public string SectorOfIndustry { get; set; }

        /// <summary>
        /// The company's other bank account IBAN, through which we verify it.
        /// </summary>
        [JsonProperty(PropertyName = "counter_bank_iban")]
        public string CounterBankIban { get; set; }

        /// <summary>
        /// The company's avatar.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public Avatar Avatar { get; set; }

        /// <summary>
        /// The version of the terms of service accepted by the user.
        /// </summary>
        [JsonProperty(PropertyName = "version_terms_of_service")]
        public string VersionTermsOfService { get; set; }

        /// <summary>
        /// The existing bunq user alias for the company's director.
        /// </summary>
        [JsonProperty(PropertyName = "director_alias")]
        public LabelUser DirectorAlias { get; set; }

        /// <summary>
        /// The customer profile of the company.
        /// </summary>
        [JsonProperty(PropertyName = "customer")]
        public Customer Customer { get; set; }

        /// <summary>
        /// The customer limits of the company.
        /// </summary>
        [JsonProperty(PropertyName = "customer_limit")]
        public CustomerLimit CustomerLimit { get; set; }

        /// <summary>
        /// The subscription of the company.
        /// </summary>
        [JsonProperty(PropertyName = "billing_contract")]
        public List<BillingContractSubscription> BillingContract { get; set; }


        /// <summary>
        /// Get a specific company.
        /// </summary>
        public static BunqResponse<UserCompany> Get(IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId()),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<UserCompany>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Modify a specific company's data.
        /// </summary>
        /// <param name="name">The company name.</param>
        /// <param name="publicNickName">The company's nick name.</param>
        /// <param name="avatarUuid">The public UUID of the company's avatar.</param>
        /// <param name="addressMain">The user's main address.</param>
        /// <param name="addressPostal">The company's postal address.</param>
        /// <param name="language">The person's preferred language. Formatted as a ISO 639-1 language code plus a ISO 3166-1 alpha-2 country code, seperated by an underscore.</param>
        /// <param name="region">The person's preferred region. Formatted as a ISO 639-1 language code plus a ISO 3166-1 alpha-2 country code, seperated by an underscore.</param>
        /// <param name="country">The country where the company is registered.</param>
        /// <param name="ubo">The names and birth dates of the company's ultimate beneficiary owners. Minimum zero, maximum four.</param>
        /// <param name="chamberOfCommerceNumber">The company's chamber of commerce number.</param>
        /// <param name="legalForm">The company's legal form.</param>
        /// <param name="status">The user status. Can be: ACTIVE, SIGNUP, RECOVERY.</param>
        /// <param name="subStatus">The user sub-status. Can be: NONE, FACE_RESET, APPROVAL, APPROVAL_DIRECTOR, APPROVAL_PARENT, APPROVAL_SUPPORT, COUNTER_IBAN, IDEAL or SUBMIT.</param>
        /// <param name="sessionTimeout">The setting for the session timeout of the company in seconds.</param>
        /// <param name="dailyLimitWithoutConfirmationLogin">The amount the company can pay in the session without asking for credentials.</param>
        /// <param name="notificationFilters">The types of notifications that will result in a push notification or URL callback for this UserCompany.</param>
        public static BunqResponse<int> Update(string name = null, string publicNickName = null,
            string avatarUuid = null, Address addressMain = null, Address addressPostal = null, string language = null,
            string region = null, string country = null, List<Ubo> ubo = null, string chamberOfCommerceNumber = null,
            string legalForm = null, string status = null, string subStatus = null, int? sessionTimeout = null,
            Amount dailyLimitWithoutConfirmationLogin = null, List<NotificationFilter> notificationFilters = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_NAME, name},
                {FIELD_PUBLIC_NICK_NAME, publicNickName},
                {FIELD_AVATAR_UUID, avatarUuid},
                {FIELD_ADDRESS_MAIN, addressMain},
                {FIELD_ADDRESS_POSTAL, addressPostal},
                {FIELD_LANGUAGE, language},
                {FIELD_REGION, region},
                {FIELD_COUNTRY, country},
                {FIELD_UBO, ubo},
                {FIELD_CHAMBER_OF_COMMERCE_NUMBER, chamberOfCommerceNumber},
                {FIELD_LEGAL_FORM, legalForm},
                {FIELD_STATUS, status},
                {FIELD_SUB_STATUS, subStatus},
                {FIELD_SESSION_TIMEOUT, sessionTimeout},
                {FIELD_DAILY_LIMIT_WITHOUT_CONFIRMATION_LOGIN, dailyLimitWithoutConfirmationLogin},
                {FIELD_NOTIFICATION_FILTERS, notificationFilters},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId()), requestBytes,
                customHeaders);

            return ProcessForId(responseRaw);
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

            if (this.PublicUuid != null)
            {
                return false;
            }

            if (this.Name != null)
            {
                return false;
            }

            if (this.DisplayName != null)
            {
                return false;
            }

            if (this.PublicNickName != null)
            {
                return false;
            }

            if (this.Alias != null)
            {
                return false;
            }

            if (this.ChamberOfCommerceNumber != null)
            {
                return false;
            }

            if (this.LegalForm != null)
            {
                return false;
            }

            if (this.TypeOfBusinessEntity != null)
            {
                return false;
            }

            if (this.SectorOfIndustry != null)
            {
                return false;
            }

            if (this.CounterBankIban != null)
            {
                return false;
            }

            if (this.Avatar != null)
            {
                return false;
            }

            if (this.AddressMain != null)
            {
                return false;
            }

            if (this.AddressPostal != null)
            {
                return false;
            }

            if (this.VersionTermsOfService != null)
            {
                return false;
            }

            if (this.DirectorAlias != null)
            {
                return false;
            }

            if (this.Language != null)
            {
                return false;
            }

            if (this.Country != null)
            {
                return false;
            }

            if (this.Region != null)
            {
                return false;
            }

            if (this.Ubo != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.SubStatus != null)
            {
                return false;
            }

            if (this.SessionTimeout != null)
            {
                return false;
            }

            if (this.DailyLimitWithoutConfirmationLogin != null)
            {
                return false;
            }

            if (this.NotificationFilters != null)
            {
                return false;
            }

            if (this.Customer != null)
            {
                return false;
            }

            if (this.CustomerLimit != null)
            {
                return false;
            }

            if (this.BillingContract != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static UserCompany CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<UserCompany>(json);
        }
    }
}