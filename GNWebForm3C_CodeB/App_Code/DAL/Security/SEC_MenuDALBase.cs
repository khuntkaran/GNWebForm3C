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
	public abstract class SEC_MenuDALBase : DataBaseConfig
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

		public SEC_MenuDALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(SEC_MenuENT entSEC_Menu)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_Menu_Insert");

				sqlDB.AddOutParameter(dbCMD, "@MenuID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@ParentMenuID", SqlDbType.Int, entSEC_Menu.ParentMenuID);
				sqlDB.AddInParameter(dbCMD, "@MenuName", SqlDbType.NVarChar, entSEC_Menu.MenuName);
				sqlDB.AddInParameter(dbCMD, "@MenuDisplayName", SqlDbType.NVarChar, entSEC_Menu.MenuDisplayName);
				sqlDB.AddInParameter(dbCMD, "@FormName", SqlDbType.NVarChar, entSEC_Menu.FormName);
				sqlDB.AddInParameter(dbCMD, "@Sequence", SqlDbType.Int, entSEC_Menu.Sequence);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entSEC_Menu.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entSEC_Menu.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entSEC_Menu.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entSEC_Menu.Modified);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entSEC_Menu.MenuID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@MenuID"].Value);

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

		public Boolean Update(SEC_MenuENT entSEC_Menu)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_Menu_Update");

				sqlDB.AddInParameter(dbCMD, "@MenuID", SqlDbType.Int, entSEC_Menu.MenuID);
				sqlDB.AddInParameter(dbCMD, "@ParentMenuID", SqlDbType.Int, entSEC_Menu.ParentMenuID);
				sqlDB.AddInParameter(dbCMD, "@MenuName", SqlDbType.NVarChar, entSEC_Menu.MenuName);
				sqlDB.AddInParameter(dbCMD, "@MenuDisplayName", SqlDbType.NVarChar, entSEC_Menu.MenuDisplayName);
				sqlDB.AddInParameter(dbCMD, "@FormName", SqlDbType.NVarChar, entSEC_Menu.FormName);
				sqlDB.AddInParameter(dbCMD, "@Sequence", SqlDbType.Int, entSEC_Menu.Sequence);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entSEC_Menu.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entSEC_Menu.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entSEC_Menu.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entSEC_Menu.Modified);

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

		public Boolean Delete(SqlInt32 MenuID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_Menu_Delete");

				sqlDB.AddInParameter(dbCMD, "@MenuID", SqlDbType.Int, MenuID);

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

		public SEC_MenuENT SelectPK(SqlInt32 MenuID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_Menu_SelectPK");

				sqlDB.AddInParameter(dbCMD, "@MenuID", SqlDbType.Int, MenuID);

				SEC_MenuENT entSEC_Menu = new SEC_MenuENT();
				DataBaseHelper DBH = new DataBaseHelper();
				using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
				{
					while (dr.Read())
					{
						if(!dr["MenuID"].Equals(System.DBNull.Value))
							entSEC_Menu.MenuID = Convert.ToInt32(dr["MenuID"]);

						if(!dr["ParentMenuID"].Equals(System.DBNull.Value))
							entSEC_Menu.ParentMenuID = Convert.ToInt32(dr["ParentMenuID"]);

						if(!dr["MenuName"].Equals(System.DBNull.Value))
							entSEC_Menu.MenuName = Convert.ToString(dr["MenuName"]);

						if(!dr["MenuDisplayName"].Equals(System.DBNull.Value))
							entSEC_Menu.MenuDisplayName = Convert.ToString(dr["MenuDisplayName"]);

						if(!dr["FormName"].Equals(System.DBNull.Value))
							entSEC_Menu.FormName = Convert.ToString(dr["FormName"]);

						if(!dr["Sequence"].Equals(System.DBNull.Value))
							entSEC_Menu.Sequence = Convert.ToInt32(dr["Sequence"]);

						if(!dr["Remarks"].Equals(System.DBNull.Value))
							entSEC_Menu.Remarks = Convert.ToString(dr["Remarks"]);

						if(!dr["UserID"].Equals(System.DBNull.Value))
							entSEC_Menu.UserID = Convert.ToInt32(dr["UserID"]);

						if(!dr["Created"].Equals(System.DBNull.Value))
							entSEC_Menu.Created = Convert.ToDateTime(dr["Created"]);

						if(!dr["Modified"].Equals(System.DBNull.Value))
							entSEC_Menu.Modified = Convert.ToDateTime(dr["Modified"]);

					}
				}
				return entSEC_Menu;
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
		public DataTable SelectView(SqlInt32 MenuID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_Menu_SelectView");

				sqlDB.AddInParameter(dbCMD, "@MenuID", SqlDbType.Int, MenuID);

				DataTable dtSEC_Menu = new DataTable("PR_SEC_Menu_SelectView");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtSEC_Menu);

				return dtSEC_Menu;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_Menu_SelectAll");

				DataTable dtSEC_Menu = new DataTable("PR_SEC_Menu_SelectAll");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtSEC_Menu);

				return dtSEC_Menu;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_Menu_SelectPage");
				sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
				sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
				sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

				DataTable dtSEC_Menu = new DataTable("PR_SEC_Menu_SelectPage");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtSEC_Menu);

				TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

				return dtSEC_Menu;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_Menu_SelectComboBox");

				DataTable dtSEC_Menu = new DataTable("PR_SEC_Menu_SelectComboBox");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtSEC_Menu);

				return dtSEC_Menu;
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