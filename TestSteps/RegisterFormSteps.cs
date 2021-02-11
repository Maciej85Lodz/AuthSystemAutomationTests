using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AuthSystemAutomationTests.TestSteps
{
    [Binding]
    public class RegisterFormSteps : IDisposable
    {
        private ChromeDriver chromeDriver;
        public RegisterFormSteps() => chromeDriver = new ChromeDriver();

        [Given(@"Open AuthSystem in browser")]
        public void GivenOpenAuthSystemInBrowser()
        {
            chromeDriver.Navigate().GoToUrl("https://localhost:44308/Identity/Account/Register");
            Assert.IsNotNull(chromeDriver.Url);
            Assert.IsTrue(chromeDriver.Title == "Register - AuthSystem");
        }

        [Given(@"fill up the form using the data (.*) (.*) (.*) and (.*)")]
        public void GivenFillUpTheFormUsingTheDataAnd(string name, string lastname, string email, string password)
        {
            var nameField = chromeDriver.FindElementByCssSelector("#Input_FirstName");
            var lastnameField = chromeDriver.FindElementByCssSelector("#Input_LastName");
            var emailFiled = chromeDriver.FindElementByXPath("//*[@id=\"Input_Email\"]");
            var passwordField = chromeDriver.FindElementByName("Input.Password");
            var confirmPasswordFiled = chromeDriver.FindElementByName("Input.ConfirmPassword");
            
            nameField.SendKeys(name);
            lastnameField.SendKeys(lastname);
            emailFiled.SendKeys(email);
            passwordField.SendKeys(password);
            confirmPasswordFiled.SendKeys(password);
        }

        [When(@"Click Register button")]
        public void WhenClickRegisterButton()
        {
            var clickRegisterBtn = chromeDriver.FindElementByCssSelector(
                "body > div > main > div > div > div > div.card-content > div > div > form > button");
            clickRegisterBtn.Click();
        }

        [Then(@"check if message about correct registration is displayed\.")]
        public void WhenCheckIfMessageAboutCorrectRegistrationIsDisplayed_()
        {
            var homePage = chromeDriver.Title;

            Assert.AreEqual("Home Page - AuthSystem",homePage);
        }

        public void Dispose()
        {
            if (chromeDriver != null)
            {
                chromeDriver.Close();
                chromeDriver.Dispose();
                chromeDriver.Dispose();
            }
        }
    }
}
