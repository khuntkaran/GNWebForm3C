using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
	public abstract class MST_SubTreatmentENTBase
	{
		#region Properties


		protected SqlInt32 _SubTreatmentID;
		public SqlInt32 SubTreatmentID
		{
			get
			{
				return _SubTreatmentID;
			}
			set
			{
				_SubTreatmentID = value;
			}
		}

		protected SqlString _SubTreatmentName;
		public SqlString SubTreatmentName
		{
			get
			{
				return _SubTreatmentName;
			}
			set
			{
				_SubTreatmentName = value;
			}
		}

		protected SqlInt32 _SequenceNo;
		public SqlInt32 SequenceNo
		{
			get
			{
				return _SequenceNo;
			}
			set
			{
				_SequenceNo = value;
			}
		}

		protected SqlDecimal _Rate;
		public SqlDecimal Rate
		{
			get
			{
				return _Rate;
			}
			set
			{
				_Rate = value;
			}
		}

		protected SqlBoolean _IsInGrid;
		public SqlBoolean IsInGrid
		{
			get
			{
				return _IsInGrid;
			}
			set
			{
				_IsInGrid = value;
			}
		}

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

		protected SqlBoolean _IsPerDay;
		public SqlBoolean IsPerDay
		{
			get
			{
				return _IsPerDay;
			}
			set
			{
				_IsPerDay = value;
			}
		}

		protected SqlString _DefaultUnit;
		public SqlString DefaultUnit
		{
			get
			{
				return _DefaultUnit;
			}
			set
			{
				_DefaultUnit = value;
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

		public MST_SubTreatmentENTBase()
		{

		}

		#endregion Constructor

		#region ToString

		public override String ToString()
		{
			String MST_SubTreatmentENT_String = String.Empty;

			if(!SubTreatmentID.IsNull)
				MST_SubTreatmentENT_String += " SubTreatmentID = " + SubTreatmentID.Value.ToString();

			if(!SubTreatmentName.IsNull)
				MST_SubTreatmentENT_String += "| SubTreatmentName = " + SubTreatmentName.Value;

			if(!SequenceNo.IsNull)
				MST_SubTreatmentENT_String += "| SequenceNo = " + SequenceNo.Value.ToString();

			if(!Rate.IsNull)
				MST_SubTreatmentENT_String += "| Rate = " + Rate.Value.ToString();

			if(!IsInGrid.IsNull)
				MST_SubTreatmentENT_String += "| IsInGrid = " + IsInGrid.Value;

			if(!HospitalID.IsNull)
				MST_SubTreatmentENT_String += "| HospitalID = " + HospitalID.Value.ToString();

			if(!IsPerDay.IsNull)
				MST_SubTreatmentENT_String += "| IsPerDay = " + IsPerDay.Value;

			if(!DefaultUnit.IsNull)
				MST_SubTreatmentENT_String += "| DefaultUnit = " + DefaultUnit.Value;

			if(!Remarks.IsNull)
				MST_SubTreatmentENT_String += "| Remarks = " + Remarks.Value;

			if(!UserID.IsNull)
				MST_SubTreatmentENT_String += "| UserID = " + UserID.Value.ToString();

			if(!Created.IsNull)
				MST_SubTreatmentENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

			if(!Modified.IsNull)
				MST_SubTreatmentENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


			MST_SubTreatmentENT_String = MST_SubTreatmentENT_String.Trim();

			return MST_SubTreatmentENT_String;
		}

		#endregion ToString

	}

}