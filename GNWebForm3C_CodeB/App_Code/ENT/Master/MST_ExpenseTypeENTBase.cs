using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
	public abstract class MST_ExpenseTypeENTBase
	{
		#region Properties


		protected SqlInt32 _ExpenseTypeID;
		public SqlInt32 ExpenseTypeID
		{
			get
			{
				return _ExpenseTypeID;
			}
			set
			{
				_ExpenseTypeID = value;
			}
		}

		protected SqlString _ExpenseType;
		public SqlString ExpenseType
		{
			get
			{
				return _ExpenseType;
			}
			set
			{
				_ExpenseType = value;
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

		public MST_ExpenseTypeENTBase()
		{

		}

		#endregion Constructor

		#region ToString

		public override String ToString()
		{
			String MST_ExpenseTypeENT_String = String.Empty;

			if(!ExpenseTypeID.IsNull)
				MST_ExpenseTypeENT_String += " ExpenseTypeID = " + ExpenseTypeID.Value.ToString();

			if(!ExpenseType.IsNull)
				MST_ExpenseTypeENT_String += "| ExpenseType = " + ExpenseType.Value;

			if(!HospitalID.IsNull)
				MST_ExpenseTypeENT_String += "| HospitalID = " + HospitalID.Value.ToString();

			if(!Remarks.IsNull)
				MST_ExpenseTypeENT_String += "| Remarks = " + Remarks.Value;

			if(!UserID.IsNull)
				MST_ExpenseTypeENT_String += "| UserID = " + UserID.Value.ToString();

			if(!Created.IsNull)
				MST_ExpenseTypeENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

			if(!Modified.IsNull)
				MST_ExpenseTypeENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


			MST_ExpenseTypeENT_String = MST_ExpenseTypeENT_String.Trim();

			return MST_ExpenseTypeENT_String;
		}

		#endregion ToString

	}

}