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
    /// Once your CashRegister has been activated you can create a QR code for it. The visibility of a tab can be
    /// modified to be linked to this QR code. If a user of the bunq app scans this QR code, the linked tab will be
    /// shown on his device.
    /// </summary>
    public class CashRegisterQrCode : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";
    
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/cash-register/{2}/qr-code";
        private const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/cash-register/{2}/qr-code/{3}";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/cash-register/{2}/qr-code/{3}";
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/cash-register/{2}/qr-code";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "TokenQrCashRegister";
    
        /// <summary>
        /// The id of the created QR code. Use this id to get the RAW content of the QR code with:
        /// ../qr-code/{id}/content
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }
    
        /// <summary>
        /// The timestamp of the QR code's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }
    
        /// <summary>
        /// The timestamp of the TokenQrCashRegister's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }
    
        /// <summary>
        /// The status of this QR code. If the status is "ACTIVE" the QR code can be scanned to see the linked
        /// CashRegister and tab. If the status is "INACTIVE" the QR code does not link to a anything.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    
        /// <summary>
        /// The CashRegister that is linked to the token.
        /// </summary>
        [JsonProperty(PropertyName = "cash_register")]
        public CashRegister CashRegister { get; private set; }
    
        /// <summary>
        /// Holds the Tab object. Can be TabUsageSingle, TabUsageMultiple or null
        /// </summary>
        [JsonProperty(PropertyName = "tab_object")]
        public Tab TabObject { get; private set; }
    
        /// <summary>
        /// Create a new QR code for this CashRegister. You can only have one ACTIVE CashRegister QR code at the time.
        /// </summary>
        public static BunqResponse<int> Create(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int cashRegisterId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, userId, monetaryAccountId, cashRegisterId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Modify a QR code in a given CashRegister. You can only have one ACTIVE CashRegister QR code at the time.
        /// </summary>
        public static BunqResponse<int> Update(ApiContext apiContext, IDictionary<string, object> requestMap, int userId, int monetaryAccountId, int cashRegisterId, int cashRegisterQrCodeId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, userId, monetaryAccountId, cashRegisterId, cashRegisterQrCodeId), requestBytes, customHeaders);
    
            return ProcessForId(responseRaw);
        }
    
        /// <summary>
        /// Get the information of a specific QR code. To get the RAW content of the QR code use ../qr-code/{id}/content
        /// </summary>
        public static BunqResponse<CashRegisterQrCode> Get(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId, int cashRegisterQrCodeId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, cashRegisterId, cashRegisterQrCodeId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<CashRegisterQrCode>(responseRaw, OBJECT_TYPE);
        }
    
        /// <summary>
        /// Get a collection of QR code information from a given CashRegister
        /// </summary>
        public static BunqResponse<List<CashRegisterQrCode>> List(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, cashRegisterId), urlParams, customHeaders);
    
            return FromJsonList<CashRegisterQrCode>(responseRaw, OBJECT_TYPE);
        }
    }
}
