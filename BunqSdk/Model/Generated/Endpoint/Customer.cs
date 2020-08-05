using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    ///     Used to view a customer.
    /// </summary>
    public class Customer : BunqModel
    {
        /// <summary>
        ///     Field constants.
        /// </summary>
        public const string FIELD_BILLING_ACCOUNT_ID = "billing_account_id";

        public const string FIELD_INVOICE_NOTIFICATION_PREFERENCE = "invoice_notification_preference";


        /// <summary>
        ///     The primary billing account account's id.
        /// </summary>
        [JsonProperty(PropertyName = "billing_account_id")]
        public string BillingAccountId { get; set; }

        /// <summary>
        ///     The preferred notification type for invoices.
        /// </summary>
        [JsonProperty(PropertyName = "invoice_notification_preference")]
        public string InvoiceNotificationPreference { get; set; }

        /// <summary>
        ///     The id of the customer.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        ///     The timestamp of the customer object's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        ///     The timestamp of the customer object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Id != null) return false;

            if (Created != null) return false;

            if (Updated != null) return false;

            if (BillingAccountId != null) return false;

            if (InvoiceNotificationPreference != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static Customer CreateFromJsonString(string json)
        {
            return CreateFromJsonString<Customer>(json);
        }
    }
}