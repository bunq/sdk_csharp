using System.Collections.Generic;

namespace Bunq.Sdk.Context
{
    /// <summary>
    /// Class-based Enum for the API environment types and their URIs.
    /// </summary>
    public sealed class ApiEnvironmentType
    {
        /// <summary>
        /// Mapping of environment type to the base URI.
        /// </summary>
        private static readonly IDictionary<string, string> NAME_TO_BASE_URI_MAP = new Dictionary<string, string>
        {
            {ENVIRONMENT_TYPE_PRODUCTION, BASE_URI_PRODUCTION},
            {ENVIRONMENT_TYPE_SANDBOX, BASE_URI_SANDBOX}
        };

        /// <summary>
        /// Production environment constants.
        /// </summary>
        public static readonly ApiEnvironmentType PRODUCTION = new ApiEnvironmentType(ENVIRONMENT_TYPE_PRODUCTION);
        private const string ENVIRONMENT_TYPE_PRODUCTION = "PRODUCTION";
        private const string BASE_URI_PRODUCTION = "https://public.api.bunq.com/v1/";

        /// <summary>
        /// Sandbox environment constants.
        /// </summary>
        public static readonly ApiEnvironmentType SANDBOX = new ApiEnvironmentType(ENVIRONMENT_TYPE_SANDBOX);
        private const string ENVIRONMENT_TYPE_SANDBOX = "SANDBOX";
        private const string BASE_URI_SANDBOX = "https://sandbox.public.api.bunq.com/v1/";

        public string TypeString { get; private set; }
        public string BaseUri { get; private set; }

        public ApiEnvironmentType(string typeString)
        {
            TypeString = typeString;
            BaseUri = NAME_TO_BASE_URI_MAP[typeString];
        }
    }
}
