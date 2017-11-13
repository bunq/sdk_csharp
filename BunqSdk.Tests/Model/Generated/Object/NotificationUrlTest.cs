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
        private const string GET_PAYMENT = "Payment";
        private const string GET_BUNQ_ME_TAB = "BunqMeTab";
        private const string GET_CHAT_MESSAGE_ANNOUNCEMENT = "ChatMessageAnnouncement";
        private const string GET_DRAFT_PAYMENT = "DraftPayment";
        private const string GET_MASTER_CARD_ACTION = "MasterCardAction";
        private const string GET_MONETARY_ACCOUNT_BANK = "MonetaryAccountBank";
        private const string GET_PAYMENT_BATCH = "PaymentBatch";
        private const string GET_REQUEST_INQUIRY = "RequestInquiry";
        private const string GET_REQUEST_RESPONSE = "RequestResponse";
        private const string GET_SCHEDULE_PAYMENT = "ScheduledPayment";
        private const string GET_SCHEDULE_INSTANCE = "ScheduledInstance";
        private const string GET_SHARE_INVITE_BANK_INQUIRY = "ShareInviteBankInquiry";
        private const string GET_SHARE_INVITE_BANK_RESPONSE = "ShareInviteBankResponse";
        
        /// <summary>
        /// Assert error constants.
        /// </summary>
        private const string ASSERT_SHOULD_NOT_REACH_THIS_CODE_ERROR = "Congratulations you\"ve reached unreachable code.";
        private const string ASSERT_JSON_DECODE_ERROR = "Error accorded while decoding the JSON file.";
        private const string ASSERT_OBJECT_IS_NULL_ERROR = "The field object of NotificationUrl is null.";
        
        /// <summary>
        /// Model json paths constants.
        /// </summary>
        private const string BASE_PATH_JSON_MODEL = "../../../Resources/NotificationUrlJsons";
        private const string JSON_PATH_MUTATION_MODEL = BASE_PATH_JSON_MODEL + "/Mutation.json";
        private const string JSON_PATH_BUNQ_ME_TAB_MODEL = BASE_PATH_JSON_MODEL + "/BunqMeTab.json";
        private const string JSON_PATH_CHAT_MESSAGE_ANNOUNCEMENT_MODEL = BASE_PATH_JSON_MODEL + 
                                                                         "/ChatMessageAnnouncement.json";
        private const string JSON_PATH_DRAFT_PAYMENT_MODEL = BASE_PATH_JSON_MODEL + "/DraftPayment.json";
        private const string JSON_PATH_MASTER_CARD_ACTION_MODEL = BASE_PATH_JSON_MODEL + "/MasterCardAction.json";
        private const string JSON_PATH_MONETARY_ACCOUNT_BANK_MODEL = BASE_PATH_JSON_MODEL + "/MonetaryAccountBank.json";
        private const string JSON_PATH_PAYMENT_BATCH_MODEL = BASE_PATH_JSON_MODEL + "/PaymentBatch.json";
        private const string JSON_PATH_REQUEST_INQUIRY_MODEL = BASE_PATH_JSON_MODEL + "/RequestInquiry.json";
        private const string JSON_PATH_REQUEST_RESPONSE_MODEL = BASE_PATH_JSON_MODEL + "/RequestResponse.json";
        private const string JSON_PATH_SCHEDULE_PAYMENT_MODEL = BASE_PATH_JSON_MODEL + "/ScheduledPayment.json";
        private const string JSON_PATH_SCHEDULE_INSTANCE_MODEL = BASE_PATH_JSON_MODEL + "/ScheduledInstance.json";
        private const string JSON_PATH_SHARE_INVITE_BANK_INQUIRY_MODEL = BASE_PATH_JSON_MODEL + 
                                                                         "/ShareInviteBankInquiry.json";

        private const string JSON_PATH_SHARE_INVITE_BANK_RESPONSE_MODEL = BASE_PATH_JSON_MODEL +
                                                                          "/ShareInviteBankResponse.json";
        
        /// <summary>
        /// Model root key.
        /// </summary>
        private const string KEY_NOTIFICATION_URL_MODEL = "NotificationUrl";

        private void ExeceuteNotificationUrlTest(
            string expectedJsonFileName,
            Type classNameExpected,
            string referencedObjectGetterName)
        {
            var jsonString = ReadJsonFromFile(expectedJsonFileName);
            var notificationUrl = BunqModel.FromJsonString<NotificationUrl>(jsonString);
            
            Assert.NotNull(notificationUrl);
            Assert.NotNull(notificationUrl.Object);

            var model = notificationUrl.Object.GetType().GetProperty(referencedObjectGetterName).GetValue(
                notificationUrl.Object);
            var referencedModel = notificationUrl.Object.GetReferencedObject();
            
            Assert.NotNull(model);
            Assert.NotNull(referencedModel);
            Assert.IsType(classNameExpected, referencedModel);
            Assert.Equal(classNameExpected, referencedModel.GetType());
        }

        private static string ReadJsonFromFile(string fileName)
        {
            var fileContentString = File.ReadAllText(fileName);
            var jsonObj = JObject.Parse(fileContentString);
            var notificationUrlObject = jsonObj[KEY_NOTIFICATION_URL_MODEL];
            
            Assert.NotNull(notificationUrlObject);

            return notificationUrlObject.ToString();
        }

        [Fact]
        public void TestMutationModel()
        {
            ExeceuteNotificationUrlTest(
                JSON_PATH_MUTATION_MODEL,
                typeof(Payment),
                GET_PAYMENT
                );
        }
        
        [Fact]
        public void TestBunqMeTabModel()
        {
            ExeceuteNotificationUrlTest(
                JSON_PATH_BUNQ_ME_TAB_MODEL,
                typeof(BunqMeTab),
                GET_BUNQ_ME_TAB
                );
        }   
        
        [Fact]
        public void TestChatMessageAnnouncementModel()
        {
            ExeceuteNotificationUrlTest(
                JSON_PATH_CHAT_MESSAGE_ANNOUNCEMENT_MODEL,
                typeof(ChatMessageAnnouncement),
                GET_CHAT_MESSAGE_ANNOUNCEMENT
                );
        }        
        
        [Fact]
        public void TestDraftPaymentModel()
        {
            ExeceuteNotificationUrlTest(
                JSON_PATH_DRAFT_PAYMENT_MODEL,
                typeof(DraftPayment),
                GET_DRAFT_PAYMENT
                );
        }      
        
        [Fact]
        public void TestMasterCardActionModel()
        {
            ExeceuteNotificationUrlTest(
                JSON_PATH_MASTER_CARD_ACTION_MODEL,
                typeof(MasterCardAction),
                GET_MASTER_CARD_ACTION
                );
        }  
        
        [Fact]
        public void TestMonetaryAccountBankModel()
        {
            ExeceuteNotificationUrlTest(
                JSON_PATH_MONETARY_ACCOUNT_BANK_MODEL,
                typeof(MonetaryAccountBank),
                GET_MONETARY_ACCOUNT_BANK
                );
        }    
        
        [Fact]
        public void TestPaymentBatchModel()
        {
            ExeceuteNotificationUrlTest(
                JSON_PATH_PAYMENT_BATCH_MODEL,
                typeof(PaymentBatch),
                GET_PAYMENT_BATCH
                );
        }     
        
        [Fact]
        public void TestRequestInquiryModel()
        {
            ExeceuteNotificationUrlTest(
                JSON_PATH_REQUEST_INQUIRY_MODEL,
                typeof(RequestInquiry),
                GET_REQUEST_INQUIRY
                );
        }     
        
        [Fact]
        public void TestRequestResponseModel()
        {
            ExeceuteNotificationUrlTest(
                JSON_PATH_REQUEST_RESPONSE_MODEL,
                typeof(RequestResponse),
                GET_REQUEST_RESPONSE
                );
        }  
        
        [Fact]
        public void TestScheduledInstanceModel()
        {
            ExeceuteNotificationUrlTest(
                JSON_PATH_SCHEDULE_INSTANCE_MODEL,
                typeof(ScheduleInstance),
                GET_SCHEDULE_INSTANCE
                );
        }     
        
        [Fact]
        public void TestScheduledPaymentModel()
        {
            ExeceuteNotificationUrlTest(
                JSON_PATH_SCHEDULE_PAYMENT_MODEL,
                typeof(SchedulePayment),
                GET_SCHEDULE_PAYMENT
                );
        }       
        
        [Fact]
        public void TestShareInviteBankModel()
        {
            ExeceuteNotificationUrlTest(
                JSON_PATH_SHARE_INVITE_BANK_INQUIRY_MODEL,
                typeof(ShareInviteBankInquiry),
                GET_SHARE_INVITE_BANK_INQUIRY
                );
        }       
        
        [Fact]
        public void TestShareInviteBankResponse()
        {
            ExeceuteNotificationUrlTest(
                JSON_PATH_SHARE_INVITE_BANK_RESPONSE_MODEL,
                typeof(ShareInviteBankResponse),
                GET_SHARE_INVITE_BANK_RESPONSE
                );
        }
    }
}
