using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using GNForm3C;

namespace GNForm3C.DAL
{
	public class SEC_UserDAL : SEC_UserDALBase
	{
        public DataTable SelectByUserNameAndPassword(SqlString UserName, SqlString Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_SelectByUserNameAndPassword");

                sqlDB.AddInParameter(dbCMD, "@UserName", SqlDbType.NVarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "@Password", SqlDbType.NVarChar, Password);


                DataTable dtSEC_User = new DataTable("PR_SEC_User_SelectByUserNameAndPassword");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtSEC_User);

                return dtSEC_User;
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