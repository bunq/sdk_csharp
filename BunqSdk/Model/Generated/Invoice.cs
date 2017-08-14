using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Used to view a bunq invoice.
    /// </summary>
    public class Invoice : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_EXTERNAL_URL = "external_url";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        private const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/invoice";
        private const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/invoice/{2}";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "Invoice";

        /// <summary>
        /// The id of the invoice object.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }

        /// <summary>
        /// The timestamp of the invoice object's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }

        /// <summary>
        /// The timestamp of the invoice object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }

        /// <summary>
        /// The invoice date.
        /// </summary>
        [JsonProperty(PropertyName = "invoice_date")]
        public string InvoiceDate { get; private set; }

        /// <summary>
        /// The invoice number.
        /// </summary>
        [JsonProperty(PropertyName = "invoice_number")]
        public string InvoiceNumber { get; private set; }

        /// <summary>
        /// The invoice status.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }

        /// <summary>
        /// The invoice item groups.
        /// </summary>
        [JsonProperty(PropertyName = "group")]
        public List<InvoiceItemGroup> Group { get; private set; }

        /// <summary>
        /// The total discounted item price including VAT.
        /// </summary>
        [JsonProperty(PropertyName = "total_vat_inclusive")]
        public Amount TotalVatInclusive { get; private set; }

        /// <summary>
        /// The total discounted item price excluding VAT.
        /// </summary>
        [JsonProperty(PropertyName = "total_vat_exclusive")]
        public Amount TotalVatExclusive { get; private set; }

        /// <summary>
        /// The VAT on the total discounted item price.
        /// </summary>
        [JsonProperty(PropertyName = "total_vat")]
        public Amount TotalVat { get; private set; }

        /// <summary>
        /// The label that's displayed to the counterparty with the invoice. Includes user.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; private set; }

        /// <summary>
        /// The customer's address.
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public Address Address { get; private set; }

        /// <summary>
        /// The label of the counterparty of the invoice. Includes user.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; private set; }

        /// <summary>
        /// The company's address.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_address")]
        public Address CounterpartyAddress { get; private set; }

        /// <summary>
        /// The company's chamber of commerce number.
        /// </summary>
        [JsonProperty(PropertyName = "chamber_of_commerce_number")]
        public string ChamberOfCommerceNumber { get; private set; }

        /// <summary>
        /// The company's chamber of commerce number.
        /// </summary>
        [JsonProperty(PropertyName = "vat_number")]
        public string VatNumber { get; private set; }

        public static BunqResponse<List<Invoice>> List(ApiContext apiContext, int userId, int monetaryAccountId)
        {
            return List(apiContext, userId, monetaryAccountId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<Invoice>> List(ApiContext apiContext, int userId, int monetaryAccountId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, userId, monetaryAccountId),
                customHeaders);

            return FromJsonList<Invoice>(responseRaw, OBJECT_TYPE);
        }

        public static BunqResponse<Invoice> Get(ApiContext apiContext, int userId, int monetaryAccountId, int invoiceId)
        {
            return Get(apiContext, userId, monetaryAccountId, invoiceId, new Dictionary<string, string>());
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<Invoice> Get(ApiContext apiContext, int userId, int monetaryAccountId, int invoiceId,
            IDictionary<string, string> customHeaders)
        {
            var apiClient = new ApiClient(apiContext);
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, userId, monetaryAccountId, invoiceId),
                customHeaders);

            return FromJson<Invoice>(responseRaw, OBJECT_TYPE);
        }
    }
}
