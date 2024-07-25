using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using GNForm3C.ENT;

/// <summary>
/// Summary description for EMP_EmployeeDetailDALBase
/// </summary>
/// 
namespace GNForm3C.DAL
{
    public abstract class EMP_EmployeeDetailDALBase : DataBaseConfig
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
        public EMP_EmployeeDetailDALBase()
        {
           
        }
        #endregion Constructor

        #region InsertOperation
        public Boolean Insert(EMP_EmployeeDetailENT entEMP_EmployeeDetail)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_EmployeeDetail_Insert");

                sqlDB.AddOutParameter(dbCMD, "@EmployeeID", SqlDbType.Int, 0);
                sqlDB.AddInParameter(dbCMD, "@EmployeeName", SqlDbType.NVarChar, entEMP_EmployeeDetail.EmployeeName);
                sqlDB.AddInParameter(dbCMD, "@EmployeeTypeID", SqlDbType.Int, entEMP_EmployeeDetail.EmployeeTypeID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entEMP_EmployeeDetail.Remarks);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entEMP_EmployeeDetail.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entEMP_EmployeeDetail.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entEMP_EmployeeDetail.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entEMP_EmployeeDetail.EmployeeID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@EmployeeID"].Value);

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

        public Boolean Update(EMP_EmployeeDetailENT entEMP_EmployeeDetail)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_EmployeeDetail_Update");

                sqlDB.AddInParameter(dbCMD, "@EmployeeID", SqlDbType.Int, entEMP_EmployeeDetail.EmployeeID);
                sqlDB.AddInParameter(dbCMD, "@EmployeeName", SqlDbType.NVarChar, entEMP_EmployeeDetail.EmployeeName);
                sqlDB.AddInParameter(dbCMD, "@EmployeeTypeID", SqlDbType.Int, entEMP_EmployeeDetail.EmployeeTypeID);
                sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entEMP_EmployeeDetail.Remarks);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entEMP_EmployeeDetail.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entEMP_EmployeeDetail.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entEMP_EmployeeDetail.Modified);

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

        public Boolean Delete(SqlInt32 EmployeeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_EmployeeDetail_Delete");

                sqlDB.AddInParameter(dbCMD, "@EmployeeID", SqlDbType.Int, EmployeeID);

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

        public EMP_EmployeeDetailENT SelectPK(SqlInt32 EmployeeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_EmployeeDetail_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@EmployeeID", SqlDbType.Int, EmployeeID);

                EMP_EmployeeDetailENT entEMP_EmployeeDetail= new EMP_EmployeeDetailENT();
                
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["EmployeeID"].Equals(System.DBNull.Value))
                            entEMP_EmployeeDetail.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);

                        if (!dr["EmployeeName"].Equals(System.DBNull.Value))
                            entEMP_EmployeeDetail.EmployeeName = Convert.ToString(dr["EmployeeName"]);

                        if (!dr["EmployeeTypeID"].Equals(System.DBNull.Value))
                            entEMP_EmployeeDetail.EmployeeTypeID = Convert.ToInt32(dr["EmployeeTypeID"]);

                        if (!dr["Remarks"].Equals(System.DBNull.Value))
                            entEMP_EmployeeDetail.Remarks = Convert.ToString(dr["Remarks"]);

                        if (!dr["UserID"].Equals(System.DBNull.Value))
                            entEMP_EmployeeDetail.UserID = Convert.ToInt32(dr["UserID"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entEMP_EmployeeDetail.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entEMP_EmployeeDetail.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entEMP_EmployeeDetail;
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
        public DataTable SelectView(SqlInt32 EmployeeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_EmployeeDetail_SelectView");

                sqlDB.AddInParameter(dbCMD, "@EmployeeID", SqlDbType.Int, EmployeeID);

                DataTable dtEMP_EmployeeDetail = new DataTable("PR_EMP_EmployeeDetail_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtEMP_EmployeeDetail);

                return dtEMP_EmployeeDetail;
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
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString EmployeeName, SqlInt32 EmployeeTypeID)
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_EmployeeDetail_SelectPage");
                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddInParameter(dbCMD, "@EmployeeName", SqlDbType.VarChar, EmployeeName);
                sqlDB.AddInParameter(dbCMD, "@EmployeeTypeID", SqlDbType.Int, EmployeeTypeID);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

                DataTable dtEMP_EmployeeDetail = new DataTable("PR_EMP_EmployeeDetail_SelectPage");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtEMP_EmployeeDetail);

                TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

                return dtEMP_EmployeeDetail;
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

        public DataTable SelectShow(SqlInt32 EmployeeTypeID)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_EmployeeDetail_SelectShow");
                sqlDB.AddInParameter(dbCMD, "@EmployeeTypeID", SqlDbType.Int, EmployeeTypeID);

                DataTable dtEMP_EmployeeDetailShow = new DataTable("PR_EMP_EmployeeDetail_SelectShow");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtEMP_EmployeeDetailShow);

                return dtEMP_EmployeeDetailShow;
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
    }
}