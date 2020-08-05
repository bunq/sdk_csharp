using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Address : BunqModel
    {
        public Address(string street, string houseNumber, string postalCode, string city, string country)
        {
            Street = street;
            HouseNumber = houseNumber;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }

        /// <summary>
        ///     The street.
        /// </summary>
        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }

        /// <summary>
        ///     The house number.
        /// </summary>
        [JsonProperty(PropertyName = "house_number")]
        public string HouseNumber { get; set; }

        /// <summary>
        ///     The PO box.
        /// </summary>
        [JsonProperty(PropertyName = "po_box")]
        public string PoBox { get; set; }

        /// <summary>
        ///     The postal code.
        /// </summary>
        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        ///     The city.
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        /// <summary>
        ///     The country as an ISO 3166-1 alpha-2 country code.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        ///     The apartment, building or other extra information for addresses.
        /// </summary>
        [JsonProperty(PropertyName = "extra")]
        public string Extra { get; set; }

        /// <summary>
        ///     The name on the mailbox (only used for Postal addresses).
        /// </summary>
        [JsonProperty(PropertyName = "mailbox_name")]
        public string MailboxName { get; set; }

        /// <summary>
        ///     The province according to local standard.
        /// </summary>
        [JsonProperty(PropertyName = "province")]
        public string Province { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Street != null) return false;

            if (HouseNumber != null) return false;

            if (PoBox != null) return false;

            if (PostalCode != null) return false;

            if (City != null) return false;

            if (Country != null) return false;

            if (Province != null) return false;

            if (Extra != null) return false;

            if (MailboxName != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static Address CreateFromJsonString(string json)
        {
            return CreateFromJsonString<Address>(json);
        }
    }
}