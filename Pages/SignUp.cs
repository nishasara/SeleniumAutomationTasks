using AventStack.ExtentReports;
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

    class SignUp
    {
        bool FirstTime = false;
        IWebDriver driver;
        //Initialise the web elements
        public SignUp(bool FirstTime, IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.FirstTime = FirstTime;            
        }

        //Identify join
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/button")]
        private IWebElement Join { get; set; }

        //Identify First Name
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/form/div[1]/input")]
        private IWebElement FirstName { get; set; }

        //Identify Last Name
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/form/div[2]/input")]
        private IWebElement LastName { get; set; }

        //Identify Email address
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/form/div[3]/input")]
        private IWebElement Email { get; set; }

        //Identify Password
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/form/div[4]/input")]
        private IWebElement Password { get; set; }

        //Idenify Confirm Password
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/form/div[5]/input")]
        private IWebElement CnfrmPswrd { get; set; }

        //Identify the checkbox for terms and conditions
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/form/div[6]/div/div/input")]
        private IWebElement TermsCndtnsChkbox { get; set; }

        //Identify the Join button
        [FindsBy(How = How.XPath, Using = "//*[@id='submit-btn']")]
        private IWebElement JoinButton { get; set; }

        //Identify the registration success pop up
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement PopUp { get; set; }

        //Identify the email validation text
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/form/div[3]/div")]
        private IWebElement EmailValidation { get; set; }


        //Function to register new user
        public void Register()
        {            
            //Click Join to sign up for the skill exchange Portal
            Join.Click();
            
            //Enter the data for First name
            FirstName.SendKeys(ServiceData.FirstName(3));

            //Enter the data for Last name
            LastName.SendKeys(ServiceData.LastName(3));

            //Enter the data for EmailID
            Email.SendKeys(ServiceData.EmailIDSignUp(3));

            //Enter the data for Password
            Password.SendKeys(ServiceData.PasswordSignUp(3)); 

            //Enter the data for Confirm Password
            CnfrmPswrd.SendKeys(ServiceData.CnfrmPasswordSignUp(3));

            //Check on the terms and conditions check box prior to clicking the Join button
            TermsCndtnsChkbox.Click();

            //Click on the Join button to complete the registration
            JoinButton.Click();

            UnitTest1.test.Log(Status.Info, "Entered Details and Clicked Join");

            //Implicit wait for the registeration pop up to be available
            Wait.wait(2, driver);

            try
            {
                if (FirstTime)
                {
                    if (PopUp.Text == "Registration Successfull")
                    {
                        UnitTest1.test.Log(Status.Info, "Entered Details and Clicked Join");
                        TestContext.WriteLine(PopUp.Text);
                    }
                        
                }
                else
                {
                    String EmailValidationMsg = EmailValidation.Text;
                    if (EmailValidationMsg == "This email has already been used to register an account.")
                        TestContext.WriteLine("The account has already been created with this emailID, Please log in using exisitng account details");
                }

            }
            catch (Exception e)
            {
                Assert.Fail("Registration failed due to 1 or more errors. Make sure that there isn't an existing account", e.Message);
            }
        }
    }
}
