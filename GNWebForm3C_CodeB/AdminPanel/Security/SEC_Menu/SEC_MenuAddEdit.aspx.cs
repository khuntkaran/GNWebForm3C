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


public partial class AdminPanel_Security_SEC_Menu_SEC_MenuAddEdit : System.Web.UI.Page
{
	#region 10.0 Local Variables 

	String FormName = "SEC_MenuAddEdit";
	
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

			lblFormHeader.Text = CV.PageHeaderAdd + " Menu";
			upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
			txtParentMenuID.Focus();
			
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
		if (Request.QueryString["MenuID"] != null) 
		{
			lblFormHeader.Text = CV.PageHeaderEdit + " Menu";
			SEC_MenuBAL balSEC_Menu = new SEC_MenuBAL();
			SEC_MenuENT entSEC_Menu = new SEC_MenuENT();
			entSEC_Menu = balSEC_Menu.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["MenuID"]));

			if (!entSEC_Menu.ParentMenuID.IsNull)
				txtParentMenuID.Text = entSEC_Menu.ParentMenuID.Value.ToString();

			if (!entSEC_Menu.MenuName.IsNull)
				txtMenuName.Text = entSEC_Menu.MenuName.Value.ToString();

			if (!entSEC_Menu.MenuDisplayName.IsNull)
				txtMenuDisplayName.Text = entSEC_Menu.MenuDisplayName.Value.ToString();

			if (!entSEC_Menu.FormName.IsNull)
				txtFormName.Text = entSEC_Menu.FormName.Value.ToString();

			if (!entSEC_Menu.Sequence.IsNull)
				txtSequence.Text = entSEC_Menu.Sequence.Value.ToString();

			if (!entSEC_Menu.Remarks.IsNull)
				txtRemarks.Text = entSEC_Menu.Remarks.Value.ToString();

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
				SEC_MenuBAL balSEC_Menu = new SEC_MenuBAL();
				SEC_MenuENT entSEC_Menu = new SEC_MenuENT();

				#region 15.1 Validate Fields 

				String ErrorMsg = String.Empty;
				if (txtMenuName.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Menu Name");
				if (txtSequence.Text.Trim() == String.Empty)
					ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Sequence");

				if (ErrorMsg != String.Empty)
				{
					ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
					ucMessage.ShowError(ErrorMsg);
					return;
				}
				
				#endregion 15.1 Validate Fields

				#region 15.2 Gather Data 


				if (txtParentMenuID.Text.Trim() != String.Empty)
					entSEC_Menu.ParentMenuID = Convert.ToInt32(txtParentMenuID.Text.Trim());

				if (txtMenuName.Text.Trim() != String.Empty)
					entSEC_Menu.MenuName = txtMenuName.Text.Trim();

				if (txtMenuDisplayName.Text.Trim() != String.Empty)
					entSEC_Menu.MenuDisplayName = txtMenuDisplayName.Text.Trim();

				if (txtFormName.Text.Trim() != String.Empty)
					entSEC_Menu.FormName = txtFormName.Text.Trim();

				if (txtSequence.Text.Trim() != String.Empty)
					entSEC_Menu.Sequence = Convert.ToInt32(txtSequence.Text.Trim());

				if (txtRemarks.Text.Trim() != String.Empty)
					entSEC_Menu.Remarks = txtRemarks.Text.Trim();

				entSEC_Menu.UserID  =  Convert.ToInt32(Session["UserID"]);

				entSEC_Menu.Created  =  DateTime.Now;

				entSEC_Menu.Modified  =  DateTime.Now;

				
				#endregion 15.2 Gather Data 


				#region 15.3 Insert,Update,Copy 

				if (Request.QueryString["MenuID"] != null && Request.QueryString["Copy"] == null) 
				{
					entSEC_Menu.MenuID = CommonFunctions.DecryptBase64Int32(Request.QueryString["MenuID"]);
					if (balSEC_Menu.Update(entSEC_Menu))
					{
						Response.Redirect("SEC_MenuList.aspx");
					}
					else
					{
						ucMessage.ShowError(balSEC_Menu.Message);
					}
				}
				else
				{
					if (Request.QueryString["MenuID"] == null || Request.QueryString["Copy"] != null)
					{
						if (balSEC_Menu.Insert(entSEC_Menu))
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
		txtParentMenuID.Text = String.Empty;
		txtMenuName.Text = String.Empty;
		txtMenuDisplayName.Text = String.Empty;
		txtFormName.Text = String.Empty;
		txtSequence.Text = String.Empty;
		txtRemarks.Text = String.Empty;
		txtParentMenuID.Focus();
	}
	
	#endregion 16.0 Clear Controls 

}
