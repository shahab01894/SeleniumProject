using AmazonTest.Pages;
using AmazonTest.Utilities;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AmazonTest
{
    public class Tests
    {
      
        private IWebDriver driver;
        private Signup _signup;
        private CommonUtilities _utilities;
        protected ExtentReports extent;
        protected ExtentTest test;
        [SetUp]
        public void Setup()
        {
            extent = ReportsManager.GetExtentReports();
            test = extent.CreateTest("Data Driven Employee Form Test", "Verifies employee registration using Excel data.");
            test.Log(Status.Info, "Navigated to the portal");
            var options = new ChromeOptions();

            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);
            options.AddArgument("--incognito");

            // Required for CI runners (no display available)
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--window-size=1920,1080");

                      
            //options.AddArgument("--incognito");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(MyResource.DemoURl);
            //driver.Navigate().GoToUrl("https://demoqa.com/webtables");
           // driver.Navigate().GoToUrl("https://dashboard.cstoregenie.app/");
        
            driver.Manage().Window.Maximize();

            _signup= new Signup(driver);
            _utilities = new CommonUtilities();
           
        }

        [Test]
        public void Test1()
        {
            // _signup.clickElements();
             _signup.ClickWebTableAndEnterdata();
            //string username =_utilities.ReadDataFromExcel();
            test.Log(Status.Info, "Reading test data from Excel (TestData/Book1.xlsx)...");
            var employee = _utilities.GetEmployeeData();
            _signup.submitWebTable(employee["FirstName"], employee["Lastname"], employee["Email"], employee["Age"], employee["Salary"], employee["Department"]);
            test.Log(Status.Pass, "Form submitted successfully.");
        }
        [Test]
        public void CStoreLogin()
        {
            var userDetails = _utilities.GetEmployeeData();
            test.Log(Status.Info, "Reading test data from Excel (TestData/Book1.xlsx)...");
            _signup.SignIn(userDetails["email"], userDetails["password"]);
            bool value=_signup.IsLoginErrorDisplayed();
            if (value)
            {
                test.Log(Status.Fail, "Can you please enter the valid username and password");

            }
            else
            {
                test.Log(Status.Pass, "User login successfully.");
            }
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
            extent.Flush();

        }
    }
}
