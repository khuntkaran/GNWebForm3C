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

        #region 11.2 Set Help Text

        ucHelp.ShowHelp("Help Text will be shown here");

        #endregion 11.2 Set Help Text 

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["HospitalID"] != null)
            {
                btnShow_Click(sender, e);
            }
            #region 11.3 Fill Labels

            FillLabels(FormName);

            #endregion 11.3 Fill Labels

            #region 11.4 DropDown List Fill Section

            FillDropDownList();

            #endregion 11.4 DropDown List Fill Section

            #region 11.5 Set Control Default Value

            lblFormHeader.Text = " Master Dashboard";
            //upr.DisplayAfter = CV.UpdateProgressDisplayAfter;


            #endregion 11.5 Set Control Default Value
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
        Div_ShowResult.Visible = true;
        var months = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        MasterDashboardBAL balMasterDashboard_Count = new MasterDashboardBAL();

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
        

        DataTable dtCount = balMasterDashboard_Count.SelectCount(HospitalID);

        lblTotalIncome.Text = String.Format( GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint , Convert.ToDecimal( dtCount.Rows[0]["TotalIncome"].ToString()));
        lblTotalExpense.Text = String.Format(GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint, Convert.ToDecimal(dtCount.Rows[0]["TotalExpense"].ToString()));
        lblTotalPatientAmount.Text = String.Format(GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint, Convert.ToDecimal(dtCount.Rows[0]["TotalPatientAmount"].ToString()));


        #endregion 14.1 Total Count

        #region 14.2  Income List

        DataTable dtIncome = balMasterDashboard_Count.IncomeList(HospitalID);
        //gvIncomeData.DataSource = dtIncome;
        //gvIncomeData.DataBind;
        if (Convert.ToInt32(dtCount.Rows[0]["TotalIncome"]) > 0)
        {
            divIncomeList.Visible = true;
            lblIncomeContent.Visible = false;
            rpIncomeMonth.DataSource = months;
            rpIncomeMonth.DataBind();
            rpIncomeData.DataSource = dtIncome;
            rpIncomeData.DataBind();
            
        }
        else
        {
            lblIncomeContent.Text = "No any Income in this Year";
            lblIncomeContent.Style.Value = "color:red;";
            divIncomeList.Visible = false;
            lblIncomeContent.Visible = true;
        }



        #endregion 14.2 Income List

        #region 14.3 Expense List

        DataTable dtExpense = balMasterDashboard_Count.ExpenseList(HospitalID);
        if (Convert.ToInt32(dtCount.Rows[0]["TotalExpense"]) > 0)
        {
            divExpenseList.Visible = true;
            lblExpenseContent.Visible = false;
            rpExpenseMonth.DataSource = months;
            rpExpenseMonth.DataBind();
            rpExpenseData.DataSource = dtExpense;
            rpExpenseData.DataBind();
        }
        else
        {
            lblExpenseContent.Text = "No any Expense in this Year";
            lblExpenseContent.Style.Value = "color:red;";
            divExpenseList.Visible = false;
            lblExpenseContent.Visible = true;
        }
        #endregion 14.3 Expense List

        #region 14.4 TreatmentType Summary

        DataTable dtTreatmentType = balMasterDashboard_Count.TreatmentTypeList(HospitalID);
        if (Convert.ToInt32(dtCount.Rows[0]["TotalPatientAmount"]) > 0)
        {
            divTreatmentList.Visible = true;
            lblTreatmentContent.Visible = false;
            rpTreatmentTypeData.DataSource = dtTreatmentType;
            rpTreatmentTypeData.DataBind();
        }
        else
        {
            lblTreatmentContent.Text = "No any Treatment in this Year";
            lblTreatmentContent.Style.Value = "color:red;";
            divTreatmentList.Visible = false;
            lblTreatmentContent.Visible = true;
        }
       
        #endregion 14.4 TreatmentType Summary


    }

    #region 14.5 rpIncome_ItemDataBound
    protected void rpIncome_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        Repeater rpMonthValues = (Repeater)e.Item.FindControl("rpIncomeMonth2");

        var months = new[] {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        //Bind the month values to the inner repeater
        rpMonthValues.DataSource = months;
        rpMonthValues.DataBind();

    }
    #endregion 14.5 rpIncome_ItemDataBound

    #region 14.6 rpExpense_ItemDataBound
    protected void rpExpense_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        Repeater rpMonthValues = (Repeater)e.Item.FindControl("rpExpenseMonth2");

        var months = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        //Bind the month values to the inner repeater
        rpMonthValues.DataSource = months;
        rpMonthValues.DataBind();

    }
    #endregion 14.6 rpExpense_ItemDataBound

    #endregion 14.0 Show Button Event

    #region 15.0 IncomeCount_Click
    protected void IncomeCount_Click(object sender, EventArgs e)
    {
        Session["HospitalID"] = ddlHospitalID.SelectedValue;

        Response.Redirect("Account/ACC_Income/ACC_IncomeList.aspx");
    }
    #endregion 15.0 IncomeCount_Click

    #region 16.0 ExpenseCount_Click

    protected void ExpenseCount_Click(object sender, EventArgs e)
    {
        Session["HospitalID"] = ddlHospitalID.SelectedValue;

        Response.Redirect("Account/ACC_Expense/ACC_ExpenseList.aspx");
    }

    #endregion 16.0 ExpenseCount_Click

    #region 17.0 TransactionCount_Click
    protected void TransactionCount_Click(object sender, EventArgs e)
    {
        Session["HospitalID"] = ddlHospitalID.SelectedValue;

        Response.Redirect("Account/ACC_Transaction/ACC_TransactionList.aspx");
    }
    #endregion 17.0 TransactionCount_Click

    #region 18.0 PatientCount_Click
    protected void PatientCount_Click(object sender, EventArgs e)
    {
        Session["HospitalID"] = ddlHospitalID.SelectedValue;
        LinkButton clickedButton = (LinkButton)sender;
        Session["TreatmentID"] = clickedButton.CommandArgument;

        Response.Redirect("Account/ACC_Transaction/ACC_TransactionList.aspx");
    }
    #endregion 18.0 PatientCount_Click

}