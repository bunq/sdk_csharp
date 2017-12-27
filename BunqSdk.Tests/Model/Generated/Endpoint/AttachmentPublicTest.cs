using System.Collections.Generic;
using System.IO;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Generated.Endpoint;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Generated.Endpoint
{
    /// <summary>
    /// Tests:
    ///     AttachmentPublic
    ///     AttachmentPublicContent
    /// </summary>
    public class AttachmentPublicTest : BunqSdkTestBase
    {
        /// <summary>
        /// Config values.
        /// </summary>
        private const string PATH_ATTACHMENT = "../../../Resources";

        private static readonly string CONTENT_TYPE = Config.GetAttachmentContentType();
        private static readonly string ATTACHMENT_DESCRIPTION = Config.GetAttachmentDescrpition();
        private static readonly string ATTACHMENT_PATH_IN = Config.GetAttachmentPathIn();

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = GetApiContext();

        /// <summary>
        /// Tests if the file we upload is the file we are getting back once successfully uploaded does.
        /// this by comparing the content of the files.
        /// </summary>
        [Fact]
        public void TestAttachmentUploadAndRetrieval()
        {
            var fileContentBytes = File.ReadAllBytes(PATH_ATTACHMENT + ATTACHMENT_PATH_IN);
            var customHeaders = new Dictionary<string, string>
            {
                {ApiClient.HeaderContentType, CONTENT_TYPE},
                {ApiClient.HeaderAttachmentDescription, ATTACHMENT_DESCRIPTION}
            };

            var attachmentUuid = AttachmentPublic.Create(API_CONTEXT, fileContentBytes, customHeaders).Value;
            var responseBytes = AttachmentPublicContent.List(API_CONTEXT, attachmentUuid).Value;

            Assert.Equal(fileContentBytes, responseBytes);
        }
    }
}
