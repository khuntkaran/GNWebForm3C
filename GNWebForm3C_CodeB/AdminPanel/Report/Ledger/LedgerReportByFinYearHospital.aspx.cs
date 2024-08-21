using GNForm3C.BAL;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Report_Ledger_LedgerReportByFinYearHospital : System.Web.UI.Page
{
    private DataTable dt = new DataTable();
    private dsLedgerReportByFinYearHospital dsLedgerReportByFinYearHospital = new dsLedgerReportByFinYearHospital();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateReport();
        }
    }

    private void GenerateReport()
    {
        LedgerBAL ledgerBAL = new LedgerBAL();
        dt = ledgerBAL.PP_HospitalWise_FinYearWise_IncomeExpenseList();
        FillDataSet();

    }

    protected void FillDataSet()
    {
        
        foreach (DataRow dr in dt.Rows)
        {
            dsLedgerReportByFinYearHospital.LedgerReportByFinYearHospitalRow drLedger = dsLedgerReportByFinYearHospital.LedgerReportByFinYearHospital.NewLedgerReportByFinYearHospitalRow();


            if (!dr["FinYearID"].Equals(System.DBNull.Value))
                drLedger.FinYearID = Convert.ToInt32(dr["FinYearID"]);
            if (!dr["HospitalID"].Equals(System.DBNull.Value))
                drLedger.HospitalID = Convert.ToInt32(dr["HospitalID"]);
            if (!dr["FinYearName"].Equals(System.DBNull.Value))
                drLedger.FinYearName = Convert.ToString(dr["FinYearName"]);
            if (!dr["Hospital"].Equals(System.DBNull.Value))
                drLedger.Hospital = Convert.ToString(dr["Hospital"]);
            if (!dr["TotalIncome"].Equals(System.DBNull.Value))
                drLedger.TotalIncome = Convert.ToDecimal(dr["TotalIncome"]);
            if (!dr["TotalExpense"].Equals(System.DBNull.Value))
                drLedger.TotalExpense = Convert.ToDecimal(dr["TotalExpense"]);
            if (!dr["TotalPatients"].Equals(System.DBNull.Value))
                drLedger.TotalPatients = Convert.ToInt32(dr["TotalPatients"]);
            dsLedgerReportByFinYearHospital.LedgerReportByFinYearHospital.Rows.Add(drLedger);
        }
        //SetReportParameter();
        this.rvIncomeList.LocalReport.DataSources.Clear();
        this.rvIncomeList.LocalReport.DataSources.Add(new ReportDataSource("LedgerReportByFinYearHospital", (DataTable)dsLedgerReportByFinYearHospital.LedgerReportByFinYearHospital));
        this.rvIncomeList.LocalReport.Refresh();
    }
    private void SetReportParameter()
    {
        String ReportTitle = "Income";
        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        this.rvIncomeList.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, });
    }
}