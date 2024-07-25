using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
public partial class AdminPanel_Master_MST_Hospital_MST_HospitalView: System.Web.UI.Page
{
	#region Page Load Event 

	protected void Page_Load(object sender, EventArgs e)
	{
		#region 10.1 Check User Login 
         
		if (Session["UserID"] == null)
			Response.Redirect(CV.LoginPageURL);
			
 #endregion 10.1 Check User Login 

			if (!Page.IsPostBack)
			{
				if (Request.QueryString["HospitalID"] != null)
				{
					FillControls();
				}
			}
		}
		
 #endregion  

		#region FillControls
		private void FillControls()
		{
			if (Request.QueryString["HospitalID"] != null) 
			{
				MST_HospitalBAL balMST_Hospital = new MST_HospitalBAL();
				DataTable dtMST_Hospital = balMST_Hospital.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["HospitalID"]));
				if (dtMST_Hospital != null)
				{
					foreach (DataRow dr in dtMST_Hospital.Rows)
					{

						if (!dr["Hospital"].Equals(DBNull.Value))
							lblHospital.Text = Convert.ToString(dr["Hospital"]);

						if (!dr["PrintName"].Equals(DBNull.Value))
							lblPrintName.Text = Convert.ToString(dr["PrintName"]);

						if (!dr["PrintLine1"].Equals(DBNull.Value)) 
							lblPrintLine1.Text = Convert.ToString(dr["PrintLine1"]);

						if (!dr["PrintLine2"].Equals(DBNull.Value))
							lblPrintLine2.Text = Convert.ToString(dr["PrintLine2"]);

						if (!dr["PrintLine3"].Equals(DBNull.Value))
							lblPrintLine3.Text = Convert.ToString(dr["PrintLine3"]);

						if (!dr["FooterName"].Equals(DBNull.Value))
							lblFooterName.Text = Convert.ToString(dr["FooterName"]);

						if (!dr["ReportHeaderName"].Equals(DBNull.Value))
							lblReportHeaderName.Text = Convert.ToString(dr["ReportHeaderName"]);

						if (!dr["Remarks"].Equals(DBNull.Value))
							lblRemarks.Text = Convert.ToString(dr["Remarks"]);

						if (!dr["UserName"].Equals(DBNull.Value))
							lblUserID.Text = Convert.ToString(dr["UserName"]);

						if (!dr["Created"].Equals(DBNull.Value))
							lblCreated.Text = Convert.ToDateTime(dr["Created"]).ToString(CV.DefaultDateTimeFormat);

						if (!dr["Modified"].Equals(DBNull.Value))
							lblModified.Text = Convert.ToDateTime(dr["Modified"]).ToString(CV.DefaultDateTimeFormat);

					}
				}
			}
		}
		#endregion FillControls
	}
