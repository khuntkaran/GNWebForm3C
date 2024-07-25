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
	public abstract class MST_ReceiptTypeDALBase : DataBaseConfig
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

		public MST_ReceiptTypeDALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(MST_ReceiptTypeENT entMST_ReceiptType)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ReceiptType_Insert");

				sqlDB.AddOutParameter(dbCMD, "@ReceiptTypeID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@ReceiptTypeName", SqlDbType.NVarChar, entMST_ReceiptType.ReceiptTypeName);
				sqlDB.AddInParameter(dbCMD, "@PrintName", SqlDbType.NVarChar, entMST_ReceiptType.PrintName);
				sqlDB.AddInParameter(dbCMD, "@IsDefault", SqlDbType.Bit, entMST_ReceiptType.IsDefault);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entMST_ReceiptType.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entMST_ReceiptType.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_ReceiptType.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_ReceiptType.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_ReceiptType.Modified);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entMST_ReceiptType.ReceiptTypeID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@ReceiptTypeID"].Value);

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

		public Boolean Update(MST_ReceiptTypeENT entMST_ReceiptType)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ReceiptType_Update");

				sqlDB.AddInParameter(dbCMD, "@ReceiptTypeID", SqlDbType.Int, entMST_ReceiptType.ReceiptTypeID);
				sqlDB.AddInParameter(dbCMD, "@ReceiptTypeName", SqlDbType.NVarChar, entMST_ReceiptType.ReceiptTypeName);
				sqlDB.AddInParameter(dbCMD, "@PrintName", SqlDbType.NVarChar, entMST_ReceiptType.PrintName);
				sqlDB.AddInParameter(dbCMD, "@IsDefault", SqlDbType.Bit, entMST_ReceiptType.IsDefault);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entMST_ReceiptType.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entMST_ReceiptType.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_ReceiptType.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_ReceiptType.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_ReceiptType.Modified);

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

		public Boolean Delete(SqlInt32 ReceiptTypeID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ReceiptType_Delete");

				sqlDB.AddInParameter(dbCMD, "@ReceiptTypeID", SqlDbType.Int, ReceiptTypeID);

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

		public MST_ReceiptTypeENT SelectPK(SqlInt32 ReceiptTypeID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ReceiptType_SelectPK");

				sqlDB.AddInParameter(dbCMD, "@ReceiptTypeID", SqlDbType.Int, ReceiptTypeID);

				MST_ReceiptTypeENT entMST_ReceiptType = new MST_ReceiptTypeENT();
				DataBaseHelper DBH = new DataBaseHelper();
				using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
				{
					while (dr.Read())
					{
						if(!dr["ReceiptTypeID"].Equals(System.DBNull.Value))
							entMST_ReceiptType.ReceiptTypeID = Convert.ToInt32(dr["ReceiptTypeID"]);

						if(!dr["ReceiptTypeName"].Equals(System.DBNull.Value))
							entMST_ReceiptType.ReceiptTypeName = Convert.ToString(dr["ReceiptTypeName"]);

						if(!dr["PrintName"].Equals(System.DBNull.Value))
							entMST_ReceiptType.PrintName = Convert.ToString(dr["PrintName"]);

						if(!dr["IsDefault"].Equals(System.DBNull.Value))
							entMST_ReceiptType.IsDefault = Convert.ToBoolean(dr["IsDefault"]);

						if(!dr["HospitalID"].Equals(System.DBNull.Value))
							entMST_ReceiptType.HospitalID = Convert.ToInt32(dr["HospitalID"]);

						if(!dr["Remarks"].Equals(System.DBNull.Value))
							entMST_ReceiptType.Remarks = Convert.ToString(dr["Remarks"]);

						if(!dr["UserID"].Equals(System.DBNull.Value))
							entMST_ReceiptType.UserID = Convert.ToInt32(dr["UserID"]);

						if(!dr["Created"].Equals(System.DBNull.Value))
							entMST_ReceiptType.Created = Convert.ToDateTime(dr["Created"]);

						if(!dr["Modified"].Equals(System.DBNull.Value))
							entMST_ReceiptType.Modified = Convert.ToDateTime(dr["Modified"]);

					}
				}
				return entMST_ReceiptType;
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
		public DataTable SelectView(SqlInt32 ReceiptTypeID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ReceiptType_SelectView");

				sqlDB.AddInParameter(dbCMD, "@ReceiptTypeID", SqlDbType.Int, ReceiptTypeID);

				DataTable dtMST_ReceiptType = new DataTable("PR_MST_ReceiptType_SelectView");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_ReceiptType);

				return dtMST_ReceiptType;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ReceiptType_SelectAll");

				DataTable dtMST_ReceiptType = new DataTable("PR_MST_ReceiptType_SelectAll");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_ReceiptType);

				return dtMST_ReceiptType;
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
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString ReceiptTypeName, SqlString PrintName, SqlInt32 HospitalID,SqlBoolean IsDefault)
		{
			TotalRecords = 0;
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ReceiptType_SelectPage");
				sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
				sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddInParameter(dbCMD, "@ReceiptTypeName", SqlDbType.VarChar, ReceiptTypeName);
                sqlDB.AddInParameter(dbCMD, "@PrintName", SqlDbType.VarChar, PrintName);
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);
				sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD,"@IsDefault", SqlDbType.Bit,IsDefault);

				DataTable dtMST_ReceiptType = new DataTable("PR_MST_ReceiptType_SelectPage");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_ReceiptType);

				TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

				return dtMST_ReceiptType;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_ReceiptType_SelectComboBox");

				DataTable dtMST_ReceiptType = new DataTable("PR_MST_ReceiptType_SelectComboBox");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtMST_ReceiptType);

				return dtMST_ReceiptType;
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