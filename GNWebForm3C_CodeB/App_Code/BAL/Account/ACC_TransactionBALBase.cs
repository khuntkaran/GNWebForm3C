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
	public abstract class ACC_TransactionBALBase
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

		public ACC_TransactionBALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(ACC_TransactionENT entACC_Transaction)
		{
			ACC_TransactionDAL dalACC_Transaction = new ACC_TransactionDAL();
			if(dalACC_Transaction.Insert(entACC_Transaction))
			{
				return true;
			}
			else
			{
				this.Message = dalACC_Transaction.Message;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

		public Boolean Update(ACC_TransactionENT entACC_Transaction)
		{
			ACC_TransactionDAL dalACC_Transaction = new ACC_TransactionDAL();
			if(dalACC_Transaction.Update(entACC_Transaction))
			{
				return true;
			}
			else
			{
				this.Message = dalACC_Transaction.Message;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 TransactionID)
		{
			ACC_TransactionDAL dalACC_Transaction = new ACC_TransactionDAL();
			if(dalACC_Transaction.Delete(TransactionID))
			{
				return true;
			}
			else
			{
				this.Message = dalACC_Transaction.Message;
				return false;
			}
		}

		#endregion DeleteOperation

		#region SelectOperation

		public ACC_TransactionENT SelectPK(SqlInt32 TransactionID)
		{
			ACC_TransactionDAL dalACC_Transaction = new ACC_TransactionDAL();
			return dalACC_Transaction.SelectPK(TransactionID);
		}
		public DataTable SelectView(SqlInt32 TransactionID)
		{
			ACC_TransactionDAL dalACC_Transaction = new ACC_TransactionDAL();
			return dalACC_Transaction.SelectView(TransactionID);
		}
		public DataTable SelectAll()
		{
			ACC_TransactionDAL dalACC_Transaction = new ACC_TransactionDAL();
			return dalACC_Transaction.SelectAll();
		}
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString Patient, SqlInt32 TreatmentID)
		{
			ACC_TransactionDAL dalACC_Transaction = new ACC_TransactionDAL();
            return dalACC_Transaction.SelectPage(PageOffset, PageSize, out TotalRecords, Patient, TreatmentID);
		}

		#endregion SelectOperation

		#region ComboBox

		public DataTable SelectComboBox()
		{
			ACC_TransactionDAL dalACC_Transaction = new ACC_TransactionDAL();
			return dalACC_Transaction.SelectComboBox();
		}

		#endregion ComboBox

	}

}