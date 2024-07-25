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
	public abstract class MST_ExpenseTypeDALBase : DataBaseConfig
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

		public MST_ExpenseTypeDALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation
		public Boolean Insert(MST_ExpenseTypeENT entMST_ExpenseType)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ExpenseType_Insert");

				sqlDB.AddOutParameter(dbCMD, "@ExpenseTypeID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@ExpenseType", SqlDbType.NVarChar, entMST_ExpenseType.ExpenseType);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entMST_ExpenseType.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entMST_ExpenseType.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_ExpenseType.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_ExpenseType.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_ExpenseType.Modified);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entMST_ExpenseType.ExpenseTypeID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@ExpenseTypeID"].Value);

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

		public Boolean Update(MST_ExpenseTypeENT entMST_ExpenseType)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ExpenseType_Update");

				sqlDB.AddInParameter(dbCMD, "@ExpenseTypeID", SqlDbType.Int, entMST_ExpenseType.ExpenseTypeID);
				sqlDB.AddInParameter(dbCMD, "@ExpenseType", SqlDbType.NVarChar, entMST_ExpenseType.ExpenseType);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entMST_ExpenseType.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entMST_ExpenseType.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_ExpenseType.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_ExpenseType.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_ExpenseType.Modified);

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

        #region UpsertOperation

        public Boolean Upsert(MST_ExpenseTypeENT entMST_ExpenseType)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ExpenseType_UPSERT");

                sqlDB.AddInParameter(dbCMD, "@ExpenseTypeID", SqlDbType.Int, entMST_ExpenseType.ExpenseTypeID);
                sqlDB.AddInParameter(dbCMD, "@ExpenseType", SqlDbType.NVarChar, entMST_ExpenseType.ExpenseType);
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entMST_ExpenseType.HospitalID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entMST_ExpenseType.Remarks);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_ExpenseType.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_ExpenseType.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_ExpenseType.Modified);

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

        #endregion UpsertOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 ExpenseTypeID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ExpenseType_Delete");

				sqlDB.AddInParameter(dbCMD, "@ExpenseTypeID", SqlDbType.Int, ExpenseTypeID);

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

		public MST_ExpenseTypeENT SelectPK(SqlInt32 ExpenseTypeID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ExpenseType_SelectPK");

				sqlDB.AddInParameter(dbCMD, "@ExpenseTypeID", SqlDbType.Int, ExpenseTypeID);

				MST_ExpenseTypeENT entMST_ExpenseType = new MST_ExpenseTypeENT();
				DataBaseHelper DBH = new DataBaseHelper();
				using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
				{
					while (dr.Read())
					{
						if(!dr["ExpenseTypeID"].Equals(System.DBNull.Value))
							entMST_ExpenseType.ExpenseTypeID = Convert.ToInt32(dr["ExpenseTypeID"]);

						if(!dr["ExpenseType"].Equals(System.DBNull.Value))
							entMST_ExpenseType.ExpenseType = Convert.ToString(dr["ExpenseType"]);

						if(!dr["HospitalID"].Equals(System.DBNull.Value))
							entMST_ExpenseType.HospitalID = Convert.ToInt32(dr["HospitalID"]);

						if(!dr["Remarks"].Equals(System.DBNull.Value))
							entMST_ExpenseType.Remarks = Convert.ToString(dr["Remarks"]);

						if(!dr["UserID"].Equals(System.DBNull.Value))
							entMST_ExpenseType.UserID = Convert.ToInt32(dr["UserID"]);

						if(!dr["Created"].Equals(System.DBNull.Value))
							entMST_ExpenseType.Created = Convert.ToDateTime(dr["Created"]);

						if(!dr["Modified"].Equals(System.DBNull.Value))
							entMST_ExpenseType.Modified = Convert.ToDateTime(dr["Modified"]);

					}
				}
				return entMST_ExpenseType;
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
		public DataTable SelectView(SqlInt32 ExpenseTypeID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ExpenseType_SelectView");

				sqlDB.AddInParameter(dbCMD, "@ExpenseTypeID", SqlDbType.Int, ExpenseTypeID);

				DataTable dtMST_ExpenseType = new DataTable("PR_MST_ExpenseType_SelectView");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_ExpenseType);

				return dtMST_ExpenseType;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ExpenseType_SelectAll");

				DataTable dtMST_ExpenseType = new DataTable("PR_MST_ExpenseType_SelectAll");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_ExpenseType);

				return dtMST_ExpenseType;
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
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString ExpenseType, SqlInt32 HospitalID)
		{
			TotalRecords = 0;
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ExpenseType_SelectPage");
				sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
				sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddInParameter(dbCMD, "@ExpenseType", SqlDbType.VarChar, ExpenseType);
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);
				sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

				DataTable dtMST_ExpenseType = new DataTable("PR_MST_ExpenseType_SelectPage");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_ExpenseType);

				TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

				return dtMST_ExpenseType;
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
        public DataTable SelectShow(SqlInt32 HospitalID)
        {
            
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ExpenseType_SelectShow");
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);

                DataTable dtMST_ExpenseTypeShow = new DataTable("PR_MST_ExpenseType_SelectShow");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_ExpenseTypeShow);

                return dtMST_ExpenseTypeShow;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ExpenseType_SelectComboBox");

				DataTable dtMST_ExpenseType = new DataTable("PR_MST_ExpenseType_SelectComboBox");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_ExpenseType);

				return dtMST_ExpenseType;
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

        public DataTable SelectComboBoxByFinYearID(SqlInt32 FinYearID, SqlInt32 HospitalID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_ExpenseType_SelectComboBox");

                sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, FinYearID);
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);

                DataTable dtMST_ExpenseType = new DataTable("PR_ACC_ExpenseType_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_ExpenseType);

                return dtMST_ExpenseType;
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