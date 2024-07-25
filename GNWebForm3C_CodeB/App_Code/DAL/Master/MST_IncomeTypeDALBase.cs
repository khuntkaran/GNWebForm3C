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
	public abstract class MST_IncomeTypeDALBase : DataBaseConfig
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

		public MST_IncomeTypeDALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(MST_IncomeTypeENT entMST_IncomeType)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_IncomeType_Insert");

				sqlDB.AddOutParameter(dbCMD, "@IncomeTypeID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@IncomeType", SqlDbType.NVarChar, entMST_IncomeType.IncomeType);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entMST_IncomeType.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entMST_IncomeType.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_IncomeType.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_IncomeType.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_IncomeType.Modified);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entMST_IncomeType.IncomeTypeID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@IncomeTypeID"].Value);

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

		public Boolean Update(MST_IncomeTypeENT entMST_IncomeType)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_IncomeType_Update");

				sqlDB.AddInParameter(dbCMD, "@IncomeTypeID", SqlDbType.Int, entMST_IncomeType.IncomeTypeID);
				sqlDB.AddInParameter(dbCMD, "@IncomeType", SqlDbType.NVarChar, entMST_IncomeType.IncomeType);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entMST_IncomeType.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entMST_IncomeType.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_IncomeType.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_IncomeType.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_IncomeType.Modified);

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

		public Boolean Delete(SqlInt32 IncomeTypeID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_IncomeType_Delete");

				sqlDB.AddInParameter(dbCMD, "@IncomeTypeID", SqlDbType.Int, IncomeTypeID);

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

		public MST_IncomeTypeENT SelectPK(SqlInt32 IncomeTypeID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_IncomeType_SelectPK");

				sqlDB.AddInParameter(dbCMD, "@IncomeTypeID", SqlDbType.Int, IncomeTypeID);

				MST_IncomeTypeENT entMST_IncomeType = new MST_IncomeTypeENT();
				DataBaseHelper DBH = new DataBaseHelper();
				using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
				{
					while (dr.Read())
					{
						if(!dr["IncomeTypeID"].Equals(System.DBNull.Value))
							entMST_IncomeType.IncomeTypeID = Convert.ToInt32(dr["IncomeTypeID"]);

						if(!dr["IncomeType"].Equals(System.DBNull.Value))
							entMST_IncomeType.IncomeType = Convert.ToString(dr["IncomeType"]);

						if(!dr["HospitalID"].Equals(System.DBNull.Value))
							entMST_IncomeType.HospitalID = Convert.ToInt32(dr["HospitalID"]);

						if(!dr["Remarks"].Equals(System.DBNull.Value))
							entMST_IncomeType.Remarks = Convert.ToString(dr["Remarks"]);

						if(!dr["UserID"].Equals(System.DBNull.Value))
							entMST_IncomeType.UserID = Convert.ToInt32(dr["UserID"]);

						if(!dr["Created"].Equals(System.DBNull.Value))
							entMST_IncomeType.Created = Convert.ToDateTime(dr["Created"]);

						if(!dr["Modified"].Equals(System.DBNull.Value))
							entMST_IncomeType.Modified = Convert.ToDateTime(dr["Modified"]);

					}
				}
				return entMST_IncomeType;
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
		public DataTable SelectView(SqlInt32 IncomeTypeID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_IncomeType_SelectView");

				sqlDB.AddInParameter(dbCMD, "@IncomeTypeID", SqlDbType.Int, IncomeTypeID);

				DataTable dtMST_IncomeType = new DataTable("PR_MST_IncomeType_SelectView");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_IncomeType);

				return dtMST_IncomeType;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_IncomeType_SelectAll");

				DataTable dtMST_IncomeType = new DataTable("PR_MST_IncomeType_SelectAll");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_IncomeType);

				return dtMST_IncomeType;
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
		public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords , SqlString IncomeType , SqlInt32 HospitalID)
		{
			TotalRecords = 0;
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_IncomeType_SelectPage");
				sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddInParameter(dbCMD, "@IncomeType", SqlDbType.VarChar, IncomeType);
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);
				sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

				DataTable dtMST_IncomeType = new DataTable("PR_MST_IncomeType_SelectPage");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_IncomeType);

				TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

				return dtMST_IncomeType;
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

        public DataTable SelectComboBoxByFinYearID(SqlInt32 FinYearID, SqlInt32 HospitalID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_IncomeType_SelectComboBox");

                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);
                sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, FinYearID);

                DataTable dtMST_IncomeType = new DataTable("PR_ACC_IncomeType_SelectComboBox");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_IncomeType);

				return dtMST_IncomeType;
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

        public DataTable SelectComboBox()
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_IncomeType_SelectComboBox");

                DataTable dtMST_IncomeType = new DataTable("PR_MST_IncomeType_SelectComboBox");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_IncomeType);

				return dtMST_IncomeType;
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