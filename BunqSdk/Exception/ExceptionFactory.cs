using System.Collections.Generic;

namespace Bunq.Sdk.Exception
{
    public class ExceptionFactory
    {
        /// <summary>
        /// HTTP error response codes constants.
        /// </summary>
        private const int HttpResponseCodeBadRequest = 400;
        private const int HttpResponseCodeUnauthorized = 401;
        private const int HttpResponseCodeForbidden = 403;
        private const int HttpResponseCodeNotFound = 404;
        private const int HttpResponseCodeMethodNotAllowed = 405;
        private const int HttpResponseCodeTooManyRequests = 429;
        private const int HttpResponseCodeInternalServerError = 500;
        
        /// <summary>
        /// Glue to concatenate the error messages.
        /// </summary>
        private const string GlueErrorMessages = "\n";
        
        /// <returns>The exception that belongs to this status code.</returns>
        public static ApiException CreateExceptionForResponse(int responseCode, IList<string> messages)
        {
            var errorMessage = ConcatenateMessages(messages);

            switch (responseCode)
            {
                case HttpResponseCodeBadRequest:
                    return new BadRequestException(responseCode, errorMessage);
                case HttpResponseCodeUnauthorized:
                    return new UnauthorizedException(responseCode, errorMessage);
                case HttpResponseCodeForbidden:
                    return new ForbiddenException(responseCode, errorMessage);
                case HttpResponseCodeNotFound:
                    return new NotFoundException(responseCode, errorMessage);
                case HttpResponseCodeMethodNotAllowed:
                    return new MethodNotAllowedException(responseCode, errorMessage);
                case HttpResponseCodeTooManyRequests:
                    return new TooManyRequestsException(responseCode, errorMessage);
                case HttpResponseCodeInternalServerError:
                    return new PleaseContactBunqException(responseCode, errorMessage);
                default:
                     return new UnknownApiErrorException(responseCode, errorMessage);
            }
        }
        
        private static string ConcatenateMessages(IEnumerable<string> messages)
        {
            return string.Join(GlueErrorMessages, messages);
        }
    }
}
