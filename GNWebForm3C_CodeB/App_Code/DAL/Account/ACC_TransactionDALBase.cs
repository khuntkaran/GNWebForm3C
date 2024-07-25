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
	public abstract class ACC_TransactionDALBase : DataBaseConfig
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

		public ACC_TransactionDALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(ACC_TransactionENT entACC_Transaction)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Transaction_Insert");

				sqlDB.AddOutParameter(dbCMD, "@TransactionID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@Patient", SqlDbType.NVarChar, entACC_Transaction.Patient);
				sqlDB.AddInParameter(dbCMD, "@TreatmentID", SqlDbType.Int, entACC_Transaction.TreatmentID);
				sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, entACC_Transaction.Amount);
				sqlDB.AddInParameter(dbCMD, "@SerialNo", SqlDbType.Int, entACC_Transaction.SerialNo);
				sqlDB.AddInParameter(dbCMD, "@ReferenceDoctor", SqlDbType.NVarChar, entACC_Transaction.ReferenceDoctor);
				sqlDB.AddInParameter(dbCMD, "@Count", SqlDbType.Int, entACC_Transaction.Count);
				sqlDB.AddInParameter(dbCMD, "@ReceiptNo", SqlDbType.Int, entACC_Transaction.ReceiptNo);
				sqlDB.AddInParameter(dbCMD, "@Date", SqlDbType.DateTime, entACC_Transaction.Date);
				sqlDB.AddInParameter(dbCMD, "@DateOfAdmission", SqlDbType.DateTime, entACC_Transaction.DateOfAdmission);
				sqlDB.AddInParameter(dbCMD, "@DateOfDischarge", SqlDbType.DateTime, entACC_Transaction.DateOfDischarge);
				sqlDB.AddInParameter(dbCMD, "@Deposite", SqlDbType.Decimal, entACC_Transaction.Deposite);
				sqlDB.AddInParameter(dbCMD, "@NetAmount", SqlDbType.Decimal, entACC_Transaction.NetAmount);
				sqlDB.AddInParameter(dbCMD, "@NoOfDays", SqlDbType.Int, entACC_Transaction.NoOfDays);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entACC_Transaction.Remarks);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entACC_Transaction.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, entACC_Transaction.FinYearID);
				sqlDB.AddInParameter(dbCMD, "@ReceiptTypeID", SqlDbType.Int, entACC_Transaction.ReceiptTypeID);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entACC_Transaction.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entACC_Transaction.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entACC_Transaction.Modified);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entACC_Transaction.TransactionID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@TransactionID"].Value);

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

		public Boolean Update(ACC_TransactionENT entACC_Transaction)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Transaction_Update");

				sqlDB.AddInParameter(dbCMD, "@TransactionID", SqlDbType.Int, entACC_Transaction.TransactionID);
				sqlDB.AddInParameter(dbCMD, "@Patient", SqlDbType.NVarChar, entACC_Transaction.Patient);
				sqlDB.AddInParameter(dbCMD, "@TreatmentID", SqlDbType.Int, entACC_Transaction.TreatmentID);
				sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, entACC_Transaction.Amount);
				sqlDB.AddInParameter(dbCMD, "@SerialNo", SqlDbType.Int, entACC_Transaction.SerialNo);
				sqlDB.AddInParameter(dbCMD, "@ReferenceDoctor", SqlDbType.NVarChar, entACC_Transaction.ReferenceDoctor);
				sqlDB.AddInParameter(dbCMD, "@Count", SqlDbType.Int, entACC_Transaction.Count);
				sqlDB.AddInParameter(dbCMD, "@ReceiptNo", SqlDbType.Int, entACC_Transaction.ReceiptNo);
				sqlDB.AddInParameter(dbCMD, "@Date", SqlDbType.DateTime, entACC_Transaction.Date);
				sqlDB.AddInParameter(dbCMD, "@DateOfAdmission", SqlDbType.DateTime, entACC_Transaction.DateOfAdmission);
				sqlDB.AddInParameter(dbCMD, "@DateOfDischarge", SqlDbType.DateTime, entACC_Transaction.DateOfDischarge);
				sqlDB.AddInParameter(dbCMD, "@Deposite", SqlDbType.Decimal, entACC_Transaction.Deposite);
				sqlDB.AddInParameter(dbCMD, "@NetAmount", SqlDbType.Decimal, entACC_Transaction.NetAmount);
				sqlDB.AddInParameter(dbCMD, "@NoOfDays", SqlDbType.Int, entACC_Transaction.NoOfDays);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entACC_Transaction.Remarks);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entACC_Transaction.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, entACC_Transaction.FinYearID);
				sqlDB.AddInParameter(dbCMD, "@ReceiptTypeID", SqlDbType.Int, entACC_Transaction.ReceiptTypeID);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entACC_Transaction.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entACC_Transaction.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entACC_Transaction.Modified);

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

		public Boolean Delete(SqlInt32 TransactionID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Transaction_Delete");

				sqlDB.AddInParameter(dbCMD, "@TransactionID", SqlDbType.Int, TransactionID);

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

		public ACC_TransactionENT SelectPK(SqlInt32 TransactionID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Transaction_SelectPK");

				sqlDB.AddInParameter(dbCMD, "@TransactionID", SqlDbType.Int, TransactionID);

				ACC_TransactionENT entACC_Transaction = new ACC_TransactionENT();
				DataBaseHelper DBH = new DataBaseHelper();
				using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
				{
					while (dr.Read())
					{
						if(!dr["TransactionID"].Equals(System.DBNull.Value))
							entACC_Transaction.TransactionID = Convert.ToInt32(dr["TransactionID"]);

						if(!dr["Patient"].Equals(System.DBNull.Value))
							entACC_Transaction.Patient = Convert.ToString(dr["Patient"]);

						if(!dr["TreatmentID"].Equals(System.DBNull.Value))
							entACC_Transaction.TreatmentID = Convert.ToInt32(dr["TreatmentID"]);

						if(!dr["Amount"].Equals(System.DBNull.Value))
							entACC_Transaction.Amount = Convert.ToDecimal(dr["Amount"]);

						if(!dr["SerialNo"].Equals(System.DBNull.Value))
							entACC_Transaction.SerialNo = Convert.ToInt32(dr["SerialNo"]);

						if(!dr["ReferenceDoctor"].Equals(System.DBNull.Value))
							entACC_Transaction.ReferenceDoctor = Convert.ToString(dr["ReferenceDoctor"]);

						if(!dr["Count"].Equals(System.DBNull.Value))
							entACC_Transaction.Count = Convert.ToInt32(dr["Count"]);

						if(!dr["ReceiptNo"].Equals(System.DBNull.Value))
							entACC_Transaction.ReceiptNo = Convert.ToInt32(dr["ReceiptNo"]);

						if(!dr["Date"].Equals(System.DBNull.Value))
							entACC_Transaction.Date = Convert.ToDateTime(dr["Date"]);

						if(!dr["DateOfAdmission"].Equals(System.DBNull.Value))
							entACC_Transaction.DateOfAdmission = Convert.ToDateTime(dr["DateOfAdmission"]);

						if(!dr["DateOfDischarge"].Equals(System.DBNull.Value))
							entACC_Transaction.DateOfDischarge = Convert.ToDateTime(dr["DateOfDischarge"]);

						if(!dr["Deposite"].Equals(System.DBNull.Value))
							entACC_Transaction.Deposite = Convert.ToDecimal(dr["Deposite"]);

						if(!dr["NetAmount"].Equals(System.DBNull.Value))
							entACC_Transaction.NetAmount = Convert.ToDecimal(dr["NetAmount"]);

						if(!dr["NoOfDays"].Equals(System.DBNull.Value))
							entACC_Transaction.NoOfDays = Convert.ToInt32(dr["NoOfDays"]);

						if(!dr["Remarks"].Equals(System.DBNull.Value))
							entACC_Transaction.Remarks = Convert.ToString(dr["Remarks"]);

						if(!dr["HospitalID"].Equals(System.DBNull.Value))
							entACC_Transaction.HospitalID = Convert.ToInt32(dr["HospitalID"]);

						if(!dr["FinYearID"].Equals(System.DBNull.Value))
							entACC_Transaction.FinYearID = Convert.ToInt32(dr["FinYearID"]);

						if(!dr["ReceiptTypeID"].Equals(System.DBNull.Value))
							entACC_Transaction.ReceiptTypeID = Convert.ToInt32(dr["ReceiptTypeID"]);

						if(!dr["UserID"].Equals(System.DBNull.Value))
							entACC_Transaction.UserID = Convert.ToInt32(dr["UserID"]);

						if(!dr["Created"].Equals(System.DBNull.Value))
							entACC_Transaction.Created = Convert.ToDateTime(dr["Created"]);

						if(!dr["Modified"].Equals(System.DBNull.Value))
							entACC_Transaction.Modified = Convert.ToDateTime(dr["Modified"]);

					}
				}
				return entACC_Transaction;
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
		public DataTable SelectView(SqlInt32 TransactionID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Transaction_SelectView");

				sqlDB.AddInParameter(dbCMD, "@TransactionID", SqlDbType.Int, TransactionID);

				DataTable dtACC_Transaction = new DataTable("PR_ACC_Transaction_SelectView");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Transaction);

				return dtACC_Transaction;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Transaction_SelectAll");

				DataTable dtACC_Transaction = new DataTable("PR_ACC_Transaction_SelectAll");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Transaction);

				return dtACC_Transaction;
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
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString Patient, SqlInt32 TreatmentID)
		{
			TotalRecords = 0;
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Transaction_SelectPage");
				sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
				sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
				sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@Patient", SqlDbType.VarChar, Patient);
                sqlDB.AddInParameter(dbCMD, "@TreatmentID", SqlDbType.Int, TreatmentID);

				DataTable dtACC_Transaction = new DataTable("PR_ACC_Transaction_SelectPage");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Transaction);

				TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

				return dtACC_Transaction;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Transaction_SelectComboBox");

				DataTable dtACC_Transaction = new DataTable("PR_ACC_Transaction_SelectComboBox");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Transaction);

				return dtACC_Transaction;
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