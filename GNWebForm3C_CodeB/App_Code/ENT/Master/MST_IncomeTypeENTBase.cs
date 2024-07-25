using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
	public abstract class MST_IncomeTypeENTBase
	{
		#region Properties


		protected SqlInt32 _IncomeTypeID;
		public SqlInt32 IncomeTypeID
		{
			get
			{
				return _IncomeTypeID;
			}
			set
			{
				_IncomeTypeID = value;
			}
		}

		protected SqlString _IncomeType;
		public SqlString IncomeType
		{
			get
			{
				return _IncomeType;
			}
			set
			{
				_IncomeType = value;
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

		public MST_IncomeTypeENTBase()
		{

		}

		#endregion Constructor

		#region ToString

		public override String ToString()
		{
			String MST_IncomeTypeENT_String = String.Empty;

			if(!IncomeTypeID.IsNull)
				MST_IncomeTypeENT_String += " IncomeTypeID = " + IncomeTypeID.Value.ToString();

			if(!IncomeType.IsNull)
				MST_IncomeTypeENT_String += "| IncomeType = " + IncomeType.Value;

			if(!HospitalID.IsNull)
				MST_IncomeTypeENT_String += "| HospitalID = " + HospitalID.Value.ToString();

			if(!Remarks.IsNull)
				MST_IncomeTypeENT_String += "| Remarks = " + Remarks.Value;

			if(!UserID.IsNull)
				MST_IncomeTypeENT_String += "| UserID = " + UserID.Value.ToString();

			if(!Created.IsNull)
				MST_IncomeTypeENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

			if(!Modified.IsNull)
				MST_IncomeTypeENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


			MST_IncomeTypeENT_String = MST_IncomeTypeENT_String.Trim();

			return MST_IncomeTypeENT_String;
		}

		#endregion ToString

	}

}