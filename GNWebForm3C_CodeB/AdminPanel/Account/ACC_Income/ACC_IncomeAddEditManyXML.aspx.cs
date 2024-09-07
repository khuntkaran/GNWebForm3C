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

public partial class AdminPanel_Account_ACC_Income_ACC_IncomeAddEditManyXML : System.Web.UI.Page
{

    #region 10.0 Local Variables

    String FormName = "ACC_IncomeAddEdit";

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

            lblFormHeader.Text = CV.PageHeaderMany + " Income";
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
        CommonFillMethods.FillDropDownListFinYearID(ddlFinYearID);
        CommonFillMethods.FillSingleDropDownListIncomeTypeID(ddlIncomeTypeID);
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 Show Button Event
    protected void btnShow_Click(object sender, EventArgs e)
    {
        SqlInt32 HospitalID = SqlInt32.Null;
        SqlInt32 IncomeTypeID = SqlInt32.Null;
        SqlInt32 FinYearID = SqlInt32.Null;

        #region NavigateLogic
        if (Request.QueryString["HospitalID"] != null && Request.QueryString["FinYearID"] != null && Request.QueryString["IncomeTypeID"] != null)
        {
            if (!Page.IsPostBack)
            {
                HospitalID = CommonFunctions.DecryptBase64Int32(Request.QueryString["HospitalID"]);
                IncomeTypeID = CommonFunctions.DecryptBase64Int32(Request.QueryString["IncomeTypeID"]);
                FinYearID = CommonFunctions.DecryptBase64Int32(Request.QueryString["FinYearID"]);
            }
            else
            {
                if (ddlHospitalID.SelectedIndex > 0)
                    HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
                if (ddlIncomeTypeID.SelectedIndex > 0)
                    IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);
                if (ddlFinYearID.SelectedIndex > 0)
                    FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);
            }
        }
        else
        {
            if (ddlHospitalID.SelectedIndex > 0)
                HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
            if (ddlIncomeTypeID.SelectedIndex > 0)
                IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);
            if (ddlFinYearID.SelectedIndex > 0)
                FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);
        }
        #endregion NavigateLogic

        ACC_IncomeBAL balACC_Income = new ACC_IncomeBAL();

        DataTable dt = balACC_Income.SelectShow(HospitalID, IncomeTypeID, FinYearID);

        if (Request.QueryString["HospitalID"] != null)
            ddlHospitalID.SelectedValue = CommonFunctions.DecryptBase64(Request.QueryString["HospitalID"]);
        if (Request.QueryString["IncomeTypeID"] != null)
            ddlIncomeTypeID.SelectedValue = CommonFunctions.DecryptBase64(Request.QueryString["IncomeTypeID"]);
        if (Request.QueryString["FinYearID"] != null)
            ddlFinYearID.SelectedValue = CommonFunctions.DecryptBase64(Request.QueryString["FinYearID"]);

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

    protected void rpData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            // Find the DropDownList control
            DropDownList ddlUserID = (DropDownList)e.Item.FindControl("ddlUserID");

            if (ddlUserID != null)
            {
                CommonFillMethods.FillDropDownListUserID(ddlUserID);

                DataRowView drv = e.Item.DataItem as DataRowView;

                if (drv != null && drv.Row.Table.Columns.Contains("UserID"))
                {
                    string selectedUserID = drv["UserID"].ToString();

                    if (!string.IsNullOrEmpty(selectedUserID))
                    {
                        ddlUserID.SelectedValue = selectedUserID;
                    }
                }
            }
        }
    }

    #endregion 14.0 Show Button Event

    #region Upsert XML 
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();

        if (Page.IsValid)
        {
            SqlInt32 HospitalID = SqlInt32.Null;
            SqlInt32 FinYearID = SqlInt32.Null;
            SqlInt32 IncomeTypeID = SqlInt32.Null;
            if (ddlHospitalID.SelectedIndex > 0)
                HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
            FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);
            IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedIndex);

            ACC_IncomeBAL balACC_Income = new ACC_IncomeBAL();
            ACC_IncomeENT entACC_Income = new ACC_IncomeENT();

            System.Text.StringBuilder xmlBuilder = new System.Text.StringBuilder();
            xmlBuilder.Append("<IncomeList>");

            try
            {
                foreach (RepeaterItem items in rpData.Items)
                {
                    #region FindControl
                   
                    var dtpIncomeDate = (TextBox)items.FindControl("dtpIncomeDate");
                    TextBox txtAmount = (TextBox)items.FindControl("txtAmount");
                    HiddenField Hdfiled = (HiddenField)items.FindControl("hdIncomeID");
                    TextBox txtNote = (TextBox)items.FindControl("txtNote");
                    CheckBox chkIsSelected = (CheckBox)items.FindControl("chkIsSelected");
                    #endregion FindControl

                    #region 15.1.1 Gather Data
                    String ErrorMsg = String.Empty;
                    if (chkIsSelected.Checked)
                    {
                        if (ddlFinYearID.SelectedIndex == 0)
                            ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("FinYear");

                        if (ddlIncomeTypeID.SelectedIndex == 0)
                            ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("IncomeType");

                        if (dtpIncomeDate.Text.Trim() == String.Empty)
                            ErrorMsg += " - " + CommonMessage.ErrorRequiredField("IncomeDate");

                        if (txtAmount.Text.Trim() == String.Empty)
                            ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Amount");

                        if (ErrorMsg != String.Empty)
                        {
                            ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
                            ucMessage.ShowError(ErrorMsg);
                            ddlFinYearID.Focus();
                            Div_ShowResult.Visible = true;
                            return;
                        }

                        entACC_Income.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
                        entACC_Income.FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);
                        entACC_Income.IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);
                        entACC_Income.IncomeDate = Convert.ToDateTime(dtpIncomeDate.Text);
                        entACC_Income.Amount = Convert.ToDecimal(txtAmount.Text);
                        entACC_Income.Note = Convert.ToString(txtNote.Text);
                        entACC_Income.UserID = Convert.ToInt32(Session["UserID"]);
                        entACC_Income.Created = DateTime.Now;
                        entACC_Income.Modified = DateTime.Now;

                        xmlBuilder.Append("<Income>");
                        xmlBuilder.Append("<IncomeID>").Append(Hdfiled.Value).Append("</IncomeID>");
                        xmlBuilder.Append("<IncomeTypeID>").Append(entACC_Income.IncomeTypeID).Append("</IncomeTypeID>");
                        xmlBuilder.Append("<Amount>").Append(entACC_Income.Amount).Append("</Amount>");
                        xmlBuilder.Append("<IncomeDate>").Append(entACC_Income.IncomeDate).Append("</IncomeDate>");
                        xmlBuilder.Append("<Note>").Append(entACC_Income.Note).Append("</Note>");
                        xmlBuilder.Append("<HospitalID>").Append(entACC_Income.HospitalID).Append("</HospitalID>");
                        xmlBuilder.Append("<FinYearID>").Append(entACC_Income.FinYearID).Append("</FinYearID>");
                        xmlBuilder.Append("<UserID>").Append(entACC_Income.UserID).Append("</UserID>");
                        xmlBuilder.Append("<Created>").Append(entACC_Income.Created).Append("</Created>");
                        xmlBuilder.Append("<Modified>").Append(entACC_Income.Modified).Append("</Modified>");
                        xmlBuilder.Append("<Operation>");

                        // Operation Type
                        if (!string.IsNullOrEmpty(Hdfiled.Value))
                        {
                            xmlBuilder.Append("U");
                        }
                        else
                        {
                            xmlBuilder.Append("I");
                        }

                        xmlBuilder.Append("</Operation>");
                        xmlBuilder.Append("</Income>");
                    }
                    else if (!string.IsNullOrEmpty(Hdfiled.Value)) // Delete unselected items
                    {
                        xmlBuilder.Append("<Income>");
                        xmlBuilder.Append("<IncomeID>").Append(Hdfiled.Value).Append("</IncomeID>");
                        xmlBuilder.Append("<Operation>D</Operation>");
                        xmlBuilder.Append("</Income>");
                    }
                    #endregion 15.1.1 Gather Data
                }

                xmlBuilder.Append("</IncomeList>");

                string xmlData = xmlBuilder.ToString();
                if (balACC_Income.Upsert_XML(xmlData))
                {
                    ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                    ClearControls();
                }
                else
                {
                    ucMessage.ShowError(balACC_Income.Message);
                }
            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message);
            }
        }
    }
    #endregion Upsert XML

    #region 16.0 Clear Controls
    private void ClearControls()
    {
        ddlHospitalID.SelectedIndex = 0;
        ddlIncomeTypeID.SelectedIndex = 0;
        ddlFinYearID.SelectedIndex = 0;
    }

    #endregion 16.0 Clear Controls

    #region 17.0 Add Row Button
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("IncomeDate");
        dt.Columns.Add("Amount");
        dt.Columns.Add("Note");
        dt.Columns.Add("IncomeID");
        dt.Columns.Add("IncomeTypeID");
        dt.Columns.Add("FinYearID");

        foreach (RepeaterItem rp in rpData.Items)
        {
            DropDownList FinYearID = (DropDownList)rp.FindControl("ddlFinYearID");
            DropDownList IncomeTypeID = (DropDownList)rp.FindControl("ddlIncomeTypeID");
            TextBox dtpIncomeDate = (TextBox)rp.FindControl("dtpIncomeDate");
            TextBox txtNote = (TextBox)rp.FindControl("txtNote");
            TextBox txtAmount = (TextBox)rp.FindControl("txtAmount");
            HiddenField hdIncomeID = (HiddenField)rp.FindControl("hdIncomeID");

            DataRow dr = dt.NewRow();
            dr["IncomeDate"] = dtpIncomeDate.Text.ToString().Trim() != String.Empty ? Convert.ToDateTime(dtpIncomeDate.Text.ToString().Trim()).ToString(CV.DefaultDateFormat) : null;
            dr["Amount"] = txtAmount.Text.ToString().Trim();
            dr["Note"] = txtNote.Text.Trim();
            dr["IncomeID"] = hdIncomeID.Value.ToString();
            dr["FinYearID"] = FinYearID.SelectedValue;
            dr["IncomeTypeID"] = IncomeTypeID.SelectedValue;
            dt.Rows.Add(dr);
        }
        int count = 0;
        foreach (DataRow dr in dt.Rows)
        {
            if (dr["Amount"].ToString().Trim() != string.Empty && dr["FinYearID"].ToString().Trim() != string.Empty && dr["IncomeTypeID"].ToString().Trim() != string.Empty)
                count++;
        }
        if (count == dt.Rows.Count)
        {
            dt.Rows.Add();
        }
        else
        {
            ucMessage.ShowError("Fill All Rows Data");
        }

        rpData.DataSource = dt;
        rpData.DataBind();
    }
    #endregion 17.0 Add Row Button
}