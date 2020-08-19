using System.Collections.Generic;
using System.Text;

namespace Bunq.Sdk.Utils
{
    public class HttpUtils
    {
        private const string QUERY_FORMAT = "{0}={1}";
        private const string QUERY_GLUE = "&";

        /// <summary>
        /// Create query string from input parameters.
        /// </summary>
        public static string CreateQueryString(Dictionary<string, string> parameters)
        {
            List<string> formattedParameters = new List<string>();

            StringBuilder queryStringBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> parameterPair in parameters)
            {
                formattedParameters.Add(
                    string.Format(QUERY_FORMAT, parameterPair.Key, parameterPair.Value)
                );
            }

            return string.Join(QUERY_GLUE, formattedParameters);
        }
    }
}