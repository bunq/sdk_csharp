using System.Collections.Generic;

namespace Bunq.Sdk.Exception
{
    /// <summary>
    /// Exception triggered by API requests failed on the server side.
    /// </summary>
    public class ApiException : System.Exception
    {
        /// <summary>
        /// Glue to concatenate the error messages.
        /// </summary>
        private const string GLUE_ERROR_MESSAGES = "\n";

        public int ResponseCode { get; private set; }
        public IList<string> Messages { get; private set; }

        /// <param name="responseCode">The HTTP Response code of the failed request.</param>
        /// <param name="messages">The list of messages related to this exception.</param>
        public ApiException(int responseCode, IList<string> messages) : base(
            ConcatenateMessages(messages))
        {
            ResponseCode = responseCode;
            Messages = messages;
        }

        private static string ConcatenateMessages(IEnumerable<string> messages)
        {
            return string.Join(GLUE_ERROR_MESSAGES, messages);
        }
    }
}
