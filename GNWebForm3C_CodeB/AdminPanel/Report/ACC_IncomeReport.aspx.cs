using GNForm3C.BAL;
using iTextSharp.text;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Account_ACC_Income_ACC_IncomeReport : System.Web.UI.Page
{
    private DataTable dt = new DataTable();
    private dsIncome dsi = new dsIncome();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateReport();
        }
    }

    private void GenerateReport()
    {
        SqlInt32 IncomeTypeID = SqlInt32.Null;
        SqlDecimal Amount = SqlDecimal.Null;
        SqlDateTime IncomeDate = SqlDateTime.Null;
        SqlInt32 HospitalID = SqlInt32.Null;
        SqlInt32 FinYearID = SqlInt32.Null;
        Int32 Offset = 0;
        Int32 TotalRecords = 0;
        Int32 TotalPages = 1;

        ACC_IncomeBAL aCC_IncomeBAL = new ACC_IncomeBAL();
        dt = aCC_IncomeBAL.SelectPage(Offset, 20,out TotalRecords, IncomeTypeID, Amount, IncomeDate, HospitalID, FinYearID);
        FillDataSet();

    }

    protected void FillDataSet()
    {
        int serialNumber = 1; 
        foreach (DataRow dr in dt.Rows){
            dsIncome.IncomeRow drACC_Income = dsi.Income.NewIncomeRow();

            drACC_Income.Sr = serialNumber.ToString();
            serialNumber++;
            if (!dr["FinYearName"].Equals(System.DBNull.Value))
                drACC_Income.Fin_Year = Convert.ToString(dr["FinYearName"]);
            if (!dr["Hospital"].Equals(System.DBNull.Value))
                drACC_Income.Hospital = Convert.ToString(dr["Hospital"]);
            if (!dr["IncomeType"].Equals(System.DBNull.Value))
                drACC_Income.Income_Type = Convert.ToString(dr["IncomeType"]);
            if (!dr["Amount"].Equals(System.DBNull.Value))
                drACC_Income.Amount = Convert.ToDecimal(dr["Amount"]);
            if (!dr["IncomeDate"].Equals(System.DBNull.Value))
                drACC_Income.Income_Date = Convert.ToDateTime(dr["IncomeDate"]).ToString("dd-MM-yyyy");
            dsi.Income.Rows.Add(drACC_Income);
        }
        SetReportParameter();
        this.rvIncomeList.LocalReport.DataSources.Clear();
        this.rvIncomeList.LocalReport.DataSources.Add( new ReportDataSource("dsIncome",(DataTable)dsi.Income) );
        this.rvIncomeList.LocalReport.Refresh();
    }
    private void SetReportParameter()
    {
        String ReportTitle = "Income";
        ReportParameter rptReportTitle = new ReportParameter("ReportTitle",ReportTitle);
        this.rvIncomeList.LocalReport.SetParameters(new ReportParameter[] {rptReportTitle, });
    }
}