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
public partial class AdminPanel_Config_CFG_ReportSetting_CFG_ReportSettingView: System.Web.UI.Page
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
				if (Request.QueryString["ReportSettingID"] != null)
				{
					FillControls();
				}
			}
		}
		
 #endregion  

		#region FillControls
		private void FillControls()
		{
			if (Request.QueryString["ReportSettingID"] != null) 
			{
				CFG_ReportSettingBAL balCFG_ReportSetting = new CFG_ReportSettingBAL();
				DataTable dtCFG_ReportSetting = balCFG_ReportSetting.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["ReportSettingID"]));
				if (dtCFG_ReportSetting != null)
				{
					foreach (DataRow dr in dtCFG_ReportSetting.Rows)
					{

						if (!dr["ReportHeaderFontType"].Equals(DBNull.Value))
							lblReportHeaderFontType.Text = Convert.ToString(dr["ReportHeaderFontType"]);

						if (!dr["ReportHeaderFontSize"].Equals(DBNull.Value))
							lblReportHeaderFontSize.Text = Convert.ToString(dr["ReportHeaderFontSize"]);

						if (!dr["ReportHeaderFontStyle"].Equals(DBNull.Value))
							lblReportHeaderFontStyle.Text = Convert.ToString(dr["ReportHeaderFontStyle"]);

						if (!dr["TableHeaderFontType"].Equals(DBNull.Value))
							lblTableHeaderFontType.Text = Convert.ToString(dr["TableHeaderFontType"]);

						if (!dr["TableHeaderFontSize"].Equals(DBNull.Value))
							lblTableHeaderFontSize.Text = Convert.ToString(dr["TableHeaderFontSize"]);

						if (!dr["TableHeaderFontStyle"].Equals(DBNull.Value))
							lblTableHeaderFontStyle.Text = Convert.ToString(dr["TableHeaderFontStyle"]);

						if (!dr["TableRowFontType"].Equals(DBNull.Value))
							lblTableRowFontType.Text = Convert.ToString(dr["TableRowFontType"]);

						if (!dr["TableRowFontSize"].Equals(DBNull.Value))
							lblTableRowFontSize.Text = Convert.ToString(dr["TableRowFontSize"]);

						if (!dr["TableRowFontStyle"].Equals(DBNull.Value))
							lblTableRowFontStyle.Text = Convert.ToString(dr["TableRowFontStyle"]);

						if (!dr["FooterFontType"].Equals(DBNull.Value))
							lblFooterFontType.Text = Convert.ToString(dr["FooterFontType"]);

						if (!dr["FooterFontSize"].Equals(DBNull.Value))
							lblFooterFontSize.Text = Convert.ToString(dr["FooterFontSize"]);

						if (!dr["FooterFontStyle"].Equals(DBNull.Value))
							lblFooterFontStyle.Text = Convert.ToString(dr["FooterFontStyle"]);

						if (!dr["IsPrintDate"].Equals(DBNull.Value))
							lblIsPrintDate.Text = Convert.ToString(dr["IsPrintDate"]);

						if (!dr["IsPrintDateWithTime"].Equals(DBNull.Value))
							lblIsPrintDateWithTime.Text = Convert.ToString(dr["IsPrintDateWithTime"]);

						if (!dr["IsPrintUserName"].Equals(DBNull.Value))
							lblIsPrintUserName.Text = Convert.ToString(dr["IsPrintUserName"]);

						if (!dr["HospitalID"].Equals(DBNull.Value))
							lblHospitalID.Text = Convert.ToString(dr["HospitalID"]);

						if (!dr["Remarks"].Equals(DBNull.Value))
							lblRemarks.Text = Convert.ToString(dr["Remarks"]);

						if (!dr["UserID"].Equals(DBNull.Value))
							lblUserID.Text = Convert.ToString(dr["UserID"]);

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
