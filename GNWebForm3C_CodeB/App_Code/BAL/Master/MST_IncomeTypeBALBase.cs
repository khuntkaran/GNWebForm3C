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
	public abstract class MST_IncomeTypeBALBase
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

		public MST_IncomeTypeBALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(MST_IncomeTypeENT entMST_IncomeType)
		{
			MST_IncomeTypeDAL dalMST_IncomeType = new MST_IncomeTypeDAL();
			if(dalMST_IncomeType.Insert(entMST_IncomeType))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_IncomeType.Message;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

		public Boolean Update(MST_IncomeTypeENT entMST_IncomeType)
		{
			MST_IncomeTypeDAL dalMST_IncomeType = new MST_IncomeTypeDAL();
			if(dalMST_IncomeType.Update(entMST_IncomeType))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_IncomeType.Message;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 IncomeTypeID)
		{
			MST_IncomeTypeDAL dalMST_IncomeType = new MST_IncomeTypeDAL();
			if(dalMST_IncomeType.Delete(IncomeTypeID))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_IncomeType.Message;
				return false;
			}
		}

		#endregion DeleteOperation

		#region SelectOperation

		public MST_IncomeTypeENT SelectPK(SqlInt32 IncomeTypeID)
		{
			MST_IncomeTypeDAL dalMST_IncomeType = new MST_IncomeTypeDAL();
			return dalMST_IncomeType.SelectPK(IncomeTypeID);
		}
		public DataTable SelectView(SqlInt32 IncomeTypeID)
		{
			MST_IncomeTypeDAL dalMST_IncomeType = new MST_IncomeTypeDAL();
			return dalMST_IncomeType.SelectView(IncomeTypeID);
		}
		public DataTable SelectAll()
		{
			MST_IncomeTypeDAL dalMST_IncomeType = new MST_IncomeTypeDAL();
			return dalMST_IncomeType.SelectAll();
		}
		public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords , SqlString IncomeType , SqlInt32 HospitalID)
		{
			MST_IncomeTypeDAL dalMST_IncomeType = new MST_IncomeTypeDAL();
			return dalMST_IncomeType.SelectPage(PageOffset, PageSize, out TotalRecords , IncomeType ,  HospitalID);
		}

		#endregion SelectOperation

		#region ComboBox

        public DataTable SelectComboBoxByFinYearID(SqlInt32 FinYearID, SqlInt32 HospitalID)
		{
			MST_IncomeTypeDAL dalMST_IncomeType = new MST_IncomeTypeDAL();
            return dalMST_IncomeType.SelectComboBoxByFinYearID(FinYearID, HospitalID);
		}

        public DataTable SelectSingleComboBox()
        {
            MST_IncomeTypeDAL dalMST_IncomeType = new MST_IncomeTypeDAL();
            return dalMST_IncomeType.SelectComboBox();
        }


		#endregion ComboBox

	}

}