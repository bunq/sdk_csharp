using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Show the authenticated user, if it is a light user.
    /// </summary>
    public class UserLight : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlRead = "user-light/{0}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FieldFirstName = "first_name";
        public const string FieldMiddleName = "middle_name";
        public const string FieldLastName = "last_name";
        public const string FieldPublicNickName = "public_nick_name";
        public const string FieldCounterBankIban = "counter_bank_iban";
        public const string FieldAddressMain = "address_main";
        public const string FieldAddressPostal = "address_postal";
        public const string FieldAvatarUuid = "avatar_uuid";
        public const string FieldSocialSecurityNumber = "social_security_number";
        public const string FieldTaxResident = "tax_resident";
        public const string FieldDocumentType = "document_type";
        public const string FieldDocumentNumber = "document_number";
        public const string FieldDocumentCountryOfIssuance = "document_country_of_issuance";
        public const string FieldDocumentFrontAttachmentId = "document_front_attachment_id";
        public const string FieldDocumentBackAttachmentId = "document_back_attachment_id";
        public const string FieldDateOfBirth = "date_of_birth";
        public const string FieldPlaceOfBirth = "place_of_birth";
        public const string FieldCountryOfBirth = "country_of_birth";
        public const string FieldNationality = "nationality";
        public const string FieldLanguage = "language";
        public const string FieldRegion = "region";
        public const string FieldGender = "gender";
        public const string FieldStatus = "status";
        public const string FieldSubStatus = "sub_status";
        public const string FieldLegalGuardianAlias = "legal_guardian_alias";
        public const string FieldSessionTimeout = "session_timeout";
        public const string FieldDailyLimitWithoutConfirmationLogin = "daily_limit_without_confirmation_login";
        public const string FieldNotificationFilters = "notification_filters";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "UserPerson";
    
        /// <summary>
        /// The id of the user.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp of the user object's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp of the user object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The user's public UUID.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; private set; }
    
        /// <summary>
        /// The user's first name.
        /// </summary>
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; private set; }
    
        /// <summary>
        /// The user's middle name.
        /// </summary>
        [JsonProperty(PropertyName = "middle_name")]
        public string MiddleName { get; private set; }
    
        /// <summary>
        /// The user's last name.
        /// </summary>
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; private set; }
    
        /// <summary>
        /// The user's legal name.
        /// </summary>
        [JsonProperty(PropertyName = "legal_name")]
        public string LegalName { get; private set; }
    
        /// <summary>
        /// The display name for the user.
        /// </summary>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; private set; }
    
        /// <summary>
        /// The public nick name for the user.
        /// </summary>
        [JsonProperty(PropertyName = "public_nick_name")]
        public string PublicNickName { get; private set; }
    
        /// <summary>
        /// The aliases of the user.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public List<Pointer> Alias { get; private set; }
    
        /// <summary>
        /// The user's social security number.
        /// </summary>
        [JsonProperty(PropertyName = "social_security_number")]
        public string SocialSecurityNumber { get; private set; }
    
        /// <summary>
        /// The user's tax residence numbers for different countries.
        /// </summary>
        [JsonProperty(PropertyName = "tax_resident")]
        public List<TaxResident> TaxResident { get; private set; }
    
        /// <summary>
        /// The type of identification document the user registered with.
        /// </summary>
        [JsonProperty(PropertyName = "document_type")]
        public string DocumentType { get; private set; }
    
        /// <summary>
        /// The identification document number the user registered with.
        /// </summary>
        [JsonProperty(PropertyName = "document_number")]
        public string DocumentNumber { get; private set; }
    
        /// <summary>
        /// The country which issued the identification document the user registered with.
        /// </summary>
        [JsonProperty(PropertyName = "document_country_of_issuance")]
        public string DocumentCountryOfIssuance { get; private set; }
    
        /// <summary>
        /// The user's main address.
        /// </summary>
        [JsonProperty(PropertyName = "address_main")]
        public Address AddressMain { get; private set; }
    
        /// <summary>
        /// The user's postal address.
        /// </summary>
        [JsonProperty(PropertyName = "address_postal")]
        public Address AddressPostal { get; private set; }
    
        /// <summary>
        /// The user's date of birth. Accepts ISO8601 date formats.
        /// </summary>
        [JsonProperty(PropertyName = "date_of_birth")]
        public string DateOfBirth { get; private set; }
    
        /// <summary>
        /// The user's place of birth.
        /// </summary>
        [JsonProperty(PropertyName = "place_of_birth")]
        public string PlaceOfBirth { get; private set; }
    
        /// <summary>
        /// The user's country of birth. Formatted as a SO 3166-1 alpha-2 country code.
        /// </summary>
        [JsonProperty(PropertyName = "country_of_birth")]
        public string CountryOfBirth { get; private set; }
    
        /// <summary>
        /// The user's nationality. Formatted as a SO 3166-1 alpha-2 country code.
        /// </summary>
        [JsonProperty(PropertyName = "nationality")]
        public string Nationality { get; private set; }
    
        /// <summary>
        /// The user's preferred language. Formatted as a ISO 639-1 language code plus a ISO 3166-1 alpha-2 country
        /// code, seperated by an underscore.
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public string Language { get; private set; }
    
        /// <summary>
        /// The user's preferred region. Formatted as a ISO 639-1 language code plus a ISO 3166-1 alpha-2 country code,
        /// seperated by an underscore.
        /// </summary>
        [JsonProperty(PropertyName = "region")]
        public string Region { get; private set; }
    
        /// <summary>
        /// The user's gender. Can be MALE, FEMALE or UNKNOWN.
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
        /// The user status. The user status. Can be: ACTIVE, BLOCKED, SIGNUP, DENIED or ABORTED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// The user sub-status. Can be: NONE, FACE_RESET, APPROVAL, APPROVAL_PARENT, AWAITING_PARENT, APPROVAL_SUPPORT,
        /// COUNTER_IBAN, IDEAL or SUBMIT.
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
        /// The types of notifications that will result in a push notification or URL callback for this UserLight.
        /// </summary>
        [JsonProperty(PropertyName = "notification_filters")]
        public List<NotificationFilter> NotificationFilters { get; private set; }
    
        /// <summary>
        /// Get a specific bunq light user.
        /// </summary>
        public static BunqResponse<UserLight> Get(ApiContext apiContext, int userLightId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlRead, userLightId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<UserLight>(responseRaw, ObjectType);
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
    
            if (this.SocialSecurityNumber != null)
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
        public static UserLight CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<UserLight>(json);
        }
    }
}
