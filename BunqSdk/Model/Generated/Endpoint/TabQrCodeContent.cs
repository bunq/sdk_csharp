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
    /// This call returns the raw content of the QR code that links to this Tab. When a bunq user scans this QR code
    /// with the bunq app the Tab will be shown on his/her device.
    /// </summary>
    public class TabQrCodeContent : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/qr-code-content";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "TabQrCodeContent";
    
        /// <summary>
        /// Returns the raw content of the QR code that links to this Tab. The raw content is the binary representation
        /// of a file, without any JSON wrapping.
        /// </summary>
        public static BunqResponse<byte[]> List(int cashRegisterId, string tabUuid, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), cashRegisterId, tabUuid), new Dictionary<string, string>(), customHeaders);
    
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
        public static TabQrCodeContent CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TabQrCodeContent>(json);
        }
    }
}
