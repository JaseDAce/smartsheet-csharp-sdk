﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Collections.Generic;
using System.Configuration;

namespace IntegrationTestSDK
{
    [TestClass]
    public class ReportResourcesTest
    {
        [Ignore]
        [TestMethod]
        public void TestReportResources()
        {
            SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();

            //Must manually create a Report at smartsheet.com and paste reportId and reportName below.
            long reportId = 8105980715132804;
            string reportName = "New Blank Report";

            Report report = smartsheet.ReportResources.GetReport(reportId, new ReportInclusion[] { ReportInclusion.ATTACHMENTS, ReportInclusion.DISCUSSIONS }, null, null);
            Assert.IsTrue(report.Name == reportName);
            SheetEmail email = new SheetEmail.CreateSheetEmail(new Recipient[] { new Recipient { Email = "jason.hiles@kinsmengroup.com" } }, SheetEmailFormat.PDF).SetCcMe(true).Build();
            smartsheet.ReportResources.SendReport(reportId, email);

            PaginatedResult<Report> reportResults = smartsheet.ReportResources.ListReports(null);
            Assert.IsTrue(reportResults.Data.Count == 1);
            Assert.IsTrue(reportResults.Data[0].Name == reportName);
        }
    }
}