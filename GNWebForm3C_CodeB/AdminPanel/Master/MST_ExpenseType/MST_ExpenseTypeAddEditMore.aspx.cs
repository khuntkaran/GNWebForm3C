using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;

public partial class AdminPanel_Master_MST_ExpenseType_MST_ExpenseTypeAddEditMore : System.Web.UI.Page
{
    #region 10.0 Local Variables

    String FormName = "MST_ExpenseTypeAddEditMore";

    #endregion 10.0 Variables

    #region 11.0 Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login

        #region 11.2 viewstate
        if (ViewState["DataTable"] == null)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ExpenseType");
            dt.Columns.Add("Hospital");
            dt.Columns.Add("HospitalID");
            dt.Columns.Add("Remarks");
            ViewState["DataTable"] = dt;
        }

        #endregion 11.2 viewstate

        if (!Page.IsPostBack)
        {
            #region 11.3 Fill Labels

            FillLabels(FormName);

            #endregion 11.3 Fill Labels

            #region 11.4 DropDown List Fill Section

            FillDropDownList();

            #endregion 11.4 DropDown List Fill Section

            #region 11.5 Set Control Default Value

            lblFormHeader.Text = CV.PageHeaderAdd + "/Edit Expense Type ";
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
            txtExpenseType.Focus();

            #endregion 11.5 Set Control Default Value

            #region 11.6 Fill Controls

            // FillControls();

            #endregion 11.6 Fill Controls

            #region 11.7 Set Help Text

            ucHelp.ShowHelp("Help Text will be shown here");

            #endregion 11.7 Set Help Text

        }
    }

    #endregion 11.0 Page Load Event

    #region 12.0 FillLabels

    private void FillLabels(String FormName)
    {
    }

    #endregion 12.0 FillLabels

    #region 13.0 Fill DropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 btnAddMore
    protected void btnAddMore_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                if (txtExpenseType.Text.Trim() != string.Empty && ddlHospitalID.SelectedIndex > 0)
                {
                    DataTable dt = (DataTable)ViewState["DataTable"];
                    DataRow dr = dt.NewRow();
                    dr["ExpenseType"] = txtExpenseType.Text.Trim();
                    dr["HospitalID"] = ddlHospitalID.SelectedIndex;
                    dr["Hospital"] = ddlHospitalID.SelectedItem;
                    dr["Remarks"] = txtRemarks.Text.Trim();

                    dt.Rows.Add(dr);

                    rpData.DataSource = dt;
                    rpData.DataBind();
                    Div_ShowResult.Visible = true;
                    ClearControls();
                }
                else if (txtExpenseType.Text.Trim() == string.Empty && ddlHospitalID.SelectedIndex == 0)
                {
                    ucMessage.ShowError(CommonMessage.ErrorRequiredField("ExpenseType"));
                    ucMessage2.ShowError(CommonMessage.ErrorRequiredFieldDDL("Hospital"));
                }
                else if (txtExpenseType.Text.Trim() == string.Empty)
                {
                    ucMessage.ShowError(CommonMessage.ErrorRequiredField("ExpenseType"));
                }
                else if (ddlHospitalID.SelectedIndex == 0)
                {
                    ucMessage2.ShowError(CommonMessage.ErrorRequiredFieldDDL("Hospital"));
                }
            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message);
            }
        }
    }
    #endregion 14.0 btnAddMore

    #region 15.0 btnUpdate
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        btnAddMore.Visible = true;
        btnUpdate.Visible = false;
        btnAddMore_Click(sender, e);
    }
    #endregion 15.0 btnUpdate

    #region 16.0 btnSave
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            MST_ExpenseTypeBAL balMST_ExpenseType = new MST_ExpenseTypeBAL();
            MST_ExpenseTypeENT entMST_ExpenseType = new MST_ExpenseTypeENT();

            foreach (RepeaterItem items in rpData.Items)
            {
                try
                {
                    #region 16.1 FindControl

                    Label lblExpenseType = (Label)items.FindControl("lblExpenseType");
                    Label lblHospital = (Label)items.FindControl("lblHospital");
                    Label lblRemarks = (Label)items.FindControl("lblRemarks");
                    HiddenField hfHospitalID = (HiddenField)items.FindControl("hfHospitalID");

                    #endregion 16.1 FindControl

                    #region 16.2 Gather Data

                    entMST_ExpenseType.HospitalID = Convert.ToInt32(hfHospitalID.Value);
                    entMST_ExpenseType.ExpenseType = lblExpenseType.Text.Trim();
                    entMST_ExpenseType.Remarks = lblRemarks.Text.Trim();
                    entMST_ExpenseType.UserID = Convert.ToInt32(Session["UserID"]);
                    entMST_ExpenseType.Created = DateTime.Now;
                    entMST_ExpenseType.Modified = DateTime.Now;

                    #endregion 16.2 Gather Data

                    #region 16.3 Insert Data
                    if (balMST_ExpenseType.Insert(entMST_ExpenseType))
                    {
                        ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                    }
                    #endregion 16.3 Insert Data
                    Div_ShowResult.Visible = false;
                }
                catch (Exception ex)
                {
                    ucMessage.ShowError(ex.Message);
                }
            }
        }
    }
    #endregion 16.0 btnSave

    #region 17.0 rpData_ItemCommand
    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            #region 17.1 Edit Record
            if (e.CommandName == "EditRecord")
            {

                if (txtExpenseType.Text.Trim() == string.Empty && ddlHospitalID.SelectedIndex == 0)
                {
                    btnAddMore.Visible = false;
                    btnUpdate.Visible = true;

                    int rowIndex = int.Parse(e.CommandArgument.ToString());
                    DataTable dt = (DataTable)ViewState["DataTable"];
                    txtExpenseType.Text = dt.Rows[rowIndex]["ExpenseType"].ToString();
                    ddlHospitalID.SelectedIndex = Convert.ToInt32(dt.Rows[rowIndex]["HospitalID"]);
                    txtRemarks.Text = dt.Rows[rowIndex]["Remarks"].ToString();

                    dt.Rows.RemoveAt(rowIndex);
                    ViewState["DataTable"] = dt;
                    rpData.DataSource = dt;
                    rpData.DataBind();
                    if (dt.Rows.Count == 0)
                    {
                        Div_ShowResult.Visible = false;
                    }
                }
            }
            #endregion 17.1 Edit Record

            #region 17.2 Delete Record
            if (e.CommandName == "DeleteRecord")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                DataTable dt = (DataTable)ViewState["DataTable"];
                dt.Rows.RemoveAt(rowIndex);
                ViewState["DataTable"] = dt;
                rpData.DataSource = dt;
                rpData.DataBind();
                if (dt.Rows.Count == 0)
                {
                    Div_ShowResult.Visible = false;
                }
            }
            #endregion 17.2 Delete Record
        }
        catch (Exception ex)
        {
            ucMessage.ShowError(ex.Message);
        }
    }
    #endregion 17.0 rpData_ItemCommand

    #region  18.0 Clear Controls
    private void ClearControls()
    {
        txtExpenseType.Text = "";
        ddlHospitalID.SelectedIndex = 0;
        txtRemarks.Text = "";
    }

    #endregion 18.0 Clear Controlsol
}