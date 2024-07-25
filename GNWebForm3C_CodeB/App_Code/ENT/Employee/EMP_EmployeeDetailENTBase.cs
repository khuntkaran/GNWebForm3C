using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EMP_EmployeeDetailENTBase
/// </summary>
/// 
namespace GNForm3C.ENT
{
    public class EMP_EmployeeDetailENTBase
    {
        #region Properties


        protected SqlInt32 _EmployeeID;
        public SqlInt32 EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
            }
        }

        protected SqlString _EmployeeName;
        public SqlString EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }

        protected SqlInt32 _EmployeeTypeID;
        public SqlInt32 EmployeeTypeID
        {
            get
            {
                return _EmployeeTypeID;
            }
            set
            {
                _EmployeeTypeID = value;
            }
        }

        protected SqlString _Remarks;
        public SqlString Remarks
        {
            get
            {
                return _Remarks;
            }
            set
            {
                _Remarks = value;
            }
        }

        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        protected SqlDateTime _Created;
        public SqlDateTime Created
        {
            get
            {
                return _Created;
            }
            set
            {
                _Created = value;
            }
        }

        protected SqlDateTime _Modified;
        public SqlDateTime Modified
        {
            get
            {
                return _Modified;
            }
            set
            {
                _Modified = value;
            }
        }

        #endregion Properties

        #region Constructor
        public EMP_EmployeeDetailENTBase()
        {
           
        }
        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String MST_EmployeeDetailENT_String = String.Empty;

            if (!EmployeeID.IsNull)
                MST_EmployeeDetailENT_String += " EmployeeID = " + EmployeeID.Value.ToString();

            if (!EmployeeName.IsNull)
                MST_EmployeeDetailENT_String += "| EmployeeName = " + EmployeeName.Value;

            if (!EmployeeTypeID.IsNull)
                MST_EmployeeDetailENT_String += "| EmployeeTypeID = " + EmployeeTypeID.Value.ToString();

            if (!Remarks.IsNull)
                MST_EmployeeDetailENT_String += "| Remarks = " + Remarks.Value;

            if (!UserID.IsNull)
                MST_EmployeeDetailENT_String += "| UserID = " + UserID.Value.ToString();

            if (!Created.IsNull)
                MST_EmployeeDetailENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                MST_EmployeeDetailENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            MST_EmployeeDetailENT_String = MST_EmployeeDetailENT_String.Trim();

            return MST_EmployeeDetailENT_String;
        }

        #endregion ToString
    }
}