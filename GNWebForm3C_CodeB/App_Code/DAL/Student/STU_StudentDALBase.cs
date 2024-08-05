using GNForm3C.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

/// <summary>
/// Summary description for STU_StudentDALBase
/// </summary>
/// 
namespace GNForm3C.DAL
{
    public abstract class STU_StudentDALBase: DataBaseConfig
    {
        #region Properties

        private string _Message;
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

        #endregion Properties

        #region Constructor
        public STU_StudentDALBase()
        {
            
        }
        #endregion Constructor

        #region InsertOperation
        public Boolean Insert(STU_StudentENT entSTU_Student)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_STU_Students_Insert");
                sqlDB.AddOutParameter(dbCMD, "@StudentID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@StudentName", SqlDbType.VarChar, entSTU_Student.StudentName);
                sqlDB.AddInParameter(dbCMD, "@EnrollmentNo", SqlDbType.VarChar, entSTU_Student.EnrollmentNo);
                sqlDB.AddInParameter(dbCMD, "@RollNo", SqlDbType.Int, entSTU_Student.RollNo);
                sqlDB.AddInParameter(dbCMD, "@CurrentSem", SqlDbType.Int, entSTU_Student.CurrentSem);
                sqlDB.AddInParameter(dbCMD, "@EmailInstitute", SqlDbType.VarChar, entSTU_Student.EmailInstitute);
                sqlDB.AddInParameter(dbCMD, "@EmailPersonal", SqlDbType.VarChar, entSTU_Student.EmailPersonal);
                sqlDB.AddInParameter(dbCMD, "@BirthDate", SqlDbType.DateTime, entSTU_Student.BirthDate);
                sqlDB.AddInParameter(dbCMD, "@ContactNo", SqlDbType.VarChar, entSTU_Student.ContactNo);
                sqlDB.AddInParameter(dbCMD, "@Gender", SqlDbType.VarChar, entSTU_Student.Gender);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entSTU_Student.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entSTU_Student.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entSTU_Student.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB,dbCMD);

                entSTU_Student.StudentID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@StudentID"].Value);


                return true;
            }
            catch(SqlException ex)
            {
                Message = SQLDataExceptionMessage(ex);
                if (SQLDataExceptionHandler(ex))
                    throw;
                return false;
            }
            catch(Exception ex) 
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }
        #endregion InsertOperation

        #region UpdateOperation
        public Boolean Update(STU_StudentENT entSTU_Student)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_STU_Students_Update");
                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, entSTU_Student.StudentID);
                sqlDB.AddInParameter(dbCMD, "@StudentName", SqlDbType.VarChar, entSTU_Student.StudentName);
                sqlDB.AddInParameter(dbCMD, "@EnrollmentNo", SqlDbType.VarChar, entSTU_Student.EnrollmentNo);
                sqlDB.AddInParameter(dbCMD, "@RollNo", SqlDbType.Int, entSTU_Student.RollNo);
                sqlDB.AddInParameter(dbCMD, "@CurrentSem", SqlDbType.Int, entSTU_Student.CurrentSem);
                sqlDB.AddInParameter(dbCMD, "@EmailInstitute", SqlDbType.VarChar, entSTU_Student.EmailInstitute);
                sqlDB.AddInParameter(dbCMD, "@EmailPersonal", SqlDbType.VarChar, entSTU_Student.EmailPersonal);
                sqlDB.AddInParameter(dbCMD, "@BirthDate", SqlDbType.DateTime, entSTU_Student.BirthDate);
                sqlDB.AddInParameter(dbCMD, "@ContactNo", SqlDbType.VarChar, entSTU_Student.ContactNo);
                sqlDB.AddInParameter(dbCMD, "@Gender", SqlDbType.VarChar, entSTU_Student.Gender);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entSTU_Student.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entSTU_Student.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entSTU_Student.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                return true;
            }
            catch(SqlException ex)
            {
                Message = SQLDataExceptionMessage(ex);
                if (SQLDataExceptionHandler(ex))
                    throw;
                return false;
            }
            catch(Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        public Boolean UpdateBranchIntakeMatrix(STU_StudentBranchIntakeMatrixENT entSTU_StudentBranchIntakeMatrix)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_STU_Student_UpdateBranchIntakeMatrix");
                sqlDB.AddInParameter(dbCMD, "@AdmissionYear", SqlDbType.Int, entSTU_StudentBranchIntakeMatrix.AdmissionYear);
                sqlDB.AddInParameter(dbCMD, "@Branch", SqlDbType.VarChar, entSTU_StudentBranchIntakeMatrix.Branch);
                sqlDB.AddInParameter(dbCMD, "@Intake", SqlDbType.Int, entSTU_StudentBranchIntakeMatrix.Intake);
                
                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                return true;
            }
            catch (SqlException ex)
            {
                Message = SQLDataExceptionMessage(ex);
                if (SQLDataExceptionHandler(ex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }
        #endregion UpdateOpertion

        #region DeleteOperation
        public Boolean Delete(SqlInt32 StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD =  sqlDB.GetStoredProcCommand("PR_STU_Students_Delete");
               
                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, StudentID);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery (sqlDB, dbCMD);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }
        #endregion DeleteOperation

        #region SelectOperation
        public STU_StudentENT SelectPK(SqlInt32 StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_STU_Students_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, StudentID);

                STU_StudentENT entSTU_Student = new STU_StudentENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB,dbCMD))
                {
                    while(dr.Read())
                    {
                        if (!dr["StudentID"].Equals(System.DBNull.Value))
                            entSTU_Student.StudentID = Convert.ToInt32(dr["StudentID"]);
                        if (!dr["StudentName"].Equals(System.DBNull.Value))
                            entSTU_Student.StudentName = Convert.ToString(dr["StudentName"]);
                        if (!dr["EnrollmentNo"].Equals(System.DBNull.Value))
                            entSTU_Student.EnrollmentNo = Convert.ToString(dr["EnrollmentNo"]);
                        if (!dr["RollNo"].Equals(System.DBNull.Value))
                            entSTU_Student.RollNo = Convert.ToInt32(dr["RollNo"]);
                        if (!dr["CurrentSem"].Equals(System.DBNull.Value))
                            entSTU_Student.CurrentSem = Convert.ToInt32(dr["CurrentSem"]);
                        if (!dr["EmailInstitute"].Equals(System.DBNull.Value))
                            entSTU_Student.EmailInstitute = Convert.ToString(dr["EmailInstitute"]);
                        if (!dr["EmailPersonal"].Equals(System.DBNull.Value))
                            entSTU_Student.EmailPersonal = Convert.ToString(dr["EmailPersonal"]);
                        if (!dr["BirthDate"].Equals(System.DBNull.Value))
                            entSTU_Student.BirthDate = Convert.ToDateTime(dr["BirthDate"]);
                        if (!dr["ContactNo"].Equals(System.DBNull.Value))
                            entSTU_Student.ContactNo = Convert.ToString(dr["ContactNo"]);
                        if (!dr["Gender"].Equals(System.DBNull.Value))
                            entSTU_Student.Gender = Convert.ToString(dr["Gender"]);
                        if (!dr["UserID"].Equals(System.DBNull.Value))
                            entSTU_Student.UserID = Convert.ToInt32(dr["UserID"]);
                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entSTU_Student.Created = Convert.ToDateTime(dr["Created"]);
                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entSTU_Student.Modified = Convert.ToDateTime(dr["Modified"]);
                    }
                }

                return entSTU_Student;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        public DataTable SelectView(SqlInt32 StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_STU_Students_SelectView");

                sqlDB.AddInParameter(dbCMD,"@StudentID",SqlDbType.Int, StudentID);

                DataTable dtSTU_Student = new DataTable("PR_STU_Students_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtSTU_Student);

                return dtSTU_Student;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords,SqlString StudentName, SqlString EnrollmentNo,SqlInt32 CurrentSem,SqlString EmailInstitute,SqlString EmailPersonal,SqlString Gender,SqlInt32 RollNo,SqlString ContactNo)
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_STU_Students_SelectPage");
                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

                sqlDB.AddInParameter(dbCMD, "@StudentName", SqlDbType.VarChar, StudentName);
                sqlDB.AddInParameter(dbCMD, "@EnrollmentNo", SqlDbType.VarChar, EnrollmentNo);
                sqlDB.AddInParameter(dbCMD, "@RollNo", SqlDbType.Int, RollNo);
                sqlDB.AddInParameter(dbCMD, "@CurrentSem", SqlDbType.Int, CurrentSem);
                sqlDB.AddInParameter(dbCMD, "@EmailInstitute", SqlDbType.VarChar, EmailInstitute);
                sqlDB.AddInParameter(dbCMD, "@EmailPersonal", SqlDbType.VarChar, EmailPersonal);
                sqlDB.AddInParameter(dbCMD, "@ContactNo", SqlDbType.VarChar, ContactNo);
                sqlDB.AddInParameter(dbCMD, "@Gender", SqlDbType.VarChar, Gender);

                DataTable dtSTU_Student = new DataTable("PR_STU_Students_SelectPage");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtSTU_Student);

                TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

                return dtSTU_Student;

            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }                                                                                          

        public DataTable SelectBranchIntakeMatrix()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_STU_Student_GetBranchIntakeMatrix");

                DataTable dtSTU_Student = new DataTable("PR_STU_Student_GetBranchIntakeMatrix");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtSTU_Student);

                return dtSTU_Student;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }
        #endregion SelectOperation                                                                  
    }                                                                                                      
}                                                                                                          
                                                                                                        