using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Post processor for open banking account to be returned in the monetary account external post processor.
    /// </summary>
    public class OpenBankingAccount : BunqModel
    {
        /// <summary>
        /// The status of this account.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The iban of this account.
        /// </summary>
        [JsonProperty(PropertyName = "iban")]
        public string Iban { get; set; }
        /// <summary>
        /// The timestamp of the last time the account was synced with our open banking partner.
        /// </summary>
        [JsonProperty(PropertyName = "time_synced_last")]
        public string TimeSyncedLast { get; set; }
        /// <summary>
        /// The bank provider the account comes from.
        /// </summary>
        [JsonProperty(PropertyName = "provider_bank")]
        public OpenBankingProviderBank ProviderBank { get; set; }
        /// <summary>
        /// The booked balance of the account.
        /// </summary>
        [JsonProperty(PropertyName = "balance_booked")]
        public Amount BalanceBooked { get; set; }
        /// <summary>
        /// The available balance of the account, if provided by the other bank.
        /// </summary>
        [JsonProperty(PropertyName = "balance_available")]
        public Amount BalanceAvailable { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.Iban != null)
            {
                return false;
            }
    
            if (this.TimeSyncedLast != null)
            {
                return false;
            }
    
            if (this.ProviderBank != null)
            {
                return false;
            }
    
            if (this.BalanceBooked != null)
            {
                return false;
            }
    
            if (this.BalanceAvailable != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static OpenBankingAccount CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<OpenBankingAccount>(json);
        }
    }
}
