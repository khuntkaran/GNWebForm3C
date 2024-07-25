using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
public partial class AdminPanel_Config_CFG_SoftwareConfiguration_CFG_SoftwareConfigurationView: System.Web.UI.Page
{
	#region Page Load Event 

	protected void Page_Load(object sender, EventArgs e)
	{
		#region 10.1 Check User Login 

		if (Session["UserID"] == null)
			Response.Redirect(CV.LoginPageURL);
			
 #endregion 10.1 Check User Login 

			if (!Page.IsPostBack)
			{
				if (Request.QueryString["SoftwareConfigurationID"] != null)
				{
					FillControls();
				}
			}
		}
		
 #endregion  

		#region FillControls
		private void FillControls()
		{
			if (Request.QueryString["SoftwareConfigurationID"] != null) 
			{
				CFG_SoftwareConfigurationBAL balCFG_SoftwareConfiguration = new CFG_SoftwareConfigurationBAL();
				DataTable dtCFG_SoftwareConfiguration = balCFG_SoftwareConfiguration.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["SoftwareConfigurationID"]));
				if (dtCFG_SoftwareConfiguration != null)
				{
					foreach (DataRow dr in dtCFG_SoftwareConfiguration.Rows)
					{

						if (!dr["SaveMessage_NoMessageJustClosetheform"].Equals(DBNull.Value))
							lblSaveMessage_NoMessageJustClosetheform.Text = Convert.ToString(dr["SaveMessage_NoMessageJustClosetheform"]);

						if (!dr["SaveMessage_ShowMessageClosetheform"].Equals(DBNull.Value))
							lblSaveMessage_ShowMessageClosetheform.Text = Convert.ToString(dr["SaveMessage_ShowMessageClosetheform"]);

						if (!dr["SaveMessage_ShowMessageAskforOtherRecord"].Equals(DBNull.Value))
							lblSaveMessage_ShowMessageAskforOtherRecord.Text = Convert.ToString(dr["SaveMessage_ShowMessageAskforOtherRecord"]);

						if (!dr["ShortcutKeys_AddOnNumPadPlusKeyinListPage"].Equals(DBNull.Value))
							lblShortcutKeys_AddOnNumPadPlusKeyinListPage.Text = Convert.ToString(dr["ShortcutKeys_AddOnNumPadPlusKeyinListPage"]);

						if (!dr["ShortcutKeys_EditOnEnterKeyinListPage"].Equals(DBNull.Value))
							lblShortcutKeys_EditOnEnterKeyinListPage.Text = Convert.ToString(dr["ShortcutKeys_EditOnEnterKeyinListPage"]);

						if (!dr["ShortcutKeys_ViewOnSpaceBarKeyinListPage"].Equals(DBNull.Value))
							lblShortcutKeys_ViewOnSpaceBarKeyinListPage.Text = Convert.ToString(dr["ShortcutKeys_ViewOnSpaceBarKeyinListPage"]);

						if (!dr["ShortcutKeys_DeleteOnDeleteKeyinListPage"].Equals(DBNull.Value))
							lblShortcutKeys_DeleteOnDeleteKeyinListPage.Text = Convert.ToString(dr["ShortcutKeys_DeleteOnDeleteKeyinListPage"]);

						if (!dr["ShortcutKeys_DoubleClicK"].Equals(DBNull.Value))
							lblShortcutKeys_DoubleClicK.Text = Convert.ToString(dr["ShortcutKeys_DoubleClicK"]);

						if (!dr["ShortcutKeys_IsAskConfirmationBeforeEscape"].Equals(DBNull.Value))
							lblShortcutKeys_IsAskConfirmationBeforeEscape.Text = Convert.ToString(dr["ShortcutKeys_IsAskConfirmationBeforeEscape"]);

						if (!dr["IsEnterAsTAB"].Equals(DBNull.Value))
							lblIsEnterAsTAB.Text = Convert.ToString(dr["IsEnterAsTAB"]);

						if (!dr["IsSendError"].Equals(DBNull.Value))
							lblIsSendError.Text = Convert.ToString(dr["IsSendError"]);

						if (!dr["IsShowUserNameinListPage"].Equals(DBNull.Value))
							lblIsShowUserNameinListPage.Text = Convert.ToString(dr["IsShowUserNameinListPage"]);

						if (!dr["IsShowModifiedinListPage"].Equals(DBNull.Value))
							lblIsShowModifiedinListPage.Text = Convert.ToString(dr["IsShowModifiedinListPage"]);

						if (!dr["AllowIncrementalSearchinGrid"].Equals(DBNull.Value))
							lblAllowIncrementalSearchinGrid.Text = Convert.ToString(dr["AllowIncrementalSearchinGrid"]);

						if (!dr["HospitalID"].Equals(DBNull.Value))
							lblHospitalID.Text = Convert.ToString(dr["HospitalID"]);

						if (!dr["WeeklyBackupPath"].Equals(DBNull.Value))
						{
							hlWeeklyBackupPath.Visible = true;
							hlWeeklyBackupPath.NavigateUrl = Convert.ToString(dr["WeeklyBackupPath"]);
							CommonFunctions.SetIcon(iWeeklyBackupPath, Convert.ToString(dr["WeeklyBackupPath"]));
						}

						if (!dr["WeeklyBackupPassword"].Equals(DBNull.Value))
							lblWeeklyBackupPassword.Text = Convert.ToString(dr["WeeklyBackupPassword"]);

						if (!dr["IsActive"].Equals(DBNull.Value))
							lblIsActive.Text = Convert.ToString(dr["IsActive"]);

						if (!dr["Remarks"].Equals(DBNull.Value))
							lblRemarks.Text = Convert.ToString(dr["Remarks"]);

						if (!dr["UserID"].Equals(DBNull.Value))
							lblUserID.Text = Convert.ToString(dr["UserID"]);

						if (!dr["Created"].Equals(DBNull.Value))
							lblCreated.Text = Convert.ToDateTime(dr["Created"]).ToString(CV.DefaultDateTimeFormat);

						if (!dr["Modified"].Equals(DBNull.Value))
							lblModified.Text = Convert.ToDateTime(dr["Modified"]).ToString(CV.DefaultDateTimeFormat);

					}
				}
			}
		}
		#endregion FillControls
	}
