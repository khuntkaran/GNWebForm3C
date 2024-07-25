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
public partial class AdminPanel_Master_MST_ReceiptType_MST_ReceiptTypeView: System.Web.UI.Page
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
				if (Request.QueryString["ReceiptTypeID"] != null)
				{
					FillControls();
				}
			}
		}
		
 #endregion  

		#region FillControls
		private void FillControls()
		{
			if (Request.QueryString["ReceiptTypeID"] != null) 
			{
				MST_ReceiptTypeBAL balMST_ReceiptType = new MST_ReceiptTypeBAL();
				DataTable dtMST_ReceiptType = balMST_ReceiptType.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["ReceiptTypeID"]));
				if (dtMST_ReceiptType != null)
				{
					foreach (DataRow dr in dtMST_ReceiptType.Rows)
					{

						if (!dr["ReceiptTypeName"].Equals(DBNull.Value))
							lblReceiptTypeName.Text = Convert.ToString(dr["ReceiptTypeName"]);

						if (!dr["PrintName"].Equals(DBNull.Value))
							lblPrintName.Text = Convert.ToString(dr["PrintName"]);

						if (!dr["IsDefault"].Equals(DBNull.Value))
							lblIsDefault.Text = Convert.ToString(dr["IsDefault"]);

						if (!dr["HospitalID"].Equals(DBNull.Value))
							lblHospitalID.Text = Convert.ToString(dr["Hospital"]);

						if (!dr["Remarks"].Equals(DBNull.Value))
							lblRemarks.Text = Convert.ToString(dr["Remarks"]);

						if (!dr["UserID"].Equals(DBNull.Value))
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
