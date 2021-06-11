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
    class Dashboard
    {

        IWebDriver driver;

        public Dashboard(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Identify Delete 
        IWebElement Delete => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[3]"));


        //Identify Pop up Message  
        IWebElement PopUpMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        
        //Identify First Service Request
        IWebElement ServiceRequestMsgOne  => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[2]/div[1]/a/div[1]"));

        //Identify Second Service Request
        IWebElement ServiceRequestMsgTwo => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[2]/div/div/div[2]/div[1]/a/div[1]"));

        //Identify Second Service Request
        IWebElement MarkSelectionAsRead => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[4]"));
                       
        //Identify Pop up Message  
        IWebElement GotoMsg => driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[3]/div/div/div[2]/div[2]/a"));
        

        public void SelectNotifications(int SelectCount)
        {
            
            for (int count = 1; count <= SelectCount; count++)
            {
                Wait.ElementIsVisible(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[" + count + "]/div/div/div[3]/input");
                driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[" + count + "]/div/div/div[3]/input")).Click();
            }
        }


        public void CheckSelectNotifications(int SelectCount)
        {
            IWebElement checkbox;

            for (int count = 1; count <= SelectCount; count++)
            {
                
                Wait.ElementIsVisible(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[" + count + "]/div/div/div[3]/input");
                checkbox = driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[" + count + "]/div/div/div[3]/input"));
                TestContext.WriteLine(checkbox.Selected);
                Assert.That(checkbox.Selected);               
            }
        }


        public void UncheckSelectNotifications(int SelectCount)
        {
            IWebElement checkbox;

            for (int count = 1; count <= SelectCount; count++)
            {

                Wait.ElementIsVisible(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[" + count + "]/div/div/div[3]/input");
                checkbox = driver.FindElement(By.XPath("//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[" + count + "]/div/div/div[3]/input"));
                TestContext.WriteLine("Inside the UncheckSelectNotifications");
                TestContext.WriteLine(checkbox.Selected);
                if (checkbox.Selected)
                {
                    checkbox.Click();
                    Thread.Sleep(50);
                    TestContext.WriteLine("After Uncheck");
                    TestContext.WriteLine(checkbox.Selected);
                    Assert.That(!checkbox.Selected);
                }
                else
                {
                   TestContext.WriteLine("The checkbox is unselected already");
                }
            }
        }

        public void DeleteSelectedNotifications()
        {
            Delete.Click();
            Thread.Sleep(500);
            Assert.That(PopUpMsg.Text, Is.EqualTo("Notification updated"));
        }

        public void CheckIfNotificationIsUnread(int NewNotificationsCount)
        {

            Wait.ElementIsVisible(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[2]/div[1]/a/div[1]");

            var FontWeightNormal = "400";
            var FontWeightBold = "700";

            var FontweightUnreadMsgOne = ServiceRequestMsgOne.GetCssValue("font-weight");
            var FontweightUnreadMsgTwo = ServiceRequestMsgTwo.GetCssValue("font-weight");

            //Wait until the check box is visble for first service request
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input");
            
            //Invoke the function to select the notifications
            SelectNotifications(NewNotificationsCount);

            //Click on the Mark Selection As Read
            MarkSelectionAsRead.Click();

            Thread.Sleep(500);

            String NotificationMsg = PopUpMsg.Text;

            Wait.ElementIsVisible(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[2]/div[1]/a/div[1]");

            var FontweightReadMsgOne = ServiceRequestMsgOne.GetCssValue("font-weight");
            var FontweightReadMsgTwo = ServiceRequestMsgTwo.GetCssValue("font-weight");

            //Check the font weights
            Assert.Multiple(() =>
            {
                Assert.That(NotificationMsg, Is.EqualTo("Notification updated"));
                Assert.That(FontweightUnreadMsgOne, Is.EqualTo(FontWeightBold));
                Assert.That(FontweightUnreadMsgTwo, Is.EqualTo(FontWeightBold));
                Assert.That(FontweightReadMsgOne, Is.EqualTo(FontWeightNormal));
                Assert.That(FontweightReadMsgTwo, Is.EqualTo(FontWeightNormal));

            });
        }
    }
}
