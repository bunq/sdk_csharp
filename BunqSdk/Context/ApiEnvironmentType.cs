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
        private static readonly IDictionary<string, string> NameToBaseUriMap = new Dictionary<string, string>
        {
            {EnvironmentTypeProduction, BaseUriProduction},
            {EnvironmentTypeSandbox, BaseUriSandbox}
        };

        /// <summary>
        /// Production environment constants.
        /// </summary>
        public static readonly ApiEnvironmentType Production = new ApiEnvironmentType(EnvironmentTypeProduction);
        private const string EnvironmentTypeProduction = "PRODUCTION";
        private const string BaseUriProduction = "https://api.bunq.com/v1/";

        /// <summary>
        /// Sandbox environment constants.
        /// </summary>
        public static readonly ApiEnvironmentType Sandbox = new ApiEnvironmentType(EnvironmentTypeSandbox);
        private const string EnvironmentTypeSandbox = "SANDBOX";
        private const string BaseUriSandbox = "https://sandbox.public.api.bunq.com/v1/";

        public string TypeString { get; private set; }
        public string BaseUri { get; private set; }

        public ApiEnvironmentType(string typeString)
        {
            TypeString = typeString;
            BaseUri = NameToBaseUriMap[typeString];
        }
    }
}
