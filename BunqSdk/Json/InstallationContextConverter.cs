using System;
using Bunq.Sdk.Context;
using Bunq.Sdk.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bunq.Sdk.Json
{
    /// <summary>
    /// Custom (de)serialization of InstallationContext required due to presence in it of the encryption
    /// keys which should be formatted when serialized in a special way.
    /// </summary>
    public class InstallationContextConverter : JsonConverter
    {
        private const string FIELD_TOKEN = "token";
        private const string FIELD_PRIVATE_KEY_CLIENT = "private_key_client";
        private const string FIELD_PUBLIC_KEY_CLIENT = "public_key_client";
        private const string FIELD_PUBLIC_KEY_SERVER = "public_key_server";

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var installationContext = (InstallationContext) value;

            writer.WriteStartObject();

            writer.WritePropertyName(FIELD_TOKEN);
            serializer.Serialize(writer, installationContext.Token);

            writer.WritePropertyName(FIELD_PUBLIC_KEY_CLIENT);
            var clientPublicKeyString = SecurityUtils.GetPublicKeyFormattedString(installationContext.KeyPairClient);
            serializer.Serialize(writer, clientPublicKeyString);

            writer.WritePropertyName(FIELD_PRIVATE_KEY_CLIENT);
            var clientPrivateKeyString = SecurityUtils.GetPrivateKeyFormattedString(installationContext.KeyPairClient);
            serializer.Serialize(writer, clientPrivateKeyString);

            writer.WritePropertyName(FIELD_PUBLIC_KEY_SERVER);
            var serverPublicKeyString = SecurityUtils.GetPublicKeyFormattedString(installationContext.PublicKeyServer);
            serializer.Serialize(writer, serverPublicKeyString);

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var installationToken = jObject.GetValue(FIELD_TOKEN).ToString();
            var privateKeyClientString = jObject.GetValue(FIELD_PRIVATE_KEY_CLIENT).ToString();
            var keyPairClient = SecurityUtils.CreateKeyPairFromPrivateKeyFormattedString(privateKeyClientString);
            var publicKeyServerString = jObject.GetValue(FIELD_PUBLIC_KEY_SERVER).ToString();
            var publicKeyServer = SecurityUtils.CreatePublicKeyFromPublicKeyFormattedString(publicKeyServerString);

            return new InstallationContext(installationToken, keyPairClient, publicKeyServer);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(InstallationContext);
        }
    }
}
