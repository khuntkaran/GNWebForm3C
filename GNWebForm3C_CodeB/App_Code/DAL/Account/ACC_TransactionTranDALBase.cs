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
	public abstract class ACC_TransactionTranDALBase : DataBaseConfig
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

		public ACC_TransactionTranDALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(ACC_TransactionTranENT entACC_TransactionTran)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_TransactionTran_Insert");

				sqlDB.AddOutParameter(dbCMD, "@TransactionTranID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@TransactionID", SqlDbType.Int, entACC_TransactionTran.TransactionID);
				sqlDB.AddInParameter(dbCMD, "@SubTreatmentID", SqlDbType.Int, entACC_TransactionTran.SubTreatmentID);
				sqlDB.AddInParameter(dbCMD, "@Quantity", SqlDbType.Int, entACC_TransactionTran.Quantity);
				sqlDB.AddInParameter(dbCMD, "@Unit", SqlDbType.NVarChar, entACC_TransactionTran.Unit);
				sqlDB.AddInParameter(dbCMD, "@Rate", SqlDbType.Decimal, entACC_TransactionTran.Rate);
				sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, entACC_TransactionTran.Amount);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entACC_TransactionTran.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entACC_TransactionTran.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entACC_TransactionTran.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entACC_TransactionTran.Modified);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entACC_TransactionTran.TransactionTranID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@TransactionTranID"].Value);

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

		public Boolean Update(ACC_TransactionTranENT entACC_TransactionTran)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_TransactionTran_Update");

				sqlDB.AddInParameter(dbCMD, "@TransactionTranID", SqlDbType.Int, entACC_TransactionTran.TransactionTranID);
				sqlDB.AddInParameter(dbCMD, "@TransactionID", SqlDbType.Int, entACC_TransactionTran.TransactionID);
				sqlDB.AddInParameter(dbCMD, "@SubTreatmentID", SqlDbType.Int, entACC_TransactionTran.SubTreatmentID);
				sqlDB.AddInParameter(dbCMD, "@Quantity", SqlDbType.Int, entACC_TransactionTran.Quantity);
				sqlDB.AddInParameter(dbCMD, "@Unit", SqlDbType.NVarChar, entACC_TransactionTran.Unit);
				sqlDB.AddInParameter(dbCMD, "@Rate", SqlDbType.Decimal, entACC_TransactionTran.Rate);
				sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, entACC_TransactionTran.Amount);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entACC_TransactionTran.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entACC_TransactionTran.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entACC_TransactionTran.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entACC_TransactionTran.Modified);

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

		public Boolean Delete(SqlInt32 TransactionTranID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_TransactionTran_Delete");

				sqlDB.AddInParameter(dbCMD, "@TransactionTranID", SqlDbType.Int, TransactionTranID);

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

		public ACC_TransactionTranENT SelectPK(SqlInt32 TransactionTranID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_TransactionTran_SelectPK");

				sqlDB.AddInParameter(dbCMD, "@TransactionTranID", SqlDbType.Int, TransactionTranID);

				ACC_TransactionTranENT entACC_TransactionTran = new ACC_TransactionTranENT();
				DataBaseHelper DBH = new DataBaseHelper();
				using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
				{
					while (dr.Read())
					{
						if(!dr["TransactionTranID"].Equals(System.DBNull.Value))
							entACC_TransactionTran.TransactionTranID = Convert.ToInt32(dr["TransactionTranID"]);

						if(!dr["TransactionID"].Equals(System.DBNull.Value))
							entACC_TransactionTran.TransactionID = Convert.ToInt32(dr["TransactionID"]);

						if(!dr["SubTreatmentID"].Equals(System.DBNull.Value))
							entACC_TransactionTran.SubTreatmentID = Convert.ToInt32(dr["SubTreatmentID"]);

						if(!dr["Quantity"].Equals(System.DBNull.Value))
							entACC_TransactionTran.Quantity = Convert.ToInt32(dr["Quantity"]);

						if(!dr["Unit"].Equals(System.DBNull.Value))
							entACC_TransactionTran.Unit = Convert.ToString(dr["Unit"]);

						if(!dr["Rate"].Equals(System.DBNull.Value))
							entACC_TransactionTran.Rate = Convert.ToDecimal(dr["Rate"]);

						if(!dr["Amount"].Equals(System.DBNull.Value))
							entACC_TransactionTran.Amount = Convert.ToDecimal(dr["Amount"]);

						if(!dr["Remarks"].Equals(System.DBNull.Value))
							entACC_TransactionTran.Remarks = Convert.ToString(dr["Remarks"]);

						if(!dr["UserID"].Equals(System.DBNull.Value))
							entACC_TransactionTran.UserID = Convert.ToInt32(dr["UserID"]);

						if(!dr["Created"].Equals(System.DBNull.Value))
							entACC_TransactionTran.Created = Convert.ToDateTime(dr["Created"]);

						if(!dr["Modified"].Equals(System.DBNull.Value))
							entACC_TransactionTran.Modified = Convert.ToDateTime(dr["Modified"]);

					}
				}
				return entACC_TransactionTran;
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
		public DataTable SelectView(SqlInt32 TransactionTranID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_TransactionTran_SelectView");

				sqlDB.AddInParameter(dbCMD, "@TransactionTranID", SqlDbType.Int, TransactionTranID);

				DataTable dtACC_TransactionTran = new DataTable("PR_ACC_TransactionTran_SelectView");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_TransactionTran);

				return dtACC_TransactionTran;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_TransactionTran_SelectAll");

				DataTable dtACC_TransactionTran = new DataTable("PR_ACC_TransactionTran_SelectAll");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_TransactionTran);

				return dtACC_TransactionTran;
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
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlInt32 TransactionID, SqlString Patient)
		{
			TotalRecords = 0;
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_TransactionTran_SelectPage");
				sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
				sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
				sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@TransactionID", SqlDbType.Int, TransactionID);
                sqlDB.AddInParameter(dbCMD, "@Patient", SqlDbType.VarChar, Patient);



				DataTable dtACC_TransactionTran = new DataTable("PR_ACC_TransactionTran_SelectPage");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_TransactionTran);

				TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

				return dtACC_TransactionTran;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_TransactionTran_SelectComboBox");

				DataTable dtACC_TransactionTran = new DataTable("PR_ACC_TransactionTran_SelectComboBox");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_TransactionTran);

				return dtACC_TransactionTran;
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