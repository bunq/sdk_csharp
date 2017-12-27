using System;
using System.Collections.Generic;
using Bunq.Sdk.Model.Core;
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
        private const int IndexId = 0;
        private const string FieldId = "Id";

        private const int IndexToken = 1;
        private const string FieldToken = "Token";

        private const int IndexServerPublicKey = 2;
        private const string FieldServerPublicKey = "ServerPublicKey";

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jObjects = JArray.Load(reader).ToObject<List<JObject>>();
            var id = FetchObject<Id>(jObjects[IndexId], FieldId);
            var token = FetchObject<SessionToken>(jObjects[IndexToken], FieldToken);
            var publicKeyServer =
                FetchObject<PublicKeyServer>(jObjects[IndexServerPublicKey], FieldServerPublicKey);

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
