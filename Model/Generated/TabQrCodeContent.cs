using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;

namespace Bunq.Sdk.Model.Generated
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
        private const string ENDPOINT_URL_LISTING =
            "user/{0}/monetary-account/{1}/cash-register/{2}/tab/{3}/qr-code-content";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "TabQrCodeContent";

        public static byte[] List(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId,
            string tabUuid)
        {
            return List(apiContext, userId, monetaryAccountId, cashRegisterId, tabUuid,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Returns the raw content of the QR code that links to this Tab. The raw content is the binary representation
        /// of a file, without any JSON wrapping.
        /// </summary>
        public static byte[] List(ApiContext apiContext, int userId, int monetaryAccountId, int cashRegisterId,
            string tabUuid, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);

            return apiClient
                .Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, cashRegisterId, tabUuid),
                    customHeaders).Content.ReadAsByteArrayAsync().Result;
        }
    }
}
