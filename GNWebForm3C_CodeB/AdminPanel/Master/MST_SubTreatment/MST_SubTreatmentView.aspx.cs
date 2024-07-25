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
public partial class AdminPanel_Master_MST_SubTreatment_MST_SubTreatmentView : System.Web.UI.Page
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
            if (Request.QueryString["SubTreatmentID"] != null)
            {
                FillControls();
            }
        }
    }

    #endregion

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["SubTreatmentID"] != null)
        {
            MST_SubTreatmentBAL balMST_SubTreatment = new MST_SubTreatmentBAL();
            DataTable dtMST_SubTreatment = balMST_SubTreatment.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["SubTreatmentID"]));
            if (dtMST_SubTreatment != null)
            {
                foreach (DataRow dr in dtMST_SubTreatment.Rows)
                {

                    if (!dr["SubTreatmentName"].Equals(DBNull.Value))
                        lblSubTreatmentName.Text = Convert.ToString(dr["SubTreatmentName"]);

                    if (!dr["SequenceNo"].Equals(DBNull.Value))
                        lblSequenceNo.Text = Convert.ToString(dr["SequenceNo"]);

                    if (!dr["Rate"].Equals(DBNull.Value))
                        lblRate.Text = Convert.ToString(dr["Rate"]);

                    if (!dr["IsInGrid"].Equals(DBNull.Value))
                        lblIsInGrid.Text = Convert.ToString(dr["IsInGrid"]);

                    if (!dr["Hospital"].Equals(DBNull.Value))
                        lblHospitalID.Text = Convert.ToString(dr["Hospital"]);

                    if (!dr["IsPerDay"].Equals(DBNull.Value))
                        lblIsPerDay.Text = Convert.ToString(dr["IsPerDay"]);

                    if (!dr["DefaultUnit"].Equals(DBNull.Value))
                        lblDefaultUnit.Text = Convert.ToString(dr["DefaultUnit"]);

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
