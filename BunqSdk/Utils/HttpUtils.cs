using System;
using System.Collections.Generic;
using System.Linq;
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
            List<String> formattedParameters = new List<string>();
            
            StringBuilder queryStringBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> parameterPair in parameters)
            {
                formattedParameters.Add(
                    String.Format(QUERY_FORMAT, parameterPair.Key, parameterPair.Value)
                );
            }

            return String.Join(QUERY_GLUE, formattedParameters);
        }
    }
}