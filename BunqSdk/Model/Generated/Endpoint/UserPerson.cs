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
    /// With UserPerson you can retrieve information regarding the authenticated UserPerson and update specific
    /// fields.<br/><br/>Notification filters can be set on a UserPerson level to receive callbacks. For more
    /// information check the <a href="/api/1/page/callbacks">dedicated callbacks page</a>.
    /// </summary>
    public class UserPerson : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_READ = "user-person/{0}";
        private const string ENDPOINT_URL_UPDATE = "user-person/{0}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_FIRST_NAME = "first_name";
        public const string FIELD_MIDDLE_NAME = "middle_name";
        public const string FIELD_LAST_NAME = "last_name";
        public const string FIELD_PUBLIC_NICK_NAME = "public_nick_name";
        public const string FIELD_ADDRESS_MAIN = "address_main";
        public const string FIELD_ADDRESS_POSTAL = "address_postal";
        public const string FIELD_AVATAR_UUID = "avatar_uuid";
        public const string FIELD_TAX_RESIDENT = "tax_resident";
        public const string FIELD_DOCUMENT_TYPE = "document_type";
        public const string FIELD_DOCUMENT_NUMBER = "document_number";
        public const string FIELD_DOCUMENT_COUNTRY_OF_ISSUANCE = "document_country_of_issuance";
        public const string FIELD_DOCUMENT_FRONT_ATTACHMENT_ID = "document_front_attachment_id";
        public const string FIELD_DOCUMENT_BACK_ATTACHMENT_ID = "document_back_attachment_id";
        public const string FIELD_DATE_OF_BIRTH = "date_of_birth";
        public const string FIELD_PLACE_OF_BIRTH = "place_of_birth";
        public const string FIELD_COUNTRY_OF_BIRTH = "country_of_birth";
        public const string FIELD_NATIONALITY = "nationality";
        public const string FIELD_LANGUAGE = "language";
        public const string FIELD_REGION = "region";
        public const string FIELD_GENDER = "gender";
        public const string FIELD_STATUS = "status";
        public const string FIELD_SUB_STATUS = "sub_status";
        public const string FIELD_LEGAL_GUARDIAN_ALIAS = "legal_guardian_alias";
        public const string FIELD_SESSION_TIMEOUT = "session_timeout";
        public const string FIELD_DAILY_LIMIT_WITHOUT_CONFIRMATION_LOGIN = "daily_limit_without_confirmation_login";
        public const string FIELD_COUNTER_BANK_IBAN = "counter_bank_iban";
        public const string FIELD_NOTIFICATION_FILTERS = "notification_filters";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "UserPerson";
    
        /// <summary>
        /// The id of the modified person object.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp of the person object's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp of the person object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The person's public UUID.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; private set; }
    
        /// <summary>
        /// The person's first name.
        /// </summary>
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; private set; }
    
        /// <summary>
        /// The person's middle name.
        /// </summary>
        [JsonProperty(PropertyName = "middle_name")]
        public string MiddleName { get; private set; }
    
        /// <summary>
        /// The person's last name.
        /// </summary>
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; private set; }
    
        /// <summary>
        /// The person's legal name.
        /// </summary>
        [JsonProperty(PropertyName = "legal_name")]
        public string LegalName { get; private set; }
    
        /// <summary>
        /// The display name for the person.
        /// </summary>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; private set; }
    
        /// <summary>
        /// The public nick name for the person.
        /// </summary>
        [JsonProperty(PropertyName = "public_nick_name")]
        public string PublicNickName { get; private set; }
    
        /// <summary>
        /// The aliases of the user.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public List<Pointer> Alias { get; private set; }
    
        /// <summary>
        /// The user's tax residence numbers for different countries.
        /// </summary>
        [JsonProperty(PropertyName = "tax_resident")]
        public List<TaxResident> TaxResident { get; private set; }
    
        /// <summary>
        /// The type of identification document the person registered with.
        /// </summary>
        [JsonProperty(PropertyName = "document_type")]
        public string DocumentType { get; private set; }
    
        /// <summary>
        /// The identification document number the person registered with.
        /// </summary>
        [JsonProperty(PropertyName = "document_number")]
        public string DocumentNumber { get; private set; }
    
        /// <summary>
        /// The country which issued the identification document the person registered with.
        /// </summary>
        [JsonProperty(PropertyName = "document_country_of_issuance")]
        public string DocumentCountryOfIssuance { get; private set; }
    
        /// <summary>
        /// The person's main address.
        /// </summary>
        [JsonProperty(PropertyName = "address_main")]
        public Address AddressMain { get; private set; }
    
        /// <summary>
        /// The person's postal address.
        /// </summary>
        [JsonProperty(PropertyName = "address_postal")]
        public Address AddressPostal { get; private set; }
    
        /// <summary>
        /// The person's date of birth. Accepts ISO8601 date formats.
        /// </summary>
        [JsonProperty(PropertyName = "date_of_birth")]
        public string DateOfBirth { get; private set; }
    
        /// <summary>
        /// The person's place of birth.
        /// </summary>
        [JsonProperty(PropertyName = "place_of_birth")]
        public string PlaceOfBirth { get; private set; }
    
        /// <summary>
        /// The person's country of birth. Formatted as a SO 3166-1 alpha-2 country code.
        /// </summary>
        [JsonProperty(PropertyName = "country_of_birth")]
        public string CountryOfBirth { get; private set; }
    
        /// <summary>
        /// The person's nationality. Formatted as a SO 3166-1 alpha-2 country code.
        /// </summary>
        [JsonProperty(PropertyName = "nationality")]
        public string Nationality { get; private set; }
    
        /// <summary>
        /// The person's preferred language. Formatted as a ISO 639-1 language code plus a ISO 3166-1 alpha-2 country
        /// code, seperated by an underscore.
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public string Language { get; private set; }
    
        /// <summary>
        /// The person's preferred region. Formatted as a ISO 639-1 language code plus a ISO 3166-1 alpha-2 country
        /// code, seperated by an underscore.
        /// </summary>
        [JsonProperty(PropertyName = "region")]
        public string Region { get; private set; }
    
        /// <summary>
        /// The person's gender. Can be MALE, FEMALE or UNKNOWN.
        /// </summary>
        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; private set; }
    
        /// <summary>
        /// The user's avatar.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public Avatar Avatar { get; private set; }
    
        /// <summary>
        /// The version of the terms of service accepted by the user.
        /// </summary>
        [JsonProperty(PropertyName = "version_terms_of_service")]
        public string VersionTermsOfService { get; private set; }
    
        /// <summary>
        /// The user status. The user status. Can be: ACTIVE, BLOCKED, SIGNUP, RECOVERY, DENIED or ABORTED.
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
        /// The setting for the session timeout of the user in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "session_timeout")]
        public int? SessionTimeout { get; private set; }
    
        /// <summary>
        /// The amount the user can pay in the session without asking for credentials.
        /// </summary>
        [JsonProperty(PropertyName = "daily_limit_without_confirmation_login")]
        public Amount DailyLimitWithoutConfirmationLogin { get; private set; }
    
        /// <summary>
        /// The types of notifications that will result in a push notification or URL callback for this UserPerson.
        /// </summary>
        [JsonProperty(PropertyName = "notification_filters")]
        public List<NotificationFilter> NotificationFilters { get; private set; }
    
        /// <summary>
        /// Get a specific person.
        /// </summary>
        public static BunqResponse<UserPerson> Get(ApiContext apiContext, int userPersonId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userPersonId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<UserPerson>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// Modify a specific person object's data.
        /// </summary>
        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userPersonId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userPersonId), requestBytes, customHeaders);
    
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
    
            if (this.FirstName != null)
            {
                return false;
            }
    
            if (this.MiddleName != null)
            {
                return false;
            }
    
            if (this.LastName != null)
            {
                return false;
            }
    
            if (this.LegalName != null)
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
    
            if (this.TaxResident != null)
            {
                return false;
            }
    
            if (this.DocumentType != null)
            {
                return false;
            }
    
            if (this.DocumentNumber != null)
            {
                return false;
            }
    
            if (this.DocumentCountryOfIssuance != null)
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
    
            if (this.DateOfBirth != null)
            {
                return false;
            }
    
            if (this.PlaceOfBirth != null)
            {
                return false;
            }
    
            if (this.CountryOfBirth != null)
            {
                return false;
            }
    
            if (this.Nationality != null)
            {
                return false;
            }
    
            if (this.Language != null)
            {
                return false;
            }
    
            if (this.Region != null)
            {
                return false;
            }
    
            if (this.Gender != null)
            {
                return false;
            }
    
            if (this.Avatar != null)
            {
                return false;
            }
    
            if (this.VersionTermsOfService != null)
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
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static UserPerson CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<UserPerson>(json);
        }
    }
}
