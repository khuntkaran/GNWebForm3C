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
	public abstract class ACC_ExpenseDALBase : DataBaseConfig
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

		public ACC_ExpenseDALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(ACC_ExpenseENT entACC_Expense)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Expense_Insert");

				sqlDB.AddOutParameter(dbCMD, "@ExpenseID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@ExpenseTypeID", SqlDbType.Int, entACC_Expense.ExpenseTypeID);
				sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, entACC_Expense.Amount);
				sqlDB.AddInParameter(dbCMD, "@ExpenseDate", SqlDbType.DateTime, entACC_Expense.ExpenseDate);
				sqlDB.AddInParameter(dbCMD, "@Note", SqlDbType.NVarChar, entACC_Expense.Note);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entACC_Expense.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, entACC_Expense.FinYearID);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entACC_Expense.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entACC_Expense.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entACC_Expense.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entACC_Expense.Modified);
                sqlDB.AddInParameter(dbCMD, "@TagName", SqlDbType.VarChar, entACC_Expense.TagName);

                DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entACC_Expense.ExpenseID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@ExpenseID"].Value);

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

        public Boolean Update(ACC_ExpenseENT entACC_Expense)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Expense_Update");

				sqlDB.AddInParameter(dbCMD, "@ExpenseID", SqlDbType.Int, entACC_Expense.ExpenseID);
				sqlDB.AddInParameter(dbCMD, "@ExpenseTypeID", SqlDbType.Int, entACC_Expense.ExpenseTypeID);
				sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, entACC_Expense.Amount);
				sqlDB.AddInParameter(dbCMD, "@ExpenseDate", SqlDbType.DateTime, entACC_Expense.ExpenseDate);
				sqlDB.AddInParameter(dbCMD, "@Note", SqlDbType.NVarChar, entACC_Expense.Note);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entACC_Expense.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, entACC_Expense.FinYearID);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entACC_Expense.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entACC_Expense.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entACC_Expense.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entACC_Expense.Modified);
                sqlDB.AddInParameter(dbCMD, "@TagName", SqlDbType.VarChar, entACC_Expense.TagName);

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

		public Boolean Delete(SqlInt32 ExpenseID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Expense_Delete");

				sqlDB.AddInParameter(dbCMD, "@ExpenseID", SqlDbType.Int, ExpenseID);

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

		public ACC_ExpenseENT SelectPK(SqlInt32 ExpenseID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Expense_SelectPK");

				sqlDB.AddInParameter(dbCMD, "@ExpenseID", SqlDbType.Int, ExpenseID);

				ACC_ExpenseENT entACC_Expense = new ACC_ExpenseENT();
				DataBaseHelper DBH = new DataBaseHelper();
				using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
				{
					while (dr.Read())
					{
						if(!dr["ExpenseID"].Equals(System.DBNull.Value))
							entACC_Expense.ExpenseID = Convert.ToInt32(dr["ExpenseID"]);

						if(!dr["ExpenseTypeID"].Equals(System.DBNull.Value))
							entACC_Expense.ExpenseTypeID = Convert.ToInt32(dr["ExpenseTypeID"]);

						if(!dr["Amount"].Equals(System.DBNull.Value))
							entACC_Expense.Amount = Convert.ToDecimal(dr["Amount"]);

						if(!dr["ExpenseDate"].Equals(System.DBNull.Value))
							entACC_Expense.ExpenseDate = Convert.ToDateTime(dr["ExpenseDate"]);

						if(!dr["Note"].Equals(System.DBNull.Value))
							entACC_Expense.Note = Convert.ToString(dr["Note"]);

						if(!dr["HospitalID"].Equals(System.DBNull.Value))
							entACC_Expense.HospitalID = Convert.ToInt32(dr["HospitalID"]);

						if(!dr["FinYearID"].Equals(System.DBNull.Value))
							entACC_Expense.FinYearID = Convert.ToInt32(dr["FinYearID"]);

						if(!dr["Remarks"].Equals(System.DBNull.Value))
							entACC_Expense.Remarks = Convert.ToString(dr["Remarks"]);

						if(!dr["UserID"].Equals(System.DBNull.Value))
							entACC_Expense.UserID = Convert.ToInt32(dr["UserID"]);

						if(!dr["Created"].Equals(System.DBNull.Value))
							entACC_Expense.Created = Convert.ToDateTime(dr["Created"]);

						if(!dr["Modified"].Equals(System.DBNull.Value))
							entACC_Expense.Modified = Convert.ToDateTime(dr["Modified"]);

                        if (!dr["TagName"].Equals(System.DBNull.Value))
                            entACC_Expense.Remarks = Convert.ToString(dr["TagName"]);
                    }
				}
				return entACC_Expense;
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
		public DataTable SelectView(SqlInt32 ExpenseID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Expense_SelectView");

				sqlDB.AddInParameter(dbCMD, "@ExpenseID", SqlDbType.Int, ExpenseID);

				DataTable dtACC_Expense = new DataTable("PR_ACC_Expense_SelectView");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Expense);

				return dtACC_Expense;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Expense_SelectAll");

				DataTable dtACC_Expense = new DataTable("PR_ACC_Expense_SelectAll");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Expense);

				return dtACC_Expense;
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
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlInt32 ExpenseTypeID, SqlDecimal Amount, SqlDateTime ExpenseDate, SqlInt32 HospitalID, SqlInt32 FinYearID, SqlString TagName)
		{
			TotalRecords = 0;
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Expense_SelectPage");
				sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
				sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
				sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@ExpenseTypeID", SqlDbType.Int, ExpenseTypeID);
                sqlDB.AddInParameter(dbCMD, "@ExpenseDate", SqlDbType.DateTime, ExpenseDate);
                sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, Amount);
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID); 
                sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, FinYearID);
                sqlDB.AddInParameter(dbCMD, "@TagName", SqlDbType.VarChar, TagName);

                DataTable dtACC_Expense = new DataTable("PR_ACC_Expense_SelectPage");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Expense);

				TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

				return dtACC_Expense;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Expense_SelectComboBox");

				DataTable dtACC_Expense = new DataTable("PR_ACC_Expense_SelectComboBox");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Expense);

				return dtACC_Expense;
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