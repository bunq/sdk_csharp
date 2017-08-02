using Bunq.Sdk.Context;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class ApiContextSaveSample : ISample
    {
        private const string API_KEY = "### YOUR API KEY ###"; // Put your API key here
        private const string DEVICE_DESCRIPTION = "Device description.";

        public void Run()
        {
            var apiContext = ApiContext.Create(ApiEnvironmentType.SANDBOX, API_KEY, DEVICE_DESCRIPTION);
            apiContext.Save();
        }
    }
}
