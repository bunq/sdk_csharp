using System.Collections.Generic;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    ///     Used to list bunq invoices by user.
    /// </summary>
    public class InvoiceByUser : BunqModel
    {
        /// <summary>
        ///     Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/invoice";

        protected const string ENDPOINT_URL_READ = "user/{0}/invoice/{1}";

        /// <summary>
        ///     Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "Invoice";

        /// <summary>
        ///     The id of the invoice object.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        ///     The timestamp of the invoice object's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        ///     The timestamp of the invoice object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        ///     The invoice date.
        /// </summary>
        [JsonProperty(PropertyName = "invoice_date")]
        public string InvoiceDate { get; set; }

        /// <summary>
        ///     The invoice number.
        /// </summary>
        [JsonProperty(PropertyName = "invoice_number")]
        public string InvoiceNumber { get; set; }

        /// <summary>
        ///     The invoice status.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        ///     The invoice item groups.
        /// </summary>
        [JsonProperty(PropertyName = "group")]
        public List<InvoiceItemGroup> Group { get; set; }

        /// <summary>
        ///     The total discounted item price including VAT.
        /// </summary>
        [JsonProperty(PropertyName = "total_vat_inclusive")]
        public Amount TotalVatInclusive { get; set; }

        /// <summary>
        ///     The total discounted item price excluding VAT.
        /// </summary>
        [JsonProperty(PropertyName = "total_vat_exclusive")]
        public Amount TotalVatExclusive { get; set; }

        /// <summary>
        ///     The VAT on the total discounted item price.
        /// </summary>
        [JsonProperty(PropertyName = "total_vat")]
        public Amount TotalVat { get; set; }

        /// <summary>
        ///     The label that's displayed to the counterparty with the invoice. Includes user.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }

        /// <summary>
        ///     The customer's address.
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        /// <summary>
        ///     The label of the counterparty of the invoice. Includes user.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }

        /// <summary>
        ///     The company's address.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_address")]
        public Address CounterpartyAddress { get; set; }

        /// <summary>
        ///     The company's chamber of commerce number.
        /// </summary>
        [JsonProperty(PropertyName = "chamber_of_commerce_number")]
        public string ChamberOfCommerceNumber { get; set; }

        /// <summary>
        ///     The company's chamber of commerce number.
        /// </summary>
        [JsonProperty(PropertyName = "vat_number")]
        public string VatNumber { get; set; }


        /// <summary>
        /// </summary>
        public static BunqResponse<List<InvoiceByUser>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<InvoiceByUser>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<InvoiceByUser> Get(int invoiceByUserId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), invoiceByUserId),
                new Dictionary<string, string>(), customHeaders);

            return FromJson<InvoiceByUser>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Id != null) return false;

            if (Created != null) return false;

            if (Updated != null) return false;

            if (InvoiceDate != null) return false;

            if (InvoiceNumber != null) return false;

            if (Status != null) return false;

            if (Group != null) return false;

            if (TotalVatInclusive != null) return false;

            if (TotalVatExclusive != null) return false;

            if (TotalVat != null) return false;

            if (Alias != null) return false;

            if (Address != null) return false;

            if (CounterpartyAlias != null) return false;

            if (CounterpartyAddress != null) return false;

            if (ChamberOfCommerceNumber != null) return false;

            if (VatNumber != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static InvoiceByUser CreateFromJsonString(string json)
        {
            return CreateFromJsonString<InvoiceByUser>(json);
        }
    }
}