using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;


public partial class AdminPanel_Config_CFG_SoftwareConfiguration_CFG_SoftwareConfigurationAddEdit : System.Web.UI.Page
{
	#region 10.0 Local Variables 

	String FormName = "CFG_SoftwareConfigurationAddEdit";
	
	#endregion 10.0 Variables 

	#region 11.0 Page Load Event 

	protected void Page_Load(object sender, EventArgs e)
	{
		#region 11.1 Check User Login 

		if (Session["UserID"] == null)
			Response.Redirect(CV.LoginPageURL);
			
		#endregion 11.1 Check User Login 

		if(!Page.IsPostBack)
		{
			#region 11.2 Fill Labels 

			FillLabels(FormName);
			
			#endregion 11.2 Fill Labels 

			#region 11.3 DropDown List Fill Section 

			FillDropDownList();
			
			#endregion 11.3 DropDown List Fill Section 

			#region 11.4 Set Control Default Value 

			lblFormHeader.Text = CV.PageHeaderAdd + " Software Configuration";
			upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
			txtSaveMessage_NoMessageJustClosetheform.Focus();
			
			#endregion 11.4 Set Control Default Value 

			#region 11.5 Fill Controls 

			FillControls();
			
			#endregion 11.5 Fill Controls 

			#region 11.6 Set Help Text 

			ucHelp.ShowHelp("Help Text will be shown here");
			
			#endregion 11.6 Set Help Text 

		}
	}
	
	#endregion 11.0 Page Load Event

	#region 12.0 FillLabels 

	private void FillLabels(String FormName)
	{
	}
	
	#endregion 12.0 FillLabels 

	#region 13.0 Fill DropDownList 

	private void FillDropDownList()
	{
		CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
	}
	
	#endregion 13.0 Fill DropDownList

	#region 14.0 FillControls By PK  

	private void FillControls()
	{
		if (Request.QueryString["SoftwareConfigurationID"] != null) 
		{
			lblFormHeader.Text = CV.PageHeaderEdit + " Software Configuration";
			CFG_SoftwareConfigurationBAL balCFG_SoftwareConfiguration = new CFG_SoftwareConfigurationBAL();
			CFG_SoftwareConfigurationENT entCFG_SoftwareConfiguration = new CFG_SoftwareConfigurationENT();
			entCFG_SoftwareConfiguration = balCFG_SoftwareConfiguration.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["SoftwareConfigurationID"]));

			if (!entCFG_SoftwareConfiguration.SaveMessage_NoMessageJustClosetheform.IsNull)
				txtSaveMessage_NoMessageJustClosetheform.Text = entCFG_SoftwareConfiguration.SaveMessage_NoMessageJustClosetheform.Value.ToString();

			if (!entCFG_SoftwareConfiguration.SaveMessage_ShowMessageClosetheform.IsNull)
				txtSaveMessage_ShowMessageClosetheform.Text = entCFG_SoftwareConfiguration.SaveMessage_ShowMessageClosetheform.Value.ToString();

			if (!entCFG_SoftwareConfiguration.SaveMessage_ShowMessageAskforOtherRecord.IsNull)
				txtSaveMessage_ShowMessageAskforOtherRecord.Text = entCFG_SoftwareConfiguration.SaveMessage_ShowMessageAskforOtherRecord.Value.ToString();

			if (!entCFG_SoftwareConfiguration.ShortcutKeys_AddOnNumPadPlusKeyinListPage.IsNull)
				cbShortcutKeys_AddOnNumPadPlusKeyinListPage.Checked = entCFG_SoftwareConfiguration.ShortcutKeys_AddOnNumPadPlusKeyinListPage.Value;

			if (!entCFG_SoftwareConfiguration.ShortcutKeys_EditOnEnterKeyinListPage.IsNull)
				txtShortcutKeys_EditOnEnterKeyinListPage.Text = entCFG_SoftwareConfiguration.ShortcutKeys_EditOnEnterKeyinListPage.Value.ToString();

			if (!entCFG_SoftwareConfiguration.ShortcutKeys_ViewOnSpaceBarKeyinListPage.IsNull)
				cbShortcutKeys_ViewOnSpaceBarKeyinListPage.Checked = entCFG_SoftwareConfiguration.ShortcutKeys_ViewOnSpaceBarKeyinListPage.Value;

			if (!entCFG_SoftwareConfiguration.ShortcutKeys_DeleteOnDeleteKeyinListPage.IsNull)
				cbShortcutKeys_DeleteOnDeleteKeyinListPage.Checked = entCFG_SoftwareConfiguration.ShortcutKeys_DeleteOnDeleteKeyinListPage.Value;

			if (!entCFG_SoftwareConfiguration.ShortcutKeys_DoubleClicK.IsNull)
				txtShortcutKeys_DoubleClicK.Text = entCFG_SoftwareConfiguration.ShortcutKeys_DoubleClicK.Value.ToString();

			if (!entCFG_SoftwareConfiguration.ShortcutKeys_IsAskConfirmationBeforeEscape.IsNull)
				cbShortcutKeys_IsAskConfirmationBeforeEscape.Checked = entCFG_SoftwareConfiguration.ShortcutKeys_IsAskConfirmationBeforeEscape.Value;

			if (!entCFG_SoftwareConfiguration.IsEnterAsTAB.IsNull)
				cbIsEnterAsTAB.Checked = entCFG_SoftwareConfiguration.IsEnterAsTAB.Value;

			if (!entCFG_SoftwareConfiguration.IsSendError.IsNull)
				cbIsSendError.Checked = entCFG_SoftwareConfiguration.IsSendError.Value;

			if (!entCFG_SoftwareConfiguration.IsShowUserNameinListPage.IsNull)
				cbIsShowUserNameinListPage.Checked = entCFG_SoftwareConfiguration.IsShowUserNameinListPage.Value;

			if (!entCFG_SoftwareConfiguration.IsShowModifiedinListPage.IsNull)
				cbIsShowModifiedinListPage.Checked = entCFG_SoftwareConfiguration.IsShowModifiedinListPage.Value;

			if (!entCFG_SoftwareConfiguration.AllowIncrementalSearchinGrid.IsNull)
				cbAllowIncrementalSearchinGrid.Checked = entCFG_SoftwareConfiguration.AllowIncrementalSearchinGrid.Value;

			if (!entCFG_SoftwareConfiguration.HospitalID.IsNull)
				ddlHospitalID.SelectedValue = entCFG_SoftwareConfiguration.HospitalID.Value.ToString();

			if (!entCFG_SoftwareConfiguration.WeeklyBackupPath.IsNull)
				{
					ViewState["WeeklyBackupPath"] = entCFG_SoftwareConfiguration.WeeklyBackupPath.Value;
					hlWeeklyBackupPath.NavigateUrl =entCFG_SoftwareConfiguration.WeeklyBackupPath.Value;
					hlWeeklyBackupPath.Visible = true;

					#region Set Icon
					CommonFunctions.SetIcon(icnWeeklyBackupPath,entCFG_SoftwareConfiguration.WeeklyBackupPath.Value.ToString());
					#endregion Set Icon
				}

			if (!entCFG_SoftwareConfiguration.WeeklyBackupPassword.IsNull)
				txtWeeklyBackupPassword.Text = entCFG_SoftwareConfiguration.WeeklyBackupPassword.Value.ToString();

			if (!entCFG_SoftwareConfiguration.IsActive.IsNull)
				cbIsActive.Checked = entCFG_SoftwareConfiguration.IsActive.Value;

			if (!entCFG_SoftwareConfiguration.Remarks.IsNull)
				txtRemarks.Text = entCFG_SoftwareConfiguration.Remarks.Value.ToString();

		}
	}
	
	#endregion 14.0 FillControls By PK 

	#region 15.0 Save Button Event 

	protected void btnSave_Click(object sender, EventArgs e)
	{
		Page.Validate();
		if (Page.IsValid)
		{
			try
			{
				CFG_SoftwareConfigurationBAL balCFG_SoftwareConfiguration = new CFG_SoftwareConfigurationBAL();
				CFG_SoftwareConfigurationENT entCFG_SoftwareConfiguration = new CFG_SoftwareConfigurationENT();

				#region 15.1 Validate Fields 

				String ErrorMsg = String.Empty;
				if (ddlHospitalID.SelectedIndex == 0)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Hospital");

				#region Validate WeeklyBackupPath
				if (fuWeeklyBackupPath.HasFile)
				{
					string extension = System.IO.Path.GetExtension(fuWeeklyBackupPath.PostedFile.FileName);
					int fileSize = fuWeeklyBackupPath.PostedFile.ContentLength;

					if (!CommonFunctions.CheckImageType(extension, fileSize))
						ErrorMsg += " - " + CommonMessage.ErrorInvalidField("File type or size in WeeklyBackupPath");
				}
				#endregion Validate WeeklyBackupPath


				if (ErrorMsg != String.Empty)
				{
					ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
					ucMessage.ShowError(ErrorMsg);
					return;
				}
				
				#endregion 15.1 Validate Fields

				#region 15.2 Gather Data 


				if (txtSaveMessage_NoMessageJustClosetheform.Text.Trim() != String.Empty)
					entCFG_SoftwareConfiguration.SaveMessage_NoMessageJustClosetheform = txtSaveMessage_NoMessageJustClosetheform.Text.Trim();

				if (txtSaveMessage_ShowMessageClosetheform.Text.Trim() != String.Empty)
					entCFG_SoftwareConfiguration.SaveMessage_ShowMessageClosetheform = txtSaveMessage_ShowMessageClosetheform.Text.Trim();

				if (txtSaveMessage_ShowMessageAskforOtherRecord.Text.Trim() != String.Empty)
					entCFG_SoftwareConfiguration.SaveMessage_ShowMessageAskforOtherRecord = txtSaveMessage_ShowMessageAskforOtherRecord.Text.Trim();

				entCFG_SoftwareConfiguration.ShortcutKeys_AddOnNumPadPlusKeyinListPage = Convert.ToBoolean(cbShortcutKeys_AddOnNumPadPlusKeyinListPage.Checked);

				if (txtShortcutKeys_EditOnEnterKeyinListPage.Text.Trim() != String.Empty)
					entCFG_SoftwareConfiguration.ShortcutKeys_EditOnEnterKeyinListPage = txtShortcutKeys_EditOnEnterKeyinListPage.Text.Trim();

				entCFG_SoftwareConfiguration.ShortcutKeys_ViewOnSpaceBarKeyinListPage = Convert.ToBoolean(cbShortcutKeys_ViewOnSpaceBarKeyinListPage.Checked);

				entCFG_SoftwareConfiguration.ShortcutKeys_DeleteOnDeleteKeyinListPage = Convert.ToBoolean(cbShortcutKeys_DeleteOnDeleteKeyinListPage.Checked);

				if (txtShortcutKeys_DoubleClicK.Text.Trim() != String.Empty)
					entCFG_SoftwareConfiguration.ShortcutKeys_DoubleClicK = txtShortcutKeys_DoubleClicK.Text.Trim();

				entCFG_SoftwareConfiguration.ShortcutKeys_IsAskConfirmationBeforeEscape = Convert.ToBoolean(cbShortcutKeys_IsAskConfirmationBeforeEscape.Checked);

				entCFG_SoftwareConfiguration.IsEnterAsTAB = Convert.ToBoolean(cbIsEnterAsTAB.Checked);

				entCFG_SoftwareConfiguration.IsSendError = Convert.ToBoolean(cbIsSendError.Checked);

				entCFG_SoftwareConfiguration.IsShowUserNameinListPage = Convert.ToBoolean(cbIsShowUserNameinListPage.Checked);

				entCFG_SoftwareConfiguration.IsShowModifiedinListPage = Convert.ToBoolean(cbIsShowModifiedinListPage.Checked);

				entCFG_SoftwareConfiguration.AllowIncrementalSearchinGrid = Convert.ToBoolean(cbAllowIncrementalSearchinGrid.Checked);

				if (ddlHospitalID.SelectedIndex > 0)
					entCFG_SoftwareConfiguration.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

				#region Upload WeeklyBackupPath
				if (fuWeeklyBackupPath.HasFile)
				{
					#region Create File Path
					string strFileName = "", strFileExt = "", strFilePath = "";
					strFileExt = System.IO.Path.GetExtension(fuWeeklyBackupPath.PostedFile.FileName);
					strFileName = fuWeeklyBackupPath.PostedFile.FileName;
					strFilePath = "~/Upload";

					if (!Directory.Exists(Server.MapPath(strFilePath)))
						Directory.CreateDirectory(Server.MapPath(strFilePath));
					#endregion Create File Path

					#region Upload File
					if (ViewState["WeeklyBackupPath"] != null)
					{
						if (File.Exists(Server.MapPath(ViewState["WeeklyBackupPath"].ToString())))
							File.Delete(Server.MapPath(ViewState["WeeklyBackupPath"].ToString()));
					}

					entCFG_SoftwareConfiguration.WeeklyBackupPath = strFilePath + "/" + strFileName;
					fuWeeklyBackupPath.SaveAs(Server.MapPath(entCFG_SoftwareConfiguration.WeeklyBackupPath.Value));
					#endregion Upload File
				}
				else
				{
						if (ViewState["WeeklyBackupPath"] != null)
							entCFG_SoftwareConfiguration.WeeklyBackupPath =  ViewState["WeeklyBackupPath"].ToString();
				}
				#endregion Upload WeeklyBackupPath

				if (txtWeeklyBackupPassword.Text.Trim() != String.Empty)
					entCFG_SoftwareConfiguration.WeeklyBackupPassword = txtWeeklyBackupPassword.Text.Trim();

				entCFG_SoftwareConfiguration.IsActive = Convert.ToBoolean(cbIsActive.Checked);

				if (txtRemarks.Text.Trim() != String.Empty)
					entCFG_SoftwareConfiguration.Remarks = txtRemarks.Text.Trim();

				entCFG_SoftwareConfiguration.UserID  =  Convert.ToInt32(Session["UserID"]);

				entCFG_SoftwareConfiguration.Created  =  DateTime.Now;

				entCFG_SoftwareConfiguration.Modified  =  DateTime.Now;

				
				#endregion 15.2 Gather Data 


				#region 15.3 Insert,Update,Copy 

				if (Request.QueryString["SoftwareConfigurationID"] != null && Request.QueryString["Copy"] == null) 
				{
					entCFG_SoftwareConfiguration.SoftwareConfigurationID = CommonFunctions.DecryptBase64Int32(Request.QueryString["SoftwareConfigurationID"]);
					if (balCFG_SoftwareConfiguration.Update(entCFG_SoftwareConfiguration))
					{
						Response.Redirect("CFG_SoftwareConfigurationList.aspx");
					}
					else
					{
						ucMessage.ShowError(balCFG_SoftwareConfiguration.Message);
					}
				}
				else
				{
					if (Request.QueryString["SoftwareConfigurationID"] == null || Request.QueryString["Copy"] != null)
					{
						if (balCFG_SoftwareConfiguration.Insert(entCFG_SoftwareConfiguration))
						{
							ucMessage.ShowSuccess(CommonMessage.RecordSaved());
							ClearControls();
						}
					}
				}
				
				#endregion 15.3 Insert,Update,Copy

			}
			catch (Exception ex)
			{
				ucMessage.ShowError(ex.Message);
			}
		}
	}
	
	#endregion 15.0 Save Button Event 

	#region 16.0 Clear Controls 

	private void ClearControls()
	{
		txtSaveMessage_NoMessageJustClosetheform.Text = String.Empty;
		txtSaveMessage_ShowMessageClosetheform.Text = String.Empty;
		txtSaveMessage_ShowMessageAskforOtherRecord.Text = String.Empty;
		cbShortcutKeys_AddOnNumPadPlusKeyinListPage.Checked = false;
		txtShortcutKeys_EditOnEnterKeyinListPage.Text = String.Empty;
		cbShortcutKeys_ViewOnSpaceBarKeyinListPage.Checked = false;
		cbShortcutKeys_DeleteOnDeleteKeyinListPage.Checked = false;
		txtShortcutKeys_DoubleClicK.Text = String.Empty;
		cbShortcutKeys_IsAskConfirmationBeforeEscape.Checked = false;
		cbIsEnterAsTAB.Checked = false;
		cbIsSendError.Checked = false;
		cbIsShowUserNameinListPage.Checked = false;
		cbIsShowModifiedinListPage.Checked = false;
		cbAllowIncrementalSearchinGrid.Checked = false;
		ddlHospitalID.SelectedIndex = 0;
		txtWeeklyBackupPassword.Text = String.Empty;
		cbIsActive.Checked = false;
		txtRemarks.Text = String.Empty;
		txtSaveMessage_NoMessageJustClosetheform.Focus();
	}
	
	#endregion 16.0 Clear Controls 

}
