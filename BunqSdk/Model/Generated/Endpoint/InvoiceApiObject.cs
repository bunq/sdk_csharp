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
    /// Used to view a bunq invoice.
    /// </summary>
    public class InvoiceApiObject : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/monetary-account/{1}/invoice/{2}";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/monetary-account/{1}/invoice";
    
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_STATUS = "status";
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_EXTERNAL_URL = "external_url";
    
        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "Invoice";
    
        /// <summary>
        /// The invoice status.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The description provided by the admin.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        /// <summary>
        /// The external url provided by the admin.
        /// </summary>
        [JsonProperty(PropertyName = "external_url")]
        public string ExternalUrl { get; set; }
        /// <summary>
        /// The id of the invoice object.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }
        /// <summary>
        /// The timestamp of the invoice object's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }
        /// <summary>
        /// The timestamp of the invoice object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }
        /// <summary>
        /// The invoice date.
        /// </summary>
        [JsonProperty(PropertyName = "invoice_date")]
        public string InvoiceDate { get; set; }
        /// <summary>
        /// The invoice number.
        /// </summary>
        [JsonProperty(PropertyName = "invoice_number")]
        public string InvoiceNumber { get; set; }
        /// <summary>
        /// The category to display to the user.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
        /// <summary>
        /// The invoice item groups.
        /// </summary>
        [JsonProperty(PropertyName = "group")]
        public List<InvoiceItemGroupObject> Group { get; set; }
        /// <summary>
        /// The total discounted item price including VAT.
        /// </summary>
        [JsonProperty(PropertyName = "total_vat_inclusive")]
        public AmountObject TotalVatInclusive { get; set; }
        /// <summary>
        /// The total discounted item price excluding VAT.
        /// </summary>
        [JsonProperty(PropertyName = "total_vat_exclusive")]
        public AmountObject TotalVatExclusive { get; set; }
        /// <summary>
        /// The VAT on the total discounted item price.
        /// </summary>
        [JsonProperty(PropertyName = "total_vat")]
        public AmountObject TotalVat { get; set; }
        /// <summary>
        /// The label that's displayed to the counterparty with the invoice. Includes user.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public MonetaryAccountReference Alias { get; set; }
        /// <summary>
        /// The customer's address.
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public AddressObject Address { get; set; }
        /// <summary>
        /// The label of the counterparty of the invoice. Includes user.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_alias")]
        public MonetaryAccountReference CounterpartyAlias { get; set; }
        /// <summary>
        /// The company's address.
        /// </summary>
        [JsonProperty(PropertyName = "counterparty_address")]
        public AddressObject CounterpartyAddress { get; set; }
        /// <summary>
        /// The company's chamber of commerce number.
        /// </summary>
        [JsonProperty(PropertyName = "chamber_of_commerce_number")]
        public string ChamberOfCommerceNumber { get; set; }
        /// <summary>
        /// The company's chamber of commerce number.
        /// </summary>
        [JsonProperty(PropertyName = "vat_number")]
        public string VatNumber { get; set; }
        /// <summary>
        /// The reference to the object used for split the bill. Can be RequestInquiry or RequestInquiryBatch
        /// </summary>
        [JsonProperty(PropertyName = "request_reference_split_the_bill")]
        public List<RequestInquiryReferenceObject> RequestReferenceSplitTheBill { get; set; }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<InvoiceApiObject> Get(long invoiceId, long? monetaryAccountId= null, IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_READ, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId), invoiceId), new Dictionary<string, string>(), customHeaders);
    
            return FromJson<InvoiceApiObject>(responseRaw, OBJECT_TYPE_GET);
        }
    
        /// <summary>
        /// </summary>
        public static BunqResponse<List<InvoiceApiObject>> List(long? monetaryAccountId= null, IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();
    
            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), DetermineMonetaryAccountId(monetaryAccountId)), urlParams, customHeaders);
    
            return FromJsonList<InvoiceApiObject>(responseRaw, OBJECT_TYPE_GET);
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
    
            if (this.InvoiceDate != null)
            {
                return false;
            }
    
            if (this.InvoiceNumber != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.Category != null)
            {
                return false;
            }
    
            if (this.Group != null)
            {
                return false;
            }
    
            if (this.TotalVatInclusive != null)
            {
                return false;
            }
    
            if (this.TotalVatExclusive != null)
            {
                return false;
            }
    
            if (this.TotalVat != null)
            {
                return false;
            }
    
            if (this.Alias != null)
            {
                return false;
            }
    
            if (this.Address != null)
            {
                return false;
            }
    
            if (this.CounterpartyAlias != null)
            {
                return false;
            }
    
            if (this.CounterpartyAddress != null)
            {
                return false;
            }
    
            if (this.ChamberOfCommerceNumber != null)
            {
                return false;
            }
    
            if (this.VatNumber != null)
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
        public static InvoiceApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<InvoiceApiObject>(json);
        }
    }
}
