using System;
using System.Collections.Generic;
using System.IO;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated;
using Bunq.Sdk.Model.Generated.Object;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Generated
{
    /// <summary>
    /// Tests:
    ///     DraftShareInviteBankEntry
    ///     DraftShareInviteBankQrCodeContent
    /// </summary>
    public class DraftShareInviteBankQrCodeContentTest
    {
        /// <summary>
        /// Config values.
        /// </summary>
        private const string FILENAME_QR_CODE_IMAGE = "tmp/qrcode.png";        
        private const int TIME_UNIT_AMOUNT_ZERO = 0;
        private const int TIME_UNIT_AMOUNT_ONE = 1;
        private const string FORMAT_DATE = "yyyy-MM-dd HH:mm:ss";
        
        private static readonly int USER_ID = Config.GetUserId();

        /// <summary>
        /// API context to use for the test API calls
        /// </summary>
        private static readonly ApiContext API_CONTEXT = ApiContextHandler.GetApiContext();

        /// <summary>
        /// Tests the creation of a connect and getting the qr code related to this connect.
        /// 
        /// This test has no assertion as of its testing to see if the code runs without errors.
        /// </summary>
        [Fact]
        public void TestCreateInviteBankAndGetQrCode()
        {
            var draftId = GetShareInviteId();
            
            var qrContent = DraftShareInviteBankQrCodeContent.List(API_CONTEXT, USER_ID, draftId);

            var fileOut = new FileInfo(FILENAME_QR_CODE_IMAGE);
            fileOut.Directory.Create();
            File.WriteAllBytes(fileOut.FullName, qrContent);
        }

        private static int GetShareInviteId()
        {
            var currentDate = DateTime.UtcNow.Date;
            var addTime = new TimeSpan(TIME_UNIT_AMOUNT_ZERO, TIME_UNIT_AMOUNT_ONE, TIME_UNIT_AMOUNT_ZERO);
            var expirationTime = currentDate.Add(addTime).ToString(FORMAT_DATE);
            
            var draftShareInviteBankEntry = new DraftShareInviteBankEntry(new ShareDetail 
                {Payment = new ShareDetailPayment(true, true, true, true)});

            var requestMap = new Dictionary<string, object>
            {
                {DraftShareInviteBank.FIELD_DRAFT_SHARE_SETTINGS, draftShareInviteBankEntry},
                {DraftShareInviteBank.FIELD_EXPIRATION, expirationTime}
            };
            
            return DraftShareInviteBank.Create(API_CONTEXT, requestMap, USER_ID);
        }
    }
}
