using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GNForm3C
{
    public class CV
    {
        #region Constructor
        public CV()
        {

        }
        #endregion Constructor

        public static Boolean IsURLEncryption = true;

        #region University Specific Configuration

        public static string DefaultUniversityNameHTML = "GNForm3C";
        public static string DefaultUniversityShortNameHTML = "GNForm3C";

        public static string DefaultUniversityName = "GNForm3C";
        public static string DefaultUniversityShortName = "PU";

        public static string DefaultCompanyName = "GNForm3C";
        public static string DefaultLogoPath = "~/Images/GNForm3C.jpg";
        public static string DefaultMISShortName = "GNForm3C";

        #region Default SMS Configuration

        public static string SMSURL = "";
        public static string SMSUserName = "";
        public static string SMSPassword = "";
        public static string SMSSenderID = "";

        #endregion Default SMS Configuration

        #region Default Email Credential

        public static class EmailCredentialInfo
        {
            public static String FromDisplayEmail = "";
            public static String FromDisplayName = CV.DefaultUniversityName;
            public static String SMTPClient = "";
            public static Int32 SMTPPortNo = 2525;
            public static String Username = "";
            public static String Password = "";

        }


        #endregion Default Email Credential

        

        #endregion University Specific Configuration
        
        #region Default Configuration

        public static string AppendForMenu = "";
        public static Boolean IsShowHelp = false;

        public static string CultureIndJavaScript = "en-IN";
        public static Int32 AutoComplete_MinimumPrefixLength = 3;
        public static Int32 CommandTimeOutSecondExam = 600;

        #endregion Default Configuration

        #region Current Value

        public static Int32 CurrentAcademicYearID = 87;
        public static Int32 CurrentAdmissionAcademicYearID = 87;
        public static Int32 CurrentAdmissionYearID = 14;
        public static Int32 CurrentFinYearID = 9;
                
        public static DateTime CurrentDate = DateTime.Now;
        public static DateTime CurrentDateTime = DateTime.Now;
        public static int CurrentYear = DateTime.Now.Year;
        public static int CurrentMonth = DateTime.Now.Month;
        public static Int32 CurrentCalendarYear = DateTime.Now.Year;
        public static Int32 CurrentCalendarMonth = DateTime.Now.Month;
        public static DateTime CurrentMonthFirstDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        public static DateTime CurrentYearFirstDay = new DateTime(DateTime.Now.Year, 1, 1);
        public static DateTime CurrentYearLastDay = new DateTime(DateTime.Now.Year, 12, 31);

        public static System.Data.SqlTypes.SqlDateTime GetGNForm3CDate = DateTime.Now;

        public static DateTime DateBeforeWeek = DateTime.Now.AddDays(-7);
        public static DateTime MonthStartingDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        public static DateTime DateBefore10Days = DateTime.Now.AddDays(-10);

        #endregion Current Value


        #region General

        public static string MaxAllowedFileSizeInMB = "1 MB";
        public static string MaxAllowedFileSize2MBMsg = "2 MB";
        public static string MaxAllowedFileSizeInkb = "150 kb";
        public static Int32 MaxAllowedFileSize1MB = 1000000;
        public static Int32 MaxAllowedFileSize2MB = 2000000;
        public static Int32 MaxAllowedFileSize5MB = 5000000;
        public static string MaxAllowedFileSize5MBMessage = "5 MB";
        public static Int32 MaxAllowedFileSize500Kb = 512000;
        public static string MaxAllowedFileSize500KbMessage = "500 Kb";

        public static Int32 MaxAllowedFileSize = 153600;
        public static string FileTypeUnit = "bit";
        public static string[] validFileTypes = { "pdf", "doc", "docx", "xls", "xlsx", "xlsm", "pptx", "ppt", "pptm", "txt", "jpg", "jpeg", "png", "gif", "bmp" };
        public static string[] validImageFileTypes = { "jpg", "jpeg", "png", "gif", "bmp" };
        public static string[] validOnlyExcelFileTypes = { "xls", "xlsx", "xlsm" };
        public static string[] ValidQuestionPaperFormat = { "pdf", "doc" };

        public static Int32 MaxPhotoHeightInPX = 500;
        public static Int32 MaxPhotoWidthInPX = 500;
        public static Int32 MaxPhotoSizeInKB = 150;

        #endregion General
       

       #region Page Header in AddEdit cs Code
        public static string PageHeaderAdd = "Add";
        public static string PageHeaderEdit = "Edit";
        public static string PageHeaderMany = "Add Many";

        #endregion Page Header in AddEdit cs Code

        #region Pagination

        public static int PageRecordSize = 100;
        public static int PageDisplaySize = 10; //Pages Displayed in Pagination
        public static int DisplayIndex = 5;
        public static int SmallestPageSize = 20;
        #endregion Pagination

        #region Default Display Formats
        public static string DefaultSQLDateFormat = "yyyy-MM-dd";


        public static string DefaultDateFormat = "dd-MM-yyyy";
        public static string DefaultTimeFormat = "hh:mm tt";
        public static string DefaultDateFormatForGrid = "{0:dd-MM-yyyy}";
        public static string DataFormatWithSortMonthandYear = "{0:MMM - yyyy}";
        public static string DefaultDayFromDateFormatForGrid = "{0:dddd}";
        public static string DefaultDateFormatForGridWithDayName = "{0:dd-MM-yyyy dddd}";
        public static string DefaultTimeFormatForGrid = "{0:hh:mm tt}";
        public static string DefaultDateTimeFormatForGrid = "{0:dd-MM-yyyy hh:mm:ss tt}";
        public static string DefaultDateTimeFormatForGridWithoutSecond = "{0:dd-MM-yyyy hh:mm tt}";
        public static string DefaultDayMonthNameForGrid = "{0:dd-MMM}";
        public static string DefaultHTMLDateFormat = "dd-mm-yyyy";
        public static string DefaultHTMLDateTimeFormat = "dd-mm-yyyy hh:mm tt";
        public static string DefaultHTMLDateFormatWithDayName = "dd-mm-yyyy DD";
        public static string DefaultDateTimeFormat = "dd-MM-yyyy hh:mm:ss tt";

        public static string DefaultCurrencyFormat = "{0:#,0}";
        public static string DefaultCurrencyFormatWithOutDecimalPoint = "{0:#,0}";
        public static string DefaultCurrencyFormatWithDecimalPoint = "{0:#,0.00}";
        public static string DefaultDecimalFormat = "{0:0.00}";
        public static string DefaultDecimalFormat2DecimalPoints = "F";
        public static string DefaultNumberFormat = "{0:00}";

        public static string DefaultAmountFormatForRDLC = "##,##,##,##,##0";
        public static string DefaultAmountFormatWithDecimalForRDLC = "##,##,##,##,##0.00";
        public static string DefaultCurrencyFormatForGrid = "##,##,##,##,##0";

        public static string DefaultRDLCLanguage = "en-IN";

        #endregion Default Display Formats

        

        #region Control Configuration
        public static System.Web.UI.WebControls.ValidatorDisplay ValidationDisplay = System.Web.UI.WebControls.ValidatorDisplay.Dynamic;
        public static string DropDownZeroIndexValue = "-99";
        public static string DefaultStaffType = "Internal";
        #endregion Control Configuration

        #region List Page
        public static string SearchHeaderText = "SEARCH";
        public static string SearchResultHeaderText = "SEARCH RESULT";
        public static int UpdateProgressDisplayAfter = 10;
        public static char ListPageSearchParamSeperator = '$';

        #endregion List Page


        #region Common URL

        public static string DefaultLoginPageURL = "~/Login.aspx";
        public static string LoginPageURL = "~/Default.aspx";
        public static string DefaultHomeURL = "~/AdminPanel//Default.aspx";
        public static string ChangePasswordPageURL = "~/ChangePassword.aspx";
        public static string PasswordChanged = "Password Changed Successfully";
        public static string PasswordWrong = "Old Password is Wrong!";
        public static string DefaultIconImageUrl = "";
        public static string ErrorAccessDeniedPageURL = "~/AdminPanel/Common/Error401.aspx";

        
        #endregion Common URL

        #region Default Images
        public static string CommonImagePath = "~/Images/defaultIcon.jpg";
        public static string NoImagePath = "~/Images/noimage.png";
        public static string FacultyNoImagePath = "~/Images/Faculty_NoImg.jpeg";
        #endregion Default Images

        #region Default Units
        public static string DefaultHeightUnit = "ft";
        public static string DefaultWeightUnit = "kg";
        #endregion Default Units
        
        
     
        
    }
}
