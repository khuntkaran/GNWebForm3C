﻿using GNForm3C.BAL;
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
        ACC_IncomeListBAL aCC_IncomeListBAL = new ACC_IncomeListBAL();
        DataTable dtHospitals = aCC_IncomeListBAL.ExecuteProcedure(null, null);

        // Bind the hospital data to the repeater
        rptHospitals.DataSource = dtHospitals;
        rptHospitals.DataBind();
    }

    

    protected void rptHospitals_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "LoadFinYears")
        {
            int hospitalID = Convert.ToInt32(e.CommandArgument);

            // Find the nested repeater for Financial Years
            Repeater rptFinYears = (Repeater)e.Item.FindControl("rptFinYears");

            // Fetch Financial Years for the selected HospitalID
            ACC_IncomeListBAL aCC_IncomeListBAL = new ACC_IncomeListBAL();
            DataTable dtFinYears = aCC_IncomeListBAL.ExecuteProcedure(hospitalID, null);

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
            ACC_IncomeListBAL aCC_IncomeListBAL = new ACC_IncomeListBAL();
            DataTable dtIncomes = aCC_IncomeListBAL.ExecuteProcedure(hospitalID, finYearID);

            // Bind the Income data to the nested repeater
            rptIncomes.DataSource = dtIncomes;
            rptIncomes.DataBind();
        }
    }
}
