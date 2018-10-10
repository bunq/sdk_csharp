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
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/cash-register/{2}/qr-code";

        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/cash-register/{2}/qr-code/{3}";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/cash-register/{2}/qr-code/{3}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/cash-register/{2}/qr-code";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "TokenQrCashRegister";

        /// <summary>
        /// The status of this QR code. If the status is "ACTIVE" the QR code can be scanned to see the linked
        /// CashRegister and tab. If the status is "INACTIVE" the QR code does not link to a anything.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The id of the created QR code. Use this id to get the RAW content of the QR code with:
        /// ../qr-code/{id}/content
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the QR code's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the TokenQrCashRegister's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The CashRegister that is linked to the token.
        /// </summary>
        [JsonProperty(PropertyName = "cash_register")]
        public CashRegister CashRegister { get; set; }

        /// <summary>
        /// Holds the Tab object. Can be TabUsageSingle, TabUsageMultiple or null
        /// </summary>
        [JsonProperty(PropertyName = "tab_object")]
        public Tab TabObject { get; set; }

        /// <summary>
        /// Create a new QR code for this CashRegister. You can only have one ACTIVE CashRegister QR code at the time.
        /// </summary>
        /// <param name="status">The status of the QR code. ACTIVE or INACTIVE. Only one QR code can be ACTIVE for a CashRegister at any time. Setting a QR code to ACTIVE will deactivate any other CashRegister QR codes.</param>
        public static BunqResponse<int> Create(int cashRegisterId, string status, int? monetaryAccountId = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_STATUS, status},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Post(
                    string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        cashRegisterId), requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Modify a QR code in a given CashRegister. You can only have one ACTIVE CashRegister QR code at the time.
        /// </summary>
        /// <param name="status">The status of the QR code. ACTIVE or INACTIVE. Only one QR code can be ACTIVE for a CashRegister at any time. Setting a QR code to ACTIVE will deactivate any other CashRegister QR codes.</param>
        public static BunqResponse<int> Update(int cashRegisterId, int cashRegisterQrCodeId,
            int? monetaryAccountId = null, string status = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_STATUS, status},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(
                    string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        cashRegisterId, cashRegisterQrCodeId), requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Get the information of a specific QR code. To get the RAW content of the QR code use ../qr-code/{id}/content
        /// </summary>
        public static BunqResponse<CashRegisterQrCode> Get(int cashRegisterId, int cashRegisterQrCodeId,
            int? monetaryAccountId = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        cashRegisterId, cashRegisterQrCodeId), new Dictionary<string, string>(), customHeaders);

            return FromJson<CashRegisterQrCode>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Get a collection of QR code information from a given CashRegister
        /// </summary>
        public static BunqResponse<List<CashRegisterQrCode>> List(int cashRegisterId, int? monetaryAccountId = null,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_LISTING, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId), cashRegisterId), urlParams, customHeaders);

            return FromJsonList<CashRegisterQrCode>(responseRaw, OBJECT_TYPE_GET);
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

            if (this.Status != null)
            {
                return false;
            }

            if (this.CashRegister != null)
            {
                return false;
            }

            if (this.TabObject != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static CashRegisterQrCode CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CashRegisterQrCode>(json);
        }
    }
}