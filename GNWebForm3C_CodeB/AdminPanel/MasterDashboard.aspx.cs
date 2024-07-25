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

public partial class AdminPanel_MasterDashboard : System.Web.UI.Page
{
    #region 10.0 Local Variables

    String FormName = "MasterDashboard";

    #endregion 10.0 Variables

    #region 11.0 Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["HospitalID"] != null)
            {
                btnShow_Click(sender, e);
            }
            #region 11.2 Fill Labels

            FillLabels(FormName);

            #endregion 11.2 Fill Labels

            #region 11.3 DropDown List Fill Section

            FillDropDownList();

            #endregion 11.3 DropDown List Fill Section

            #region 11.4 Set Control Default Value

            lblFormHeader.Text = " Master Dashboard";
            //upr.DisplayAfter = CV.UpdateProgressDisplayAfter;


            #endregion 11.4 Set Control Default Value
        }
    }
    #endregion Pageload

    #region 12.0 FillLabels
    private void FillLabels(String FormName)
    {
    }

    #endregion 12.0 FillLabels

    #region 13.0 Fill DropDownList
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 Show Button Event
    protected void btnShow_Click(object sender, EventArgs e)
    {
        SqlInt32 HospitalID = SqlInt32.Null;

        #region NavigateLogic
        if (Request.QueryString["HospitalID"] != null)
        {
            if (!Page.IsPostBack)
            {
                HospitalID = CommonFunctions.DecryptBase64Int32(Request.QueryString["HospitalID"]);
            }
            else
            {
                if (ddlHospitalID.SelectedIndex > 0)
                    HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
            }
        }
        else
        {
            if (ddlHospitalID.SelectedIndex > 0)
                HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
        }
        #endregion NavigateLogic

        #region 14.1 Total Count
        MasterDashboardBAL balMasterDashboard_Count = new MasterDashboardBAL();

        DataTable dtCount = balMasterDashboard_Count.SelectCount(HospitalID);

        lblTotalIncome.Text = dtCount.Rows[0]["TotalIncome"].ToString();
        lblTotalExpense.Text = dtCount.Rows[0]["TotalExpense"].ToString();
        lblTotalPatientAmount.Text = dtCount.Rows[0]["TotalPatientAmount"].ToString();
        Div_ShowResult.Visible = true;

        #endregion 14.1 Total Count

        #region 14.2  Income List

        DataTable dtIncome = balMasterDashboard_Count.IncomeList(HospitalID);
        //gvIncomeData.DataSource = dtIncome;
        //gvIncomeData.DataBind;
        var months = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        rpIncomeMonth.DataSource = months;
        rpIncomeMonth.DataBind();
        rpIncomeData.DataSource = dtIncome;
        rpIncomeData.DataBind();


        #endregion 14.2 Income List

        #region 14.3 Expense List

        DataTable dtExpense = balMasterDashboard_Count.ExpenseList(HospitalID);
        rpExpenseMonth.DataSource = months;
        rpExpenseMonth.DataBind();
        rpExpenseData.DataSource = dtExpense;
        rpExpenseData.DataBind();
        #endregion 14.3 Expense List

        #region 14.4 TreatmentType Summary

        DataTable dtTreatmentType = balMasterDashboard_Count.TreatmentTypeList(HospitalID);
        rpTreatmentTypeData.DataSource = dtTreatmentType;
        rpTreatmentTypeData.DataBind();
        #endregion 14.4 TreatmentType Summary


    }

    //protected void rpIncome_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{

    //    Repeater rpMonthValues = (Repeater)e.Item.FindControl("rpMonthValues");

    //    var months = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    //    // Bind the month values to the inner repeater
    //    rpMonthValues.DataSource = months;
    //    rpMonthValues.DataBind();

    //}
    #endregion 14.0 Show Button Event


}