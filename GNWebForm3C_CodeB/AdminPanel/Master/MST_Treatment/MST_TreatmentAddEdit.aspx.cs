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


public partial class AdminPanel_Master_MST_Treatment_MST_TreatmentAddEdit : System.Web.UI.Page
{
	#region 10.0 Local Variables 

	String FormName = "MST_TreatmentAddEdit";
	
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

			lblFormHeader.Text = CV.PageHeaderAdd + " Treatment";
			upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
			txtTreatment.Focus();
			
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
		if (Request.QueryString["TreatmentID"] != null) 
		{
			lblFormHeader.Text = CV.PageHeaderEdit + " Treatment";
			MST_TreatmentBAL balMST_Treatment = new MST_TreatmentBAL();
			MST_TreatmentENT entMST_Treatment = new MST_TreatmentENT();
			entMST_Treatment = balMST_Treatment.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["TreatmentID"]));

			if (!entMST_Treatment.Treatment.IsNull)
				txtTreatment.Text = entMST_Treatment.Treatment.Value.ToString();

			if (!entMST_Treatment.HospitalID.IsNull)
				ddlHospitalID.SelectedValue = entMST_Treatment.HospitalID.Value.ToString();

			if (!entMST_Treatment.Remarks.IsNull)
				txtRemarks.Text = entMST_Treatment.Remarks.Value.ToString();

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
				MST_TreatmentBAL balMST_Treatment = new MST_TreatmentBAL();
				MST_TreatmentENT entMST_Treatment = new MST_TreatmentENT();

				#region 15.1 Validate Fields 

				String ErrorMsg = String.Empty;
				if (txtTreatment.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Treatment");
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


				if (txtTreatment.Text.Trim() != String.Empty)
					entMST_Treatment.Treatment = txtTreatment.Text.Trim();

				if (ddlHospitalID.SelectedIndex > 0)
					entMST_Treatment.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

				if (txtRemarks.Text.Trim() != String.Empty)
					entMST_Treatment.Remarks = txtRemarks.Text.Trim();

				entMST_Treatment.UserID  =  Convert.ToInt32(Session["UserID"]);

				entMST_Treatment.Created  =  DateTime.Now;

				entMST_Treatment.Modified  =  DateTime.Now;

				
				#endregion 15.2 Gather Data 


				#region 15.3 Insert,Update,Copy 

				if (Request.QueryString["TreatmentID"] != null && Request.QueryString["Copy"] == null) 
				{
					entMST_Treatment.TreatmentID = CommonFunctions.DecryptBase64Int32(Request.QueryString["TreatmentID"]);
					if (balMST_Treatment.Update(entMST_Treatment))
					{
						Response.Redirect("MST_TreatmentList.aspx");
					}
					else
					{
						ucMessage.ShowError(balMST_Treatment.Message);
					}
				}
				else
				{
					if (Request.QueryString["TreatmentID"] == null || Request.QueryString["Copy"] != null)
					{
						if (balMST_Treatment.Insert(entMST_Treatment))
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
		txtTreatment.Text = String.Empty;
		ddlHospitalID.SelectedIndex = 0;
		txtRemarks.Text = String.Empty;
		txtTreatment.Focus();
	}
	
	#endregion 16.0 Clear Controls 

}
