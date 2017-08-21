using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Newtonsoft.Json.Linq;

namespace Bunq.Sdk.Model
{
    public abstract class BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        private const string FIELD_RESPONSE = "Response";
        private const string FIELD_ID = "Id";
        private const string FIELD_UUID = "Uuid";

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
            var responseContent = GetResponseContent(responseRaw);
            var jsonObjectString = GetWrappedContentString(responseContent, FIELD_ID);
            var responseValue = BunqJsonConvert.DeserializeObject<Id>(jsonObjectString).IdInt;

            return new BunqResponse<int>(responseValue, responseRaw.Headers);
        }

        private static JObject GetResponseContent(BunqResponseRaw responseRaw)
        {
            var json = Encoding.UTF8.GetString(responseRaw.BodyBytes);
            var responseWithWrapper = BunqJsonConvert.DeserializeObject<JObject>(json);

            return responseWithWrapper.GetValue(FIELD_RESPONSE).ToObject<JArray>().Value<JObject>(INDEX_FIRST);
        }

        private static string GetWrappedContentString(JObject json, string wrapper)
        {
            return json.GetValue(wrapper).ToString();
        }

        /// <summary>
        /// De-serializes an UUID object and returns its string value.
        /// </summary>
        protected static BunqResponse<string> ProcessForUuid(BunqResponseRaw responseRaw)
        {
            var responseContent = GetResponseContent(responseRaw);
            var jsonObjectString = GetWrappedContentString(responseContent, FIELD_UUID);
            var responseValue = BunqJsonConvert.DeserializeObject<Uuid>(jsonObjectString).UuidString;

            return new BunqResponse<string>(responseValue, responseRaw.Headers);
        }

        /// <summary>
        /// De-serialize an object from JSON.
        /// </summary>
        protected static BunqResponse<T> FromJson<T>(BunqResponseRaw responseRaw, string wrapper)
        {
            var responseContent = GetResponseContent(responseRaw);
            var objectContentString = GetWrappedContentString(responseContent, wrapper);
            var responseValue = BunqJsonConvert.DeserializeObject<T>(objectContentString);

            return new BunqResponse<T>(responseValue, responseRaw.Headers);
        }

        protected static BunqResponse<T> FromJson<T>(BunqResponseRaw responseRaw)
        {
            var responseContent = GetResponseContent(responseRaw);
            var responseValue = BunqJsonConvert.DeserializeObject<T>(responseContent.ToString());

            return new BunqResponse<T>(responseValue, responseRaw.Headers);
        }

        /// <summary>
        /// De-serializes a list from JSON.
        /// </summary>
        protected static BunqResponse<List<T>> FromJsonList<T>(BunqResponseRaw responseRaw, string wrapper)
        {
            var responseObjectsArray = GetResponseContentArray(responseRaw);
            var responseValue = responseObjectsArray
                .Select(objectContentWithWrapper =>
                    GetWrappedContentString(objectContentWithWrapper.ToObject<JObject>(), wrapper))
                .Select(BunqJsonConvert.DeserializeObject<T>).ToList();

            return new BunqResponse<List<T>>(responseValue, responseRaw.Headers);
        }

        protected static BunqResponse<List<T>> FromJsonList<T>(BunqResponseRaw responseRaw)
        {
            var responseObjectsArray = GetResponseContentArray(responseRaw);
            var responseValue = responseObjectsArray
                .Select(objectContent => BunqJsonConvert.DeserializeObject<T>(objectContent.ToString()))
                .ToList();

            return new BunqResponse<List<T>>(responseValue, responseRaw.Headers);
        }

        private static JArray GetResponseContentArray(BunqResponseRaw responseRaw)
        {
            var json = Encoding.UTF8.GetString(responseRaw.BodyBytes);
            var responseWithWrapper = BunqJsonConvert.DeserializeObject<JObject>(json);

            return responseWithWrapper.GetValue(FIELD_RESPONSE).ToObject<JArray>();
        }

        public override string ToString()
        {
            return BunqJsonConvert.SerializeObject(this);
        }
    }
}
