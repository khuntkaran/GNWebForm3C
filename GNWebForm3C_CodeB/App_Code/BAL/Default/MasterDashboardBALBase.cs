using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MasterDashboardBALBase
/// </summary>
/// 
namespace GNForm3C.BAL
{
    public class MasterDashboardBALBase
    {
        #region Constructor
        public MasterDashboardBALBase()
        {
            
        }
        #endregion Constructor

        #region Select
        public DataTable SelectCount(SqlInt32 HospitalID)
        {
            MasterDashboardDAL dalMasterDashboard_Count = new MasterDashboardDAL();
            return dalMasterDashboard_Count.SelectCount(HospitalID);
        }

        public DataTable IncomeList(SqlInt32 HospitalID)
        {
            MasterDashboardDAL dalMasterDashboard_Count = new MasterDashboardDAL();
            return dalMasterDashboard_Count.IncomeList(HospitalID);
        }

        public DataTable ExpenseList(SqlInt32 HospitalID)
        {
            MasterDashboardDAL dalMasterDashboard_Count = new MasterDashboardDAL();
            return dalMasterDashboard_Count.ExpenseList(HospitalID);
        }

        public DataTable TreatmentTypeList(SqlInt32 HospitalID)
        {
            MasterDashboardDAL dalMasterDashboard_Count = new MasterDashboardDAL();
            return dalMasterDashboard_Count.TreatmentTypeList(HospitalID);
        }
        #endregion Select
    }
}