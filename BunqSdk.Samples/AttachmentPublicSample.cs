using System.Collections.Generic;
using System.IO;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class AttachmentPublicSample : ISample
    {
        private const string ContentTypeImageJpeg = "image/jpeg";
        private const string DescriptionTestJpgAttachment = "A test JPG attachment.";
        private const string PathAttachmentIn = "Assets/Attachment.jpg";
        private const string PathAttachmentOut = "Tmp/AttachmentOut.jpg";

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var customHeaders =
                new Dictionary<string, string>
                {
                    {ApiClient.HeaderContentType, ContentTypeImageJpeg},
                    {ApiClient.HeaderAttachmentDescription, DescriptionTestJpgAttachment}
                };
            var requestBytes = File.ReadAllBytes(PathAttachmentIn);
            var uuid = AttachmentPublic.Create(apiContext, requestBytes, customHeaders).Value;
            var responseBytes = AttachmentPublicContent.List(apiContext, uuid).Value;
            var fileOut = new FileInfo(PathAttachmentOut);
            fileOut.Directory.Create();
            File.WriteAllBytes(fileOut.FullName, responseBytes);
        }
    }
}
