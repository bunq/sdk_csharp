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
    /// Create and manage companies.
    /// </summary>
    public class Company : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/company";
        protected const string ENDPOINT_URL_READ = "user/{0}/company/{1}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/company";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/company/{1}";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_NAME = "name";
        public const string FIELD_ADDRESS_MAIN = "address_main";
        public const string FIELD_ADDRESS_POSTAL = "address_postal";
        public const string FIELD_COUNTRY = "country";
        public const string FIELD_UBO = "ubo";
        public const string FIELD_CHAMBER_OF_COMMERCE_NUMBER = "chamber_of_commerce_number";
        public const string FIELD_LEGAL_FORM = "legal_form";
        public const string FIELD_SUBSCRIPTION_TYPE = "subscription_type";
        public const string FIELD_AVATAR_UUID = "avatar_uuid";

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
        /// The country where the company is registered.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// The names and birth dates of the company's ultimate beneficiary owners. Minimum zero, maximum four.
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
        /// The subscription type for the company.
        /// </summary>
        [JsonProperty(PropertyName = "subscription_type")]
        public string SubscriptionType { get; set; }

        /// <summary>
        /// The public UUID of the company's avatar.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_uuid")]
        public string AvatarUuid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UserCompany")]
        public UserCompany UserCompany { get; set; }


        /// <summary>
        /// </summary>
        /// <param name="name">The company name.</param>
        /// <param name="addressMain">The company's main address.</param>
        /// <param name="addressPostal">The company's postal address.</param>
        /// <param name="country">The country where the company is registered.</param>
        /// <param name="legalForm">The company's legal form.</param>
        /// <param name="ubo">The names and birth dates of the company's ultimate beneficiary owners. Minimum zero, maximum four.</param>
        /// <param name="chamberOfCommerceNumber">The company's chamber of commerce number.</param>
        /// <param name="subscriptionType">The subscription type for the company.</param>
        /// <param name="avatarUuid">The public UUID of the company's avatar.</param>
        public static BunqResponse<int> Create(string name, Address addressMain, Address addressPostal, string country,
            string legalForm, List<Ubo> ubo = null, string chamberOfCommerceNumber = null,
            string subscriptionType = null, string avatarUuid = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_NAME, name},
                {FIELD_ADDRESS_MAIN, addressMain},
                {FIELD_ADDRESS_POSTAL, addressPostal},
                {FIELD_COUNTRY, country},
                {FIELD_UBO, ubo},
                {FIELD_CHAMBER_OF_COMMERCE_NUMBER, chamberOfCommerceNumber},
                {FIELD_LEGAL_FORM, legalForm},
                {FIELD_SUBSCRIPTION_TYPE, subscriptionType},
                {FIELD_AVATAR_UUID, avatarUuid},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes,
                customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<Company> Get(int companyId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), companyId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<Company>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<Company>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<Company>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        /// <param name="avatarUuid">The public UUID of the company's avatar.</param>
        public static BunqResponse<int> Update(int companyId, string avatarUuid = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_AVATAR_UUID, avatarUuid},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), companyId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.UserCompany != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static Company CreateFromJsonString(string json)
        {
            return CreateFromJsonString<Company>(json);
        }
    }
}