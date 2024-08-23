using GNForm3C;
using GNForm3C.BAL;
using GNForm3C.ENT;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Report_Ledger_LedgerReport : System.Web.UI.Page
{
    private DataTable dt = new DataTable();
    private dsLedgerReportByFinYearHospital dsLedgerReportByFinYearHospital = new dsLedgerReportByFinYearHospital();
    int HospitalID=1;
    int FinYearID=1;

    #region 10.0 Local Variables 

    String FormName = "Ledger";

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
            GenerateReport(HospitalID, FinYearID);
            ExportReport("pdf");
            #region 11.2 Fill Labels 

            FillLabels(FormName);

            #endregion 11.2 Fill Labels 

            #region 11.3 DropDown List Fill Section 

            FillDropDownList();

            #endregion 11.3 DropDown List Fill Section 

            #region 11.4 Set Control Default Value 

            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
            ddlHospitalID.Focus();

            #endregion 11.4 Set Control Default Value 

            #region 11.5 Fill Controls 

            FillControls();

            #endregion 11.5 Fill Controls 

            

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
        CommonFillMethods.FillSingleDropDownListFinYearID(ddlFinYearID);
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 FillControls By PK  

    private void FillControls()
    {
    }

    #endregion 14.0 FillControls By PK 

    #region 15.0 Save Button Event 

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Page.Validate();
        
        if (Page.IsValid)
        {
            try
            {

                #region 15.1 Validate Fields 

                String ErrorMsg = String.Empty;
                if (ddlHospitalID.SelectedIndex == 0)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Hospital");
                if (ddlFinYearID.SelectedIndex == 0)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Fin Year");

                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
                   
                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data 


                
                if (ddlHospitalID.SelectedIndex > 0)
                    HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

                if (ddlFinYearID.SelectedIndex > 0)
                    FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);




                #endregion 15.2 Gather Data 


                #region 15.3 Download Print
                GenerateReport(HospitalID,FinYearID);
                ExportReport("pdf");

                #endregion 15.3 Download Print

            }
            catch (Exception ex)
            {
            }
        }
    }

    #endregion 15.0 Save Button Event 

    #region 16.0 Clear Controls 

    private void btnClear_Click(object sender, EventArgs e)
    {
       
        ddlHospitalID.SelectedIndex = 0;
        ddlFinYearID.SelectedIndex = 0;
       
    }

    #endregion 16.0 Clear Controls 

    private void GenerateReport(int HospitalID,int FinYearID)
    {
        LedgerBAL ledgerBAL = new LedgerBAL();
        dt = ledgerBAL.PP_ACC_IncomeExpense_Ledger(HospitalID,FinYearID);
        FillDataSet();
    }

    protected void FillDataSet()
    {

        foreach (DataRow dr in dt.Rows)
        {
            dsLedgerReportByFinYearHospital.LedgerReportRow drLedger = dsLedgerReportByFinYearHospital.LedgerReport.NewLedgerReportRow();


            if (!dr["FinYearID"].Equals(System.DBNull.Value))
                drLedger.FinYearID = Convert.ToInt32(dr["FinYearID"]);
            if (!dr["HospitalID"].Equals(System.DBNull.Value))
                drLedger.HospitalID = Convert.ToInt32(dr["HospitalID"]);
            if (!dr["FinYearName"].Equals(System.DBNull.Value))
                drLedger.FinYearName = Convert.ToString(dr["FinYearName"]);
            if (!dr["Hospital"].Equals(System.DBNull.Value))
                drLedger.Hospital = Convert.ToString(dr["Hospital"]);
            if(!dr["ParticularID"].Equals(System.DBNull.Value))
                drLedger.ParticularID = Convert.ToInt32(dr["ParticularID"]);
            if (!dr["Particular"].Equals(System.DBNull.Value))
                drLedger.Particular = Convert.ToString(dr["Particular"]);
            if (!dr["LedgerID"].Equals(System.DBNull.Value))
                drLedger.LedgerID = Convert.ToInt32(dr["LedgerID"]);
            if (!dr["LedgerType"].Equals(System.DBNull.Value))
                drLedger.LedgerType = Convert.ToString(dr["LedgerType"]);
            if (!dr["LedgerAmount"].Equals(System.DBNull.Value))
                drLedger.LedgerAmount = Convert.ToDecimal(dr["LedgerAmount"]);
            if (!dr["LedgerDate"].Equals(System.DBNull.Value))
                drLedger.LedgerDate = Convert.ToDateTime(dr["LedgerDate"]);
            if (!dr["LedgerNote"].Equals(System.DBNull.Value))
                drLedger.LedgerNote = Convert.ToString(dr["LedgerNote"]);

            dsLedgerReportByFinYearHospital.LedgerReport.Rows.Add(drLedger);
        }
        //SetReportParameter();
        this.rvLedger.LocalReport.DataSources.Clear();
        this.rvLedger.LocalReport.DataSources.Add(new ReportDataSource("LedgerReport", (DataTable)dsLedgerReportByFinYearHospital.LedgerReport));
        this.rvLedger.LocalReport.Refresh();
    }
    private void SetReportParameter()
    {
        String ReportTitle = "Income Expense";
        String ReportSubTitle = "Hospital wise FinYear wise";
        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptReportSubTitle = new ReportParameter("ReportSubTitle", ReportSubTitle);
        this.rvLedger.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptReportSubTitle, });
    }

    private void ExportReport(string format)
    {
        try
        {
            string mimeType, encoding, extension;
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamIds;

            byte[] bytes = rvLedger.LocalReport.Render(format,
                                                        null,
                                                        out mimeType,
                                                        out encoding,
                                                        out extension,
                                                        out streamIds,
                                                        out warnings);

            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("Content-Disposition", "attachment; filename=report.pdf");
            Response.BinaryWrite(bytes);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception ex)
        {
        }

    }

}