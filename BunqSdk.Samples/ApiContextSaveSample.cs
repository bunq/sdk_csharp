using Bunq.Sdk.Context;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class ApiContextSaveSample : ISample
    {
        private const string ApiKey = "### YOUR API KEY ###"; // Put your API key here
        private const string DeviceDescription = "Device description.";

        public void Run()
        {
            var apiContext = ApiContext.Create(ApiEnvironmentType.Sandbox, ApiKey, DeviceDescription);
            apiContext.Save();
        }
    }
}
