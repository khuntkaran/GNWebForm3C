using GNForm3C.BAL;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class AdminPanel_Dashboard3 : System.Web.UI.Page
{
    #region 10.0 Local Variables

    static Int32 PageRecordSize = CV.PageRecordSize;//Size of record per page   

    #endregion 10.0 Local Variables

    #region 11.0 Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.0 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.0 Check User Login

        if (!Page.IsPostBack)
        {
            #region 11.1 DropDown List Fill Section

            //FillDropDownList();

            #endregion 11.1 DropDown List Fill Section

            #region 11.2 Set Default Value  

            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;

            #endregion 11.2 Set Default Value 


            #region 11.3 Set Help Text
            ucHelp.ShowHelp("Help Text will be shown here");
            #endregion 12.3 Set Help Text

            BindData();
        }
    }


    #endregion 11.0 Page Load Event 

    #region 12.0 Search
    protected void BindData()
    {
        MST_FinYearBAL balMST_FinYearBAL = new MST_FinYearBAL();
        DataTable dtFinYear = balMST_FinYearBAL.SelectComboBox();

        rpFinYear.DataSource = dtFinYear;
        rpFinYear.DataBind();


        foreach (RepeaterItem rpAc in rpFinYear.Items)
        {
            SqlInt32 FinYearID = SqlInt32.Null;
            HiddenField hfFinYearID = (HiddenField)rpAc.FindControl("hdFinyearID");

            if (hfFinYearID != null)
            {
                FinYearID = Convert.ToInt32(hfFinYearID.Value);
            }
            Repeater rpitemCategoryWiseIncomeTotalList = (Repeater)rpAc.FindControl("rpCategoryWiseIncomeTotalList");
            Repeater rpitemCategoryWiseExpenseTotalList = (Repeater)rpAc.FindControl("rpCategoryWiseExpenseTotalList");
            Repeater rpitemHospitalWisePatientCountList = (Repeater)rpAc.FindControl("rpHospitalWisePatientCountList");
            Repeater rpitemAccountTranscationList = (Repeater)rpAc.FindControl("rpAccountTranscationList");

            BindCategoryWiseIncomeTotalList(rpitemCategoryWiseIncomeTotalList, FinYearID);
            BindCategoryWiseExpenseTotalList(rpitemCategoryWiseExpenseTotalList, FinYearID);
            BindHospitalWisePatientCountList(rpitemHospitalWisePatientCountList, FinYearID);
            BindAccountTranscationList(rpitemAccountTranscationList, FinYearID);


            Label lIncomeCount = (Label)rpAc.FindControl("lblIncomeCount");
            Label lExpenseCount = (Label)rpAc.FindControl("lblExpenseCount");
            Label lDifferenceCount = (Label)rpAc.FindControl("lblDifferenceCount");

            MST_DSB2BAL balMST_DSB2BAL = new MST_DSB2BAL();
            DataTable dtCount = balMST_DSB2BAL.SelectCount(FinYearID);

            lIncomeCount.Text = string.Format(GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint, Convert.ToDecimal(dtCount.Rows[0]["IncomeCount"].ToString()));
            lExpenseCount.Text = string.Format(GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint, Convert.ToDecimal(dtCount.Rows[0]["ExpenseCount"].ToString()));
            lDifferenceCount.Text = string.Format(GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint, Convert.ToDecimal(dtCount.Rows[0]["DifferenceCount"].ToString()));


        }

    }
    protected void displayChange(object sender, EventArgs e)
    {

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {



    }
    #endregion 12.0 Search

    #region 13.0 BindTable

    #region 13.1 BindCategoryWiseIncomeTotalList
    private void BindCategoryWiseIncomeTotalList(Repeater rp, SqlInt32 FinYearID)
    {
        MST_DSB2BAL balMST_DSB2BAL = new MST_DSB2BAL();

        DataTable dtCategoryWiseIncomeTotalList = balMST_DSB2BAL.CategoryWiseIncomeTotalList(FinYearID);
        var upList = rp.FindControl("CategoryWiseIncomeTotalList") as HtmlTable;
        Label label = (Label)rp.FindControl("lblNoCategoryWiseIncomeTotalListRecords");

        if (dtCategoryWiseIncomeTotalList.Rows.Count > 0)
        {
            rp.DataSource = dtCategoryWiseIncomeTotalList;
            rp.DataBind();

            //label.Visible = false;
            //upList.Visible = true;
        }
        else
        {
            //upList.Visible = false;
            //label.Visible = true;
        }


    }

    #endregion 13.1 BindCategoryWiseIncomeTotalList
    #region 13.2 BindExpense

    private void BindCategoryWiseExpenseTotalList(Repeater rp, SqlInt32 FinYearID)
    {

        MST_DSB2BAL balMST_DSB2BAL = new MST_DSB2BAL();

        DataTable dtCategoryWiseExpenseTotalList = balMST_DSB2BAL.CategoryWiseExpenseTotalList(FinYearID);
        var upList = rp.FindControl("CategoryWiseExpenseTotalList") as HtmlTable;
        var label = rp.FindControl("lblNoCategoryWiseExpenseTotalListRecords") as Label;
        if (dtCategoryWiseExpenseTotalList.Rows.Count > 0)
        {
            rp.DataSource = dtCategoryWiseExpenseTotalList;
            rp.DataBind();

            //label.Visible = false;
            //upList.Visible = true;
        }
        else
        {

            //upList.Visible = false;
            //label.Visible = true;
        }


    }
    #endregion 13.2 BindExpense

    #region 13.3 BindHospitalWisePatientCountList
    private void BindHospitalWisePatientCountList(Repeater rp, SqlInt32 FinYearID)
    {

        MST_DSB2BAL balMST_DSB2BAL = new MST_DSB2BAL();

        DataTable dtHospitalWisePatientCountList = balMST_DSB2BAL.HospitalWisePatientCountList(FinYearID);
        var upList = rp.FindControl("HospitalWisePatientCountList") as HtmlTable;
        var label = rp.FindControl("lblNoHospitalWisePatientCountListRecords") as Label;
        if (dtHospitalWisePatientCountList.Rows.Count > 0)
        {
            rp.DataSource = dtHospitalWisePatientCountList;
            rp.DataBind();

            //label.Visible = false;
            //upList.Visible = true;
        }
        else
        {
            //upList.Visible = false;
            //label.Visible = true;
        }


    }
    #endregion 13.3 BindHospitalWisePatientCountList
    #region 13.4 BindAccountTranscationList

    private void BindAccountTranscationList(Repeater rp, SqlInt32 FinYearID)
    {

        MST_DSB2BAL balMST_DSB2BAL = new MST_DSB2BAL();

        DataTable dtAccountTranscationList = balMST_DSB2BAL.AccountTranscationList(FinYearID);
        var upList = rp.FindControl("AccountTranscationList") as HtmlTable;
        var label = rp.FindControl("lblNoAccountTranscationListRecords") as Label;
        if (dtAccountTranscationList.Rows.Count > 0)
        {
            rp.DataSource = dtAccountTranscationList;
            rp.DataBind();

            //label.Visible = false;
            //upList.Visible = true;
        }
        else
        {
            //upList.Visible = false;
            //label.Visible = true;
        }


    }


    #endregion 13.4 BindAccountTranscationList

    #endregion BindTable

    #region 14.0 DropDownList

    #region 14.1 Fill DropDownList
    private void FillDropDownList()
    {
    }
    #endregion 14.1 Fill DropDownList

    #endregion 14.0 DropDownList

    public void rpData_OnItemDataBound(object sender, EventArgs e)
    {
        SqlInt32 FinYearID = SqlInt32.Null;


    }
}