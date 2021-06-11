using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SkillSwap.Utilities
{
    class ServiceData
    {
        public static string filepath = "\\TestData\\TestData.xls";
        public static string ExcelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + filepath);
       

        public static string TitleData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Title");
        }

        public static string DescriptionData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Description");
        }

        public static string CategData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Category");
        }

        public static string SubCategData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Subcategory");
        }

        public static string TagsCntData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "SkillExchangeTagsCount");
        }

        public static string SrvcTypeData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Service Type");
        }

        public static string LocatnTypeData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Location Type");
        }

        public static string SkillTrdeData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Skill Trade");
        }

        public static string ActvStatusData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "ActiveStatus");
        }

        public static string StrtDateData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Start date");
        }

        public static string EndDateData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "End date");
        }

        public static string TagsData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Tags");
        }

        public static string TagsDataCount(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "TagsCount");
        }
        public static string[] SkillExchangeData(int RowNum)
        {
            int count = Int32.Parse(TagsCntData(RowNum));
            string[] SkillExchngData = new string[count];
            
            for (int i = 0; i < count; i++)
            {
                SkillExchngData[i] = ExcelLibHelpers.ReadData((i + RowNum), "Skill-Exchange");
            }
            return SkillExchngData;
        }

        public static string CreditValue(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Credit");
        }

        public static string AvailableDays(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Available Days");
        }

        public static string AvailableDaysCnt(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "AvailableDaysCount");
        }

        public static string StrtTimeData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "Start Time");
        }

        public static string EndTimeData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ShareSkillPage");
            return ExcelLibHelpers.ReadData(RowNum, "End Time");
        }

        public static String ReadCurrentPassword(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ChangePassword");
            return ExcelLibHelpers.ReadData(RowNum, "Current Password");
        }

        public static String ReadEmailID(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ChangePassword");
            return ExcelLibHelpers.ReadData(RowNum, "EmailID");
        }

        public static String ReadNewPassword(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ChangePassword");
            return ExcelLibHelpers.ReadData(RowNum, "New Password");
        }

        public static String ReadConfirmPassword(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ChangePassword");
            return ExcelLibHelpers.ReadData(RowNum, "Confirm Password");
        }

        public static String ReadSignInEmailID(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SignIn");
            return ExcelLibHelpers.ReadData(RowNum, "EmailID");
        }

        public static String ReadSignInPassword(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SignIn");
            return ExcelLibHelpers.ReadData(RowNum, "Password");
        }

        public static String TestCaseTitleSignIn(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SignIn");
            return ExcelLibHelpers.ReadData(RowNum, "Title");
        }

        public static String FirstName(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SignUp");
            return ExcelLibHelpers.ReadData(RowNum, "FirstName");
        }

        public static String LastName(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SignUp");
            return ExcelLibHelpers.ReadData(RowNum, "LastName");
        }

        public static String EmailIDSignUp(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SignUp");
            return ExcelLibHelpers.ReadData(RowNum, "EmailID");
        }

        public static String PasswordSignUp(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SignUp");
            return ExcelLibHelpers.ReadData(RowNum, "Password");
        }

        public static String CnfrmPasswordSignUp(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SignUp");
            return ExcelLibHelpers.ReadData(RowNum, "ConfirmPassword");
        }

        public static String TestCaseTitleChngPswrd(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "ChangePassword");
            return ExcelLibHelpers.ReadData(RowNum, "Title");
        }

        public static String Availability()
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SellerProfileDetails");
            return ExcelLibHelpers.ReadData(2, "Availability");
        }

        public static String Hours()
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SellerProfileDetails");
            return ExcelLibHelpers.ReadData(2, "Hours");
        }

        public static String EarnTarget()
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SellerProfileDetails");
            return ExcelLibHelpers.ReadData(2, "Earn Target");
        }

        public static String languageData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SellerProfileDetails");
            return ExcelLibHelpers.ReadData(RowNum, "Language");
        }

        public static String languageLevel(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SellerProfileDetails");
            return ExcelLibHelpers.ReadData(RowNum, "LanguageLevel");
        }
        public static String skillData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SellerProfileDetails");
            return ExcelLibHelpers.ReadData(RowNum, "Skill");
        }

        public static String skillLevelData(int RowNum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SellerProfileDetails");
            return ExcelLibHelpers.ReadData(RowNum, "SkillLevel");
        }

        public static String collegeNameData()
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SellerProfileDetails");
            return ExcelLibHelpers.ReadData(2, "College/University Name");
        }

        public static String CountryOfCollege()
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SellerProfileDetails");
            return ExcelLibHelpers.ReadData(2, "Country of College/University");
        }

        public static String EducationTitle()
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SellerProfileDetails");
            return ExcelLibHelpers.ReadData(2, "Title");
        }

        public static String Degree()
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SellerProfileDetails");
            return ExcelLibHelpers.ReadData(2, "Degree");
        }

        public static String GraduationYear()
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SellerProfileDetails");
            return ExcelLibHelpers.ReadData(2, "Year of graduation");
        }

        public static String CertificateName(int entrynum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SellerProfileDetails");
            return ExcelLibHelpers.ReadData(entrynum, "Certificate/Award");
        }

        public static String certifiedFrom(int entrynum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SellerProfileDetails");
            return ExcelLibHelpers.ReadData(entrynum, "Certified From");
        }

        public static String CertificationYear(int entrynum)
        {
            ExcelLibHelpers.PopulateInCollection(ExcelPath, "SellerProfileDetails");
            return ExcelLibHelpers.ReadData(entrynum, "Year of certification");
        }

    }
}
