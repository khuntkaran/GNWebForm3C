using GNForm3C.BAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Account_ACC_Chart_ACC_ChartIncomeExpenseByFinYearHospital : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindHospitalCharts();
        }
    }

    private void BindHospitalCharts()
    {
        ACC_ChartBAL aCC_ChartBAL = new ACC_ChartBAL();
        DataTable hospitals = aCC_ChartBAL.GetHospitalName(); // Method to get list of hospitals
        rptHospitalCharts.DataSource = hospitals;
        rptHospitalCharts.DataBind();
    }

    [WebMethod]
    public static string GetChartData(int hospitalID)
    {
        try
        {
            DataTable dataTable = new DataTable();
            ACC_ChartBAL chartBAL = new ACC_ChartBAL();
            dataTable = chartBAL.GetIncomeExpenseDataByHospital(hospitalID);

            var chartData = dataTable.AsEnumerable().Select(row => new
            {
                FinYearName = row.Field<string>("FinYearName"),
                TotalIncome = row.Field<decimal>("TotalIncome"),
                TotalExpense = row.Field<decimal>("TotalExpense")
            }).ToList();

            return JsonConvert.SerializeObject(chartData);
        }
        catch (Exception ex)
        {
            // Return error details as JSON
            return JsonConvert.SerializeObject(new { error = ex.Message });
        }
    }

}