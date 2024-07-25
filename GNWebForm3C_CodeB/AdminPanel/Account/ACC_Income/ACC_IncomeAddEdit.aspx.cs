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


public partial class AdminPanel_Account_ACC_Income_ACC_IncomeAddEdit : System.Web.UI.Page
{
	#region 10.0 Local Variables 

	String FormName = "ACC_IncomeAddEdit";
	
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

			lblFormHeader.Text = CV.PageHeaderAdd + " Income";
			upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
			ddlIncomeTypeID.Focus();
			
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
		CommonFillMethods.FillSingleDropDownListIncomeTypeID(ddlIncomeTypeID);
		CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
		CommonFillMethods.FillSingleDropDownListFinYearID(ddlFinYearID);
	}
	
	#endregion 13.0 Fill DropDownList

	#region 14.0 FillControls By PK  

	private void FillControls()
	{
		if (Request.QueryString["IncomeID"] != null) 
		{
			lblFormHeader.Text = CV.PageHeaderEdit + " Income";
			ACC_IncomeBAL balACC_Income = new ACC_IncomeBAL();
			ACC_IncomeENT entACC_Income = new ACC_IncomeENT();
			entACC_Income = balACC_Income.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["IncomeID"]));

			if (!entACC_Income.IncomeTypeID.IsNull)
				ddlIncomeTypeID.SelectedValue = entACC_Income.IncomeTypeID.Value.ToString();

			if (!entACC_Income.Amount.IsNull)
				txtAmount.Text = entACC_Income.Amount.Value.ToString();

			if (!entACC_Income.IncomeDate.IsNull)
				dtpIncomeDate.Text = entACC_Income.IncomeDate.Value.ToString(CV.DefaultDateFormat);

			if (!entACC_Income.Note.IsNull)
				txtNote.Text = entACC_Income.Note.Value.ToString();

			if (!entACC_Income.HospitalID.IsNull)
				ddlHospitalID.SelectedValue = entACC_Income.HospitalID.Value.ToString();

			if (!entACC_Income.FinYearID.IsNull)
				ddlFinYearID.SelectedValue = entACC_Income.FinYearID.Value.ToString();

			//if (!entACC_Income.Remarks.IsNull)
			//	txtRemarks.Text = entACC_Income.Remarks.Value.ToString();

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
				ACC_IncomeBAL balACC_Income = new ACC_IncomeBAL();
				ACC_IncomeENT entACC_Income = new ACC_IncomeENT();

				#region 15.1 Validate Fields 

				String ErrorMsg = String.Empty;
				if (ddlIncomeTypeID.SelectedIndex == 0)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Income Type");
				if (txtAmount.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Amount");
				if (dtpIncomeDate.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Income Date");
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


				if (ddlIncomeTypeID.SelectedIndex > 0)
					entACC_Income.IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);

				if (txtAmount.Text.Trim() != String.Empty)
					entACC_Income.Amount = Convert.ToDecimal(txtAmount.Text.Trim());

				if (dtpIncomeDate.Text.Trim() != String.Empty)
					entACC_Income.IncomeDate = Convert.ToDateTime(dtpIncomeDate.Text.Trim());

				if (txtNote.Text.Trim() != String.Empty)
					entACC_Income.Note = txtNote.Text.Trim();

				if (ddlHospitalID.SelectedIndex > 0)
					entACC_Income.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

				if (ddlFinYearID.SelectedIndex > 0)
					entACC_Income.FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);

				//if (txtRemarks.Text.Trim() != String.Empty)
				//	entACC_Income.Remarks = txtRemarks.Text.Trim();

				entACC_Income.UserID  =  Convert.ToInt32(Session["UserID"]);

				entACC_Income.Created  =  DateTime.Now;

				entACC_Income.Modified  =  DateTime.Now;

				
				#endregion 15.2 Gather Data 


				#region 15.3 Insert,Update,Copy 

				if (Request.QueryString["IncomeID"] != null && Request.QueryString["Copy"] == null) 
				{
					entACC_Income.IncomeID = CommonFunctions.DecryptBase64Int32(Request.QueryString["IncomeID"]);
                    if (balACC_Income.Update(entACC_Income))
					{
						Response.Redirect("ACC_IncomeList.aspx");
					}
					else
					{
						ucMessage.ShowError(balACC_Income.Message);
					}
				}
				else
				{
					if (Request.QueryString["IncomeID"] == null || Request.QueryString["Copy"] != null)
					{
                        if (balACC_Income.Insert(entACC_Income))
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
		ddlIncomeTypeID.SelectedIndex = 0;
		txtAmount.Text = String.Empty;
		dtpIncomeDate.Text = String.Empty;
		txtNote.Text = String.Empty;
		ddlHospitalID.SelectedIndex = 0;
		ddlFinYearID.SelectedIndex = 0;
		//txtRemarks.Text = String.Empty;
		ddlIncomeTypeID.Focus();
	}
	
	#endregion 16.0 Clear Controls 

}
