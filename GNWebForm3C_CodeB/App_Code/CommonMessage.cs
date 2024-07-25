using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GNForm3C
{
    public class CommonMessage
    {
        #region Constructor
        public CommonMessage()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Error Message
        public static string ErrorRequiredField(string FieldName)
        {
            return "Enter " + FieldName;
        }

        public static string ErrorRequiredFieldDDL(string FieldName)
        {
            return "Select " + FieldName;
        }

        public static string ErrorDuplicateFiled(string TableName)
        {
            return TableName + " for given data already exists.";
        }
        public static string ErrorDuplicateFiled(string TableName,String FieldName)
        {
            return TableName + " for <b>" + FieldName + "</b> already exists.";
        }
        public static string ErrorInvalidFile(string FieldName)
        {
            return "Invalid " + FieldName + " Type or Size  in Attachment";
        }

        public static string ErrorPleaseCorrectFollowing()
        {
            return "Please Correct Following Errors <br/>";
        }
        public static string ErrorPleaseSelectAtLeastOneItem(string ItemName)
        {
            return "Select at least one " + ItemName;
        }

        public static string NoRecordFound()
        {
            return "No Record Found";
        }

        public static string NullDataMessage(String Param)
        {
            return "NullDataMessage";
        }

        public static string ErrorInvalidField(string FieldName)
        {
            return "Invalid " + FieldName;
        }

        public static string ErrorLockedRecordEdit(string FieldName)
        {
            return FieldName + " is locked hence you cannot change.";
        }

        public static string ErrorLockedRecordEdit(string Table,string FieldName)
        {
            return "<b>" + FieldName + "</b> " + Table + " is locked hence you cannot change.";
        }
        public static string ErrorLockedRecordDelete(string FieldName)
        {
            return FieldName + " is locked hence you cannot delete.";
        }
        #endregion Error Message

        #region Record Save, Delete, Update

        public static string RecordSavedAs(String Table, String FieldName, String ForFieldName)
        {
            return "<b>" + FieldName + "</b> Saved Successfully as " + Table + " for <b>" + ForFieldName + "</b>.";
        }

        public static string RecordSaved(String Table, String FieldName, String ForFieldName)
        {
            return "<b>" + FieldName + "</b> " + Table + " for <b>" + ForFieldName + "</b> Saved Successfully";
        }

        public static string RecordSaved(String Table, String FieldName)
        {
            return "<b>" + FieldName + "</b> " + Table + " Saved Successfully";
        }
        public static string RecordSaved(String RecordValue)
        {
            return "<b>" + RecordValue + "</b> Saved Successfully";
        }
        public static string RecordSaved()
        {
            return "Record Saved Successfully";
        }

        public static string DeletedRecord()
        {
            return "Record Deleted Successfully";
        }
        public static string RecordUpdated()
        {
            return "Details Updated Successfully";
        }
        #endregion Record Save, Delete, Update

        #region Pagination Message
        public static string PageDisplayMessage(int Offset, int CurrentRowCount, int TotalRecords, int PageNo, int TotalPages)
        {
            return "(Showing <strong>" + (Offset + 1).ToString() + "</strong> to <strong>" + (CurrentRowCount + Offset).ToString() + "</strong> of <strong>" + TotalRecords + "</strong> records" + ", Page : <strong>" + PageNo + "</strong> of <strong>" + TotalPages + "</strong>)";
        }
        #endregion Pagination Message

        public static string ContactSystemAdministrator()
        {
            return " To make changes to this page, contact your system administrator.";
        }


        public static string FromDate_LessThan_ToDate()
        {
            return " From Date must be less than To Date ";
        }
        public static string ToDate_GreaterThan_FromDate()
        {
            return " To Date must be greater than From Date ";
        }
    }
}