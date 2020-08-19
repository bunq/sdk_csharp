namespace Bunq.Sdk.Model.Core
{
    /// <summary>
    /// Class-based Enum for the supported OAuth Grant Types.
    /// </summary>
    public sealed class OauthGrantType
    {
        /// <summary>
        /// Authorization code grant constants.
        /// </summary>
        public static readonly OauthGrantType AUTHORIZATION_CODE = new OauthGrantType(GRANT_TYPE_AUTHORIZATION_CODE);
        private const string GRANT_TYPE_AUTHORIZATION_CODE = "authorization_code";

        public string TypeString { get; private set; }

        private OauthGrantType(string typeString)
        {
            TypeString = typeString;
        }
    }
}