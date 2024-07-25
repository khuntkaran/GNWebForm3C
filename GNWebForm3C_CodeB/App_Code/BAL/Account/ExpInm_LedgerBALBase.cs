using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExpInm_LedgerBALBase
/// </summary>
/// 
namespace GNForm3C.BAL
{
    public class ExpInm_LedgerBALBase
    {
        #region Constructor
        public ExpInm_LedgerBALBase()
        {

        }
        #endregion Constructor


        #region SelectOperation
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords,  SqlDateTime FromDate, SqlDateTime ToDate)
        {
            ExpInm_LedgerListDAL dalExpInm_LedgerList = new ExpInm_LedgerListDAL();
            return dalExpInm_LedgerList.SelectPage(PageOffset, PageSize, out TotalRecords, FromDate,ToDate);
        }

        #endregion SelectOperation

    }
}