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
public partial class AdminPanel_Account_ACC_Transaction_ACC_TransactionView: System.Web.UI.Page
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
				if (Request.QueryString["TransactionID"] != null)
				{
					FillControls();
				}
			}
		}
		
 #endregion  

		#region FillControls
		private void FillControls()
		{
			if (Request.QueryString["TransactionID"] != null) 
			{
				ACC_TransactionBAL balACC_Transaction = new ACC_TransactionBAL();
				DataTable dtACC_Transaction = balACC_Transaction.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["TransactionID"]));
				if (dtACC_Transaction != null)
				{
					foreach (DataRow dr in dtACC_Transaction.Rows)
					{

						if (!dr["Patient"].Equals(DBNull.Value))
							lblPatient.Text = Convert.ToString(dr["Patient"]);

						if (!dr["TreatmentID"].Equals(DBNull.Value))
							lblTreatmentID.Text = Convert.ToString(dr["TreatmentID"]);

						if (!dr["Amount"].Equals(DBNull.Value))
							lblAmount.Text = Convert.ToString(dr["Amount"]);

						if (!dr["SerialNo"].Equals(DBNull.Value))
							lblSerialNo.Text = Convert.ToString(dr["SerialNo"]);

						if (!dr["ReferenceDoctor"].Equals(DBNull.Value))
							lblReferenceDoctor.Text = Convert.ToString(dr["ReferenceDoctor"]);

						if (!dr["Count"].Equals(DBNull.Value))
							lblCount.Text = Convert.ToString(dr["Count"]);

						if (!dr["ReceiptNo"].Equals(DBNull.Value))
							lblReceiptNo.Text = Convert.ToString(dr["ReceiptNo"]);

						if (!dr["Date"].Equals(DBNull.Value))
							lblDate.Text = Convert.ToDateTime(dr["Date"]).ToString(CV.DefaultDateTimeFormat);

						if (!dr["DateOfAdmission"].Equals(DBNull.Value))
							lblDateOfAdmission.Text = Convert.ToDateTime(dr["DateOfAdmission"]).ToString(CV.DefaultDateTimeFormat);

						if (!dr["DateOfDischarge"].Equals(DBNull.Value))
							lblDateOfDischarge.Text = Convert.ToDateTime(dr["DateOfDischarge"]).ToString(CV.DefaultDateTimeFormat);

						if (!dr["Deposite"].Equals(DBNull.Value))
							lblDeposite.Text = Convert.ToString(dr["Deposite"]);

						if (!dr["NetAmount"].Equals(DBNull.Value))
							lblNetAmount.Text = Convert.ToString(dr["NetAmount"]);

						if (!dr["NoOfDays"].Equals(DBNull.Value))
							lblNoOfDays.Text = Convert.ToString(dr["NoOfDays"]);

						if (!dr["Remarks"].Equals(DBNull.Value))
							lblRemarks.Text = Convert.ToString(dr["Remarks"]);

						if (!dr["HospitalID"].Equals(DBNull.Value))
							lblHospitalID.Text = Convert.ToString(dr["HospitalID"]);

						if (!dr["FinYearID"].Equals(DBNull.Value))
							lblFinYearID.Text = Convert.ToString(dr["FinYearID"]);

						if (!dr["ReceiptTypeID"].Equals(DBNull.Value))
							lblReceiptTypeID.Text = Convert.ToString(dr["ReceiptTypeID"]);

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
