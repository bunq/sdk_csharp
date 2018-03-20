using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

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

        /// <summary>
        /// The id of the card limit entry.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        public CardLimit(string dailyLimit, string currency, string type)
        {
            DailyLimit = dailyLimit;
            Currency = currency;
            Type = type;
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }

            if (this.DailyLimit != null)
            {
                return false;
            }

            if (this.Currency != null)
            {
                return false;
            }

            if (this.Type != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static CardLimit CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardLimit>(json);
        }
    }
}