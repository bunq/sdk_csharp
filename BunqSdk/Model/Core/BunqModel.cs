using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Newtonsoft.Json.Linq;

namespace Bunq.Sdk.Model.Core
{
    public abstract class BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        private const string FIELD_RESPONSE = "Response";

        private const string FIELD_ID = "Id";
        private const string FIELD_UUID = "Uuid";
        private const string FIELD_PAGINATION = "Pagination";

        /// <summary>
        /// Index of the very first item in an array.
        /// </summary>
        private const int INDEX_FIRST = 0;

        /// <summary>
        /// De-serializes an object from a JSON format specific to Installation and SessionServer.
        /// </summary>
        protected static BunqResponse<T> FromJsonArrayNested<T>(BunqResponseRaw responseRaw)
        {
            var json = Encoding.UTF8.GetString(responseRaw.BodyBytes);
            var jObject = BunqJsonConvert.DeserializeObject<JObject>(json);
            var jsonArrayString = jObject.GetValue(FIELD_RESPONSE).ToString();
            var responseValue = BunqJsonConvert.DeserializeObject<T>(jsonArrayString);

            return new BunqResponse<T>(responseValue, responseRaw.Headers);
        }

        /// <summary>
        /// De-serializes an ID object and returns its integer value.
        /// </summary>
        protected static BunqResponse<int> ProcessForId(BunqResponseRaw responseRaw)
        {
            var responseItemObject = GetResponseItemObject(responseRaw);
            var unwrappedItemJsonString = GetUnwrappedItemJsonString(responseItemObject, FIELD_ID);
            var responseValue = BunqJsonConvert.DeserializeObject<Id>(unwrappedItemJsonString).IdInt;

            return new BunqResponse<int>(responseValue, responseRaw.Headers);
        }

        private static JObject GetResponseItemObject(BunqResponseRaw responseRaw)
        {
            var json = Encoding.UTF8.GetString(responseRaw.BodyBytes);
            var responseWithWrapper = BunqJsonConvert.DeserializeObject<JObject>(json);

            return responseWithWrapper.GetValue(FIELD_RESPONSE).ToObject<JArray>().Value<JObject>(INDEX_FIRST);
        }

        private static string GetUnwrappedItemJsonString(JObject json, string wrapper)
        {
            return json.GetValue(wrapper).ToString();
        }

        /// <summary>
        /// De-serializes an UUID object and returns its string value.
        /// </summary>
        protected static BunqResponse<string> ProcessForUuid(BunqResponseRaw responseRaw)
        {
            var responseItemObject = GetResponseItemObject(responseRaw);
            var unwrappedItemJsonString = GetUnwrappedItemJsonString(responseItemObject, FIELD_UUID);
            var responseValue = BunqJsonConvert.DeserializeObject<Uuid>(unwrappedItemJsonString).UuidString;

            return new BunqResponse<string>(responseValue, responseRaw.Headers);
        }

        /// <summary>
        /// De-serialize an object from JSON.
        /// </summary>
        protected static BunqResponse<T> FromJson<T>(BunqResponseRaw responseRaw, string wrapper)
        {
            var responseItemObject = GetResponseItemObject(responseRaw);
            var unwrappedItemJsonString = GetUnwrappedItemJsonString(responseItemObject, wrapper);
            var responseValue = BunqJsonConvert.DeserializeObject<T>(unwrappedItemJsonString);

            return new BunqResponse<T>(responseValue, responseRaw.Headers);
        }

        protected static BunqResponse<T> FromJson<T>(BunqResponseRaw responseRaw)
        {
            var responseItemObject = GetResponseItemObject(responseRaw);
            var responseValue = BunqJsonConvert.DeserializeObject<T>(responseItemObject.ToString());

            return new BunqResponse<T>(responseValue, responseRaw.Headers);
        }

        public static T CreateFromJsonString<T>(string json)
        {
            var modelValue = BunqJsonConvert.DeserializeObject<T>(json);

            return modelValue;
        }

        /// <summary>
        /// De-serializes a list from JSON.
        /// </summary>
        protected static BunqResponse<List<T>> FromJsonList<T>(BunqResponseRaw responseRaw, string wrapper)
        {
            var responseObject = DeserializeResponseObject(responseRaw);
            var responseValue = responseObject
                .GetValue(FIELD_RESPONSE).ToObject<JArray>()
                .Select(unwrappedItemObject =>
                    GetUnwrappedItemJsonString(unwrappedItemObject.ToObject<JObject>(), wrapper))
                .Select(BunqJsonConvert.DeserializeObject<T>)
                .ToList();
            var pagination = DeserializePagination(responseObject);

            return new BunqResponse<List<T>>(responseValue, responseRaw.Headers, pagination);
        }

        protected static BunqResponse<List<T>> FromJsonList<T>(BunqResponseRaw responseRaw)
        {
            var responseObject = DeserializeResponseObject(responseRaw);
            var responseValue = responseObject
                .GetValue(FIELD_RESPONSE).ToObject<JArray>()
                .Select(itemObject => BunqJsonConvert.DeserializeObject<T>(itemObject.ToString()))
                .ToList();
            var pagination = DeserializePagination(responseObject);

            return new BunqResponse<List<T>>(responseValue, responseRaw.Headers, pagination);
        }

        private static Pagination DeserializePagination(JObject responseObject)
        {
            var paginationBody = responseObject.GetValue(FIELD_PAGINATION).ToString();

            return BunqJsonConvert.DeserializeObject<Pagination>(paginationBody);
        }

        private static JObject DeserializeResponseObject(BunqResponseRaw responseRaw)
        {
            var json = Encoding.UTF8.GetString(responseRaw.BodyBytes);

            return BunqJsonConvert.DeserializeObject<JObject>(json);
        }

        public override string ToString()
        {
            return BunqJsonConvert.SerializeObject(this);
        }

        public abstract bool IsAllFieldNull();

        protected static ApiContext GetApiContext()
        {
            return BunqContext.ApiContext;
        }

        protected static int DetermineUserId()
        {
            return BunqContext.UserContext.UserId;
        }

        protected static int DetermineMonetaryAccountId(int? monetaryAccountId = null)
        {
            return monetaryAccountId ?? BunqContext.UserContext.PrimaryMonetaryAccountBank.Id.Value;
        }
    }
}