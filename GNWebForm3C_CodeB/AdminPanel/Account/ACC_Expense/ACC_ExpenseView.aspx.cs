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
public partial class AdminPanel_Account_ACC_Expense_ACC_ExpenseView: System.Web.UI.Page
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
				if (Request.QueryString["ExpenseID"] != null)
				{
					FillControls();
				}
			}
		}
		
 #endregion  

		#region FillControls
		private void FillControls()
		{
			if (Request.QueryString["ExpenseID"] != null) 
			{
				ACC_ExpenseBAL balACC_Expense = new ACC_ExpenseBAL();
				DataTable dtACC_Expense = balACC_Expense.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["ExpenseID"]));
				if (dtACC_Expense != null)
				{
					foreach (DataRow dr in dtACC_Expense.Rows)
					{

						if (!dr["ExpenseTypeID"].Equals(DBNull.Value))
							lblExpenseTypeID.Text = Convert.ToString(dr["ExpenseType"]);
                         
						if (!dr["Amount"].Equals(DBNull.Value))
							lblAmount.Text = Convert.ToString(dr["Amount"]);

						if (!dr["ExpenseDate"].Equals(DBNull.Value))
							lblExpenseDate.Text = Convert.ToDateTime(dr["ExpenseDate"]).ToString(CV.DefaultDateTimeFormat);

						if (!dr["Note"].Equals(DBNull.Value))
							lblNote.Text = Convert.ToString(dr["Note"]);

						if (!dr["HospitalID"].Equals(DBNull.Value))
							lblHospitalID.Text = Convert.ToString(dr["Hospital"]);

						if (!dr["FinYearID"].Equals(DBNull.Value))
							lblFinYearID.Text = Convert.ToString(dr["FinYearName"]);

						if (!dr["Remarks"].Equals(DBNull.Value))
							lblRemarks.Text = Convert.ToString(dr["Remarks"]);

						if (!dr["UserName"].Equals(DBNull.Value))
							lblUserID.Text = Convert.ToString(dr["UserName"]);

						if (!dr["Created"].Equals(DBNull.Value))
							lblCreated.Text = Convert.ToDateTime(dr["Created"]).ToString(CV.DefaultDateTimeFormat);

						if (!dr["Modified"].Equals(DBNull.Value))
							lblModified.Text = Convert.ToDateTime(dr["Modified"]).ToString(CV.DefaultDateTimeFormat);

						if (!dr["TagName"].Equals(DBNull.Value))
							lblTagName.Text = Convert.ToString(dr["TagName"]);
                }
				}
			}
		}
		#endregion FillControls
	}
