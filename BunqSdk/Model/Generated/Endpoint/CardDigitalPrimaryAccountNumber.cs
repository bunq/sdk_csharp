using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// View for getting the dPAN of the card.
    /// </summary>
    public class CardDigitalPrimaryAccountNumber : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/card/{1}/digital-primary-account-number";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "CardDigitalPrimaryAccountNumber";
    
        /// <summary>
        /// The digital PAN of the card.
        /// </summary>
        [JsonProperty(PropertyName = "digital_primary_account_number")]
        public string DigitalPrimaryAccountNumber { get; set; }
    
        /// <summary>
        /// The expiry date.
        /// </summary>
        [JsonProperty(PropertyName = "expiry_date")]
        public string ExpiryDate { get; set; }
    
        /// <summary>
        /// The sequence number.
        /// </summary>
        [JsonProperty(PropertyName = "sequence_number")]
        public string SequenceNumber { get; set; }
    
        /// <summary>
        /// Unique reference given by MDES.
        /// </summary>
        [JsonProperty(PropertyName = "token_unique_reference")]
        public string TokenUniqueReference { get; set; }
    
        /// <summary>
        /// Status code of the token given by MDES.
        /// </summary>
        [JsonProperty(PropertyName = "token_status_code")]
        public string TokenStatusCode { get; set; }
    
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<CardDigitalPrimaryAccountNumber>> List(int cardId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), cardId), urlParams, customHeaders);
    
            return FromJsonList<CardDigitalPrimaryAccountNumber>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.DigitalPrimaryAccountNumber != null)
            {
                return false;
            }
    
            if (this.ExpiryDate != null)
            {
                return false;
            }
    
            if (this.SequenceNumber != null)
            {
                return false;
            }
    
            if (this.TokenUniqueReference != null)
            {
                return false;
            }
    
            if (this.TokenStatusCode != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CardDigitalPrimaryAccountNumber CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardDigitalPrimaryAccountNumber>(json);
        }
    }
}
