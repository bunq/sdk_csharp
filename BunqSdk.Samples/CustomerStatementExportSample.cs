using System;
using System.Collections.Generic;
using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using Bunq.Sdk.Samples.Utils;

namespace Bunq.Sdk.Samples
{
    public class CustomerStatementExportSample : ISample
    {
        /// <summary>
        /// Constant to translate weeks to milliseconds.
        /// </summary>
        private const int IndexFirst = 0;

        /// <summary>
        /// Date format for Customer Statement Export endpoint.
        /// </summary>
        private const string FormatDateStatement = "yyyy-MM-dd";

        /// <summary>
        /// Format of the statement file requested.
        /// </summary>
        private const string StatementFormat = "PDF";

        /// <summary>
        /// Measure of any time unit when none of it is needed.
        /// </summary>
        private const int TimeUnitCountNone = 0;

        /// <summary>
        /// Measure of any time unit when none of it is needed.
        /// </summary>
        private const int DaysInWeek = 7;

        public void Run()
        {
            var apiContext = ApiContext.Restore();
            var timeSpanWeek = new TimeSpan(
                DaysInWeek,
                TimeUnitCountNone,
                TimeUnitCountNone,
                TimeUnitCountNone
            );
            var dateStart = DateTime.Now.Subtract(timeSpanWeek);
            var dateEnd = DateTime.Now;

            var customerStatementMap = new Dictionary<string, object>
            {
                {CustomerStatementExport.FieldStatementFormat, StatementFormat},
                {CustomerStatementExport.FieldDateStart, dateStart.ToString(FormatDateStatement)},
                {CustomerStatementExport.FieldDateEnd, dateEnd.ToString(FormatDateStatement)},
            };

            var userId = User.List(apiContext).Value[IndexFirst].UserCompany.Id;

            if (userId != null)
            {
                var userIdInt = (int) userId;
                var monetaryAccountId = MonetaryAccountBank.List(apiContext, userIdInt).Value[IndexFirst].Id;

                if (monetaryAccountId != null)
                {
                    var monetaryAccountIdInt = (int) monetaryAccountId;
                    var customerStatementId = CustomerStatementExport.Create(apiContext, customerStatementMap,
                        userIdInt, monetaryAccountIdInt).Value;

                    CustomerStatementExport.Delete(apiContext, userIdInt, monetaryAccountIdInt, customerStatementId);
                }
            }

            apiContext.Save();
        }
    }
}
