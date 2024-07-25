using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
	public abstract class CFG_ReportSettingENTBase
	{
		#region Properties


		protected SqlInt32 _ReportSettingID;
		public SqlInt32 ReportSettingID
		{
			get
			{
				return _ReportSettingID;
			}
			set
			{
				_ReportSettingID = value;
			}
		}

		protected SqlString _ReportHeaderFontType;
		public SqlString ReportHeaderFontType
		{
			get
			{
				return _ReportHeaderFontType;
			}
			set
			{
				_ReportHeaderFontType = value;
			}
		}

		protected SqlDecimal _ReportHeaderFontSize;
		public SqlDecimal ReportHeaderFontSize
		{
			get
			{
				return _ReportHeaderFontSize;
			}
			set
			{
				_ReportHeaderFontSize = value;
			}
		}

		protected SqlString _ReportHeaderFontStyle;
		public SqlString ReportHeaderFontStyle
		{
			get
			{
				return _ReportHeaderFontStyle;
			}
			set
			{
				_ReportHeaderFontStyle = value;
			}
		}

		protected SqlString _TableHeaderFontType;
		public SqlString TableHeaderFontType
		{
			get
			{
				return _TableHeaderFontType;
			}
			set
			{
				_TableHeaderFontType = value;
			}
		}

		protected SqlDecimal _TableHeaderFontSize;
		public SqlDecimal TableHeaderFontSize
		{
			get
			{
				return _TableHeaderFontSize;
			}
			set
			{
				_TableHeaderFontSize = value;
			}
		}

		protected SqlString _TableHeaderFontStyle;
		public SqlString TableHeaderFontStyle
		{
			get
			{
				return _TableHeaderFontStyle;
			}
			set
			{
				_TableHeaderFontStyle = value;
			}
		}

		protected SqlString _TableRowFontType;
		public SqlString TableRowFontType
		{
			get
			{
				return _TableRowFontType;
			}
			set
			{
				_TableRowFontType = value;
			}
		}

		protected SqlDecimal _TableRowFontSize;
		public SqlDecimal TableRowFontSize
		{
			get
			{
				return _TableRowFontSize;
			}
			set
			{
				_TableRowFontSize = value;
			}
		}

		protected SqlString _TableRowFontStyle;
		public SqlString TableRowFontStyle
		{
			get
			{
				return _TableRowFontStyle;
			}
			set
			{
				_TableRowFontStyle = value;
			}
		}

		protected SqlString _FooterFontType;
		public SqlString FooterFontType
		{
			get
			{
				return _FooterFontType;
			}
			set
			{
				_FooterFontType = value;
			}
		}

		protected SqlDecimal _FooterFontSize;
		public SqlDecimal FooterFontSize
		{
			get
			{
				return _FooterFontSize;
			}
			set
			{
				_FooterFontSize = value;
			}
		}

		protected SqlString _FooterFontStyle;
		public SqlString FooterFontStyle
		{
			get
			{
				return _FooterFontStyle;
			}
			set
			{
				_FooterFontStyle = value;
			}
		}

		protected SqlBoolean _IsPrintDate;
		public SqlBoolean IsPrintDate
		{
			get
			{
				return _IsPrintDate;
			}
			set
			{
				_IsPrintDate = value;
			}
		}

		protected SqlBoolean _IsPrintDateWithTime;
		public SqlBoolean IsPrintDateWithTime
		{
			get
			{
				return _IsPrintDateWithTime;
			}
			set
			{
				_IsPrintDateWithTime = value;
			}
		}

		protected SqlBoolean _IsPrintUserName;
		public SqlBoolean IsPrintUserName
		{
			get
			{
				return _IsPrintUserName;
			}
			set
			{
				_IsPrintUserName = value;
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

		public CFG_ReportSettingENTBase()
		{

		}

		#endregion Constructor

		#region ToString

		public override String ToString()
		{
			String CFG_ReportSettingENT_String = String.Empty;

			if(!ReportSettingID.IsNull)
				CFG_ReportSettingENT_String += " ReportSettingID = " + ReportSettingID.Value.ToString();

			if(!ReportHeaderFontType.IsNull)
				CFG_ReportSettingENT_String += "| ReportHeaderFontType = " + ReportHeaderFontType.Value;

			if(!ReportHeaderFontSize.IsNull)
				CFG_ReportSettingENT_String += "| ReportHeaderFontSize = " + ReportHeaderFontSize.Value.ToString();

			if(!ReportHeaderFontStyle.IsNull)
				CFG_ReportSettingENT_String += "| ReportHeaderFontStyle = " + ReportHeaderFontStyle.Value;

			if(!TableHeaderFontType.IsNull)
				CFG_ReportSettingENT_String += "| TableHeaderFontType = " + TableHeaderFontType.Value;

			if(!TableHeaderFontSize.IsNull)
				CFG_ReportSettingENT_String += "| TableHeaderFontSize = " + TableHeaderFontSize.Value.ToString();

			if(!TableHeaderFontStyle.IsNull)
				CFG_ReportSettingENT_String += "| TableHeaderFontStyle = " + TableHeaderFontStyle.Value;

			if(!TableRowFontType.IsNull)
				CFG_ReportSettingENT_String += "| TableRowFontType = " + TableRowFontType.Value;

			if(!TableRowFontSize.IsNull)
				CFG_ReportSettingENT_String += "| TableRowFontSize = " + TableRowFontSize.Value.ToString();

			if(!TableRowFontStyle.IsNull)
				CFG_ReportSettingENT_String += "| TableRowFontStyle = " + TableRowFontStyle.Value;

			if(!FooterFontType.IsNull)
				CFG_ReportSettingENT_String += "| FooterFontType = " + FooterFontType.Value;

			if(!FooterFontSize.IsNull)
				CFG_ReportSettingENT_String += "| FooterFontSize = " + FooterFontSize.Value.ToString();

			if(!FooterFontStyle.IsNull)
				CFG_ReportSettingENT_String += "| FooterFontStyle = " + FooterFontStyle.Value;

			if(!IsPrintDate.IsNull)
				CFG_ReportSettingENT_String += "| IsPrintDate = " + IsPrintDate.Value;

			if(!IsPrintDateWithTime.IsNull)
				CFG_ReportSettingENT_String += "| IsPrintDateWithTime = " + IsPrintDateWithTime.Value;

			if(!IsPrintUserName.IsNull)
				CFG_ReportSettingENT_String += "| IsPrintUserName = " + IsPrintUserName.Value;

			if(!HospitalID.IsNull)
				CFG_ReportSettingENT_String += "| HospitalID = " + HospitalID.Value.ToString();

			if(!Remarks.IsNull)
				CFG_ReportSettingENT_String += "| Remarks = " + Remarks.Value;

			if(!UserID.IsNull)
				CFG_ReportSettingENT_String += "| UserID = " + UserID.Value.ToString();

			if(!Created.IsNull)
				CFG_ReportSettingENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

			if(!Modified.IsNull)
				CFG_ReportSettingENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


			CFG_ReportSettingENT_String = CFG_ReportSettingENT_String.Trim();

			return CFG_ReportSettingENT_String;
		}

		#endregion ToString

	}

}