using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
	public abstract class MST_TreatmentENTBase
	{
		#region Properties


		protected SqlInt32 _TreatmentID;
		public SqlInt32 TreatmentID
		{
			get
			{
				return _TreatmentID;
			}
			set
			{
				_TreatmentID = value;
			}
		}

		protected SqlString _Treatment;
		public SqlString Treatment
		{
			get
			{
				return _Treatment;
			}
			set
			{
				_Treatment = value;
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

		public MST_TreatmentENTBase()
		{

		}

		#endregion Constructor

		#region ToString

		public override String ToString()
		{
			String MST_TreatmentENT_String = String.Empty;

			if(!TreatmentID.IsNull)
				MST_TreatmentENT_String += " TreatmentID = " + TreatmentID.Value.ToString();

			if(!Treatment.IsNull)
				MST_TreatmentENT_String += "| Treatment = " + Treatment.Value;

			if(!HospitalID.IsNull)
				MST_TreatmentENT_String += "| HospitalID = " + HospitalID.Value.ToString();

			if(!Remarks.IsNull)
				MST_TreatmentENT_String += "| Remarks = " + Remarks.Value;

			if(!UserID.IsNull)
				MST_TreatmentENT_String += "| UserID = " + UserID.Value.ToString();

			if(!Created.IsNull)
				MST_TreatmentENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

			if(!Modified.IsNull)
				MST_TreatmentENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


			MST_TreatmentENT_String = MST_TreatmentENT_String.Trim();

			return MST_TreatmentENT_String;
		}

		#endregion ToString

	}

}