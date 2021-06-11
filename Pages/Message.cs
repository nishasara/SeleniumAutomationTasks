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
    class Message
    {
        //Declare the driver
        IWebDriver driver;

        //Constructor to initialise the driver and webelements
        public Message(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            
        }

        //Identify the Chat Text Box
        [FindsBy(How = How.XPath, Using = "//*[@id='chatTextBox']")]
        private IWebElement ChatTextBox { get; set; }

        //Identify the Send Button
        [FindsBy(How = How.XPath, Using = "//*[@id='btnSend']")]
        private IWebElement SendButton { get; set; }

        //Identify the SignOut Button
        [FindsBy(How = How.XPath, Using = "//*[@id='message-section']/div[1]/div[2]/div/a[2]/button")]
        private IWebElement SignOut { get; set; }

        //Identify the Chat Search Box
        [FindsBy(How = How.XPath, Using = "//*[@id='chatRoomContainer']/div/div[1]/div/div[1]/input")]
        private IWebElement ChatSrchBox { get; set; }

        //Identify the Search Result
        [FindsBy(How = How.XPath, Using = "//*[@id='chatList']/div/div[2]/div[1]")]
        private IWebElement ChatSrchRslt { get; set; }

        //Identify the Time Stamp
        [FindsBy(How = How.XPath, Using = "//*[@id='chatBox']/div[position()=last()]/div[1]/span[1]")]
        private IWebElement TimeStampMsgTwo { get; set; }

        //Identify the Time Stamp
        [FindsBy(How = How.XPath, Using = "//*[@id='chatBox']/div[position()=(last()-1)]/div[1]/span[1]")]
        private IWebElement TimeStampMsgOne { get; set; }

        //Identify the Messages
        [FindsBy(How = How.XPath, Using = "//*[@id='chatBox']/div[position()=last()]//div[1]//div[1]//span[1]")]
        private IWebElement MsgTwo { get; set; }

        //Identify the Messages
        [FindsBy(How = How.XPath, Using = "//*[@id='chatBox']/div[position()=(last()-1)]//div[1]//div[1]//span[1]")]
        private IWebElement MsgOne { get; set; }

        string ChatMsgOneToSeller = "Hi Nisha, How are you?";
        string ChatMsgTwoToSeller = "I would like to avail your service";

        public string[] ChatWithSeller()
        {
            
            //Wait until Chat text box is visible
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='chatTextBox']");

            ChatTextBox.Click();

            ChatTextBox.SendKeys(ChatMsgOneToSeller);

            SendButton.Click();

            ChatTextBox.SendKeys(ChatMsgTwoToSeller);

            SendButton.Click();

            Thread.Sleep(2000);

            string[] chatMsgTimeStamp = new String[4];
            
            chatMsgTimeStamp[0] = TimeStampMsgOne.Text;
            chatMsgTimeStamp[1] = MsgOne.Text;
                                    
            chatMsgTimeStamp[2] = TimeStampMsgTwo.Text;
            chatMsgTimeStamp[3] = MsgTwo.Text;

            Assert.Multiple(() =>
            {
                Assert.That(ChatMsgOneToSeller, Is.EqualTo(chatMsgTimeStamp[1]));
                Assert.That(ChatMsgTwoToSeller, Is.EqualTo(chatMsgTimeStamp[3]));
                
            });

            Thread.Sleep(300);

            SignOut.Click();

            return chatMsgTimeStamp;

        }

        public void CheckNewChatMessages(string name, string[] chatdetails)
        {
            //Wait until Chat Search Box is visible
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='chatRoomContainer']/div/div[1]/div/div[1]/input");

            ChatSrchBox.Click();
            Thread.Sleep(3000);
            ChatSrchBox.SendKeys(name);

            Thread.Sleep(1000);

            ChatSrchRslt.Click();
            Thread.Sleep(1000);

            Assert.Multiple(() =>
            {
                Assert.That(chatdetails[0], Is.EqualTo(TimeStampMsgOne.Text));
                Assert.That(chatdetails[1], Is.EqualTo(MsgOne.Text));
                Assert.That(chatdetails[2], Is.EqualTo(TimeStampMsgTwo.Text));
                Assert.That(chatdetails[3], Is.EqualTo(MsgTwo.Text));

            });

        }
    }
}

