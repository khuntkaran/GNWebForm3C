using GNForm3C;
using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    Session["UserID"] = 1;
    //    Session["DisplayName"] = "Fixed Login";  

    //}
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "sessionStorage.clear();", true);
        if (!Page.IsPostBack)
        {
            Session.Clear();
            this.Page.Title = "Login - " + CV.DefaultCompanyName;
           // imgLogo.ImageUrl = CV.DefaultLoginLogoPath;
        }

        #region Check Login Restricted

        

        #endregion Check Login Restricted
    }

    #endregion Page Load Event

    #region Login Button Click Event

    protected void lbtnLogin_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            String ErrorMsg = String.Empty;

            #region Validate Controls
            if (txtUsername.Text.Trim() == String.Empty)
                ErrorMsg += "Username is required<br>";

            if (txtPassword.Text.Trim() == String.Empty)
                ErrorMsg += "Password is required";

            #endregion Validate Controls

            #region Check Login Restricted



            #endregion Check Login Restricted

            #region Store Data in Session


            SEC_UserBAL balSEC_UserBAL = new SEC_UserBAL();
            DataTable dtSEC_UserBAL = balSEC_UserBAL.SelectByUserNameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.ToString());
            if (dtSEC_UserBAL != null && dtSEC_UserBAL.Rows.Count > 0)
            {
                foreach (DataRow drow in dtSEC_UserBAL.Rows)
                {
                    if (!drow["UserID"].Equals(System.DBNull.Value))
                        Session["UserID"] = drow["UserID"].ToString();


                    if (!drow["UserName"].Equals(DBNull.Value))
                        Session["DisplayName"] = drow["UserName"].ToString();

                    if (!drow["Password"].Equals(DBNull.Value))
                        Session["Password"] = drow["Password"].ToString();

                    if (!drow["HospitalID"].Equals(System.DBNull.Value))
                        Session["HospitalID"] = drow["HospitalID"].ToString();

                    if (!drow["Remarks"].Equals(System.DBNull.Value))
                        Session["Remarks"] = drow["Remarks"].ToString();

                    if (!drow["Created"].Equals(System.DBNull.Value))
                        Session["Created"] = drow["Created"].ToString();

                    if (!drow["Modified"].Equals(System.DBNull.Value))
                        Session["Modified"] = drow["Modified"].ToString();


                    string strDomainURL = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + CV.AppendForMenu;
                }
                Session["HomeURL"] = CV.DefaultHomeURL;
                Response.Redirect("~/AdminPanel/Default.aspx");
            }
            else
            {
                //ucMessage.ShowError("Invalid Username or Password");
                txtPassword.Focus();
            }

            #endregion Store Data in Session


        }
    }

    #endregion Login Button Click Event
}