using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MST_DSB2BALBase
/// </summary>
/// 
namespace GNForm3C.BAL
{

    public abstract class MST_DSB2BALBase
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

        public MST_DSB2BALBase()
        {

        }

        #endregion Constructor

        #region Select
        public DataTable SelectCount(SqlInt32 FinYearID)
        {
            MST_DSB2DAL dalMST_DSB2DAL = new MST_DSB2DAL();
            return dalMST_DSB2DAL.SelectCount(FinYearID);
        }

        public DataTable CategoryWiseIncomeTotalList(SqlInt32 FinYearID)
        {
            MST_DSB2DAL dalMST_DSB2DAL = new MST_DSB2DAL();
            return dalMST_DSB2DAL.CategoryWiseIncomeTotalList(FinYearID);
        }

        public DataTable CategoryWiseExpenseTotalList(SqlInt32 FinYearID)
        {
            MST_DSB2DAL dalMST_DSB2DAL = new MST_DSB2DAL();
            return dalMST_DSB2DAL.CategoryWiseExpenseTotalList(FinYearID);
        }

        public DataTable HospitalWisePatientCountList(SqlInt32 FinYearID)
        {
            MST_DSB2DAL dalMST_DSB2DAL = new MST_DSB2DAL();
            return dalMST_DSB2DAL.HospitalWisePatientCountList(FinYearID);
        }

        public DataTable AccountTranscationList(SqlInt32 FinYearID)
        {
            MST_DSB2DAL dalMST_DSB2DAL = new MST_DSB2DAL();
            return dalMST_DSB2DAL.AccountTranscationList(FinYearID);
        }

        #endregion Select

    }
}