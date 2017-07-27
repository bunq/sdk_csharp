using System.Collections.Generic;
using System.Linq;
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
        /// De-serializes an object from a JSON format specific to Installation and SessionServer.
        /// </summary>
        protected static T FromJsonArrayNested<T>(string json)
        {
            var jObject = BunqJsonConvert.DeserializeObject<JObject>(json);
            var jsonArrayString = jObject.GetValue(FIELD_RESPONSE).ToString();

            return BunqJsonConvert.DeserializeObject<T>(jsonArrayString);
        }

        /// <summary>
        /// De-serializes an ID object and returns its integer value.
        /// </summary>
        protected static int ProcessForId(string json)
        {
            var responseContent = GetResponseContent(json);
            var jsonObjectString = GetWrappedContentString(responseContent, FIELD_ID);

            return BunqJsonConvert.DeserializeObject<Id>(jsonObjectString).IdInt;
        }

        private static JObject GetResponseContent(string json)
        {
            var responseWithWrapper = BunqJsonConvert.DeserializeObject<JObject>(json);

            return responseWithWrapper.GetValue(FIELD_RESPONSE).ToObject<JArray>().Value<JObject>(0);
        }

        private static string GetWrappedContentString(JObject json, string wrapper)
        {
            return json.GetValue(wrapper).ToString();
        }

        /// <summary>
        /// De-serializes an UUID object and returns its string value.
        /// </summary>
        protected static string ProcessForUuid(string json)
        {
            var responseContent = GetResponseContent(json);
            var jsonObjectString = GetWrappedContentString(responseContent, FIELD_UUID);

            return BunqJsonConvert.DeserializeObject<Uuid>(jsonObjectString).UuidString;
        }

        /// <summary>
        /// De-serialize an object from JSON.
        /// </summary>
        protected static T FromJson<T>(string json, string wrapper)
        {
            var responseContent = GetResponseContent(json);
            var objectContentString = GetWrappedContentString(responseContent, wrapper);

            return BunqJsonConvert.DeserializeObject<T>(objectContentString);
        }

        protected static T FromJson<T>(string json)
        {
            var responseContent = GetResponseContent(json);

            return BunqJsonConvert.DeserializeObject<T>(responseContent.ToString());
        }

        /// <summary>
        /// De-serializes a list from JSON.
        /// </summary>
        protected static List<T> FromJsonList<T>(string json, string wrapper)
        {
            var responseObjectsArray = GetResponseContentArray(json);

            return responseObjectsArray
                .Select(objectContentWithWrapper =>
                    GetWrappedContentString(objectContentWithWrapper.ToObject<JObject>(), wrapper))
                .Select(BunqJsonConvert.DeserializeObject<T>).ToList();
        }

        protected static List<T> FromJsonList<T>(string json)
        {
            var responseObjectsArray = GetResponseContentArray(json);

            return responseObjectsArray
                .Select(objectContent => BunqJsonConvert.DeserializeObject<T>(objectContent.ToString()))
                .ToList();
        }

        private static JArray GetResponseContentArray(string json)
        {
            var responseWithWrapper = BunqJsonConvert.DeserializeObject<JObject>(json);

            return responseWithWrapper.GetValue(FIELD_RESPONSE).ToObject<JArray>();
        }

        public override string ToString()
        {
            return BunqJsonConvert.SerializeObject(this);
        }
    }
}
