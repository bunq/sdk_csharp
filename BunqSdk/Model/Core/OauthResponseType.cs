namespace Bunq.Sdk.Model.Core
{
    /// <summary>
    /// Class-based Enum for the supported OAuth Response Types.
    /// </summary>
    public sealed class OauthResponseType
    {
        /// <summary>
        /// Code response type constants.
        /// </summary>
        public static readonly OauthResponseType CODE = new OauthResponseType(RESPONSE_TYPE_CODE);
        private const string RESPONSE_TYPE_CODE = "code";

        public string TypeString { get; private set; }

        private OauthResponseType(string typeString)
        {
            TypeString = typeString;
        }
    }
}