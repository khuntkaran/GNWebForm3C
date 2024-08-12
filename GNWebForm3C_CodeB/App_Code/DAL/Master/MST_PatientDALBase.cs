using GNForm3C.ENT;
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
/// Summary description for MST_PatientDALBase
/// </summary>
/// 
namespace GNForm3C.DAL
{
    public abstract class MST_PatientDALBase : DataBaseConfig
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

        public MST_PatientDALBase()
        {

        }

        #endregion Constructor

        #region Insert
        public SqlInt32 InsertPatient(MST_PatientENT entMST_Patient)
        {
            SqlInt32 PatientID = -1;

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_GNPatient_Insert");

                sqlDB.AddOutParameter(dbCMD, "@PatientID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@PatientName", SqlDbType.NVarChar, entMST_Patient.PatientName);
                sqlDB.AddInParameter(dbCMD, "@Age", SqlDbType.Int, entMST_Patient.Age);
                sqlDB.AddInParameter(dbCMD, "@MobileNo", SqlDbType.NVarChar, entMST_Patient.MobileNo);
                sqlDB.AddInParameter(dbCMD, "@DOB", SqlDbType.DateTime, entMST_Patient.DOB);
                sqlDB.AddInParameter(dbCMD, "@PrimaryDesc", SqlDbType.NVarChar, entMST_Patient.PrimaryDesc);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Patient.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Patient.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Patient.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                if (!(dbCMD.Parameters["@PatientID"].Value).Equals(DBNull.Value))
                {
                    entMST_Patient.PatientID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@PatientID"].Value);
                    PatientID = entMST_Patient.PatientID;
                }

                return PatientID;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return PatientID;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return PatientID;
            }
        }

        #endregion

        #region Select
        public DataTable SelectView(SqlInt32 PatientID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_SelectView");

                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, PatientID);

                DataTable dtACC_GNTransaction = new DataTable("PR_MST_Patient_SelectView");

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
        #endregion Select

    }
}