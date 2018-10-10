using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to view a customer.
    /// </summary>
    public class Customer : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/customer";

        protected const string ENDPOINT_URL_READ = "user/{0}/customer/{1}";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/customer/{1}";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_BILLING_ACCOUNT_ID = "billing_account_id";

        public const string FIELD_INVOICE_NOTIFICATION_PREFERENCE = "invoice_notification_preference";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "Customer";

        /// <summary>
        /// The primary billing account account's id.
        /// </summary>
        [JsonProperty(PropertyName = "billing_account_id")]
        public string BillingAccountId { get; set; }

        /// <summary>
        /// The preferred notification type for invoices.
        /// </summary>
        [JsonProperty(PropertyName = "invoice_notification_preference")]
        public string InvoiceNotificationPreference { get; set; }

        /// <summary>
        /// The id of the customer.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the customer object's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the customer object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<Customer>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<Customer>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<Customer> Get(int customerId, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), customerId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<Customer>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        /// <param name="billingAccountId">The primary billing account account's id.</param>
        /// <param name="invoiceNotificationPreference">The preferred notification type for invoices</param>
        public static BunqResponse<int> Update(int customerId, string billingAccountId = null,
            string invoiceNotificationPreference = null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_BILLING_ACCOUNT_ID, billingAccountId},
                {FIELD_INVOICE_NOTIFICATION_PREFERENCE, invoiceNotificationPreference},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Put(string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), customerId),
                requestBytes, customHeaders);

            return ProcessForId(responseRaw);
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

            if (this.BillingAccountId != null)
            {
                return false;
            }

            if (this.InvoiceNotificationPreference != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static Customer CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Customer>(json);
        }
    }
}