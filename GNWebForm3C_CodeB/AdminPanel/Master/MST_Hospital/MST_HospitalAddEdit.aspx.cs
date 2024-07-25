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


public partial class AdminPanel_Master_MST_Hospital_MST_HospitalAddEdit : System.Web.UI.Page
{
	#region 10.0 Local Variables 

	String FormName = "MST_HospitalAddEdit";
	
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

			lblFormHeader.Text = CV.PageHeaderAdd + " Hospital";
			upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
			txtHospital.Focus();
			
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
	}
	
	#endregion 13.0 Fill DropDownList

	#region 14.0 FillControls By PK  

	private void FillControls()
	{
		if (Request.QueryString["HospitalID"] != null) 
		{
			lblFormHeader.Text = CV.PageHeaderEdit + " Hospital";
			MST_HospitalBAL balMST_Hospital = new MST_HospitalBAL();
			MST_HospitalENT entMST_Hospital = new MST_HospitalENT();
			entMST_Hospital = balMST_Hospital.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["HospitalID"]));

			if (!entMST_Hospital.Hospital.IsNull)
				txtHospital.Text = entMST_Hospital.Hospital.Value.ToString();

			if (!entMST_Hospital.PrintName.IsNull)
				txtPrintName.Text = entMST_Hospital.PrintName.Value.ToString();

			if (!entMST_Hospital.PrintLine1.IsNull)
				txtPrintLine1.Text = entMST_Hospital.PrintLine1.Value.ToString();

			if (!entMST_Hospital.PrintLine2.IsNull)
				txtPrintLine2.Text = entMST_Hospital.PrintLine2.Value.ToString();

			if (!entMST_Hospital.PrintLine3.IsNull)
				txtPrintLine3.Text = entMST_Hospital.PrintLine3.Value.ToString();

			if (!entMST_Hospital.FooterName.IsNull)
				txtFooterName.Text = entMST_Hospital.FooterName.Value.ToString();

			if (!entMST_Hospital.ReportHeaderName.IsNull)
				txtReportHeaderName.Text = entMST_Hospital.ReportHeaderName.Value.ToString();

			if (!entMST_Hospital.Remarks.IsNull)
				txtRemarks.Text = entMST_Hospital.Remarks.Value.ToString();

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
				MST_HospitalBAL balMST_Hospital = new MST_HospitalBAL();
				MST_HospitalENT entMST_Hospital = new MST_HospitalENT();

				#region 15.1 Validate Fields 

				String ErrorMsg = String.Empty;
				if (txtHospital.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Hospital");
				if (txtPrintName.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Print Name");
				if (txtFooterName.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Footer Name");

				if (ErrorMsg != String.Empty)
				{
					ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
					ucMessage.ShowError(ErrorMsg);
					return;
				}
				
				#endregion 15.1 Validate Fields

				#region 15.2 Gather Data 


				if (txtHospital.Text.Trim() != String.Empty)
					entMST_Hospital.Hospital = txtHospital.Text.Trim();

				if (txtPrintName.Text.Trim() != String.Empty)
					entMST_Hospital.PrintName = txtPrintName.Text.Trim();

				if (txtPrintLine1.Text.Trim() != String.Empty)
					entMST_Hospital.PrintLine1 = txtPrintLine1.Text.Trim();

				if (txtPrintLine2.Text.Trim() != String.Empty)
					entMST_Hospital.PrintLine2 = txtPrintLine2.Text.Trim();

				if (txtPrintLine3.Text.Trim() != String.Empty)
					entMST_Hospital.PrintLine3 = txtPrintLine3.Text.Trim();

				if (txtFooterName.Text.Trim() != String.Empty)
					entMST_Hospital.FooterName = txtFooterName.Text.Trim();

				if (txtReportHeaderName.Text.Trim() != String.Empty)
					entMST_Hospital.ReportHeaderName = txtReportHeaderName.Text.Trim();

				if (txtRemarks.Text.Trim() != String.Empty)
					entMST_Hospital.Remarks = txtRemarks.Text.Trim();

				entMST_Hospital.UserID  =  Convert.ToInt32(Session["UserID"]);

				entMST_Hospital.Created  =  DateTime.Now;

				entMST_Hospital.Modified  =  DateTime.Now;

				
				#endregion 15.2 Gather Data 


				#region 15.3 Insert,Update,Copy 

				if (Request.QueryString["HospitalID"] != null && Request.QueryString["Copy"] == null) 
				{
					entMST_Hospital.HospitalID = CommonFunctions.DecryptBase64Int32(Request.QueryString["HospitalID"]);
					if (balMST_Hospital.Update(entMST_Hospital))
					{
						Response.Redirect("MST_HospitalList.aspx");
					}
					else
					{
						ucMessage.ShowError(balMST_Hospital.Message);
					}
				}
				else
				{
					if (Request.QueryString["HospitalID"] == null || Request.QueryString["Copy"] != null)
					{
						if (balMST_Hospital.Insert(entMST_Hospital))
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
		txtHospital.Text = String.Empty;
		txtPrintName.Text = String.Empty;
		txtPrintLine1.Text = String.Empty;
		txtPrintLine2.Text = String.Empty;
		txtPrintLine3.Text = String.Empty;
		txtFooterName.Text = String.Empty;
		txtReportHeaderName.Text = String.Empty;
		txtRemarks.Text = String.Empty;
		txtHospital.Focus();
	}
	
	#endregion 16.0 Clear Controls 

}
