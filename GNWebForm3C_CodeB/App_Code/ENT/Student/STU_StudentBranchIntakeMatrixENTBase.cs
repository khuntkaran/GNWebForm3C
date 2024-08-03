using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for STU_StudentBranchIntakeMatrixENTBase
/// </summary>
/// 
namespace GNForm3C.ENT
{
    public abstract class STU_StudentBranchIntakeMatrixENTBase
    {
        public STU_StudentBranchIntakeMatrixENTBase()
        {
            
        }

        #region Properties
        protected SqlInt32 _AdmissionYear;
        public SqlInt32 AdmissionYear
        {
            get
            {
                return _AdmissionYear;
            }
            set
            {
                _AdmissionYear = value;
            }
        }

        protected SqlInt32 _Intake;
        public SqlInt32 Intake
        {
            get
            {
                return _Intake;
            }
            set
            {
                _Intake = value;
            }
        }

        protected SqlString _Branch;
        public SqlString Branch
        {
            get
            {
                return _Branch;
            }
            set
            {
                _Branch = value;
            }
        }
        #endregion Properties
    }
}