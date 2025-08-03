using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to accept or reject a monetaryAccountJoint co-ownership.
    /// </summary>
    public class CoOwnerInviteResponseApiObject : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";
    
    
        /// <summary>
        /// The status of the invite. Can be PENDING, REVOKED (the user deletes the share inquiry before it's accepted)
        /// or ACCEPTED
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The monetary account and user who get the invite for the joint account.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
        /// <summary>
        /// The monetary account and user who created the joint account.
        /// </summary>
        [JsonProperty(PropertyName = "counter_alias")]
        public MonetaryAccountReference CounterAlias { get; set; }
        /// <summary>
        /// The ID of the monetaryAccount
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public long? MonetaryAccountId { get; set; }
        /// <summary>
        /// The extension type of the monetaryAccount
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_type")]
        public string MonetaryAccountType { get; set; }
        /// <summary>
        /// The freeze_status of the invite.
        /// </summary>
        [JsonProperty(PropertyName = "freeze_status")]
        public string FreezeStatus { get; set; }
        /// <summary>
        /// The label of the user that froze the coowner invite (if frozen).
        /// </summary>
        [JsonProperty(PropertyName = "label_freeze_user")]
        public MonetaryAccountReference LabelFreezeUser { get; set; }
        /// <summary>
        /// The users the account will be joint with.
        /// </summary>
        [JsonProperty(PropertyName = "all_co_owner")]
        public List<CoOwnerObject> AllCoOwner { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Alias != null)
            {
                return false;
            }
    
            if (this.CounterAlias != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountId != null)
            {
                return false;
            }
    
            if (this.MonetaryAccountType != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.FreezeStatus != null)
            {
                return false;
            }
    
            if (this.LabelFreezeUser != null)
            {
                return false;
            }
    
            if (this.AllCoOwner != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CoOwnerInviteResponseApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CoOwnerInviteResponseApiObject>(json);
        }
    }
}
