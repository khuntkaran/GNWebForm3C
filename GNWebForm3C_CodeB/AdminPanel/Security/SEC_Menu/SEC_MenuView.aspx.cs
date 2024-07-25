using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
public partial class AdminPanel_Security_SEC_Menu_SEC_MenuView: System.Web.UI.Page
{
	#region Page Load Event 

	protected void Page_Load(object sender, EventArgs e)
	{
		#region 10.1 Check User Login 

		if (Session["UserID"] == null)
			Response.Redirect(CV.LoginPageURL);
			
 #endregion 10.1 Check User Login 

			if (!Page.IsPostBack)
			{
				if (Request.QueryString["MenuID"] != null)
				{
					FillControls();
				}
			}
		}
		
 #endregion  

		#region FillControls
		private void FillControls()
		{
			if (Request.QueryString["MenuID"] != null) 
			{
				SEC_MenuBAL balSEC_Menu = new SEC_MenuBAL();
				DataTable dtSEC_Menu = balSEC_Menu.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["MenuID"]));
				if (dtSEC_Menu != null)
				{
					foreach (DataRow dr in dtSEC_Menu.Rows)
					{

						if (!dr["ParentMenuID"].Equals(DBNull.Value))
							lblParentMenuID.Text = Convert.ToString(dr["ParentMenuID"]);

						if (!dr["MenuName"].Equals(DBNull.Value))
							lblMenuName.Text = Convert.ToString(dr["MenuName"]);

						if (!dr["MenuDisplayName"].Equals(DBNull.Value))
							lblMenuDisplayName.Text = Convert.ToString(dr["MenuDisplayName"]);

						if (!dr["FormName"].Equals(DBNull.Value))
							lblFormName.Text = Convert.ToString(dr["FormName"]);

						if (!dr["Sequence"].Equals(DBNull.Value))
							lblSequence.Text = Convert.ToString(dr["Sequence"]);

						if (!dr["Remarks"].Equals(DBNull.Value))
							lblRemarks.Text = Convert.ToString(dr["Remarks"]);

						if (!dr["UserID"].Equals(DBNull.Value))
							lblUserID.Text = Convert.ToString(dr["UserID"]);

						if (!dr["Created"].Equals(DBNull.Value))
							lblCreated.Text = Convert.ToDateTime(dr["Created"]).ToString(CV.DefaultDateTimeFormat);

						if (!dr["Modified"].Equals(DBNull.Value))
							lblModified.Text = Convert.ToDateTime(dr["Modified"]).ToString(CV.DefaultDateTimeFormat);

					}
				}
			}
		}
		#endregion FillControls
	}
