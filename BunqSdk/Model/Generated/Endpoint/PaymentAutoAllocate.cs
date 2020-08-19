using System.Collections.Generic;
using System.Text;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Manage a users automatic payment auto allocated settings.
    /// </summary>
    public class PaymentAutoAllocate : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/monetary-account/{1}/payment-auto-allocate";
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/payment-auto-allocate/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/payment-auto-allocate";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/monetary-account/{1}/payment-auto-allocate/{2}";
        protected const string ENDPOINT_URL_DELETE = "user/{0}/monetary-account/{1}/payment-auto-allocate/{2}";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_PAYMENT_ID = "payment_id";
        public const string FIELD_TYPE = "type";
        public const string FIELD_DEFINITION = "definition";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "PaymentAutoAllocate";

        /// <summary>
        /// The payment that should be used to define the triggers for the payment auto allocate.
        /// </summary>
        [JsonProperty(PropertyName = "payment_id")]
        public int? PaymentId { get; set; }

        /// <summary>
        /// The type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The definition of how the money should be allocated.
        /// </summary>
        [JsonProperty(PropertyName = "definition")]
        public List<PaymentAutoAllocateDefinition> Definition { get; set; }

        /// <summary>
        /// The id of the PaymentAutoAllocate.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp when the PaymentAutoAllocate was created.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp when the PaymentAutoAllocate was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The status.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The amount on which this payment auto allocate will be triggered.
        /// </summary>
        [JsonProperty(PropertyName = "trigger_amount")]
        public Amount TriggerAmount { get; set; }

        /// <summary>
        /// The payment that was used to define the triggers for this payment auto allocate.
        /// </summary>
        [JsonProperty(PropertyName = "payment")]
        public Payment Payment { get; set; }


        /// <summary>
        /// </summary>
        /// <param name="paymentId">The payment that should be used to define the triggers for the payment auto allocate.</param>
        /// <param name="type">Whether a payment should be sorted ONCE or RECURRING.</param>
        /// <param name="definition">The definition of how the money should be allocated.</param>
        public static BunqResponse<int> Create(int? paymentId, string type,
            List<PaymentAutoAllocateDefinition> definition, int? monetaryAccountId = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_PAYMENT_ID, paymentId},
                {FIELD_TYPE, type},
                {FIELD_DEFINITION, definition},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Post(
                    string.Format(ENDPOINT_URL_CREATE, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId)), requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<PaymentAutoAllocate> Get(int paymentAutoAllocateId, int? monetaryAccountId = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        paymentAutoAllocateId), new Dictionary<string, string>(), customHeaders);

            return FromJson<PaymentAutoAllocate>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<PaymentAutoAllocate>> List(int? monetaryAccountId = null,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_LISTING, DetermineUserId(),
                        DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);

            return FromJsonList<PaymentAutoAllocate>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        /// <param name="definition">The definition of how the money should be allocated.</param>
        public static BunqResponse<int> Update(int paymentAutoAllocateId, int? monetaryAccountId = null,
            List<PaymentAutoAllocateDefinition> definition = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_DEFINITION, definition},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(
                    string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        paymentAutoAllocateId), requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<object> Delete(int paymentAutoAllocateId, int? monetaryAccountId = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Delete(
                    string.Format(ENDPOINT_URL_DELETE, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId),
                        paymentAutoAllocateId), customHeaders);

            return new BunqResponse<object>(null, responseRaw.Headers);
        }


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

            if (this.Type != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            if (this.TriggerAmount != null)
            {
                return false;
            }

            if (this.Payment != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static PaymentAutoAllocate CreateFromJsonString(string json)
        {
            return CreateFromJsonString<PaymentAutoAllocate>(json);
        }
    }
}