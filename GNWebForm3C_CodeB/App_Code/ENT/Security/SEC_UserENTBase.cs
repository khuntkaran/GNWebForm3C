using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
	public abstract class SEC_UserENTBase
	{
		#region Properties


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

		protected SqlString _UserName;
		public SqlString UserName
		{
			get
			{
				return _UserName;
			}
			set
			{
				_UserName = value;
			}
		}

		protected SqlString _Password;
		public SqlString Password
		{
			get
			{
				return _Password;
			}
			set
			{
				_Password = value;
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

		public SEC_UserENTBase()
		{

		}

		#endregion Constructor

		#region ToString

		public override String ToString()
		{
			String SEC_UserENT_String = String.Empty;

			if(!UserID.IsNull)
				SEC_UserENT_String += " UserID = " + UserID.Value.ToString();

			if(!UserName.IsNull)
				SEC_UserENT_String += "| UserName = " + UserName.Value;

			if(!Password.IsNull)
				SEC_UserENT_String += "| Password = " + Password.Value;

			if(!HospitalID.IsNull)
				SEC_UserENT_String += "| HospitalID = " + HospitalID.Value.ToString();

			if(!Remarks.IsNull)
				SEC_UserENT_String += "| Remarks = " + Remarks.Value;

			if(!Created.IsNull)
				SEC_UserENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

			if(!Modified.IsNull)
				SEC_UserENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


			SEC_UserENT_String = SEC_UserENT_String.Trim();

			return SEC_UserENT_String;
		}

		#endregion ToString

	}

}