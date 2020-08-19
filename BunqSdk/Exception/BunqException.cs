namespace Bunq.Sdk.Exception
{
    /// <summary>
    /// Exception triggered by an error in SDK (client-side).
    /// </summary>
    public class BunqException : System.Exception
    {
        /// <param name="message">A custom error message.</param>
        public BunqException(string message) : base(message)
        {
        }

        /// <param name="message">A custom error message.</param>
        /// <param name="innerException">An exception which caused this exception.</param>
        public BunqException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}