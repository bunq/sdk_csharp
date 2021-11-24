using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Endpoint for creating a refund request for a masterCard transaction.
    /// </summary>
    public class MasterCardActionRefund : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_TYPE = "type";
        public const string FIELD_SUB_TYPE = "sub_type";
        public const string FIELD_AMOUNT = "amount";
        public const string FIELD_CATEGORY = "category";
        public const string FIELD_REASON = "reason";
        public const string FIELD_COMMENT = "comment";
        public const string FIELD_ATTACHMENT = "attachment";
        public const string FIELD_TERMS_AND_CONDITIONS = "terms_and_conditions";
    
    
        /// <summary>
        /// Type of this refund. Can de REFUND or CHARGEBACK
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    
        /// <summary>
        /// The sub type of this refund indicating whether the chargeback will be FULL or PARTIAL.
        /// </summary>
        [JsonProperty(PropertyName = "sub_type")]
        public string SubType { get; set; }
    
        /// <summary>
        /// The amount to refund.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }
    
        /// <summary>
        /// The category of the refund, required for chargeback.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
    
        /// <summary>
        /// The reason of the refund. Can be REFUND_EXPIRED_TRANSACTION, REFUND_REQUESTED, REFUND_MERCHANT,
        /// REFUND_CHARGEBACK.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }
    
        /// <summary>
        /// Comment about the refund.
        /// </summary>
        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }
    
        /// <summary>
        /// The Attachments to attach to the refund request.
        /// </summary>
        [JsonProperty(PropertyName = "attachment")]
        public List<AttachmentMasterCardActionRefund> Attachment { get; set; }
    
        /// <summary>
        /// Proof that the user acknowledged the terms and conditions for chargebacks.
        /// </summary>
        [JsonProperty(PropertyName = "terms_and_conditions")]
        public string TermsAndConditions { get; set; }
    
        /// <summary>
        /// The id of the refund.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
    
        /// <summary>
        /// The timestamp of the refund's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
    
        /// <summary>
        /// The timestamp of the refund's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
    
        /// <summary>
        /// The label of the user who created this note.
        /// </summary>
        [JsonProperty(PropertyName = "label_user_creator")]
        public MonetaryAccountReference LabelUserCreator { get; set; }
    
        /// <summary>
        /// The status of the refunded mastercard action. Can be AUTO_APPROVED, AUTO_APPROVED_WAITING_FOR_EXPIRY,
        /// PENDING_APPROVAL, APPROVED, REFUNDED, DENIED or FAILED
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    
        /// <summary>
        /// The reference to the object this refund applies to.
        /// </summary>
        [JsonProperty(PropertyName = "reference_mastercard_action_event")]
        public List<MasterCardActionReference> ReferenceMastercardActionEvent { get; set; }
    
        /// <summary>
        /// The id of mastercard action being refunded.
        /// </summary>
        [JsonProperty(PropertyName = "mastercard_action_id")]
        public int? MastercardActionId { get; set; }
    
        /// <summary>
        /// The monetary account label of the account that this action is created for.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
    
        /// <summary>
        /// The monetary account label of the counterparty.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
    
        /// <summary>
        /// The description for this transaction to display.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    
        /// <summary>
        /// The label of the card.
        /// </summary>
        [JsonProperty(PropertyName = "label_card")]
        public LabelCard LabelCard { get; set; }
    
        /// <summary>
        /// The time the refund will take place.
        /// </summary>
        [JsonProperty(PropertyName = "time_refund")]
        public string TimeRefund { get; set; }
    
        /// <summary>
        /// All additional information provided by the user.
        /// </summary>
        [JsonProperty(PropertyName = "additional_information")]
        public AdditionalInformation AdditionalInformation { get; set; }
    
        /// <summary>
        /// Description of the refund's current status.
        /// </summary>
        [JsonProperty(PropertyName = "status_description")]
        public string StatusDescription { get; set; }
    
        /// <summary>
        /// Description of the refund's current status, translated in user's language.
        /// </summary>
        [JsonProperty(PropertyName = "status_description_translated")]
        public string StatusDescriptionTranslated { get; set; }
    
        /// <summary>
        /// Together topic concerning the refund's current status.
        /// </summary>
        [JsonProperty(PropertyName = "status_together_url")]
        public string StatusTogetherUrl { get; set; }
    
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }
    
            if (this.Created != null)
            {
                return false;
            }
    
            if (this.Updated != null)
            {
                return false;
            }
    
            if (this.LabelUserCreator != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.ReferenceMastercardActionEvent != null)
            {
                return false;
            }
    
            if (this.MastercardActionId != null)
            {
                return false;
            }
    
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.SubType != null)
            {
                return false;
            }
    
            if (this.Reason != null)
            {
                return false;
            }
    
            if (this.Amount != null)
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
    
            if (this.Description != null)
            {
                return false;
            }
    
            if (this.LabelCard != null)
            {
                return false;
            }
    
            if (this.TimeRefund != null)
            {
                return false;
            }
    
            if (this.AdditionalInformation != null)
            {
                return false;
            }
    
            if (this.StatusDescription != null)
            {
                return false;
            }
    
            if (this.StatusDescriptionTranslated != null)
            {
                return false;
            }
    
            if (this.StatusTogetherUrl != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static MasterCardActionRefund CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<MasterCardActionRefund>(json);
        }
    }
}
