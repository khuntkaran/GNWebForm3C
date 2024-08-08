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
    public abstract class ACC_GNTransactionDALBase : DataBaseConfig
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

        public ACC_GNTransactionDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation
        public MST_PatientENT InsertPatient(MST_PatientENT entMST_Patient)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_GNPatient_Insert");

                sqlDB.AddOutParameter(dbCMD, "@PatientID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@PatientName", SqlDbType.NVarChar, entMST_Patient.PatientName);
                sqlDB.AddInParameter(dbCMD, "@Age", SqlDbType.Int, entMST_Patient.Age);
                sqlDB.AddInParameter(dbCMD, "@DOB", SqlDbType.DateTime, entMST_Patient.DOB);
                sqlDB.AddInParameter(dbCMD, "@MobileNo", SqlDbType.NVarChar, entMST_Patient.MobileNo);
                sqlDB.AddInParameter(dbCMD, "@PrimaryDesc", SqlDbType.NVarChar, entMST_Patient.PrimaryDesc);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Patient.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Patient.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Patient.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    if (dr.Read())
                    {
                        MST_PatientENT entMST_PatientDetails = new MST_PatientENT
                        {
                            PatientID = dr.GetInt32(dr.GetOrdinal("PatientID")),
                            PatientName = dr.GetString(dr.GetOrdinal("PatientName")),
                            Age = dr.GetInt32(dr.GetOrdinal("Age")),
                            DOB = dr.GetDateTime(dr.GetOrdinal("DOB")),
                            MobileNo = dr.GetString(dr.GetOrdinal("MobileNo")),
                            PrimaryDesc = dr.GetString(dr.GetOrdinal("PrimaryDesc")),
                            UserID = dr.GetInt32(dr.GetOrdinal("UserID")),
                            Created = dr.GetDateTime(dr.GetOrdinal("Created")),
                            Modified = dr.GetDateTime(dr.GetOrdinal("Modified"))
                        };

                        return entMST_PatientDetails;
                    }
                    else
                    {
                        return null;
                    }
                }
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

        public Boolean Insert(ACC_GNTransactionENT entACC_GNTransaction)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_GNTransaction_Insert");

                sqlDB.AddOutParameter(dbCMD, "@TransactionID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, entACC_GNTransaction.PatientID);
                sqlDB.AddInParameter(dbCMD, "@TreatmentID", SqlDbType.Int, entACC_GNTransaction.TreatmentID);
                sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, entACC_GNTransaction.Amount);
                sqlDB.AddInParameter(dbCMD, "@Quantity", SqlDbType.Int, entACC_GNTransaction.Quantity); // Added this field
                sqlDB.AddInParameter(dbCMD, "@ReferenceDoctor", SqlDbType.NVarChar, entACC_GNTransaction.ReferenceDoctor);
                sqlDB.AddInParameter(dbCMD, "@Count", SqlDbType.Int, entACC_GNTransaction.Count);
                sqlDB.AddInParameter(dbCMD, "@ReceiptNo", SqlDbType.Int, entACC_GNTransaction.ReceiptNo);
                sqlDB.AddInParameter(dbCMD, "@Date", SqlDbType.DateTime, entACC_GNTransaction.Date);
                sqlDB.AddInParameter(dbCMD, "@Deposite", SqlDbType.Decimal, entACC_GNTransaction.Deposite);
                sqlDB.AddInParameter(dbCMD, "@NoOfDays", SqlDbType.Int, entACC_GNTransaction.NoOfDays);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entACC_GNTransaction.Remarks);
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entACC_GNTransaction.HospitalID);
                sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, entACC_GNTransaction.FinYearID);
                sqlDB.AddInParameter(dbCMD, "@ReceiptTypeID", SqlDbType.Int, entACC_GNTransaction.ReceiptTypeID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entACC_GNTransaction.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entACC_GNTransaction.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entACC_GNTransaction.Modified);


                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entACC_GNTransaction.TransactionID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@TransactionID"].Value);

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

        public Boolean Update(ACC_GNTransactionENT entACC_GNTransaction)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_GNTransaction_Update");

                sqlDB.AddInParameter(dbCMD, "@TransactionID", SqlDbType.Int, entACC_GNTransaction.TransactionID);
                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, entACC_GNTransaction.PatientID);
                sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, entACC_GNTransaction.Amount);
                sqlDB.AddInParameter(dbCMD, "@ReferenceDoctor", SqlDbType.NVarChar, entACC_GNTransaction.ReferenceDoctor);
                sqlDB.AddInParameter(dbCMD, "@Count", SqlDbType.Int, entACC_GNTransaction.Count);
                sqlDB.AddInParameter(dbCMD, "@ReceiptNo", SqlDbType.Int, entACC_GNTransaction.ReceiptNo);
                sqlDB.AddInParameter(dbCMD, "@Date", SqlDbType.DateTime, entACC_GNTransaction.Date);
                sqlDB.AddInParameter(dbCMD, "@DateOfAdmission", SqlDbType.DateTime, entACC_GNTransaction.DateOfAdmission);
                sqlDB.AddInParameter(dbCMD, "@DateOfDischarge", SqlDbType.DateTime, entACC_GNTransaction.DateOfDischarge);
                sqlDB.AddInParameter(dbCMD, "@Deposite", SqlDbType.Decimal, entACC_GNTransaction.Deposite);
                sqlDB.AddInParameter(dbCMD, "@NetAmount", SqlDbType.Decimal, entACC_GNTransaction.NetAmount);
                sqlDB.AddInParameter(dbCMD, "@NoOfDays", SqlDbType.Int, entACC_GNTransaction.NoOfDays);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entACC_GNTransaction.Remarks);
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entACC_GNTransaction.HospitalID);
                sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, entACC_GNTransaction.FinYearID);
                sqlDB.AddInParameter(dbCMD, "@ReceiptTypeID", SqlDbType.Int, entACC_GNTransaction.ReceiptTypeID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entACC_GNTransaction.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entACC_GNTransaction.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entACC_GNTransaction.Modified);

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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_GNTransaction_Delete");

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

        public Boolean UpdateDischargeAndTotalDays(SqlInt32 TransactionID)
        {
            try
            {
                // Create a new SqlDatabase instance
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);

                // Create a new DbCommand instance for the stored procedure
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_GNTransaction_Discharge");

                // Add input parameters
                sqlDB.AddInParameter(dbCMD, "@TransactionID", SqlDbType.Int, TransactionID);

                // Execute the stored procedure
                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                // Return true if successful
                return true;
            }
            catch (SqlException sqlex)
            {
                // Capture SQL exception message
                Message = SQLDataExceptionMessage(sqlex);

                // Handle SQL exception
                if (SQLDataExceptionHandler(sqlex))
                    throw;

                // Return false in case of failure
                return false;
            }
            catch (Exception ex)
            {
                // Capture general exception message
                Message = ExceptionMessage(ex);

                // Handle general exception
                if (ExceptionHandler(ex))
                    throw;

                // Return false in case of failure
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public ACC_GNTransactionENT SelectPK(SqlInt32 TransactionID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_GNTransaction_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@TransactionID", SqlDbType.Int, TransactionID);

                ACC_GNTransactionENT entACC_GNTransaction = new ACC_GNTransactionENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["TransactionID"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.TransactionID = Convert.ToInt32(dr["TransactionID"]);

                        if (!dr["PatientID"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.PatientID = Convert.ToInt32(dr["PatientID"]);

                        if (!dr["Amount"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.Amount = Convert.ToDecimal(dr["Amount"]);

                        if (!dr["ReferenceDoctor"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.ReferenceDoctor = Convert.ToString(dr["ReferenceDoctor"]);

                        if (!dr["Count"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.Count = Convert.ToInt32(dr["Count"]);

                        if (!dr["ReceiptNo"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.ReceiptNo = Convert.ToInt32(dr["ReceiptNo"]);

                        if (!dr["Date"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.Date = Convert.ToDateTime(dr["Date"]);

                        if (!dr["DateOfAdmission"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.DateOfAdmission = Convert.ToDateTime(dr["DateOfAdmission"]);

                        if (!dr["DateOfDischarge"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.DateOfDischarge = Convert.ToDateTime(dr["DateOfDischarge"]);

                        if (!dr["Deposite"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.Deposite = Convert.ToDecimal(dr["Deposite"]);

                        if (!dr["NetAmount"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.NetAmount = Convert.ToDecimal(dr["NetAmount"]);

                        if (!dr["NoOfDays"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.NoOfDays = Convert.ToInt32(dr["NoOfDays"]);

                        if (!dr["Remarks"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.Remarks = Convert.ToString(dr["Remarks"]);

                        if (!dr["HospitalID"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.HospitalID = Convert.ToInt32(dr["HospitalID"]);

                        if (!dr["FinYearID"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.FinYearID = Convert.ToInt32(dr["FinYearID"]);

                        if (!dr["ReceiptTypeID"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.ReceiptTypeID = Convert.ToInt32(dr["ReceiptTypeID"]);

                        if (!dr["UserID"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.UserID = Convert.ToInt32(dr["UserID"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entACC_GNTransaction.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entACC_GNTransaction;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_GNTransaction_SelectView");

                sqlDB.AddInParameter(dbCMD, "@TransactionID", SqlDbType.Int, TransactionID);

                DataTable dtACC_GNTransaction = new DataTable("PR_ACC_GNTransaction_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_GNTransaction);

                return dtACC_GNTransaction;
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_GNTransaction_SelectAll");

                DataTable dtACC_GNTransaction = new DataTable("PR_ACC_GNTransaction_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_GNTransaction);

                return dtACC_GNTransaction;
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
        public DataTable SelectPage(
    SqlInt32 PageOffset,
    SqlInt32 PageSize,
    out Int32 TotalRecords,
    SqlInt32 PatientID,
    SqlDecimal Amount,
    SqlString ReferenceDoctor,
    SqlInt32 Count,
    SqlInt32 ReceiptNo,
    SqlDateTime Date,
    SqlDateTime DateOfAdmission,
    SqlDateTime DateOfDischarge,
    SqlDecimal Deposite,
    SqlDecimal NetAmount,
    SqlInt32 NoOfDays,
    SqlInt32 HospitalID,
    SqlInt32 FinYearID,
    SqlInt32 ReceiptTypeID
)
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_GNTransaction_SelectPage");

                // Add parameters
                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, PatientID);
                sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, Amount);
                sqlDB.AddInParameter(dbCMD, "@ReferenceDoctor", SqlDbType.VarChar, ReferenceDoctor);
                sqlDB.AddInParameter(dbCMD, "@Count", SqlDbType.Int, Count);
                sqlDB.AddInParameter(dbCMD, "@ReceiptNo", SqlDbType.Int, ReceiptNo);
                sqlDB.AddInParameter(dbCMD, "@Date", SqlDbType.DateTime, Date);
                sqlDB.AddInParameter(dbCMD, "@DateOfAdmission", SqlDbType.DateTime, DateOfAdmission);
                sqlDB.AddInParameter(dbCMD, "@DateOfDischarge", SqlDbType.DateTime, DateOfDischarge);
                sqlDB.AddInParameter(dbCMD, "@Deposite", SqlDbType.Decimal, Deposite);
                sqlDB.AddInParameter(dbCMD, "@NetAmount", SqlDbType.Decimal, NetAmount);
                sqlDB.AddInParameter(dbCMD, "@NoOfDays", SqlDbType.Int, NoOfDays);
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);
                sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, FinYearID);
                sqlDB.AddInParameter(dbCMD, "@ReceiptTypeID", SqlDbType.Int, ReceiptTypeID);

                DataTable dtACC_GNTransaction = new DataTable("PR_ACC_GNTransaction_SelectPage");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_GNTransaction);

                TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

                return dtACC_GNTransaction;
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

        #region AutoComplete


        #endregion AutoComplete

        #region ComboBox

        public DataTable SelectComboBox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_SelectComboBox");

                DataTable dtMST_Patient = new DataTable("PR_MST_Patient_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Patient);

                return dtMST_Patient;
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

    }
}