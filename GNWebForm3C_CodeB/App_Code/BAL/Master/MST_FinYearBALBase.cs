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
	public abstract class MST_FinYearBALBase
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

		public MST_FinYearBALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(MST_FinYearENT entMST_FinYear)
		{
			MST_FinYearDAL dalMST_FinYear = new MST_FinYearDAL();
			if(dalMST_FinYear.Insert(entMST_FinYear))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_FinYear.Message;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

		public Boolean Update(MST_FinYearENT entMST_FinYear)
		{
			MST_FinYearDAL dalMST_FinYear = new MST_FinYearDAL();
			if(dalMST_FinYear.Update(entMST_FinYear))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_FinYear.Message;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 FinYearID)
		{
			MST_FinYearDAL dalMST_FinYear = new MST_FinYearDAL();
			if(dalMST_FinYear.Delete(FinYearID))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_FinYear.Message;
				return false;
			}
		}

		#endregion DeleteOperation

		#region SelectOperation

		public MST_FinYearENT SelectPK(SqlInt32 FinYearID)
		{
			MST_FinYearDAL dalMST_FinYear = new MST_FinYearDAL();
			return dalMST_FinYear.SelectPK(FinYearID);
		}
		public DataTable SelectView(SqlInt32 FinYearID)
		{
			MST_FinYearDAL dalMST_FinYear = new MST_FinYearDAL();
			return dalMST_FinYear.SelectView(FinYearID);
		}
		public DataTable SelectAll()
		{
			MST_FinYearDAL dalMST_FinYear = new MST_FinYearDAL();
			return dalMST_FinYear.SelectAll();
		}
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString FinYearName, SqlDateTime FromDate, SqlDateTime ToDate)
		{
			MST_FinYearDAL dalMST_FinYear = new MST_FinYearDAL();
			return dalMST_FinYear.SelectPage(PageOffset, PageSize, out TotalRecords , FinYearName, FromDate, ToDate );
		}

		#endregion SelectOperation

		#region ComboBox

        public DataTable SelectComboBoxByHospitalID(SqlInt32 HospitalID)
		{
			MST_FinYearDAL dalMST_FinYear = new MST_FinYearDAL();
            return dalMST_FinYear.SelectComboBoxByHospitalID(HospitalID);
		}
        public DataTable SelectComboBoxByHospitalIDExpense(SqlInt32 HospitalID)
		{
			MST_FinYearDAL dalMST_FinYear = new MST_FinYearDAL();
            return dalMST_FinYear.SelectComboBoxByHospitalIDExpense(HospitalID);
		}
         public DataTable SelectComboBox()
		{
			MST_FinYearDAL dalMST_FinYear = new MST_FinYearDAL();
            return dalMST_FinYear.SelectSingleComboBox();
		}

		#endregion ComboBox

	}

}