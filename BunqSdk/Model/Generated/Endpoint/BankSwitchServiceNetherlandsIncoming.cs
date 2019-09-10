using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for using the Equens Bank Switch Service.
    /// </summary>
    public class BankSwitchServiceNetherlandsIncoming : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_ALIAS = "alias";

        public const string FIELD_COUNTERPARTY_ALIAS = "counterparty_alias";
        public const string FIELD_STATUS = "status";
        public const string FIELD_SUB_STATUS = "sub_status";
        public const string FIELD_TIME_START_ACTUAL = "time_start_actual";


        /// <summary>
        /// The label of the monetary of this switch service.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }

        /// <summary>
        /// The IBAN alias that's displayed for this switch service.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }

        /// <summary>
        /// The status of the switch service.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The sub status of the switch service.
        /// </summary>
        [JsonProperty(PropertyName = "sub_status")]
        public string SubStatus { get; set; }

        /// <summary>
        /// The timestamp when the switch service actually starts.
        /// </summary>
        [JsonProperty(PropertyName = "time_start_actual")]
        public string TimeStartActual { get; set; }

        /// <summary>
        /// The label of the user creator of this switch service.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias")]
        public LabelUser UserAlias { get; set; }

        /// <summary>
        /// The timestamp when the switch service desired to be start.
        /// </summary>
        [JsonProperty(PropertyName = "time_start_desired")]
        public string TimeStartDesired { get; set; }

        /// <summary>
        /// The timestamp when the switch service ends.
        /// </summary>
        [JsonProperty(PropertyName = "time_end")]
        public string TimeEnd { get; set; }

        /// <summary>
        /// Reference to the bank transfer form for this switch-service.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public Attachment Attachment { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.UserAlias != null)
            {
                return false;
            }

            if (this.Alias != null)
            {
                return false;
            }

            if (this.CounterpartyAlias != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.SubStatus != null)
            {
                return false;
            }

            if (this.TimeStartDesired != null)
            {
                return false;
            }

            if (this.TimeStartActual != null)
            {
                return false;
            }

            if (this.TimeEnd != null)
            {
                return false;
            }

            if (this.Attachment != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static BankSwitchServiceNetherlandsIncoming CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<BankSwitchServiceNetherlandsIncoming>(json);
        }
    }
}