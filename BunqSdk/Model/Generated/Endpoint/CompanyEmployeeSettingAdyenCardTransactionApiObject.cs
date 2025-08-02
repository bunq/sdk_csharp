using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Manage permissions for Adyen card transactions / Tap to Pay for a company employee.
    /// </summary>
    public class CompanyEmployeeSettingAdyenCardTransactionApiObject : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/company-employee-setting-adyen-card-transaction/{1}";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_POINTER_COUNTER_USER = "pointer_counter_user";
        public const string FIELD_STATUS = "status";
        public const string FIELD_MONETARY_ACCOUNT_PAYOUT_ID = "monetary_account_payout_id";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "CompanyEmployeeSettingAdyenCardTransaction";
    
        /// <summary>
        /// The pointer to the employee for which you want to create a card.
        /// </summary>
        [JsonProperty(PropertyName = "pointer_counter_user")]
        public MonetaryAccountReference PointerCounterUser { get; set; }
        /// <summary>
        /// Whether the user is allowed to use Tap to Pay.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The ID of the monetary account where Tap to Pay transactions should be paid out to.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_payout_id")]
        public long? MonetaryAccountPayoutId { get; set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<CompanyEmployeeSettingAdyenCardTransactionApiObject> Get(long companyEmployeeSettingAdyenCardTransactionId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), companyEmployeeSettingAdyenCardTransactionId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<CompanyEmployeeSettingAdyenCardTransactionApiObject>(responseRaw, OBJECT_TYPE_GET);
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountPayoutId != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CompanyEmployeeSettingAdyenCardTransactionApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CompanyEmployeeSettingAdyenCardTransactionApiObject>(json);
        }
    }
}
