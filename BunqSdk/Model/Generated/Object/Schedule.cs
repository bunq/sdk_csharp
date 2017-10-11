using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class Schedule : BunqModel
    {
        /// <summary>
        /// The schedule start time (UTC).
        /// </summary>
        [JsonProperty(PropertyName = "time_start")]
        public string TimeStart { get; set; }
    
        /// <summary>
        /// The schedule end time (UTC).
        /// </summary>
        [JsonProperty(PropertyName = "time_end")]
        public string TimeEnd { get; set; }
    
        /// <summary>
        /// The schedule recurrence unit, options: ONCE, HOURLY, DAILY, WEEKLY, MONTHLY, YEARLY
        /// </summary>
        [JsonProperty(PropertyName = "recurrence_unit")]
        public string RecurrenceUnit { get; set; }
    
        /// <summary>
        /// The schedule recurrence size. For example size 4 and unit WEEKLY means the recurrence is every 4 weeks.
        /// </summary>
        [JsonProperty(PropertyName = "recurrence_size")]
        public int? RecurrenceSize { get; set; }
    
        /// <summary>
        /// The schedule status, options: ACTIVE, FINISHED, CANCELLED.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The scheduled object.
        /// </summary>
        [JsonProperty(PropertyName = "object")]
        public BunqModel Object { get; set; }
    
        public Schedule(string timeStart, string recurrenceUnit, int? recurrenceSize)
        {
            TimeStart = timeStart;
            RecurrenceUnit = recurrenceUnit;
            RecurrenceSize = recurrenceSize;
        }
    }
}
