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
	public abstract class ACC_IncomeDALBase : DataBaseConfig
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

		public ACC_IncomeDALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(ACC_IncomeENT entACC_Income)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Income_Insert");

				sqlDB.AddOutParameter(dbCMD, "@IncomeID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@IncomeTypeID", SqlDbType.Int, entACC_Income.IncomeTypeID);
				sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, entACC_Income.Amount);
				sqlDB.AddInParameter(dbCMD, "@IncomeDate", SqlDbType.DateTime, entACC_Income.IncomeDate);
				sqlDB.AddInParameter(dbCMD, "@Note", SqlDbType.NVarChar, entACC_Income.Note);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entACC_Income.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, entACC_Income.FinYearID);
				//sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entACC_Income.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entACC_Income.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entACC_Income.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entACC_Income.Modified);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entACC_Income.IncomeID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@IncomeID"].Value);

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

		public Boolean Update(ACC_IncomeENT entACC_Income)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Income_Update");

				sqlDB.AddInParameter(dbCMD, "@IncomeID", SqlDbType.Int, entACC_Income.IncomeID);
				sqlDB.AddInParameter(dbCMD, "@IncomeTypeID", SqlDbType.Int, entACC_Income.IncomeTypeID);
				sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, entACC_Income.Amount);
				sqlDB.AddInParameter(dbCMD, "@IncomeDate", SqlDbType.DateTime, entACC_Income.IncomeDate);
				sqlDB.AddInParameter(dbCMD, "@Note", SqlDbType.NVarChar, entACC_Income.Note);
				sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entACC_Income.HospitalID);
				sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, entACC_Income.FinYearID);
				//sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entACC_Income.Remarks);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entACC_Income.UserID);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entACC_Income.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entACC_Income.Modified);

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

        #region UpsertOpration XML

        public Boolean Upsert_XML(string xmlData)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Income_Upsert_XML");

                sqlDB.AddInParameter(dbCMD, "@xmlData", SqlDbType.Xml, xmlData);

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


        #endregion UpsertOpration XML

        #region UpsertOperation DataTable

        public Boolean Upsert(DataTable dtIncomeTable)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Income_Upsert");

                sqlDB.AddInParameter(dbCMD, "@dtIncomeTable", SqlDbType.Structured, dtIncomeTable);


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
        #endregion UpsertOperation DataTable

        #region DeleteOperation

        public Boolean Delete(SqlInt32 IncomeID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Income_Delete");

				sqlDB.AddInParameter(dbCMD, "@IncomeID", SqlDbType.Int, IncomeID);

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

		public ACC_IncomeENT SelectPK(SqlInt32 IncomeID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Income_SelectPK");

				sqlDB.AddInParameter(dbCMD, "@IncomeID", SqlDbType.Int, IncomeID);

				ACC_IncomeENT entACC_Income = new ACC_IncomeENT();
				DataBaseHelper DBH = new DataBaseHelper();
				using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
				{
					while (dr.Read())
					{
						if(!dr["IncomeID"].Equals(System.DBNull.Value))
							entACC_Income.IncomeID = Convert.ToInt32(dr["IncomeID"]);

						if(!dr["IncomeTypeID"].Equals(System.DBNull.Value))
							entACC_Income.IncomeTypeID = Convert.ToInt32(dr["IncomeTypeID"]);

						if(!dr["Amount"].Equals(System.DBNull.Value))
							entACC_Income.Amount = Convert.ToDecimal(dr["Amount"]);

						if(!dr["IncomeDate"].Equals(System.DBNull.Value))
							entACC_Income.IncomeDate = Convert.ToDateTime(dr["IncomeDate"]);

						if(!dr["Note"].Equals(System.DBNull.Value))
							entACC_Income.Note = Convert.ToString(dr["Note"]);

						if(!dr["HospitalID"].Equals(System.DBNull.Value))
							entACC_Income.HospitalID = Convert.ToInt32(dr["HospitalID"]);

						if(!dr["FinYearID"].Equals(System.DBNull.Value))
							entACC_Income.FinYearID = Convert.ToInt32(dr["FinYearID"]);

						//if(!dr["Remarks"].Equals(System.DBNull.Value))
						//	entACC_Income.Remarks = Convert.ToString(dr["Remarks"]);

						if(!dr["UserID"].Equals(System.DBNull.Value))
							entACC_Income.UserID = Convert.ToInt32(dr["UserID"]);

						if(!dr["Created"].Equals(System.DBNull.Value))
							entACC_Income.Created = Convert.ToDateTime(dr["Created"]);

						if(!dr["Modified"].Equals(System.DBNull.Value))
							entACC_Income.Modified = Convert.ToDateTime(dr["Modified"]);

					}
				}
				return entACC_Income;
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
		public DataTable SelectView(SqlInt32 IncomeID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Income_SelectView");

				sqlDB.AddInParameter(dbCMD, "@IncomeID", SqlDbType.Int, IncomeID);

				DataTable dtACC_Income = new DataTable("PR_ACC_Income_SelectView");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Income);

				return dtACC_Income;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Income_SelectAll");

				DataTable dtACC_Income = new DataTable("PR_ACC_Income_SelectAll");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Income);

				return dtACC_Income;
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
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlInt32 IncomeTypeID, SqlDecimal Amount, SqlDateTime IncomeDate, SqlInt32 HospitalID, SqlInt32 FinYearID)
		{
			TotalRecords = 0;
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Income_SelectPage");
				sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
				sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
				sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@IncomeTypeID", SqlDbType.Int, IncomeTypeID);
                sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, Amount);
                sqlDB.AddInParameter(dbCMD, "@IncomeDate", SqlDbType.DateTime, IncomeDate);
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);
                sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, FinYearID);

				DataTable dtACC_Income = new DataTable("PR_ACC_Income_SelectPage");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Income);

				TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

				return dtACC_Income;
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

        public DataTable SelectShow(SqlInt32 HospitalID, SqlInt32 IncomeTypeID, SqlInt32 FinYearID)

        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Income_SelectShow");
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);
                sqlDB.AddInParameter(dbCMD, "@IncomeTypeID", SqlDbType.Int, IncomeTypeID);
                sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, FinYearID);

                DataTable dtACC_IncomeShow = new DataTable("PR_ACC_Income_SelectShow");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_IncomeShow);

                return dtACC_IncomeShow;
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
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Income_SelectComboBox");

				DataTable dtACC_Income = new DataTable("PR_ACC_Income_SelectComboBox");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Income);

				return dtACC_Income;
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