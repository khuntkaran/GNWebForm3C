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


public partial class AdminPanel_Master_MST_ExpenseType_MST_ExpenseTypeAddEdit : System.Web.UI.Page
{
	#region 10.0 Local Variables 

	String FormName = "MST_ExpenseTypeAddEdit";
	
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

			lblFormHeader.Text = CV.PageHeaderAdd + " Expense Type";
			upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
			txtExpenseType.Focus();
			
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
        if (Request.QueryString["ExpenseTypeID"] != null) 
		{
			lblFormHeader.Text = CV.PageHeaderEdit + " Expense Type";
			MST_ExpenseTypeBAL balMST_ExpenseType = new MST_ExpenseTypeBAL();
			MST_ExpenseTypeENT entMST_ExpenseType = new MST_ExpenseTypeENT();
            entMST_ExpenseType = balMST_ExpenseType.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["ExpenseTypeID"]));

			if (!entMST_ExpenseType.ExpenseType.IsNull)
				txtExpenseType.Text = entMST_ExpenseType.ExpenseType.Value.ToString();

			if (!entMST_ExpenseType.HospitalID.IsNull)
				ddlHospitalID.SelectedValue = entMST_ExpenseType.HospitalID.Value.ToString();

			if (!entMST_ExpenseType.Remarks.IsNull)
				txtRemarks.Text = entMST_ExpenseType.Remarks.Value.ToString();

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
				MST_ExpenseTypeBAL balMST_ExpenseType = new MST_ExpenseTypeBAL();
				MST_ExpenseTypeENT entMST_ExpenseType = new MST_ExpenseTypeENT();

				#region 15.1 Validate Fields 

				String ErrorMsg = String.Empty;
				if (txtExpenseType.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Expense Type");
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


				if (txtExpenseType.Text.Trim() != String.Empty)
					entMST_ExpenseType.ExpenseType = txtExpenseType.Text.Trim();

				if (ddlHospitalID.SelectedIndex > 0)
					entMST_ExpenseType.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

				if (txtRemarks.Text.Trim() != String.Empty)
					entMST_ExpenseType.Remarks = txtRemarks.Text.Trim();

				entMST_ExpenseType.UserID  =  Convert.ToInt32(Session["UserID"]);

				entMST_ExpenseType.Created  =  DateTime.Now;

				entMST_ExpenseType.Modified  =  DateTime.Now;

				
				#endregion 15.2 Gather Data 


				#region 15.3 Insert,Update,Copy 

				if (Request.QueryString["ExpenseTypeID"] != null && Request.QueryString["Copy"] == null) 
				{
					entMST_ExpenseType.ExpenseTypeID = CommonFunctions.DecryptBase64Int32(Request.QueryString["ExpenseTypeID"]);
					if (balMST_ExpenseType.Update(entMST_ExpenseType))
					{
						Response.Redirect("MST_ExpenseTypeList.aspx");
					}
					else
					{
						ucMessage.ShowError(balMST_ExpenseType.Message);
					}
				}
				else
				{
					if (Request.QueryString["ExpenseTypeID"] == null || Request.QueryString["Copy"] != null)
					{
						if (balMST_ExpenseType.Insert(entMST_ExpenseType))
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
		txtExpenseType.Text = String.Empty;
		ddlHospitalID.SelectedIndex = 0;
		txtRemarks.Text = String.Empty;
		txtExpenseType.Focus();
	}
	
	#endregion 16.0 Clear Controls 

}
