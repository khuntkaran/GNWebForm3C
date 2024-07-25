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
public partial class AdminPanel_Account_ACC_Income_ACC_IncomeView : System.Web.UI.Page
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
            if (Request.QueryString["IncomeID"] != null)
            {
                FillControls();
            }
        }
    }

    #endregion

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["IncomeID"] != null)
        {
            ACC_IncomeBAL balACC_Income = new ACC_IncomeBAL();
            DataTable dtACC_Income = balACC_Income.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["IncomeID"]));
            if (dtACC_Income != null)
            {
                foreach (DataRow dr in dtACC_Income.Rows)
                {

                    if (!dr["IncomeType"].Equals(DBNull.Value))
                        lblIncomeTypeID.Text = Convert.ToString(dr["IncomeType"]);

                    if (!dr["Amount"].Equals(DBNull.Value))
                        lblAmount.Text = Convert.ToString(dr["Amount"]);

                    if (!dr["IncomeDate"].Equals(DBNull.Value))
                        lblIncomeDate.Text = Convert.ToDateTime(dr["IncomeDate"]).ToString(CV.DefaultDateTimeFormat);

                    if (!dr["Note"].Equals(DBNull.Value))
                        lblNote.Text = Convert.ToString(dr["Note"]);

                    if (!dr["Hospital"].Equals(DBNull.Value))
                        lblHospitalID.Text = Convert.ToString(dr["Hospital"]);

                    if (!dr["FinYearName"].Equals(DBNull.Value))
                        lblFinYearID.Text = Convert.ToString(dr["FinYearName"]);

                    //if (!dr["Remarks"].Equals(DBNull.Value))
                    //    lblRemarks.Text = Convert.ToString(dr["Remarks"]);

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