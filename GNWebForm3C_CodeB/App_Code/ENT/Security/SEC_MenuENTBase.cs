using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
	public abstract class SEC_MenuENTBase
	{
		#region Properties


		protected SqlInt32 _MenuID;
		public SqlInt32 MenuID
		{
			get
			{
				return _MenuID;
			}
			set
			{
				_MenuID = value;
			}
		}

		protected SqlInt32 _ParentMenuID;
		public SqlInt32 ParentMenuID
		{
			get
			{
				return _ParentMenuID;
			}
			set
			{
				_ParentMenuID = value;
			}
		}

		protected SqlString _MenuName;
		public SqlString MenuName
		{
			get
			{
				return _MenuName;
			}
			set
			{
				_MenuName = value;
			}
		}

		protected SqlString _MenuDisplayName;
		public SqlString MenuDisplayName
		{
			get
			{
				return _MenuDisplayName;
			}
			set
			{
				_MenuDisplayName = value;
			}
		}

		protected SqlString _FormName;
		public SqlString FormName
		{
			get
			{
				return _FormName;
			}
			set
			{
				_FormName = value;
			}
		}

		protected SqlInt32 _Sequence;
		public SqlInt32 Sequence
		{
			get
			{
				return _Sequence;
			}
			set
			{
				_Sequence = value;
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

		public SEC_MenuENTBase()
		{

		}

		#endregion Constructor

		#region ToString

		public override String ToString()
		{
			String SEC_MenuENT_String = String.Empty;

			if(!MenuID.IsNull)
				SEC_MenuENT_String += " MenuID = " + MenuID.Value.ToString();

			if(!ParentMenuID.IsNull)
				SEC_MenuENT_String += "| ParentMenuID = " + ParentMenuID.Value.ToString();

			if(!MenuName.IsNull)
				SEC_MenuENT_String += "| MenuName = " + MenuName.Value;

			if(!MenuDisplayName.IsNull)
				SEC_MenuENT_String += "| MenuDisplayName = " + MenuDisplayName.Value;

			if(!FormName.IsNull)
				SEC_MenuENT_String += "| FormName = " + FormName.Value;

			if(!Sequence.IsNull)
				SEC_MenuENT_String += "| Sequence = " + Sequence.Value.ToString();

			if(!Remarks.IsNull)
				SEC_MenuENT_String += "| Remarks = " + Remarks.Value;

			if(!UserID.IsNull)
				SEC_MenuENT_String += "| UserID = " + UserID.Value.ToString();

			if(!Created.IsNull)
				SEC_MenuENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

			if(!Modified.IsNull)
				SEC_MenuENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


			SEC_MenuENT_String = SEC_MenuENT_String.Trim();

			return SEC_MenuENT_String;
		}

		#endregion ToString

	}

}