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
	public abstract class CFG_SoftwareConfigurationBALBase
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

		public CFG_SoftwareConfigurationBALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(CFG_SoftwareConfigurationENT entCFG_SoftwareConfiguration)
		{
			CFG_SoftwareConfigurationDAL dalCFG_SoftwareConfiguration = new CFG_SoftwareConfigurationDAL();
			if(dalCFG_SoftwareConfiguration.Insert(entCFG_SoftwareConfiguration))
			{
				return true;
			}
			else
			{
				this.Message = dalCFG_SoftwareConfiguration.Message;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

		public Boolean Update(CFG_SoftwareConfigurationENT entCFG_SoftwareConfiguration)
		{
			CFG_SoftwareConfigurationDAL dalCFG_SoftwareConfiguration = new CFG_SoftwareConfigurationDAL();
			if(dalCFG_SoftwareConfiguration.Update(entCFG_SoftwareConfiguration))
			{
				return true;
			}
			else
			{
				this.Message = dalCFG_SoftwareConfiguration.Message;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 SoftwareConfigurationID)
		{
			CFG_SoftwareConfigurationDAL dalCFG_SoftwareConfiguration = new CFG_SoftwareConfigurationDAL();
			if(dalCFG_SoftwareConfiguration.Delete(SoftwareConfigurationID))
			{
				return true;
			}
			else
			{
				this.Message = dalCFG_SoftwareConfiguration.Message;
				return false;
			}
		}

		#endregion DeleteOperation

		#region SelectOperation

		public CFG_SoftwareConfigurationENT SelectPK(SqlInt32 SoftwareConfigurationID)
		{
			CFG_SoftwareConfigurationDAL dalCFG_SoftwareConfiguration = new CFG_SoftwareConfigurationDAL();
			return dalCFG_SoftwareConfiguration.SelectPK(SoftwareConfigurationID);
		}
		public DataTable SelectView(SqlInt32 SoftwareConfigurationID)
		{
			CFG_SoftwareConfigurationDAL dalCFG_SoftwareConfiguration = new CFG_SoftwareConfigurationDAL();
			return dalCFG_SoftwareConfiguration.SelectView(SoftwareConfigurationID);
		}
		public DataTable SelectAll()
		{
			CFG_SoftwareConfigurationDAL dalCFG_SoftwareConfiguration = new CFG_SoftwareConfigurationDAL();
			return dalCFG_SoftwareConfiguration.SelectAll();
		}
		public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords)
		{
			CFG_SoftwareConfigurationDAL dalCFG_SoftwareConfiguration = new CFG_SoftwareConfigurationDAL();
			return dalCFG_SoftwareConfiguration.SelectPage(PageOffset, PageSize, out TotalRecords);
		}

		#endregion SelectOperation

		#region ComboBox

		public DataTable SelectComboBox()
		{
			CFG_SoftwareConfigurationDAL dalCFG_SoftwareConfiguration = new CFG_SoftwareConfigurationDAL();
			return dalCFG_SoftwareConfiguration.SelectComboBox();
		}

		#endregion ComboBox

	}

}