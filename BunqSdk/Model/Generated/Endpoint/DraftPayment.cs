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
    /// A DraftPayment is like a regular Payment, but it needs to be accepted by the sending party before the actual
    /// Payment is done.
    /// </summary>
    public class DraftPayment : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/draft-payment";

        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/draft-payment/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/draft-payment";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/draft-payment/{2}";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";

        public const string FIELD_ENTRIES = "entries";
        public const string FIELD_PREVIOUS_UPDATED_TIMESTAMP = "previous_updated_timestamp";
        public const string FIELD_NUMBER_OF_REQUIRED_ACCEPTS = "number_of_required_accepts";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "DraftPayment";

        /// <summary>
        /// The status of the DraftPayment.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The entries in the DraftPayment.
        /// </summary>
        [JsonProperty(PropertyName = "entries")]
        public List<DraftPaymentEntry> Entries { get; set; }

        /// <summary>
        /// The last updated_timestamp that you received for this DraftPayment. This needs to be provided to prevent
        /// race conditions.
        /// </summary>
        [JsonProperty(PropertyName = "previous_updated_timestamp")]
        public string PreviousUpdatedTimestamp { get; set; }

        /// <summary>
        /// The number of accepts that are required for the draft payment to receive status ACCEPTED. Currently only 1
        /// is valid.
        /// </summary>
        [JsonProperty(PropertyName = "number_of_required_accepts")]
        public int? NumberOfRequiredAccepts { get; set; }

        /// <summary>
        /// The id of the created DrafPayment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The id of the MonetaryAccount the DraftPayment applies to.
        /// </summary>
        [JsonProperty(PropertyName = "monetary_account_id")]
        public int? MonetaryAccountId { get; set; }

        /// <summary>
        /// The label of the User who created the DraftPayment.
        /// </summary>
        [JsonProperty(PropertyName = "user_alias_created")]
        public LabelUser UserAliasCreated { get; set; }

        /// <summary>
        /// All responses to this draft payment.
        /// </summary>
        [JsonProperty(PropertyName = "responses")]
        public List<DraftPaymentResponse> Responses { get; set; }

        /// <summary>
        /// The type of the DraftPayment.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The Payment or PaymentBatch. This will only be present after the DraftPayment has been accepted.
        /// </summary>
        [JsonProperty(PropertyName = "object")]
        public DraftPaymentAnchorObject Object { get; set; }

        /// <summary>
        /// The reference to the object used for split the bill. Can be RequestInquiry or RequestInquiryBatch
        /// </summary>
        [JsonProperty(PropertyName = "request_reference_split_the_bill")]
        public List<RequestInquiryReference> RequestReferenceSplitTheBill { get; set; }


        /// <summary>
        /// Create a new DraftPayment.
        /// </summary>
        /// <param name="entries">The list of entries in the DraftPayment. Each entry will result in a payment when the DraftPayment is accepted.</param>
        /// <param name="numberOfRequiredAccepts">The number of accepts that are required for the draft payment to receive status ACCEPTED. Currently only 1 is valid.</param>
        /// <param name="status">The status of the DraftPayment.</param>
        /// <param name="previousUpdatedTimestamp">The last updated_timestamp that you received for this DraftPayment. This needs to be provided to prevent race conditions.</param>
        public static BunqResponse<int> Create(List<DraftPaymentEntry> entries, int? numberOfRequiredAccepts,
            int? monetaryAccountId = null, string status = null, string previousUpdatedTimestamp = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_STATUS, status},
                {FIELD_ENTRIES, entries},
                {FIELD_PREVIOUS_UPDATED_TIMESTAMP, previousUpdatedTimestamp},
                {FIELD_NUMBER_OF_REQUIRED_ACCEPTS, numberOfRequiredAccepts},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Post(
                    string.Format(ENDPOINT_URL_CREATE, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId)), requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Update a DraftPayment.
        /// </summary>
        /// <param name="status">The status of the DraftPayment.</param>
        /// <param name="entries">The list of entries in the DraftPayment. Each entry will result in a payment when the DraftPayment is accepted.</param>
        /// <param name="previousUpdatedTimestamp">The last updated_timestamp that you received for this DraftPayment. This needs to be provided to prevent race conditions.</param>
        public static BunqResponse<int> Update(int draftPaymentId, int? monetaryAccountId = null, string status = null,
            List<DraftPaymentEntry> entries = null, string previousUpdatedTimestamp = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_STATUS, status},
                {FIELD_ENTRIES, entries},
                {FIELD_PREVIOUS_UPDATED_TIMESTAMP, previousUpdatedTimestamp},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(
                    string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        draftPaymentId), requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// Get a listing of all DraftPayments from a given MonetaryAccount.
        /// </summary>
        public static BunqResponse<List<DraftPayment>> List(int? monetaryAccountId = null,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_LISTING, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);

            return FromJsonList<DraftPayment>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// Get a specific DraftPayment.
        /// </summary>
        public static BunqResponse<DraftPayment> Get(int draftPaymentId, int? monetaryAccountId = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        draftPaymentId), new Dictionary<string, string>(), customHeaders);

            return FromJson<DraftPayment>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }

            if (this.MonetaryAccountId != null)
            {
                return false;
            }

            if (this.UserAliasCreated != null)
            {
                return false;
            }

            if (this.Responses != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.Type != null)
            {
                return false;
            }

            if (this.Entries != null)
            {
                return false;
            }

            if (this.Object != null)
            {
                return false;
            }

            if (this.RequestReferenceSplitTheBill != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static DraftPayment CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<DraftPayment>(json);
        }
    }
}