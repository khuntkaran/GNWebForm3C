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
	public abstract class ACC_TransactionTranBALBase
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

		public ACC_TransactionTranBALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(ACC_TransactionTranENT entACC_TransactionTran)
		{
			ACC_TransactionTranDAL dalACC_TransactionTran = new ACC_TransactionTranDAL();
			if(dalACC_TransactionTran.Insert(entACC_TransactionTran))
			{
				return true;
			}
			else
			{
				this.Message = dalACC_TransactionTran.Message;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

		public Boolean Update(ACC_TransactionTranENT entACC_TransactionTran)
		{
			ACC_TransactionTranDAL dalACC_TransactionTran = new ACC_TransactionTranDAL();
			if(dalACC_TransactionTran.Update(entACC_TransactionTran))
			{
				return true;
			}
			else
			{
				this.Message = dalACC_TransactionTran.Message;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 TransactionTranID)
		{
			ACC_TransactionTranDAL dalACC_TransactionTran = new ACC_TransactionTranDAL();
			if(dalACC_TransactionTran.Delete(TransactionTranID))
			{
				return true;
			}
			else
			{
				this.Message = dalACC_TransactionTran.Message;
				return false;
			}
		}

		#endregion DeleteOperation

		#region SelectOperation

		public ACC_TransactionTranENT SelectPK(SqlInt32 TransactionTranID)
		{
			ACC_TransactionTranDAL dalACC_TransactionTran = new ACC_TransactionTranDAL();
			return dalACC_TransactionTran.SelectPK(TransactionTranID);
		}
		public DataTable SelectView(SqlInt32 TransactionTranID)
		{
			ACC_TransactionTranDAL dalACC_TransactionTran = new ACC_TransactionTranDAL();
			return dalACC_TransactionTran.SelectView(TransactionTranID);
		}
		public DataTable SelectAll()
		{
			ACC_TransactionTranDAL dalACC_TransactionTran = new ACC_TransactionTranDAL();
			return dalACC_TransactionTran.SelectAll();
		}
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlInt32 TransactionID, SqlString Patient)
		{
			ACC_TransactionTranDAL dalACC_TransactionTran = new ACC_TransactionTranDAL();
            return dalACC_TransactionTran.SelectPage(PageOffset, PageSize, out TotalRecords, TransactionID, Patient);
		}

		#endregion SelectOperation

		#region ComboBox

		public DataTable SelectComboBox()
		{
			ACC_TransactionTranDAL dalACC_TransactionTran = new ACC_TransactionTranDAL();
			return dalACC_TransactionTran.SelectComboBox();
		}

		#endregion ComboBox

	}

}