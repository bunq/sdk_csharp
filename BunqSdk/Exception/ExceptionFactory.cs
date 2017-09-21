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
        /// Glue to concatenate the error messages.
        /// </summary>
        private const string GLUE_ERROR_MESSAGES = "\n";

        
        /// <returns>The exception that belongs to this status code.</returns>
        public static ApiException CreateExceptionForResponse(int responseCode, IList<string> messages)
        {
            var errorMessage = ConcatenateMessages(messages);

            switch (responseCode)
            {
                case HTTP_RESPONSE_CODE_BAD_REQUEST:
                    return new BadRequestException(responseCode, errorMessage);
                case HTTP_RESPONSE_CODE_UNAUTHORIZED:
                    return new UnauthorizedException(responseCode, errorMessage);
                case HTTP_RESPONSE_CODE_FORBIDDEN:
                    return new ForbiddenException(responseCode, errorMessage);
                case HTTP_RESPONSE_CODE_NOT_FOUND:
                    return new NotFoundException(responseCode, errorMessage);
                case HTTP_RESPONSE_CODE_METHOD_NOT_ALLOWED:
                    return new MethodNotAllowedException(responseCode, errorMessage);
                case HTTP_RESPONSE_CODE_TOO_MANY_REQUESTS:
                    return new ToManyRequestsException(responseCode, errorMessage);
                case HTTP_RESPONSE_CODE_INTERNAL_SERVER_ERROR:
                    return new PleaseContactBunqException(responseCode, errorMessage);
                default:
                     return new UnknownApiErrorException(responseCode, errorMessage);
            }
        }
        
        private static string ConcatenateMessages(IEnumerable<string> messages)
        {
            return string.Join(GLUE_ERROR_MESSAGES, messages);
        }
    }
}