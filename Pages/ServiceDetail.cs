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
    class ServiceDetail
    {
        IWebDriver driver;
        int RowNum;
        public ServiceDetail(IWebDriver driver, int RowNum)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.RowNum = RowNum;
        }

        public ServiceDetail(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);            
        }

        //Identify the 'Title'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span")]
        private IWebElement titleServiceDetail { get; set; }

        //Identify the 'Description'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[2]")]
        private IWebElement DescServiceDetail { get; set; }

        //Identify the 'Category'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]")]
        private IWebElement CategoryServiceDetail { get; set; }
        
        //Identify the 'Start Date'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[1]/div/div[2]")]
        private IWebElement StartDateServiceDetail { get; set; }

        //Identify the 'Subcategory'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]")]
        private IWebElement SubCategoryServiceDetail { get; set; }

        //Identify the 'End Date'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[2]/div/div[2]")]
        private IWebElement EndDateServiceDetail { get; set; }

        //Identify the 'Service Type'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[3]/div/div[2]")]
        private IWebElement ServTypeServiceDetail { get; set; }

        //Identify the 'Location Type'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]")]
        private IWebElement LocationTypeServiceDetail { get; set; }

        //Identify the 'Search box'
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[1]/div[1]/input")]
        private IWebElement SearchBox { get; set; }

        //Identify the Charge displayed
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[2]/label/em")]
        private IWebElement Charge { get; set; }

        //Identify the SkillsTrade displayed
        [FindsBy(How = How.XPath, Using = "//*[@id='no-skills-specified']")]
        private IWebElement SkillsTradeDisplay { get; set; }

        //Identify the ManageListings from service detail page
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/section[1]/div/a[3]")]
        private IWebElement ManageLstings { get; set; }

        //Identify the ManageListings from search page
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/section[1]/div/a[3]")]
        private IWebElement MngLstngs { get; set; }

        //Identify the Category of the service searched
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]")]
        private IWebElement Category { get; set; }

        //Identify the Title of the service searched
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span")]
        private IWebElement titleService { get; set; }

        //Identify the Message box to seller
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/textarea")]
        private IWebElement MessageBoxToSeller { get; set; }

        //Identify the Request Button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[3]")]
        private IWebElement RequestButton { get; set; }

        //Identify the Request Button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[1]/div/div[1]/a/h3")]
        private IWebElement SellerName { get; set; }

        //Identify the Manage Request tab
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/section[1]/div/div[1]")]
        private IWebElement ManageRqst { get; set; }

        //Identify the Sent Request option from the Manage Request dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/section[1]/div/div[1]/div/a[2]")]
        private IWebElement SentRqst { get; set; }

        //Identify the Yes button in Confirm Trade request window
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div[3]/button[1]")]
        private IWebElement CnfrmTradeRqstButton { get; set; }

        //Identify the Chat button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[1]/div/div[1]/div/a")]
        private IWebElement ChatButton { get; set; }

        //Identify the Chat button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[5]/div/div/div/div[2]/div/div/i")]
        private IWebElement WrkSmplUpload { get; set; }
        

        public void ValidateServiceDetail()
        {
            try
            {
                bool fileUpload = false;
                //Wait until the page loads and description is visible
                Wait.ElementIsVisible(driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[1]");

                //Read the Skill exchange tag count from the excel
                var SkillExchngCount = ServiceData.TagsCntData(RowNum);

                //Convert the count of the skill exchange tags from String to integer
                int Count = Int32.Parse(SkillExchngCount);

                //Convert the Start Date and End Data format from (dd/mm/yyyy to yyyy-mm-dd)
                String StartDate = (ServiceData.StrtDateData(RowNum).Substring(4, 4)) + "-" + (ServiceData.StrtDateData(RowNum).Substring(2, 2)) + "-" + (ServiceData.StrtDateData(RowNum).Substring(0, 2));
                String EndDate = (ServiceData.EndDateData(RowNum).Substring(4, 4)) + "-" + (ServiceData.EndDateData(RowNum).Substring(2, 2)) + "-" + (ServiceData.EndDateData(RowNum).Substring(0, 2));

                fileUpload = WrkSmplUpload.Displayed;

                //Validate the expected and actual values of the different fields in the services
                Assert.Multiple(() =>
                {
                    Assert.That(titleServiceDetail.Text, Is.EqualTo(ServiceData.TitleData(RowNum)));
                    Assert.That(DescServiceDetail.Text, Is.EqualTo(ServiceData.DescriptionData(RowNum)));
                    Assert.That(CategoryServiceDetail.Text, Is.EqualTo(ServiceData.CategData(RowNum)));
                    Assert.That(SubCategoryServiceDetail.Text, Is.EqualTo(ServiceData.SubCategData(RowNum)));
                    Assert.That(ServTypeServiceDetail.Text, Is.EqualTo(ServiceData.SrvcTypeData(RowNum)));
                    Assert.That(StartDateServiceDetail.Text, Is.EqualTo(StartDate));
                    Assert.That(EndDateServiceDetail.Text, Is.EqualTo(EndDate));
                    Assert.That(LocationTypeServiceDetail.Text, Is.EqualTo(ServiceData.LocatnTypeData(RowNum)));
                    Assert.That(fileUpload, Is.EqualTo(true));
                });



                //If the skill trade is chosen as "Skill-exchange" then need to validate the Skill exchange tags
                if (ServiceData.SkillTrdeData(RowNum) == "Skill-exchange")
                {
                    String[] SkillsTradeData = new String[Count];
                    String[] SkillExchangeData = ServiceData.SkillExchangeData(RowNum);
                    for (int Counter = 0; Counter < Count; Counter++)
                    {
                        SkillsTradeData[Counter] = driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[4]/div[2]/div/div/div[2]/span[" + (Counter + 1) + "]")).Text;
                        TestContext.WriteLine(SkillsTradeData[Counter]);
                        Assert.That(SkillsTradeData[Counter], Is.EqualTo(SkillExchangeData[Counter]));
                    }

                    //Click on the Manage Listings
                    ManageLstings.Click();

                    //Wait until the Listings are available in the Manage Listing page
                    Wait.ElementIsVisible(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[4]");
                }

                //If the Skill Exchange is chosen as 'Credit' then validate the credit charge value displayed
                else if (ServiceData.SkillTrdeData(RowNum) == "Credit")
                {

                    String SkillsTrade = SkillsTradeDisplay.Text;

                    //Enter the title in the serach Box
                    SearchBox.SendKeys(ServiceData.TitleData(RowNum));

                    //Press enter key to search for the skill
                    SearchBox.SendKeys(Keys.Enter);

                    //Implicit wait for the registeration pop up to be available
                    Wait.wait(2, driver);

                    String CreditCharge;

                    if (ServiceData.SrvcTypeData(RowNum) == "One-off")
                        CreditCharge = "Charge is :$" + ServiceData.CreditValue(RowNum);
                    else
                        CreditCharge = "Charge is :$" + ServiceData.CreditValue(RowNum) + " per hour";

                    String CreditActualVal = Charge.Text;
                    Assert.Multiple(() =>
                    {
                        Assert.That(CreditActualVal, Is.EqualTo(CreditCharge));
                        Assert.That(SkillsTrade, Is.EqualTo("None Specified"));
                    });

                    //Click on the Manage Listings
                    MngLstngs.Click();

                    //Wait until the Listings are available in the Manage Listing page
                    Wait.ElementIsVisible(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[4]");
                }
            }
            catch (Exception e)
            {
                Assert.Fail("One or more webelements could not be found", e.Message);
            }
                
            }

        

        public string[] SentRequestToSeller()
        {
            string MsgToSeller = "I would like to avail your service";
            string[] requestDetails = new string[4];
            Wait.ElementPresent(driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span");
            requestDetails[0] = Category.Text;
            requestDetails[1] = titleService.Text;
            MessageBoxToSeller.Click();
            MessageBoxToSeller.SendKeys(MsgToSeller);
            RequestButton.Click();
            CnfrmTradeRqstButton.Click();
            requestDetails[2] = MsgToSeller;
            requestDetails[3] = SellerName.Text;

            ManageRqst.Click();
            Thread.Sleep(500);
            SentRqst.Click();
            return requestDetails;
        }


        public void NavigateToChat()
        {            
            //Wait until Chat button is visible
            Wait.ElementPresent(driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[1]/div/div[1]/div/a");

            //Click on the chat button
            ChatButton.Click();

        }
    }
}
