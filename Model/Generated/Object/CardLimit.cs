using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class CardLimit : BunqModel
    {
        /// <summary>
        /// The daily limit amount.
        /// </summary>
        [JsonProperty(PropertyName = "daily_limit")]
        public string DailyLimit { get; set; }

        /// <summary>
        /// Currency for the daily limit.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The type of transaction for the limit. Can be CARD_LIMIT_ATM, CARD_LIMIT_CONTACTLESS, CARD_LIMIT_DIPPING or
        /// CARD_LIMIT_POS_ICC.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        public CardLimit(string dailyLimit, string currency, string type)
        {
            DailyLimit = dailyLimit;
            Currency = currency;
            Type = type;
        }
    }
}
