using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using System.Web.UI.HtmlControls;
using System.Data;

public partial class AdminPanel_Student_STU_Student_STU_StudentBranchIntakeMatrix : System.Web.UI.Page
{
    #region 11.0 Variables

    String FormName = "Branch Intake Matrix";
    List<String> TextBoxID = new List<string>();


    #endregion 11.0 Variables

    #region 12.0 Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 12.0 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 12.0 Check User Login

        if (!Page.IsPostBack)
        {
            #region 12.1 DropDown List Fill Section

            FillDropDownList();

            #endregion 12.1 DropDown List Fill Section

            #region 12.2 Set Default Value


            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;

            #endregion 12.2 Set Default Value
            Search(1);

            #region 12.3 Set Help Text
            ucHelp.ShowHelp("Help Text will be shown here");
            #endregion 12.3 Set Help Text

            #region 12.4 Fill Labels

            FillLabels(FormName);

            #endregion 12.4 Fill Labels


        }
        else
        {
            if (ViewState["TextBoxID"] != null)
            {
                TextBoxID = (List<string>)ViewState["TextBoxID"];
            }
        }
    }

    #endregion 12.0 Page Load Event

    #region 13.0 FillLabels

    private void FillLabels(String FormName)
    {
        lblFormHeader.Text = FormName;
    }

    #endregion

    #region 14.0 DropDownList

    #region 14.1 Fill DropDownList

    private void FillDropDownList()
    {

    }

    #endregion 14.1 Fill DropDownList

    #endregion 14.0 DropDownList

    #region 15.0 Search

    #region 15.1 Button Search Click Event

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search(1);
    }

    #endregion 15.1 Button Search Click Event

    #region 15.2 Search Function

    private void Search(int PageNo)
    {

        STU_StudentBAL balSTU_Student = new STU_StudentBAL();
        DataTable dt = balSTU_Student.SelectBranchIntakeMatrix();


        if (dt != null && dt.Rows.Count > 0)
        {

            rpAddmissionYearHead.DataSource = CommonFunctions.ColumnOfDataTable(dt);
            rpAddmissionYearHead.DataBind();
            rpIntakeData.DataSource = dt;
            rpIntakeData.DataBind();

        }
        else
        {

            ucMessage.ShowError(CommonMessage.NoRecordFound());
        }
    }

    #endregion 15.2 Search Function


    #region 15.3 rpIntake_ItemDataBound
    protected void rpIntake_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rpAddmissionYearBody = (Repeater)e.Item.FindControl("rpAddmissionYearBody");
            DataRowView drv = (DataRowView)e.Item.DataItem;

            if (rpAddmissionYearBody != null && drv != null)
            {
                // Retrieve column names excluding the "Branch" column
                DataTable dt = drv.DataView.Table;
                List<string> yearColumns = CommonFunctions.ColumnOfDataTable(dt).GetRange(1, dt.Columns.Count - 1);

                // Create a data source with year and intake pairs for binding
                List<YearIntakePair> yearIntakePairs = new List<YearIntakePair>();
                foreach (string year in yearColumns)
                {
                    yearIntakePairs.Add(new YearIntakePair
                    {
                        Year = year,
                        Intake = drv[year].ToString()
                    });
                }

                rpAddmissionYearBody.DataSource = yearIntakePairs;
                rpAddmissionYearBody.DataBind();
            }
        }
    }

    // Helper class to store year and intake pairs
    public class YearIntakePair
    {
        public string Year { get; set; }
        public string Intake { get; set; }
    }


    protected string BindIntakeData(string year, object dataItem)
    {
        DataRowView rowView = dataItem as DataRowView;
        if (rowView != null && rowView.Row.Table.Columns.Contains(year))
        {
            return rowView[year].ToString();
        }
        return string.Empty;
    }

    #endregion 15.3 rpIntake_ItemDataBound



    #endregion 15.0 Search

    #region 16.0 Save Button Event 

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                STU_StudentBAL balSTU_Student = new STU_StudentBAL();
                DataTable branchIntakeTable = new DataTable();
                branchIntakeTable.Columns.Add("Branch", typeof(string));
                branchIntakeTable.Columns.Add("AdmissionYear", typeof(string));
                branchIntakeTable.Columns.Add("Intake", typeof(int));



                foreach (RepeaterItem item in rpIntakeData.Items)
                {
                    Label lblBranch = (Label)item.FindControl("lblBranch");

                    if (lblBranch != null)
                    {
                        Repeater rpAddmissionYearBody = (Repeater)item.FindControl("rpAddmissionYearBody");

                        if (rpAddmissionYearBody != null)
                        {
                            foreach (RepeaterItem yearItem in rpAddmissionYearBody.Items)
                            {
                                TextBox txtIntake = (TextBox)yearItem.FindControl("txtIntake");
                                Label lblYear = (Label)yearItem.FindControl("lblYear");

                                if (txtIntake != null && lblYear != null)
                                {
                                    int intake;
                                    int year;

                                    if (int.TryParse(txtIntake.Text, out intake) && int.TryParse(lblYear.Text, out year))
                                    {
                                        branchIntakeTable.Rows.Add(lblBranch.Text, year, intake);
                                    }
                                }
                            }


                        }
                    }
                }
                balSTU_Student.UpdateBranchIntakeMatrix(branchIntakeTable);

                // Refresh the data
                Search(1);

            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message);
            }
        }
    }

    #endregion 16.0 Save Button Event 

    #region 17.0 Cancel Button Event

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearControls();
    }


    #endregion 17.0 Cancel Button Event

    #region 18.0 Clear Controls 

    private void ClearControls()
    {

        foreach (RepeaterItem item in rpIntakeData.Items)
        {

            Repeater rpAddmissionYearBody = (Repeater)item.FindControl("rpAddmissionYearBody");

            if (rpAddmissionYearBody != null)
            {
                foreach (RepeaterItem yearItem in rpAddmissionYearBody.Items)
                {
                    TextBox txtIntake = (TextBox)yearItem.FindControl("txtIntake");
                    if (txtIntake != null)
                    {
                        txtIntake.Text = string.Empty;
                    }
                    

                }
            }
        }
    }



    #endregion 18.0 Clear Controls 

}