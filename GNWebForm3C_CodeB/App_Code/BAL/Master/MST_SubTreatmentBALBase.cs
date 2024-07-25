using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using GNForm3C;
using GNForm3C.DAL;
using GNForm3C.ENT;

namespace GNForm3C.BAL
{
	public abstract class MST_SubTreatmentBALBase
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

		public MST_SubTreatmentBALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(MST_SubTreatmentENT entMST_SubTreatment)
		{
			MST_SubTreatmentDAL dalMST_SubTreatment = new MST_SubTreatmentDAL();
			if(dalMST_SubTreatment.Insert(entMST_SubTreatment))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_SubTreatment.Message;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

		public Boolean Update(MST_SubTreatmentENT entMST_SubTreatment)
		{
			MST_SubTreatmentDAL dalMST_SubTreatment = new MST_SubTreatmentDAL();
			if(dalMST_SubTreatment.Update(entMST_SubTreatment))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_SubTreatment.Message;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 SubTreatmentID)
		{
			MST_SubTreatmentDAL dalMST_SubTreatment = new MST_SubTreatmentDAL();
			if(dalMST_SubTreatment.Delete(SubTreatmentID))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_SubTreatment.Message;
				return false;
			}
		}

		#endregion DeleteOperation

		#region SelectOperation

		public MST_SubTreatmentENT SelectPK(SqlInt32 SubTreatmentID)
		{
			MST_SubTreatmentDAL dalMST_SubTreatment = new MST_SubTreatmentDAL();
			return dalMST_SubTreatment.SelectPK(SubTreatmentID);
		}
		public DataTable SelectView(SqlInt32 SubTreatmentID)
		{
			MST_SubTreatmentDAL dalMST_SubTreatment = new MST_SubTreatmentDAL();
			return dalMST_SubTreatment.SelectView(SubTreatmentID);
		}
		public DataTable SelectAll()
		{
			MST_SubTreatmentDAL dalMST_SubTreatment = new MST_SubTreatmentDAL();
			return dalMST_SubTreatment.SelectAll();
		}
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString SubTreatmentName, SqlInt32 SequenceNo, SqlDecimal Rate, SqlInt32 HospitalID, SqlString DefaultUnit)
		{
			MST_SubTreatmentDAL dalMST_SubTreatment = new MST_SubTreatmentDAL();
            return dalMST_SubTreatment.SelectPage(PageOffset, PageSize, out TotalRecords, SubTreatmentName, SequenceNo, Rate, HospitalID, DefaultUnit);
		}

		#endregion SelectOperation

		#region ComboBox

		public DataTable SelectComboBox()
		{
			MST_SubTreatmentDAL dalMST_SubTreatment = new MST_SubTreatmentDAL();
			return dalMST_SubTreatment.SelectComboBox();
		}

		#endregion ComboBox

	}

}