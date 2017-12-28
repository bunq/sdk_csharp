using System;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bunq.Sdk.Json
{
    /// <inheritdoc />
    /// <summary>
    /// Custom (de)serialization of SessionServer required due to the unconventional structure of the
    /// SessionServer POST response.
    /// </summary>
    public class SessionServerConverter : JsonConverter
    {
        /// <summary>
        /// The indices of the attributes inside the json object.
        /// </summary>
        private const int IndexId = 0;
        private const int IndexUser = 2;
        private const int IndexToken = 1;

        /// <summary>
        /// Field constantss.
        /// </summary>
        private const string FieldId = "Id";
        private const string FieldToken = "Token";
        private const string FieldUserCompany = "UserCompany";
        private const string FieldUserPerson = "UserPerson";

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jObjects = JArray.Load(reader);
            var id = FetchObject<Id>(jObjects[IndexId], FieldId);
            var token = FetchObject<SessionToken>(jObjects[IndexToken], FieldToken);
            var userBody = jObjects[IndexUser];

            return userBody[FieldUserCompany] == null
                ? new SessionServer(id, token, FetchObject<UserPerson>(userBody, FieldUserPerson))
                : new SessionServer(id, token, FetchObject<UserCompany>(userBody, FieldUserCompany));
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
