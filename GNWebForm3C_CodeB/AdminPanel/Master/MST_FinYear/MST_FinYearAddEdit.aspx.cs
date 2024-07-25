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


public partial class AdminPanel_Master_MST_FinYear_MST_FinYearAddEdit : System.Web.UI.Page
{
	#region 10.0 Local Variables 

	String FormName = "MST_FinYearAddEdit";
	
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

			lblFormHeader.Text = CV.PageHeaderAdd + " Fin Year";
			upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
			txtFinYearName.Focus();
			
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
		if (Request.QueryString["FinYearID"] != null) 
		{
			lblFormHeader.Text = CV.PageHeaderEdit + " Fin Year";
			MST_FinYearBAL balMST_FinYear = new MST_FinYearBAL();
			MST_FinYearENT entMST_FinYear = new MST_FinYearENT();
			entMST_FinYear = balMST_FinYear.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["FinYearID"]));

			if (!entMST_FinYear.FinYearName.IsNull)
				txtFinYearName.Text = entMST_FinYear.FinYearName.Value.ToString();

			if (!entMST_FinYear.FromDate.IsNull)
				dtpFromDate.Text = entMST_FinYear.FromDate.Value.ToString(CV.DefaultDateFormat);

			if (!entMST_FinYear.ToDate.IsNull)
				dtpToDate.Text = entMST_FinYear.ToDate.Value.ToString(CV.DefaultDateFormat);

			if (!entMST_FinYear.Remarks.IsNull)
				txtRemarks.Text = entMST_FinYear.Remarks.Value.ToString();

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
				MST_FinYearBAL balMST_FinYear = new MST_FinYearBAL();
				MST_FinYearENT entMST_FinYear = new MST_FinYearENT();

				#region 15.1 Validate Fields 

				String ErrorMsg = String.Empty;
				if (txtFinYearName.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Fin Year Name");
				if (dtpFromDate.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("From Date");
				if (dtpToDate.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("To Date");

				if (ErrorMsg != String.Empty)
				{
					ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
					ucMessage.ShowError(ErrorMsg);
					return;
				}
				
				#endregion 15.1 Validate Fields

				#region 15.2 Gather Data 


				if (txtFinYearName.Text.Trim() != String.Empty)
					entMST_FinYear.FinYearName = txtFinYearName.Text.Trim();

				if (dtpFromDate.Text.Trim() != String.Empty)
					entMST_FinYear.FromDate = Convert.ToDateTime(dtpFromDate.Text.Trim());

				if (dtpToDate.Text.Trim() != String.Empty)
					entMST_FinYear.ToDate = Convert.ToDateTime(dtpToDate.Text.Trim());

				if (txtRemarks.Text.Trim() != String.Empty)
					entMST_FinYear.Remarks = txtRemarks.Text.Trim();

				entMST_FinYear.UserID  =  Convert.ToInt32(Session["UserID"]);

				entMST_FinYear.Created  =  DateTime.Now;

				entMST_FinYear.Modified  =  DateTime.Now;

				
				#endregion 15.2 Gather Data 


				#region 15.3 Insert,Update,Copy 

				if (Request.QueryString["FinYearID"] != null && Request.QueryString["Copy"] == null) 
				{
					entMST_FinYear.FinYearID = CommonFunctions.DecryptBase64Int32(Request.QueryString["FinYearID"]);
					if (balMST_FinYear.Update(entMST_FinYear))
					{
						Response.Redirect("MST_FinYearList.aspx");
					}
					else
					{
						ucMessage.ShowError(balMST_FinYear.Message);
					}
				}
				else
				{
					if (Request.QueryString["FinYearID"] == null || Request.QueryString["Copy"] != null)
					{
						if (balMST_FinYear.Insert(entMST_FinYear))
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
		txtFinYearName.Text = String.Empty;
		dtpFromDate.Text = String.Empty;
		dtpToDate.Text = String.Empty;
		txtRemarks.Text = String.Empty;
		txtFinYearName.Focus();
	}
	
	#endregion 16.0 Clear Controls 

}
