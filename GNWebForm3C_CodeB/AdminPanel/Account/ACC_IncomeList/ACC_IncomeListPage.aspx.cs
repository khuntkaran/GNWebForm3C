using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Account_ACC_IncomeList_ACC_IncomeListPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadHospitals();
        }
    }

    private void LoadHospitals()
    {
        // Call the stored procedure without parameters to get all hospitals
        DataTable dtHospitals = ExecuteProcedure(null, null);

        // Bind the hospital data to the repeater
        rptHospitals.DataSource = dtHospitals;
        rptHospitals.DataBind();
    }

    // Executes the stored procedure and returns the results
    private DataTable ExecuteProcedure(int? hospitalID, int? finYearID)
    {
        DataTable dtResults = new DataTable();

        using (SqlConnection conn = new SqlConnection("data source=KARAN\\SQLEXPRESS;initial catalog=GNForm3C; Integrated Security =True;TrustServerCertificate=True;"))
        {
            using (SqlCommand cmd = new SqlCommand("PR_ACC_IncomeList_SelectPage2", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameters for HospitalID and FinYearID
                if (hospitalID.HasValue)
                    cmd.Parameters.AddWithValue("@HospitalID", hospitalID);
                else
                    cmd.Parameters.AddWithValue("@HospitalID", DBNull.Value);

                if (finYearID.HasValue)
                    cmd.Parameters.AddWithValue("@FinYearID", finYearID);
                else
                    cmd.Parameters.AddWithValue("@FinYearID", DBNull.Value);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dtResults);
                }
            }
        }

        return dtResults;
    }

    protected void rptHospitals_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "LoadFinYears")
        {
            int hospitalID = Convert.ToInt32(e.CommandArgument);

            // Find the nested repeater for Financial Years
            Repeater rptFinYears = (Repeater)e.Item.FindControl("rptFinYears");

            // Fetch Financial Years for the selected HospitalID
            DataTable dtFinYears = ExecuteProcedure(hospitalID, null);

            // Bind the Financial Years data to the nested repeater
            rptFinYears.DataSource = dtFinYears;
            rptFinYears.DataBind();
        }
    }

    protected void rptFinYears_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "LoadIncomes")
        {
            int finYearID = Convert.ToInt32(e.CommandArgument);

            // Find the parent RepeaterItem of this financial year (to get HospitalID)
            RepeaterItem parentItem = (RepeaterItem)((Repeater)sender).NamingContainer;
            HiddenField hdnHospitalID = (HiddenField)parentItem.FindControl("hdnHospitalID");
            int hospitalID = Convert.ToInt32(hdnHospitalID.Value);

            // Find the nested repeater for Income
            Repeater rptIncomes = (Repeater)e.Item.FindControl("rptIncomes");

            // Fetch Incomes for the selected HospitalID and FinYearID
            DataTable dtIncomes = ExecuteProcedure(hospitalID, finYearID);

            // Bind the Income data to the nested repeater
            rptIncomes.DataSource = dtIncomes;
            rptIncomes.DataBind();
        }
    }
}
