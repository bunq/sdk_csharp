using Bunq.Sdk.Context;
using Bunq.Sdk.Exception;
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
    /// List a users automatic payment auto allocated settings.
    /// </summary>
    public class PaymentAutoAllocateUser : BunqModel, IAnchorObjectInterface
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ERROR_NULL_FIELDS = "All fields of an extended model or object are null.";

        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_LISTING = "user/{0}/payment-auto-allocate";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "PaymentAutoAllocate";

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PaymentAutoAllocate")]
        public PaymentAutoAllocate PaymentAutoAllocate { get; set; }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<PaymentAutoAllocateUser>> List(IDictionary<string, string> urlParams = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw = apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId()), urlParams,
                customHeaders);

            return FromJsonList<PaymentAutoAllocateUser>(responseRaw, OBJECT_TYPE_GET);
        }


        /// <summary>
        /// </summary>
        public BunqModel GetReferencedObject()
        {
            if (this.PaymentAutoAllocate != null)
            {
                return this.PaymentAutoAllocate;
            }

            throw new BunqException(ERROR_NULL_FIELDS);
        }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.PaymentAutoAllocate != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static PaymentAutoAllocateUser CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PaymentAutoAllocateUser>(json);
        }
    }
}