using GNForm3C;
using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Employee_EMP_EmployeeDetail_EMP_EmployeeDetailView : System.Web.UI.Page
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
            if (Request.QueryString["EmployeeID"] != null)
            {
                FillControls();
            }
        }
    }

    #endregion

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["EmployeeID"] != null)
        {
            EMP_EmployeeDetailBAL balEMP_EmployeeDetail = new EMP_EmployeeDetailBAL();
            DataTable dtMST_ExpenseType = balEMP_EmployeeDetail.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["EmployeeID"]));
            if (dtMST_ExpenseType != null)
            {
                foreach (DataRow dr in dtMST_ExpenseType.Rows)
                {

                    if (!dr["EmployeeName"].Equals(DBNull.Value))
                        lblEmployeeName.Text = Convert.ToString(dr["EmployeeName"]);

                    if (!dr["EmployeeTypeName"].Equals(DBNull.Value))
                        lblEmployeeType.Text = Convert.ToString(dr["EmployeeTypeName"]);

                    if (!dr["Remarks"].Equals(DBNull.Value))
                        lblRemarks.Text = Convert.ToString(dr["Remarks"]);

                    if (!dr["UserName"].Equals(DBNull.Value))
                        lblUserName.Text = Convert.ToString(dr["UserName"]);

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