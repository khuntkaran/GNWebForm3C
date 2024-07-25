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
	public abstract class MST_SubTreatmentDALBase : DataBaseConfig
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

		public MST_SubTreatmentDALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(MST_SubTreatmentENT entMST_SubTreatment)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_SubTreatment_Insert");

				sqlDB.AddOutParameter(dbCMD, "@SubTreatmentID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@SubTreatmentName", SqlDbType.NVarChar, entMST_SubTreatment.SubTreatmentName);
				sqlDB.AddInParameter(dbCMD, "@SequenceNo", SqlDbType.Int, entMST_SubTreatment.SequenceNo);
				sqlDB.AddInParameter(dbCMD, "@Rate", SqlDbType.Decimal, entMST_SubTreatment.Rate);
				sqlDB.AddInParameter(dbCMD, "@IsInGrid", SqlDbType.Bit, entMST_SubTreatment.IsInGrid);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entMST_SubTreatment.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@IsPerDay", SqlDbType.Bit, entMST_SubTreatment.IsPerDay);
				sqlDB.AddInParameter(dbCMD, "@DefaultUnit", SqlDbType.NVarChar, entMST_SubTreatment.DefaultUnit);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entMST_SubTreatment.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_SubTreatment.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_SubTreatment.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_SubTreatment.Modified);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entMST_SubTreatment.SubTreatmentID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@SubTreatmentID"].Value);

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

		public Boolean Update(MST_SubTreatmentENT entMST_SubTreatment)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_SubTreatment_Update");

				sqlDB.AddInParameter(dbCMD, "@SubTreatmentID", SqlDbType.Int, entMST_SubTreatment.SubTreatmentID);
				sqlDB.AddInParameter(dbCMD, "@SubTreatmentName", SqlDbType.NVarChar, entMST_SubTreatment.SubTreatmentName);
				sqlDB.AddInParameter(dbCMD, "@SequenceNo", SqlDbType.Int, entMST_SubTreatment.SequenceNo);
				sqlDB.AddInParameter(dbCMD, "@Rate", SqlDbType.Decimal, entMST_SubTreatment.Rate);
				sqlDB.AddInParameter(dbCMD, "@IsInGrid", SqlDbType.Bit, entMST_SubTreatment.IsInGrid);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entMST_SubTreatment.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@IsPerDay", SqlDbType.Bit, entMST_SubTreatment.IsPerDay);
				sqlDB.AddInParameter(dbCMD, "@DefaultUnit", SqlDbType.NVarChar, entMST_SubTreatment.DefaultUnit);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entMST_SubTreatment.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_SubTreatment.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_SubTreatment.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_SubTreatment.Modified);

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

		public Boolean Delete(SqlInt32 SubTreatmentID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_SubTreatment_Delete");

				sqlDB.AddInParameter(dbCMD, "@SubTreatmentID", SqlDbType.Int, SubTreatmentID);

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

		public MST_SubTreatmentENT SelectPK(SqlInt32 SubTreatmentID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_SubTreatment_SelectPK");

				sqlDB.AddInParameter(dbCMD, "@SubTreatmentID", SqlDbType.Int, SubTreatmentID);

				MST_SubTreatmentENT entMST_SubTreatment = new MST_SubTreatmentENT();
				DataBaseHelper DBH = new DataBaseHelper();
				using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
				{
					while (dr.Read())
					{
						if(!dr["SubTreatmentID"].Equals(System.DBNull.Value))
							entMST_SubTreatment.SubTreatmentID = Convert.ToInt32(dr["SubTreatmentID"]);

						if(!dr["SubTreatmentName"].Equals(System.DBNull.Value))
							entMST_SubTreatment.SubTreatmentName = Convert.ToString(dr["SubTreatmentName"]);

						if(!dr["SequenceNo"].Equals(System.DBNull.Value))
							entMST_SubTreatment.SequenceNo = Convert.ToInt32(dr["SequenceNo"]);

						if(!dr["Rate"].Equals(System.DBNull.Value))
							entMST_SubTreatment.Rate = Convert.ToDecimal(dr["Rate"]);

						if(!dr["IsInGrid"].Equals(System.DBNull.Value))
							entMST_SubTreatment.IsInGrid = Convert.ToBoolean(dr["IsInGrid"]);

						if(!dr["HospitalID"].Equals(System.DBNull.Value))
							entMST_SubTreatment.HospitalID = Convert.ToInt32(dr["HospitalID"]);

						if(!dr["IsPerDay"].Equals(System.DBNull.Value))
							entMST_SubTreatment.IsPerDay = Convert.ToBoolean(dr["IsPerDay"]);

						if(!dr["DefaultUnit"].Equals(System.DBNull.Value))
							entMST_SubTreatment.DefaultUnit = Convert.ToString(dr["DefaultUnit"]);

						if(!dr["Remarks"].Equals(System.DBNull.Value))
							entMST_SubTreatment.Remarks = Convert.ToString(dr["Remarks"]);

						if(!dr["UserID"].Equals(System.DBNull.Value))
							entMST_SubTreatment.UserID = Convert.ToInt32(dr["UserID"]);

						if(!dr["Created"].Equals(System.DBNull.Value))
							entMST_SubTreatment.Created = Convert.ToDateTime(dr["Created"]);

						if(!dr["Modified"].Equals(System.DBNull.Value))
							entMST_SubTreatment.Modified = Convert.ToDateTime(dr["Modified"]);

					}
				}
				return entMST_SubTreatment;
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
		public DataTable SelectView(SqlInt32 SubTreatmentID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_SubTreatment_SelectView");

				sqlDB.AddInParameter(dbCMD, "@SubTreatmentID", SqlDbType.Int, SubTreatmentID);

				DataTable dtMST_SubTreatment = new DataTable("PR_MST_SubTreatment_SelectView");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_SubTreatment);

				return dtMST_SubTreatment;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_SubTreatment_SelectAll");

				DataTable dtMST_SubTreatment = new DataTable("PR_MST_SubTreatment_SelectAll");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_SubTreatment);

				return dtMST_SubTreatment;
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
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString SubTreatmentName, SqlInt32 SequenceNo, SqlDecimal Rate, SqlInt32 HospitalID, SqlString DefaultUnit)
		{
			TotalRecords = 0;
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_SubTreatment_SelectPage");
				sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
				sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);

                sqlDB.AddInParameter(dbCMD, "@SubTreatmentName", SqlDbType.NVarChar, SubTreatmentName);
                sqlDB.AddInParameter(dbCMD, "@SequenceNo", SqlDbType.Int, SequenceNo);
                sqlDB.AddInParameter(dbCMD, "@Rate", SqlDbType.Decimal, Rate);
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);
                sqlDB.AddInParameter(dbCMD, "@DefaultUnit", SqlDbType.VarChar, DefaultUnit);

				sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

				DataTable dtMST_SubTreatment = new DataTable("PR_MST_SubTreatment_SelectPage");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_SubTreatment);

				TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

				return dtMST_SubTreatment;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_SubTreatment_SelectComboBox");

				DataTable dtMST_SubTreatment = new DataTable("PR_MST_SubTreatment_SelectComboBox");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_SubTreatment);

				return dtMST_SubTreatment;
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