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
	public abstract class SEC_UserBALBase
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

		public SEC_UserBALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(SEC_UserENT entSEC_User)
		{
			SEC_UserDAL dalSEC_User = new SEC_UserDAL();
			if(dalSEC_User.Insert(entSEC_User))
			{
				return true;
			}
			else
			{
				this.Message = dalSEC_User.Message;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

		public Boolean Update(SEC_UserENT entSEC_User)
		{
			SEC_UserDAL dalSEC_User = new SEC_UserDAL();
			if(dalSEC_User.Update(entSEC_User))
			{
				return true;
			}
			else
			{
				this.Message = dalSEC_User.Message;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 UserID)
		{
			SEC_UserDAL dalSEC_User = new SEC_UserDAL();
			if(dalSEC_User.Delete(UserID))
			{
				return true;
			}
			else
			{
				this.Message = dalSEC_User.Message;
				return false;
			}
		}

		#endregion DeleteOperation

		#region SelectOperation

		public SEC_UserENT SelectPK(SqlInt32 UserID)
		{
			SEC_UserDAL dalSEC_User = new SEC_UserDAL();
			return dalSEC_User.SelectPK(UserID);
		}
		public DataTable SelectView(SqlInt32 UserID)
		{
			SEC_UserDAL dalSEC_User = new SEC_UserDAL();
			return dalSEC_User.SelectView(UserID);
		}
		public DataTable SelectAll()
		{
			SEC_UserDAL dalSEC_User = new SEC_UserDAL();
			return dalSEC_User.SelectAll();
		}
		public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords)
		{
			SEC_UserDAL dalSEC_User = new SEC_UserDAL();
			return dalSEC_User.SelectPage(PageOffset, PageSize, out TotalRecords);
		}

		#endregion SelectOperation

		#region ComboBox

		public DataTable SelectComboBox()
		{
			SEC_UserDAL dalSEC_User = new SEC_UserDAL();
			return dalSEC_User.SelectComboBox();
		}

		#endregion ComboBox

	}

}