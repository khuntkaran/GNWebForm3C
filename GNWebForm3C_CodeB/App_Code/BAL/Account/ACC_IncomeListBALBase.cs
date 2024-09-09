using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ACC_IncomeListBALBase
/// </summary>
/// 
namespace GNForm3C.BAL
{
    public abstract class ACC_IncomeListBALBase
    {
        public ACC_IncomeListBALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable ExecuteProcedure(int? HospitalID, int? FinYearID)
        {
            ACC_IncomeListDAL aCC_IncomeListDAL = new ACC_IncomeListDAL();
            return aCC_IncomeListDAL.ExecuteProcedure(HospitalID , FinYearID);
        }
    }
}