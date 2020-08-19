using System;
using System.Collections.Generic;
using System.Linq;
using Bunq.Sdk.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bunq.Sdk.Json
{
    /// <summary>
    /// Custom (de)serialization of SessionServer required due to the unconventional structure of the
    /// SessionServer POST response.
    /// </summary>
    public class PaginationConverter : JsonConverter
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        private const string FIELD_OLDER_URL = "older_url";
        private const string FIELD_NEWER_URL = "newer_url";
        private const string FIELD_FUTURE_URL = "future_url";

        /// <summary>
        /// Indices of param key and value after parsing.
        /// </summary>
        private const int INDEX_PARAM_KEY = 0;
        private const int INDEX_PARAM_VALUE = 1;

        /// <summary>
        /// Base dummy URL to hack through the incomplete relative URI functionality of dotnetcore.
        /// </summary>
        private const string URI_BASE_DUMMY = "https://example.com";

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var responseJson = JObject.Load(reader);
            var paginationBody = ParsePaginationBody(responseJson);

            return new Pagination
            {
                OlderId = GetValueOrNull(paginationBody, Pagination.PARAM_OLDER_ID),
                NewerId = GetValueOrNull(paginationBody, Pagination.PARAM_NEWER_ID),
                FutureId = GetValueOrNull(paginationBody, Pagination.PARAM_FUTURE_ID),
                Count = GetValueOrNull(paginationBody, Pagination.PARAM_COUNT),
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
                Pagination.PARAM_OLDER_ID,
                responseJson,
                FIELD_OLDER_URL,
                Pagination.PARAM_OLDER_ID
            );
            UpdatePaginationBodyFromResponseField(
                paginationBody,
                Pagination.PARAM_NEWER_ID,
                responseJson,
                FIELD_NEWER_URL,
                Pagination.PARAM_NEWER_ID
            );
            UpdatePaginationBodyFromResponseField(
                paginationBody,
                Pagination.PARAM_FUTURE_ID,
                responseJson,
                FIELD_FUTURE_URL,
                Pagination.PARAM_NEWER_ID
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
                else if (Pagination.PARAM_COUNT.Equals(param.Key) &&
                         !paginationBody.ContainsKey(Pagination.PARAM_COUNT))
                {
                    paginationBody[Pagination.PARAM_COUNT] = int.Parse(param.Value);
                }
            }
        }

        private static IDictionary<string, string> ParseUriParams(JToken uriToken)
        {
            if (uriToken == null) return new Dictionary<string, string>();

            return new Uri(URI_BASE_DUMMY + uriToken).Query
                .TrimStart(ApiClient.DELIMITER_URI_QUERY)
                .Split(ApiClient.DELIMITER_URI_PARAMS)
                .Select(param => param.Split(ApiClient.DELIMITER_URI_PARAM_KEY_VALUE))
                .ToDictionary(pair => pair[INDEX_PARAM_KEY], pair => pair[INDEX_PARAM_VALUE]);
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