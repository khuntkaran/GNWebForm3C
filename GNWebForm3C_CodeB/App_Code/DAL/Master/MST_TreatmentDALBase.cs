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
	public abstract class MST_TreatmentDALBase : DataBaseConfig
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

		public MST_TreatmentDALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(MST_TreatmentENT entMST_Treatment)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Treatment_Insert");

				sqlDB.AddOutParameter(dbCMD, "@TreatmentID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@Treatment", SqlDbType.NVarChar, entMST_Treatment.Treatment);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entMST_Treatment.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entMST_Treatment.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Treatment.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Treatment.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Treatment.Modified);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entMST_Treatment.TreatmentID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@TreatmentID"].Value);

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

		public Boolean Update(MST_TreatmentENT entMST_Treatment)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Treatment_Update");

				sqlDB.AddInParameter(dbCMD, "@TreatmentID", SqlDbType.Int, entMST_Treatment.TreatmentID);
				sqlDB.AddInParameter(dbCMD, "@Treatment", SqlDbType.NVarChar, entMST_Treatment.Treatment);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entMST_Treatment.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entMST_Treatment.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Treatment.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Treatment.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Treatment.Modified);

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

		public Boolean Delete(SqlInt32 TreatmentID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Treatment_Delete");

				sqlDB.AddInParameter(dbCMD, "@TreatmentID", SqlDbType.Int, TreatmentID);

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

		public MST_TreatmentENT SelectPK(SqlInt32 TreatmentID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Treatment_SelectPK");

				sqlDB.AddInParameter(dbCMD, "@TreatmentID", SqlDbType.Int, TreatmentID);

				MST_TreatmentENT entMST_Treatment = new MST_TreatmentENT();
				DataBaseHelper DBH = new DataBaseHelper();
				using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
				{
					while (dr.Read())
					{
						if(!dr["TreatmentID"].Equals(System.DBNull.Value))
							entMST_Treatment.TreatmentID = Convert.ToInt32(dr["TreatmentID"]);

						if(!dr["Treatment"].Equals(System.DBNull.Value))
							entMST_Treatment.Treatment = Convert.ToString(dr["Treatment"]);

						if(!dr["HospitalID"].Equals(System.DBNull.Value))
							entMST_Treatment.HospitalID = Convert.ToInt32(dr["HospitalID"]);

						if(!dr["Remarks"].Equals(System.DBNull.Value))
							entMST_Treatment.Remarks = Convert.ToString(dr["Remarks"]);

						if(!dr["UserID"].Equals(System.DBNull.Value))
							entMST_Treatment.UserID = Convert.ToInt32(dr["UserID"]);

						if(!dr["Created"].Equals(System.DBNull.Value))
							entMST_Treatment.Created = Convert.ToDateTime(dr["Created"]);

						if(!dr["Modified"].Equals(System.DBNull.Value))
							entMST_Treatment.Modified = Convert.ToDateTime(dr["Modified"]);

					}
				}
				return entMST_Treatment;
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
		public DataTable SelectView(SqlInt32 TreatmentID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Treatment_SelectView");

				sqlDB.AddInParameter(dbCMD, "@TreatmentID", SqlDbType.Int, TreatmentID);

				DataTable dtMST_Treatment = new DataTable("PR_MST_Treatment_SelectView");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Treatment);

				return dtMST_Treatment;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Treatment_SelectAll");

				DataTable dtMST_Treatment = new DataTable("PR_MST_Treatment_SelectAll");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Treatment);

				return dtMST_Treatment;
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
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString Treatment, SqlInt32 HospitalID)
		{
			TotalRecords = 0;
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Treatment_SelectPage");
				sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
				sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddInParameter(dbCMD, "@Treatment", SqlDbType.NVarChar, Treatment);
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);
				sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

				DataTable dtMST_Treatment = new DataTable("PR_MST_Treatment_SelectPage");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Treatment);

				TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

				return dtMST_Treatment;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Treatment_SelectComboBox");

				DataTable dtMST_Treatment = new DataTable("PR_MST_Treatment_SelectComboBox");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Treatment);

				return dtMST_Treatment;
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