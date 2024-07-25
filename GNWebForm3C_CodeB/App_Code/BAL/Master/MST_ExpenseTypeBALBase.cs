using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using GNForm3C;
using GNForm3C.DAL;
using GNForm3C.ENT;

namespace GNForm3C.BAL
{
	public abstract class MST_ExpenseTypeBALBase
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

		public MST_ExpenseTypeBALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(MST_ExpenseTypeENT entMST_ExpenseType)
		{
			MST_ExpenseTypeDAL dalMST_ExpenseType = new MST_ExpenseTypeDAL();
			if(dalMST_ExpenseType.Insert(entMST_ExpenseType))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_ExpenseType.Message;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

		public Boolean Update(MST_ExpenseTypeENT entMST_ExpenseType)
		{
			MST_ExpenseTypeDAL dalMST_ExpenseType = new MST_ExpenseTypeDAL();
			if(dalMST_ExpenseType.Update(entMST_ExpenseType))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_ExpenseType.Message;
				return false;
			}
		}

		#endregion UpdateOperation

        #region UpsertOperation

        public Boolean Upsert(MST_ExpenseTypeENT entMST_ExpenseType)
        {
            MST_ExpenseTypeDAL dalMST_ExpenseType = new MST_ExpenseTypeDAL();
            if (dalMST_ExpenseType.Upsert(entMST_ExpenseType))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_ExpenseType.Message;
                return false;
            }
        }

        #endregion UpsertOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 ExpenseTypeID)
		{
			MST_ExpenseTypeDAL dalMST_ExpenseType = new MST_ExpenseTypeDAL();
			if(dalMST_ExpenseType.Delete(ExpenseTypeID))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_ExpenseType.Message;
				return false;
			}
		}

		#endregion DeleteOperationa

		#region SelectOperation

		public MST_ExpenseTypeENT SelectPK(SqlInt32 ExpenseTypeID)
		{
			MST_ExpenseTypeDAL dalMST_ExpenseType = new MST_ExpenseTypeDAL();
			return dalMST_ExpenseType.SelectPK(ExpenseTypeID);
		}
		public DataTable SelectView(SqlInt32 ExpenseTypeID)
		{
			MST_ExpenseTypeDAL dalMST_ExpenseType = new MST_ExpenseTypeDAL();
			return dalMST_ExpenseType.SelectView(ExpenseTypeID);
		}
		public DataTable SelectAll()
		{
			MST_ExpenseTypeDAL dalMST_ExpenseType = new MST_ExpenseTypeDAL();
			return dalMST_ExpenseType.SelectAll();
		}
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString ExpenseType, SqlInt32 HospitalID)
		{
			MST_ExpenseTypeDAL dalMST_ExpenseType = new MST_ExpenseTypeDAL();
			return dalMST_ExpenseType.SelectPage(PageOffset, PageSize, out TotalRecords , ExpenseType,  HospitalID);
		}

        public DataTable SelectShow(SqlInt32 HospitalID)
        {
            MST_ExpenseTypeDAL dalMST_ExpenseType = new MST_ExpenseTypeDAL();
            return dalMST_ExpenseType.SelectShow(HospitalID);
        }

		#endregion SelectOperation

        #region ComboBox 

        public DataTable SelectComboBox()
		{
			MST_ExpenseTypeDAL dalMST_ExpenseType = new MST_ExpenseTypeDAL();
			return dalMST_ExpenseType.SelectComboBox();
		}

        public DataTable SelectComboBoxByFinYearID(SqlInt32 FinYearID, SqlInt32 HospitalID)
        {
            MST_ExpenseTypeDAL dalMST_ExpenseType = new MST_ExpenseTypeDAL();
            return dalMST_ExpenseType.SelectComboBoxByFinYearID(FinYearID, HospitalID);
        }

		#endregion ComboBox
	}

}