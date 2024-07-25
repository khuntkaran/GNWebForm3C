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
	public abstract class SEC_MenuBALBase
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

		public SEC_MenuBALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(SEC_MenuENT entSEC_Menu)
		{
			SEC_MenuDAL dalSEC_Menu = new SEC_MenuDAL();
			if(dalSEC_Menu.Insert(entSEC_Menu))
			{
				return true;
			}
			else
			{
				this.Message = dalSEC_Menu.Message;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

		public Boolean Update(SEC_MenuENT entSEC_Menu)
		{
			SEC_MenuDAL dalSEC_Menu = new SEC_MenuDAL();
			if(dalSEC_Menu.Update(entSEC_Menu))
			{
				return true;
			}
			else
			{
				this.Message = dalSEC_Menu.Message;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 MenuID)
		{
			SEC_MenuDAL dalSEC_Menu = new SEC_MenuDAL();
			if(dalSEC_Menu.Delete(MenuID))
			{
				return true;
			}
			else
			{
				this.Message = dalSEC_Menu.Message;
				return false;
			}
		}

		#endregion DeleteOperation

		#region SelectOperation

		public SEC_MenuENT SelectPK(SqlInt32 MenuID)
		{
			SEC_MenuDAL dalSEC_Menu = new SEC_MenuDAL();
			return dalSEC_Menu.SelectPK(MenuID);
		}
		public DataTable SelectView(SqlInt32 MenuID)
		{
			SEC_MenuDAL dalSEC_Menu = new SEC_MenuDAL();
			return dalSEC_Menu.SelectView(MenuID);
		}
		public DataTable SelectAll()
		{
			SEC_MenuDAL dalSEC_Menu = new SEC_MenuDAL();
			return dalSEC_Menu.SelectAll();
		}
		public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords)
		{
			SEC_MenuDAL dalSEC_Menu = new SEC_MenuDAL();
			return dalSEC_Menu.SelectPage(PageOffset, PageSize, out TotalRecords);
		}

		#endregion SelectOperation

		#region ComboBox

		public DataTable SelectComboBox()
		{
			SEC_MenuDAL dalSEC_Menu = new SEC_MenuDAL();
			return dalSEC_Menu.SelectComboBox();
		}

		#endregion ComboBox

	}

}