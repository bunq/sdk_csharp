﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bunq.Sdk.Json
{
    public class AnchorObjectConverter: JsonConverter
    {
        private const string FORMAT_DATE = "yyyy-MM-dd HH:mm:ss.ffffff";

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            new JsonSerializer().Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonSerializer = JsonSerializer.CreateDefault(
                new JsonSerializerSettings
                {
                    ContractResolver = new BunqContractResolver(new List<Type> {typeof(IAnchorObjectInterface)}),
                    DateFormatString = FORMAT_DATE,
                    FloatParseHandling = FloatParseHandling.Decimal,
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore,
                }
            );
            
            JToken token = JObject.Load(reader);
            var model = (IAnchorObjectInterface) jsonSerializer.Deserialize(token.CreateReader(), objectType);

            if (!model.IsAllFieldNull()) return model;
            
            var fields = objectType.GetTypeInfo().GetProperties();

            foreach (var field in fields)
            {
                var fieldType = field.PropertyType;
                    
                if (!typeof(BunqModel).GetTypeInfo().IsAssignableFrom(fieldType))
                {
                    continue;
                }
                
                var fieldContent = (BunqModel) jsonSerializer.Deserialize(token.CreateReader(), fieldType);

                field.SetValue(model, fieldContent.IsAllFieldNull() ? null : fieldContent);
            }

            return model;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IAnchorObjectInterface).GetTypeInfo().IsAssignableFrom(objectType);
        }
    }
}
