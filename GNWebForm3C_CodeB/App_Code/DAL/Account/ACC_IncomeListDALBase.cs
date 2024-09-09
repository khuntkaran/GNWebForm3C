using iTextSharp.text;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ACC_IncomeListDALBase
/// </summary>
/// 
namespace GNForm3C.DAL
{
    public abstract class ACC_IncomeListDALBase : DataBaseConfig
    {
        public ACC_IncomeListDALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
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
        public DataTable ExecuteProcedure(int? HospitalID, int? FinYearID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_IncomeList_SelectPage2");
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);
                sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, FinYearID);

                DataTable dtACC_IncomeList = new DataTable("PR_ACC_IncomeList_SelectPage2");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_IncomeList);

                return dtACC_IncomeList;
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