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
using System.Data.SqlTypes;
using System.Collections.Generic;

public partial class AdminPanel_Master_MST_ExpenseType_MST_ExpenseTypeAddEditMany : System.Web.UI.Page
{
    #region 10.0 Local Variables

    String FormName = "MST_ExpenseTypeAddEdit";

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
            if (Request.QueryString["HospitalID"] != null)
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

            lblFormHeader.Text = CV.PageHeaderMany + " Expense Type";
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
        CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 Show Button Event
    protected void btnShow_Click(object sender, EventArgs e)
    {
        SqlInt32 HospitalID = SqlInt32.Null;

        #region NavigateLogic
        if (Request.QueryString["HospitalID"] != null)
        {
            if (!Page.IsPostBack)
            {
                HospitalID = CommonFunctions.DecryptBase64Int32(Request.QueryString["HospitalID"]);
            }
            else
            {
                if (ddlHospitalID.SelectedIndex > 0)
                    HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
            }
        }
        else
        {
            if (ddlHospitalID.SelectedIndex > 0)
                HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
        }
        #endregion NavigateLogic

        MST_ExpenseTypeBAL balMST_ExpenseType = new MST_ExpenseTypeBAL();

        DataTable dt = balMST_ExpenseType.SelectShow(HospitalID);

        if (Request.QueryString["HospitalID"] != null)
            ddlHospitalID.SelectedValue = CommonFunctions.DecryptBase64(Request.QueryString["HospitalID"]);

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
            SqlInt32 HospitalID = SqlInt32.Null;
            if (ddlHospitalID.SelectedIndex > 0)
                HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

            MST_ExpenseTypeBAL balMST_ExpenseType = new MST_ExpenseTypeBAL();
            MST_ExpenseTypeENT entMST_ExpenseType = new MST_ExpenseTypeENT();

            foreach (RepeaterItem items in rpData.Items)
            {
                try
                {
                    #region FindControl

                    TextBox txtExpenseType = (TextBox)items.FindControl("txtExpenseType");
                    HiddenField Hdfiled = (HiddenField)items.FindControl("hdExpenseTypeID");
                    TextBox txtRemarks = (TextBox)items.FindControl("txtRemarks");
                    CheckBox chkIsSelected = (CheckBox)items.FindControl("chkIsSelected");


                    #endregion FindControl

                    #region 15.1.1 Gather Data

                    entMST_ExpenseType.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
                    entMST_ExpenseType.ExpenseType = txtExpenseType.Text.Trim();
                    entMST_ExpenseType.Remarks = txtRemarks.Text.Trim();
                    entMST_ExpenseType.UserID = Convert.ToInt32(Session["UserID"]);
                    entMST_ExpenseType.Created = DateTime.Now;
                    entMST_ExpenseType.Modified = DateTime.Now;

                    #endregion 15.1.1 Gather Data

                    if (Hdfiled.Value != string.Empty)
                    {
                        if (chkIsSelected.Checked)
                        {
                            #region 15.1.2 Update Data
                            if (txtExpenseType.Text.Trim() == string.Empty)
                            {
                                txtExpenseType.Focus();
                                ucMessage.ShowError("Enter Expense Type");
                                break;
                            }
                            else
                            {
                                entMST_ExpenseType.ExpenseTypeID = Convert.ToInt32(Hdfiled.Value);
                                if (balMST_ExpenseType.Update(entMST_ExpenseType))
                                {
                                    ucMessage.ShowSuccess(CommonMessage.RecordUpdated());
                                }
                            }

                            #endregion 15.1.2 Update Data
                        }
                        else
                        {
                            #region 15.1.3 Delete Data
                            if (txtExpenseType.Text.Trim() == string.Empty)
                            {
                                txtExpenseType.Focus();
                                ucMessage.ShowError("Enter Expense Type");
                                break;
                            }
                            else
                            {
                                entMST_ExpenseType.ExpenseTypeID = Convert.ToInt32(Hdfiled.Value);
                                if (balMST_ExpenseType.Delete(entMST_ExpenseType.ExpenseTypeID))
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
                            if (txtExpenseType.Text.Trim() == string.Empty && txtRemarks.Text.Trim() != string.Empty)
                            {
                                txtExpenseType.Focus();
                                ucMessage.ShowError("Enter Expense Type");
                            }
                            else
                            {
                                if (txtExpenseType.Text.Trim() != string.Empty)
                                {
                                    if (balMST_ExpenseType.Insert(entMST_ExpenseType))
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
        ddlHospitalID.SelectedIndex = 0;
    }

    #endregion 16.0 Clear Controls

    #region 17.0 Add Row Button
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ExpenseType");
        dt.Columns.Add("Remarks");
        dt.Columns.Add("ExpenseTypeID");

        foreach (RepeaterItem rp in rpData.Items)
        {
            TextBox txtExpenseType = (TextBox)rp.FindControl("txtExpenseType");
            TextBox txtRemarks = (TextBox)rp.FindControl("txtRemarks");
            HiddenField hdExpenseTypeID = (HiddenField)rp.FindControl("hdExpenseTypeID");

            DataRow dr = dt.NewRow();
            dr["ExpenseType"] = txtExpenseType.Text.Trim();
            dr["Remarks"] = txtRemarks.Text.Trim();
            dr["ExpenseTypeID"] = hdExpenseTypeID.Value.ToString();

            dt.Rows.Add(dr);
        }
        int count = 0;
        foreach(DataRow dr in dt.Rows)
        {
            if (dr["ExpenseType"].ToString() != String.Empty)
                count++;
        }
        if (count == dt.Rows.Count)
            dt.Rows.Add();

        rpData.DataSource = dt;
        rpData.DataBind();
    }
    #endregion 17.0 Add Row Button
}
