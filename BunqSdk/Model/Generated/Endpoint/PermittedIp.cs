using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Manage the IPs which may be used for a credential of a user for server authentication.
    /// </summary>
    public class PermittedIp : BunqModel
    {
        /// <summary>
        /// Endpoint constants.
        /// </summary>
        protected const string ENDPOINT_URL_READ = "user/{0}/credential-password-ip/{1}/ip/{2}";

        protected const string ENDPOINT_URL_CREATE = "user/{0}/credential-password-ip/{1}/ip";
        protected const string ENDPOINT_URL_LISTING = "user/{0}/credential-password-ip/{1}/ip";
        protected const string ENDPOINT_URL_UPDATE = "user/{0}/credential-password-ip/{1}/ip/{2}";

        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_IP = "ip";

        public const string FIELD_STATUS = "status";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE_GET = "PermittedIp";

        /// <summary>
        /// The IP address.
        /// </summary>
        [JsonProperty(PropertyName = "ip")]
        public string Ip { get; set; }

        /// <summary>
        /// The status of the IP. May be "ACTIVE" or "INACTIVE". It is only possible to make requests from "ACTIVE" IP
        /// addresses. Only "ACTIVE" IPs will be billed.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }


        /// <summary>
        /// </summary>
        public static BunqResponse<PermittedIp> Get(int credentialPasswordIpId, int permittedIpId,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(
                    string.Format(ENDPOINT_URL_READ, DetermineUserId(), credentialPasswordIpId, permittedIpId),
                    new Dictionary<string, string>(), customHeaders);

            return FromJson<PermittedIp>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        /// <param name="ip">The IP address.</param>
        /// <param name="status">The status of the IP. May be "ACTIVE" or "INACTIVE". It is only possible to make requests from "ACTIVE" IP addresses. Only "ACTIVE" IPs will be billed.</param>
        public static BunqResponse<int> Create(int credentialPasswordIpId, string ip, string status = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_IP, ip},
                {FIELD_STATUS, status},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Post(string.Format(ENDPOINT_URL_CREATE, DetermineUserId(), credentialPasswordIpId),
                    requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }

        /// <summary>
        /// </summary>
        public static BunqResponse<List<PermittedIp>> List(int credentialPasswordIpId,
            IDictionary<string, string> urlParams = null, IDictionary<string, string> customHeaders = null)
        {
            if (urlParams == null) urlParams = new Dictionary<string, string>();
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());
            var responseRaw =
                apiClient.Get(string.Format(ENDPOINT_URL_LISTING, DetermineUserId(), credentialPasswordIpId), urlParams,
                    customHeaders);

            return FromJsonList<PermittedIp>(responseRaw, OBJECT_TYPE_GET);
        }

        /// <summary>
        /// </summary>
        /// <param name="status">The status of the IP. May be "ACTIVE" or "INACTIVE". It is only possible to make requests from "ACTIVE" IP addresses. Only "ACTIVE" IPs will be billed.</param>
        public static BunqResponse<int> Update(int credentialPasswordIpId, int permittedIpId, string status = null,
            IDictionary<string, string> customHeaders = null)
        {
            if (customHeaders == null) customHeaders = new Dictionary<string, string>();

            var apiClient = new ApiClient(GetApiContext());

            var requestMap = new Dictionary<string, object>
            {
                {FIELD_STATUS, status},
            };

            var requestBytes = Encoding.UTF8.GetBytes(BunqJsonConvert.SerializeObject(requestMap));
            var responseRaw =
                apiClient.Put(
                    string.Format(ENDPOINT_URL_UPDATE, DetermineUserId(), credentialPasswordIpId, permittedIpId),
                    requestBytes, customHeaders);

            return ProcessForId(responseRaw);
        }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Ip != null)
            {
                return false;
            }

            if (this.Status != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static PermittedIp CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<PermittedIp>(json);
        }
    }
}