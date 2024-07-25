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


public partial class AdminPanel_Security_SEC_User_SEC_UserAddEdit : System.Web.UI.Page
{
	#region 10.0 Local Variables 

	String FormName = "SEC_UserAddEdit";
	
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

			lblFormHeader.Text = CV.PageHeaderAdd + " User";
			upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
			txtUserName.Focus();
			
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
		if (Request.QueryString["UserID"] != null) 
		{
			lblFormHeader.Text = CV.PageHeaderEdit + " User";
			SEC_UserBAL balSEC_User = new SEC_UserBAL();
			SEC_UserENT entSEC_User = new SEC_UserENT();
			entSEC_User = balSEC_User.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["UserID"]));

			if (!entSEC_User.UserName.IsNull)
				txtUserName.Text = entSEC_User.UserName.Value.ToString();

			if (!entSEC_User.Password.IsNull)
				txtPassword.Text = entSEC_User.Password.Value.ToString();

			if (!entSEC_User.HospitalID.IsNull)
				ddlHospitalID.SelectedValue = entSEC_User.HospitalID.Value.ToString();

			if (!entSEC_User.Remarks.IsNull)
				txtRemarks.Text = entSEC_User.Remarks.Value.ToString();

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
				SEC_UserBAL balSEC_User = new SEC_UserBAL();
				SEC_UserENT entSEC_User = new SEC_UserENT();

				#region 15.1 Validate Fields 

				String ErrorMsg = String.Empty;
				if (txtUserName.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("User Name");
				if (txtPassword.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Password");

				if (ErrorMsg != String.Empty)
				{
					ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
					ucMessage.ShowError(ErrorMsg);
					return;
				}
				
				#endregion 15.1 Validate Fields

				#region 15.2 Gather Data 


				if (txtUserName.Text.Trim() != String.Empty)
					entSEC_User.UserName = txtUserName.Text.Trim();

				if (txtPassword.Text.Trim() != String.Empty)
					entSEC_User.Password = txtPassword.Text.Trim();

				if (ddlHospitalID.SelectedIndex > 0)
					entSEC_User.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

				if (txtRemarks.Text.Trim() != String.Empty)
					entSEC_User.Remarks = txtRemarks.Text.Trim();

				entSEC_User.Created  =  DateTime.Now;

				entSEC_User.Modified  =  DateTime.Now;

				
				#endregion 15.2 Gather Data 


				#region 15.3 Insert,Update,Copy 

				if (Request.QueryString["UserID"] != null && Request.QueryString["Copy"] == null) 
				{
					entSEC_User.UserID = CommonFunctions.DecryptBase64Int32(Request.QueryString["UserID"]);
					if (balSEC_User.Update(entSEC_User))
					{
						Response.Redirect("SEC_UserList.aspx");
					}
					else
					{
						ucMessage.ShowError(balSEC_User.Message);
					}
				}
				else
				{
					if (Request.QueryString["UserID"] == null || Request.QueryString["Copy"] != null)
					{
						if (balSEC_User.Insert(entSEC_User))
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
		txtUserName.Text = String.Empty;
		txtPassword.Text = String.Empty;
		ddlHospitalID.SelectedIndex = 0;
		txtRemarks.Text = String.Empty;
		txtUserName.Focus();
	}
	
	#endregion 16.0 Clear Controls 

}
