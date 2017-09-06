using System.Collections.Immutable;
using System.IO;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json.Linq;

namespace Bunq.Sdk.Tests
{
    public class Config
    {
        /// <summary>
        /// Delimiter between the IP addresses in the PERMITTED_IPS field.
        /// </summary>
        private const char DELIMITER_IPS = ',';

        /// <summary>
        /// Length of an empty array.
        /// </summary>
        private const int LENGTH_NONE = 0;

        /// <summary>
        /// Field constants.
        /// </summary>
        private const string FIELD_CONFIG_FILE_PATH = "../../../Resources/config.json";
        private const string FIELD_USER_ID = "USER_ID";
        private const string FIELD_API_KEY = "API_KEY";
        private const string FIELD_PERMITTED_IPS = "PERMITTED_IPS";
        private const string FIELD_ATTACHMENT_PUBLIC_TEST = "AttachmentPublicTest";
        private const string FIELD_ATTACHMENT_PATH_IN = "PATH_IN";
        private const string FIELD_ATTACHMENT_DESCRIPTION = "DESCRIPTION";
        private const string FIELD_ATTACHMENT_CONTENT_TYPE = "CONTENT_TYPE";
        private const string FIELD_MONETARY_ACCOUNT_ID = "MONETARY_ACCOUNT_ID";
        private const string FIELD_MONETARY_ACCOUNT_ID2 = "MONETARY_ACCOUNT_ID2";
        private const string FIELD_COUNTER_PARTY_SELF = "CounterPartySelf";
        private const string FIELD_COUNTER_PARTY_OTHER = "CounterPartyOther";
        private const string FIELD_COUNTER_ALIAS = "Alias";
        private const string FIELD_COUNTER_TYPE = "Type";
        private const string FIELD_TAB_USAGE_SINGLE = "TabUsageSingleTest";
        private const string FIELD_CASH_REGISTER_ID = "CASH_REGISTER_ID";

        public static int GetCashRegisterId()
        {
            return GetConfig()[FIELD_TAB_USAGE_SINGLE][FIELD_CASH_REGISTER_ID].ToObject<int>();
        }

        public static Pointer GetCounterPartyAliasOther()
        {
            var alias = GetConfig()[FIELD_COUNTER_PARTY_OTHER][FIELD_COUNTER_ALIAS].ToString();
            var type = GetConfig()[FIELD_COUNTER_PARTY_OTHER][FIELD_COUNTER_TYPE].ToString();

            return new Pointer(type, alias);
        }

        public static Pointer GetCounterPartyAliasSelf()
        {
            var alias = GetConfig()[FIELD_COUNTER_PARTY_SELF][FIELD_COUNTER_ALIAS].ToString();
            var type = GetConfig()[FIELD_COUNTER_PARTY_SELF][FIELD_COUNTER_TYPE].ToString();

            return new Pointer(type, alias);
        }

        public static int GetSecondMonetaryAccountId()
        {
            return GetConfig()[FIELD_MONETARY_ACCOUNT_ID2].ToObject<int>();
        }

        public static int GetMonetarytAccountId()
        {
            return GetConfig()[FIELD_MONETARY_ACCOUNT_ID].ToObject<int>();
        }

        public static string GetAttachmentPathIn()
        {
            return GetConfig()[FIELD_ATTACHMENT_PUBLIC_TEST][FIELD_ATTACHMENT_PATH_IN].ToString();
        }

        public static string GetAttachmentDescrpition()
        {
            return GetConfig()[FIELD_ATTACHMENT_PUBLIC_TEST][FIELD_ATTACHMENT_DESCRIPTION].ToString();
        }

        public static string GetAttachmentContentType()
        {
            return GetConfig()[FIELD_ATTACHMENT_PUBLIC_TEST][FIELD_ATTACHMENT_CONTENT_TYPE].ToString();
        }

        public static string[] GetPermittedIps()
        {
            var permittedIpsString = GetConfig()[FIELD_PERMITTED_IPS].ToString();

            return permittedIpsString.Length == LENGTH_NONE ?
                new string[LENGTH_NONE] :
                permittedIpsString.Split(DELIMITER_IPS);
        }

        public static string GetApiKey()
        {
            return GetConfig()[FIELD_API_KEY].ToString();
        }

        public static int GetUserId()
        {
            return GetConfig()[FIELD_USER_ID].ToObject<int>();
        }

        private static JObject GetConfig()
        {
            var fileContentString = File.ReadAllText(FIELD_CONFIG_FILE_PATH);

            return JObject.Parse(fileContentString);
        }
    }
}
