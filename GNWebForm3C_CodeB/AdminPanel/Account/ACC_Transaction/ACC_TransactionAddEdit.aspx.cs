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


public partial class AdminPanel_Account_ACC_Transaction_ACC_TransactionAddEdit : System.Web.UI.Page
{
	#region 10.0 Local Variables 

	String FormName = "ACC_TransactionAddEdit";
	
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

			lblFormHeader.Text = CV.PageHeaderAdd + " Transaction";
			upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
			txtPatient.Focus();
			
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
		CommonFillMethods.FillDropDownListTreatmentID(ddlTreatmentID);
		CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
		CommonFillMethods.FillDropDownListFinYearID(ddlFinYearID);
		CommonFillMethods.FillDropDownListReceiptTypeID(ddlReceiptTypeID);
	}
	
	#endregion 13.0 Fill DropDownList

	#region 14.0 FillControls By PK  

	private void FillControls()
	{
		if (Request.QueryString["TransactionID"] != null) 
		{
			lblFormHeader.Text = CV.PageHeaderEdit + " Transaction";
			ACC_TransactionBAL balACC_Transaction = new ACC_TransactionBAL();
			ACC_TransactionENT entACC_Transaction = new ACC_TransactionENT();
			entACC_Transaction = balACC_Transaction.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["TransactionID"]));

			if (!entACC_Transaction.Patient.IsNull)
				txtPatient.Text = entACC_Transaction.Patient.Value.ToString();

			if (!entACC_Transaction.TreatmentID.IsNull)
				ddlTreatmentID.SelectedValue = entACC_Transaction.TreatmentID.Value.ToString();

			if (!entACC_Transaction.Amount.IsNull)
				txtAmount.Text = entACC_Transaction.Amount.Value.ToString();

			if (!entACC_Transaction.SerialNo.IsNull)
				txtSerialNo.Text = entACC_Transaction.SerialNo.Value.ToString();

			if (!entACC_Transaction.ReferenceDoctor.IsNull)
				txtReferenceDoctor.Text = entACC_Transaction.ReferenceDoctor.Value.ToString();

			if (!entACC_Transaction.Count.IsNull)
				txtCount.Text = entACC_Transaction.Count.Value.ToString();

			if (!entACC_Transaction.ReceiptNo.IsNull)
				txtReceiptNo.Text = entACC_Transaction.ReceiptNo.Value.ToString();

			if (!entACC_Transaction.Date.IsNull)
				dtpDate.Text = entACC_Transaction.Date.Value.ToString(CV.DefaultDateFormat);

			if (!entACC_Transaction.DateOfAdmission.IsNull)
				dtpDateOfAdmission.Text = entACC_Transaction.DateOfAdmission.Value.ToString(CV.DefaultDateFormat);

			if (!entACC_Transaction.DateOfDischarge.IsNull)
				dtpDateOfDischarge.Text = entACC_Transaction.DateOfDischarge.Value.ToString(CV.DefaultDateFormat);

			if (!entACC_Transaction.Deposite.IsNull)
				txtDeposite.Text = entACC_Transaction.Deposite.Value.ToString();

			if (!entACC_Transaction.NetAmount.IsNull)
				txtNetAmount.Text = entACC_Transaction.NetAmount.Value.ToString();

			if (!entACC_Transaction.NoOfDays.IsNull)
				txtNoOfDays.Text = entACC_Transaction.NoOfDays.Value.ToString();

			if (!entACC_Transaction.Remarks.IsNull)
				txtRemarks.Text = entACC_Transaction.Remarks.Value.ToString();

			if (!entACC_Transaction.HospitalID.IsNull)
				ddlHospitalID.SelectedValue = entACC_Transaction.HospitalID.Value.ToString();

			if (!entACC_Transaction.FinYearID.IsNull)
				ddlFinYearID.SelectedValue = entACC_Transaction.FinYearID.Value.ToString();

			if (!entACC_Transaction.ReceiptTypeID.IsNull)
				ddlReceiptTypeID.SelectedValue = entACC_Transaction.ReceiptTypeID.Value.ToString();

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
				ACC_TransactionBAL balACC_Transaction = new ACC_TransactionBAL();
				ACC_TransactionENT entACC_Transaction = new ACC_TransactionENT();

				#region 15.1 Validate Fields 

				String ErrorMsg = String.Empty;
				if (txtPatient.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Patient");
				if (ddlTreatmentID.SelectedIndex == 0)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Treatment");
				if (txtAmount.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Amount");
				if (txtReceiptNo.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Receipt No");
				if (dtpDate.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Date");
				if (ddlHospitalID.SelectedIndex == 0)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Hospital");
				if (ddlFinYearID.SelectedIndex == 0)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Fin Year");

				if (ErrorMsg != String.Empty)
				{
					ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
					ucMessage.ShowError(ErrorMsg);
					return;
				}
				
				#endregion 15.1 Validate Fields

				#region 15.2 Gather Data 


				if (txtPatient.Text.Trim() != String.Empty)
					entACC_Transaction.Patient = txtPatient.Text.Trim();

				if (ddlTreatmentID.SelectedIndex > 0)
					entACC_Transaction.TreatmentID = Convert.ToInt32(ddlTreatmentID.SelectedValue);

				if (txtAmount.Text.Trim() != String.Empty)
					entACC_Transaction.Amount = Convert.ToDecimal(txtAmount.Text.Trim());

				if (txtSerialNo.Text.Trim() != String.Empty)
					entACC_Transaction.SerialNo = Convert.ToInt32(txtSerialNo.Text.Trim());

				if (txtReferenceDoctor.Text.Trim() != String.Empty)
					entACC_Transaction.ReferenceDoctor = txtReferenceDoctor.Text.Trim();

				if (txtCount.Text.Trim() != String.Empty)
					entACC_Transaction.Count = Convert.ToInt32(txtCount.Text.Trim());

				if (txtReceiptNo.Text.Trim() != String.Empty)
					entACC_Transaction.ReceiptNo = Convert.ToInt32(txtReceiptNo.Text.Trim());

				if (dtpDate.Text.Trim() != String.Empty)
					entACC_Transaction.Date = Convert.ToDateTime(dtpDate.Text.Trim());

				if (dtpDateOfAdmission.Text.Trim() != String.Empty)
					entACC_Transaction.DateOfAdmission = Convert.ToDateTime(dtpDateOfAdmission.Text.Trim());

				if (dtpDateOfDischarge.Text.Trim() != String.Empty)
					entACC_Transaction.DateOfDischarge = Convert.ToDateTime(dtpDateOfDischarge.Text.Trim());

				if (txtDeposite.Text.Trim() != String.Empty)
					entACC_Transaction.Deposite = Convert.ToDecimal(txtDeposite.Text.Trim());

				if (txtNetAmount.Text.Trim() != String.Empty)
					entACC_Transaction.NetAmount = Convert.ToDecimal(txtNetAmount.Text.Trim());

				if (txtNoOfDays.Text.Trim() != String.Empty)
					entACC_Transaction.NoOfDays = Convert.ToInt32(txtNoOfDays.Text.Trim());

				if (txtRemarks.Text.Trim() != String.Empty)
					entACC_Transaction.Remarks = txtRemarks.Text.Trim();

				if (ddlHospitalID.SelectedIndex > 0)
					entACC_Transaction.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

				if (ddlFinYearID.SelectedIndex > 0)
					entACC_Transaction.FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);

				if (ddlReceiptTypeID.SelectedIndex > 0)
					entACC_Transaction.ReceiptTypeID = Convert.ToInt32(ddlReceiptTypeID.SelectedValue);

				entACC_Transaction.UserID  =  Convert.ToInt32(Session["UserID"]);

				entACC_Transaction.Created  =  DateTime.Now;

				entACC_Transaction.Modified  =  DateTime.Now;

				
				#endregion 15.2 Gather Data 


				#region 15.3 Insert,Update,Copy 

				if (Request.QueryString["TransactionID"] != null && Request.QueryString["Copy"] == null) 
				{
					entACC_Transaction.TransactionID = CommonFunctions.DecryptBase64Int32(Request.QueryString["TransactionID"]);
					if (balACC_Transaction.Update(entACC_Transaction))
					{
						Response.Redirect("ACC_TransactionList.aspx");
					}
					else
					{
						ucMessage.ShowError(balACC_Transaction.Message);
					}
				}
				else
				{
					if (Request.QueryString["TransactionID"] == null || Request.QueryString["Copy"] != null)
					{
						if (balACC_Transaction.Insert(entACC_Transaction))
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
		txtPatient.Text = String.Empty;
		ddlTreatmentID.SelectedIndex = 0;
		txtAmount.Text = String.Empty;
		txtSerialNo.Text = String.Empty;
		txtReferenceDoctor.Text = String.Empty;
		txtCount.Text = String.Empty;
		txtReceiptNo.Text = String.Empty;
		dtpDate.Text = String.Empty;
		dtpDateOfAdmission.Text = String.Empty;
		dtpDateOfDischarge.Text = String.Empty;
		txtDeposite.Text = String.Empty;
		txtNetAmount.Text = String.Empty;
		txtNoOfDays.Text = String.Empty;
		txtRemarks.Text = String.Empty;
		ddlHospitalID.SelectedIndex = 0;
		ddlFinYearID.SelectedIndex = 0;
		ddlReceiptTypeID.SelectedIndex = 0;
		txtPatient.Focus();
	}
	
	#endregion 16.0 Clear Controls 

}
