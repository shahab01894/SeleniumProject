using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonTest.Pages
{
    internal class Signup
    {
        private readonly IWebDriver driver;
        private readonly By lnkElements=By.XPath("//h5[text()='Elements']");

        private readonly By lnkwebTables = By.XPath("//li[contains(@class, 'btn')]//span[text()='Web Tables']");
        private readonly By textboxes = By.XPath("//span[text()='Text Box']");
        private readonly By txtFullName = By.XPath("//input[@placeholder='Full Name']");
        private readonly By btnSubmit = By.CssSelector("#submit");
        private readonly By btnAdd = By.CssSelector("#addNewRecordButton");

        private readonly By fname = By.XPath("//input[@placeholder='First Name']");
        private readonly By lname = By.XPath(" //input[@placeholder='Last Name']");
        private readonly By email = By.XPath(" //input[@placeholder='name@example.com']");
        private readonly By age = By.XPath("//input[@placeholder='Age']");
        private readonly By salary = By.XPath("//input[@placeholder='Salary']");
        private readonly By department = By.XPath(" //input[@placeholder='Department']");
        private readonly By  btnsubmit= By.CssSelector("#submit");
        private readonly By btnAddButton = By.CssSelector("#addNewRecordButton");
        private readonly By txtEmail = By.CssSelector("#email");
        private readonly By txtPassword = By.CssSelector("#password");
        private readonly By btnLogin = By.XPath("//button[text()='Log in']");
        private readonly By ErrorMessage = By.XPath(" //div[text()='Invalid email or password']");
       




        public Signup(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void clickElements()
        { 
          WebDriverWait wait =new WebDriverWait(driver,TimeSpan.FromSeconds(5));
          var lnkElements1 = wait.Until(d => d.FindElement(lnkElements));
          lnkElements1.Click();

        }
        public void ClickWebTableAndEnterdata()
        {
            
           driver.FindElement(btnAddButton).Click();
        }

        public void submitWebTable(string fname1, string lname1, string email1, string age1, string salary1, string department1)
        {
            driver.FindElement(fname).SendKeys(fname1);
            driver.FindElement(lname).SendKeys(lname1);
            driver.FindElement(email).SendKeys(email1);
            driver.FindElement(age).SendKeys(age1);
            driver.FindElement(salary).SendKeys(salary1);
            driver.FindElement(department).SendKeys(department1);
            driver.FindElement(btnsubmit).Click();

        }
        public void SignIn(string username, string password)
        {
            // Wait until the username field is present & interactable
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var email = wait.Until(d => d.FindElement(txtEmail));
            email.Clear();
            email.SendKeys(username);
            var passwd = wait.Until(d => d.FindElement(txtPassword));
            passwd.Clear();
            passwd.SendKeys(password);

            driver.FindElement(btnLogin).Click();
        }
        public bool IsLoginErrorDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            try
            {
                return wait.Until(d => d.FindElement(ErrorMessage)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
