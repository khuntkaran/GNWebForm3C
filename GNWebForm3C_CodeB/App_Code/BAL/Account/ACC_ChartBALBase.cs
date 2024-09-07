using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ACC_ChartBALBase
/// </summary>
/// 
namespace GNForm3C.BAL
{
    public class ACC_ChartBALBase
    {
        public ACC_ChartBALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable GetHospitalName()
        {
            ACC_ChartDAL aCC_ChartDAL = new ACC_ChartDAL();
            return aCC_ChartDAL.GetHospitalName();
        }
        public DataTable GetIncomeExpenseDataByHospital(SqlInt32 HospitalID)
        {
            ACC_ChartDAL aCC_ChartDAL = new ACC_ChartDAL();
            return aCC_ChartDAL.GetIncomeExpenseDataByHospital(HospitalID);
        }
    }
}