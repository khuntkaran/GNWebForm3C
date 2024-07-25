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
public partial class AdminPanel_Security_SEC_User_SEC_UserView: System.Web.UI.Page
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
				if (Request.QueryString["UserID"] != null)
				{
					FillControls();
				}
			}
		}
		
 #endregion  

		#region FillControls
		private void FillControls()
		{
			if (Request.QueryString["UserID"] != null) 
			{
				SEC_UserBAL balSEC_User = new SEC_UserBAL();
				DataTable dtSEC_User = balSEC_User.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["UserID"]));
				if (dtSEC_User != null)
				{
					foreach (DataRow dr in dtSEC_User.Rows)
					{

						if (!dr["UserName"].Equals(DBNull.Value))
							lblUserName.Text = Convert.ToString(dr["UserName"]);

						if (!dr["Password"].Equals(DBNull.Value))
							lblPassword.Text = Convert.ToString(dr["Password"]);

						if (!dr["HospitalID"].Equals(DBNull.Value))
							lblHospitalID.Text = Convert.ToString(dr["HospitalID"]);

						if (!dr["Remarks"].Equals(DBNull.Value))
							lblRemarks.Text = Convert.ToString(dr["Remarks"]);

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
