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
	public abstract class MST_FinYearDALBase : DataBaseConfig
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

		public MST_FinYearDALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(MST_FinYearENT entMST_FinYear)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_FinYear_Insert");

				sqlDB.AddOutParameter(dbCMD, "@FinYearID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@FinYearName", SqlDbType.NVarChar, entMST_FinYear.FinYearName);
				sqlDB.AddInParameter(dbCMD, "@FromDate", SqlDbType.DateTime, entMST_FinYear.FromDate);
				sqlDB.AddInParameter(dbCMD, "@ToDate", SqlDbType.DateTime, entMST_FinYear.ToDate);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entMST_FinYear.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_FinYear.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_FinYear.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_FinYear.Modified);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entMST_FinYear.FinYearID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@FinYearID"].Value);

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

		public Boolean Update(MST_FinYearENT entMST_FinYear)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_FinYear_Update");

				sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, entMST_FinYear.FinYearID);
				sqlDB.AddInParameter(dbCMD, "@FinYearName", SqlDbType.NVarChar, entMST_FinYear.FinYearName);
				sqlDB.AddInParameter(dbCMD, "@FromDate", SqlDbType.DateTime, entMST_FinYear.FromDate);
				sqlDB.AddInParameter(dbCMD, "@ToDate", SqlDbType.DateTime, entMST_FinYear.ToDate);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entMST_FinYear.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_FinYear.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_FinYear.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_FinYear.Modified);

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

		public Boolean Delete(SqlInt32 FinYearID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_FinYear_Delete");

				sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, FinYearID);

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

		public MST_FinYearENT SelectPK(SqlInt32 FinYearID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_FinYear_SelectPK");

				sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, FinYearID);

				MST_FinYearENT entMST_FinYear = new MST_FinYearENT();
				DataBaseHelper DBH = new DataBaseHelper();
				using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
				{
					while (dr.Read())
					{
						if(!dr["FinYearID"].Equals(System.DBNull.Value))
							entMST_FinYear.FinYearID = Convert.ToInt32(dr["FinYearID"]);

						if(!dr["FinYearName"].Equals(System.DBNull.Value))
							entMST_FinYear.FinYearName = Convert.ToString(dr["FinYearName"]);

						if(!dr["FromDate"].Equals(System.DBNull.Value))
							entMST_FinYear.FromDate = Convert.ToDateTime(dr["FromDate"]);

						if(!dr["ToDate"].Equals(System.DBNull.Value))
							entMST_FinYear.ToDate = Convert.ToDateTime(dr["ToDate"]);

						if(!dr["Remarks"].Equals(System.DBNull.Value))
							entMST_FinYear.Remarks = Convert.ToString(dr["Remarks"]);

						if(!dr["UserID"].Equals(System.DBNull.Value))
							entMST_FinYear.UserID = Convert.ToInt32(dr["UserID"]);

						if(!dr["Created"].Equals(System.DBNull.Value))
							entMST_FinYear.Created = Convert.ToDateTime(dr["Created"]);

						if(!dr["Modified"].Equals(System.DBNull.Value))
							entMST_FinYear.Modified = Convert.ToDateTime(dr["Modified"]);

					}
				}
				return entMST_FinYear;
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
		public DataTable SelectView(SqlInt32 FinYearID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_FinYear_SelectView");

				sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, FinYearID);

				DataTable dtMST_FinYear = new DataTable("PR_MST_FinYear_SelectView");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_FinYear);

				return dtMST_FinYear;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_FinYear_SelectAll");

				DataTable dtMST_FinYear = new DataTable("PR_MST_FinYear_SelectAll");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_FinYear);

				return dtMST_FinYear;
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
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString FinYearName, SqlDateTime FromDate, SqlDateTime ToDate)
		{
			TotalRecords = 0;
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_FinYear_SelectPage");
				sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddInParameter(dbCMD, "@FinYearName", SqlDbType.VarChar, FinYearName);
                sqlDB.AddInParameter(dbCMD, "@FromDate", SqlDbType.DateTime, FromDate);
                sqlDB.AddInParameter(dbCMD, "@ToDate", SqlDbType.DateTime, ToDate);
				sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

				DataTable dtMST_FinYear = new DataTable("PR_MST_FinYear_SelectPage"); 

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_FinYear);

				TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

				return dtMST_FinYear;
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

        public DataTable SelectComboBoxByHospitalIDExpense(SqlInt32 HospitalID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_FinYear_SelectComboBoxByHospitalID");

                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);

                DataTable dtMST_FinYear = new DataTable("PR_ACC_FinYear_SelectComboBoxByHospitalID");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_FinYear);

				return dtMST_FinYear;
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

        public DataTable SelectComboBoxByHospitalID(SqlInt32 HospitalID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_FinYear_SelectComboBox");

                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);

				DataTable dtMST_FinYear = new DataTable("PR_ACC_FinYear_SelectComboBox");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_FinYear);

				return dtMST_FinYear;
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

        public DataTable SelectSingleComboBox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_FinYear_SelectComboBox");

                DataTable dtMST_FinYear = new DataTable("PR_MST_FinYear_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_FinYear);

                return dtMST_FinYear;
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