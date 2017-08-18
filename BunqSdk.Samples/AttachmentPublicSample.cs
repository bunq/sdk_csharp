using System.Collections.Generic;
using System.IO;
using Bunq.Sdk.Context;
using Bunq.Sdk.Http;
using Bunq.Sdk.Model.Generated;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class AttachmentPublicSample : ISample
    {
        private const string CONTENT_TYPE_IMAGE_JPEG = "image/jpeg";
        private const string DESCRIPTION_TEST_JPG_ATTACHMENT = "A test JPG attachment.";
        private const string PATH_ATTACHMENT_IN = "Samples/Assets/Attachment.jpg";
        private const string PATH_ATTACHMENT_OUT = "Samples/Tmp/AttachmentOut.jpg";

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var customHeaders =
                new Dictionary<string, string>
                {
                    {ApiClient.HEADER_CONTENT_TYPE, CONTENT_TYPE_IMAGE_JPEG},
                    {ApiClient.HEADER_ATTACHMENT_DESCRIPTION, DESCRIPTION_TEST_JPG_ATTACHMENT}
                };
            var requestBytes = File.ReadAllBytes(PATH_ATTACHMENT_IN);
            var uuid = AttachmentPublic.Create(apiContext, requestBytes, customHeaders).Value;
            var responseBytes = AttachmentPublicContent.List(apiContext, uuid).Value;
            var fileOut = new FileInfo(PATH_ATTACHMENT_OUT);
            fileOut.Directory.Create();
            File.WriteAllBytes(fileOut.FullName, responseBytes);
        }
    }
}
