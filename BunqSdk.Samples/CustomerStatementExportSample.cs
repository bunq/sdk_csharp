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
        private const int INDEX_FIRST = 0;

        /// <summary>
        /// Date format for Customer Statement Export endpoint.
        /// </summary>
        private const string FORMAT_DATE_STATEMENT = "yyyy-MM-dd";

        /// <summary>
        /// Format of the statement file requested.
        /// </summary>
        private const string STATEMENT_FORMAT = "PDF";

        /// <summary>
        /// Measure of any time unit when none of it is needed.
        /// </summary>
        private const int TIME_UNIT_COUNT_NONE = 0;

        /// <summary>
        /// Measure of any time unit when none of it is needed.
        /// </summary>
        private const int DAYS_IN_WEEK = 7;

        public void Run()
        {
            BunqContext.LoadApiContext(ApiContext.Restore());
            var timeSpanWeek = new TimeSpan(
                DAYS_IN_WEEK,
                TIME_UNIT_COUNT_NONE,
                TIME_UNIT_COUNT_NONE,
                TIME_UNIT_COUNT_NONE
            );
            var dateStart = DateTime.Now.Subtract(timeSpanWeek);
            var dateEnd = DateTime.Now;

            var userId = BunqContext.UserContext.UserId;

            var userIdInt = userId;
            var monetaryAccountId = BunqContext.UserContext.PrimaryMonetaryAccountBank.Id.Value;

                var monetaryAccountIdInt = monetaryAccountId;
                var customerStatementId = CustomerStatementExport.Create(STATEMENT_FORMAT,
                    dateStart.ToString(FORMAT_DATE_STATEMENT), dateEnd.ToString(FORMAT_DATE_STATEMENT)).Value;

                CustomerStatementExport.Delete(customerStatementId);

            BunqContext.ApiContext.Save();
        }
    }
}