using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using GNForm3C;

public partial class Default_Export : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        String ExportType = String.Empty;

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ExportType"] != null)
            {
                ExportType = Request.QueryString["ExportType"].ToString();
                DataTable dt = (DataTable)Session["ExportTable"];
                Export(ExportType, dt);
            }
        }
    }

    private void Export(String ExportType, DataTable dt)
    {
        String FileName = String.Empty;
        if (Request.QueryString["FileName"] != null)
            FileName = Request.QueryString["FileName"].ToString() + "_";

        if (ExportType == "Excel")
            ExporttoExcel(dt, FileName + DateTime.Now.ToString());
        else if (ExportType == "PDF")
            ExportToPDF(dt, FileName + DateTime.Now.ToString());
    }

    private void ExporttoExcel(DataTable dt, String FileName)
    {
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Buffer = true;
        Response.ContentType = "application/ms-excel";
        // Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");

        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");

        Response.Charset = "utf-8";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");

        Response.Write("<Table border='1' style='border:1px solid;border-collapse:collapse;'> <TR>");


        //am getting my grid's column headers

        foreach (DataColumn dc in dt.Columns)
        {
            if (Request.QueryString["All"] == null)
                if (dc.ColumnName.EndsWith("ID") || dc.ColumnName.Contains("Lock") || dc.ColumnName.Contains("Created") || dc.ColumnName.Contains("Modified") || dc.ColumnName.Contains("Path"))
                    continue;

           


            Response.Write("<Td>");
            Response.Write("<B>");
            if (Request.QueryString["All"] != null && dc.ColumnName.EndsWith("ID"))
            {
                Response.Write(dc.ColumnName.ToString().Remove(dc.ColumnName.ToString().Length-2,2));
            }
            else if (Request.QueryString["All"] != null && dc.ColumnName.EndsWith("Path"))
            {
                Response.Write(dc.ColumnName.ToString().Remove(dc.ColumnName.ToString().Length - 4, 4));
            }
            else
            {
                Response.Write(dc.ColumnName);
            }
            Response.Write("</B>");
            Response.Write("</Td>");
        }

        Response.Write("</TR>");


        foreach (DataRow dr in dt.Rows)
        {
            Response.Write("<TR>");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (Request.QueryString["All"] == null)
                    if (dt.Columns[i].ColumnName.EndsWith("ID") || dt.Columns[i].ColumnName.Contains("Lock") || dt.Columns[i].ColumnName.Contains("Created") || dt.Columns[i].ColumnName.Contains("Modified") || dt.Columns[i].ColumnName.Contains("Path"))
                        continue;

                Response.Write("<Td>");
                if (dt.Columns[i].ColumnName.EndsWith("Date") && !dr[i].Equals(DBNull.Value))
                {
                    DateTime value;
                    if (DateTime.TryParse(dr[i].ToString(), out value))
                    {
                        Response.Write(Convert.ToDateTime(dr[i].ToString()).ToString(CV.DefaultDateFormat));
                    }
                    else
                        Response.Write(dr[i].ToString());
                }
                else if (dt.Columns[i].ColumnName.EndsWith("DateTime") && !dr[i].Equals(DBNull.Value))
                {
                    DateTime value;
                    if (DateTime.TryParse(dr[i].ToString(), out value))
                    {
                        Response.Write(Convert.ToDateTime(dr[i].ToString()).ToString(CV.DefaultDateTimeFormat));
                    }
                    else
                        Response.Write(dr[i].ToString());


                }
                else
                {
                    Response.Write(dr[i].ToString());
                }

                Response.Write("</Td>");
            }

            Response.Write("</TR>");
        }

        Response.Write("</Table>");
        Response.Write("</font>");
        Response.Flush();
        Response.End();
    }

    protected void ExportToPDF(DataTable dt, String FileName)
    {
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Buffer = true;

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        for (int i = 0; i < dt.Columns.Count; i++)
        {
            string temp2 = dt.Columns[i].ColumnName.ToString();
            if(temp2.EndsWith("ID"))
            {
                dt.Columns.RemoveAt(i);
                dt.AcceptChanges();
            }
        }
        
        //Create a dummy GridView
        GridView GridView1 = new GridView();
        GridView1.AllowPaging = false;
        GridView1.DataSource = dt;
        GridView1.DataBind();


        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.LEGAL, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.Flush();
        Response.End();
    }



}