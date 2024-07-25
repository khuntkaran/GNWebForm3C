using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
	public abstract class MST_ReceiptTypeENTBase
	{
		#region Properties


		protected SqlInt32 _ReceiptTypeID;
		public SqlInt32 ReceiptTypeID
		{
			get
			{
				return _ReceiptTypeID;
			}
			set
			{
				_ReceiptTypeID = value;
			}
		}

		protected SqlString _ReceiptTypeName;
		public SqlString ReceiptTypeName
		{
			get
			{
				return _ReceiptTypeName;
			}
			set
			{
				_ReceiptTypeName = value;
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

		protected SqlBoolean _IsDefault;
		public SqlBoolean IsDefault
		{
			get
			{
				return _IsDefault;
			}
			set
			{
				_IsDefault = value;
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

		public MST_ReceiptTypeENTBase()
		{

		}

		#endregion Constructor

		#region ToString

		public override String ToString()
		{
			String MST_ReceiptTypeENT_String = String.Empty;

			if(!ReceiptTypeID.IsNull)
				MST_ReceiptTypeENT_String += " ReceiptTypeID = " + ReceiptTypeID.Value.ToString();

			if(!ReceiptTypeName.IsNull)
				MST_ReceiptTypeENT_String += "| ReceiptTypeName = " + ReceiptTypeName.Value;

			if(!PrintName.IsNull)
				MST_ReceiptTypeENT_String += "| PrintName = " + PrintName.Value;

			if(!IsDefault.IsNull)
				MST_ReceiptTypeENT_String += "| IsDefault = " + IsDefault.Value;

			if(!HospitalID.IsNull)
				MST_ReceiptTypeENT_String += "| HospitalID = " + HospitalID.Value.ToString();

			if(!Remarks.IsNull)
				MST_ReceiptTypeENT_String += "| Remarks = " + Remarks.Value;

			if(!UserID.IsNull)
				MST_ReceiptTypeENT_String += "| UserID = " + UserID.Value.ToString();

			if(!Created.IsNull)
				MST_ReceiptTypeENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

			if(!Modified.IsNull)
				MST_ReceiptTypeENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


			MST_ReceiptTypeENT_String = MST_ReceiptTypeENT_String.Trim();

			return MST_ReceiptTypeENT_String;
		}

		#endregion ToString

	}

}