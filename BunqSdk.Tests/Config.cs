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
        private const char DelimiterIps = ',';

        /// <summary>
        /// Length of an empty array.
        /// </summary>
        private const int LengthNone = 0;

        /// <summary>
        /// Field constants.
        /// </summary>
        private const string FieldConfigFilePath = "../../../Resources/config.json";
        private const string FieldUserId = "USER_ID";
        private const string FieldApiKey = "API_KEY";
        private const string FieldPermittedIps = "PERMITTED_IPS";
        private const string FieldAttachmentPublicTest = "AttachmentPublicTest";
        private const string FieldAttachmentPathIn = "PATH_IN";
        private const string FieldAttachmentDescription = "DESCRIPTION";
        private const string FieldAttachmentContentType = "CONTENT_TYPE";
        private const string FieldMonetaryAccountId = "MONETARY_ACCOUNT_ID";
        private const string FieldMonetaryAccountId2 = "MONETARY_ACCOUNT_ID2";
        private const string FieldCounterPartySelf = "CounterPartySelf";
        private const string FieldCounterPartyOther = "CounterPartyOther";
        private const string FieldCounterAlias = "Alias";
        private const string FieldCounterType = "Type";
        private const string FieldTabUsageSingle = "TabUsageSingleTest";
        private const string FieldCashRegisterId = "CASH_REGISTER_ID";

        public static int GetCashRegisterId()
        {
            return GetConfig()[FieldTabUsageSingle][FieldCashRegisterId].ToObject<int>();
        }

        public static Pointer GetCounterPartyAliasOther()
        {
            var alias = GetConfig()[FieldCounterPartyOther][FieldCounterAlias].ToString();
            var type = GetConfig()[FieldCounterPartyOther][FieldCounterType].ToString();

            return new Pointer(type, alias);
        }

        public static Pointer GetCounterPartyAliasSelf()
        {
            var alias = GetConfig()[FieldCounterPartySelf][FieldCounterAlias].ToString();
            var type = GetConfig()[FieldCounterPartySelf][FieldCounterType].ToString();

            return new Pointer(type, alias);
        }

        public static int GetSecondMonetaryAccountId()
        {
            return GetConfig()[FieldMonetaryAccountId2].ToObject<int>();
        }

        public static int GetMonetarytAccountId()
        {
            return GetConfig()[FieldMonetaryAccountId].ToObject<int>();
        }

        public static string GetAttachmentPathIn()
        {
            return GetConfig()[FieldAttachmentPublicTest][FieldAttachmentPathIn].ToString();
        }

        public static string GetAttachmentDescrpition()
        {
            return GetConfig()[FieldAttachmentPublicTest][FieldAttachmentDescription].ToString();
        }

        public static string GetAttachmentContentType()
        {
            return GetConfig()[FieldAttachmentPublicTest][FieldAttachmentContentType].ToString();
        }

        public static string[] GetPermittedIps()
        {
            var permittedIpsString = GetConfig()[FieldPermittedIps].ToString();

            return permittedIpsString.Length == LengthNone ?
                new string[LengthNone] :
                permittedIpsString.Split(DelimiterIps);
        }

        public static string GetApiKey()
        {
            return GetConfig()[FieldApiKey].ToString();
        }

        public static int GetUserId()
        {
            return GetConfig()[FieldUserId].ToObject<int>();
        }

        private static JObject GetConfig()
        {
            var fileContentString = File.ReadAllText(FieldConfigFilePath);

            return JObject.Parse(fileContentString);
        }
    }
}
