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
    /// This call returns the raw content of the QR code that links to this draft share invite. When a bunq user scans
    /// this QR code with the bunq app the draft share invite will be shown on his/her device.
    /// </summary>
    public class DraftShareInviteBankQrCodeContent : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING = "user/{0}/draft-share-invite-bank/{1}/qr-code-content";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "DraftShareInviteBankQrCodeContent";
    
        /// <summary>
        /// Returns the raw content of the QR code that links to this draft share invite. The raw content is the binary
        /// representation of a file, without any JSON wrapping.
        /// </summary>
        public static BunqResponse<byte[]> List(ApiContext apiContext, int userId, int draftShareInviteBankId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, draftShareInviteBankId), new Dictionary<string, string>(), customHeaders);
    
            return new BunqResponse<byte[]>(responseRaw.BodyBytes, responseRaw.Headers);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool AreAllFieldNull()
        {
            return true;
        }
    }
}
