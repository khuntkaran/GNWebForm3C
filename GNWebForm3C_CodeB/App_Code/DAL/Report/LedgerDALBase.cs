using GNForm3C.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LedgerDALBase
/// </summary>
/// 
namespace GNForm3C.DAL
{
    public abstract class LedgerDALBase : DataBaseConfig
    {
        public LedgerDALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable PP_HospitalWise_FinYearWise_IncomeExpenseList()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_HospitalWise_FinYearWise_IncomeExpenseList");
               
                DataTable dtACC_Income = new DataTable("PP_HospitalWise_FinYearWise_IncomeExpenseList");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Income);


                return dtACC_Income;
            }
            catch (SqlException sqlex)
            {
                //Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                //Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }


        public DataTable PP_ACC_IncomeExpense_Ledger (SqlInt32 HospitalID, SqlInt32 FinYearID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_ACC_IncomeExpense_Ledger");
                sqlDB.AddInParameter(dbCMD,"@HospitalID",SqlDbType.Int,HospitalID);
                sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, FinYearID);


                DataTable dtACC_Income = new DataTable("PP_ACC_IncomeExpense_Ledger");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Income);


                return dtACC_Income;
            }
            catch (SqlException sqlex)
            {
                //Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                //Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

    }
}