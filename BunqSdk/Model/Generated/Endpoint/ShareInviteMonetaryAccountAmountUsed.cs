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
    /// When you have connected your monetary account to a user, and given this user a (for example) daily budget of 10
    /// EUR. If this users has used his entire budget or part of it, this call can be used to reset the amount he used
    /// to 0. The user can then spend the daily budget of 10 EUR again.
    /// </summary>
    public class ShareInviteMonetaryAccountAmountUsed : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_DELETE = "user/{0}/monetary-account/{1}/share-invite-monetary-account-inquiry/{2}/amount-used/{3}";
    
    
        /// <summary>
        /// Reset the available budget for an account share. To be called without any ID at the end of the path.
        /// </summary>
        public static BunqResponse<object> Delete(int shareInviteMonetaryAccountInquiryId, int shareInviteMonetaryAccountAmountUsedId, int? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Delete(string.Format(ENDPOINT_URL_DELETE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), shareInviteMonetaryAccountInquiryId, shareInviteMonetaryAccountAmountUsedId), customHeaders);
    
            return new BunqResponse<object>(null, responseRaw.Headers);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static ShareInviteMonetaryAccountAmountUsed CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ShareInviteMonetaryAccountAmountUsed>(json);
        }
    }
}
