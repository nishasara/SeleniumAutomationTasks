using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SkillSwap.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillSwap.Pages
{
    class SentRequest
    {
        //Declare the driver
        IWebDriver driver;

        //Constructor to initialise the driver and webelements
        public SentRequest(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }


        //Identify the Category Field
        [FindsBy(How = How.XPath, Using = "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[1]")]
        private IWebElement CategoryDetail { get; set; }

        //Identify the Title Field
        [FindsBy(How = How.XPath, Using = "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[2]/a")]
        private IWebElement TitleDetail { get; set; }

        //Identify the Message Field
        [FindsBy(How = How.XPath, Using = "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[3]")]
        private IWebElement MessageDetail { get; set; }

        //Identify the Recipient Field
        [FindsBy(How = How.XPath, Using = "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[4]/a")]
        private IWebElement RecipientDetail { get; set; }

        //Identify the Status Field
        [FindsBy(How = How.XPath, Using = "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[5]")]
        private IWebElement Status { get; set; }


        //Navigate to Sent Request
        public void CheckSentRequests(string[] sentRqstDetails)
        {
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[1]");

            Assert.Multiple(() =>
            {
                Assert.That(sentRqstDetails[0], Is.EqualTo(CategoryDetail.Text));
                Assert.That(sentRqstDetails[1], Is.EqualTo(TitleDetail.Text));
                Assert.That(sentRqstDetails[2], Is.EqualTo(MessageDetail.Text));
                Assert.That(sentRqstDetails[3], Is.EqualTo(RecipientDetail.Text));
                Assert.That("Pending", Is.EqualTo(Status.Text));
            });

        }
    }
}
