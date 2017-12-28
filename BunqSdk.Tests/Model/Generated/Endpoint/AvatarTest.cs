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
        private static readonly string AttachmentContentType = Config.GetAttachmentContentType();
        private static readonly string AttachmentDescription = Config.GetAttachmentDescription();
        private static readonly string AttachmentPathIn = Config.GetAttachmentPathIn();

        /// <summary>
        /// File path constatns.
        /// </summary>
        private const string PathAttachment = "../../../Resources";
        
        /// <summary>
        /// The index of the first item in an array.
        /// </summary>
        private const int IndexFirst = 0;

        /// <summary>
        /// API context to use for the test API calls.
        /// </summary>
        private static readonly ApiContext ApiContext = GetApiContext();

        /// <summary>
        /// Tests the creation of an avatar by uploading a picture via AttachmentPublic and setting it as avatar
        /// via the uuid.
        /// </summary>
        [Fact]
        public void TestCreateAvatarAndRetrieval()
        {
            var fileContentByte = File.ReadAllBytes(PathAttachment + AttachmentPathIn);
            var attachmentUuid = UploadAvatarAndGetUuid(fileContentByte);

            var avatarMap = new Dictionary<string, object>
            {
                {Avatar.FIELD_ATTACHMENT_PUBLIC_UUID, attachmentUuid}
            };
            var avatarUuid = Avatar.Create(ApiContext, avatarMap).Value;

            var attachmentUuidFromAvatar = Avatar.Get(ApiContext, avatarUuid).Value
                .Image[IndexFirst].AttachmentPublicUuid;
            var revievedFileContentByte = AttachmentPublicContent.List(ApiContext, attachmentUuidFromAvatar).Value;

            Assert.Equal(attachmentUuid, attachmentUuidFromAvatar);
            Assert.Equal(fileContentByte, revievedFileContentByte);
        }

        private static string UploadAvatarAndGetUuid(byte[] fileContentByte)
        {
            var customHeaders = new Dictionary<string, string>
            {
                {ApiClient.HeaderAttachmentDescription, AttachmentDescription},
                {ApiClient.HeaderContentType, AttachmentContentType},
            };

            return AttachmentPublic.Create(ApiContext, fileContentByte, customHeaders).Value;
        }
    }
}
