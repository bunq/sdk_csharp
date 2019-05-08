using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Bunq.Sdk.Tests.Model.Generated.Object
{
    public class NotificationUrlTest : BunqSdkTestBase
    {
        /// <summary>
        /// Getter constans.
        /// </summary>
        private const string GetPayment = "Payment";

        private const string GetBunqMeTab = "BunqMeTab";
        private const string GetChatMessageAnnouncement = "ChatMessageAnnouncement";
        private const string GetChatMessage = "ChatMessage";
        private const string GetDraftPayment = "DraftPayment";
        private const string GetMasterCardAction = "MasterCardAction";
        private const string GetMonetaryAccountBank = "MonetaryAccountBank";
        private const string GetMonetaryAccount = "MonetaryAccount";
        private const string GetPaymentBatch = "PaymentBatch";
        private const string GetRequestInquiry = "RequestInquiry";
        private const string GetRequestResponse = "RequestResponse";
        private const string GetSchedulePayment = "ScheduledPayment";
        private const string GetScheduleInstance = "ScheduledInstance";
        private const string GetShareInviteBankInquiry = "ShareInviteBankInquiry";
        private const string GetShareInviteBankResponse = "ShareInviteBankResponse";

        /// <summary>
        /// Model json paths constants.
        /// </summary>
        private const string BasePathJsonModel = "../../../Resources/NotificationUrlJsons";

        private const string JsonPathMutationModel = BasePathJsonModel + "/Mutation.json";
        private const string JsonPathBunqMeTabModel = BasePathJsonModel + "/BunqMeTab.json";

        private const string JsonPathChatMessageAnnouncementModel = BasePathJsonModel +
                                                                    "/ChatMessageAnnouncement.json";

        private const string JsonPathDraftPaymentModel = BasePathJsonModel + "/DraftPayment.json";
        private const string JsonPathMasterCardActionModel = BasePathJsonModel + "/MasterCardAction.json";
        private const string JsonPathMonetaryAccountBankModel = BasePathJsonModel + "/MonetaryAccountBank.json";
        private const string JsonPathPaymentBatchModel = BasePathJsonModel + "/PaymentBatch.json";
        private const string JsonPathRequestInquiryModel = BasePathJsonModel + "/RequestInquiry.json";
        private const string JsonPathRequestResponseModel = BasePathJsonModel + "/RequestResponse.json";
        private const string JsonPathSchedulePaymentModel = BasePathJsonModel + "/ScheduledPayment.json";
        private const string JsonPathScheduleInstanceModel = BasePathJsonModel + "/ScheduledInstance.json";

        private const string JsonPathShareInviteBankInquiryModel = BasePathJsonModel +
                                                                   "/ShareInviteBankInquiry.json";

        private const string JsonPathShareInviteBankResponseModel = BasePathJsonModel +
                                                                    "/ShareInviteBankResponse.json";

        /// <summary>
        /// Model root key.
        /// </summary>
        private const string KeyNotificationUrlModel = "NotificationUrl";

        private void ExecuteNotificationUrlTest(
            string expectedJsonFileName,
            Type classTypeExpected,
            string referencedObjectPropertyName,
            string subClassObjectPropertyName = null,
            Type subClassTypeExpected = null)
        {
            var jsonString = ReadJsonFromFile(expectedJsonFileName);
            var notificationUrl = NotificationUrl.CreateFromJsonString(jsonString);

            Assert.NotNull(notificationUrl);
            Assert.NotNull(notificationUrl.Object);

            var model = notificationUrl.Object.GetType()
                .GetProperty(referencedObjectPropertyName)
                .GetValue(notificationUrl.Object);
            var referencedModel = notificationUrl.Object.GetReferencedObject();

            Assert.NotNull(model);
            Assert.NotNull(referencedModel);
            Assert.IsType(classTypeExpected, referencedModel);

            if (subClassObjectPropertyName == null || subClassTypeExpected == null) return;
            var subClass = referencedModel.GetType()
                .GetProperty(subClassObjectPropertyName)
                .GetValue(referencedModel);

            Assert.NotNull(subClass);
            Assert.IsType(subClassTypeExpected, subClass);
        }

        private static string ReadJsonFromFile(string fileName)
        {
            var fileContentString = File.ReadAllText(fileName);
            var jsonObj = JObject.Parse(fileContentString);
            var notificationUrlObject = jsonObj[KeyNotificationUrlModel];

            Assert.NotNull(notificationUrlObject);

            return notificationUrlObject.ToString();
        }

        [Fact]
        public void TestMutationModel()
        {
            ExecuteNotificationUrlTest(
                JsonPathMutationModel,
                typeof(Payment),
                GetPayment
            );
        }

        [Fact]
        public void TestBunqMeTabModel()
        {
            ExecuteNotificationUrlTest(
                JsonPathBunqMeTabModel,
                typeof(BunqMeTab),
                GetBunqMeTab
            );
        }

        [Fact]
        public void TestDraftPaymentModel()
        {
            ExecuteNotificationUrlTest(
                JsonPathDraftPaymentModel,
                typeof(DraftPayment),
                GetDraftPayment
            );
        }

        [Fact]
        public void TestMasterCardActionModel()
        {
            ExecuteNotificationUrlTest(
                JsonPathMasterCardActionModel,
                typeof(MasterCardAction),
                GetMasterCardAction
            );
        }

        [Fact]
        public void TestMonetaryAccountBankModel()
        {
            ExecuteNotificationUrlTest(
                JsonPathMonetaryAccountBankModel,
                typeof(MonetaryAccount),
                GetMonetaryAccount,
                GetMonetaryAccountBank,
                typeof(MonetaryAccountBank)
            );
        }

        [Fact]
        public void TestPaymentBatchModel()
        {
            ExecuteNotificationUrlTest(
                JsonPathPaymentBatchModel,
                typeof(PaymentBatch),
                GetPaymentBatch
            );
        }

        [Fact]
        public void TestRequestInquiryModel()
        {
            ExecuteNotificationUrlTest(
                JsonPathRequestInquiryModel,
                typeof(RequestInquiry),
                GetRequestInquiry
            );
        }

        [Fact]
        public void TestRequestResponseModel()
        {
            ExecuteNotificationUrlTest(
                JsonPathRequestResponseModel,
                typeof(RequestResponse),
                GetRequestResponse
            );
        }

        [Fact]
        public void TestScheduledInstanceModel()
        {
            ExecuteNotificationUrlTest(
                JsonPathScheduleInstanceModel,
                typeof(ScheduleInstance),
                GetScheduleInstance
            );
        }

        [Fact]
        public void TestScheduledPaymentModel()
        {
            ExecuteNotificationUrlTest(
                JsonPathSchedulePaymentModel,
                typeof(SchedulePayment),
                GetSchedulePayment
            );
        }

        [Fact]
        public void TestShareInviteBankModel()
        {
            ExecuteNotificationUrlTest(
                JsonPathShareInviteBankInquiryModel,
                typeof(ShareInviteBankInquiry),
                GetShareInviteBankInquiry
            );
        }

        [Fact]
        public void TestShareInviteBankResponse()
        {
            ExecuteNotificationUrlTest(
                JsonPathShareInviteBankResponseModel,
                typeof(ShareInviteBankResponse),
                GetShareInviteBankResponse
            );
        }
    }
}