using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Address : BunqModel
    {
        /// <summary>
        /// The street.
        /// </summary>
        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }
    
        /// <summary>
        /// The house number.
        /// </summary>
        [JsonProperty(PropertyName = "house_number")]
        public string HouseNumber { get; set; }
    
        /// <summary>
        /// The PO box.
        /// </summary>
        [JsonProperty(PropertyName = "po_box")]
        public string PoBox { get; set; }
    
        /// <summary>
        /// The postal code.
        /// </summary>
        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode { get; set; }
    
        /// <summary>
        /// The city.
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
    
        /// <summary>
        /// The country as an ISO 3166-1 alpha-2 country code..
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
    
        /// <summary>
        /// The province according to local standard.
        /// </summary>
        [JsonProperty(PropertyName = "province")]
        public string Province { get; set; }
    
        public Address(string street, string houseNumber, string postalCode, string city, string country)
        {
            Street = street;
            HouseNumber = houseNumber;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }
    
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
        {
            if (this.Street != null)
            {
                return false;
            }
    
            if (this.HouseNumber != null)
            {
                return false;
            }
    
            if (this.PoBox != null)
            {
                return false;
            }
    
            if (this.PostalCode != null)
            {
                return false;
            }
    
            if (this.City != null)
            {
                return false;
            }
    
            if (this.Country != null)
            {
                return false;
            }
    
            if (this.Province != null)
            {
                return false;
            }
    
            return true;
        }
    }
}
