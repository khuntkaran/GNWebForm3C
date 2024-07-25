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
	public abstract class MST_TreatmentBALBase
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

		public MST_TreatmentBALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(MST_TreatmentENT entMST_Treatment)
		{
			MST_TreatmentDAL dalMST_Treatment = new MST_TreatmentDAL();
			if(dalMST_Treatment.Insert(entMST_Treatment))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_Treatment.Message;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

		public Boolean Update(MST_TreatmentENT entMST_Treatment)
		{
			MST_TreatmentDAL dalMST_Treatment = new MST_TreatmentDAL();
			if(dalMST_Treatment.Update(entMST_Treatment))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_Treatment.Message;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 TreatmentID)
		{
			MST_TreatmentDAL dalMST_Treatment = new MST_TreatmentDAL();
			if(dalMST_Treatment.Delete(TreatmentID))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_Treatment.Message;
				return false;
			}
		}

		#endregion DeleteOperation

		#region SelectOperation

		public MST_TreatmentENT SelectPK(SqlInt32 TreatmentID)
		{
			MST_TreatmentDAL dalMST_Treatment = new MST_TreatmentDAL();
			return dalMST_Treatment.SelectPK(TreatmentID);
		}
		public DataTable SelectView(SqlInt32 TreatmentID)
		{
			MST_TreatmentDAL dalMST_Treatment = new MST_TreatmentDAL();
			return dalMST_Treatment.SelectView(TreatmentID);
		}
		public DataTable SelectAll()
		{
			MST_TreatmentDAL dalMST_Treatment = new MST_TreatmentDAL();
			return dalMST_Treatment.SelectAll();
		}
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString Treatment, SqlInt32 HospitalID)
		{ 
			MST_TreatmentDAL dalMST_Treatment = new MST_TreatmentDAL();
			return dalMST_Treatment.SelectPage(PageOffset, PageSize, out TotalRecords, Treatment, HospitalID);
		}

		#endregion SelectOperation

		#region ComboBox

		public DataTable SelectComboBox()
		{
			MST_TreatmentDAL dalMST_Treatment = new MST_TreatmentDAL();
			return dalMST_Treatment.SelectComboBox();
		}

		#endregion ComboBox

	}

}