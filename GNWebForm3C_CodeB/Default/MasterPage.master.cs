using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNForm3C.BAL;
using System.Data.SqlTypes;
using GNForm3C;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class Default_MasterPage : System.Web.UI.MasterPage
{

    #region 10.0 Variables
    private DataTable dtMenu;
    private string strDomainURL = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
    #endregion 10.0 Variables

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    { 
        #region 11.1 Check User Login
       
        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login

        if (!Page.IsPostBack)
        {
            #region Set Default Values

            lblCurrentUsername.Text = Session["DisplayName"].ToString();

            if (Session["PhotoPath"] != null)
                imgCurrentUserPhoto.ImageUrl = CommonFunctions.GetImageByURL(Convert.ToString(Session["PhotoPath"]));
            else
                imgCurrentUserPhoto.ImageUrl = CommonFunctions.GetImageByURL(CV.FacultyNoImagePath);


            #endregion Set Default Values

            #region Set Page Title
            Label lblPageHeader_XXXXX = (Label)cphPageHeader.FindControl("lblPageHeader_XXXXX");
            if (lblPageHeader_XXXXX != null && Session["DisplayName"] != null)
                Page.Title = lblPageHeader_XXXXX.Text.ToString() + " - " + CV.DefaultMISShortName + " - " + Session["DisplayName"].ToString();

            #endregion Set Page Title
        }
    }
    #endregion Page Load Event

    #region Logout Button Click Event
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "sessionStorage.clear();", true);

        if (Request.Cookies["GNForm3C_Username"] != null)
            Response.Cookies["GNForm3C_Username"].Expires = DateTime.Now.AddDays(-1);
        if (Request.Cookies["GNForm3C_UserID"] != null)
            Response.Cookies["GNForm3C_UserID"].Expires = DateTime.Now.AddDays(-1);

        Session.Clear();
        Response.Redirect(CV.LoginPageURL);
    }
    #endregion Logout Button Click Event

    #region ChangePassword Button Click Event
    protected void lbtnChangePassword_Click(object sender, EventArgs e)
    {
        if (Session["StudentID"] != null)
            Response.Redirect("~/StudentPanel/ChangePassword.aspx");
        else
            Response.Redirect(CV.ChangePasswordPageURL);

    }
    #endregion ChangePassword Button Click Event
}
