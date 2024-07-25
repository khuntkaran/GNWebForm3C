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
	public abstract class MST_HospitalDALBase : DataBaseConfig
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

		public MST_HospitalDALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(MST_HospitalENT entMST_Hospital)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Hospital_Insert");

				sqlDB.AddOutParameter(dbCMD, "@HospitalID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@Hospital", SqlDbType.NVarChar, entMST_Hospital.Hospital);
				sqlDB.AddInParameter(dbCMD, "@PrintName", SqlDbType.NVarChar, entMST_Hospital.PrintName);
				sqlDB.AddInParameter(dbCMD, "@PrintLine1", SqlDbType.NVarChar, entMST_Hospital.PrintLine1);
				sqlDB.AddInParameter(dbCMD, "@PrintLine2", SqlDbType.NVarChar, entMST_Hospital.PrintLine2);
				sqlDB.AddInParameter(dbCMD, "@PrintLine3", SqlDbType.NVarChar, entMST_Hospital.PrintLine3);
				sqlDB.AddInParameter(dbCMD, "@FooterName", SqlDbType.NVarChar, entMST_Hospital.FooterName);
				sqlDB.AddInParameter(dbCMD, "@ReportHeaderName", SqlDbType.NVarChar, entMST_Hospital.ReportHeaderName);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entMST_Hospital.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Hospital.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Hospital.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Hospital.Modified);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entMST_Hospital.HospitalID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@HospitalID"].Value);

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

		public Boolean Update(MST_HospitalENT entMST_Hospital)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Hospital_Update");

				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entMST_Hospital.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@Hospital", SqlDbType.NVarChar, entMST_Hospital.Hospital);
				sqlDB.AddInParameter(dbCMD, "@PrintName", SqlDbType.NVarChar, entMST_Hospital.PrintName);
				sqlDB.AddInParameter(dbCMD, "@PrintLine1", SqlDbType.NVarChar, entMST_Hospital.PrintLine1);
				sqlDB.AddInParameter(dbCMD, "@PrintLine2", SqlDbType.NVarChar, entMST_Hospital.PrintLine2);
				sqlDB.AddInParameter(dbCMD, "@PrintLine3", SqlDbType.NVarChar, entMST_Hospital.PrintLine3);
				sqlDB.AddInParameter(dbCMD, "@FooterName", SqlDbType.NVarChar, entMST_Hospital.FooterName);
				sqlDB.AddInParameter(dbCMD, "@ReportHeaderName", SqlDbType.NVarChar, entMST_Hospital.ReportHeaderName);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entMST_Hospital.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Hospital.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Hospital.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Hospital.Modified);

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

		public Boolean Delete(SqlInt32 HospitalID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Hospital_Delete");

				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);

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

		public MST_HospitalENT SelectPK(SqlInt32 HospitalID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Hospital_SelectPK");

				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);

				MST_HospitalENT entMST_Hospital = new MST_HospitalENT();
				DataBaseHelper DBH = new DataBaseHelper();
				using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
				{
					while (dr.Read())
					{
						if(!dr["HospitalID"].Equals(System.DBNull.Value))
							entMST_Hospital.HospitalID = Convert.ToInt32(dr["HospitalID"]);

						if(!dr["Hospital"].Equals(System.DBNull.Value))
							entMST_Hospital.Hospital = Convert.ToString(dr["Hospital"]);

						if(!dr["PrintName"].Equals(System.DBNull.Value))
							entMST_Hospital.PrintName = Convert.ToString(dr["PrintName"]);

						if(!dr["PrintLine1"].Equals(System.DBNull.Value))
							entMST_Hospital.PrintLine1 = Convert.ToString(dr["PrintLine1"]);

						if(!dr["PrintLine2"].Equals(System.DBNull.Value))
							entMST_Hospital.PrintLine2 = Convert.ToString(dr["PrintLine2"]);

						if(!dr["PrintLine3"].Equals(System.DBNull.Value))
							entMST_Hospital.PrintLine3 = Convert.ToString(dr["PrintLine3"]);

						if(!dr["FooterName"].Equals(System.DBNull.Value))
							entMST_Hospital.FooterName = Convert.ToString(dr["FooterName"]);

						if(!dr["ReportHeaderName"].Equals(System.DBNull.Value))
							entMST_Hospital.ReportHeaderName = Convert.ToString(dr["ReportHeaderName"]);

						if(!dr["Remarks"].Equals(System.DBNull.Value))
							entMST_Hospital.Remarks = Convert.ToString(dr["Remarks"]);

						if(!dr["UserID"].Equals(System.DBNull.Value))
							entMST_Hospital.UserID = Convert.ToInt32(dr["UserID"]);

						if(!dr["Created"].Equals(System.DBNull.Value))
							entMST_Hospital.Created = Convert.ToDateTime(dr["Created"]);

						if(!dr["Modified"].Equals(System.DBNull.Value))
							entMST_Hospital.Modified = Convert.ToDateTime(dr["Modified"]);

					}
				}
				return entMST_Hospital;
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
		public DataTable SelectView(SqlInt32 HospitalID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Hospital_SelectView");

				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);

				DataTable dtMST_Hospital = new DataTable("PR_MST_Hospital_SelectView");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Hospital);

				return dtMST_Hospital;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Hospital_SelectAll");

				DataTable dtMST_Hospital = new DataTable("PR_MST_Hospital_SelectAll");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Hospital);

				return dtMST_Hospital;
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
		public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString Hospital, SqlString PrintName, SqlString PrintLine1, SqlString PrintLine2, SqlString PrintLine3, SqlString FooterName, SqlString ReportHeaderName)
		{
			TotalRecords = 0;
			try 
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Hospital_SelectPage");
				sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
				sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
				sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@Hospital", SqlDbType.NVarChar, Hospital);
                sqlDB.AddInParameter(dbCMD, "@PrintName", SqlDbType.NVarChar, PrintName);
                sqlDB.AddInParameter(dbCMD, "@PrintLine1", SqlDbType.NVarChar, PrintLine1);
                sqlDB.AddInParameter(dbCMD, "@PrintLine2", SqlDbType.NVarChar, PrintLine2);
                sqlDB.AddInParameter(dbCMD, "@PrintLine3", SqlDbType.NVarChar, PrintLine3);
                sqlDB.AddInParameter(dbCMD, "@FooterName", SqlDbType.NVarChar, FooterName);
                sqlDB.AddInParameter(dbCMD, "@ReportHeaderName", SqlDbType.NVarChar, ReportHeaderName);

				DataTable dtMST_Hospital = new DataTable("PR_MST_Hospital_SelectPage");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Hospital);

				TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

				return dtMST_Hospital;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Hospital_SelectComboBox");

				DataTable dtMST_Hospital = new DataTable("PR_MST_Hospital_SelectComboBox");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Hospital);

				return dtMST_Hospital;
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