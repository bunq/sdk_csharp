using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

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
        public const string FieldProfileFill = "profile_fill";
        public const string FieldProfileDrain = "profile_drain";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string ObjectType = "MonetaryAccountProfile";
    
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
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.ProfileFill != null)
            {
                return false;
            }
    
            if (this.ProfileDrain != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static MonetaryAccountProfile CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MonetaryAccountProfile>(json);
        }
    }
}
