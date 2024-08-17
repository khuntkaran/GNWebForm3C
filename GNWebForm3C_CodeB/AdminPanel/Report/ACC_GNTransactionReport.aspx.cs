using GNForm3C.BAL;
using GNForm3C;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services.Description;
using System.Security.Cryptography;
using Microsoft.ReportingServices.Interfaces;
using Org.BouncyCastle.Utilities.IO;
using System.Text;
using Microsoft.Reporting.WebForms;


public partial class AdminPanel_Report_ACC_GNTransactionReport : System.Web.UI.Page
{
    #region 11.0 Variables

    String FormName = "ACC_GNTransactionList";
    private DataTable dtPatientReceipt = new DataTable();
    private dsPatientReceipt objdsACC_GNTransaction = new dsPatientReceipt();


    #endregion 11.0 Variables

    #region 12.0 Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {

        #region 12.0 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 12.0 Check User Login
        GenerateReport();
        ExportReport("pdf");

    }

    #endregion 12.0 Page Load Event   

    private void GenerateReport()
    {
        

        ACC_GNTransactionBAL balACC_GNTransaction = new ACC_GNTransactionBAL();
        dtPatientReceipt = balACC_GNTransaction.PatientReceiptByTransactionID(CommonFunctions.DecryptBase64Int32(Request.QueryString["TransactionID"]));
        FillDataSet();

    }

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtPatientReceipt.Rows)
        {
            dsPatientReceipt.PatientReceiptRow drPatientReceipt = objdsACC_GNTransaction.PatientReceipt.NewPatientReceiptRow();

            if (!dr["PatientName"].Equals(System.DBNull.Value))
                drPatientReceipt.PatientName = Convert.ToString(dr["PatientName"]);

            if (!dr["Age"].Equals(System.DBNull.Value))
                drPatientReceipt.Age = Convert.ToInt32(dr["Age"]);

            if (!dr["MobileNo"].Equals(System.DBNull.Value))
                drPatientReceipt.MobileNo = Convert.ToString(dr["MobileNo"]);

            if (!dr["DateOfAdmission"].Equals(System.DBNull.Value))
                drPatientReceipt.DateOfAdmission = Convert.ToDateTime(dr["DateOfAdmission"]);

            if (!dr["DateOfDischarge"].Equals(System.DBNull.Value))
                drPatientReceipt.DateOfDischarge = Convert.ToDateTime(dr["DateOfDischarge"]);

            if (!dr["Hospital"].Equals(System.DBNull.Value))
                drPatientReceipt.Hospital = Convert.ToString(dr["Hospital"]);

            if (!dr["ReferenceDoctor"].Equals(System.DBNull.Value))
                drPatientReceipt.ReferenceDoctor = Convert.ToString(dr["ReferenceDoctor"]);

            if (!dr["ReceiptNo"].Equals(System.DBNull.Value))
                drPatientReceipt.ReceiptNo = Convert.ToString(dr["ReceiptNo"]);

            if (!dr["ReceiptTypeName"].Equals(System.DBNull.Value))
                drPatientReceipt.ReceiptTypeName = Convert.ToString(dr["ReceiptTypeName"]);

            if (!dr["Treatment"].Equals(System.DBNull.Value))
                drPatientReceipt.Treatment = Convert.ToString(dr["Treatment"]);

            if (!dr["Rate"].Equals(System.DBNull.Value))
                drPatientReceipt.Rate = Convert.ToDecimal(dr["Rate"]);

            if (!dr["Quantity"].Equals(System.DBNull.Value))
                drPatientReceipt.Quantity = Convert.ToInt32(dr["Quantity"]);

            if (!dr["Amount"].Equals(System.DBNull.Value))
                drPatientReceipt.Amount = Convert.ToDecimal(dr["Amount"]);

            if (!dr["TreatmentDate"].Equals(System.DBNull.Value))
                drPatientReceipt.TreatmentDate = Convert.ToDateTime(dr["TreatmentDate"]);


            objdsACC_GNTransaction.PatientReceipt.Rows.Add(drPatientReceipt);

        }

        //SetReportParamater();
        this.rvReceipt.LocalReport.DataSources.Clear();
        this.rvReceipt.LocalReport.DataSources.Add(new ReportDataSource("dtPatientReceipt", (DataTable)objdsACC_GNTransaction.PatientReceipt));
        this.rvReceipt.LocalReport.Refresh();
    }
    private void SetReportParamater()
    {
        String ReportTitle = "Income";
        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        this.rvReceipt.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, });
    }

    private void ExportReport(string format)
    {
        try
        {
            string mimeType, encoding, extension;
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamIds;

            byte[] bytes = rvReceipt.LocalReport.Render(format,
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
            Response.End();
        }
        catch (Exception ex)
        {
        }

    }




}