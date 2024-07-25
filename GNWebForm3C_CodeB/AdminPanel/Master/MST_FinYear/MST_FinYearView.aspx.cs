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
public partial class AdminPanel_Master_MST_FinYear_MST_FinYearView: System.Web.UI.Page
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
				if (Request.QueryString["FinYearID"] != null)
				{
					FillControls();
				}
			}
		}
		
 #endregion  

		#region FillControls
		private void FillControls()
		{
			if (Request.QueryString["FinYearID"] != null) 
			{
				MST_FinYearBAL balMST_FinYear = new MST_FinYearBAL();
				DataTable dtMST_FinYear = balMST_FinYear.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["FinYearID"]));
				if (dtMST_FinYear != null)
				{
					foreach (DataRow dr in dtMST_FinYear.Rows)
					{

						if (!dr["FinYearName"].Equals(DBNull.Value))
							lblFinYearName.Text = Convert.ToString(dr["FinYearName"]);

						if (!dr["FromDate"].Equals(DBNull.Value))
							lblFromDate.Text = Convert.ToDateTime(dr["FromDate"]).ToString(CV.DefaultDateTimeFormat);

						if (!dr["ToDate"].Equals(DBNull.Value))
							lblToDate.Text = Convert.ToDateTime(dr["ToDate"]).ToString(CV.DefaultDateTimeFormat);

						if (!dr["Remarks"].Equals(DBNull.Value))
							lblRemarks.Text = Convert.ToString(dr["Remarks"]);

						if (!dr["UserID"].Equals(DBNull.Value))
                            lblUserID.Text = Convert.ToString(dr["UserName"]);

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
