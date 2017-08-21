using System;
using System.Collections.Generic;
using Bunq.Sdk.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bunq.Sdk.Json
{
    /// <summary>
    /// Custom (de)serialization of Installation required due to the unconventional structure of the
    /// Installation POST response.
    /// </summary>
    public class InstallationConverter : JsonConverter
    {
        private const int INDEX_ID = 0;
        private const string FIELD_ID = "Id";

        private const int INDEX_TOKEN = 1;
        private const string FIELD_TOKEN = "Token";

        private const int INDEX_SERVER_PUBLIC_KEY = 2;
        private const string FIELD_SERVER_PUBLIC_KEY = "ServerPublicKey";

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jObjects = JArray.Load(reader).ToObject<List<JObject>>();
            var id = FetchObject<Id>(jObjects[INDEX_ID], FIELD_ID);
            var token = FetchObject<SessionToken>(jObjects[INDEX_TOKEN], FIELD_TOKEN);
            var publicKeyServer =
                FetchObject<PublicKeyServer>(jObjects[INDEX_SERVER_PUBLIC_KEY], FIELD_SERVER_PUBLIC_KEY);

            return new Installation(id, token, publicKeyServer);
        }

        private static T FetchObject<T>(JToken jToken, string fieldName)
        {
            return jToken[fieldName].ToObject<T>();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Installation);
        }
    }
}
