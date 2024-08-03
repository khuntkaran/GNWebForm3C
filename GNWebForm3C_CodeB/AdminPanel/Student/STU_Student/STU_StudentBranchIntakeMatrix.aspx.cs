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
        DataTable dt = balSTU_Student.SelecBranchIntakeMatrix();


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

        Repeater rpAddmissionYearBody = (Repeater)e.Item.FindControl("rpAddmissionYearBody");

        STU_StudentBAL balSTU_Student = new STU_StudentBAL();
        DataTable dt = balSTU_Student.SelecBranchIntakeMatrix();


        List<String> column = CommonFunctions.ColumnOfDataTable(dt);

        rpAddmissionYearBody.DataSource = column.GetRange(1, column.Count - 1); ;
        rpAddmissionYearBody.DataBind();




    }
    #endregion 15.3 rpIntake_ItemDataBound

    #region 15.4 rpAddmissionYearBody_ItemDataBound

    protected void rpAddmissionYearBody_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
             
            RepeaterItem parentItem = (RepeaterItem)e.Item.Parent.Parent;
            var branchData = (DataRowView)parentItem.DataItem;
            string branch = branchData["Branch"].ToString();
            string columnName = e.Item.DataItem.ToString(); 

            TextBox txtBox = e.Item.FindControl("TextBoxTemplate") as TextBox;
            if (txtBox != null)
            {
                txtBox.ID = "txt" + branch + columnName;
                TextBoxID.Add("txt" + branch + columnName);
                txtBox.Text = branchData[columnName].ToString();
            }
        }

        // Save TextBoxID to ViewState
        ViewState["TextBoxID"] = TextBoxID;
    }

    #endregion 15.4 rpAddmissionYearBody_ItemDataBound

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
                STU_StudentBranchIntakeMatrixENT entSTU_StudentBranchIntakeMatrix = new STU_StudentBranchIntakeMatrixENT();



                //Repeater rpAddmissionYearBody = (Repeater)e.FindControl("rpAddmissionYearBody");
                foreach (RepeaterItem outerItem in rpIntakeData.Items)
                {
                    if (outerItem.ItemType == ListItemType.Item || outerItem.ItemType == ListItemType.AlternatingItem)
                    {
                        var branchData = outerItem.DataItem as DataRowView;
                        if (branchData != null)
                        {
                            string branch = branchData["Branch"].ToString();
                            Repeater innerRepeater = (Repeater)outerItem.FindControl("rpAddmissionYearBody");

                            if (innerRepeater != null)
                            {
                                foreach (RepeaterItem innerItem in innerRepeater.Items)
                                {
                                    if (innerItem.ItemType == ListItemType.Item || innerItem.ItemType == ListItemType.AlternatingItem)
                                    {
                                        TextBox txtBox = (TextBox)innerItem.FindControl("TextBoxTemplate");
                                        if (txtBox != null)
                                        {
                                            string intakeValue = txtBox.Text;
                                            // Process the intakeValue (e.g., save to database)
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // Log or handle case where innerRepeater is null
                                Console.WriteLine("Inner Repeater not found for branch: " + branch);
                            }
                        }
                        else
                        {
                            // Log or handle case where branchData is null
                            Console.WriteLine("Branch data is null for an item in the outer repeater.");
                        }
                    }
                }
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
        List<TextBox> allTextBoxes = FindAllTextBoxes(Page);
        foreach (TextBox textboxid in allTextBoxes)
        {
            
            int num = 5; // your count goes here
            TextBox tb = new TextBox();
            //tb = FindControlRecursive(Page, textboxid) as TextBox;

            string value = textboxid.Text; //You have the data now


        }
    }

    private List<TextBox> FindAllTextBoxes(Control root)
    {
        List<TextBox> textBoxes = new List<TextBox>();

        foreach (Control control in root.Controls)
        {
            if (control is TextBox)
            {
                textBoxes.Add((TextBox)control);
            }
            else if (control.HasControls())
            {
                textBoxes.AddRange(FindAllTextBoxes(control));
            }
        }

        return textBoxes;
    }




    #endregion 18.0 Clear Controls 

}