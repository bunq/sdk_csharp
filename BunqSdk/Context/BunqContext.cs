using System;
using Bunq.Sdk.Exception;

namespace Bunq.Sdk.Context
{
    public static class BunqContext
    {
        private const string ErrorApicontextHasNotBeenLoaded = "apiContext has not been loaded.";
        private const string ErrorUserContextHasNotBeenLoaded = "userContext has not been loaded, you can load this by loading apiContext.";
        private static ApiContext apiContext;
        private static UserContext userContext;
        
        public static ApiContext ApiContext {
            get
            {
                if (apiContext == null)
                {
                    throw new BunqException(ErrorApicontextHasNotBeenLoaded);
                }
                else
                {
                    return apiContext;
                }
            }
            private set => apiContext = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static UserContext UserContext
        {
            get
            {
                if (userContext == null)
                {
                    throw new BunqException(ErrorUserContextHasNotBeenLoaded);
                }
                else
                {
                    return userContext;
                }
            }
            private set => userContext = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static void LoadApiContext(ApiContext apiContextToLoad)
        {
            ApiContext = apiContextToLoad;
            UserContext = new UserContext(apiContextToLoad.SessionContext.UserId);
            UserContext.InitPrimaryMonetaryAccount();
        }
    }
}
