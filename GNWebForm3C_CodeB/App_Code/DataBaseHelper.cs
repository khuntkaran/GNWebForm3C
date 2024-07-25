using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlTypes;

namespace GNForm3C.DAL
{
    
    public class DataBaseHelper
    {
        Int32 DefaultCommandTimeOutSecond = 180;
        public DataBaseHelper()
        {

        }

        public Int32 ExecuteNonQuery(SqlDatabase sqlDB, DbCommand dbCMD)
        {
            dbCMD.CommandTimeout = DefaultCommandTimeOutSecond;
            return sqlDB.ExecuteNonQuery(dbCMD);
        }

        public DataTable LoadDataTable(SqlDatabase sqlDB, DbCommand dbCMD, DataTable dt)
        {
            dbCMD.CommandTimeout = DefaultCommandTimeOutSecond;
            using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
            {
                dt.Load(dr);
            }
            return dt;
        }

        public Int32 ExecuteNonQuery(SqlDatabase sqlDB, DbCommand dbCMD, Int32 CommandTimeOutSecond)
        {
            dbCMD.CommandTimeout = CommandTimeOutSecond;
            return sqlDB.ExecuteNonQuery(dbCMD);
        }

        public DataTable LoadDataTable(SqlDatabase sqlDB, DbCommand dbCMD, DataTable dt, Int32 CommandTimeOutSecond)
        {
            dbCMD.CommandTimeout = CommandTimeOutSecond;
            using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
            {
                dt.Load(dr);
            }
            return dt;
        }

        public IDataReader ExecuteReader(SqlDatabase sqlDB, DbCommand dbCMD)
        {
            dbCMD.CommandTimeout = DefaultCommandTimeOutSecond;
            return sqlDB.ExecuteReader(dbCMD);
        }


        //public SqlString ExecuteScalar_Int32(SqlDatabase sqlDB, DbCommand dbCMD)
        //{
        //    return sqlDB.ExecuteScalar(dbCMD);
        //}
        public object ExecuteScalar_object(SqlDatabase sqlDB, DbCommand dbCMD)
        {
            dbCMD.CommandTimeout = DefaultCommandTimeOutSecond;
            return sqlDB.ExecuteScalar(dbCMD);
        }
    }
}
