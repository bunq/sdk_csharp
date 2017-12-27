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
    /// Show the raw contents of a QR code. First you need to created a QR code using ../cash-register/{id}/qr-code.
    /// </summary>
    public class CashRegisterQrCodeContent : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/cash-register/{2}/qr-code/{3}/content";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "CashRegisterQrCodeContent";
    
        /// <summary>
        /// Show the raw contents of a QR code
        /// </summary>
        public static BunqResponse<byte[]> List(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId, int qrCodeId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, cashRegisterId, qrCodeId), new Dictionary<string, string>(), customHeaders);
    
            return new BunqResponse<byte[]>(responseRaw.BodyBytes, responseRaw.Headers);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CashRegisterQrCodeContent CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CashRegisterQrCodeContent>(json);
        }
    }
}
