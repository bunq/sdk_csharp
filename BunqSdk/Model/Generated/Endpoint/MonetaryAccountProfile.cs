using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to update and read up monetary account profiles, to keep the balance between specific thresholds.
    /// </summary>
    public class MonetaryAccountProfile : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_PROFILE_FILL = "profile_fill";
        public const string FIELD_PROFILE_DRAIN = "profile_drain";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "MonetaryAccountProfile";
    
        /// <summary>
        /// The profile settings for triggering the fill of a monetary account.
        /// </summary>
        [JsonProperty(PropertyName = "profile_fill")]
        public MonetaryAccountProfileFill ProfileFill { get; private set; }
    
        /// <summary>
        /// The profile settings for moving excesses to a savings account
        /// </summary>
        [JsonProperty(PropertyName = "profile_drain")]
        public MonetaryAccountProfileDrain ProfileDrain { get; private set; }
    }
}
