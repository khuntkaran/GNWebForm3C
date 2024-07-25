using GNForm3C.DAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EMP_EmployeeDetailBALBase
/// </summary>
/// 
namespace GNForm3C.BAL
{
    public abstract class EMP_EmployeeDetailBALBase
    {
        #region Private Fields

        private string _Message;

        #endregion Private Fields

        #region Public Properties

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Public Properties

        #region Constructor
        public EMP_EmployeeDetailBALBase()
        {
           
        }
        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(EMP_EmployeeDetailENT entEMP_EmployeeDetail)
        {
            EMP_EmployeeDetailDAL dalEMP_EmployeeDetail = new EMP_EmployeeDetailDAL();
            if (dalEMP_EmployeeDetail.Insert(entEMP_EmployeeDetail))
            {
                return true;
            }
            else
            {
                this.Message = dalEMP_EmployeeDetail.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(EMP_EmployeeDetailENT entEMP_EmployeeDetail)
        {
            EMP_EmployeeDetailDAL dalEMP_EmployeeDetail = new EMP_EmployeeDetailDAL();
            if (dalEMP_EmployeeDetail.Update(entEMP_EmployeeDetail))
            {
                return true;
            }
            else
            {
                this.Message = dalEMP_EmployeeDetail.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 EmployeeID)
        {
            EMP_EmployeeDetailDAL dalEMP_EmployeeDetail = new EMP_EmployeeDetailDAL();
            if (dalEMP_EmployeeDetail.Delete(EmployeeID))
            {
                return true;
            }
            else
            {
                this.Message = dalEMP_EmployeeDetail.Message;
                return false;
            }
        }

        #endregion DeleteOperationa

        #region SelectOperation

        public EMP_EmployeeDetailENT SelectPK(SqlInt32 EmployeeID)
        {
            EMP_EmployeeDetailDAL dalEMP_EmployeeDetail = new EMP_EmployeeDetailDAL();
            return dalEMP_EmployeeDetail.SelectPK(EmployeeID);
        }

        public DataTable SelectView(SqlInt32 EmployeeID)
        {
            EMP_EmployeeDetailDAL dalEMP_EmployeeDetail = new EMP_EmployeeDetailDAL();
            return dalEMP_EmployeeDetail.SelectView(EmployeeID);
        }
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString EmployeeName, SqlInt32 EmployeeTypeID)
        {
            EMP_EmployeeDetailDAL dalEMP_EmployeeDetail = new EMP_EmployeeDetailDAL();
            return dalEMP_EmployeeDetail.SelectPage(PageOffset, PageSize, out TotalRecords, EmployeeName, EmployeeTypeID);
        }

        public DataTable SelectShow(SqlInt32 EmployeeTypeID)
        {
            EMP_EmployeeDetailDAL dalEMP_EmployeeDetail = new EMP_EmployeeDetailDAL();
            return dalEMP_EmployeeDetail.SelectShow(EmployeeTypeID);
        }

        #endregion SelectOperation
    }
}