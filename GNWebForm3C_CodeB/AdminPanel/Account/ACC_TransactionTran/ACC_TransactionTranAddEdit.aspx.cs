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


public partial class AdminPanel_Account_ACC_TransactionTran_ACC_TransactionTranAddEdit : System.Web.UI.Page
{
	#region 10.0 Local Variables 

	String FormName = "ACC_TransactionTranAddEdit";
	
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

			lblFormHeader.Text = CV.PageHeaderAdd + " Transaction Tran";
			upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
			ddlTransactionID.Focus();
			
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
		CommonFillMethods.FillDropDownListTransactionID(ddlTransactionID);
		CommonFillMethods.FillDropDownListSubTreatmentID(ddlSubTreatmentID);
	}
	
	#endregion 13.0 Fill DropDownList

	#region 14.0 FillControls By PK  

	private void FillControls()
	{
		if (Request.QueryString["TransactionTranID"] != null) 
		{
			lblFormHeader.Text = CV.PageHeaderEdit + " Transaction Tran";
			ACC_TransactionTranBAL balACC_TransactionTran = new ACC_TransactionTranBAL();
			ACC_TransactionTranENT entACC_TransactionTran = new ACC_TransactionTranENT();
			entACC_TransactionTran = balACC_TransactionTran.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["TransactionTranID"]));

			if (!entACC_TransactionTran.TransactionID.IsNull)
				ddlTransactionID.SelectedValue = entACC_TransactionTran.TransactionID.Value.ToString();

			if (!entACC_TransactionTran.SubTreatmentID.IsNull)
				ddlSubTreatmentID.SelectedValue = entACC_TransactionTran.SubTreatmentID.Value.ToString();

			if (!entACC_TransactionTran.Quantity.IsNull)
				txtQuantity.Text = entACC_TransactionTran.Quantity.Value.ToString();

			if (!entACC_TransactionTran.Unit.IsNull)
				txtUnit.Text = entACC_TransactionTran.Unit.Value.ToString();

			if (!entACC_TransactionTran.Rate.IsNull)
				txtRate.Text = entACC_TransactionTran.Rate.Value.ToString();

			if (!entACC_TransactionTran.Amount.IsNull)
				txtAmount.Text = entACC_TransactionTran.Amount.Value.ToString();

			if (!entACC_TransactionTran.Remarks.IsNull)
				txtRemarks.Text = entACC_TransactionTran.Remarks.Value.ToString();

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
				ACC_TransactionTranBAL balACC_TransactionTran = new ACC_TransactionTranBAL();
				ACC_TransactionTranENT entACC_TransactionTran = new ACC_TransactionTranENT();

				#region 15.1 Validate Fields 

				String ErrorMsg = String.Empty;
				if (ddlTransactionID.SelectedIndex == 0)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Transaction");

				if (ErrorMsg != String.Empty)
				{
					ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
					ucMessage.ShowError(ErrorMsg);
					return;
				}
				
				#endregion 15.1 Validate Fields

				#region 15.2 Gather Data 


				if (ddlTransactionID.SelectedIndex > 0)
					entACC_TransactionTran.TransactionID = Convert.ToInt32(ddlTransactionID.SelectedValue);

				if (ddlSubTreatmentID.SelectedIndex > 0)
					entACC_TransactionTran.SubTreatmentID = Convert.ToInt32(ddlSubTreatmentID.SelectedValue);

				if (txtQuantity.Text.Trim() != String.Empty)
					entACC_TransactionTran.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());

				if (txtUnit.Text.Trim() != String.Empty)
					entACC_TransactionTran.Unit = txtUnit.Text.Trim();

				if (txtRate.Text.Trim() != String.Empty)
					entACC_TransactionTran.Rate = Convert.ToDecimal(txtRate.Text.Trim());

				if (txtAmount.Text.Trim() != String.Empty)
					entACC_TransactionTran.Amount = Convert.ToDecimal(txtAmount.Text.Trim());

				if (txtRemarks.Text.Trim() != String.Empty)
					entACC_TransactionTran.Remarks = txtRemarks.Text.Trim();

				entACC_TransactionTran.UserID  =  Convert.ToInt32(Session["UserID"]);

				entACC_TransactionTran.Created  =  DateTime.Now;

				entACC_TransactionTran.Modified  =  DateTime.Now;

				
				#endregion 15.2 Gather Data 


				#region 15.3 Insert,Update,Copy 

				if (Request.QueryString["TransactionTranID"] != null && Request.QueryString["Copy"] == null) 
				{
					entACC_TransactionTran.TransactionTranID = CommonFunctions.DecryptBase64Int32(Request.QueryString["TransactionTranID"]);
					if (balACC_TransactionTran.Update(entACC_TransactionTran))
					{
						Response.Redirect("ACC_TransactionTranList.aspx");
					}
					else
					{
						ucMessage.ShowError(balACC_TransactionTran.Message);
					}
				}
				else
				{
					if (Request.QueryString["TransactionTranID"] == null || Request.QueryString["Copy"] != null)
					{
						if (balACC_TransactionTran.Insert(entACC_TransactionTran))
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
		ddlTransactionID.SelectedIndex = 0;
		ddlSubTreatmentID.SelectedIndex = 0;
		txtQuantity.Text = String.Empty;
		txtUnit.Text = String.Empty;
		txtRate.Text = String.Empty;
		txtAmount.Text = String.Empty;
		txtRemarks.Text = String.Empty;
		ddlTransactionID.Focus();
	}
	
	#endregion 16.0 Clear Controls 

}
