using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Employee_EMP_EmployeeDetail_EMP_EmployeeDetailAddEditMany : System.Web.UI.Page
{
    #region 10.0 Local Variables

    String FormName = "EMP_EmployeeDetailAddEdit";

    #endregion 10.0 Variables

    #region 11.0 Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["EmployeeTypeID"] != null)
            {
                btnShow_Click(sender, e);
            }
            #region 11.2 Fill Labels

            FillLabels(FormName);

            #endregion 11.2 Fill Labels

            #region 11.3 DropDown List Fill Section

            FillDropDownList();

            #endregion 11.3 DropDown List Fill Section

            #region 11.4 Set Control Default Value

            lblFormHeader.Text = CV.PageHeaderMany + " Employee Detail";
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;


            #endregion 11.4 Set Control Default Value
        }
    }
    #endregion Pageload

    #region 12.0 FillLabels
    private void FillLabels(String FormName)
    {
    }

    #endregion 12.0 FillLabels

    #region 13.0 Fill DropDownList
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListEmployeeTypeID(ddlEmployeeTypeID);
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 Show Button Event
    protected void btnShow_Click(object sender, EventArgs e)
    {
        SqlInt32 EmployeeTypeID = SqlInt32.Null;

        #region NavigateLogic
        if (Request.QueryString["EmployeeTypeID"] != null)
        {
            if (!Page.IsPostBack)
            {
                EmployeeTypeID = CommonFunctions.DecryptBase64Int32(Request.QueryString["EmployeeTypeID"]);
            }
            else
            {
                if (ddlEmployeeTypeID.SelectedIndex > 0)
                    EmployeeTypeID = Convert.ToInt32(ddlEmployeeTypeID.SelectedValue);
            }
        }
        else
        {
            if (ddlEmployeeTypeID.SelectedIndex > 0)
                EmployeeTypeID = Convert.ToInt32(ddlEmployeeTypeID.SelectedValue);
        }
        #endregion NavigateLogic

        EMP_EmployeeDetailBAL balEMP_EmployeeDetail = new EMP_EmployeeDetailBAL();

        DataTable dt = balEMP_EmployeeDetail.SelectShow(EmployeeTypeID);

        if (Request.QueryString["EmployeeTypeID"] != null)
            ddlEmployeeTypeID.SelectedValue = CommonFunctions.DecryptBase64(Request.QueryString["EmployeeTypeID"]);

        foreach (DataColumn dtc in dt.Columns)
        {
            dtc.AutoIncrement = false;
            dtc.AllowDBNull = true;
        }
        dt.AcceptChanges();

        int count = 10 - dt.Rows.Count;
        for (int i = 1; i <= count; i++)
        {
            dt.Rows.Add();
        }

        rpData.DataSource = dt;
        rpData.DataBind();
        Div_ShowResult.Visible = true;

    }

    #endregion 14.0 Show Button Event

    #region 15.0 Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            SqlInt32 EmployeeTypeID = SqlInt32.Null;
            if (ddlEmployeeTypeID.SelectedIndex > 0)
                EmployeeTypeID = Convert.ToInt32(ddlEmployeeTypeID.SelectedValue);

            EMP_EmployeeDetailBAL balEMP_EmployeeDetail = new EMP_EmployeeDetailBAL();
            EMP_EmployeeDetailENT entEMP_EmployeeDetail = new EMP_EmployeeDetailENT();

            foreach (RepeaterItem items in rpData.Items)
            {
                try
                {
                    #region FindControl

                    TextBox txtEmployeeName = (TextBox)items.FindControl("txtEmployeeName");
                    HiddenField Hdfiled = (HiddenField)items.FindControl("hdEmployeeID");
                    TextBox txtRemarks = (TextBox)items.FindControl("txtRemarks");
                    CheckBox chkIsSelected = (CheckBox)items.FindControl("chkIsSelected");


                    #endregion FindControl

                    #region 15.1.1 Gather Data

                    entEMP_EmployeeDetail.EmployeeTypeID = Convert.ToInt32(ddlEmployeeTypeID.SelectedValue);
                    entEMP_EmployeeDetail.EmployeeName = txtEmployeeName.Text.Trim();
                    entEMP_EmployeeDetail.Remarks = txtRemarks.Text.Trim();
                    entEMP_EmployeeDetail.UserID = Convert.ToInt32(Session["UserID"]);
                    entEMP_EmployeeDetail.Created = DateTime.Now;
                    entEMP_EmployeeDetail.Modified = DateTime.Now;

                    #endregion 15.1.1 Gather Data

                    if (Hdfiled.Value != string.Empty)
                    {
                        if (chkIsSelected.Checked)
                        {
                            #region 15.1.2 Update Data
                            if (txtEmployeeName.Text.Trim() == string.Empty)
                            {
                                txtEmployeeName.Focus();
                                ucMessage.ShowError("Enter Expense Type");
                                break;
                            }
                            else
                            {
                                entEMP_EmployeeDetail.EmployeeID = Convert.ToInt32(Hdfiled.Value);
                                if (balEMP_EmployeeDetail.Update(entEMP_EmployeeDetail))
                                {
                                    ucMessage.ShowSuccess(CommonMessage.RecordUpdated());
                                }
                            }

                            #endregion 15.1.2 Update Data
                        }
                        else
                        {
                            #region 15.1.3 Delete Data
                            if (txtEmployeeName.Text.Trim() == string.Empty)
                            {
                                txtEmployeeName.Focus();
                                ucMessage.ShowError("Enter Expense Type");
                                break;
                            }
                            else
                            {
                                entEMP_EmployeeDetail.EmployeeID = Convert.ToInt32(Hdfiled.Value);
                                if (balEMP_EmployeeDetail.Delete(entEMP_EmployeeDetail.EmployeeID))
                                {
                                    ucMessage.ShowSuccess(CommonMessage.DeletedRecord());
                                }
                            }

                            #endregion 15.1.3 Delete Data
                        }
                    }
                    else
                    {
                        if (chkIsSelected.Checked)
                        {
                            #region 15.1.4 Insert Data
                            if (txtEmployeeName.Text.Trim() == string.Empty && txtRemarks.Text.Trim() != string.Empty)
                            {
                                txtEmployeeName.Focus();
                                ucMessage.ShowError("Enter Expense Type");
                            }
                            else
                            {
                                if (txtEmployeeName.Text.Trim() != string.Empty)
                                {
                                    if (balEMP_EmployeeDetail.Insert(entEMP_EmployeeDetail))
                                    {
                                        Div_ShowResult.Visible = false;
                                        ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                                    }
                                }
                            }
                            #endregion  15.1.4 Insert Data
                        }
                    }
                    Div_ShowResult.Visible = false;
                }
                catch (Exception ex)
                {
                    ucMessage.ShowError(ex.Message);
                }
            }
            ClearControls();
        }
    }

    #endregion 15.0 Save Button Event

    #region 16.0 Clear Controls
    private void ClearControls()
    {
        ddlEmployeeTypeID.SelectedIndex = 0;
    }

    #endregion 16.0 Clear Controls

    #region 17.0 Add Row Button
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("EmployeeName");
        dt.Columns.Add("Remarks");
        dt.Columns.Add("EmployeeID");

        foreach (RepeaterItem rp in rpData.Items)
        {
            TextBox txtEmployeeName = (TextBox)rp.FindControl("txtEmployeeName");
            TextBox txtRemarks = (TextBox)rp.FindControl("txtRemarks");
            HiddenField hdEmployeeID = (HiddenField)rp.FindControl("hdEmployeeID");

            DataRow dr = dt.NewRow();
            dr["EmployeeName"] = txtEmployeeName.Text.Trim();
            dr["Remarks"] = txtRemarks.Text.Trim();
            dr["EmployeeID"] = hdEmployeeID.Value.ToString();

            dt.Rows.Add(dr);
        }
        int count = 0;
        foreach (DataRow dr in dt.Rows)
        {
            if (dr["EmployeeName"].ToString() != String.Empty)
                count++;
        }
        if (count == dt.Rows.Count)
            dt.Rows.Add();

        rpData.DataSource = dt;
        rpData.DataBind();
    }
    #endregion 17.0 Add Row Button
}