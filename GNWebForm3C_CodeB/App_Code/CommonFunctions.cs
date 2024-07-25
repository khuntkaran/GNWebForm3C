using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using GNForm3C.BAL;
using System.IO;
using System.Globalization;
using System.Net.Mail;
using System.Net;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;
using System.Data.SqlTypes;
using GNForm3C.ENT;
using System.Configuration;
using System.Data.OleDb;
using System.Web.UI;
using System.Security.Cryptography;

namespace GNForm3C
{
    public class CommonFunctions
    {
        #region Constructor
        public CommonFunctions()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Encryption/Decryption
        public static string EncryptPassword(String Password)
        {
            return Password;
            


        }

        public static string Encrypt_Md5(string str_encode)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str_encode));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();

        }


        public static string EncryptBase64(string password)
        {
            if (CV.IsURLEncryption)
            {
                string strmsg = string.Empty;
                byte[] encode = new byte[password.Length];
                encode = Encoding.UTF8.GetBytes(password);
                strmsg = Convert.ToBase64String(encode);
                return strmsg;
            }
            else
                return password;

        }

        public static string DecryptBase64(string encryptpwd)
        {
            if (CV.IsURLEncryption)
            {
                string decryptpwd = string.Empty;
                if (IsBase64Encoded(encryptpwd))
                {
                    UTF8Encoding encodepwd = new UTF8Encoding();
                    Decoder Decode = encodepwd.GetDecoder();
                    byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
                    int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                    char[] decoded_char = new char[charCount];
                    Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                    decryptpwd = new String(decoded_char);
                }
                return decryptpwd;
            }
            else
                return encryptpwd;


        }

        public static SqlInt32 DecryptBase64Int32(SqlString encryptpwd)
        {
            int n;

            if (CV.IsURLEncryption)
            {

                if (!encryptpwd.IsNull && encryptpwd.Value != String.Empty)
                {
                    if (IsBase64Encoded(encryptpwd.Value))
                    {
                        string decryptpwd = string.Empty;
                        UTF8Encoding encodepwd = new UTF8Encoding();
                        Decoder Decode = encodepwd.GetDecoder();
                        byte[] todecode_byte = Convert.FromBase64String(encryptpwd.Value);
                        int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                        char[] decoded_char = new char[charCount];
                        Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                        decryptpwd = new String(decoded_char);

                        if (int.TryParse(decryptpwd, out n))
                            return Convert.ToInt32(decryptpwd);
                        else return SqlInt32.Null;
                    }
                    else return SqlInt32.Null;
                }
                else
                    return SqlInt32.Null;
            }
            else
            {
                if (encryptpwd.IsNull)
                    return SqlInt32.Null;
                else if (int.TryParse(encryptpwd.Value, out n))
                    return Convert.ToInt32(encryptpwd.Value);
                else return SqlInt32.Null;
            }

        }

       
        public static bool IsBase64Encoded(String str)
        {
            try
            {
                // If no exception is caught, then it is possibly a base64 encoded string
                byte[] data = Convert.FromBase64String(str);
                // The part that checks if the string was properly padded to the
                // correct length was borrowed from d@anish's solution
                return (str.Replace(" ", "").Length % 4 == 0);
            }
            catch
            {
                // If exception is caught, then it is not a base64 encoded string
                return false;
            }
        }


        #endregion Encryption/Decryption

        #region Function For Paging In List Page

        public static void BindPageList(Int32 TotalPages, Int32 TotalRecords, Int32 CurrentPage, Int32 PageDisplaySize, Int32 DisplayIndex, Repeater rp, HtmlGenericControl liPrevious, LinkButton lbtnPrevious, HtmlGenericControl liFirstPage, LinkButton lbtnFirstPage, HtmlGenericControl liNext, LinkButton lbtnNext, HtmlGenericControl liLastPage, LinkButton lbtnLastPage)
        {
            if (TotalRecords == 0 && TotalPages == 0)
            {
                liPrevious.Attributes["class"] = "paginate_button previous disabled";
                lbtnPrevious.Enabled = false;
                liFirstPage.Attributes["class"] = "paginate_button previous disabled";
                lbtnFirstPage.Enabled = false;
                liNext.Attributes["class"] = "paginate_button next disabled";
                lbtnNext.Enabled = false;
                liLastPage.Attributes["class"] = "paginate_button next disabled";
                lbtnLastPage.Enabled = false;
                return;
            }

            if (CurrentPage == 1)
            {
                liPrevious.Attributes["class"] = "paginate_button previous disabled";
                lbtnPrevious.Enabled = false;
                liFirstPage.Attributes["class"] = "paginate_button previous disabled";
                lbtnFirstPage.Enabled = false;
            }
            else
            {
                liPrevious.Attributes["class"] = "paginate_button previous";
                lbtnPrevious.Enabled = true;
                liFirstPage.Attributes["class"] = "paginate_button previous";
                lbtnFirstPage.Enabled = true;

            }
            if (CurrentPage == TotalPages)
            {
                liNext.Attributes["class"] = "paginate_button next disabled";
                lbtnNext.Enabled = false;
                liLastPage.Attributes["class"] = "paginate_button next disabled";
                lbtnLastPage.Enabled = false;
            }
            else
            {
                liNext.Attributes["class"] = "paginate_button next";
                lbtnNext.Enabled = true;
                liLastPage.Attributes["class"] = "paginate_button next";
                lbtnLastPage.Enabled = true;
            }

            if (TotalPages <= PageDisplaySize)
            {
                BindPage(1, TotalPages, rp);
            }
            else if (TotalPages > PageDisplaySize)
            {
                if (CurrentPage <= DisplayIndex)
                {
                    BindPage(1, PageDisplaySize, rp);
                }
                else
                {
                    int Suffix = PageDisplaySize - DisplayIndex;

                    int Prefix = PageDisplaySize - Suffix - 1;

                    if ((CurrentPage + Suffix) >= TotalPages)
                    {
                        BindPage(CurrentPage - Prefix, TotalPages, rp);
                    }
                    else
                    {
                        BindPage(CurrentPage - Prefix, CurrentPage + Suffix, rp);
                    }
                }
            }
        }

        public static void BindPage(int FirstPage, int LastPage, Repeater rp)
        {
            DataTable dtPageNo = new DataTable();
            dtPageNo.Columns.Add("PageNo");
            for (int i = FirstPage; i <= LastPage; i++)
            {
                DataRow drPageNo = dtPageNo.NewRow();
                drPageNo["PageNo"] = i.ToString();
                dtPageNo.Rows.Add(drPageNo);
            }
            rp.DataSource = dtPageNo;
            rp.DataBind();
        }

        public static void GetDropDownPageSize(DropDownList ddl)
        {
            List<ListItem> pageSize = new List<ListItem>();
            //pageSize.Add(new ListItem("All", "0"));
            //pageSize.Add(new ListItem("1", "1"));
            //pageSize.Add(new ListItem("10", "10"));
            pageSize.Add(new ListItem("20", "20"));
            pageSize.Add(new ListItem("50", "50"));
            pageSize.Add(new ListItem("100", "100"));
            pageSize.Add(new ListItem("500", "500"));

            foreach (ListItem li in pageSize)
            {
                ddl.Items.Add(li);
            }
        }

        #endregion Function For Paging In List Page

        #region Other
        public static System.Drawing.Image ByteArrayToImage(byte[] bArray)
        {
            if (bArray == null)
                return null;

            System.Drawing.Image newImage;

            try
            {
                using (MemoryStream ms = new MemoryStream(bArray, 0, bArray.Length))
                {
                    ms.Write(bArray, 0, bArray.Length);
                    newImage = System.Drawing.Image.FromStream(ms, true);
                }
            }
            catch (Exception ex)
            {
                newImage = null;
                //Log an error here
            }

            return newImage;
        }
        public static string GetMonthName(int month)
        {
            int iMonthNo = month;
            DateTime dtDate = new DateTime(2000, iMonthNo, 1);
            string sMonthName = dtDate.ToString("MMM");
            string sMonthFullName = dtDate.ToString("MMMM");
            return sMonthName;
        }

        public static string Experience(int year, int month)
        {
            string experience = "";
            if (year > 0)
            {
                if (year > 1)
                    experience = year.ToString() + " Years";
                else
                    experience = year.ToString() + " Year";
            }
            else if (year == 0)
                experience = year.ToString() + " Year";

            if (month > 0)
            {
                if (month > 1)
                    experience = experience + ", " + month.ToString() + " Months";
                else
                    experience = experience + ", " + month.ToString() + " Month";
            }
            else if (month == 0)
                experience = experience + ", " + month.ToString() + " Month";

            if (year == 0 && month == 0)
                experience = "0 Year";

            return experience;
        }

        public static string GetStatusLabelCss(bool Status)
        {
            string cssclass = string.Empty;

            if (Convert.ToBoolean(Status))
            {
                cssclass = CSSClass.StatusLabelSuccess;
            }
            else
            {
                cssclass = CSSClass.StatusLabelDanger;
            }


            return cssclass;
        }


        public static string GetVivaMarkStatusCSSClass(String Status)
        {

            String cssclass = String.Empty;
            if (Status == "Absent")
            {
                cssclass = CSSClass.MarkAbsentCSSClass;
            }
            else if (Status == "Fail")
            {
                cssclass = CSSClass.MarkFailCSSClass;
            }

            return cssclass;
        }

        public static string GetMarkStatusCSSClassLabel(String Status)
        {

            String cssclass = String.Empty;
            if (Status == "Absent")
            {
                cssclass = CSSClass.MarkAbsentCSSClassLabel;
            }
            else if (Status == "Fail")
            {
                cssclass = CSSClass.MarkFailCSSClassLabel;
            }

            return cssclass;
        }

        public static string GetRecruiterStatus(string Status)
        {
            string cssclass = string.Empty;

            if (Status == "Active")
            {
                cssclass = CSSClass.StatusLabelSuccess;
            }
            else
            {
                cssclass = CSSClass.StatusLabelDanger;
            }
            return cssclass;
        }

        public static string GetAcceptanceStatusLabelCss(String Status)
        {
            string cssclass = string.Empty;

            if (Status == "Yes")
            {
                cssclass = CSSClass.StatusLabelSuccess;
            }
            else if (Status == "No")
            {
                cssclass = CSSClass.StatusLabelDanger;
            }
            else
            {
                cssclass = CSSClass.StatusLabelWarning;
            }

            return cssclass;
        }


       
        public static string GetAcceptanceStatusLabelText(String Status)
        {
            string StatusText = string.Empty;

            if (Status == "Yes")
            {
                StatusText = "Accepted";
            }
            else if (Status == "No")
            {
                StatusText = "Rejected";
            }
            else
            {
                StatusText = "Pending";
            }

            return StatusText;
        }

        public static string GetApprovalStatusLabelText(String Status)
        {
            string StatusText = string.Empty;

            if (Status == "Approved")
            {
                StatusText = "Approved";
            }
            else if (Status == "Rejected")
            {
                StatusText = "Rejected";
            }
            else
            {
                StatusText = "Pending";
            }

            return StatusText;
        }

        public static string GetApprovalStatusLabelText(bool Status)
        {
            string StatusText = string.Empty;

            if (Status == true)
            {
                StatusText = "Approved";
            }
            else if (Status == false)
            {
                StatusText = "Rejected";
            }

            return StatusText;
        }

        #region Practical Exam

        public static string GetInternalMarkLockStatusLabelCss(String Status)
        {
            string cssclass = string.Empty;

            if (Status == "Locked")
            {
                cssclass = CSSClass.StatusLabelSuccess;
            }
            else if (Status == "Pending")
            {
                cssclass = CSSClass.StatusLabelWarning;
            }
            else
            {
                cssclass = CSSClass.StatusLabelInfo;
            }

            return cssclass;
        }

        public static string GetPracticalExamStatusStatusLabelCss(String Status)
        {
            string cssclass = string.Empty;

            if (Status == "Locked")
            {
                cssclass = CSSClass.StatusLabelSuccess;
            }
            else
            {
                cssclass = CSSClass.StatusLabelWarning;
            }

            return cssclass;
        }

        #endregion Practical Exam

        public static string GetOrderSentLabelText(bool Status)
        {
            string txt = string.Empty;

            if (Convert.ToBoolean(Status))
            {
                txt = "Sent";
            }
            else
            {
                txt = "Pending";
            }

            return txt;
        }
        public static string GetOrderSentLabelCss(bool Status)
        {
            string cssclass = string.Empty;

            if (Status == true)
            {
                cssclass = CSSClass.StatusLabelSuccess;
            }
            else if (Status == false)
            {
                cssclass = CSSClass.StatusLabelWarning;
            }

            return cssclass;
        }


        public static string GetApprovalStatusLabelCss(String Status)
        {
            string cssclass = string.Empty;

            if (Status == "Approved")
            {
                cssclass = CSSClass.StatusLabelSuccess;
            }
            else if (Status == "Rejected")
            {
                cssclass = CSSClass.StatusLabelDanger;
            }
            else if (Status == "Locked")
            {
                cssclass = CSSClass.StatusLabelInfo;
            }
            else
            {
                cssclass = CSSClass.StatusLabelWarning;
            }

            return cssclass;
        }

        public static string GetStatusLabelCssPassFail(bool Status)
        {
            string cssclass = string.Empty;

            if (Convert.ToBoolean(Status))
            {
                cssclass = CSSClass.StatusLabelDanger;
            }
            else
            {
                cssclass = CSSClass.StatusLabelSuccess;
            }

            return cssclass;
        }

        public static string GetStatusLabelPaidNotPaidCss(bool Status)
        {
            string cssclass = string.Empty;

            if (!Status)
            {
                cssclass = CSSClass.StatusLabelSuccess;
            }
            else
            {
                cssclass = CSSClass.StatusLabelDanger;
            }

            return cssclass;
        }

        public static string GetStatusLabelActiveBlockedCss(bool Status)
        {
            string cssclass = string.Empty;

            if (!Status)
            {
                cssclass = CSSClass.StatusLabelSuccess;
            }
            else
            {
                cssclass = CSSClass.StatusLabelDanger;
            }

            return cssclass;
        }

        public static string GetStatusLabelChequeReturnCss(bool Status)
        {
            string cssclass = string.Empty;

            if (Status)
            {
                cssclass = CSSClass.StatusLabelDanger;
            }

            return cssclass;
        }
        public static string GetStatusLabelYesNo(bool Status)
        {
            string txt = string.Empty;

            if (Convert.ToBoolean(Status))
            {
                txt = "Yes";
            }
            else
            {
                txt = "No";
            }

            return txt;
        }

        public static string GetPaperReceiveStatusLabel(bool Status)
        {
            string txt = string.Empty;

            if (Convert.ToBoolean(Status))
            {
                txt = "Received";
            }
            else
            {
                txt = "Pending";
            }

            return txt;
        }

        public static string GetStatusLabelPresentAbsent(bool Status)
        {
            string txt = string.Empty;

            if (Convert.ToBoolean(Status))
            {
                txt = "Present";
            }
            else
            {
                txt = "Absent";
            }

            return txt;
        }

        public static string GetStatusLabelPassFail(bool Status)
        {
            string txt = string.Empty;

            if (Convert.ToBoolean(Status))
            {
                txt = "Fail";
            }
            else
            {
                txt = "Pass";
            }

            return txt;
        }
        public static string GetStatusLabelActiveBlocked(bool Status)
        {
            string txt = string.Empty;

            if (Convert.ToBoolean(Status))
            {
                txt = "Blocked";
            }
            else
            {
                txt = "Active";
            }

            return txt;
        }

        public static string GetStatusLabelChequeReturn(bool Status)
        {
            string txt = string.Empty;

            if (Convert.ToBoolean(Status))
            {
                txt = "Returned";
            }

            return txt;
        }

        public static string GetDocumentIcon(string URL)
        {
            string Extension = Path.GetExtension(URL);

            if (Extension.ToLower() == ".txt")
                return CSSClass.TXTIcon;
            else if (Extension.ToLower() == ".pdf")
                return CSSClass.PDFIcon;
            else if (Extension.ToLower() == ".doc" || Extension.ToLower() == ".docx")
                return CSSClass.WordIcon;
            else if (Extension.ToLower() == ".xls" || Extension.ToLower() == ".xlsx" || Extension.ToLower() == ".xlsm" || Extension.ToLower() == ".csv")
                return CSSClass.ExcelIcon;
            else if (Extension.ToLower() == ".jpg" || Extension.ToLower() == ".jpeg" || Extension.ToLower() == ".png" || Extension.ToLower() == ".gif")
                return CSSClass.ImageIcon;
            else
                return CSSClass.DownloadIcon;
        }

        public static string GetFloorName(int Floor)
        {
            string FloorName = string.Empty;

            if (Floor == 0)
            {
                FloorName = "Ground Floor";
            }
            else if (Floor == 1)
            {
                FloorName = "First Floor";
            }
            else if (Floor == 2)
            {
                FloorName = "Second Floor";
            }
            else if (Floor == 3)
            {
                FloorName = "Third Floor";
            }
            else if (Floor == 4)
            {
                FloorName = "Fourth Floor";
            }
            else if (Floor == 5)
            {
                FloorName = "Fifth Floor";
            }

            return FloorName;
        }

        public static string GetImageByURL(string URL)
        {
            var filePath = HttpContext.Current.Server.MapPath(URL);
            var dataUrl = string.Empty;
            if (File.Exists(filePath))
            {
                var bytes = File.ReadAllBytes(filePath);
                var b64String = Convert.ToBase64String(bytes);
                dataUrl = "data:image/png;base64," + b64String;
            }
            return dataUrl;
        }

        #endregion Other

        #region Validation

        public static String IsValidPhoto(FileUpload fu, String ImageName)
        {
            string extension = System.IO.Path.GetExtension(fu.PostedFile.FileName);
            string[] validFileTypes = CV.validImageFileTypes;
            String Message = String.Empty;
            bool IsValid = false;

            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (extension.ToLower() == "." + validFileTypes[i])
                {
                    IsValid = true;
                    break;
                }
            }

            if (IsValid)
            {
                Bitmap img = new Bitmap(fu.PostedFile.InputStream, false);
                int height = img.Height;
                int width = img.Width;
                int fileSize = (fu.PostedFile.ContentLength) / 1024;

                //double MinRatio = 0.98;
                //double MaxRatio = 1.02;

                double MinRatio = 0.73;
                double MaxRatio = 1.80;
                double ratio = (double)width / (double)height;

                /*
                if (height > CV.MaxPhotoHeightInPX || width > CV.MaxPhotoWidthInPX || fileSize > CV.MaxPhotoSizeInKB)
                    IsValid = false;

                if (!IsValid)
                  Message = ImageName + " size not be greater than " + CV.MaxPhotoSizeInKB + "KB, " + CV.MaxPhotoWidthInPX.ToString() + " X " + CV.MaxPhotoHeightInPX.ToString() + "px";

                  */

                if (ratio < MinRatio || ratio > MaxRatio || fileSize > CV.MaxPhotoSizeInKB)
                    IsValid = false;

                if (!IsValid)
                    Message = ImageName + " size not be greater than " + CV.MaxPhotoSizeInKB + "KB, " + CV.MaxPhotoWidthInPX.ToString() + " X " + CV.MaxPhotoHeightInPX.ToString() + "px";

            }
            else
                Message = ImageName + " extension must be (" + String.Join(" or ", validFileTypes) + ")";

            return Message;
        }

        public static bool CheckImageType(string FileExtension, int FileSize)
        {
            string[] validFileTypes = CV.validImageFileTypes;
            bool result = false;

            if (FileSize < CV.MaxAllowedFileSize)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public static bool CheckFileType(string FileExtension, int FileSize)
        {
            return CheckFileType(FileExtension, FileSize, "Medimum");
        }

        public static bool CheckFileType(string FileExtension, int FileSize, String FileSizeType)
        {
            string[] validFileTypes = CV.validFileTypes;

            bool result = false;

            if (FileSize < CV.MaxAllowedFileSize)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;

        }

        public static bool CheckFileType(string FileExtension, int FileSize, int MaxAllowedSize)
        {
            string[] validFileTypes = CV.validFileTypes;

            bool result = false;

            if (FileSize < MaxAllowedSize)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;

        }

        public static bool CheckPDFFileType(string FileExtension, int FileSize)
        {
            string[] validFileTypes = { "pdf" };
            bool result = false;

            if (FileSize < 5242880)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;

        }

        public static bool CheckWordFileType(string FileExtension, int FileSize)
        {
            string[] validFileTypes = { "doc", "docx" };
            bool result = false;

            if (FileSize < 5242880)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public static bool CheckWordPDFFileType(string FileExtension, int FileSize)
        {
            string[] validFileTypes = { "doc", "docx", "pdf" };
            bool result = false;

            if (FileSize < 5242880)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public static bool CheckExcelFileType(string FileExtension, int FileSize)
        {
            string[] validFileTypes = CV.validOnlyExcelFileTypes;
            bool result = false;

            if (FileSize < 5242880)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public static bool CheckHTMLFileType(string FileExtension, int FileSize)
        {
            string[] validFileTypes = { "html", "htm" };
            bool result = false;

            if (FileSize < 5242880)
            {
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (FileExtension.ToLower() == "." + validFileTypes[i])
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public static bool ValidateFromDateToDate(DateTime FromDate, DateTime ToDate)
        {
            bool result = false;

            if (FromDate <= ToDate)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static void SetIcon(HtmlControl Control, String URL)
        {
            string Extension = Path.GetExtension(URL);
            if (Extension.ToLower() == ".txt")
                Control.Attributes.Add("class", CSSClass.TXTIcon);
            else if (Extension.ToLower() == ".pdf")
                Control.Attributes.Add("class", CSSClass.PDFIcon);
            else if (Extension.ToLower() == ".doc" || Extension.ToLower() == ".docx")
                Control.Attributes.Add("class", CSSClass.WordIcon);
            else if (Extension.ToLower() == ".xls" || Extension.ToLower() == ".xlsx" || Extension.ToLower() == ".xlsm" || Extension.ToLower() == ".csv")
                Control.Attributes.Add("class", CSSClass.ExcelIcon);
            else if (Extension.ToLower() == ".jpg" || Extension.ToLower() == ".jpeg" || Extension.ToLower() == ".png" || Extension.ToLower() == ".gif" || Extension.ToLower() == ".bmp")
                Control.Attributes.Add("class", CSSClass.ImageIcon);
            else
                Control.Attributes.Add("class", CSSClass.DownloadIcon);
        }

        #region Exam Module

        public static bool IsValidExamSessionTime(DateTime ExamTime, String ExamSession)
        {
            String AMPM = ExamTime.ToString("tt", CultureInfo.InvariantCulture);
            //private static readonly TimeSpan FromTime = new TimeSpan(16,25,00);

            //internal static bool IsTimeOver()
            //{
            //    return DateTime.Now.TimeOfDay.Subtract(_whenTimeIsOver ).Ticks > 0; 
            //}

            //if (ExamSession == "Morning" && AMPM != "AM")
            //{
            //    return false;
            //}
            //else if (ExamSession == "Evening" && AMPM != "PM")
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}

            return true;
        }

        #endregion Exam Module

        #endregion Validation

        #region System Function
        public static String GetSystemURL()
        {
            return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + GNForm3C.CV.AppendForMenu;
        }
        public static void BindEmptyRepeater(Repeater rp)
        {
            rp.DataSource = null;
            rp.DataBind();
        }

        public static void BindEmptyGrid(GridView gv)
        {
            gv.DataSource = null;
            gv.DataBind();
        }

        public static void SetFocusWithoutScroll(Control c)
        {
            string script = string.Format("$('#{0}').focus();", c.ClientID);
            ScriptManager.RegisterStartupScript(c, c.GetType(), "SetFocus", script, true);
        }

        #region Scroll To Top
        public static void ScrollToTop(Page MyPage)
        {
            ScriptManager.RegisterStartupScript(MyPage, MyPage.GetType(), "Javascript", "javascript:ScrolltoTop(); ", true);
        }

        #endregion Scroll To Top

        public static Font DeserializeFont(String font)
        {
            //Fontƒ[Font: Name=Microsoft Sans Serif, Size=8.25, Units=3, GdiCharSet=0, GdiVerticalFont=False]
            String ValueName = font;
            String FontName = ValueName.Substring(ValueName.IndexOf("Name=") + 5, ValueName.IndexOf(",") - ValueName.IndexOf("Name=") - 5);
            ValueName = ValueName.Substring(ValueName.IndexOf(",") + 1);
            String FontSize = ValueName.Substring(ValueName.IndexOf("Size=") + 5, ValueName.IndexOf(",") - ValueName.IndexOf("Size=") - 5);
            ValueName = ValueName.Substring(ValueName.IndexOf(",") + 1);
            String FontUnits = ValueName.Substring(ValueName.IndexOf("Units=") + 6, ValueName.IndexOf(",") - ValueName.IndexOf("Units=") - 6);
            ValueName = ValueName.Substring(ValueName.IndexOf(",") + 1);
            String FontGdiCharSet = ValueName.Substring(ValueName.IndexOf("GdiCharSet=") + 11, ValueName.IndexOf(",") - ValueName.IndexOf("GdiCharSet=") - 11);
            ValueName = ValueName.Substring(ValueName.IndexOf(",") + 1);
            String FontGdiVerticalFont = ValueName.Substring(ValueName.IndexOf("GdiVerticalFont=") + 16, ValueName.IndexOf(",") - ValueName.IndexOf("GdiVerticalFont=") - 16);
            ValueName = ValueName.Substring(ValueName.IndexOf(",") + 1);
            String strFontStyle = ValueName.Substring(ValueName.IndexOf("FontStyle=") + 10, ValueName.IndexOf("]") - ValueName.IndexOf("FontStyle=") - 10);
            ValueName = ValueName.Substring(ValueName.IndexOf(",") + 1);

            return new Font(FontName, (float)Convert.ToDecimal(FontSize), GetFontStyle(strFontStyle), NumToEnum<GraphicsUnit>(Convert.ToInt32(FontUnits)), Convert.ToByte(FontGdiCharSet), Convert.ToBoolean(FontGdiVerticalFont));
        }

        #endregion System Function

        #region GetFontStyle
        public static FontStyle GetFontStyle(String _FontStyle)
        {
            FontStyle f = new FontStyle();
            if (_FontStyle.Contains("Bold"))
                f = FontStyle.Bold;
            if (_FontStyle.Contains("Italic"))
                f = f | FontStyle.Italic;
            if (_FontStyle.Contains("Underline"))
                f = f | FontStyle.Underline;
            return f;
        }
        public FontStyle GetFontStyle(Boolean IsBold, Boolean IsItalic, Boolean IsUnderline)
        {
            FontStyle fs = new FontStyle();
            if (IsBold)
                fs |= FontStyle.Bold;
            if (IsItalic)
                fs |= FontStyle.Italic;
            if (IsUnderline)
                fs |= FontStyle.Underline;

            return fs;
        }


        public static T NumToEnum<T>(int number)
        {
            return (T)Enum.ToObject(typeof(T), number);
        }
        #endregion GetFontStyle

        #region FillDropDownList

        
        #region Master

        public static void FillDropDownListAdmissionYear(DropDownList ddl)
        {
            // Replace 2000 to Desired Starting Year
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Select Year", "-99"));
            for (int i = DateTime.Now.Year + 1; i >= 2008; i--)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            //ddl.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
        }

        public static void FillDropDownListFromDateToDate(DropDownList ddl, DateTime FromDate, DateTime ToDate)
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Select Date", "-99"));
            for (DateTime i = FromDate; i <= ToDate; i = i.AddDays(1))
            {
                ddl.Items.Add(new ListItem(i.ToString("dd-MM-yyyy"), i.ToString("dd-MM-yyyy")));
            }
        }

        #endregion Master

        public static void FillDropDownListBlank(DropDownList ddl, String DropDownName)
        {
            ddl.Items.Clear();
            ddl.ClearSelection();
            ddl.DataSource = null;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem(" Select " + DropDownName, "-99"));
        }

    
        public static void FillDropDownListYear(DropDownList ddl)
        {
            // Replace 2000 to Desired Starting Year
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Select Year", "-99"));
            for (int i = DateTime.Now.Year; i >= 1970; i--)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            //ddl.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
        }

        public static void FillDropDownListYearFromMISStart(DropDownList ddl)
        {
            // Replace 2000 to Desired Starting Year
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Select Year", "-99"));
            for (int i = DateTime.Now.Year + 1; i >= 2015; i--)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            //ddl.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
        }

        public static void FillDropDownListMonth(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Select Month", "-99"));
            for (int i = 1; i <= 12; i++)
            {
                string monthName = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(i);
                ddl.Items.Add(new ListItem(i.ToString() + "-" + monthName, i.ToString()));
            }
        }
        public static void FillDropDownListDateByDayNoMonthYear(DropDownList ddl, Int32 YearNo, Int32 MonthNo, String DayName)
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Select Date", "-99"));
            CultureInfo ci = new CultureInfo("en-US");
            for (int i = 1; i <= ci.Calendar.GetDaysInMonth(YearNo, MonthNo); i++)
            {
                DateTime Date = new DateTime(YearNo, MonthNo, i);
                if (Date.DayOfWeek == GetDayOfWeekByDayName(DayName))
                    ddl.Items.Add(new ListItem(new DateTime(YearNo, MonthNo, i).ToString(CV.DefaultDateFormat), new DateTime(YearNo, MonthNo, i).ToString(CV.DefaultDateFormat)));
            }
        }

        public static DataTable GetDateByDayNoMonthYear(Int32 YearNo, Int32 MonthNo, String DayName)
        {
            DataTable dtDate = new DataTable();
            dtDate.Columns.Add("MonthDate", typeof(DateTime));

            CultureInfo ci = new CultureInfo("en-US");
            for (int i = 1; i <= ci.Calendar.GetDaysInMonth(YearNo, MonthNo); i++)
            {
                DataRow dr = dtDate.NewRow();
                DateTime Date = new DateTime(YearNo, MonthNo, i);
                if (Date.DayOfWeek == GetDayOfWeekByDayName(DayName))
                {
                    dr["MonthDate"] = Date.ToString();
                    dtDate.Rows.Add(dr);
                }
            }
            return dtDate;
        }

        public static DayOfWeek GetDayOfWeekByDayName(String DayName)
        {
            if (DayName == "Sunday")
                return DayOfWeek.Sunday;
            else if (DayName == "Monday")
                return DayOfWeek.Monday;
            else if (DayName == "Tuesday")
                return DayOfWeek.Tuesday;
            else if (DayName == "Wednesday")
                return DayOfWeek.Wednesday;
            else if (DayName == "Thursday")
                return DayOfWeek.Thursday;
            else if (DayName == "Friday")
                return DayOfWeek.Friday;
            else
                return DayOfWeek.Saturday;
        }

        public static void FillDropDownListDayOfWeek(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("Select Day Name", "-99"));
            ddl.Items.Insert(1, new ListItem("Sunday", "Sunday"));
            ddl.Items.Insert(2, new ListItem("Monday", "Monday"));
            ddl.Items.Insert(3, new ListItem("Tuesday", "Tuesday"));
            ddl.Items.Insert(4, new ListItem("Wednesday", "Wednesday"));
            ddl.Items.Insert(5, new ListItem("Thursday", "Thursday"));
            ddl.Items.Insert(6, new ListItem("Friday", "Friday"));
            ddl.Items.Insert(7, new ListItem("Saturday", "Saturday"));
        }

        public static void FillDropDownListMonthInt(DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("Select No of Month", "-99"));
            for (int i = 1; i <= 11; i++)
            {
                ddl.Items.Add(new ListItem(i.ToString() + " Month", i.ToString()));
            }
        }


        #endregion FillDropDownList

        #region Generate Password
        public static string GenerateOTP(int length)
        {
            //string allowedLetterChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
            string allowedNumberChars = "23456789";
            char[] chars = new char[length];
            Random rd = new Random();

            bool useLetter = true;
            for (int i = 0; i < length; i++)
            {
                //if (useLetter)
                //{
                //    chars[i] = allowedLetterChars[rd.Next(0, allowedLetterChars.Length)];
                //    useLetter = false;
                //}
                //else
                //{
                //    chars[i] = allowedNumberChars[rd.Next(0, allowedNumberChars.Length)];
                //    useLetter = true;
                //}
                chars[i] = allowedNumberChars[rd.Next(0, allowedNumberChars.Length)];
                useLetter = true;

            }

            return new string(chars);
        }

        public static string GenerateRandomPassword()
        {
            int length = 5;
            //string allowedLetterChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
            string allowedNumberChars = "23456789";
            char[] chars = new char[length];
            Random rd = new Random();

            bool useLetter = true;
            for (int i = 0; i < length; i++)
            {
                //if (useLetter)
                //{
                //    chars[i] = allowedLetterChars[rd.Next(0, allowedLetterChars.Length)];
                //    useLetter = false;
                //}
                //else
                //{
                //    chars[i] = allowedNumberChars[rd.Next(0, allowedNumberChars.Length)];
                //    useLetter = true;
                //}
                chars[i] = allowedNumberChars[rd.Next(0, allowedNumberChars.Length)];
                useLetter = true;

            }

            return new string(chars);
        }

        #endregion Generate Password

        #region Send Email

        public static Boolean SendEmail(MailMessage mm, SqlInt32 EmailTemplateID, SqlString strParameters)
        {
            try
            {
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static Boolean SendEmail(MailMessage mm, SqlInt32 EmailTemplateID, SqlString strParameters, SqlString FromEmail)
        {
            

            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion Send Email

        #region Send SMS
        public static bool SendSMS(String MobileNo, String SMSText, ref String ResponseString)
        {
            try
            {
               

                return true;

            }
            catch (Exception ex)
            {
                SaveErrorToDb(ex);
                return false;
            }
        }

        public static bool SendSMS(String MobileNo, String SMSText, ref String ResponseString, String SMSType, String ModuleName, String ScreenName)
        {
            try
            {
               

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion Send SMS

        #region Error Log

        public static void SaveErrorToDb(Exception ex)
        {

          
        }

                public static void Error(string message)
        {
           
            return;
        }

        #endregion Error Log

        #region Security

        public static Boolean IsHeavyOperationAllowed()
        {
            DateTime FromDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0);
            DateTime ToDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 30, 0);

            if (DateTime.Now > FromDateTime && DateTime.Now < ToDateTime)
                return false;
            else
                return true;
        }

        public static string GetClientIP()
        {
          
            return HttpContext.Current.Request.UserHostAddress;
        }

        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;


        }

        public static string GetOS(String UserAgent)
        {
            String OsName = UserAgent;
            if (UserAgent.IndexOf("Windows NT 6.3") > 0)
                OsName = "Windows 8.1";
            else if (UserAgent.IndexOf("Windows NT 6.2") > 0)
                OsName = "Windows 8";
            else if (UserAgent.IndexOf("Windows NT 6.1") > 0)
                OsName = "Windows 7";
            else if (UserAgent.IndexOf("Windows NT 6.0") > 0)
                OsName = "Windows Vista";
            else if (UserAgent.IndexOf("Windows NT 5.2") > 0)
                OsName = "Windows Server 2003; Windows XP x64 Edition";
            else if (UserAgent.IndexOf("Windows NT 5.1") > 0)
                OsName = "Windows XP";
            else if (UserAgent.IndexOf("Windows NT 5.01") > 0)
                OsName = "Windows 2000, Service Pack 1 (SP1)";
            else if (UserAgent.IndexOf("Windows NT 5.0") > 0)
                OsName = "Windows 2000";
            else if (UserAgent.IndexOf("Windows NT 4.0") > 0)
                OsName = "Microsoft Windows NT 4.0";
            else if (UserAgent.IndexOf("Win 9x 4.90") > 0)
                OsName = "Windows Millennium Edition (Windows Me)";
            else if (UserAgent.IndexOf("Windows 98") > 0)
                OsName = "Windows 98";
            else if (UserAgent.IndexOf("Windows 95") > 0)
                OsName = "Windows 95";
            else if (UserAgent.IndexOf("Windows CE") > 0)
                OsName = "Windows CE";

            return OsName;

        }


        public static Boolean IsUserValidToAccessPage(String FormName)
        {
            if (HttpContext.Current.Session["UserID"] == null || HttpContext.Current.Session["StudentID"] != null)
                return false;
            else
                return true;
        }

        public static Boolean IsAllowedForOperation(String FormName, String PageClassName, out Boolean IsAdd, out Boolean IsEdit, out Boolean IsDelete, out Boolean IsExport, out Boolean IsPrint, out String PageHelpText, out String PageImportantNote)
        {
            IsAdd = false;
            IsEdit = false;
            IsDelete = false;
            IsExport = false;
            IsPrint = false;
            PageHelpText = String.Empty;
            PageImportantNote = String.Empty;

            if (HttpContext.Current.Session["UserID"] == null)
                return false;
            else
                return true;

        }


        public static void CheckListPageRight(Repeater rp, Boolean IsEdit, Boolean IsDelete, Boolean Export)
        {
            foreach (RepeaterItem item in rp.Items)
            {
                HyperLink hlEdit = (HyperLink)item.FindControl("hlEdit");
                LinkButton lbtnDelete = (LinkButton)item.FindControl("lbtnDelete");

                if (hlEdit != null)
                {
                    if (IsEdit && hlEdit.Visible == true)
                        hlEdit.Visible = true;
                    else
                        hlEdit.Visible = false;
                }

                if (lbtnDelete != null)
                {
                    if (IsDelete && lbtnDelete.Visible == true)
                        lbtnDelete.Visible = true;
                    else
                        lbtnDelete.Visible = false;
                }
            }
        }


        public static Boolean IsLocked(SqlString LockLevel)
        {
            if (LockLevel.Value != String.Empty)
                return true;
            else
                return false;
        }

        #endregion Security

        #region Common
        public static void ImageResize(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                var newWidth = (int)(image.Width * scaleFactor);
                var newHeight = (int)(image.Height * scaleFactor);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }

        public static void ImageResizeHeightWidth(int Height, int Width, Stream sourcePath, string targetPath)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                var newWidth = Width;
                var newHeight = Height;
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }

        public static string GetInRuppe(String Amount)
        {
            String Amt = "";
            if (Amount != String.Empty)
            {
                decimal parsed = decimal.Parse(Amount, CultureInfo.InvariantCulture);
                CultureInfo hindi = new CultureInfo("hi-IN");
                Amt = string.Format(hindi, "{0:c}", parsed);
            }
            return Amt;
        }


        public static string ToOrdinal(Int32 i, SqlString word)
        {
            string suffix = "<sup>th</sup>";
            string final = "";
            if (word != "")
            {
                switch (i % 100)
                {
                    case 11:
                    case 12:
                    case 13:
                        break;
                    default:
                        switch (i % 10)
                        {
                            case 1:
                                suffix = "<sup>st</sup>";
                                break;
                            case 2:
                                suffix = "<sup>nd</sup>";
                                break;
                            case 3:
                                suffix = "<sup>rd</sup>";
                                break;
                        }
                        break;
                }
                final = i.ToString() + suffix + " " + word.ToString();
            }
            return final;
        }


        public static string MinutesTo12HourFormat(Int32 Minutes)
        {
            return (Convert.ToDateTime(TimeSpan.FromMinutes(Convert.ToInt32(Minutes)).Hours + ":" + TimeSpan.FromMinutes(Convert.ToInt32(Minutes)).Minutes)).ToString("hh:mm tt");
        }

        public static Int32 HourFormatsToMinutes(String HourFormat)
        {
            //HourFormat is as per dtpTimeSelector of the theme: eg. 12:20 AM
            return Convert.ToInt32(DateTime.Parse(HourFormat).Hour) * 60 + Convert.ToInt32(DateTime.Parse(HourFormat).Minute);
        }

    

        #endregion Common

      

        


        #region Get CSS Class

        public static String GetCssClassForExamTimeLineStatus(String Status)
        {
            String CssClass = String.Empty;

            if (Status == "Time Over")
                CssClass = CSSClass.badgedanger;
            else
                CssClass = CSSClass.badgeinfo;

            return CssClass;
        }

        public static String GetCssClassForLockUnlock(Boolean IsLocked)
        {
            String CssClass = String.Empty;

            if (IsLocked == true)
                CssClass = CSSClass.btnLock;
            else
                CssClass = CSSClass.btnUnlock;

            return CssClass;
        }


        public static string GetTrueFalseCssClass(Boolean value)
        {
            if (value)
                return CSSClass.True;
            else
                return CSSClass.False;
        }

      

        public static string GetPendingCountCssClass(Int32 Count)
        {
            if (Count == 0)
                return CSSClass.bgtdSuccess;
            else
                return CSSClass.bgtddanger;
        }

        public static string GetRedGreenFont(Boolean value)
        {
            if (value)
                return CSSClass.FontGreen;
            else
                return CSSClass.FontRed;
        }
        #endregion Get CSS Class

       


        #region Document
        public static Boolean UploadDocument(FileUpload fu, String DirectoryPath, String NewPath, String OldPath)
        {
            #region Upload Document
            if (fu.HasFile && NewPath != String.Empty)
            {
                #region Create File Path

                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }

                #endregion Create File Path

                #region Upload File

                fu.SaveAs(NewPath);

                #endregion Upload File
            }
            #endregion Upload Document

            return true;
        }

        public static void DownloadDocument(String Path, String FileName)
        {
            #region Download Document

            if (File.Exists(Path))
            {
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + FileName + "\"");
                byte[] data = req.DownloadData(Path);
                response.BinaryWrite(data);
                response.End();
            }

            #endregion Download Document
        }

        #endregion Document

        #region Pending

        public static string TruncateString(string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + " ..";
        }

        public static DateTime GetGNForm3CDateTime()
        {
            return DateTime.Now.Date;
        }

        public static DataTable DataTableRemoveReadOnlyProperty(DataTable dt)
        {
            foreach (DataColumn dc in dt.Columns)
            {
                dc.ReadOnly = false;
                dc.AllowDBNull = true;
            }
            return dt;
        }

        #endregion Pending

        #region Import/Export

        public static DataTable ImportExcelToDataTable(string FilePath, string Extension, Boolean hasHDR)
        {
            try
            {
                string conStr = "";
                string isHDR = "";

                if (hasHDR)
                    isHDR = "Yes";
                else
                    isHDR = "No";

                switch (Extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                                 .ConnectionString;
                        break;
                    case ".xlsx": //Excel 07
                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                                  .ConnectionString;
                        break;
                }
                conStr = String.Format(conStr, FilePath, isHDR);
                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                cmdExcel.Connection = connExcel;

                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet
                connExcel.Open();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                oda.SelectCommand = cmdExcel;
                oda.Fill(dt);
                connExcel.Close();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void ExportDataTableToExcel(DataTable dt, String FileName)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", FileName + ".xls"));

            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");

            HttpContext.Current.Response.Write("<style>TD { mso-number-format:\\@; white-space: nowrap; } </style>");

            HttpContext.Current.Response.Write("<Table border='1'" +
              "borderColor='#000000' cellSpacing='0' cellPadding='0'><TR>");
            int columnscount = dt.Columns.Count;

            for (int j = 0; j < columnscount; j++)
            {
                HttpContext.Current.Response.Write("<Td>");
                HttpContext.Current.Response.Write(dt.Columns[j].ColumnName.ToString());
                HttpContext.Current.Response.Write("</Td>");
            }
            HttpContext.Current.Response.Write("</TR>");
            foreach (DataRow row in dt.Rows)
            {//write in new row
                HttpContext.Current.Response.Write("<TR>");
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(row[i].ToString());
                    HttpContext.Current.Response.Write("</Td>");
                }

                HttpContext.Current.Response.Write("</TR>");
            }
            HttpContext.Current.Response.Write("</Table>");
            //HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        public static String ConvertDataTableToCSVString(DataTable dt)
        {
            StringBuilder sbExcel = new StringBuilder();
            foreach (DataColumn col in dt.Columns)
            {
                sbExcel.Append(col.ColumnName + ',');
            }
            sbExcel.Remove(sbExcel.Length - 1, 1);
            sbExcel.Append(Environment.NewLine);
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sbExcel.Append(row[i].ToString() + ",");
                }

                sbExcel.Append(Environment.NewLine);
            }

            return sbExcel.ToString();
        }

        public static void ExportDataTableToCSVFile(DataTable dtTable, String FileName)
        {
            StringBuilder sbldr = new StringBuilder();
            if (dtTable.Columns.Count != 0)
            {
                foreach (DataColumn col in dtTable.Columns)
                {
                    sbldr.Append(col.ColumnName + ',');
                }
                sbldr.Append("\r\n");
                foreach (DataRow row in dtTable.Rows)
                {
                    foreach (DataColumn column in dtTable.Columns)
                    {
                        sbldr.Append(row[column].ToString() + ',');
                    }
                    sbldr.Append("\r\n");
                }
            }

            HttpContext.Current.Response.ContentType = "Application/x-msexcel";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".csv");
            HttpContext.Current.Response.Write(sbldr.ToString());
            HttpContext.Current.Response.End();
        }

        public static void ExportDataTableToCSVFilePipeline(DataTable dtTable, String FileName)
        {
            StringBuilder sbldr = new StringBuilder();
            if (dtTable.Columns.Count != 0)
            {
                foreach (DataColumn col in dtTable.Columns)
                {
                    sbldr.Append(col.ColumnName + '|');
                }
                sbldr.Append("\r\n");
                foreach (DataRow row in dtTable.Rows)
                {
                    foreach (DataColumn column in dtTable.Columns)
                    {
                        sbldr.Append(row[column].ToString() + '|');
                    }
                    sbldr.Append("\r\n");
                }
            }

            HttpContext.Current.Response.ContentType = "Application/x-msexcel";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".csv");
            HttpContext.Current.Response.Write(sbldr.ToString());
            HttpContext.Current.Response.End();
        }

        public static void ExportDataTableToTXTFilePipeline(DataTable dtTable, String FileName)
        {
            StringBuilder sbldr = new StringBuilder();
            if (dtTable.Columns.Count != 0)
            {
                foreach (DataColumn col in dtTable.Columns)
                {
                    sbldr.Append(col.ColumnName + '|');
                }
                sbldr.Append("\r\n");
                foreach (DataRow row in dtTable.Rows)
                {
                    foreach (DataColumn column in dtTable.Columns)
                    {
                        sbldr.Append(row[column].ToString() + '|');
                    }
                    sbldr.Append("\r\n");
                }
            }

            HttpContext.Current.Response.ContentType = "Application/x-msexcel";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".txt");
            HttpContext.Current.Response.Write(sbldr.ToString());
            HttpContext.Current.Response.End();
        }

        #endregion Import/Export

        #region Conversion

        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900); //EDIT: i've typed 400 instead 900
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
        }
        public static string ConvertDatatableToXML(DataTable dt)
        {
            MemoryStream str = new MemoryStream();
            dt.WriteXml(str, true);
            str.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(str);
            string xmlstr;
            xmlstr = sr.ReadToEnd();
            return (xmlstr);
        }

        public static string ConvertDatatableToXML_New(DataTable dt)
        {
            String xmlData = String.Empty;

            foreach (DataRow dr in dt.Rows)
            {
                xmlData += "<" + dt.TableName.ToString() + ">\r\n";
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.DataType.Name == "DateTime" && dr[dc.ColumnName.ToString()].ToString().Trim() != String.Empty)
                        xmlData += "<" + dc.ColumnName.ToString() + ">" + Convert.ToDateTime(dr[dc.ColumnName.ToString()].ToString()).ToString("yyyy-MM-dd hh:mm:ss") + "</" + dc.ColumnName.ToString() + ">\r\n";
                    else if (dr[dc.ColumnName.ToString()].ToString() != String.Empty)
                        xmlData += "<" + dc.ColumnName.ToString() + ">" + dr[dc.ColumnName.ToString()].ToString() + "</" + dc.ColumnName.ToString() + ">\r\n";
                    else
                        xmlData += "<" + dc.ColumnName.ToString() + "></" + dc.ColumnName.ToString() + ">\r\n";
                }
                xmlData += "</" + dt.TableName.ToString() + ">\r\n";
            }
            return xmlData;
        }

        #endregion Conversion

        

      

    }
}