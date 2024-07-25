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
	public abstract class MST_ReceiptTypeBALBase
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

		public MST_ReceiptTypeBALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(MST_ReceiptTypeENT entMST_ReceiptType)
		{
			MST_ReceiptTypeDAL dalMST_ReceiptType = new MST_ReceiptTypeDAL();
			if(dalMST_ReceiptType.Insert(entMST_ReceiptType))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_ReceiptType.Message;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

		public Boolean Update(MST_ReceiptTypeENT entMST_ReceiptType)
		{
			MST_ReceiptTypeDAL dalMST_ReceiptType = new MST_ReceiptTypeDAL();
			if(dalMST_ReceiptType.Update(entMST_ReceiptType))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_ReceiptType.Message;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 ReceiptTypeID)
		{
			MST_ReceiptTypeDAL dalMST_ReceiptType = new MST_ReceiptTypeDAL();
			if(dalMST_ReceiptType.Delete(ReceiptTypeID))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_ReceiptType.Message;
				return false;
			}
		}

		#endregion DeleteOperation

		#region SelectOperation

		public MST_ReceiptTypeENT SelectPK(SqlInt32 ReceiptTypeID)
		{
			MST_ReceiptTypeDAL dalMST_ReceiptType = new MST_ReceiptTypeDAL();
			return dalMST_ReceiptType.SelectPK(ReceiptTypeID);
		}
		public DataTable SelectView(SqlInt32 ReceiptTypeID)
		{
			MST_ReceiptTypeDAL dalMST_ReceiptType = new MST_ReceiptTypeDAL();
			return dalMST_ReceiptType.SelectView(ReceiptTypeID);
		}
		public DataTable SelectAll()
		{
			MST_ReceiptTypeDAL dalMST_ReceiptType = new MST_ReceiptTypeDAL();
			return dalMST_ReceiptType.SelectAll();
		}
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString ReceiptTypeName, SqlString PrintName, SqlInt32 HospitalID,SqlBoolean IsDefault)
		{
			MST_ReceiptTypeDAL dalMST_ReceiptType = new MST_ReceiptTypeDAL();
			return dalMST_ReceiptType.SelectPage(PageOffset, PageSize, out TotalRecords , ReceiptTypeName,  PrintName,  HospitalID,IsDefault);
		}

		#endregion SelectOperation

		#region ComboBox

		public DataTable SelectComboBox()
		{
			MST_ReceiptTypeDAL dalMST_ReceiptType = new MST_ReceiptTypeDAL();
			return dalMST_ReceiptType.SelectComboBox();
		}

		#endregion ComboBox

	}

}