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
    class SearchSkill
    {
        IWebDriver driver;
        int RowNum;
        public SearchSkill(IWebDriver driver, int RowNum)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.RowNum = RowNum;
        }

        public SearchSkill(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Identify the search result
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[1]")]
        private IWebElement SellerInfo { get; set; }

        //Identify the  text box
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p")]
        private IWebElement ServiceInfo { get; set; }

        //Identify the Credit charge
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[2]/label/em")]
        private IWebElement Charge { get; set; }

        //Identify the Service
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p")]
        private IWebElement Service { get; set; }

        //Identify the SearchResultDisplay
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/h3")]
        private IWebElement SrchDisplay { get; set; }

        //Identify the Filter Online button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]")]
        private IWebElement FilterOnline { get; set; }

        //Identify the Filter Onsite button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[2]")]
        private IWebElement FilterOnsite { get; set; }

        //Identify the ShowAll button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[3]")]
        private IWebElement ShowAll { get; set; }

        //List of SearchElements
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div")]
        private IWebElement SearchElements { get; set; }

        //Number of SearchElements
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[1]/span")]
        private IWebElement SearchRsltNumber { get; set; }
        
        //Identify the Location Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]")]
        private IWebElement Location { get; set; }

        //Identify the Search Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[1]/div[1]/input")]
        private IWebElement Search { get; set; }

        //Identify the SkillName Type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/h1/span")]
        private IWebElement SkillName { get; set; }

        //Identify the SearchUser search box
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input")]
        private IWebElement UserSearch { get; set; }

        //Identify the particular user dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]")]
        private IWebElement User { get; set; }

        //Identify the search result displayed
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p")]
        private IWebElement SrchRslts{ get; set; }         
                     
        

        

        //Function to retrieve the details of Seller from the search results
        public void SkillSrchResult()
        {
            if (ServiceData.ActvStatusData(RowNum) == "Active")
            {
                Thread.Sleep(500);
                if ((SellerInfo.Text == "Sara Susan") && (ServiceData.TitleData(RowNum) == ServiceInfo.Text))
                    TestContext.WriteLine("The service has been found in the search list");
                String CreditCharge = "Charge is :$" + ServiceData.CreditValue(RowNum);
                String CreditActualVal = Charge.Text;
                Assert.That(CreditActualVal, Is.EqualTo(CreditCharge));
                Service.Click();
            }
        }

        //Function to search for the skills that has already been deleted
        public void SrchResultAfterDel()
        {
            //Search for service only if the service is active
            if (ServiceData.ActvStatusData(RowNum) == "Active")
            {
                Wait.wait(1, driver);
                String displayResult = "No results found, please select a new category!";
                Assert.That(SrchDisplay.Text, Is.EqualTo(displayResult));
            }

        }


        //Function to filter out the search results (search conducted based on skills) based on filters "Online", "Onsite" and "ShowAll" 
        public void FilterSkills(string LocationType, String TitleForServc)
        {
            
            bool Online = false;
            bool Onsite = false;
            bool ShowAllSelected = false;
            
            //Based on the Location Type, click on the appropriate filters
            if (LocationType == "Online")
            {
                Online = true;
                Wait.ElementClickable(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]");
                FilterOnline.Click();
            }                
            else if (LocationType == "On-Site")
            {
                Onsite = true;
                Wait.ElementClickable(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[2]");
                FilterOnsite.Click();
            }
                
            else if (LocationType == "ShowAll")
            {
                ShowAllSelected = true;
                Wait.ElementClickable(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[3]");
                ShowAll.Click();
            }

            //Wait until the element that displays the search result element's number is present on the page
            Wait.ElementPresent(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[1]/span");
            Thread.Sleep(500);

            //Get the number of results displayed on the search results page in integer format
            int SrchResultsCnt = Int32.Parse(SearchRsltNumber.Text);
            
            TestContext.WriteLine("The Search results count is "+SrchResultsCnt);

            //Validate the search results retrieved based on the filter applied
            if (SrchResultsCnt > 1)
            {
                //Loop through all the search results and validate the details of the Location Type
                for (int i = 1; i <= SrchResultsCnt; i++)
                {
                    Thread.Sleep(250);

                    //Click on the skill details
                    driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div["+i+"]/div[1]/a[2]/p")).Click();
                    Wait.ElementPresent(driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]");

                    //Validate the location type of the skill
                    if (LocationType == "Online" || LocationType == "On-Site")
                    {
                        Assert.That(Location.Text, Is.EqualTo(LocationType));
                    }

                        TestContext.WriteLine("Inside details of "+ SkillName.Text+ " with location Type " + Location.Text);

                        //Navigate back to the search results page from the service details page
                        //Enter the SkillName in the search box
                        Search.SendKeys(TitleForServc);

                        //Press Enter button
                        Search.SendKeys(Keys.Enter);

                        //Wait for the element that displays the search result element's number
                        Wait.ElementPresent(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[1]/span");
                        Thread.Sleep(500);
                        if (Online)
                        {
                        FilterOnline.Click();
                        Thread.Sleep(500);
                        }                            
                        else if (Onsite)
                        {
                        FilterOnsite.Click();
                        Thread.Sleep(500);
                        }                            
                        else if (ShowAllSelected)
                        {
                        ShowAll.Click();
                        Thread.Sleep(500);
                        }
                        

                    //Wait for the element that displays the search result element's number
                    Wait.ElementPresent(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[1]/span");                   
                }
            }
            else if (SrchResultsCnt == 1)
            {
                driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p")).Click();
                Wait.ElementPresent(driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]");
                if (LocationType == "Online" || LocationType == "On-Site")
                {                    
                    Assert.That(Location.Text, Is.EqualTo(LocationType));
                }
                TestContext.WriteLine("Inside details of " + SkillName.Text + " with location Type " + Location.Text);
            }
        }

        //Function to filter out the search results (search conducted based on Username) based on filters "Online", "Onsite" and "ShowAll" 
        public void FilterSkillsOfParticularUser(string LocationType, String Name)
        {

            bool Online = false;
            bool Onsite = false;
            bool ShowAllSelected = false;
            

            //Wait until the "Search user" search box is available
            Wait.ElementPresent(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input");

            UserSearch.Click();
            UserSearch.SendKeys(Name);
            Thread.Sleep(1000);
            User.Click();
                     
            if (LocationType == "Online")
            {
                Online = true;
                Wait.ElementClickable(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]");
                FilterOnline.Click();

            }
            else if (LocationType == "On-Site")
            {
                Onsite = true;
                Wait.ElementClickable(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[2]");
                FilterOnsite.Click();
            }

            else if (LocationType == "ShowAll")
            {
                ShowAllSelected = true;
                Wait.ElementClickable(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[3]");
                ShowAll.Click();
            }

            //Wait for the element that displays the search result element's number
            Wait.ElementPresent(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[1]/span");
            Thread.Sleep(500);
            //Get the number of results displayed on the search results page in integer format
            int SrchResultsCnt = Int32.Parse(SearchRsltNumber.Text);

            TestContext.WriteLine("The Search results count is " + SrchResultsCnt);

           if (SrchResultsCnt > 1)
            {

                for (int i = 1; i <= SrchResultsCnt; i++)
                {
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[" + i + "]/div[1]/a[2]/p")).Click();
                    Wait.ElementPresent(driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]");
                    if (LocationType == "Online" || LocationType == "On-Site")
                    {
                        Assert.That(Location.Text, Is.EqualTo(LocationType));
                    }
                        TestContext.WriteLine("Inside details of " + SkillName.Text+ " with location type "+ Location.Text);
                                                
                        //Press Enter button
                        Search.SendKeys(Keys.Enter);

                        //Enter the UserName in the search box
                        UserSearch.Click();
                        Thread.Sleep(500);
                        UserSearch.SendKeys(Name);
                        Thread.Sleep(1000);
                        User.Click();

                        //Wait for the element that displays the search result element's number
                        Wait.ElementPresent(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[1]/span");
                        Thread.Sleep(500);
                        if (Online)
                        {
                          FilterOnline.Click();
                          Thread.Sleep(1000);
                        }                          
                        else if(Onsite)
                        {
                          FilterOnsite.Click();
                          Thread.Sleep(1000);
                        }                          
                        else if (ShowAllSelected)
                        {
                          Thread.Sleep(1000);
                          ShowAll.Click();
                        }                          

                    //Wait for the element that displays the search result element's number
                    Wait.ElementPresent(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[1]/span");

                    
                    
                }
            }

            else if (SrchResultsCnt == 1)
            {
                driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p")).Click();
                Wait.ElementPresent(driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]");
                if (LocationType == "Online" || LocationType == "On-Site")
                {                    
                    Assert.That(Location.Text, Is.EqualTo(LocationType));
                }
                TestContext.WriteLine("Inside details of " + SkillName.Text+ " with location type " + Location.Text);
            }
        }
                

        public void SearchResult(string serviceTitle)
        {          
          //wait until the result is displayed
          Wait.ElementPresent(driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p");

          if (SrchRslts.Text == serviceTitle)
            SrchRslts.Click();

          Thread.Sleep(250);
        }

        

    }
}