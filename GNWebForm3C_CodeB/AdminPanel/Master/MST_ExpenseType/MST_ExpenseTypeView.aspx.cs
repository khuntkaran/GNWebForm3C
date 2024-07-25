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
public partial class AdminPanel_Master_MST_ExpenseType_MST_ExpenseTypeView: System.Web.UI.Page
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
				if (Request.QueryString["ExpenseTypeID"] != null)
				{
					FillControls();
				}
			}
		}
		
 #endregion  

		#region FillControls
		private void FillControls()
		{
			if (Request.QueryString["ExpenseTypeID"] != null) 
			{
				MST_ExpenseTypeBAL balMST_ExpenseType = new MST_ExpenseTypeBAL();
				DataTable dtMST_ExpenseType = balMST_ExpenseType.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["ExpenseTypeID"]));
				if (dtMST_ExpenseType != null)
				{
					foreach (DataRow dr in dtMST_ExpenseType.Rows)
					{

						if (!dr["ExpenseType"].Equals(DBNull.Value))
							lblExpenseType.Text = Convert.ToString(dr["ExpenseType"]);

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
