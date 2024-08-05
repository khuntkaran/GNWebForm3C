using GNForm3C.DAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for STU_StudentBALBase
/// </summary>
/// 
namespace GNForm3C.BAL
{
    public  abstract class STU_StudentBALBase
    {
        #region Private Fields

        private string _Message;

        #endregion Private Fields

        #region Public Properties

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

        #endregion Public Properties

        #region Constructor
        public STU_StudentBALBase()
        {
           
        }
        #endregion Constructor

        #region InsertOperation
        public Boolean Insert(STU_StudentENT entSTU_Student)
        {
            STU_StudentDAL dalSTU_Student = new STU_StudentDAL();
            if(dalSTU_Student.Insert(entSTU_Student))
            {
                return true;
            }
            else
            {
                Message = dalSTU_Student.Message;
                return false;
            }
        }
        #endregion InsertOperation

        #region UpdateOperation
        public Boolean Update(STU_StudentENT entSTU_Student)
        {
            STU_StudentDAL dalSTU_Student = new STU_StudentDAL();
            if (dalSTU_Student.Update(entSTU_Student))
            {
                return true;
            }
            else
            {
                Message = dalSTU_Student.Message;
                return false;
            }
        }

        public Boolean UpdateBranchIntakeMatrix(STU_StudentBranchIntakeMatrixENT entSTU_StudentBranchIntakeMatrix)
        {
            STU_StudentDAL dalSTU_Student = new STU_StudentDAL();
            if (dalSTU_Student.UpdateBranchIntakeMatrix(entSTU_StudentBranchIntakeMatrix))
            {
                return true;
            }
            else
            {
                Message = dalSTU_Student.Message;
                return false;
            }
        }
        #endregion UpdateOperation

        #region DeleteOperation
        public Boolean Delete(SqlInt32 StudentID)
        {
            STU_StudentDAL dalSTU_Student = new STU_StudentDAL();
            if (dalSTU_Student.Delete(StudentID))
            {
                return true;
            }
            else
            {
                Message = dalSTU_Student.Message;
                return false;
            }
        }
        #endregion DeleteOperation

        #region SelectOperation
        public STU_StudentENT SelectPK(SqlInt32 StudentID)
        {
            STU_StudentDAL dalSTU_Student = new STU_StudentDAL();
            return dalSTU_Student.SelectPK(StudentID);
        }

        public DataTable SelectView(SqlInt32 StudentID)
        {
            STU_StudentDAL dalSTU_Student = new STU_StudentDAL();
            return dalSTU_Student.SelectView(StudentID);
        }


        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString StudentName, SqlString EnrollmentNo, SqlInt32 CurrentSem, SqlString EmailInstitute, SqlString EmailPersonal, SqlString Gender, SqlInt32 RollNo, SqlString ContactNo)
        {
            STU_StudentDAL dalSTU_Student = new STU_StudentDAL();
            return dalSTU_Student.SelectPage( PageOffset,  PageSize, out  TotalRecords,  StudentName,  EnrollmentNo,  CurrentSem,  EmailInstitute,  EmailPersonal,  Gender,  RollNo,  ContactNo);
        }

        public DataTable SelectBranchIntakeMatrix()
        {
            STU_StudentDAL dalSTU_Student = new STU_StudentDAL();
            return dalSTU_Student.SelectBranchIntakeMatrix();
        }
        #endregion SelectOperation

    }
}