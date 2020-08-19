using System.Collections.Generic;
using System.IO;
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
        /// Tests if the file we upload is the file we are getting back once successfully uploaded does.
        /// this by comparing the content of the files.
        /// </summary>
        [Fact]
        public void TestAttachmentUploadAndRetrieval()
        {
            SetUpTestCase();

            var fileContentBytes = File.ReadAllBytes(PathAttachment + AttachmentPathIn);
            var customHeaders = new Dictionary<string, string>
            {
                {ApiClient.HEADER_CONTENT_TYPE, ContentType},
                {ApiClient.HEADER_ATTACHMENT_DESCRIPTION, AttachmentDescription}
            };

            var attachmentUuid = AttachmentPublic.Create(fileContentBytes, customHeaders).Value;
            var responseBytes = AttachmentPublicContent.List(attachmentUuid).Value;

            Assert.Equal(fileContentBytes, responseBytes);
        }
    }
}