using System;
using System.Collections.Generic;
using System.IO;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Model.Generated.Object;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Generated.Endpoint
{
    /// <summary>
    /// Tests:
    ///     DraftShareInviteBankEntry
    ///     DraftShareInviteBankQrCodeContent
    /// </summary>
    public class DraftShareInviteBankQrCodeContentTest : BunqSdkTestBase
    {
        /// <summary>
        /// Config values.
        /// </summary>
        private const string FilenameQrCodeImage = "tmp/qrcode.png";

        private const int TimeUnitAmountZero = 0;
        private const int TimeUnitAmountOne = 1;
        private const string FormatDate = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// Tests the creation of a connect and getting the qr code related to this connect.
        ///
        /// This test has no assertion as of its testing to see if the code runs without errors.
        /// </summary>
        [Fact]
        public void TestCreateInviteBankAndGetQrCode()
        {
            SetUpTestCase();

            var draftId = GetShareInviteId();

            var qrContent = DraftShareInviteBankQrCodeContent.List(draftId).Value;

            var fileOut = new FileInfo(FilenameQrCodeImage);
            fileOut.Directory.Create();
            File.WriteAllBytes(fileOut.FullName, qrContent);
        }

        private static int GetShareInviteId()
        {
            var currentDate = DateTime.UtcNow.Date;
            var addTime = new TimeSpan(TimeUnitAmountZero, TimeUnitAmountOne, TimeUnitAmountZero);
            var expirationTime = currentDate.Add(addTime).ToString(FormatDate);

            var draftShareInviteEntry = new DraftShareInviteEntry(
                new ShareDetail {Payment = new ShareDetailPayment(true, true, true, true)}
            );

            return DraftShareInviteBank.Create(expirationTime, draftShareInviteEntry).Value;
        }
    }
}