using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
	public abstract class ACC_ExpenseENTBase
	{
		#region Properties


		protected SqlInt32 _ExpenseID;
		public SqlInt32 ExpenseID
		{
			get
			{
				return _ExpenseID;
			}
			set
			{
				_ExpenseID = value;
			}
		}

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

		protected SqlDateTime _ExpenseDate;
		public SqlDateTime ExpenseDate
		{
			get
			{
				return _ExpenseDate;
			}
			set
			{
				_ExpenseDate = value;
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

        protected SqlString _TagName;
        public SqlString TagName
        {
            get
            {
                return _TagName;
            }
            set
            {
                _TagName = value;
            }
        }

        #endregion Properties

        #region Constructor

        public ACC_ExpenseENTBase()
		{

		}

		#endregion Constructor

		#region ToString

		public override String ToString()
		{
			String ACC_ExpenseENT_String = String.Empty;

			if(!ExpenseID.IsNull)
				ACC_ExpenseENT_String += " ExpenseID = " + ExpenseID.Value.ToString();

			if(!ExpenseTypeID.IsNull)
				ACC_ExpenseENT_String += "| ExpenseTypeID = " + ExpenseTypeID.Value.ToString();

			if(!Amount.IsNull)
				ACC_ExpenseENT_String += "| Amount = " + Amount.Value.ToString();

			if(!ExpenseDate.IsNull)
				ACC_ExpenseENT_String += "| ExpenseDate = " + ExpenseDate.Value.ToString("dd-MM-yyyy");

			if(!Note.IsNull)
				ACC_ExpenseENT_String += "| Note = " + Note.Value;

			if(!HospitalID.IsNull)
				ACC_ExpenseENT_String += "| HospitalID = " + HospitalID.Value.ToString();

			if(!FinYearID.IsNull)
				ACC_ExpenseENT_String += "| FinYearID = " + FinYearID.Value.ToString();

			if (!Remarks.IsNull)
				ACC_ExpenseENT_String += "| Remarks = " + Remarks.Value;

			if (!UserID.IsNull)
				ACC_ExpenseENT_String += "| UserID = " + UserID.Value.ToString();

			if(!Created.IsNull)
				ACC_ExpenseENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

			if(!Modified.IsNull)
				ACC_ExpenseENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");

            if (!TagName.IsNull)
                ACC_ExpenseENT_String += "| TagName = " + TagName.Value;

            ACC_ExpenseENT_String = ACC_ExpenseENT_String.Trim();

			return ACC_ExpenseENT_String;
		}

		#endregion ToString

	}

}