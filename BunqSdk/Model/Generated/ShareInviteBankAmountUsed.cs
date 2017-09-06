using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;

namespace Bunq.Sdk.Model.Generated
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
        private const string ENDPOINT_URL_DELETE =
            "user/{0}/monetary-account/{1}/share-invite-bank-inquiry/{2}/amount-used/{3}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "ShareInviteBankAmountUsed";

        /// <summary>
        /// Reset the available budget for a bank account share. To be called without any ID at the end of the path.
        /// </summary>
        public static BunqResponse<object> Delete(ApiContext apiContext, int userId, int monetaryAccountId,
            int shareInviteBankInquiryId, int shareInviteBankAmountUsedId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(apiContext);
            var responseRaw =
                apiClient.Delete(
                    string.Format(ENDPOINT_URL_DELETE, userId, monetaryAccountId, shareInviteBankInquiryId,
                        shareInviteBankAmountUsedId), customHeaders);

            return new BunqResponse<object>(null, responseRaw.Headers);
        }
    }
}
