using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using GNForm3C.ENT;

namespace GNForm3C.DAL
{
	public abstract class CFG_SoftwareConfigurationDALBase : DataBaseConfig
	{
		#region Properties

		private string _Message;
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

		#endregion Properties

		#region Constructor

		public CFG_SoftwareConfigurationDALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(CFG_SoftwareConfigurationENT entCFG_SoftwareConfiguration)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_SoftwareConfiguration_Insert");

				sqlDB.AddOutParameter(dbCMD, "@SoftwareConfigurationID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@SaveMessage_NoMessageJustClosetheform", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.SaveMessage_NoMessageJustClosetheform);
				sqlDB.AddInParameter(dbCMD, "@SaveMessage_ShowMessageClosetheform", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.SaveMessage_ShowMessageClosetheform);
				sqlDB.AddInParameter(dbCMD, "@SaveMessage_ShowMessageAskforOtherRecord", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.SaveMessage_ShowMessageAskforOtherRecord);
				sqlDB.AddInParameter(dbCMD, "@ShortcutKeys_AddOnNumPadPlusKeyinListPage", SqlDbType.Bit, entCFG_SoftwareConfiguration.ShortcutKeys_AddOnNumPadPlusKeyinListPage);
				sqlDB.AddInParameter(dbCMD, "@ShortcutKeys_EditOnEnterKeyinListPage", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.ShortcutKeys_EditOnEnterKeyinListPage);
				sqlDB.AddInParameter(dbCMD, "@ShortcutKeys_ViewOnSpaceBarKeyinListPage", SqlDbType.Bit, entCFG_SoftwareConfiguration.ShortcutKeys_ViewOnSpaceBarKeyinListPage);
				sqlDB.AddInParameter(dbCMD, "@ShortcutKeys_DeleteOnDeleteKeyinListPage", SqlDbType.Bit, entCFG_SoftwareConfiguration.ShortcutKeys_DeleteOnDeleteKeyinListPage);
				sqlDB.AddInParameter(dbCMD, "@ShortcutKeys_DoubleClicK", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.ShortcutKeys_DoubleClicK);
				sqlDB.AddInParameter(dbCMD, "@ShortcutKeys_IsAskConfirmationBeforeEscape", SqlDbType.Bit, entCFG_SoftwareConfiguration.ShortcutKeys_IsAskConfirmationBeforeEscape);
				sqlDB.AddInParameter(dbCMD, "@IsEnterAsTAB", SqlDbType.Bit, entCFG_SoftwareConfiguration.IsEnterAsTAB);
				sqlDB.AddInParameter(dbCMD, "@IsSendError", SqlDbType.Bit, entCFG_SoftwareConfiguration.IsSendError);
				sqlDB.AddInParameter(dbCMD, "@IsShowUserNameinListPage", SqlDbType.Bit, entCFG_SoftwareConfiguration.IsShowUserNameinListPage);
				sqlDB.AddInParameter(dbCMD, "@IsShowModifiedinListPage", SqlDbType.Bit, entCFG_SoftwareConfiguration.IsShowModifiedinListPage);
				sqlDB.AddInParameter(dbCMD, "@AllowIncrementalSearchinGrid", SqlDbType.Bit, entCFG_SoftwareConfiguration.AllowIncrementalSearchinGrid);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entCFG_SoftwareConfiguration.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@WeeklyBackupPath", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.WeeklyBackupPath);
				sqlDB.AddInParameter(dbCMD, "@WeeklyBackupPassword", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.WeeklyBackupPassword);
				sqlDB.AddInParameter(dbCMD, "@IsActive", SqlDbType.Bit, entCFG_SoftwareConfiguration.IsActive);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entCFG_SoftwareConfiguration.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entCFG_SoftwareConfiguration.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entCFG_SoftwareConfiguration.Modified);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entCFG_SoftwareConfiguration.SoftwareConfigurationID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@SoftwareConfigurationID"].Value);

				return true;
			}
			catch (SqlException sqlex)
			{
				Message = SQLDataExceptionMessage(sqlex);
				if (SQLDataExceptionHandler(sqlex))
					throw;
				return false;
			}
			catch (Exception ex)
			{
				Message = ExceptionMessage(ex);
				if (ExceptionHandler(ex))
					throw;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

		public Boolean Update(CFG_SoftwareConfigurationENT entCFG_SoftwareConfiguration)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_SoftwareConfiguration_Update");

				sqlDB.AddInParameter(dbCMD, "@SoftwareConfigurationID", SqlDbType.Int, entCFG_SoftwareConfiguration.SoftwareConfigurationID);
				sqlDB.AddInParameter(dbCMD, "@SaveMessage_NoMessageJustClosetheform", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.SaveMessage_NoMessageJustClosetheform);
				sqlDB.AddInParameter(dbCMD, "@SaveMessage_ShowMessageClosetheform", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.SaveMessage_ShowMessageClosetheform);
				sqlDB.AddInParameter(dbCMD, "@SaveMessage_ShowMessageAskforOtherRecord", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.SaveMessage_ShowMessageAskforOtherRecord);
				sqlDB.AddInParameter(dbCMD, "@ShortcutKeys_AddOnNumPadPlusKeyinListPage", SqlDbType.Bit, entCFG_SoftwareConfiguration.ShortcutKeys_AddOnNumPadPlusKeyinListPage);
				sqlDB.AddInParameter(dbCMD, "@ShortcutKeys_EditOnEnterKeyinListPage", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.ShortcutKeys_EditOnEnterKeyinListPage);
				sqlDB.AddInParameter(dbCMD, "@ShortcutKeys_ViewOnSpaceBarKeyinListPage", SqlDbType.Bit, entCFG_SoftwareConfiguration.ShortcutKeys_ViewOnSpaceBarKeyinListPage);
				sqlDB.AddInParameter(dbCMD, "@ShortcutKeys_DeleteOnDeleteKeyinListPage", SqlDbType.Bit, entCFG_SoftwareConfiguration.ShortcutKeys_DeleteOnDeleteKeyinListPage);
				sqlDB.AddInParameter(dbCMD, "@ShortcutKeys_DoubleClicK", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.ShortcutKeys_DoubleClicK);
				sqlDB.AddInParameter(dbCMD, "@ShortcutKeys_IsAskConfirmationBeforeEscape", SqlDbType.Bit, entCFG_SoftwareConfiguration.ShortcutKeys_IsAskConfirmationBeforeEscape);
				sqlDB.AddInParameter(dbCMD, "@IsEnterAsTAB", SqlDbType.Bit, entCFG_SoftwareConfiguration.IsEnterAsTAB);
				sqlDB.AddInParameter(dbCMD, "@IsSendError", SqlDbType.Bit, entCFG_SoftwareConfiguration.IsSendError);
				sqlDB.AddInParameter(dbCMD, "@IsShowUserNameinListPage", SqlDbType.Bit, entCFG_SoftwareConfiguration.IsShowUserNameinListPage);
				sqlDB.AddInParameter(dbCMD, "@IsShowModifiedinListPage", SqlDbType.Bit, entCFG_SoftwareConfiguration.IsShowModifiedinListPage);
				sqlDB.AddInParameter(dbCMD, "@AllowIncrementalSearchinGrid", SqlDbType.Bit, entCFG_SoftwareConfiguration.AllowIncrementalSearchinGrid);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entCFG_SoftwareConfiguration.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@WeeklyBackupPath", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.WeeklyBackupPath);
				sqlDB.AddInParameter(dbCMD, "@WeeklyBackupPassword", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.WeeklyBackupPassword);
				sqlDB.AddInParameter(dbCMD, "@IsActive", SqlDbType.Bit, entCFG_SoftwareConfiguration.IsActive);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entCFG_SoftwareConfiguration.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entCFG_SoftwareConfiguration.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entCFG_SoftwareConfiguration.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entCFG_SoftwareConfiguration.Modified);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				return true;
			}
			catch (SqlException sqlex)
			{
				Message = SQLDataExceptionMessage(sqlex);
				if (SQLDataExceptionHandler(sqlex))
					throw;
				return false;
			}
			catch (Exception ex)
			{
				Message = ExceptionMessage(ex);
				if (ExceptionHandler(ex))
					throw;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 SoftwareConfigurationID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_SoftwareConfiguration_Delete");

				sqlDB.AddInParameter(dbCMD, "@SoftwareConfigurationID", SqlDbType.Int, SoftwareConfigurationID);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				return true;
			}
			catch (SqlException sqlex)
			{
				Message = SQLDataExceptionMessage(sqlex);
				if (SQLDataExceptionHandler(sqlex))
					throw;
				return false;
			}
			catch (Exception ex)
			{
				Message = ExceptionMessage(ex);
				if (ExceptionHandler(ex))
					throw;
				return false;
			}
		}

		#endregion DeleteOperation

		#region SelectOperation

		public CFG_SoftwareConfigurationENT SelectPK(SqlInt32 SoftwareConfigurationID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_SoftwareConfiguration_SelectPK");

				sqlDB.AddInParameter(dbCMD, "@SoftwareConfigurationID", SqlDbType.Int, SoftwareConfigurationID);

				CFG_SoftwareConfigurationENT entCFG_SoftwareConfiguration = new CFG_SoftwareConfigurationENT();
				DataBaseHelper DBH = new DataBaseHelper();
				using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
				{
					while (dr.Read())
					{
						if(!dr["SoftwareConfigurationID"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.SoftwareConfigurationID = Convert.ToInt32(dr["SoftwareConfigurationID"]);

						if(!dr["SaveMessage_NoMessageJustClosetheform"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.SaveMessage_NoMessageJustClosetheform = Convert.ToString(dr["SaveMessage_NoMessageJustClosetheform"]);

						if(!dr["SaveMessage_ShowMessageClosetheform"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.SaveMessage_ShowMessageClosetheform = Convert.ToString(dr["SaveMessage_ShowMessageClosetheform"]);

						if(!dr["SaveMessage_ShowMessageAskforOtherRecord"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.SaveMessage_ShowMessageAskforOtherRecord = Convert.ToString(dr["SaveMessage_ShowMessageAskforOtherRecord"]);

						if(!dr["ShortcutKeys_AddOnNumPadPlusKeyinListPage"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.ShortcutKeys_AddOnNumPadPlusKeyinListPage = Convert.ToBoolean(dr["ShortcutKeys_AddOnNumPadPlusKeyinListPage"]);

						if(!dr["ShortcutKeys_EditOnEnterKeyinListPage"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.ShortcutKeys_EditOnEnterKeyinListPage = Convert.ToString(dr["ShortcutKeys_EditOnEnterKeyinListPage"]);

						if(!dr["ShortcutKeys_ViewOnSpaceBarKeyinListPage"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.ShortcutKeys_ViewOnSpaceBarKeyinListPage = Convert.ToBoolean(dr["ShortcutKeys_ViewOnSpaceBarKeyinListPage"]);

						if(!dr["ShortcutKeys_DeleteOnDeleteKeyinListPage"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.ShortcutKeys_DeleteOnDeleteKeyinListPage = Convert.ToBoolean(dr["ShortcutKeys_DeleteOnDeleteKeyinListPage"]);

						if(!dr["ShortcutKeys_DoubleClicK"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.ShortcutKeys_DoubleClicK = Convert.ToString(dr["ShortcutKeys_DoubleClicK"]);

						if(!dr["ShortcutKeys_IsAskConfirmationBeforeEscape"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.ShortcutKeys_IsAskConfirmationBeforeEscape = Convert.ToBoolean(dr["ShortcutKeys_IsAskConfirmationBeforeEscape"]);

						if(!dr["IsEnterAsTAB"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.IsEnterAsTAB = Convert.ToBoolean(dr["IsEnterAsTAB"]);

						if(!dr["IsSendError"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.IsSendError = Convert.ToBoolean(dr["IsSendError"]);

						if(!dr["IsShowUserNameinListPage"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.IsShowUserNameinListPage = Convert.ToBoolean(dr["IsShowUserNameinListPage"]);

						if(!dr["IsShowModifiedinListPage"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.IsShowModifiedinListPage = Convert.ToBoolean(dr["IsShowModifiedinListPage"]);

						if(!dr["AllowIncrementalSearchinGrid"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.AllowIncrementalSearchinGrid = Convert.ToBoolean(dr["AllowIncrementalSearchinGrid"]);

						if(!dr["HospitalID"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.HospitalID = Convert.ToInt32(dr["HospitalID"]);

						if(!dr["WeeklyBackupPath"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.WeeklyBackupPath = Convert.ToString(dr["WeeklyBackupPath"]);

						if(!dr["WeeklyBackupPassword"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.WeeklyBackupPassword = Convert.ToString(dr["WeeklyBackupPassword"]);

						if(!dr["IsActive"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.IsActive = Convert.ToBoolean(dr["IsActive"]);

						if(!dr["Remarks"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.Remarks = Convert.ToString(dr["Remarks"]);

						if(!dr["UserID"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.UserID = Convert.ToInt32(dr["UserID"]);

						if(!dr["Created"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.Created = Convert.ToDateTime(dr["Created"]);

						if(!dr["Modified"].Equals(System.DBNull.Value))
							entCFG_SoftwareConfiguration.Modified = Convert.ToDateTime(dr["Modified"]);

					}
				}
				return entCFG_SoftwareConfiguration;
			}
			catch (SqlException sqlex)
			{
				Message = SQLDataExceptionMessage(sqlex);
				if (SQLDataExceptionHandler(sqlex))
					throw;
				return null;
			}
			catch (Exception ex)
			{
				Message = ExceptionMessage(ex);
				if (ExceptionHandler(ex))
					throw;
				return null;
			}
		}
		public DataTable SelectView(SqlInt32 SoftwareConfigurationID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_SoftwareConfiguration_SelectView");

				sqlDB.AddInParameter(dbCMD, "@SoftwareConfigurationID", SqlDbType.Int, SoftwareConfigurationID);

				DataTable dtCFG_SoftwareConfiguration = new DataTable("PR_CFG_SoftwareConfiguration_SelectView");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtCFG_SoftwareConfiguration);

				return dtCFG_SoftwareConfiguration;
			}
			catch (SqlException sqlex)
			{
				Message = SQLDataExceptionMessage(sqlex);
				if (SQLDataExceptionHandler(sqlex))
					throw;
				return null;
			}
			catch (Exception ex)
			{
				Message = ExceptionMessage(ex);
				if (ExceptionHandler(ex))
					throw;
				return null;
			}
		}
		public DataTable SelectAll()
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_SoftwareConfiguration_SelectAll");

				DataTable dtCFG_SoftwareConfiguration = new DataTable("PR_CFG_SoftwareConfiguration_SelectAll");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtCFG_SoftwareConfiguration);

				return dtCFG_SoftwareConfiguration;
			}
			catch (SqlException sqlex)
			{
				Message = SQLDataExceptionMessage(sqlex);
				if (SQLDataExceptionHandler(sqlex))
					throw;
				return null;
			}
			catch (Exception ex)
			{
				Message = ExceptionMessage(ex);
				if (ExceptionHandler(ex))
					throw;
				return null;
			}
		}
		public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords)
		{
			TotalRecords = 0;
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_SoftwareConfiguration_SelectPage");
				sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
				sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
				sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

				DataTable dtCFG_SoftwareConfiguration = new DataTable("PR_CFG_SoftwareConfiguration_SelectPage");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtCFG_SoftwareConfiguration);

				TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

				return dtCFG_SoftwareConfiguration;
			}
			catch (SqlException sqlex)
			{
				Message = SQLDataExceptionMessage(sqlex);
				if (SQLDataExceptionHandler(sqlex))
					throw;
				return null;
			}
			catch (Exception ex)
			{
				Message = ExceptionMessage(ex);
				if (ExceptionHandler(ex))
					throw;
				return null;
			}
		}

		#endregion SelectOperation

		#region ComboBox

		public DataTable SelectComboBox()
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_SoftwareConfiguration_SelectComboBox");

				DataTable dtCFG_SoftwareConfiguration = new DataTable("PR_CFG_SoftwareConfiguration_SelectComboBox");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtCFG_SoftwareConfiguration);

				return dtCFG_SoftwareConfiguration;
			}
			catch (SqlException sqlex)
			{
				Message = SQLDataExceptionMessage(sqlex);
				if (SQLDataExceptionHandler(sqlex))
					throw;
				return null;
			}
			catch (Exception ex)
			{
				Message = ExceptionMessage(ex);
				if (ExceptionHandler(ex))
					throw;
				return null;
			}
		}

		#endregion ComboBox

		#region AutoComplete


		#endregion AutoComplete

	}
}