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
    ///     Avatar
    ///     AttachmentPublic
    ///     AttachmentPublicContent
    /// </summary>
    public class AvatarTest : BunqSdkTestBase
    {
        /// <summary>
        /// Config values.
        /// </summary>
        private const string PATH_TO_ATTACHMENT = "../../../Resources";
        private const int INDEX_FIRST = 0;

        private static readonly string CONTEN_TYPE = Config.GetAttachmentContentType();
        private static readonly string ATTACHMENT_DECSRIPTION = Config.GetAttachmentDescrpition();
        private static readonly string ATTACHMENT_PATH_IN = Config.GetAttachmentPathIn();

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext API_CONTEXT = GetApiContext();

        /// <summary>
        /// Tests the creation of an avatar by uploading a picture via AttachmentPublic and setting it as avatar
        /// via the uuid.
        /// </summary>
        [Fact]
        public void TestCreateAvatarAndRetrieval()
        {
            var fileContentByte = File.ReadAllBytes(PATH_TO_ATTACHMENT + ATTACHMENT_PATH_IN);
            var attachmentUuid = UploadAvatarAndGetUuid(fileContentByte);

            var avatarMap = new Dictionary<string, object>
            {
                {Avatar.FIELD_ATTACHMENT_PUBLIC_UUID, attachmentUuid}
            };
            var avatarUuid = Avatar.Create(API_CONTEXT, avatarMap).Value;

            var attachmentUuidFromAvatar = Avatar.Get(API_CONTEXT, avatarUuid).Value
                .Image[INDEX_FIRST].AttachmentPublicUuid;
            var revievedFileContentByte = AttachmentPublicContent.List(API_CONTEXT, attachmentUuidFromAvatar).Value;

            Assert.Equal(attachmentUuid, attachmentUuidFromAvatar);
            Assert.Equal(fileContentByte, revievedFileContentByte);
        }

        private static string UploadAvatarAndGetUuid(byte[] fileContentByte)
        {
            var customHeaders = new Dictionary<string, string>
            {
                {ApiClient.HEADER_ATTACHMENT_DESCRIPTION, ATTACHMENT_DECSRIPTION},
                {ApiClient.HEADER_CONTENT_TYPE, CONTEN_TYPE},
            };

            return AttachmentPublic.Create(API_CONTEXT, fileContentByte, customHeaders).Value;
        }
    }
}
