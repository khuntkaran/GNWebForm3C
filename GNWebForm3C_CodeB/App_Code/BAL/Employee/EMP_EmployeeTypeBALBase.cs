using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EMP_EmployeeTypeBALBase
/// </summary>
/// 
namespace GNForm3C.BAL
{
    public abstract class EMP_EmployeeTypeBALBase
    {
        public EMP_EmployeeTypeBALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable SelecComboBox()
        {
            EMP_EmployeeTypeDAL dalEmployeeType = new EMP_EmployeeTypeDAL();
            return dalEmployeeType.SelectComboBox();
        }
    }
}