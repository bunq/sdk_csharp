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
        private const string FieldToken = "token";
        private const string FieldPrivateKeyClient = "private_key_client";
        private const string FieldPublicKeyClient = "public_key_client";
        private const string FieldPublicKeyServer = "public_key_server";

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var installationContext = (InstallationContext) value;

            writer.WriteStartObject();

            writer.WritePropertyName(FieldToken);
            serializer.Serialize(writer, installationContext.Token);

            writer.WritePropertyName(FieldPublicKeyClient);
            var clientPublicKeyString = SecurityUtils.GetPublicKeyFormattedString(installationContext.KeyPairClient);
            serializer.Serialize(writer, clientPublicKeyString);

            writer.WritePropertyName(FieldPrivateKeyClient);
            var clientPrivateKeyString = SecurityUtils.GetPrivateKeyFormattedString(installationContext.KeyPairClient);
            serializer.Serialize(writer, clientPrivateKeyString);

            writer.WritePropertyName(FieldPublicKeyServer);
            var serverPublicKeyString = SecurityUtils.GetPublicKeyFormattedString(installationContext.PublicKeyServer);
            serializer.Serialize(writer, serverPublicKeyString);

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var installationToken = jObject.GetValue(FieldToken).ToString();
            var privateKeyClientString = jObject.GetValue(FieldPrivateKeyClient).ToString();
            var keyPairClient = SecurityUtils.CreateKeyPairFromPrivateKeyFormattedString(privateKeyClientString);
            var publicKeyServerString = jObject.GetValue(FieldPublicKeyServer).ToString();
            var publicKeyServer = SecurityUtils.CreatePublicKeyFromPublicKeyFormattedString(publicKeyServerString);

            return new InstallationContext(installationToken, keyPairClient, publicKeyServer);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(InstallationContext);
        }
    }
}
