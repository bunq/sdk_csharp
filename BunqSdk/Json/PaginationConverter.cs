using System;
using System.Collections.Generic;
using System.Linq;
using Bunq.Sdk.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bunq.Sdk.Json
{
    /// <inheritdoc />
    /// <summary>
    /// Custom (de)serialization of SessionServer required due to the unconventional structure of the
    /// SessionServer POST response.
    /// </summary>
    public class PaginationConverter : JsonConverter
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        private const string FieldOlderUrl = "older_url";
        private const string FieldNewerUrl = "newer_url";
        private const string FieldFutureUrl = "future_url";

        /// <summary>
        /// Indices of param key and value after parsing.
        /// </summary>
        private const int IndexParamKey = 0;
        private const int IndexParamValue = 1;

        /// <summary>
        /// Base dummy URL to hack through the incomplete relative URI functionality of dotnetcore.
        /// </summary>
        private const string UriBaseDummy = "https://example.com";

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var responseJson = JObject.Load(reader);
            var paginationBody = ParsePaginationBody(responseJson);

            return new Pagination
            {
                OlderId = GetValueOrNull(paginationBody, Pagination.ParamOlderId),
                NewerId = GetValueOrNull(paginationBody, Pagination.ParamNewerId),
                FutureId = GetValueOrNull(paginationBody, Pagination.ParamFutureId),
                Count = GetValueOrNull(paginationBody, Pagination.ParamCount),
            };
        }

        private static T GetValueOrNull<T>(IDictionary<string, T> dictionary, string key)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : default(T);
        }

        private static IDictionary<string, int?> ParsePaginationBody(JObject responseJson)
        {
            var paginationBody = new Dictionary<string, int?>();
            UpdatePaginationBodyFromResponseField(
                paginationBody,
                Pagination.ParamOlderId,
                responseJson,
                FieldOlderUrl,
                Pagination.ParamOlderId
            );
            UpdatePaginationBodyFromResponseField(
                paginationBody,
                Pagination.ParamNewerId,
                responseJson,
                FieldNewerUrl,
                Pagination.ParamNewerId
            );
            UpdatePaginationBodyFromResponseField(
                paginationBody,
                Pagination.ParamFutureId,
                responseJson,
                FieldFutureUrl,
                Pagination.ParamNewerId
            );

            return paginationBody;
        }

        private static void UpdatePaginationBodyFromResponseField(IDictionary<string, int?> paginationBody,
            string idField, JObject responseJson, string responseField, string responseParam)
        {
            var responseToken = responseJson[responseField];

            if (responseToken == null || responseToken.Value<string>() == null) return;

            foreach (var param in ParseUriParams(responseToken))
            {
                if (responseParam.Equals(param.Key))
                {
                    paginationBody[idField] = int.Parse(param.Value);
                }
                else if (Pagination.ParamCount.Equals(param.Key) &&
                    !paginationBody.ContainsKey(Pagination.ParamCount))
                {
                    paginationBody[Pagination.ParamCount] = int.Parse(param.Value);
                }
            }
        }

        private static IDictionary<string, string> ParseUriParams(JToken uriToken)
        {
            if (uriToken == null) return new Dictionary<string, string>();

            return new Uri(UriBaseDummy + uriToken).Query
                .TrimStart(ApiClient.DelimiterUriQuery)
                .Split(ApiClient.DelimiterAllUriParameter)
                .Select(param => param.Split(ApiClient.DelimiterUriParamKeyValue))
                .ToDictionary(pair => pair[IndexParamKey], pair => pair[IndexParamValue]);
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
            return objectType == typeof(Pagination);
        }
    }
}
