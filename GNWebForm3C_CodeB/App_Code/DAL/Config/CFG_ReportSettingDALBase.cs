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
	public abstract class CFG_ReportSettingDALBase : DataBaseConfig
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

		public CFG_ReportSettingDALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(CFG_ReportSettingENT entCFG_ReportSetting)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_ReportSetting_Insert");

				sqlDB.AddOutParameter(dbCMD, "@ReportSettingID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@ReportHeaderFontType", SqlDbType.NVarChar, entCFG_ReportSetting.ReportHeaderFontType);
				sqlDB.AddInParameter(dbCMD, "@ReportHeaderFontSize", SqlDbType.Decimal, entCFG_ReportSetting.ReportHeaderFontSize);
				sqlDB.AddInParameter(dbCMD, "@ReportHeaderFontStyle", SqlDbType.NVarChar, entCFG_ReportSetting.ReportHeaderFontStyle);
				sqlDB.AddInParameter(dbCMD, "@TableHeaderFontType", SqlDbType.NVarChar, entCFG_ReportSetting.TableHeaderFontType);
				sqlDB.AddInParameter(dbCMD, "@TableHeaderFontSize", SqlDbType.Decimal, entCFG_ReportSetting.TableHeaderFontSize);
				sqlDB.AddInParameter(dbCMD, "@TableHeaderFontStyle", SqlDbType.NVarChar, entCFG_ReportSetting.TableHeaderFontStyle);
				sqlDB.AddInParameter(dbCMD, "@TableRowFontType", SqlDbType.NVarChar, entCFG_ReportSetting.TableRowFontType);
				sqlDB.AddInParameter(dbCMD, "@TableRowFontSize", SqlDbType.Decimal, entCFG_ReportSetting.TableRowFontSize);
				sqlDB.AddInParameter(dbCMD, "@TableRowFontStyle", SqlDbType.NVarChar, entCFG_ReportSetting.TableRowFontStyle);
				sqlDB.AddInParameter(dbCMD, "@FooterFontType", SqlDbType.NVarChar, entCFG_ReportSetting.FooterFontType);
				sqlDB.AddInParameter(dbCMD, "@FooterFontSize", SqlDbType.Decimal, entCFG_ReportSetting.FooterFontSize);
				sqlDB.AddInParameter(dbCMD, "@FooterFontStyle", SqlDbType.NVarChar, entCFG_ReportSetting.FooterFontStyle);
				sqlDB.AddInParameter(dbCMD, "@IsPrintDate", SqlDbType.Bit, entCFG_ReportSetting.IsPrintDate);
				sqlDB.AddInParameter(dbCMD, "@IsPrintDateWithTime", SqlDbType.Bit, entCFG_ReportSetting.IsPrintDateWithTime);
				sqlDB.AddInParameter(dbCMD, "@IsPrintUserName", SqlDbType.Bit, entCFG_ReportSetting.IsPrintUserName);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entCFG_ReportSetting.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entCFG_ReportSetting.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entCFG_ReportSetting.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entCFG_ReportSetting.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entCFG_ReportSetting.Modified);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entCFG_ReportSetting.ReportSettingID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@ReportSettingID"].Value);

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

		public Boolean Update(CFG_ReportSettingENT entCFG_ReportSetting)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_ReportSetting_Update");

				sqlDB.AddInParameter(dbCMD, "@ReportSettingID", SqlDbType.Int, entCFG_ReportSetting.ReportSettingID);
				sqlDB.AddInParameter(dbCMD, "@ReportHeaderFontType", SqlDbType.NVarChar, entCFG_ReportSetting.ReportHeaderFontType);
				sqlDB.AddInParameter(dbCMD, "@ReportHeaderFontSize", SqlDbType.Decimal, entCFG_ReportSetting.ReportHeaderFontSize);
				sqlDB.AddInParameter(dbCMD, "@ReportHeaderFontStyle", SqlDbType.NVarChar, entCFG_ReportSetting.ReportHeaderFontStyle);
				sqlDB.AddInParameter(dbCMD, "@TableHeaderFontType", SqlDbType.NVarChar, entCFG_ReportSetting.TableHeaderFontType);
				sqlDB.AddInParameter(dbCMD, "@TableHeaderFontSize", SqlDbType.Decimal, entCFG_ReportSetting.TableHeaderFontSize);
				sqlDB.AddInParameter(dbCMD, "@TableHeaderFontStyle", SqlDbType.NVarChar, entCFG_ReportSetting.TableHeaderFontStyle);
				sqlDB.AddInParameter(dbCMD, "@TableRowFontType", SqlDbType.NVarChar, entCFG_ReportSetting.TableRowFontType);
				sqlDB.AddInParameter(dbCMD, "@TableRowFontSize", SqlDbType.Decimal, entCFG_ReportSetting.TableRowFontSize);
				sqlDB.AddInParameter(dbCMD, "@TableRowFontStyle", SqlDbType.NVarChar, entCFG_ReportSetting.TableRowFontStyle);
				sqlDB.AddInParameter(dbCMD, "@FooterFontType", SqlDbType.NVarChar, entCFG_ReportSetting.FooterFontType);
				sqlDB.AddInParameter(dbCMD, "@FooterFontSize", SqlDbType.Decimal, entCFG_ReportSetting.FooterFontSize);
				sqlDB.AddInParameter(dbCMD, "@FooterFontStyle", SqlDbType.NVarChar, entCFG_ReportSetting.FooterFontStyle);
				sqlDB.AddInParameter(dbCMD, "@IsPrintDate", SqlDbType.Bit, entCFG_ReportSetting.IsPrintDate);
				sqlDB.AddInParameter(dbCMD, "@IsPrintDateWithTime", SqlDbType.Bit, entCFG_ReportSetting.IsPrintDateWithTime);
				sqlDB.AddInParameter(dbCMD, "@IsPrintUserName", SqlDbType.Bit, entCFG_ReportSetting.IsPrintUserName);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entCFG_ReportSetting.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entCFG_ReportSetting.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entCFG_ReportSetting.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entCFG_ReportSetting.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entCFG_ReportSetting.Modified);

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

		public Boolean Delete(SqlInt32 ReportSettingID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_ReportSetting_Delete");

				sqlDB.AddInParameter(dbCMD, "@ReportSettingID", SqlDbType.Int, ReportSettingID);

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

		public CFG_ReportSettingENT SelectPK(SqlInt32 ReportSettingID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_ReportSetting_SelectPK");

				sqlDB.AddInParameter(dbCMD, "@ReportSettingID", SqlDbType.Int, ReportSettingID);

				CFG_ReportSettingENT entCFG_ReportSetting = new CFG_ReportSettingENT();
				DataBaseHelper DBH = new DataBaseHelper();
				using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
				{
					while (dr.Read())
					{
						if(!dr["ReportSettingID"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.ReportSettingID = Convert.ToInt32(dr["ReportSettingID"]);

						if(!dr["ReportHeaderFontType"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.ReportHeaderFontType = Convert.ToString(dr["ReportHeaderFontType"]);

						if(!dr["ReportHeaderFontSize"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.ReportHeaderFontSize = Convert.ToDecimal(dr["ReportHeaderFontSize"]);

						if(!dr["ReportHeaderFontStyle"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.ReportHeaderFontStyle = Convert.ToString(dr["ReportHeaderFontStyle"]);

						if(!dr["TableHeaderFontType"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.TableHeaderFontType = Convert.ToString(dr["TableHeaderFontType"]);

						if(!dr["TableHeaderFontSize"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.TableHeaderFontSize = Convert.ToDecimal(dr["TableHeaderFontSize"]);

						if(!dr["TableHeaderFontStyle"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.TableHeaderFontStyle = Convert.ToString(dr["TableHeaderFontStyle"]);

						if(!dr["TableRowFontType"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.TableRowFontType = Convert.ToString(dr["TableRowFontType"]);

						if(!dr["TableRowFontSize"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.TableRowFontSize = Convert.ToDecimal(dr["TableRowFontSize"]);

						if(!dr["TableRowFontStyle"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.TableRowFontStyle = Convert.ToString(dr["TableRowFontStyle"]);

						if(!dr["FooterFontType"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.FooterFontType = Convert.ToString(dr["FooterFontType"]);

						if(!dr["FooterFontSize"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.FooterFontSize = Convert.ToDecimal(dr["FooterFontSize"]);

						if(!dr["FooterFontStyle"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.FooterFontStyle = Convert.ToString(dr["FooterFontStyle"]);

						if(!dr["IsPrintDate"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.IsPrintDate = Convert.ToBoolean(dr["IsPrintDate"]);

						if(!dr["IsPrintDateWithTime"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.IsPrintDateWithTime = Convert.ToBoolean(dr["IsPrintDateWithTime"]);

						if(!dr["IsPrintUserName"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.IsPrintUserName = Convert.ToBoolean(dr["IsPrintUserName"]);

						if(!dr["HospitalID"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.HospitalID = Convert.ToInt32(dr["HospitalID"]);

						if(!dr["Remarks"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.Remarks = Convert.ToString(dr["Remarks"]);

						if(!dr["UserID"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.UserID = Convert.ToInt32(dr["UserID"]);

						if(!dr["Created"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.Created = Convert.ToDateTime(dr["Created"]);

						if(!dr["Modified"].Equals(System.DBNull.Value))
							entCFG_ReportSetting.Modified = Convert.ToDateTime(dr["Modified"]);

					}
				}
				return entCFG_ReportSetting;
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
		public DataTable SelectView(SqlInt32 ReportSettingID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_ReportSetting_SelectView");

				sqlDB.AddInParameter(dbCMD, "@ReportSettingID", SqlDbType.Int, ReportSettingID);

				DataTable dtCFG_ReportSetting = new DataTable("PR_CFG_ReportSetting_SelectView");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtCFG_ReportSetting);

				return dtCFG_ReportSetting;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_ReportSetting_SelectAll");

				DataTable dtCFG_ReportSetting = new DataTable("PR_CFG_ReportSetting_SelectAll");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtCFG_ReportSetting);

				return dtCFG_ReportSetting;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_ReportSetting_SelectPage");
				sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
				sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
				sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

				DataTable dtCFG_ReportSetting = new DataTable("PR_CFG_ReportSetting_SelectPage");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtCFG_ReportSetting);

				TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

				return dtCFG_ReportSetting;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CFG_ReportSetting_SelectComboBox");

				DataTable dtCFG_ReportSetting = new DataTable("PR_CFG_ReportSetting_SelectComboBox");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtCFG_ReportSetting);

				return dtCFG_ReportSetting;
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