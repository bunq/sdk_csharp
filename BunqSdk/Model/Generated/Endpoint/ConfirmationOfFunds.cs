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
    /// Used to confirm availability of funds on an account.
    /// </summary>
    public class ConfirmationOfFunds : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_CREATE = "user/{0}/confirmation-of-funds";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_POINTER_IBAN = "pointer_iban";

        public const string FIELD_AMOUNT = "amount";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_POST = "ConfirmationOfFunds";

        /// <summary>
        /// The pointer (IBAN) of the account we're querying.
        /// </summary>
        [JsonProperty(PropertyName = "pointer_iban")]
        public MonetaryAccountReference PointerIban { get; set; }

        /// <summary>
        /// The amount we want to check for.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }

        /// <summary>
        /// Whether the account has sufficient funds.
        /// </summary>
        [JsonProperty(PropertyName = "has_sufficient_funds")]
        public bool? HasSufficientFunds { get; set; }


        /// <summary>
        /// </summary>
        /// <param name="pointerIban">The pointer (IBAN) of the account we're querying.</param>
        /// <param name="amount">The amount we want to check for.</param>
        public static BunqResponse<ConfirmationOfFunds> Create(Pointer pointerIban, Amount amount,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_POINTER_IBAN, pointerIban},
                {FIELD_AMOUNT, amount},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw = apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId()), requestBytes,
                customHeaders);

            return FromJson<ConfirmationOfFunds>(responseRaw, OBJECT_TYPE_POST);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.HasSufficientFunds != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static ConfirmationOfFunds CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<ConfirmationOfFunds>(json);
        }
    }
}