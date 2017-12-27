## Exceptions
When you make a request via the SDK, there is a chance of request failing
due to various reasons. When such a failure happens, an exception
corresponding to the error occurred is thrown.


----
#### Possible Exceptions
* `BadRequestException` If the request returns with status code `400`
* `UnauthorizedException` If the request returns with status code `401`
* `ForbiddenException` If the request returns with status code `403`
* `NotFoundException` If the request returns with status code `404`
* `MethodNotAllowedException` If the request returns with status code `405`
* `TooManyRequestsException` If the request returns with status code `429`
* `PleaseContactBunqException` If the request returns with status code `500`.
If you get this exception, please contact us preferably via the support chat in the bunq app.
* `UnknownApiErrorException` If none of the above mentioned exceptions are thrown,
this exception will be thrown instead.

For more information regarding these errors, please take a look on the documentation
page here: https://doc.bunq.com/api/1/page/errors

---
#### Base exception
All the exceptions have the same base exception which looks like this:
```c#
   public class ApiException : System.Exception
    {
        public int ResponseCode { get;}

        /// <param name="responseCode">The HTTP Response code of the failed request.</param>
        /// <param name="message">The error messages related to this exception.</param>
        public ApiException(int responseCode, string message) : base(message)
        {
            // hidden code
        }
    } 
```
This means that each exception will have a response code and an error message
related to the specific error returned by API.

---
#### Exception handling
Since each API error has a distinct SDK exception type corresponding to it,
you can catch the exact exceptions you expect 👏.

```c#
using Bunq.Sdk.Context;
using Bunq.Sdk.Exception;

public class BadRequest
{
    private const string Key = "Some invalid API key"
    private const string Description = "This will throw BadRequestException."
    
    public void Run()
    {
        try
        {
            ApiContext.Create(ApiEnvironmentType.SandBox, Key, Description);
        }
        catch(BadRequestException error)
        {
            Console.WriteLine(error.getMessage())
            Console.WriteLine(error.getResponseCode())
        }
    }
}
```