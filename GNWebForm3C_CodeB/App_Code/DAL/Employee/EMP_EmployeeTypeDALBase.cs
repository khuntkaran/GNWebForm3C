
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Collections.Generic;

using System.Linq;
using System.Web;


/// <summary>
/// Summary description for EMP_EmployeeTypeDALBase
/// </summary>
/// 
namespace GNForm3C.DAL
{
    public abstract class EMP_EmployeeTypeDALBase : DataBaseConfig
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
        public EMP_EmployeeTypeDALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion  Constructor

        #region ComboBox

        public DataTable SelectComboBox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_EmployeeType_SelectComboBox");

                DataTable dtEMP_EmployeeType = new DataTable("PR_EMP_EmployeeType_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtEMP_EmployeeType);

                return dtEMP_EmployeeType;
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