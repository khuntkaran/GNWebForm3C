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
	public abstract class CFG_ReportSettingBALBase
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

		public CFG_ReportSettingBALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(CFG_ReportSettingENT entCFG_ReportSetting)
		{
			CFG_ReportSettingDAL dalCFG_ReportSetting = new CFG_ReportSettingDAL();
			if(dalCFG_ReportSetting.Insert(entCFG_ReportSetting))
			{
				return true;
			}
			else
			{
				this.Message = dalCFG_ReportSetting.Message;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

		public Boolean Update(CFG_ReportSettingENT entCFG_ReportSetting)
		{
			CFG_ReportSettingDAL dalCFG_ReportSetting = new CFG_ReportSettingDAL();
			if(dalCFG_ReportSetting.Update(entCFG_ReportSetting))
			{
				return true;
			}
			else
			{
				this.Message = dalCFG_ReportSetting.Message;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 ReportSettingID)
		{
			CFG_ReportSettingDAL dalCFG_ReportSetting = new CFG_ReportSettingDAL();
			if(dalCFG_ReportSetting.Delete(ReportSettingID))
			{
				return true;
			}
			else
			{
				this.Message = dalCFG_ReportSetting.Message;
				return false;
			}
		}

		#endregion DeleteOperation

		#region SelectOperation

		public CFG_ReportSettingENT SelectPK(SqlInt32 ReportSettingID)
		{
			CFG_ReportSettingDAL dalCFG_ReportSetting = new CFG_ReportSettingDAL();
			return dalCFG_ReportSetting.SelectPK(ReportSettingID);
		}
		public DataTable SelectView(SqlInt32 ReportSettingID)
		{
			CFG_ReportSettingDAL dalCFG_ReportSetting = new CFG_ReportSettingDAL();
			return dalCFG_ReportSetting.SelectView(ReportSettingID);
		}
		public DataTable SelectAll()
		{
			CFG_ReportSettingDAL dalCFG_ReportSetting = new CFG_ReportSettingDAL();
			return dalCFG_ReportSetting.SelectAll();
		}
		public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords)
		{
			CFG_ReportSettingDAL dalCFG_ReportSetting = new CFG_ReportSettingDAL();
			return dalCFG_ReportSetting.SelectPage(PageOffset, PageSize, out TotalRecords);
		}

		#endregion SelectOperation

		#region ComboBox

		public DataTable SelectComboBox()
		{
			CFG_ReportSettingDAL dalCFG_ReportSetting = new CFG_ReportSettingDAL();
			return dalCFG_ReportSetting.SelectComboBox();
		}

		#endregion ComboBox

	}

}