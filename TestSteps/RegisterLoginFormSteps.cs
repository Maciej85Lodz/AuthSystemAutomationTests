using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace AuthSystemAutomationTests.TestSteps
{
    [Binding]
    public class RegisterLoginFormSteps : IDisposable
    {
        private ChromeDriver chromeDriver;
        public RegisterLoginFormSteps() => chromeDriver = new ChromeDriver();

        #region Browser
        [Given(@"Open AuthSystem in browser")]
        public void GivenOpenAuthSystemInBrowser()
        {
            if (FeatureContext.Current.FeatureInfo.Title.Contains("Login"))
            {
                chromeDriver.Navigate().GoToUrl("https://localhost:44308/Identity/Account/Login");
                Assert.IsNotNull(chromeDriver.Url);
                Assert.IsTrue(chromeDriver.Title == "Log in - AuthSystem");
            }
            else
            {
                chromeDriver.Navigate().GoToUrl("https://localhost:44308/Identity/Account/Register");
                Assert.IsNotNull(chromeDriver.Url);
                Assert.IsTrue(chromeDriver.Title == "Register - AuthSystem");
            }
        }
        #endregion


        #region Register
        [Given(@"fill up the form using the data (.*) (.*) (.*) (.*) with (.*)")]
        public void GivenFillUpTheFormUsingTheDataWith(string name, string lastname, string email, string password, string confirmPassword)
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
            confirmPasswordFiled.SendKeys(confirmPassword);
        }

        [When(@"Click Register button")]
        public void WhenClickRegisterButton()
        {
            var clickRegisterBtn = chromeDriver.FindElementByCssSelector(
                "body > div > main > div > div > div > div.card-content > div > div > form > button");
            clickRegisterBtn.Click();
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(5));
        }

        [Then(@"check if the home page is displayed")]
        public void ThenCheckIfTheHomePageIsDisplayed()
        {
            var homePage = chromeDriver.Title;
            var logoutButton = chromeDriver.FindElementById("logout");


            Assert.AreEqual("Home Page - AuthSystem", homePage);
            Assert.IsTrue(logoutButton.Displayed);
        }

        [Then(@"check if error message is displayed")]
        public void ThenCheckIfErrorMessageIsDisplayed_()
        {
            var errorMessage =
                chromeDriver.FindElementByXPath("/html/body/div/main/div/div/div/div[2]/div/div/form/div[1]/ul/li");

            if (errorMessage.Text.Contains("Password"))
            {
                Assert.IsTrue(errorMessage.Text == "The Password must be at least 6 and at max 100 characters long.");
            }
            else if (errorMessage.Text.Contains("Email"))
            {
                Assert.IsTrue(errorMessage.Text == "The Email field is not a valid e-mail address.");
            }
            else if (errorMessage.Text.Contains("password") || errorMessage.Text.Contains("confirmation"))
            {
                Assert.IsTrue(errorMessage.Text == "The password and confirmation password do not match.");
            }
            else if (errorMessage.Text.Contains("First Name"))
            {
                Assert.IsTrue(errorMessage.Text == "The First Name field is required.");
            }
            else if (errorMessage.Text.Contains("Last Name"))
            {
                Assert.IsTrue(errorMessage.Text == "The Last Name field is required.");
            }
        }
        #endregion

        #region Login
        [Given(@"fill up the login form with data (.*) (.*)")]
        public void GivenFillUpTheLoginFormWithData(string email, string password)
        {
            var emailFiled = chromeDriver.FindElementByXPath("//*[@id=\"Input_Email\"]");
            var passwordFiled = chromeDriver.FindElementById("Input_Password");
            
            emailFiled.SendKeys(email);
            passwordFiled.SendKeys(password);
        }

        [When(@"click login button")]
        public void WhenClickLoginButton()
        {
            IWebElement button = chromeDriver.FindElement(By.XPath("//*[@id=\"account\"]/div[5]/button")); 
            Actions action = new Actions(chromeDriver);
            action.MoveToElement(button).Perform(); 
            button.Click();
        }

        [Then(@"check if the error message is displayed")]
        public void ThenCheckIfTheErrorMessageIsDisplayed()
        {
            var errorMessage =
                chromeDriver.FindElementByCssSelector("#account > div.text-danger.validation-summary-errors > ul > li");
           
            if (errorMessage.Text.Contains("login"))
            {
                Assert.IsTrue(errorMessage.Text == "Invalid login attempt.");
            }
        }

        [Then(@"check if the error field message is displayed")]
        public void ThenCheckIfTheErrorFieldMessageIsDisplayed()
        {
            var errorMessage =
                chromeDriver.FindElementByCssSelector("#account > div.text-danger.validation-summary-errors > ul > li");

            if (errorMessage.Text.Contains("Email"))
            {
                var emptyEmailFiledError = chromeDriver.FindElementById("Input_Email-error");
                if (emptyEmailFiledError.Displayed)
                {
                    Assert.IsTrue(errorMessage.Text == "The Email field is required.");
                }
            }
            else if (errorMessage.Text.Contains("Password"))
            {
                var emptyPassFieldError = chromeDriver.FindElementById("Input_Password-error");
                if (emptyPassFieldError.Displayed)
                {
                    Assert.IsTrue(errorMessage.Text == "The Password field is required.");
                }
            }
        }

        #endregion

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
