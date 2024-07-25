using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
	public abstract class MST_HospitalENTBase
	{
		#region Properties


		protected SqlInt32 _HospitalID;
		public SqlInt32 HospitalID
		{
			get
			{
				return _HospitalID;
			}
			set
			{
				_HospitalID = value;
			}
		}

		protected SqlString _Hospital;
		public SqlString Hospital
		{
			get
			{
				return _Hospital;
			}
			set
			{
				_Hospital = value;
			}
		}

		protected SqlString _PrintName;
		public SqlString PrintName
		{
			get
			{
				return _PrintName;
			}
			set
			{
				_PrintName = value;
			}
		}

		protected SqlString _PrintLine1;
		public SqlString PrintLine1
		{
			get
			{
				return _PrintLine1;
			}
			set
			{
				_PrintLine1 = value;
			}
		}

		protected SqlString _PrintLine2;
		public SqlString PrintLine2
		{
			get
			{
				return _PrintLine2;
			}
			set
			{
				_PrintLine2 = value;
			}
		}

		protected SqlString _PrintLine3;
		public SqlString PrintLine3
		{
			get
			{
				return _PrintLine3;
			}
			set
			{
				_PrintLine3 = value;
			}
		}

		protected SqlString _FooterName;
		public SqlString FooterName
		{
			get
			{
				return _FooterName;
			}
			set
			{
				_FooterName = value;
			}
		}

		protected SqlString _ReportHeaderName;
		public SqlString ReportHeaderName
		{
			get
			{
				return _ReportHeaderName;
			}
			set
			{
				_ReportHeaderName = value;
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

		public MST_HospitalENTBase()
		{

		}

		#endregion Constructor

		#region ToString

		public override String ToString()
		{
			String MST_HospitalENT_String = String.Empty;

			if(!HospitalID.IsNull)
				MST_HospitalENT_String += " HospitalID = " + HospitalID.Value.ToString();

			if(!Hospital.IsNull)
				MST_HospitalENT_String += "| Hospital = " + Hospital.Value;

			if(!PrintName.IsNull)
				MST_HospitalENT_String += "| PrintName = " + PrintName.Value;

			if(!PrintLine1.IsNull)
				MST_HospitalENT_String += "| PrintLine1 = " + PrintLine1.Value;

			if(!PrintLine2.IsNull)
				MST_HospitalENT_String += "| PrintLine2 = " + PrintLine2.Value;

			if(!PrintLine3.IsNull)
				MST_HospitalENT_String += "| PrintLine3 = " + PrintLine3.Value;

			if(!FooterName.IsNull)
				MST_HospitalENT_String += "| FooterName = " + FooterName.Value;

			if(!ReportHeaderName.IsNull)
				MST_HospitalENT_String += "| ReportHeaderName = " + ReportHeaderName.Value;

			if(!Remarks.IsNull)
				MST_HospitalENT_String += "| Remarks = " + Remarks.Value;

			if(!UserID.IsNull)
				MST_HospitalENT_String += "| UserID = " + UserID.Value.ToString();

			if(!Created.IsNull)
				MST_HospitalENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

			if(!Modified.IsNull)
				MST_HospitalENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


			MST_HospitalENT_String = MST_HospitalENT_String.Trim();

			return MST_HospitalENT_String;
		}

		#endregion ToString

	}

}