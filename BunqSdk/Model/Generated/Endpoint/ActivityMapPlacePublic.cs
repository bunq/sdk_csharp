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
    /// Public endpoint for getting the place info.
    /// </summary>
    public class ActivityMapPlacePublic : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "activity-map-place-public/{0}";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "ActivityMapPlace";
    
        /// <summary>
        /// The name of the place.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// The public uuid of the place.
        /// </summary>
        [JsonProperty(PropertyName = "public_uuid")]
        public string PublicUuid { get; set; }
        /// <summary>
        /// The geolocation of this place.
        /// </summary>
        [JsonProperty(PropertyName = "geolocation")]
        public Geolocation Geolocation { get; set; }
        /// <summary>
        /// The address of this place.
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }
        /// <summary>
        /// The phone number of this place.
        /// </summary>
        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// The URL to this place's merchant website.
        /// </summary>
        [JsonProperty(PropertyName = "url_merchant")]
        public string UrlMerchant { get; set; }
        /// <summary>
        /// The URL to the place's Google maps location.
        /// </summary>
        [JsonProperty(PropertyName = "url_google_maps")]
        public string UrlGoogleMaps { get; set; }
        /// <summary>
        /// The attachments for the place's photos.
        /// </summary>
        [JsonProperty(PropertyName = "all_attachment_photo")]
        public List<AttachmentPublic> AllAttachmentPhoto { get; set; }
        /// <summary>
        /// The google types of the place.
        /// </summary>
        [JsonProperty(PropertyName = "all_type")]
        public List<string> AllType { get; set; }
        /// <summary>
        /// The opening periods of the place.
        /// </summary>
        [JsonProperty(PropertyName = "all_opening_period")]
        public List<string> AllOpeningPeriod { get; set; }
        /// <summary>
        /// The total number of recommendations.
        /// </summary>
        [JsonProperty(PropertyName = "number_of_recommendation_total")]
        public int? NumberOfRecommendationTotal { get; set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<ActivityMapPlacePublic> Get(string activityMapPlacePublicUuid, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, activityMapPlacePublicUuid), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<ActivityMapPlacePublic>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Name != null)
            {
                return false;
            }
    
            if (this.PublicUuid != null)
            {
                return false;
            }
    
            if (this.Geolocation != null)
            {
                return false;
            }
    
            if (this.Address != null)
            {
                return false;
            }
    
            if (this.PhoneNumber != null)
            {
                return false;
            }
    
            if (this.UrlMerchant != null)
            {
                return false;
            }
    
            if (this.UrlGoogleMaps != null)
            {
                return false;
            }
    
            if (this.AllAttachmentPhoto != null)
            {
                return false;
            }
    
            if (this.AllType != null)
            {
                return false;
            }
    
            if (this.AllOpeningPeriod != null)
            {
                return false;
            }
    
            if (this.NumberOfRecommendationTotal != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static ActivityMapPlacePublic CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ActivityMapPlacePublic>(json);
        }
    }
}
