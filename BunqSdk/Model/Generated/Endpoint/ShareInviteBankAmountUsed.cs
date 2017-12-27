using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// When you have connected your monetary account bank to a user, and given this user a (for example) daily budget
    /// of 10 EUR. If this users has used his entire budget or part of it, this call can be used to reset the amount he
    /// used to 0. The user can then spend the daily budget of 10 EUR again.
    /// </summary>
    public class ShareInviteBankAmountUsed : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string EndpointUrlDelete = "user/{0}/monetary-account/{1}/share-invite-bank-inquiry/{2}/amount-used/{3}";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "ShareInviteBankAmountUsed";
    
        /// <summary>
        /// Reset the available budget for a bank account share. To be called without any ID at the end of the path.
        /// </summary>
        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int monetaryAccountId, int shareInviteBankInquiryId, int shareInviteBankAmountUsedId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Delete(string.Format(EndpointUrlDelete, userId, monetaryAccountId, shareInviteBankInquiryId, shareInviteBankAmountUsedId), customHeaders);
    
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
        public static ShareInviteBankAmountUsed CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ShareInviteBankAmountUsed>(json);
        }
    }
}
