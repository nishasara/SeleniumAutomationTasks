using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SkillSwap.Pages;
using SkillSwap.Utilities;
using System;
using System.IO;
using System.Threading;

namespace SkillSwap
{
    [TestFixture]
    public class UnitTest1 : CommonDriver

    {
        //Get the browser option from the resource file
        public static int Browser = Int32.Parse(Resource.SkillSwapResource.Browser);

        //Get the URL from the resource file
        public static string URL = Resource.SkillSwapResource.URL;

        //Declare object for ExtentTest
        public static ExtentTest test;

        //Declare object for ExtentReports
        public static ExtentReports extent;

        //Test Case name
        public String TestCase_Name;

        [SetUp]
        public void Setup()
        {
            //Choose the browser as per the input from the resource file
            switch (Browser)
            {
                case 1:
                    //Create an instance of the FireFox driver
                    driver = new FirefoxDriver();
                    break;

                case 2:
                    //Create an instance of the ChromeDriver
                    driver = new ChromeDriver();

                    //Navigate to the required URL
                    driver.Navigate().GoToUrl(URL);

                    //Maximise the window
                    driver.Manage().Window.Maximize();
                    break;
            }
        }

        [OneTimeSetUp]
        //Entent reporting using Extent Reporter 4
        protected void ExtentStart()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = (projectPath + "Reports\\ExtentReport.html");
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "LocalHost");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("UserName", "Nisha Thomas");
        }

        [Category("Sign Up with valid details first time")]
        [Test, Description("Checks if user is able to Sign Up with Valide details"), Order(1)]
        public void SignUpFirstTime()
        {
            bool FirstTime = true;

            TestCase_Name = "Register New user";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for SignUp page
            SignUp JoinObj = new SignUp(FirstTime, driver);

            //Invoke the register function using the instance of SignUp page
            JoinObj.Register();
        }

        [Category("Sign Up with same details second time")]
        [Test, Description("Checks if user is able to Sign Up with same email second time"), Order(2)]
        public void SignUpWithSameEmailSecondTime()
        {
            bool FirstTime = false;

            TestCase_Name = "Register with same Email ID twice";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for SignUp page
            SignUp JoinObj = new SignUp(FirstTime, driver);

            //Invoke the register function using the instance of SignUp page
            JoinObj.Register();
        }

        [Category("Sign In Invalid cases")]
        [TestCase(3), Order(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void CheckSignIn(int rownum)
        {
            //Get the TestCase title from the excel sheet to determine the objective of the test 
            String TestCaseTitle = ServiceData.TestCaseTitleSignIn(rownum);

            //Assign the appropriate Test Name
            TestCase_Name = $"SignIn with {TestCaseTitle}";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page 
            SignIn JoinObj = new SignIn(driver);

            JoinObj.LoginSteps(TestCaseTitle, rownum);
            
        }

        [Category("Add Availability Details")]
        [Test, Order(4)]
        public void AddAvailability()
        {

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Adding the TestCase name
            TestCase_Name = "Adding availability details in profile";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            //Navigate to Profile
            SkillObj.navigateToProfile();

            //Invoke function to add availability details
            SkillObj.addDetails();

        }

        [Category("Add 4 Language Details")]
        [Test, Order(5)]
        public void AddLanguages()
        {
            
            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Adding the TestCase name
            TestCase_Name = "Adding Language details in profile";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            //Navigate to Profile
            SkillObj.navigateToProfile();

            //Navigate to Language Tab
            SkillObj.goToLanguageTab();

            SkillObj.addLanguages();

        }

        [Category("Add Skills in Profile")]
        [Test, Order(6)]
        public void AddSkillsInProfile()
        {

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Adding the TestCase name
            TestCase_Name = "Adding Skill details in profile";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            //Navigate to Profile
            SkillObj.navigateToProfile();

            //Navigate to Language Tab
            SkillObj.goToSkillsTab();

            SkillObj.addSkills();

        }

        [Category("Add Education in Profile")]
        [Test, Order(7)]
        public void AddEducationInProfile()
        {

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Adding the TestCase name
            TestCase_Name = "Adding Education details in profile";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            //Navigate to Profile
            SkillObj.navigateToProfile();

            //Navigate to Language Tab
            SkillObj.goToEducationTab();

            SkillObj.addEducation();

        }

        [Category("Add Certifications in Profile")]
        [Test, Order(8)]
        public void AddCertificationsInProfile()
        {

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Adding the TestCase name
            TestCase_Name = "Add Certifications in Profile";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            //Navigate to Profile
            SkillObj.navigateToProfile();

            //Navigate to Language Tab
            SkillObj.goToCertificationTab();

            SkillObj.addCertifications();

        }

        [Category("Add Description in Profile")]
        [Test, Order(9)]
        public void AddDescriptionInProfile()
        {

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Adding the TestCase name
            TestCase_Name = "Add Description in Profile";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            //Navigate to Profile
            SkillObj.navigateToProfile();

            //Navigate to Language Tab
            SkillObj.AddDescription();
                    

        }


        [Category("Check duplicate entries of certifications in profile")]
        [Test, Order(10)]
        public void DuplicateEntriesCheck()
        {

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Adding the TestCase name
            TestCase_Name = "Check duplicate entries of certifications in profile";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            //Navigate to Profile
            SkillObj.navigateToProfile();

            //Navigate to Language Tab
            SkillObj.goToCertificationTab();

            SkillObj.checkDuplicateEntries();
        }


        [Category("Edit Language Details")]
        [Test, Order(11)]
        public void EditLanguages()
        {

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Adding the TestCase name
            TestCase_Name = "Edit Language Details";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            //Navigate to Profile
            SkillObj.navigateToProfile();

            //Navigate to Language Tab
            SkillObj.goToLanguageTab();

            SkillObj.editLanguages();
        }

        [Category("Delete Language Details")]
        [Test, Order(12)]
        public void DeleteLanguages()
        {

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Adding the TestCase name
            TestCase_Name = "Delete Language Details";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            //Navigate to Profile
            SkillObj.navigateToProfile();

            //Navigate to Language Tab
            SkillObj.goToLanguageTab();

            SkillObj.DeleteLanguages();

        }



        //This test is to check if the user can add details of various service using Share Skill feature in SkillSwap
        //Each of these test cases below adds unique entry for the services rendered
        [Category("Adding Services through ShareSkill")]
        [TestCase(2), Order(13)]
        [TestCase(8)]
        [TestCase(15)]
        [TestCase(29)]
        [TestCase(33)]
        //Function to add services using Share Skill feature to render services to others
        public void ShareSkill(int rownumber)
        {
            //Get the Title of the service from the excel sheet
            String Title = ServiceData.TitleData(rownumber);

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Adding the TestCase name
            TestCase_Name = $"Adding services with title {Title}";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType,2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            //Invoke the function to navigate to Share Skill Page
            SkillObj.navigateToShareSkill();

            //Create an instance for the ShareSkillPage
            ShareSkillPage Obj = new ShareSkillPage(driver, rownumber);

            //Invoke the function to fill the details of services rendered
            Obj.FillDetailsOfServiceProvided();

            //Create an instance for the Listing Management page
            ListingManagement listObj = new ListingManagement(driver, rownumber);

            //Invoke the funtion to navigate to Manage Listings
            listObj.ManageListing();

            //Invoke the funtion to view the listings
            listObj.ViewListings();

            //Invoke the funtion to view the details of the listings
            listObj.NavigateToViewAddedDetails();

            //Create an instance for the Service Detail page
            ServiceDetail ViewDetailObj = new ServiceDetail(driver, rownumber);

            //Invoke the funtion to validate the details of services
            ViewDetailObj.ValidateServiceDetail();
        }



        [Category("Editing Details for a skill based on title")]
        [TestCase("Yoga Trainer", 22), Order(14)]
        public void EditSkill(string TitleForServcToBeEdited, int rownumber)
        {
            bool editMatchFound = false;

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            TestCase_Name = $"Editing existing services for title {TitleForServcToBeEdited}";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage listObj = new HomePage(driver);

            //Invoke the funtion to navigate to Manage Listings
            listObj.navigateToManageListings();

            //Create an instance for the Listing Management page
            ListingManagement obj = new ListingManagement(driver, TitleForServcToBeEdited, rownumber);

            //Invoke the function to check if the service to be edited is available in the Manage Listings
            editMatchFound = obj.NavigateToEditDetails();

            //Create instances for ServiceListing Page and SearchSkill Page
            ServiceListing editObj = new ServiceListing(driver, rownumber);
            SearchSkill SrchObj = new SearchSkill(driver, rownumber);

            //Proceed to Edit service only if the service to be edited is found
            if (editMatchFound)
            {
                //Invoke the function to Edit services
                editObj.EditServices();

                //Implicit wait
                Wait.wait(2, driver);

                //Invoke the function to search for service after edit
                obj.SearchSkillsAfterEdit();

                //Invoke the function to validate the search result
                SrchObj.SkillSrchResult();                

                //Create an instance for ServiceDetail Page
                ServiceDetail ViewEditdDetailObj = new ServiceDetail(driver, rownumber);

                //Invoke the function to validate the edited details
                ViewEditdDetailObj.ValidateServiceDetail();
            }

        }               

        [Category("Search Skills by SkillName")]
        [TestCase("Classical Music ", "Online"), Order(15)]
        [TestCase("Classical Music ", "On-Site")]
        [TestCase("Classical Music ", "ShowAll")]
        public void SearchSkillsByFilters(string TitleForServcToBeSearched, string LocationTypeForService )
        {
            TestCase_Name = $"Searching Skills for {TitleForServcToBeSearched} location type as {LocationTypeForService}";
            test = extent.CreateTest(TestCase_Name);

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage listObj = new HomePage(driver);

            //Search for the required service from the home page
            listObj.SearchSkillFromHomePage(TitleForServcToBeSearched);

            SearchSkill SrchObj = new SearchSkill(driver);
            SrchObj.FilterSkills(LocationTypeForService, TitleForServcToBeSearched);
        }

        [Category("Search Skills by Username")]
        [TestCase("Nisha Thomas", "Online"), Order(16)]
        [TestCase("Nisha Thomas", "On-Site")]
        [TestCase("Nisha Thomas", "ShowAll")]
        public void SearchSkillsByName(string Username, string LocationTypeForService)
        {
            TestCase_Name = $"Searching Skills by {Username} location type as {LocationTypeForService}";
            test = extent.CreateTest(TestCase_Name);

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage listObj = new HomePage(driver);

            //Search for the required service from the home page
            listObj.NavigateToSearchSkill();

            //Create an object for SearchSkill page
            SearchSkill SrchObj = new SearchSkill(driver);

            //Invoke the method for performing Filter operation on skills
            SrchObj.FilterSkillsOfParticularUser(LocationTypeForService, Username);
        }

        [Category("Delete Notifications")]
        [TestCase(2), Order(17)]
        public void DeleteNotifications(int SelectNotificationsCount)
        {
            TestCase_Name = $"Delete {SelectNotificationsCount} notifications";
            test = extent.CreateTest(TestCase_Name);

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage listObj = new HomePage(driver);

            //Invoke function to see all notifications
            listObj.SeeAllNotifications();

            //Create an instance for the HomePage
            Dashboard obj = new Dashboard(driver);

            obj.SelectNotifications(SelectNotificationsCount);
            obj.DeleteSelectedNotifications();

        }

        
        [Category("Mark All As Read")]
        [TestCase, Order(18)]
        public void MarkAllAsRead()
        {

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Adding the TestCase name
            TestCase_Name = "Using Mark All As Read ";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            //Navigate to Notifications and Mark as Read
            SkillObj.MarkNotificationAsRead();        


        }

        [Category("Select and Unselect")]
        [TestCase(3), Order(19)]
        public void SelectAndUnselect(int notificationsNumber)
        {

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Adding the TestCase name
            TestCase_Name = "Select and Unselect Notifications";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            //Navigate to Notifications and Mark as Read
            SkillObj.SeeAllNotifications();

            //Wait until the Dashboard page is launched
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/a/h1");

            //Create an instance for the Dashboard
            Dashboard obj = new Dashboard(driver);                       

            //Invoke the function to select the notifications
            obj.SelectNotifications(notificationsNumber);

            //Invoke function to check selected notifications
            obj.CheckSelectNotifications(notificationsNumber);

            obj.UncheckSelectNotifications(notificationsNumber);

        }

        [Category("Sent Request")]
        [TestCase("Agile Coach"), Order(20)]
        public void SentRquest(string serviceTitle)
        {

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Adding the TestCase name
            TestCase_Name = "Manage Request - Sent Request";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            //Search Skills from Home Page
            SkillObj.SearchSkillFromHomePage(serviceTitle);

            //Create an instance for Search Skill Page
            SearchSkill srchObj = new SearchSkill(driver);

            string[] reqstDetails = new string[4];

            srchObj.SearchResult(serviceTitle);

            ServiceDetail detailObj = new ServiceDetail(driver);

            //Get the details of teh request raised
            reqstDetails = detailObj.SentRequestToSeller();

            SentRequest rqstObj = new SentRequest(driver);

            //Validate the sent Request
            rqstObj.CheckSentRequests(reqstDetails);

        }


        [Category("Chat")]
        [TestCase("QA Coach"), Order(21)]
        public void ValidateChat(string serviceTitle)
        {
            string Sellername;

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Adding the TestCase name
            TestCase_Name = "Chat with other Sellers";
            test = extent.CreateTest(TestCase_Name);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 7);

            //Wait until the Mars Logo in the HomePage is visible
            Wait.ElementIsVisible(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/a");

            //Create an instance for the HomePage
            HomePage SkillObj = new HomePage(driver);

            SkillObj.navigateToProfile();

            Sellername = SkillObj.GetSellerName();

            //Search Skills from Home Page
            SkillObj.SearchSkillFromHomePage(serviceTitle);

            //Create an instance for Search Skill Page
            SearchSkill srchObj = new SearchSkill(driver);
            
            //Invoke the function to search for the skill
            srchObj.SearchResult(serviceTitle);

            ServiceDetail detailObj = new ServiceDetail(driver);

            detailObj.NavigateToChat();

            Message chatObj = new Message(driver);

            string[] ChatDetails = new string[4];

            ChatDetails = chatObj.ChatWithSeller();

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            SkillObj.navigateToChat();

            chatObj.CheckNewChatMessages(Sellername, ChatDetails);

        }


        [Category("Change Password"), Order(22)]
        [TestCase(2)]
        [TestCase(3)]

        public void ChangePassword(int Rownum)
        {

            TestCase_Name = "Change Current Password";
            test = extent.CreateTest(TestCase_Name);

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleChngPswrd(Rownum);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, Rownum);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage listObj = new HomePage(driver);

            //Invoke function to navigate to change password
            listObj.GoToChangePassword(Rownum);

            //Sign in using new password
            JoinObj.LoginStepsAfterChangePassword(Rownum);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

        }

        [Category("Delete existing services from the manage Listings page")]        
        [TestCase("Blogger"), Order(23)]
        [TestCase("QA Coach")]
        public void DeleteService(string TitleForServcToBeDeleted)
        {
            TestCase_Name = $"Deleting existing services for title {TitleForServcToBeDeleted}";
            test = extent.CreateTest(TestCase_Name);

            //Get the SignInType from the excel sheet 
            String SignInType = ServiceData.TestCaseTitleSignIn(2);

            //Create an instance for the SignIn page
            SignIn JoinObj = new SignIn(driver);

            //Invoke the LoginSteps to verify if the user can log in with valid credentials
            JoinObj.LoginSteps(SignInType, 2);

            //Invoke the function to validate if the user has logged in successfully and the home page is displayed
            JoinObj.ValidateHomePage();

            //Create an instance for the HomePage
            HomePage listObj = new HomePage(driver);

            //Invoke the funtion to navigate to Manage Listings
            listObj.navigateToManageListings();

            //Implicit wait
            Wait.wait(2, driver);

            //Create an instance for ListingManagement
            ListingManagement DeletelistObj = new ListingManagement(driver, TitleForServcToBeDeleted);

            //Invoke Delete Operation
            DeletelistObj.DeleteDetails();

            //Invoke a function to search for the service after deletion
            DeletelistObj.SearchSkillsAfterDelete();
            SearchSkill SrchObj = new SearchSkill(driver);

            //Invoke a function for search
            SrchObj.SrchResultAfterDel();
        }


        [TearDown]
        public void TearDown()
        {
            String fileName;

            DateTime time = DateTime.Now;

            fileName = "Screenshot_" + time.ToString("hh_mm_") + TestCase_Name + ".png";

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            Status logstatus = Status.Pass;
            if (status == TestStatus.Failed)
            {
                logstatus = Status.Fail;
                var mediaEntity = CaptureScreenShot(driver, fileName);
                test.Log(logstatus, "Fail");
                test.Log(Status.Fail, stackTrace + errorMessage);
                /* Usage of MediaEntityBuilder for capturing screenshots */
                test.Pass("ExtentReport 4 Capture: Test Failed", mediaEntity);
            }

            else if (status == TestStatus.Passed)
            {
                logstatus = Status.Pass;
                var mediaEntity = CaptureScreenShot(driver, fileName);
                test.Log(logstatus, "Pass");
                /* Usage of MediaEntityBuilder for capturing screenshots */
                test.Pass("ExtentReport 4 Capture: Test Passed", mediaEntity);

            }

            extent.Flush();
            driver.Quit();

        }
    }
}