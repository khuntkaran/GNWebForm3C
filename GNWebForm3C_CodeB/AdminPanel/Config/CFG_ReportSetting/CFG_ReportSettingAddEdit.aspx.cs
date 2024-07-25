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


public partial class AdminPanel_Config_CFG_ReportSetting_CFG_ReportSettingAddEdit : System.Web.UI.Page
{
	#region 10.0 Local Variables 

	String FormName = "CFG_ReportSettingAddEdit";
	
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

			lblFormHeader.Text = CV.PageHeaderAdd + " Report Setting";
			upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
			txtReportHeaderFontType.Focus();
			
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
		if (Request.QueryString["ReportSettingID"] != null) 
		{
			lblFormHeader.Text = CV.PageHeaderEdit + " Report Setting";
			CFG_ReportSettingBAL balCFG_ReportSetting = new CFG_ReportSettingBAL();
			CFG_ReportSettingENT entCFG_ReportSetting = new CFG_ReportSettingENT();
			entCFG_ReportSetting = balCFG_ReportSetting.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["ReportSettingID"]));

			if (!entCFG_ReportSetting.ReportHeaderFontType.IsNull)
				txtReportHeaderFontType.Text = entCFG_ReportSetting.ReportHeaderFontType.Value.ToString();

			if (!entCFG_ReportSetting.ReportHeaderFontSize.IsNull)
				txtReportHeaderFontSize.Text = entCFG_ReportSetting.ReportHeaderFontSize.Value.ToString();

			if (!entCFG_ReportSetting.ReportHeaderFontStyle.IsNull)
				txtReportHeaderFontStyle.Text = entCFG_ReportSetting.ReportHeaderFontStyle.Value.ToString();

			if (!entCFG_ReportSetting.TableHeaderFontType.IsNull)
				txtTableHeaderFontType.Text = entCFG_ReportSetting.TableHeaderFontType.Value.ToString();

			if (!entCFG_ReportSetting.TableHeaderFontSize.IsNull)
				txtTableHeaderFontSize.Text = entCFG_ReportSetting.TableHeaderFontSize.Value.ToString();

			if (!entCFG_ReportSetting.TableHeaderFontStyle.IsNull)
				txtTableHeaderFontStyle.Text = entCFG_ReportSetting.TableHeaderFontStyle.Value.ToString();

			if (!entCFG_ReportSetting.TableRowFontType.IsNull)
				txtTableRowFontType.Text = entCFG_ReportSetting.TableRowFontType.Value.ToString();

			if (!entCFG_ReportSetting.TableRowFontSize.IsNull)
				txtTableRowFontSize.Text = entCFG_ReportSetting.TableRowFontSize.Value.ToString();

			if (!entCFG_ReportSetting.TableRowFontStyle.IsNull)
				txtTableRowFontStyle.Text = entCFG_ReportSetting.TableRowFontStyle.Value.ToString();

			if (!entCFG_ReportSetting.FooterFontType.IsNull)
				txtFooterFontType.Text = entCFG_ReportSetting.FooterFontType.Value.ToString();

			if (!entCFG_ReportSetting.FooterFontSize.IsNull)
				txtFooterFontSize.Text = entCFG_ReportSetting.FooterFontSize.Value.ToString();

			if (!entCFG_ReportSetting.FooterFontStyle.IsNull)
				txtFooterFontStyle.Text = entCFG_ReportSetting.FooterFontStyle.Value.ToString();

			if (!entCFG_ReportSetting.IsPrintDate.IsNull)
				cbIsPrintDate.Checked = entCFG_ReportSetting.IsPrintDate.Value;

			if (!entCFG_ReportSetting.IsPrintDateWithTime.IsNull)
				cbIsPrintDateWithTime.Checked = entCFG_ReportSetting.IsPrintDateWithTime.Value;

			if (!entCFG_ReportSetting.IsPrintUserName.IsNull)
				cbIsPrintUserName.Checked = entCFG_ReportSetting.IsPrintUserName.Value;

			if (!entCFG_ReportSetting.HospitalID.IsNull)
				ddlHospitalID.SelectedValue = entCFG_ReportSetting.HospitalID.Value.ToString();

			if (!entCFG_ReportSetting.Remarks.IsNull)
				txtRemarks.Text = entCFG_ReportSetting.Remarks.Value.ToString();

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
				CFG_ReportSettingBAL balCFG_ReportSetting = new CFG_ReportSettingBAL();
				CFG_ReportSettingENT entCFG_ReportSetting = new CFG_ReportSettingENT();

				#region 15.1 Validate Fields 

				String ErrorMsg = String.Empty;
				if (txtReportHeaderFontType.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Report Header Font Type");
				if (txtReportHeaderFontSize.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Report Header Font Size");
				if (txtReportHeaderFontStyle.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Report Header Font Style");
				if (txtTableHeaderFontType.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Table Header Font Type");
				if (txtTableHeaderFontSize.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Table Header Font Size");
				if (txtTableHeaderFontStyle.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Table Header Font Style");
				if (txtTableRowFontType.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Table Row Font Type");
				if (txtTableRowFontSize.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Table Row Font Size");
				if (txtTableRowFontStyle.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Table Row Font Style");
				if (txtFooterFontType.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Footer Font Type");
				if (txtFooterFontSize.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Footer Font Size");
				if (txtFooterFontStyle.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Footer Font Style");
				if (ddlHospitalID.SelectedIndex == 0)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Hospital");

				if (ErrorMsg != String.Empty)
				{
					ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
					ucMessage.ShowError(ErrorMsg);
					return;
				}
				
				#endregion 15.1 Validate Fields

				#region 15.2 Gather Data 


				if (txtReportHeaderFontType.Text.Trim() != String.Empty)
					entCFG_ReportSetting.ReportHeaderFontType = txtReportHeaderFontType.Text.Trim();

				if (txtReportHeaderFontSize.Text.Trim() != String.Empty)
					entCFG_ReportSetting.ReportHeaderFontSize = Convert.ToDecimal(txtReportHeaderFontSize.Text.Trim());

				if (txtReportHeaderFontStyle.Text.Trim() != String.Empty)
					entCFG_ReportSetting.ReportHeaderFontStyle = txtReportHeaderFontStyle.Text.Trim();

				if (txtTableHeaderFontType.Text.Trim() != String.Empty)
					entCFG_ReportSetting.TableHeaderFontType = txtTableHeaderFontType.Text.Trim();

				if (txtTableHeaderFontSize.Text.Trim() != String.Empty)
					entCFG_ReportSetting.TableHeaderFontSize = Convert.ToDecimal(txtTableHeaderFontSize.Text.Trim());

				if (txtTableHeaderFontStyle.Text.Trim() != String.Empty)
					entCFG_ReportSetting.TableHeaderFontStyle = txtTableHeaderFontStyle.Text.Trim();

				if (txtTableRowFontType.Text.Trim() != String.Empty)
					entCFG_ReportSetting.TableRowFontType = txtTableRowFontType.Text.Trim();

				if (txtTableRowFontSize.Text.Trim() != String.Empty)
					entCFG_ReportSetting.TableRowFontSize = Convert.ToDecimal(txtTableRowFontSize.Text.Trim());

				if (txtTableRowFontStyle.Text.Trim() != String.Empty)
					entCFG_ReportSetting.TableRowFontStyle = txtTableRowFontStyle.Text.Trim();

				if (txtFooterFontType.Text.Trim() != String.Empty)
					entCFG_ReportSetting.FooterFontType = txtFooterFontType.Text.Trim();

				if (txtFooterFontSize.Text.Trim() != String.Empty)
					entCFG_ReportSetting.FooterFontSize = Convert.ToDecimal(txtFooterFontSize.Text.Trim());

				if (txtFooterFontStyle.Text.Trim() != String.Empty)
					entCFG_ReportSetting.FooterFontStyle = txtFooterFontStyle.Text.Trim();

				entCFG_ReportSetting.IsPrintDate = Convert.ToBoolean(cbIsPrintDate.Checked);

				entCFG_ReportSetting.IsPrintDateWithTime = Convert.ToBoolean(cbIsPrintDateWithTime.Checked);

				entCFG_ReportSetting.IsPrintUserName = Convert.ToBoolean(cbIsPrintUserName.Checked);

				if (ddlHospitalID.SelectedIndex > 0)
					entCFG_ReportSetting.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

				if (txtRemarks.Text.Trim() != String.Empty)
					entCFG_ReportSetting.Remarks = txtRemarks.Text.Trim();

				entCFG_ReportSetting.UserID  =  Convert.ToInt32(Session["UserID"]);

				entCFG_ReportSetting.Created  =  DateTime.Now;

				entCFG_ReportSetting.Modified  =  DateTime.Now;

				
				#endregion 15.2 Gather Data 


				#region 15.3 Insert,Update,Copy 

				if (Request.QueryString["ReportSettingID"] != null && Request.QueryString["Copy"] == null) 
				{
					entCFG_ReportSetting.ReportSettingID = CommonFunctions.DecryptBase64Int32(Request.QueryString["ReportSettingID"]);
					if (balCFG_ReportSetting.Update(entCFG_ReportSetting))
					{
						Response.Redirect("CFG_ReportSettingList.aspx");
					}
					else
					{
						ucMessage.ShowError(balCFG_ReportSetting.Message);
					}
				}
				else
				{
					if (Request.QueryString["ReportSettingID"] == null || Request.QueryString["Copy"] != null)
					{
						if (balCFG_ReportSetting.Insert(entCFG_ReportSetting))
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
		txtReportHeaderFontType.Text = String.Empty;
		txtReportHeaderFontSize.Text = String.Empty;
		txtReportHeaderFontStyle.Text = String.Empty;
		txtTableHeaderFontType.Text = String.Empty;
		txtTableHeaderFontSize.Text = String.Empty;
		txtTableHeaderFontStyle.Text = String.Empty;
		txtTableRowFontType.Text = String.Empty;
		txtTableRowFontSize.Text = String.Empty;
		txtTableRowFontStyle.Text = String.Empty;
		txtFooterFontType.Text = String.Empty;
		txtFooterFontSize.Text = String.Empty;
		txtFooterFontStyle.Text = String.Empty;
		cbIsPrintDate.Checked = false;
		cbIsPrintDateWithTime.Checked = false;
		cbIsPrintUserName.Checked = false;
		ddlHospitalID.SelectedIndex = 0;
		txtRemarks.Text = String.Empty;
		txtReportHeaderFontType.Focus();
	}
	
	#endregion 16.0 Clear Controls 

}
