using System;
using System.Collections.Generic;
using System.Reflection;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Bunq.Sdk.Json
{
    /// <inheritdoc />
    /// <summary>
    /// Custom mapping of types to JSON converters.
    /// </summary>
    public class BunqContractResolver : DefaultContractResolver
    {
        private readonly Dictionary<Type, JsonConverter> converterRegistry = new Dictionary<Type, JsonConverter>();

        public BunqContractResolver(IReadOnlyCollection<Type> typesToExclude=null)
        {
            RegisterConverter(typeof(ApiEnvironmentType), new ApiEnvironmentTypeConverter());
            RegisterConverter(typeof(Geolocation), new GeolocationConverter());
            RegisterConverter(typeof(InstallationContext), new InstallationContextConverter());
            RegisterConverter(typeof(Installation), new InstallationConverter());
            RegisterConverter(typeof(MonetaryAccountReference), new MonetaryAccountReferenceConverter());
            RegisterConverter(typeof(SessionServer), new SessionServerConverter());
            RegisterConverter(typeof(decimal?), new NonIntegerNumberConverter());
            RegisterConverter(typeof(double?), new NonIntegerNumberConverter());
            RegisterConverter(typeof(float?), new NonIntegerNumberConverter());
            RegisterConverter(typeof(Pagination), new PaginationConverter());
            RegisterConverter(typeof(IAnchorObjectInterface), new AnchorObjectConverter());

            if (typesToExclude == null)
            {
                return;                
            }
            
            foreach (var type in typesToExclude)
            {
                converterRegistry.Remove(type);
            }
        }

        private void RegisterConverter(Type objectType, JsonConverter converter)
        {
            converterRegistry.Add(objectType, converter);
        }

        protected override JsonContract CreateContract(Type objectType)
        {
            var contract = base.CreateContract(objectType);
            var customConverter = GetCustomConverterOrNull(objectType);

            if (customConverter != null)
            {
                contract.Converter = customConverter;
            }

            return contract;
        }

        private JsonConverter GetCustomConverterOrNull(Type objectType)
        {
            if (typeof(IAnchorObjectInterface).IsAssignableFrom(objectType))
            {
                return converterRegistry.ContainsKey(typeof(IAnchorObjectInterface))
                    ? converterRegistry[typeof(IAnchorObjectInterface)]
                    : null;
            }
            
            return converterRegistry.ContainsKey(objectType) ? converterRegistry[objectType] : null;
        }
    }
}
