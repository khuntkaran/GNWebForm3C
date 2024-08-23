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
	public abstract class ACC_ExpenseBALBase
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

		public ACC_ExpenseBALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(ACC_ExpenseENT entACC_Expense)
		{
			ACC_ExpenseDAL dalACC_Expense = new ACC_ExpenseDAL();
			if(dalACC_Expense.Insert(entACC_Expense))
			{
				return true;
			}
			else
			{
				this.Message = dalACC_Expense.Message;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

		public Boolean Update(ACC_ExpenseENT entACC_Expense)
		{
			ACC_ExpenseDAL dalACC_Expense = new ACC_ExpenseDAL();
			if(dalACC_Expense.Update(entACC_Expense))
			{
				return true;
			}
			else
			{
				this.Message = dalACC_Expense.Message;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 ExpenseID)
		{
			ACC_ExpenseDAL dalACC_Expense = new ACC_ExpenseDAL();
			if(dalACC_Expense.Delete(ExpenseID))
			{
				return true;
			}
			else
			{
				this.Message = dalACC_Expense.Message;
				return false;
			}
		}

        #endregion DeleteOperation

        #region SelectOperation

        public DataTable SelectHospitalWiseExpenseList(SqlDateTime FromDate, SqlDateTime ToDate, SqlInt32 HospitalID)
        {
            ACC_ExpenseDAL dalACC_Expense = new ACC_ExpenseDAL();
            return dalACC_Expense.SelectHospitalWiseExpenseList(FromDate, ToDate, HospitalID);
        }
        public ACC_ExpenseENT SelectPK(SqlInt32 ExpenseID)
		{
			ACC_ExpenseDAL dalACC_Expense = new ACC_ExpenseDAL();
			return dalACC_Expense.SelectPK(ExpenseID);
		}
		public DataTable SelectView(SqlInt32 ExpenseID)
		{
			ACC_ExpenseDAL dalACC_Expense = new ACC_ExpenseDAL();
			return dalACC_Expense.SelectView(ExpenseID); 
		}
		public DataTable SelectAll()
		{
			ACC_ExpenseDAL dalACC_Expense = new ACC_ExpenseDAL();
			return dalACC_Expense.SelectAll();
		}
		public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlInt32 ExpenseTypeID, SqlDecimal Amount, SqlDateTime ExpenseDate, SqlInt32 HospitalID, SqlInt32 FinYearID,SqlString TagName)
		{
			ACC_ExpenseDAL dalACC_Expense = new ACC_ExpenseDAL();
			return dalACC_Expense.SelectPage(PageOffset, PageSize, out TotalRecords, ExpenseTypeID, Amount, ExpenseDate, HospitalID, FinYearID,TagName);
		}

		#endregion SelectOperation

		#region ComboBox

		public DataTable SelectComboBox()
		{
			ACC_ExpenseDAL dalACC_Expense = new ACC_ExpenseDAL();
			return dalACC_Expense.SelectComboBox();
		}

		#endregion ComboBox

	}

}