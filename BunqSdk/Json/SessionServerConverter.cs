using System;
using Bunq.Sdk.Exception;
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
        private const string ErrorCouldNotDetermineUser = "Could not determine user.";

        private const int IndexId = 0;
        private const string FieldId = "Id";

        private const int IndexToken = 1;
        private const string FieldToken = "Token";

        private const int IndexUser = 2;
        private const string FieldUserApiKey = "UserApiKey";
        private const string FieldUserCompany = "UserCompany";
        private const string FieldUserPerson = "UserPerson";
        private const string FieldUserPaymentServiceProvider = "UserPaymentServiceProvider";

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jObjects = JArray.Load(reader);
            var id = FetchObject<Id>(jObjects[IndexId], FieldId);
            var token = FetchObject<SessionToken>(jObjects[IndexToken], FieldToken);
            var userBody = jObjects[IndexUser];

            if (userBody[FieldUserApiKey] != null)
            {
                return new SessionServer(id, token, FetchObject<UserApiKey>(userBody, FieldUserApiKey));
            }
            else if (userBody[FieldUserCompany] != null)
            {
                return new SessionServer(id, token, FetchObject<UserCompany>(userBody, FieldUserCompany));
            }
            else if (userBody[FieldUserPerson] != null)
            {
                return new SessionServer(id, token, FetchObject<UserPerson>(userBody, FieldUserPerson));
            }
            else if (userBody[FieldUserPaymentServiceProvider] != null)
            {
                return new SessionServer(id, token, FetchObject<UserPaymentServiceProvider>(
                    userBody,
                    FieldUserPaymentServiceProvider
                ));
            }
            else
            {
                throw new BunqException(ErrorCouldNotDetermineUser);
            }
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
