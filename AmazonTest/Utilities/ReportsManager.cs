using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NPOI.OpenXmlFormats.Dml.WordProcessing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonTest.Utilities
{
    internal class ReportsManager
    {
        private static ExtentReports _extent;
        private  static ExtentSparkReporter _sparkreporter;

        public static ExtentReports GetExtentReports()
        {
            if (_extent == null)
            {
                // Create a 'Reports' folder inside your build directory
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string reportPath = Path.GetFullPath(Path.Combine(baseDirectory, @"C:\Users\DELL\source\repos\AmazonTest\AmazonTest\Reports"));
                string fullPath = Path.Combine(reportPath, "AutomationReport.html");

                // Initialize the Spark HTML reporter
                _sparkreporter = new ExtentSparkReporter(fullPath);

                // Optional styling configuration
                _sparkreporter.Config.DocumentTitle = "Automation Test Execution Report";
                _sparkreporter.Config.ReportName = "Selenium Regression Results";
                _sparkreporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

                _extent = new ExtentReports();
                _extent.AttachReporter(_sparkreporter);

                // Add system metadata to the report dashboard
                _extent.AddSystemInfo("Environment", "QA");
                _extent.AddSystemInfo("Tester", "Shahab");
                _extent.AddSystemInfo("Browser", "Chrome");
            }
            return _extent;
        }
    }
}
