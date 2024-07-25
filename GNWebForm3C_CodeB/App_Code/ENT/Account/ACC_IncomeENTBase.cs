using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
	public abstract class ACC_IncomeENTBase
	{
		#region Properties


		protected SqlInt32 _IncomeID;
		public SqlInt32 IncomeID
		{
			get
			{
				return _IncomeID;
			}
			set
			{
				_IncomeID = value;
			}
		}

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

		protected SqlDecimal _Amount;
		public SqlDecimal Amount
		{
			get
			{
				return _Amount;
			}
			set
			{
				_Amount = value;
			}
		}

		protected SqlDateTime _IncomeDate;
		public SqlDateTime IncomeDate
		{
			get
			{
				return _IncomeDate;
			}
			set
			{
				_IncomeDate = value;
			}
		}

		protected SqlString _Note;
		public SqlString Note
		{
			get
			{
				return _Note;
			}
			set
			{
				_Note = value;
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

		protected SqlInt32 _FinYearID;
		public SqlInt32 FinYearID
		{
			get
			{
				return _FinYearID;
			}
			set
			{
				_FinYearID = value;
			}
		}

		//protected SqlString _Remarks;
		//public SqlString Remarks
		//{
		//	get
		//	{
		//		return _Remarks;
		//	}
		//	set
		//	{
		//		_Remarks = value;
		//	}
		//}

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

		public ACC_IncomeENTBase()
		{

		}

		#endregion Constructor

		#region ToString

		public override String ToString()
		{
			String ACC_IncomeENT_String = String.Empty;

			if(!IncomeID.IsNull)
				ACC_IncomeENT_String += " IncomeID = " + IncomeID.Value.ToString();

			if(!IncomeTypeID.IsNull)
				ACC_IncomeENT_String += "| IncomeTypeID = " + IncomeTypeID.Value.ToString();

			if(!Amount.IsNull)
				ACC_IncomeENT_String += "| Amount = " + Amount.Value.ToString();

			if(!IncomeDate.IsNull)
				ACC_IncomeENT_String += "| IncomeDate = " + IncomeDate.Value.ToString("dd-MM-yyyy");

			if(!Note.IsNull)
				ACC_IncomeENT_String += "| Note = " + Note.Value;

			if(!HospitalID.IsNull)
				ACC_IncomeENT_String += "| HospitalID = " + HospitalID.Value.ToString();

			if(!FinYearID.IsNull)
				ACC_IncomeENT_String += "| FinYearID = " + FinYearID.Value.ToString();

			//if(!Remarks.IsNull)
			//	ACC_IncomeENT_String += "| Remarks = " + Remarks.Value;

			if(!UserID.IsNull)
				ACC_IncomeENT_String += "| UserID = " + UserID.Value.ToString();

			if(!Created.IsNull)
				ACC_IncomeENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

			if(!Modified.IsNull)
				ACC_IncomeENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


			ACC_IncomeENT_String = ACC_IncomeENT_String.Trim();

			return ACC_IncomeENT_String;
		}

		#endregion ToString

	}

}