using GNForm3C.BAL;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;

public partial class AdminPanel_Report_ICard_PatientICard : System.Web.UI.Page
{
    private DataTable dt = new DataTable();
    private dsPatientID dsPatientID = new dsPatientID();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateReport();
        }
    }

    private void GenerateReport()
    {
       
        MST_PatientBAL mST_PatientBAL = new MST_PatientBAL();
        dt = mST_PatientBAL.PP_Patient_ICard();
        FillDataSet();

    }

    protected void FillDataSet()
    {

        foreach (DataRow dr in dt.Rows)
        {
            dsPatientID.PatientICardRow drPatientICard = dsPatientID.PatientICard.NewPatientICardRow();

            if (!dr["PatientID"].Equals(System.DBNull.Value))
                drPatientICard.PatientID = Convert.ToInt32(dr["PatientID"]);
            if (!dr["PatientName"].Equals(System.DBNull.Value))
                drPatientICard.PatientName = Convert.ToString(dr["PatientName"]);
            if (!dr["DOB"].Equals(System.DBNull.Value))
                drPatientICard.DOB = Convert.ToDateTime(dr["DOB"]);
            if (!dr["Age"].Equals(System.DBNull.Value))
                drPatientICard.Age = Convert.ToString(dr["Age"]);
            if (!dr["MobileNo"].Equals(System.DBNull.Value))
                drPatientICard.MobileNo = Convert.ToString(dr["MobileNo"]);
            
            if (!dr["PrimaryDesc"].Equals(System.DBNull.Value))
                drPatientICard.PrimaryDesc = Convert.ToString(dr["PrimaryDesc"]);
            if (!dr["HospitalID"].Equals(System.DBNull.Value))
                drPatientICard.HospitalID = Convert.ToInt32(dr["HospitalID"]);
            if (!dr["Hospital"].Equals(System.DBNull.Value))
                drPatientICard.Hospital = Convert.ToString(dr["Hospital"]);
            if (!dr["FinYearID"].Equals(System.DBNull.Value))
                drPatientICard.FinYearID = Convert.ToInt32(dr["FinYearID"]);
            if (!dr["FinYearName"].Equals(System.DBNull.Value))
                drPatientICard.FinYearName = Convert.ToString(dr["FinYearName"]);

            if (!dr["PatientID"].Equals(System.DBNull.Value))
                drPatientICard.PatientBarcode = GenerateBarcode(Convert.ToString(dr["PatientID"]));

            dsPatientID.PatientICard.Rows.Add(drPatientICard);
        }
        //SetReportParameter();
        this.rvPatientICard.LocalReport.DataSources.Clear();
        this.rvPatientICard.LocalReport.DataSources.Add(new ReportDataSource("PatientICard", (DataTable)dsPatientID.PatientICard));
        this.rvPatientICard.LocalReport.Refresh();
    }
    private void SetReportParameter()
    {
        String ReportTitle = "Income Expense";
        String ReportSubTitle = "Hospital wise FinYear wise";
        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptReportSubTitle = new ReportParameter("ReportSubTitle", ReportSubTitle);
        this.rvPatientICard.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptReportSubTitle, });
    }

    private byte[] GenerateBarcode(string data)
    {
        // Create a barcode writer instance
        var barcodeWriter = new BarcodeWriter
        {
            Format = BarcodeFormat.CODE_128,
            Options = new ZXing.Common.EncodingOptions
            {
                Height = 150,
                Width = 300
            }
        };

        // Generate the barcode image
        using (Bitmap bitmap = barcodeWriter.Write(data))
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}