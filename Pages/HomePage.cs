using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SkillSwap.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SkillSwap.Pages
{
    class HomePage
    {
        //Declare the driver
        IWebDriver driver;

        //Constructor to initialise the driver and webelements
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            

        }

        //Identify ShareSkill button on the home page
        
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[2]/a")]      
        private IWebElement ShareSkill { get; set; }

        //Identify ManageListings button on the home page
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/a[3]")]
        private IWebElement ManageListings { get; set; }

        //Identify ManageListings button on the home page
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[1]/input")]
        private IWebElement SearchSkills { get; set; }

        //Identify unread notifications count on the home page
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/div/div[1]")]
        private IWebElement UnreadNotificationsCount { get; set; }

        
        //Identify notifications tab on the home page
        [FindsBy(How = How.XPath, Using = "//div[@class='ui top left pointing dropdown item']")]
        private IWebElement NotificationsTab { get; set; }

        //Identify "See All..." in the notifications dropdown on the home page        
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'See All...')]")]        
        private IWebElement SeeAll { get; set; }

        //Identify dropdown      
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")]
        private IWebElement UiDropdown { get; set; }

        //Identify dropdown      
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[2]")]
        private IWebElement ChangePasswordOption { get; set; }

        //Identify CurrentPassword field      
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Current Password']")]
        private IWebElement CurrentPasswrd { get; set; }

        //Identify New Passowrd field      
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='New Password']")]
        private IWebElement NewPasswrd { get; set; }

        //Identify Confirm Password field      
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Confirm Password']")]
        private IWebElement CnfirmPasswrd { get; set; }

        //Identify Save button in the Change Password Window      
        [FindsBy(How = How.XPath, Using = "//button[@role='button']")]
        private IWebElement Save { get; set; }

        //Identify Pop up message box      
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement PasswordChangeStatusMsg { get; set; }

        //Identify SignOut button      
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[2]/button")]
        private IWebElement SignOut { get; set; }

        //Identify the availability section and click on edit icon to add details
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i")]
        private IWebElement addAvailability { get; set; }

        //Identify the availability dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select")]
        private IWebElement availabilityDrpdwn { get; set; }

        //Identify the add hours section
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i")]
        private IWebElement addHours { get; set; }

        //Identify the availability hours dropdown
        [FindsBy(How = How.Name, Using = "availabiltyHour")]
        private IWebElement availabilityHourDrpdwn { get; set; }

        //Identify the earn target section
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i")]
        private IWebElement addEarnTarget { get; set; }

        //Identify the earn target dropdown
        [FindsBy(How = How.Name, Using = "availabiltyTarget")]
        private IWebElement availabiltyTargetDrpdwn { get; set; }

        //Identify the Go to Profile option
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[1]")]
        private IWebElement GotoProfile { get; set; }

        //Identify the language tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")]
        private IWebElement languageTab { get; set; }

        //Identify the add new button for language
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement addNewLanguageButton { get; set; }

        //Identify the add Language text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")]
        private IWebElement addLanguage { get; set; }

        //Identify the dropdown for language level
        [FindsBy(How = How.Name, Using = "level")]
        private IWebElement languageLevelDrpdwn { get; set; }

        //Identify the add button for language
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")]
        private IWebElement languageDetailsAddButton { get; set; }

        //Identify the Skills tab and click 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")]
        private IWebElement skillsTab { get; set; }

        //Identify the add new button for adding a new entry for Skills
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement addNewSkillButton { get; set; }

        //Identify the add skill text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input")]
        private IWebElement addSkill { get; set; }

        //Identify the dropdown for skill level
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select")]
        private IWebElement skillLevelDrpdwn { get; set; }

        //Identify the add button for all the skill details
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")]
        private IWebElement skillDetailsAddButton { get; set; }

        //Identify the add new button for adding a new entry for education details
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")]
        private IWebElement addNewEducationButton { get; set; }

        //Identify the College/University text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input")]
        private IWebElement addCollege { get; set; }

        //Identify the country dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select")]
        private IWebElement countryDrpdwn { get; set; }

        //Identify the dropdown for title
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select")]
        private IWebElement titleDrpdwn { get; set; }

        //Identify the degree text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input")]
        private IWebElement addDegree { get; set; }

        //Identify the year text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select")]
        private IWebElement graduateYearDrpdwn { get; set; }

        //Identify the add button for adding the details of education
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]")]
        private IWebElement educationDetailsAddButton { get; set; }

        //Identify the details for education in the profile
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]")]
        private IWebElement country { get; set; }

        //Identify the details for education in the profile
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]")]
        private IWebElement university { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[3]")]
        private IWebElement Title { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]")]
        private IWebElement Degree { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[5]")]
        private IWebElement graduationYear { get; set; }

        //Identify the add new button to add the certification details
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")]
        private IWebElement addNewCertificationButton { get; set; }

        //Identify the certificate text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input")]
        private IWebElement addCertificate { get; set; }

        //Identify the certificate From text box
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input")]
        private IWebElement certifiedFrom { get; set; }

        //Identify the year drop down for certification
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select")]
        private IWebElement yearDrpdwn { get; set; }

        //Identify the add button for adding all the certification details
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]")]
        private IWebElement certificationDetailsAddButton { get; set; }

        //Identify the element to edit and add description
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span")]
        private IWebElement description { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea")]
        private IWebElement addDescription { get; set; }

        //Identify the save button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button")]
        private IWebElement save { get; set; }

        //Identify the notificationsDropdown 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/div")]
        private IWebElement notificationsDropdown { get; set; }

        //Identify the MarkAllAsRead 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/div/div[2]/span/div/div[1]/div[1]/center/a")]
        private IWebElement MarkAllAsRead { get; set; }

        //Identify the NotificationsNumber 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/div/div[1]")]
        private IWebElement NotificationsNumber { get; set; }

        //Identify the Chat 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[1]")]
        private IWebElement Chat { get; set; }

        //Identify the Name Dropdown icon 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]/i")]
        private IWebElement NameDropDwn { get; set; }

        //Identify the Seller name
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]")]
        private IWebElement Sellername { get; set; }


        



        //Get the Seller Name
        public string GetSellerName()
        {
            //Wait until the Sellername is visible
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]");

            Thread.Sleep(1000);

            string Fullname = Sellername.Text;
            int positionOfWhiteSpace = 1;
            positionOfWhiteSpace = Fullname.IndexOf(" ");            

            string firstname = "";
            firstname = Fullname.Substring(0, positionOfWhiteSpace);

            return firstname;
        }


        //Get the pop up text and display
        public void getPopText()
        {
            //Wait until the pop up appears
            Wait.ElementIsVisible(driver, "XPath", "//div[@class='ns-box-inner']");
            Thread.Sleep(250);
            //Get the text from the pop up
            string msg = driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
            TestContext.WriteLine(msg);
            Thread.Sleep(250);
            //Close the pop up before adding next entry
            driver.FindElement(By.XPath("//a[@class='ns-close']")).Click();
            Thread.Sleep(250);
        }


        //Navigate to Share Skill page
        public void navigateToShareSkill()
        {
            //Click on the Share Skill button in the home page
            ShareSkill.Click();

        }


        //Navigate to Chat
        public void navigateToChat()
        {

            //Click on the Chat button in the home page
            Chat.Click();

        }

        //Navigate to Profile
        public void navigateToProfile()
        {
            //Create an object of the class Actions
            Actions hover = new Actions(driver);

            //Hover the mouser over dropdown element
            hover.MoveToElement(UiDropdown).Perform();

            Wait.ElementIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[1]");

            //Click on the Change Password option
            GotoProfile.Click();

        }

        public void goToLanguageTab()
        {
            //Wait until the Language tab is visible
            Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]");

            //Click on language tab
            languageTab.Click();
        }

        public void goToSkillsTab()
        {

            //Wait until the Skills tab is visible
            Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]");

            //Click on skills tab
            skillsTab.Click();
        }

        //Navigate to Manage Listings page
        public void navigateToManageListings()
        {
            //Click on the Manage Listings in the home page
            ManageListings.Click();
        }

        //Search skills by giving appropriate skills in Search box
        public void SearchSkillFromHomePage(string SkillName)
        {
            //Enter the SkillName in the search box
            SearchSkills.SendKeys(SkillName);

            //Press Enter button
            SearchSkills.SendKeys(Keys.Enter);
            
        }

        //Navigate to search skill box
        public void NavigateToSearchSkill()
        {
            //Enter the SkillName in the search box
            SearchSkills.Click();

            //Press Enter button
            SearchSkills.SendKeys(Keys.Enter);

        }

        

        public void MarkNotificationAsRead()
        {

            string S = NotificationsNumber.Text;
            int Count = Int32.Parse(S);
            string[] newNotificationsArr = new string[Count];
            string[] NotificationsArrMarkedAsRead = new string[Count];
            string normalFontWeight = "400";
            string boldFontWeight = "700";

            notificationsDropdown.Click();

            Thread.Sleep(500);

            ////Create an object of the class Actions
            //Actions hover = new Actions(driver);

            ////Hover the mouser over dropdown element
            //hover.MoveToElement(notificationsDropdown).Perform();

            Wait.ElementIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/div/div[2]/span/div/div[1]/div[1]/center/a");

            for (int i = 2; i <= (Count + 1); i++)
            {

                IWebElement requests = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/div/div[2]/span/div/div[1]/div[" + i + "]/div/a/div[1]"));
                newNotificationsArr[i - 2] = requests.GetCssValue("font-weight");
                Assert.That(newNotificationsArr[i - 2], Is.EqualTo(boldFontWeight));
            }

            //Click on MarkAllAsRead
            MarkAllAsRead.Click();

            Thread.Sleep(500);

            ////Hover the mouser over dropdown element
            //hover.MoveToElement(notificationsDropdown).Perform();

            notificationsDropdown.Click();

            Thread.Sleep(500);

            for (int i = 2; i <= (Count + 1); i++)
            {
                IWebElement requests = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/div/div/span/div/div[1]/div[" + i + "]/div/a/div[1]"));
                NotificationsArrMarkedAsRead[i - 2] = requests.GetCssValue("font-weight");
                Assert.That(NotificationsArrMarkedAsRead[i - 2], Is.EqualTo(normalFontWeight));

            }
        }

        //Function to view all notification on a separate page
        public void SeeAllNotifications()
        {
            //Create an object of the class Actions
            Actions hover = new Actions(driver);

            //Hover the mouser over dropdown element
            hover.MoveToElement(notificationsDropdown).Perform();
                                   
            //Click on See All Notifications
            SeeAll.Click();
            
        }


        public void goToEducationTab()
        {

            //Wait until the Education tab is visible
            Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]");

            //Identify the Education tab and click 
            IWebElement EducationTab = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
            EducationTab.Click();
        }


        //Navigate to the certification tab
        public void goToCertificationTab()
        {
            //Wait until the Certification tab is visible
            Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]");

            //Identify the Certification tab and click 
            IWebElement certificationTab = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
            certificationTab.Click();
        }

        //Function to navigate to Change Password Window
        public void GoToChangePassword(int rownum)
        {
            //Create an object of the class Actions
            Actions hover = new Actions(driver);

            //Hover the mouser over dropdown element
            hover.MoveToElement(UiDropdown).Perform();

            Wait.ElementIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[2]");                    

            //Click on the Change Password option
            ChangePasswordOption.Click();

            //Wait until the element Current Password in the new window is visible
            Wait.ElementIsVisible(driver, "XPath", "//input[@placeholder='Current Password']");

            //Enter the current Password
            CurrentPasswrd.SendKeys(ServiceData.ReadCurrentPassword(rownum));

            //Enter the New Password
            NewPasswrd.SendKeys(ServiceData.ReadNewPassword(rownum));

            //Enter the Confirm Passowrd
            CnfirmPasswrd.SendKeys(ServiceData.ReadConfirmPassword(rownum));

            //Click on Save Button
            Save.Click();

            Wait.ElementPresent(driver, "XPath", "//div[@class='ns-box-inner']");
            string ExpectedMsg = "Password Changed Successfully";
            string ActualMsg = PasswordChangeStatusMsg.Text;

            TestContext.WriteLine(ActualMsg);
            Assert.That(ExpectedMsg, Is.EqualTo(ActualMsg));

            Thread.Sleep(250);
            SignOut.Click();
        }


        public void addDetails()
        {
            //Click on Add Availability      
            addAvailability.Click();
            Thread.Sleep(500);

            SelectElement availabilitySelect = new SelectElement(availabilityDrpdwn);

            //Read the data for the Earn Target from the excel
            var availabilityData = ServiceData.Availability();

            //Select the required availability option from the dropdown
            availabilitySelect.SelectByText(availabilityData);

            getPopText();

            //Click on add hours
            addHours.Click();

            Thread.Sleep(500);

            SelectElement availabilityHourSelect = new SelectElement(availabilityHourDrpdwn);

            //Read the data for the Earn Target from the excel
            var availabilityHourData = ServiceData.Hours();

            //Select the required availability hour value from the dropdown
            availabilityHourSelect.SelectByText(availabilityHourData);

            getPopText();

            //Click to add Earn Target details
            addEarnTarget.Click();

            Thread.Sleep(500);

            SelectElement availabiltyTargetSelect = new SelectElement(availabiltyTargetDrpdwn);

            //Read the data for the Earn Target from the excel
            var earnTargetData = ServiceData.EarnTarget();

            //Select the required target value from the dropdown
            availabiltyTargetSelect.SelectByText(earnTargetData);

            getPopText();

            //Validate if the details are added correctly
            string availability = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span")).Text;
            string hours = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span")).Text;
            string earnTarget = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span")).Text;

            if ((availability == availabilityData) && (hours == availabilityHourData) && (earnTarget == earnTargetData))
                Assert.Pass("Test Passed!! Availability, Hours and Earn Target details has been added to the profile successfully");
            else
                Assert.Fail("Test Failed, Availability, Hours and Earn Target details has not been added to the profile successfully");
        }


        public void addLanguages()
        {
           
            var languageData = new string[4];
            var levelData = new string[4];
            bool firstColumnCheck = false;
            bool secondColumnCheck = false;
            bool[] rowCheck = new bool[4];
            int entries = 4;
            for (int entryCount = 0; entryCount < entries; entryCount++)
            {

                //Wait until 'add language' text box is present
                Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div");

                //Click on add new button
                addNewLanguageButton.Click();

                //Wait until 'add language' text box is present
                Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input");

                //Read language data from the excel
                languageData[entryCount] = ServiceData.languageData(entryCount + 2);

                //add the language 
                addLanguage.SendKeys(languageData[entryCount]);

                SelectElement levelSelect = new SelectElement(languageLevelDrpdwn);

                //Read the language level data from the excel
                levelData[entryCount] = ServiceData.languageLevel(entryCount + 2);

                //Select the required value from the dropdown
                levelSelect.SelectByText(levelData[entryCount]);

                //Click on the add button to add all the language details
                languageDetailsAddButton.Click();

                //Get the message displayed in the pop after the language details are updated
                getPopText();

            }

            //Wait for the language details to be updated
            Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]");

            IWebElement table = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));

            //Get the list of rows in the table for the last Page
            IList<IWebElement> languageRows = table.FindElements(By.TagName("tr"));
            IList<IWebElement> columnsFirstRow = languageRows[1].FindElements(By.TagName("td"));
            IWebElement Column;

            //Validate if all the entries for the language is added successfully and correctly by checking the table values
            for (int entry = 1; entry < languageRows.Count; entry++)
            {
                for (int col = 1; col < columnsFirstRow.Count; col++)
                {
                    Column = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + (entry) + "]/tr/td[" + col + "]"));

                    if (col == 1)
                    {
                        if (Column.Text == languageData[entry - 1])
                            firstColumnCheck = true;
                    }
                    else if (col == 2)
                    {
                        if (Column.Text == levelData[entry - 1])
                            secondColumnCheck = true;
                    }
                }
                //Validate each entry for Language updated in the page by checking the column values
                rowCheck[entry - 1] = firstColumnCheck && secondColumnCheck;

                //Check if both Language and Language Level values updated in the page matches with the data in excel
                if (rowCheck[entry - 1])
                    TestContext.WriteLine($" Entry {entry} for the Language is added correctly");
                else
                    TestContext.WriteLine($" Entry {entry} for the Language is not added correctly");

                //Set the check values to false before next iteration
                firstColumnCheck = false;
                secondColumnCheck = false;
            }

            //Validate if all the added entries in the table match with the value provided
            if (rowCheck[0] && rowCheck[1] && rowCheck[2] && rowCheck[3])
                Assert.Pass("Test Passed, Language details has been added correctly");
            else
                Assert.Fail("Test Failed, Language details has not been added correctly");

        }

        public void addSkills()
        {
            var skillData = new string[4];
            var skillLevelData = new string[4];
            bool firstColumnCheck = false;
            bool secondColumnCheck = false;
            bool[] rowCheck = new bool[4];
            int entries = 4;

            
            for (int entryCount = 0; entryCount < entries; entryCount++)
            {
                //Wait until add new button is present
                Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div");

                //Click on add new button for Skills
                addNewSkillButton.Click();

                //Read the skill from the excel
                skillData[entryCount] = ServiceData.skillData(entryCount + 2);

                //Wait until add skill text box is visible
                Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input");

                //add the required skill 
                addSkill.SendKeys(skillData[entryCount]);

                SelectElement levelSelect = new SelectElement(skillLevelDrpdwn);
                
                //Read the skill Level from the excel
                skillLevelData[entryCount] = ServiceData.skillLevelData(entryCount + 2);

                //Select the required level from the dropdown
                levelSelect.SelectByText(skillLevelData[entryCount]);

                //Click on the add button to add all the skill details
                skillDetailsAddButton.Click();

                //Get the message displayed in the pop after each skill details are updated
                getPopText();
            }

            //Wait until the skill details are added and are visible
            Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]");

            //Idenitfy the table that stores the data for the Skill
            IWebElement table = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));

            //Get the list of rows in the table for the last Page
            IList<IWebElement> skillRows = table.FindElements(By.TagName("tr"));
            //Get the list of columns
            IList<IWebElement> columnsFirstRow = skillRows[1].FindElements(By.TagName("td"));
            IWebElement Column;

            //Validate if all the entries for the language is added successfully and correctly by checking the table values
            for (int entry = 1; entry < skillRows.Count; entry++)
            {
                for (int col = 1; col < columnsFirstRow.Count; col++)
                {
                    //Access each column value in the table
                    Column = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + (entry) + "]/tr/td[" + col + "]"));

                    if (col == 1)
                    {
                        if (Column.Text == skillData[entry - 1])
                            firstColumnCheck = true;
                    }
                    else if (col == 2)
                    {
                        if (Column.Text == skillLevelData[entry - 1])
                            secondColumnCheck = true;
                    }
                }
                //Validate each entry for Language updated in the page by checking the column values
                rowCheck[entry - 1] = firstColumnCheck && secondColumnCheck;

                //Check if both Skills and Level values updated in the page matches with the data in excel
                if (rowCheck[entry - 1])
                    TestContext.WriteLine($" Entry {entry} for the skill is added correctly");
                else
                    TestContext.WriteLine($" Entry {entry} for the skill is not added correctly");
                //Set the check values to false before next iteration
                firstColumnCheck = false;
                secondColumnCheck = false;
            }

            //Validate if all the added entries in the table match with the value provided
            if (rowCheck[0] && rowCheck[1] && rowCheck[2] && rowCheck[3])
                Assert.Pass("Test Passed, Skill details has been added correctly");
            else
                Assert.Fail("Test Failed, Skill details has not been added correctly");

        }


        public void addEducation()
        {
            //Wait until the edit button for adding aducation details is visible
            Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div");

            //Click on the add new button for adding a new entry for the education details
            addNewEducationButton.Click();

            //Wait until the he College/University text box is present
            Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input");

            //Read the College name from the excel
            var collegeData = ServiceData.collegeNameData();

            //add the required college
            addCollege.SendKeys(collegeData);

            SelectElement countrySelect = new SelectElement(countryDrpdwn);

            //Read the country name from the excel
            var countryData = ServiceData.CountryOfCollege();

            //Select the required country from the dropdown
            countrySelect.SelectByText(countryData);

            SelectElement titleSelect = new SelectElement(titleDrpdwn);

            //Read the title name from the excel
            var titleData = ServiceData.EducationTitle();

            //Select the required title from the dropdown
            titleSelect.SelectByText(titleData);

            //Read the degree data from the excel
            var degreeData = ServiceData.Degree();

            //Enter the required degree to the education 
            addDegree.SendKeys(degreeData);

            SelectElement year = new SelectElement(graduateYearDrpdwn);

            //Read the degree data from the excel
            var yearData = ServiceData.GraduationYear();

            //Select the required title from the dropdown
            year.SelectByText(yearData);

            //Click on the add button to add all the education details
            educationDetailsAddButton.Click();

            //Get the message displayed on the pop up after education details are added
            getPopText();

            //wait until the details appear
            Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]");

            //Validate the details added in the Education tab
            if ((country.Text == countryData) && (university.Text == collegeData) && (Title.Text == titleData) && (Degree.Text == degreeData) && (graduationYear.Text == yearData))
                Assert.Pass("Test Passed, Education details has been added succesfully");
            else
                Assert.Fail("Test Failed, Education details has not been added succesfully");

        }


        public void addCertifications()
        {
            
            var certificateData = new string[4];
            var certifiedFromData = new string[4];
            var certificationYearData = new string[4];
            bool firstColumnCheck = false;
            bool secondColumnCheck = false;
            bool thirdColumnCheck = false;
            bool[] rowCheck = new bool[4];
            int entries = 4;

            //Add all the certification details in the profile
            for (int entryCount = 0; entryCount < entries; entryCount++)
            {
                //Wait until add new button is present
                Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div");

                //Click on the add new button to add the details
                addNewCertificationButton.Click();

                //Wait until the certificate text box is available
                Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input");

                //Read the  name from the excel
                certificateData[entryCount] = ServiceData.CertificateName(entryCount + 2);

                //Add the required certificate details
                addCertificate.SendKeys(certificateData[entryCount]);

                //Read the Certified From Data from the excel
                certifiedFromData[entryCount] = ServiceData.certifiedFrom(entryCount + 2);

                //Add the data for the 'Çertified From' field
                certifiedFrom.SendKeys(certifiedFromData[entryCount]);

                SelectElement yearSelect = new SelectElement(yearDrpdwn);

                //Read the Certified From Data from the excel
                certificationYearData[entryCount] = ServiceData.CertificationYear(entryCount + 2);

                //Select the required year from the dropdown
                yearSelect.SelectByText(certificationYearData[entryCount]);

                //Click on the add button to add the details
                certificationDetailsAddButton.Click();

                //Get the message displayed on the pop up after certification details are added
                getPopText();
            }

            //Wait until the certificate for text box is visible
            Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]");

            //Idenitfy the table that stores the data for the Certification
            IWebElement table = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table"));

            //Get the list of rows in the table
            IList<IWebElement> certRows = table.FindElements(By.TagName("tr"));
            //Get the list of columns
            IList<IWebElement> columnsFirstRow = certRows[1].FindElements(By.TagName("td"));
            IWebElement Column;

            //Validate if all the entries for the language is added successfully and correctly by checking the table values
            for (int entry = 1; entry < certRows.Count; entry++)
            {
                for (int col = 1; col < columnsFirstRow.Count; col++)
                {
                    //Access each column value in the table
                    Column = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + (entry) + "]/tr/td[" + col + "]"));

                    if (col == 1)
                    {
                        if (Column.Text == certificateData[entry - 1])
                            firstColumnCheck = true;
                    }
                    else if (col == 2)
                    {
                        if (Column.Text == certifiedFromData[entry - 1])
                            secondColumnCheck = true;
                    }
                    else if (col == 3)
                    {
                        if (Column.Text == certificationYearData[entry - 1])
                            thirdColumnCheck = true;
                    }
                }
                //Validate each entry for certificate updated in the page by checking the column values
                rowCheck[entry - 1] = firstColumnCheck && secondColumnCheck && thirdColumnCheck;

                //Check if certificate, From and Year values updated in the page match with the data in excel
                if (rowCheck[entry - 1])
                    TestContext.WriteLine($" Entry {entry} data for the certification is added correctly");
                else
                    TestContext.WriteLine($" Entry {entry} data for the certification is not added correctly");

                //Set the check values to false before next iteration
                firstColumnCheck = false;
                secondColumnCheck = false;
                thirdColumnCheck = false;
            }

            //Validate if all the added entries in the table match with the value provided
            if (rowCheck[0] && rowCheck[1] && rowCheck[2] && rowCheck[3])
                Assert.Pass("Test Passed, Certifications details has been added correctly");
            else
                Assert.Fail("Test Failed, Certifications details has not been added correctly");

        }

        public void AddDescription()
        {

            //Wait for the edit icon for the description to be available
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span");

            //Click on the description
            description.Click();

            //Wait for the description box to be available so as to add description
            Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea");

            //Pass the filename and sheetname of the excel sheet
            ExcelLibHelpers.PopulateInCollection(@"D:\Internship\Onboarding_task\SkillExchange\SkillExchange\TestData\TestData.xls", "HomePage");

            //Read description data from the excel
            var descriptionStatement = ExcelLibHelpers.ReadData(2, "Description");

            addDescription.Clear();

            Thread.Sleep(100);

            //Add description
            addDescription.SendKeys(descriptionStatement);

            //Click on save button
            save.Click();

            //Wait until the description appears on the profile
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span");

            //Get the description value
            string descrptnBox = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span")).Text;

            getPopText();

            //Validate if the description has been added correctly
            if (descrptnBox == descriptionStatement)
                Assert.Pass("Test Passed, description has been added successfully");
            else
                Assert.Fail("Test Failed, description has not been added successfully");

        }


        public void checkDuplicateEntries()
        {            
            var certificateData = new string[2];
            var certifiedFromData = new string[2];
            var certificationYearData = new string[2];
            int entries = 2;

            //Add all the certification details in the profile
            for (int entryCount = 0; entryCount < entries; entryCount++)
            {
                //Wait until add new button is present
                Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div");

                //Click on the add new button to add the details
                addNewCertificationButton.Click();

                //Wait until the certificate text box is available
                Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input");

                //Read the data from the excel
                certificateData[entryCount] = ServiceData.CertificateName(entryCount + 6);

                //Add the required certificate details
                addCertificate.SendKeys(certificateData[entryCount]);

                //Read the Certified From Data from the excel
                certifiedFromData[entryCount] = ServiceData.certifiedFrom(entryCount + 6);

                //Add the data for the 'Çertified From' field
                certifiedFrom.SendKeys(certifiedFromData[entryCount]);

                SelectElement yearSelect = new SelectElement(yearDrpdwn);

                //Read the Certified From Data from the excel
                certificationYearData[entryCount] = ServiceData.CertificationYear(entryCount + 6);

                //Select the required year from the dropdown
                yearSelect.SelectByText(certificationYearData[entryCount]);

                //Click on the add button to add the details
                certificationDetailsAddButton.Click();

                //Wait until the pop up appears
                Wait.ElementIsVisible(driver, "XPath", "//div[@class='ns-box-inner']");
                Thread.Sleep(1000);
                if (entryCount == 0)
                {
                    //Get the text from the pop up
                    string msg = driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                    TestContext.WriteLine(msg);
                    Thread.Sleep(1000);
                    //Close the pop up before adding next entry
                    driver.FindElement(By.XPath("//a[@class='ns-close']")).Click();
                    Thread.Sleep(1000);
                }
                else
                {
                    string validateMsg = driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
                    if (validateMsg == "This information is already exist.")
                        Assert.Pass("Test Passed, Duplicate entry is not allowed and pop up message is displayed");
                    else
                        Assert.Fail("Test Failed!!!");
                }

            }
        }

        public void editLanguages()

        {
            
            //Read the degree data from the excel
            var UpdateLang = ServiceData.languageData(6);
            var UpdateLangLevel = ServiceData.languageLevel(6);

            //Identify the language table
            IWebElement table = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));

            //Get the list of rows in the table
            IList<IWebElement> languageRows = table.FindElements(By.TagName("tr"));

            //If the is atleast 1 entry for language
            if (languageRows.Count > 1)
            {
                //Wait until edit button is present
                Wait.ElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]");

                //Identify the Edit button of the last entry in the table
                driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]")).Click();

                //Wait for the edit mode to be visible
                Thread.Sleep(100);

                //Identify the add language box to be updated
                IWebElement editLanguage = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));

                //Clear the data
                editLanguage.Clear();

                //Enter the updated data
                editLanguage.SendKeys(UpdateLang);

                //Identify the level dropdown box to update
                IWebElement editLanguageLevel = driver.FindElement(By.XPath("//select[@name='level']"));
                SelectElement Editlevel = new SelectElement(editLanguageLevel);
                Editlevel.SelectByText(UpdateLangLevel);

                Thread.Sleep(100);
                //Idenitfy the Update button
                driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]")).Click();

                //Get the message displayed in the pop up
                getPopText();

                //Get the First Column value from last entry in the table
                string updatedLang = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;

                //Get the Second Column value from last entry in the table
                string updatedLangLevel = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]")).Text;

                //Validate the updated language entry
                if ((updatedLang == UpdateLang) && (updatedLangLevel == UpdateLangLevel))
                    Assert.Pass("Test Passed, Language details are updated correctly");
                else
                    Assert.Fail("Test Failed, Language details are not updated correctly");

            }
            //Display error message and fail the test if there are no entries to be edited
            else
            {
                Assert.Fail("Edit cannot be performed, there are no language records to be edited");
            }

        }


        public void DeleteLanguages()

        {
            //Identify the language table
            IWebElement table = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));

            //Get the list of rows in the table
            IList<IWebElement> languageRows = table.FindElements(By.TagName("tr"));

            //Check if there are any entries for the language in the table
            if (languageRows.Count > 1)
            {
                string Lang = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;
                //Delete the last element in the table
                driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i")).Click();
                Thread.Sleep(100);
                //Get the string from the pop up
                string validateDelMsg = driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;

                //Validate the message displayed in the pop up
                if (validateDelMsg == $"{Lang} has been deleted from your languages")
                    Assert.Pass("Test Passed, Language has been deleted");
                else
                    Assert.Fail("Test Failed, Language has not been deleted");

            }
            //Display error message and fail the test if there are no entries to be deleted
            else
            {
                Assert.Fail("Delete cannot be performed, there are no language records to be deleted");
            }
        }
    }
}
