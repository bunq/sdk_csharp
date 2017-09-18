using System.Collections.Generic;
using Bunq.Sdk.Model;

namespace Bunq.Sdk.Exception
{
    public class ExceptionHandler
    {
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


        public static BunqError CreateExceptionForResponse(int responseCode, IList<string> messages)
        {
            var errorMessage = ConcatenateMessages(messages);

            if (responseCode == HTTP_RESPONSE_CODE_BAD_REQUEST)
            {
                return new BadRequestException(responseCode, errorMessage);
            }
            if (responseCode == HTTP_RESPONSE_CODE_UNAUTHORIZED)
            {
                return new UnauthorizedException(responseCode, errorMessage);
            }
            if (responseCode == HTTP_RESPONSE_CODE_FORBIDDEN)
            {
                return new ForbiddenException(responseCode, errorMessage);
            }
            if (responseCode == HTTP_RESPONSE_CODE_NOT_FOUND)
            {
                return new NotFoundException(responseCode, errorMessage);
            }
            if (responseCode == HTTP_RESPONSE_CODE_METHOD_NOT_ALLOWED)
            {
                return new MethodNotAllowedException(responseCode, errorMessage);
            }
            if (responseCode == HTTP_RESPONSE_CODE_TOO_MANY_REQUESTS)
            {
                return new ToManyRequestsException(responseCode, errorMessage);
            }
            if (responseCode == HTTP_RESPONSE_CODE_INTERNAL_SERVER_ERROR)
            {
                return new PleaseContactBunqException(responseCode, errorMessage);
            }

            return new ApiException(responseCode, errorMessage);
        }
        
        private static string ConcatenateMessages(IEnumerable<string> messages)
        {
            return string.Join(GLUE_ERROR_MESSAGES, messages);
        }
    }
}