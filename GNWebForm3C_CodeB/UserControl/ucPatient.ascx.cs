using GNForm3C.BAL;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_ucPatient : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void ShowPatient(SqlInt32 PatientID)
    {
        MST_PatientBAL balMST_Patient = new MST_PatientBAL();
        System.Data.DataTable dtPatient = balMST_Patient.SelectView(PatientID);

        if (dtPatient != null)
        {
            foreach (DataRow dr in dtPatient.Rows)
            {

                if (!dr["PatientName"].Equals(DBNull.Value))
                {
                    lblucPatientName.Text = Convert.ToString(dr["PatientName"]);
                    lblucTitle.Text = Convert.ToString(dr["PatientName"]);

                }

                if (!dr["Age"].Equals(DBNull.Value))
                    lblucPatietAge.Text = Convert.ToString(dr["Age"]);

                if (!dr["DOB"].Equals(DBNull.Value))
                    lblucDOB.Text = Convert.ToDateTime(dr["DOB"]).ToString(CV.DefaultDateTimeFormat);

                if (!dr["MobileNo"].Equals(DBNull.Value))
                    lblucMobileNo.Text = Convert.ToString(dr["MobileNo"]);

                if (!dr["PrimaryDesc"].Equals(DBNull.Value))
                    lblucPrimaryDesc.Text = Convert.ToString(dr["PrimaryDesc"]);
            }
        }

        mvwPatient.SetActiveView(vwPatient);
        mvwPatient.Visible = true;
    }
}