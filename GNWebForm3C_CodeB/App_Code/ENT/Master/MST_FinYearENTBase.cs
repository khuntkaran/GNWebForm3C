using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
	public abstract class MST_FinYearENTBase
	{
		#region Properties


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

		protected SqlString _FinYearName;
		public SqlString FinYearName
		{
			get
			{
				return _FinYearName;
			}
			set
			{
				_FinYearName = value;
			}
		}

		protected SqlDateTime _FromDate;
		public SqlDateTime FromDate
		{
			get
			{
				return _FromDate;
			}
			set
			{
				_FromDate = value;
			}
		}

		protected SqlDateTime _ToDate;
		public SqlDateTime ToDate
		{
			get
			{
				return _ToDate;
			}
			set
			{
				_ToDate = value;
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

		public MST_FinYearENTBase()
		{

		}

		#endregion Constructor

		#region ToString

		public override String ToString()
		{
			String MST_FinYearENT_String = String.Empty;

			if(!FinYearID.IsNull)
				MST_FinYearENT_String += " FinYearID = " + FinYearID.Value.ToString();

			if(!FinYearName.IsNull)
				MST_FinYearENT_String += "| FinYearName = " + FinYearName.Value;

			if(!FromDate.IsNull)
				MST_FinYearENT_String += "| FromDate = " + FromDate.Value.ToString("dd-MM-yyyy");

			if(!ToDate.IsNull)
				MST_FinYearENT_String += "| ToDate = " + ToDate.Value.ToString("dd-MM-yyyy");

			if(!Remarks.IsNull)
				MST_FinYearENT_String += "| Remarks = " + Remarks.Value;

			if(!UserID.IsNull)
				MST_FinYearENT_String += "| UserID = " + UserID.Value.ToString();

			if(!Created.IsNull)
				MST_FinYearENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

			if(!Modified.IsNull)
				MST_FinYearENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


			MST_FinYearENT_String = MST_FinYearENT_String.Trim();

			return MST_FinYearENT_String;
		}

		#endregion ToString

	}

}