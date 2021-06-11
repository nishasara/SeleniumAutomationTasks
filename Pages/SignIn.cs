using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SkillSwap.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SkillSwap.Pages
{
    class SignIn
    {
        IWebDriver driver;
        
        bool ReadPasswordBasedOnRowNum;
                
        public SignIn(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            ReadPasswordBasedOnRowNum = false;
        }

        //Identify signIn
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/a")]
        private IWebElement signIn { get; set; }

        //Identify the Email textbox
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement email { get; set; }

        //Identify the Password textbox
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement pswrd { get; set; }

        //Identify the Login button and click
        [FindsBy(How = How.XPath, Using = "//html/body/div[2]/div/div/div[1]/div/div[4]/button")]
        private IWebElement login { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")]
        private IWebElement User { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Password must be at least 6 characters')]")]
        private IWebElement PswrdValidationLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Please enter a valid email address')]")]
        private IWebElement EmailValidationLabel { get; set; }


        public void LoginSteps(string TestCaseTitle, int rownum)
        {

            //Wait for login page to be loaded and 'Sign In' to become visible
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='home']/div/div/div[1]/div/a");

            //Click on Sign in button
            signIn.Click();

            //Wait for email textbox to be present
            Wait.ElementPresent(driver, "Name", "email");

            if (TestCaseTitle == "Valid Username and Valid Password")
            {
                

                //Read the emailID data from excel and enter the data into the Email Textbox
                email.SendKeys(ServiceData.ReadSignInEmailID(rownum));

                //Read the Password data from excel and enter the data into the Password Textbox
                pswrd.SendKeys(ServiceData.ReadSignInPassword(rownum));

                //Click on the Login button
                login.Click();

                UnitTest1.test.Log(Status.Info, "Logged In successfully");

                //Wait for Home page to be loaded by checking if 'Sign Out' is visible
                Wait.ElementIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[2]/button");

                //Validate the HomePage after Signing In
                ValidateHomePage();

                UnitTest1.test.Log(Status.Info, "Signed In with Valid Username and Valid Password");
            }
            else if (TestCaseTitle == "Valid Username and Blank Password")
            {
                //Read the emailID data from excel and enter the data into the Email Textbox
                email.SendKeys(ServiceData.ReadSignInEmailID(rownum));

                //Click on the Login button
                login.Click();

                UnitTest1.test.Log(Status.Info, "Clicked Login after providing Valid Username and Blank Password");

                //Wait for password validation tag to be visible
                Wait.ElementIsVisible(driver, "XPath", "//div[contains(text(),'Password must be at least 6 characters')]");

                //Strings to store the expected and actual password validation label
                string PswrdValdtnText = PswrdValidationLabel.Text;
                string PswrdValdtnTextExp = "Password must be at least 6 characters";

                //Validate the label for Blank Password
                Assert.That(PswrdValdtnText, Is.EqualTo(PswrdValdtnTextExp));
            }
            else if (TestCaseTitle == "Blank Username and Valid Password")
            {
                //Read the Password data from excel and enter the data into the Password Textbox
                pswrd.SendKeys(ServiceData.ReadSignInPassword(rownum));

                //Click on the Login button
                login.Click();

                UnitTest1.test.Log(Status.Info, "Clicked Login after providing Blank Username and Valid Password");

                //Wait for password validation tag to be visible
                Wait.ElementIsVisible(driver, "XPath", "//div[contains(text(),'Please enter a valid email address')]");

                //Strings to store the expected and actual Email validation label
                String EmailValdtnText = EmailValidationLabel.Text;
                String EmailValdtnTextExp = "Please enter a valid email address";

                //Validate the label for Blank Username
                Assert.That(EmailValdtnText, Is.EqualTo(EmailValdtnTextExp));

            }

            else if (TestCaseTitle == "Blank Username and Blank Password")
            {
                //Click on the Login button
                login.Click();

                UnitTest1.test.Log(Status.Info, "Clicked Login after providing Blank Username and Blank Password");

                //Wait for password validation tag to be visible
                Wait.ElementIsVisible(driver, "XPath", "//div[contains(text(),'Please enter a valid email address')]");

                //Strings to store the expected and actual Email validation label
                String EmailValdtnText = EmailValidationLabel.Text;
                String EmailValdtnTextExp = "Please enter a valid email address";

                //Strings to store the expected and actual password validation label
                String PswrdValdtnText = PswrdValidationLabel.Text;
                String PswrdValdtnTextExp = "Password must be at least 6 characters";

                //Validate the label for Blank Username and Blank Password
                Assert.That(EmailValdtnText, Is.EqualTo(EmailValdtnTextExp));
                Assert.That(PswrdValdtnText, Is.EqualTo(PswrdValdtnTextExp));

            }

            else if (TestCaseTitle == "Valid Username and InValid Password")
            {
                //Read the emailID data from excel and enter the data into the Email Textbox
                email.SendKeys(ServiceData.ReadSignInEmailID(rownum));

                //Read the Password data from excel and enter the data into the Password Textbox
                pswrd.SendKeys(ServiceData.ReadSignInPassword(rownum));

                //Click on the Login button
                login.Click();

                UnitTest1.test.Log(Status.Info, "Clicked Login after providing Valid Username and InValid Password");

                //Wait for password validation tag to be visible
                Wait.ElementIsVisible(driver, "XPath", "//div[contains(text(),'Password must be at least 6 characters')]");

                //String to hold the password validation label
                String PswrdValdtnText = PswrdValidationLabel.Text;
                String PswrdValdtnTextExp = "Password must be at least 6 characters";

                //Validate the label for password field
                Assert.That(PswrdValdtnText, Is.EqualTo(PswrdValdtnTextExp));

            }

            else if (TestCaseTitle == "Change to another valid password")
            {
                //Read the emailID data from excel and enter the data into the Email Textbox
                email.SendKeys(ServiceData.ReadEmailID(rownum));

                //Read the Password data from excel and enter the data into the Password Textbox
                pswrd.SendKeys(ServiceData.ReadCurrentPassword(rownum));

                //Click on the Login button
                login.Click();

                //Wait for Home page to be loaded by checking if 'Sign Out' is visible
                Wait.ElementIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[2]/button");

                //Validate the HomePage after singing in
                ValidateHomePage();

            }
        }

        
        public void LoginStepsAfterChangePassword(int rownum)
        {
            //Wait for login page to be loaded and 'Sign In' to become visible
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='home']/div/div/div[1]/div/a");

            //Click on Sign in button
            signIn.Click();
                       
            //Wait for email textbox to be present
            Wait.ElementPresent(driver, "Name", "email");
                       
            //Read the emailID data from excel and enter the data into the Email Textbox
            email.SendKeys(ServiceData.ReadEmailID(rownum));

            //Read the Password data from excel and enter the data into the Password Textbox
            pswrd.SendKeys(ServiceData.ReadNewPassword(rownum));
            
            //Click on the Login button
            login.Click();

            UnitTest1.test.Log(Status.Info, "Clicked Sign In After providing new password");

            try
            {
                //Wait for Home page to be loaded by checking if 'Sign Out' is visible
                Wait.ElementIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[2]/button");
            }
            catch (Exception e)
            {
                TestContext.WriteLine("Unsuccessfull Login", e.Message);
            }
        }

        public void ValidateHomePage()
        {

            try
            { 
                if (User.Text == "Hi Sara")
                {
                    TestContext.WriteLine($"Logged in successfully and message {User.Text} is displayed on home page");
                }

            }
            catch (Exception e)
            {
                TestContext.WriteLine("Home page not displayed", e.Message);
            }
        }
    }
}
