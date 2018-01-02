using System.Collections.Generic;

namespace Bunq.Sdk.Exception
{
    public class ExceptionFactory
    {
        /// <summary>
        /// HTTP error response codes constants.
        /// </summary>
        private const int HTTP_RESPONSE_CODE_BAD_REQUEST = 400;
        private const int HTTP_RESPONSE_CODE_UNAUTHORIZED = 401;
        private const int HTTP_RESPONSE_CODE_FORBIDDEN = 403;
        private const int HTTP_RESPONSE_CODE_NOT_FOUND = 404;
        private const int HTTP_RESPONSE_CODE_METHOD_NOT_ALLOWED = 405;
        private const int HTTP_RESPONSE_CODE_TOO_MANY_REQUESTS = 429;
        private const int HTTP_RESPONSE_CODE_INTERNAL_SERVER_ERROR = 500;
        
        /// <summary>
        /// String format constants.
        /// </summary>
        private static string FORMAT_ERROR_MESSAGE = "Response id to help bunq debug: {0}. \n Error message: {1}";
        
        /// <returns>The exception that belongs to this status code.</returns>
        public static ApiException CreateExceptionForResponse(
            int responseCode,
            IList<string> messages,
            string responseId
        )
        {
            var errorMessage = FormatExceptionMessage(messages, responseId);

            switch (responseCode)
            {
                case HTTP_RESPONSE_CODE_BAD_REQUEST:
                    return new BadRequestException(responseCode, errorMessage, responseId);
                case HTTP_RESPONSE_CODE_UNAUTHORIZED:
                    return new UnauthorizedException(responseCode, errorMessage, responseId);
                case HTTP_RESPONSE_CODE_FORBIDDEN:
                    return new ForbiddenException(responseCode, errorMessage, responseId);
                case HTTP_RESPONSE_CODE_NOT_FOUND:
                    return new NotFoundException(responseCode, errorMessage, responseId);
                case HTTP_RESPONSE_CODE_METHOD_NOT_ALLOWED:
                    return new MethodNotAllowedException(responseCode, errorMessage, responseId);
                case HTTP_RESPONSE_CODE_TOO_MANY_REQUESTS:
                    return new TooManyRequestsException(responseCode, errorMessage, responseId);
                case HTTP_RESPONSE_CODE_INTERNAL_SERVER_ERROR:
                    return new PleaseContactBunqException(responseCode, errorMessage, responseId);
                default:
                     return new UnknownApiErrorException(responseCode, errorMessage, responseId);
            }
        }
        
        /// <summary>
        /// Formats the exception message accordingly.
        /// </summary>
        private static string FormatExceptionMessage(IEnumerable<string> messages, string responseId)
        {
            return string.Format(FORMAT_ERROR_MESSAGE,
                responseId,
                string.Join(Environment.NewLine, messages)
            );
        }
    }
}
