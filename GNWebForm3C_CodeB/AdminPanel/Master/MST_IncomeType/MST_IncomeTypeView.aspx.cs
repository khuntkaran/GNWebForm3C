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
public partial class AdminPanel_Master_MST_IncomeType_MST_IncomeTypeView: System.Web.UI.Page
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
				if (Request.QueryString["IncomeTypeID"] != null)
				{
					FillControls();
				}
			}
		}
		
 #endregion  

		#region FillControls
		private void FillControls()
		{
			if (Request.QueryString["IncomeTypeID"] != null) 
			{
				MST_IncomeTypeBAL balMST_IncomeType = new MST_IncomeTypeBAL();
				DataTable dtMST_IncomeType = balMST_IncomeType.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["IncomeTypeID"]));
				if (dtMST_IncomeType != null)
				{
					foreach (DataRow dr in dtMST_IncomeType.Rows)
					{

						if (!dr["IncomeType"].Equals(DBNull.Value))
							lblIncomeType.Text = Convert.ToString(dr["IncomeType"]);

						if (!dr["Hospital"].Equals(DBNull.Value))
							lblHospitalID.Text = Convert.ToString(dr["Hospital"]);

						if (!dr["Remarks"].Equals(DBNull.Value))
							lblRemarks.Text = Convert.ToString(dr["Remarks"]);

						if (!dr["UserName"].Equals(DBNull.Value))
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
