using System;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class UserListSample : ISample
    {
        public void Run()
        {
            BunqContext.LoadApiContext(ApiContext.Restore());
            var users = User.List().Value;

            BunqContext.ApiContext.Save();

            foreach (var oneUser in users)
            {
                Console.WriteLine(oneUser.UserCompany);
            }
            
            // or
            
            Console.WriteLine(BunqContext.UserContext.UserCompany);
            Console.WriteLine(BunqContext.UserContext.UserPerson);
        }
    }
}
