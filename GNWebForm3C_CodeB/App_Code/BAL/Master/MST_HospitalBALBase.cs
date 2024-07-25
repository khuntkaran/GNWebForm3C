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
	public abstract class MST_HospitalBALBase
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

		public MST_HospitalBALBase()
		{

		}

		#endregion Constructor

		#region InsertOperation

		public Boolean Insert(MST_HospitalENT entMST_Hospital)
		{
			MST_HospitalDAL dalMST_Hospital = new MST_HospitalDAL();
			if(dalMST_Hospital.Insert(entMST_Hospital))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_Hospital.Message;
				return false;
			}
		}

		#endregion InsertOperation

		#region UpdateOperation

		public Boolean Update(MST_HospitalENT entMST_Hospital)
		{
			MST_HospitalDAL dalMST_Hospital = new MST_HospitalDAL();
			if(dalMST_Hospital.Update(entMST_Hospital))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_Hospital.Message;
				return false;
			}
		}

		#endregion UpdateOperation

		#region DeleteOperation

		public Boolean Delete(SqlInt32 HospitalID)
		{
			MST_HospitalDAL dalMST_Hospital = new MST_HospitalDAL();
			if(dalMST_Hospital.Delete(HospitalID))
			{
				return true;
			}
			else
			{
				this.Message = dalMST_Hospital.Message;
				return false;
			}
		}

		#endregion DeleteOperation

		#region SelectOperation

		public MST_HospitalENT SelectPK(SqlInt32 HospitalID)
		{
			MST_HospitalDAL dalMST_Hospital = new MST_HospitalDAL();
			return dalMST_Hospital.SelectPK(HospitalID);
		}
		public DataTable SelectView(SqlInt32 HospitalID)
		{
			MST_HospitalDAL dalMST_Hospital = new MST_HospitalDAL();
			return dalMST_Hospital.SelectView(HospitalID);
		}
		public DataTable SelectAll()
		{
			MST_HospitalDAL dalMST_Hospital = new MST_HospitalDAL();
			return dalMST_Hospital.SelectAll();
		}
		public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString Hospital, SqlString PrintName, SqlString PrintLine1, SqlString PrintLine2, SqlString PrintLine3, SqlString FooterName, SqlString ReportHeaderName)
		{
			MST_HospitalDAL dalMST_Hospital = new MST_HospitalDAL();
			return dalMST_Hospital.SelectPage(PageOffset, PageSize, out TotalRecords, Hospital, PrintName, PrintLine1, PrintLine2, PrintLine3, FooterName, ReportHeaderName);
		}

		#endregion SelectOperation

		#region ComboBox

        public DataTable SelecComboBox()
		{
			MST_HospitalDAL dalMST_Hospital = new MST_HospitalDAL();
            return dalMST_Hospital.SelectComboBox();
		}

		#endregion ComboBox

	}

}