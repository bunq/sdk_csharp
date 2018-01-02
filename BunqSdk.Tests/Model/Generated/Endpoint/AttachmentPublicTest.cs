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
        private static readonly string ContentType = Config.GetAttachmentContentType();
        private static readonly string AttachmentDescription = Config.GetAttachmentDescription();
        private static readonly string AttachmentPathIn = Config.GetAttachmentPathIn();
        
        /// <summary>
        /// File path constatns.
        /// </summary>
        private const string PathAttachment = "../../../Resources";
        
        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext ApiContext = GetApiContext();

        /// <summary>
        /// Tests if the file we upload is the file we are getting back once successfully uploaded does.
        /// this by comparing the content of the files.
        /// </summary>
        [Fact]
        public void TestAttachmentUploadAndRetrieval()
        {
            var fileContentBytes = File.ReadAllBytes(PathAttachment + AttachmentPathIn);
            var customHeaders = new Dictionary<string, string>
            {
                {ApiClient.HeaderContentType, ContentType},
                {ApiClient.HeaderAttachmentDescription, AttachmentDescription}
            };

            var attachmentUuid = AttachmentPublic.Create(ApiContext, fileContentBytes, customHeaders).Value;
            var responseBytes = AttachmentPublicContent.List(ApiContext, attachmentUuid).Value;

            Assert.Equal(fileContentBytes, responseBytes);
        }
    }
}
