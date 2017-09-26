using System;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bunq.Sdk.Json
{
    /// <summary>
    /// Custom (de)serialization of SessionServer required due to the unconventional structure of the
    /// SessionServer POST response.
    /// </summary>
    public class SessionServerConverter : JsonConverter
    {
        private const int INDEX_ID = 0;
        private const string FIELD_ID = "Id";

        private const int INDEX_TOKEN = 1;
        private const string FIELD_TOKEN = "Token";

        private const int INDEX_USER = 2;
        private const string FIELD_USER_COMPANY = "UserCompany";
        private const string FIELD_USER_PERSON = "UserPerson";

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jObjects = JArray.Load(reader);
            var id = FetchObject<Id>(jObjects[INDEX_ID], FIELD_ID);
            var token = FetchObject<SessionToken>(jObjects[INDEX_TOKEN], FIELD_TOKEN);
            var userBody = jObjects[INDEX_USER];

            return userBody[FIELD_USER_COMPANY] == null
                ? new SessionServer(id, token, FetchObject<UserPerson>(userBody, FIELD_USER_PERSON))
                : new SessionServer(id, token, FetchObject<UserCompany>(userBody, FIELD_USER_COMPANY));
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
            return objectType == typeof(SessionServer);
        }
    }
}
