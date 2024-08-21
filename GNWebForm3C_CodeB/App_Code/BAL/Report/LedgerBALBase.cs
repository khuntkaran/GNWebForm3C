using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LedgerBALBase
/// </summary>
/// 
namespace GNForm3C.BAL
{
    public abstract class LedgerBALBase
    {
        public LedgerBALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable PP_HospitalWise_FinYearWise_IncomeExpenseList()
        {
            LedgerDAL ledgerDAL = new LedgerDAL();
            return ledgerDAL.PP_HospitalWise_FinYearWise_IncomeExpenseList();
        }
    }
}