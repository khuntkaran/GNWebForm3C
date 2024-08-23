using GNForm3C.BAL;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_Reports_RPT_ACC_Expense_RPT_HospitalWiseDateWiseExpenseList : System.Web.UI.Page
{

    #region 11.0 Variables

    String FormName = "HospitalWise Date wise Expense";
    private DataTable dtACC_Expense = new DataTable("dtACC_Expense");
    private ds_ACC_Expense objdsACC_Expense = new ds_ACC_Expense();

    #endregion 11.0 Variables

    #region 12.0 Page Load event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 12.0 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 12.0 Check User Login

        if (!Page.IsPostBack)
        {

            #region 12.1 Set Default Value

            lblSearchHeader.Text = CV.SearchHeaderText;

            #endregion 12.1 Set Default Value

            #region 12.2 DropDown List Fill Section

            FillDropDownList();

            #endregion 12.2 DropDown List Fill Section

            SetDefaultDates();


            #region 12.3 Set Help Text
            ucHelp.ShowHelp("Help Text will be shown here");
            #endregion 12.3 Set Help Text
        }
    }
    #endregion

    #region 13.0 Fillable
    private void FillLabels(String FormName)
    {
    }
    #endregion

    #region 14.0 DropDownList

    #region 14.1 Fill DropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
    }

    #endregion 14.1 Fill DropDownList

    #endregion 14.0 DropDownList

    #region 15.0 Search

    #region 15.1 Button Search Click Event

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search();
    }

    #endregion 15.1 Button Search Click Event

    #region 15.2 Search Function

    private void Search()
    {
        #region Parameters

        SqlDateTime FromDate = SqlDateTime.Null;
        SqlDateTime ToDate = SqlDateTime.Null;
        SqlInt32 HospitalID = SqlInt32.Null;

        #endregion Parameters

        #region Gather Data
        if (dtpFromDate.Text.Trim() != String.Empty)
            FromDate = Convert.ToDateTime(dtpFromDate.Text.Trim());

        if (dtpToDate.Text.Trim() != String.Empty)
            ToDate = Convert.ToDateTime(dtpToDate.Text.Trim());

        if (ddlHospitalID.SelectedIndex > 0)
            HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

        #endregion Gather Data

        if (FromDate < ToDate)
        {
            ACC_ExpenseBAL balACC_Expense = new ACC_ExpenseBAL();

            dtACC_Expense = balACC_Expense.SelectHospitalWiseExpenseList(FromDate, ToDate, HospitalID);

            if (dtACC_Expense != null && dtACC_Expense.Rows.Count > 0)
            {
                Div_SearchResult.Visible = true;
                Div_ExportOption.Visible = true;
                rpData.DataSource = dtACC_Expense;
                rpData.DataBind();
                ShowReport();
            }
            else
            {
                Div_SearchResult.Visible = false;
                lbtnExportExcel.Visible = false;

                rpData.DataSource = null;
                rpData.DataBind();

                lblRecordInfoTop.Text = CommonMessage.NoRecordFound();

                ucMessage.ShowError(CommonMessage.NoRecordFound());
            }
        }
        else
        {
            Div_SearchResult.Visible = false;
            lbtnExportExcel.Visible = false;

            rpData.DataSource = null;
            rpData.DataBind();

            ucMessage.ShowError(CommonMessage.ToDate_GreaterThan_FromDate());
        }
    }

    #endregion 15.2 Search Function

    #endregion 15.0 Search

    #region 16.0 Repeater Events

    #region 16.1 Item Command Event

    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            try
            {
                ACC_ExpenseBAL balACC_Expense = new ACC_ExpenseBAL();
                if (e.CommandArgument.ToString().Trim() != "")
                {
                    if (balACC_Expense.Delete(Convert.ToInt32(e.CommandArgument)))
                    {
                        ucMessage.ShowSuccess(CommonMessage.DeletedRecord());

                        if (ViewState["CurrentPage"] != null)
                        {
                            int Count = rpData.Items.Count;

                            if (Count == 1 && Convert.ToInt32(ViewState["CurrentPage"]) != 1)
                                ViewState["CurrentPage"] = (Convert.ToInt32(ViewState["CurrentPage"]) - 1);
                            Search();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message.ToString());
            }
        }
    }

    #endregion 16.1 Item Command Event

    #endregion 16.0 Repeater Events

    #region 17.0 Export Data

    #region 17.1 Excel Export Button Click Event

    protected void lbtnExport_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        String ExportType = lbtn.CommandArgument.ToString();

        #region Parameters

        SqlDateTime FromDate = SqlDateTime.Null;
        SqlDateTime ToDate = SqlDateTime.Null;
        SqlInt32 HospitalID = SqlInt32.Null;

        #endregion Parameters

        #region Gather Data

        if (dtpFromDate.Text.Trim() != String.Empty)
            FromDate = Convert.ToDateTime(dtpFromDate.Text);

        if (dtpFromDate.Text.Trim() != String.Empty)
            ToDate = Convert.ToDateTime(dtpToDate.Text);

        if (ddlHospitalID.SelectedIndex > 0)
            HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

        #endregion Gather Data

        ACC_ExpenseBAL balACC_Expense = new ACC_ExpenseBAL();

        dtACC_Expense = balACC_Expense.SelectHospitalWiseExpenseList(FromDate, ToDate, HospitalID);
        if (dtACC_Expense != null && dtACC_Expense.Rows.Count > 0)
        {
            ExportReport(ExportType);
        }
    }

    private void ExportReport(string format)
    {
        try
        {
            string mimeType, encoding, extension;
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamIds;

            byte[] bytes = rvHospitalWiseExpenseList.LocalReport.Render(format,
                                                        null,
                                                        out mimeType,
                                                        out encoding,
                                                        out extension,
                                                        out streamIds,
                                                        out warnings);

            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("Content-Disposition", "attachment; filename=report." + extension);
            Response.BinaryWrite(bytes);
            Response.End();

        }
        catch (Exception ex)
        {
            ucMessage.ShowError(format + " is Not Correct Format");
        }

    }

    #endregion 17.1 Excel Export Button Click Event

    #endregion 17.0 Export Data

    #region 18.0 Cancel Button Event

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    #endregion 18.0 Cancel Button Event

    #region 19.0 ClearControls 

    private void ClearControls()
    {
        ddlHospitalID.Items.Clear();
        dtpFromDate.Text = String.Empty;
        dtpToDate.Text = String.Empty;
        CommonFunctions.BindEmptyRepeater(rpData);
        Div_SearchResult.Visible = false;
        //Div_ExportOption.Visible = false;
        lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
    }

    #endregion 19.0 ClearControls

    #region 20.0 SetDefaultDate
    private void SetDefaultDates()
    {
        var today = DateTime.Today;
        var firstDay = new DateTime(today.Year, today.Month, 1);
        var lastDay = firstDay.AddMonths(1).AddDays(-1);

        dtpFromDate.Text = firstDay.ToString("dd/MM/yyyy");
        dtpToDate.Text = lastDay.ToString("dd/MM/yyyy");
    }
    #endregion 20.0 SetDefaultDate

    #region 21.0 Reports

    #region 21.1 Show Report
    protected void ShowReport()
    {
        FillDataSet();
    }
    #endregion 21.1 Show Report

    #region 21.3 FillDataSet
    protected void FillDataSet()
    {
        foreach (DataRow dr in dtACC_Expense.Rows)
        {
            ds_ACC_Expense.dt_ACC_ExpenseRow drACC_Expense = objdsACC_Expense.dt_ACC_Expense.Newdt_ACC_ExpenseRow();

            if (!dr["ExpenseID"].Equals(System.DBNull.Value))
                drACC_Expense.ExpenseID = Convert.ToInt32(dr["ExpenseID"]);

            if (!dr["ExpenseType"].Equals(System.DBNull.Value))
                drACC_Expense.ExpenseType = Convert.ToString(dr["ExpenseType"]);

            if (!dr["Amount"].Equals(System.DBNull.Value))
                drACC_Expense.Amount = Convert.ToDecimal(dr["Amount"]);

            if (!dr["ExpenseDate"].Equals(System.DBNull.Value))
                drACC_Expense.ExpenseDate = Convert.ToDateTime(dr["ExpenseDate"]);

            if (!dr["Note"].Equals(System.DBNull.Value))
                drACC_Expense.Note = Convert.ToString(dr["Note"]);

            if (!dr["Hospital"].Equals(System.DBNull.Value))
                drACC_Expense.Hospital = Convert.ToString(dr["Hospital"]);

            if (!dr["FinYearName"].Equals(System.DBNull.Value))
                drACC_Expense.FinYearName = Convert.ToString(dr["FinYearName"]);

            if (!dr["Remarks"].Equals(System.DBNull.Value))
                drACC_Expense.Remarks = Convert.ToString(dr["Remarks"]);

            if (!dr["ExpenseTypeID"].Equals(System.DBNull.Value))
                drACC_Expense.ExpenseTypeID = Convert.ToInt32(dr["ExpenseTypeID"]);

            if (!dr["TagName"].Equals(System.DBNull.Value))
                drACC_Expense.TagName = Convert.ToString(dr["TagName"]);

            if (!dr["HospitalID"].Equals(System.DBNull.Value))
                drACC_Expense.HospitalID = Convert.ToInt32(dr["HospitalID"]);

            if (!dr["FinYearID"].Equals(System.DBNull.Value))
                drACC_Expense.FinYearID = Convert.ToInt32(dr["FinYearID"]);


            objdsACC_Expense.dt_ACC_Expense.Rows.Add(drACC_Expense);
        }

        //SetReportParameters();
        this.rvHospitalWiseExpenseList.LocalReport.DataSources.Clear();
        this.rvHospitalWiseExpenseList.LocalReport.DataSources.Add(new ReportDataSource("dt_ACC_Expense", (DataTable)objdsACC_Expense.dt_ACC_Expense));
        this.rvHospitalWiseExpenseList.LocalReport.Refresh();
    }
    #endregion 21.3 FillDataSet

    #region 21.4 SetReportParameter
    private void SetReportParameters()
    {
        String ReportTitle = "Hospital wise Expense list";
        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        this.rvHospitalWiseExpenseList.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle,});
    }
    #endregion 21.4 SetReportParameter

    #endregion 21.0 reports
}