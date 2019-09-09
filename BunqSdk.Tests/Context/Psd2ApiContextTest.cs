using System;
using System.Collections.Generic;
using System.IO;
using Bunq.Sdk.Context;
using Bunq.Sdk.Json;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Security;
using Bunq.Sdk.Tests.Util;
using Xunit;
using Assert = Xunit.Assert;

namespace Bunq.Sdk.Tests.Context
{
    [TestCaseOrderer("Bunq.Sdk.Tests.Util.TestPriorityOrderer", "Psd2ApiContextTest")]
    public class Psd2ApiContextTest: IClassFixture<Psd2ApiContextTest>
    {
        /// <summary>
        /// File constants.
        /// </summary>
        private const string FILE_TEST_CONFIGURATION = "../../../Resources/bunq-psd2-test.conf";
        private const string FILE_TEST_OAUTH = "../../../Resources/bunq-oauth-test.conf";

        private const string FILE_TEST_CREDENTIALS = "../../../Resources/credentials.pfx";
        private const string FILE_TEST_CERTIFICATE_CHAIN = "../../../Resources/chain.cert";

        /// <summary>
        /// Test constants.
        /// </summary>
        private const string TEST_DEVICE_DESCRIPTION = "PSD2TestDevice";
        private const string TEST_PASSPHRASE_CREDENTIALS = "secret";

        [Fact, TestPriority(1)]
        public void TestCreatePsd2Context()
        {
            ApiContext apiContext = null;
            if (File.Exists(FILE_TEST_CONFIGURATION))
            {
                apiContext = ApiContext.Restore(FILE_TEST_CONFIGURATION);
                Assert.NotNull(apiContext);
                
                BunqContext.LoadApiContext(apiContext);
                return;
            }
            
            apiContext = CreateApiContext();
            BunqContext.LoadApiContext(apiContext);

            Assert.True(File.Exists(FILE_TEST_CONFIGURATION));
        }

        [Fact, TestPriority(0)]
        public void TestCreateOauthClient()
        {
            if (File.Exists(FILE_TEST_OAUTH))
            {
                return;
            }
            
            int clientId = OauthClient.Create().Value;
            OauthClient oauthClient = OauthClient.Get(clientId).Value;
            Assert.NotNull(oauthClient);

            File.WriteAllText(
                FILE_TEST_OAUTH, 
                BunqJsonConvert.SerializeObject(oauthClient)
            );
            Assert.True(File.Exists(FILE_TEST_OAUTH));
        }

        private ApiContext CreateApiContext()
        {
            ApiContext apiContext = ApiContext.CreateForPsd2(
                    ApiEnvironmentType.SANDBOX,
                    SecurityUtils.GetCertificateFromFile(FILE_TEST_CREDENTIALS, TEST_PASSPHRASE_CREDENTIALS),
                    SecurityUtils.GetCertificateCollectionFromAllPath(
                        new[] { FILE_TEST_CERTIFICATE_CHAIN }
                    ),
                    TEST_DEVICE_DESCRIPTION,
                    new List<string>()
            );
            apiContext.Save(FILE_TEST_CONFIGURATION);

            return apiContext;
        }
    }
}