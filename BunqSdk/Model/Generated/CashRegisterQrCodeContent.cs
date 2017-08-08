using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Show the raw contents of a QR code. First you need to created a QR code using ../cash-register/{id}/qr-code.
    /// </summary>
    public class CashRegisterQrCodeContent : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING =
            "user/{0}/monetary-account/{1}/cash-register/{2}/qr-code/{3}/content";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "CashRegisterQrCodeContent";

        public static BunqResponse<byte[]> List(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId, int qrCodeId)
        {
            return List(apiContext, userId, monetaryAccountId, cashRegisterId, qrCodeId,
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Show the raw contents of a QR code
        /// </summary>
        public static BunqResponse<byte[]> List(ApiContext apiContext, int userId, int monetaryAccountId,
            int cashRegisterId, int qrCodeId, IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId, cashRegisterId, qrCodeId),
                    customHeaders);

            return new BunqResponse<byte[]>(responseRaw.BodyBytes, responseRaw.Headers);
        }
    }
}
