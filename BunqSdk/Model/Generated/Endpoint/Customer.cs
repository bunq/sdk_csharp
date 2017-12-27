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
    /// Used to view a customer.
    /// </summary>
    public class Customer : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlListing = "user/{0}/customer";
        private const string EndpointUrlRead = "user/{0}/customer/{1}";
        private const string EndpointUrlUpdate = "user/{0}/customer/{1}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FieldBillingAccountId = "billing_account_id";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "Customer";
    
        /// <summary>
        /// The id of the customer.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp of the customer object's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp of the customer object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The primary billing account account's id.
        /// </summary>
        [JsonProperty(PropertyName = "billing_account_id")]
        public string BillingAccountId { get; private set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<Customer>> List(ApiContext apiContext, int userId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlListing, userId), urlParams, customHeaders);
    
            return FromJsonList<Customer>(responseRaw, ObjectType);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<Customer> Get(ApiContext apiContext, int userId, int customerId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(EndpointUrlRead, userId, customerId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<Customer>(responseRaw, ObjectType);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int customerId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(EndpointUrlUpdate, userId, customerId), requestBytes, customHeaders);
    
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
    
            if (this.BillingAccountId != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static Customer CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Customer>(json);
        }
    }
}
