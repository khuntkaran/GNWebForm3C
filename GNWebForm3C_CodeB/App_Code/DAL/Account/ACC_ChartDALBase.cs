using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ACC_ChartDALBase
/// </summary>
/// 
namespace GNForm3C.DAL
{
    public class ACC_ChartDALBase : DataBaseConfig
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
        public ACC_ChartDALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetHospitalName()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Hospital_SelectComboBox");

                DataTable dtACC_Expense = new DataTable("PR_MST_Hospital_SelectComboBox");

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


        public DataTable GetIncomeExpenseDataByHospital(SqlInt32 HospitalID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_ChartDataByHospitalID");
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);

                DataTable dtACC_Expense = new DataTable("PR_ACC_ChartDataByHospitalID");

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

    }
}