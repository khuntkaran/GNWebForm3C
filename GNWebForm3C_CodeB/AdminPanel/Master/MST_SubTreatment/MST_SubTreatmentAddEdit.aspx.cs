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


public partial class AdminPanel_Master_MST_SubTreatment_MST_SubTreatmentAddEdit : System.Web.UI.Page
{
	#region 10.0 Local Variables 

	String FormName = "MST_SubTreatmentAddEdit";
	
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

			lblFormHeader.Text = CV.PageHeaderAdd + " Sub Treatment";
			upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
			txtSubTreatmentName.Focus();
			
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
		if (Request.QueryString["SubTreatmentID"] != null) 
		{
			lblFormHeader.Text = CV.PageHeaderEdit + " Sub Treatment";
			MST_SubTreatmentBAL balMST_SubTreatment = new MST_SubTreatmentBAL();
			MST_SubTreatmentENT entMST_SubTreatment = new MST_SubTreatmentENT();
			entMST_SubTreatment = balMST_SubTreatment.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["SubTreatmentID"]));

			if (!entMST_SubTreatment.SubTreatmentName.IsNull)
				txtSubTreatmentName.Text = entMST_SubTreatment.SubTreatmentName.Value.ToString();

			if (!entMST_SubTreatment.SequenceNo.IsNull)
				txtSequenceNo.Text = entMST_SubTreatment.SequenceNo.Value.ToString();

			if (!entMST_SubTreatment.Rate.IsNull)
				txtRate.Text = entMST_SubTreatment.Rate.Value.ToString();

			if (!entMST_SubTreatment.IsInGrid.IsNull)
				cbIsInGrid.Checked = entMST_SubTreatment.IsInGrid.Value;

			if (!entMST_SubTreatment.HospitalID.IsNull)
				ddlHospitalID.SelectedValue = entMST_SubTreatment.HospitalID.Value.ToString();

			if (!entMST_SubTreatment.IsPerDay.IsNull)
				cbIsPerDay.Checked = entMST_SubTreatment.IsPerDay.Value;

			if (!entMST_SubTreatment.DefaultUnit.IsNull)
				txtDefaultUnit.Text = entMST_SubTreatment.DefaultUnit.Value.ToString();

			if (!entMST_SubTreatment.Remarks.IsNull)
				txtRemarks.Text = entMST_SubTreatment.Remarks.Value.ToString();

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
				MST_SubTreatmentBAL balMST_SubTreatment = new MST_SubTreatmentBAL();
				MST_SubTreatmentENT entMST_SubTreatment = new MST_SubTreatmentENT();

				#region 15.1 Validate Fields 

				String ErrorMsg = String.Empty;
				if (txtSubTreatmentName.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Sub Treatment Name");
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


				if (txtSubTreatmentName.Text.Trim() != String.Empty)
					entMST_SubTreatment.SubTreatmentName = txtSubTreatmentName.Text.Trim();

				if (txtSequenceNo.Text.Trim() != String.Empty)
					entMST_SubTreatment.SequenceNo = Convert.ToInt32(txtSequenceNo.Text.Trim());

				if (txtRate.Text.Trim() != String.Empty)
					entMST_SubTreatment.Rate = Convert.ToDecimal(txtRate.Text.Trim());

				entMST_SubTreatment.IsInGrid = Convert.ToBoolean(cbIsInGrid.Checked);

				if (ddlHospitalID.SelectedIndex > 0)
					entMST_SubTreatment.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

				entMST_SubTreatment.IsPerDay = Convert.ToBoolean(cbIsPerDay.Checked);

				if (txtDefaultUnit.Text.Trim() != String.Empty)
					entMST_SubTreatment.DefaultUnit = txtDefaultUnit.Text.Trim();

				if (txtRemarks.Text.Trim() != String.Empty)
					entMST_SubTreatment.Remarks = txtRemarks.Text.Trim();

				entMST_SubTreatment.UserID  =  Convert.ToInt32(Session["UserID"]);

				entMST_SubTreatment.Created  =  DateTime.Now;

				entMST_SubTreatment.Modified  =  DateTime.Now;

				
				#endregion 15.2 Gather Data 


				#region 15.3 Insert,Update,Copy 

				if (Request.QueryString["SubTreatmentID"] != null && Request.QueryString["Copy"] == null) 
				{
					entMST_SubTreatment.SubTreatmentID = CommonFunctions.DecryptBase64Int32(Request.QueryString["SubTreatmentID"]);
					if (balMST_SubTreatment.Update(entMST_SubTreatment))
					{
						Response.Redirect("MST_SubTreatmentList.aspx");
					}
					else
					{
						ucMessage.ShowError(balMST_SubTreatment.Message);
					}
				}
				else
				{
					if (Request.QueryString["SubTreatmentID"] == null || Request.QueryString["Copy"] != null)
					{
						if (balMST_SubTreatment.Insert(entMST_SubTreatment))
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
		txtSubTreatmentName.Text = String.Empty;
		txtSequenceNo.Text = String.Empty;
		txtRate.Text = String.Empty;
		cbIsInGrid.Checked = false;
		ddlHospitalID.SelectedIndex = 0;
		cbIsPerDay.Checked = false;
		txtDefaultUnit.Text = String.Empty;
		txtRemarks.Text = String.Empty;
		txtSubTreatmentName.Focus();
	}
	
	#endregion 16.0 Clear Controls 

}
