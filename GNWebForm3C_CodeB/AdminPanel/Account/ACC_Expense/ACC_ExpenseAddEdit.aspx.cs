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


public partial class AdminPanel_Account_ACC_Expense_ACC_ExpenseAddEdit : System.Web.UI.Page
{
	#region 10.0 Local Variables 

	String FormName = "ACC_ExpenseAddEdit";
	
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

			lblFormHeader.Text = CV.PageHeaderAdd + " Expense";
			upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
			ddlExpenseTypeID.Focus();
			
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
		CommonFillMethods.FillDropDownListExpenseTypeID(ddlExpenseTypeID);
		CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
        CommonFillMethods.FillSingleDropDownListFinYearID(ddlFinYearID);
	}
	
	#endregion 13.0 Fill DropDownList
        
	#region 14.0 FillControls By PK  

	private void FillControls()
	{
		if (Request.QueryString["ExpenseID"] != null) 
		{
			lblFormHeader.Text = CV.PageHeaderEdit + " Expense";
			ACC_ExpenseBAL balACC_Expense = new ACC_ExpenseBAL();
			ACC_ExpenseENT entACC_Expense = new ACC_ExpenseENT();
			entACC_Expense = balACC_Expense.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["ExpenseID"]));

			if (!entACC_Expense.ExpenseTypeID.IsNull)
				ddlExpenseTypeID.SelectedValue = entACC_Expense.ExpenseTypeID.Value.ToString();

			if (!entACC_Expense.Amount.IsNull)
				txtAmount.Text = entACC_Expense.Amount.Value.ToString();

			if (!entACC_Expense.ExpenseDate.IsNull)
				dtpExpenseDate.Text = entACC_Expense.ExpenseDate.Value.ToString(CV.DefaultDateFormat);

			if (!entACC_Expense.Note.IsNull)
				txtNote.Text = entACC_Expense.Note.Value.ToString();

			if (!entACC_Expense.HospitalID.IsNull)
				ddlHospitalID.SelectedValue = entACC_Expense.HospitalID.Value.ToString();

			if (!entACC_Expense.FinYearID.IsNull)
				ddlFinYearID.SelectedValue = entACC_Expense.FinYearID.Value.ToString();

			if (!entACC_Expense.Remarks.IsNull)
				txtRemarks.Text = entACC_Expense.Remarks.Value.ToString();

            if (!entACC_Expense.TagName.IsNull)
                txtTagName.Text = entACC_Expense.Remarks.Value.ToString();
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
				ACC_ExpenseBAL balACC_Expense = new ACC_ExpenseBAL();
				ACC_ExpenseENT entACC_Expense = new ACC_ExpenseENT();

				#region 15.1 Validate Fields 

				String ErrorMsg = String.Empty;
				if (ddlExpenseTypeID.SelectedIndex == 0)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Expense Type");
				if (txtAmount.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Amount");
				if (dtpExpenseDate.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Expense Date");
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


				if (ddlExpenseTypeID.SelectedIndex > 0)
					entACC_Expense.ExpenseTypeID = Convert.ToInt32(ddlExpenseTypeID.SelectedValue);

				if (txtAmount.Text.Trim() != String.Empty)
					entACC_Expense.Amount = Convert.ToDecimal(txtAmount.Text.Trim());

				if (dtpExpenseDate.Text.Trim() != String.Empty)
					entACC_Expense.ExpenseDate = Convert.ToDateTime(dtpExpenseDate.Text.Trim());

				if (txtNote.Text.Trim() != String.Empty)
					entACC_Expense.Note = txtNote.Text.Trim();

				if (ddlHospitalID.SelectedIndex > 0)
					entACC_Expense.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

				if (ddlFinYearID.SelectedIndex > 0)
					entACC_Expense.FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);

				if (txtRemarks.Text.Trim() != String.Empty)
					entACC_Expense.Remarks = txtRemarks.Text.Trim();

                if (txtTagName.Text.Trim() != String.Empty)
                    entACC_Expense.TagName = txtTagName.Text.Trim();

                entACC_Expense.UserID  =  Convert.ToInt32(Session["UserID"]);

				entACC_Expense.Created  =  DateTime.Now;

				entACC_Expense.Modified  =  DateTime.Now;

				
				#endregion 15.2 Gather Data 


				#region 15.3 Insert,Update,Copy 

				if (Request.QueryString["ExpenseID"] != null && Request.QueryString["Copy"] == null) 
				{
					entACC_Expense.ExpenseID = CommonFunctions.DecryptBase64Int32(Request.QueryString["ExpenseID"]);
					if (balACC_Expense.Update(entACC_Expense))
					{
						Response.Redirect("ACC_ExpenseList.aspx");
					}
					else
					{
						ucMessage.ShowError(balACC_Expense.Message);
					}
				}
				else
				{
					if (Request.QueryString["ExpenseID"] == null || Request.QueryString["Copy"] != null)
					{
						if (balACC_Expense.Insert(entACC_Expense))
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
		ddlExpenseTypeID.SelectedIndex = 0;
		txtAmount.Text = String.Empty;
		dtpExpenseDate.Text = String.Empty;
		txtNote.Text = String.Empty;
		ddlHospitalID.SelectedIndex = 0;
		ddlFinYearID.SelectedIndex = 0;
		txtRemarks.Text = String.Empty;
        txtTagName.Text = String.Empty;
        ddlExpenseTypeID.Focus();
	}
	
	#endregion 16.0 Clear Controls 

}
