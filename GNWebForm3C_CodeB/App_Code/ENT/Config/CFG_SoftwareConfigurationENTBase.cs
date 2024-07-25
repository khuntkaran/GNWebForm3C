using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
	public abstract class CFG_SoftwareConfigurationENTBase
	{
		#region Properties


		protected SqlInt32 _SoftwareConfigurationID;
		public SqlInt32 SoftwareConfigurationID
		{
			get
			{
				return _SoftwareConfigurationID;
			}
			set
			{
				_SoftwareConfigurationID = value;
			}
		}

		protected SqlString _SaveMessage_NoMessageJustClosetheform;
		public SqlString SaveMessage_NoMessageJustClosetheform
		{
			get
			{
				return _SaveMessage_NoMessageJustClosetheform;
			}
			set
			{
				_SaveMessage_NoMessageJustClosetheform = value;
			}
		}

		protected SqlString _SaveMessage_ShowMessageClosetheform;
		public SqlString SaveMessage_ShowMessageClosetheform
		{
			get
			{
				return _SaveMessage_ShowMessageClosetheform;
			}
			set
			{
				_SaveMessage_ShowMessageClosetheform = value;
			}
		}

		protected SqlString _SaveMessage_ShowMessageAskforOtherRecord;
		public SqlString SaveMessage_ShowMessageAskforOtherRecord
		{
			get
			{
				return _SaveMessage_ShowMessageAskforOtherRecord;
			}
			set
			{
				_SaveMessage_ShowMessageAskforOtherRecord = value;
			}
		}

		protected SqlBoolean _ShortcutKeys_AddOnNumPadPlusKeyinListPage;
		public SqlBoolean ShortcutKeys_AddOnNumPadPlusKeyinListPage
		{
			get
			{
				return _ShortcutKeys_AddOnNumPadPlusKeyinListPage;
			}
			set
			{
				_ShortcutKeys_AddOnNumPadPlusKeyinListPage = value;
			}
		}

		protected SqlString _ShortcutKeys_EditOnEnterKeyinListPage;
		public SqlString ShortcutKeys_EditOnEnterKeyinListPage
		{
			get
			{
				return _ShortcutKeys_EditOnEnterKeyinListPage;
			}
			set
			{
				_ShortcutKeys_EditOnEnterKeyinListPage = value;
			}
		}

		protected SqlBoolean _ShortcutKeys_ViewOnSpaceBarKeyinListPage;
		public SqlBoolean ShortcutKeys_ViewOnSpaceBarKeyinListPage
		{
			get
			{
				return _ShortcutKeys_ViewOnSpaceBarKeyinListPage;
			}
			set
			{
				_ShortcutKeys_ViewOnSpaceBarKeyinListPage = value;
			}
		}

		protected SqlBoolean _ShortcutKeys_DeleteOnDeleteKeyinListPage;
		public SqlBoolean ShortcutKeys_DeleteOnDeleteKeyinListPage
		{
			get
			{
				return _ShortcutKeys_DeleteOnDeleteKeyinListPage;
			}
			set
			{
				_ShortcutKeys_DeleteOnDeleteKeyinListPage = value;
			}
		}

		protected SqlString _ShortcutKeys_DoubleClicK;
		public SqlString ShortcutKeys_DoubleClicK
		{
			get
			{
				return _ShortcutKeys_DoubleClicK;
			}
			set
			{
				_ShortcutKeys_DoubleClicK = value;
			}
		}

		protected SqlBoolean _ShortcutKeys_IsAskConfirmationBeforeEscape;
		public SqlBoolean ShortcutKeys_IsAskConfirmationBeforeEscape
		{
			get
			{
				return _ShortcutKeys_IsAskConfirmationBeforeEscape;
			}
			set
			{
				_ShortcutKeys_IsAskConfirmationBeforeEscape = value;
			}
		}

		protected SqlBoolean _IsEnterAsTAB;
		public SqlBoolean IsEnterAsTAB
		{
			get
			{
				return _IsEnterAsTAB;
			}
			set
			{
				_IsEnterAsTAB = value;
			}
		}

		protected SqlBoolean _IsSendError;
		public SqlBoolean IsSendError
		{
			get
			{
				return _IsSendError;
			}
			set
			{
				_IsSendError = value;
			}
		}

		protected SqlBoolean _IsShowUserNameinListPage;
		public SqlBoolean IsShowUserNameinListPage
		{
			get
			{
				return _IsShowUserNameinListPage;
			}
			set
			{
				_IsShowUserNameinListPage = value;
			}
		}

		protected SqlBoolean _IsShowModifiedinListPage;
		public SqlBoolean IsShowModifiedinListPage
		{
			get
			{
				return _IsShowModifiedinListPage;
			}
			set
			{
				_IsShowModifiedinListPage = value;
			}
		}

		protected SqlBoolean _AllowIncrementalSearchinGrid;
		public SqlBoolean AllowIncrementalSearchinGrid
		{
			get
			{
				return _AllowIncrementalSearchinGrid;
			}
			set
			{
				_AllowIncrementalSearchinGrid = value;
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

		protected SqlString _WeeklyBackupPath;
		public SqlString WeeklyBackupPath
		{
			get
			{
				return _WeeklyBackupPath;
			}
			set
			{
				_WeeklyBackupPath = value;
			}
		}

		protected SqlString _WeeklyBackupPassword;
		public SqlString WeeklyBackupPassword
		{
			get
			{
				return _WeeklyBackupPassword;
			}
			set
			{
				_WeeklyBackupPassword = value;
			}
		}

		protected SqlBoolean _IsActive;
		public SqlBoolean IsActive
		{
			get
			{
				return _IsActive;
			}
			set
			{
				_IsActive = value;
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

		public CFG_SoftwareConfigurationENTBase()
		{

		}

		#endregion Constructor

		#region ToString

		public override String ToString()
		{
			String CFG_SoftwareConfigurationENT_String = String.Empty;

			if(!SoftwareConfigurationID.IsNull)
				CFG_SoftwareConfigurationENT_String += " SoftwareConfigurationID = " + SoftwareConfigurationID.Value.ToString();

			if(!SaveMessage_NoMessageJustClosetheform.IsNull)
				CFG_SoftwareConfigurationENT_String += "| SaveMessage_NoMessageJustClosetheform = " + SaveMessage_NoMessageJustClosetheform.Value;

			if(!SaveMessage_ShowMessageClosetheform.IsNull)
				CFG_SoftwareConfigurationENT_String += "| SaveMessage_ShowMessageClosetheform = " + SaveMessage_ShowMessageClosetheform.Value;

			if(!SaveMessage_ShowMessageAskforOtherRecord.IsNull)
				CFG_SoftwareConfigurationENT_String += "| SaveMessage_ShowMessageAskforOtherRecord = " + SaveMessage_ShowMessageAskforOtherRecord.Value;

			if(!ShortcutKeys_AddOnNumPadPlusKeyinListPage.IsNull)
				CFG_SoftwareConfigurationENT_String += "| ShortcutKeys_AddOnNumPadPlusKeyinListPage = " + ShortcutKeys_AddOnNumPadPlusKeyinListPage.Value;

			if(!ShortcutKeys_EditOnEnterKeyinListPage.IsNull)
				CFG_SoftwareConfigurationENT_String += "| ShortcutKeys_EditOnEnterKeyinListPage = " + ShortcutKeys_EditOnEnterKeyinListPage.Value;

			if(!ShortcutKeys_ViewOnSpaceBarKeyinListPage.IsNull)
				CFG_SoftwareConfigurationENT_String += "| ShortcutKeys_ViewOnSpaceBarKeyinListPage = " + ShortcutKeys_ViewOnSpaceBarKeyinListPage.Value;

			if(!ShortcutKeys_DeleteOnDeleteKeyinListPage.IsNull)
				CFG_SoftwareConfigurationENT_String += "| ShortcutKeys_DeleteOnDeleteKeyinListPage = " + ShortcutKeys_DeleteOnDeleteKeyinListPage.Value;

			if(!ShortcutKeys_DoubleClicK.IsNull)
				CFG_SoftwareConfigurationENT_String += "| ShortcutKeys_DoubleClicK = " + ShortcutKeys_DoubleClicK.Value;

			if(!ShortcutKeys_IsAskConfirmationBeforeEscape.IsNull)
				CFG_SoftwareConfigurationENT_String += "| ShortcutKeys_IsAskConfirmationBeforeEscape = " + ShortcutKeys_IsAskConfirmationBeforeEscape.Value;

			if(!IsEnterAsTAB.IsNull)
				CFG_SoftwareConfigurationENT_String += "| IsEnterAsTAB = " + IsEnterAsTAB.Value;

			if(!IsSendError.IsNull)
				CFG_SoftwareConfigurationENT_String += "| IsSendError = " + IsSendError.Value;

			if(!IsShowUserNameinListPage.IsNull)
				CFG_SoftwareConfigurationENT_String += "| IsShowUserNameinListPage = " + IsShowUserNameinListPage.Value;

			if(!IsShowModifiedinListPage.IsNull)
				CFG_SoftwareConfigurationENT_String += "| IsShowModifiedinListPage = " + IsShowModifiedinListPage.Value;

			if(!AllowIncrementalSearchinGrid.IsNull)
				CFG_SoftwareConfigurationENT_String += "| AllowIncrementalSearchinGrid = " + AllowIncrementalSearchinGrid.Value;

			if(!HospitalID.IsNull)
				CFG_SoftwareConfigurationENT_String += "| HospitalID = " + HospitalID.Value.ToString();

			if(!WeeklyBackupPath.IsNull)
				CFG_SoftwareConfigurationENT_String += "| WeeklyBackupPath = " + WeeklyBackupPath.Value;

			if(!WeeklyBackupPassword.IsNull)
				CFG_SoftwareConfigurationENT_String += "| WeeklyBackupPassword = " + WeeklyBackupPassword.Value;

			if(!IsActive.IsNull)
				CFG_SoftwareConfigurationENT_String += "| IsActive = " + IsActive.Value;

			if(!Remarks.IsNull)
				CFG_SoftwareConfigurationENT_String += "| Remarks = " + Remarks.Value;

			if(!UserID.IsNull)
				CFG_SoftwareConfigurationENT_String += "| UserID = " + UserID.Value.ToString();

			if(!Created.IsNull)
				CFG_SoftwareConfigurationENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

			if(!Modified.IsNull)
				CFG_SoftwareConfigurationENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


			CFG_SoftwareConfigurationENT_String = CFG_SoftwareConfigurationENT_String.Trim();

			return CFG_SoftwareConfigurationENT_String;
		}

		#endregion ToString

	}

}