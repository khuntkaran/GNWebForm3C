using GNForm3C;
using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;

public partial class AdminPanel_Default : System.Web.UI.Page
{
    #region variable

        static Int32 PageRecordSize = CV.PageRecordSize;//Size of record per page

        #endregion variable

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

        #region 11.3 Total Count
        DEF_CountBAL balDEF_Count = new DEF_CountBAL();

        DataTable dtCount = balDEF_Count.SelectCount();

        lblIncomeCount.Text = dtCount.Rows[0]["IncomeCount"].ToString();
        lblExpenseCount.Text = dtCount.Rows[0]["ExpenseCount"].ToString();
        lblHospitalCount.Text = dtCount.Rows[0]["HospitalCount"].ToString();
        lblFinyearCount.Text = dtCount.Rows[0]["FinyearCount"].ToString();

        #endregion 11.3 Total Count

        #region 11.4 TOp 10 Income

        DataTable dtIncome = balDEF_Count.TOP10IncomeList();

        rpIncome.DataSource = dtIncome;
        rpIncome.DataBind();
        #endregion 11.4 TOp 10 Income

        #region 11.5 TOp 10 Expense

        DataTable dtExpense = balDEF_Count.TOP10ExpenseList();

        rpExpense.DataSource = dtExpense;
        rpExpense.DataBind();
        #endregion 11.5 TOp 10 Expense

        #region 11.6 TabView
        BindCol();
        #endregion 11.6 TabView

    }

    #endregion 11.0 Page Load Event

    #region 12.0 RepeterBind

    private void BindCol()
    {
        #region Parameters

        SqlInt32 ExpenseTypeID = SqlInt32.Null;
        SqlDecimal Amount = SqlDecimal.Null;
        SqlDateTime ExpenseDate = SqlDateTime.Null;
        SqlInt32 HospitalID = SqlInt32.Null;
        SqlInt32 FinYearID = SqlInt32.Null;
        Int32 TotalRecords = 0;
        Int32 Offset = (1 - 1) * PageRecordSize;
        SqlString TagName = SqlString.Null;
        
        #endregion Parameters

        ACC_ExpenseBAL balACC_Expense = new ACC_ExpenseBAL();

        DataTable dt = balACC_Expense.SelectPage(Offset, PageRecordSize, out TotalRecords, ExpenseTypeID, Amount, ExpenseDate, HospitalID, FinYearID,TagName);

        rpCol.DataSource = dt.DefaultView.ToTable(true, "Hospital", "HospitalID");
        rpCol.DataBind();

        rpActive.DataSource = dt.DefaultView.ToTable(true,"HospitalID");
        rpActive.DataBind();

        foreach(RepeaterItem rpAc in rpActive.Items)
        {
            Repeater rpData = (Repeater)rpAc.FindControl("rpData");
            HiddenField hfHospitalID = (HiddenField)rpAc.FindControl("hfHospitalID");

            SqlInt32 HospitalIDr = Convert.ToInt32(hfHospitalID.Value);

            DataTable dtr = balACC_Expense.SelectPage(Offset, PageRecordSize, out TotalRecords, ExpenseTypeID, Amount, ExpenseDate, HospitalIDr, FinYearID,TagName);

            rpData.DataSource = dtr;
            rpData.DataBind();
        }
    }

    #endregion 12.0 RepeterBind

}