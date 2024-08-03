using GNForm3C.BAL;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNForm3C.ENT;
using System.Web.UI.WebControls.WebParts;

public partial class AdminPanel_Student_STU_Student_STU_StudentAddEditPopUp : System.Web.UI.Page
{

    #region 10.0 Local Variables 

    String FormName = "STU_StudentAddEdit";

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
            #region 11.2 Fill Labels 

            FillLabels(FormName);

            #endregion 11.2 Fill Labels 

            #region 11.3 DropDown List Fill Section 

            FillDropDownList();

            #endregion 11.3 DropDown List Fill Section 

            #region 11.4 Set Control Default Value 

            lblFormHeader.Text = CV.PageHeaderAdd + " Student";
            txtStudentName.Focus();

            #endregion 11.4 Set Control Default Value 

            #region 11.5 Fill Controls 

            FillControls();

            #endregion 11.5 Fill Controls 

            

        }
    }

    #endregion 11.0 Page Load Event

    #region 12.0 FillLabels 

    private void FillLabels(String FormName)
    {
    }

    #endregion 12.0 FillLabels 

    #region 13.0 Fill DropDownList 

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListSemester(ddlCurrentSem);
        CommonFillMethods.FillDropDownListGender(ddlGender);
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 FillControls By PK  

    private void FillControls()
    {
        if (Request.QueryString["StudentID"] != null)
        {
            lblFormHeader.Text = CV.PageHeaderEdit + " Student";
            STU_StudentBAL balSTU_Student = new STU_StudentBAL();
            STU_StudentENT entSTU_STudent = new STU_StudentENT();
            entSTU_STudent = balSTU_Student.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["StudentID"]));

            if (!entSTU_STudent.StudentName.IsNull)
                txtStudentName.Text = entSTU_STudent.StudentName.Value.ToString();

            if (!entSTU_STudent.EnrollmentNo.IsNull)
                txtEnrollmentNo.Text = entSTU_STudent.EnrollmentNo.Value.ToString();

            if (!entSTU_STudent.CurrentSem.IsNull)
                ddlCurrentSem.SelectedValue = entSTU_STudent.CurrentSem.Value.ToString();

            if (!entSTU_STudent.EmailInstitute.IsNull)
                txtEmailInstitute.Text = entSTU_STudent.EmailInstitute.Value.ToString();

            if (!entSTU_STudent.EmailPersonal.IsNull)
                txtEmailPersonal.Text = entSTU_STudent.EmailPersonal.Value.ToString();

            if (!entSTU_STudent.Gender.IsNull)
                ddlGender.SelectedValue = entSTU_STudent.Gender.Value.ToString();

            if (!entSTU_STudent.RollNo.IsNull)
                txtRollNo.Text = entSTU_STudent.RollNo.Value.ToString();

            if (!entSTU_STudent.BirthDate.IsNull)
                dtpBirthDate.Text = entSTU_STudent.BirthDate.Value.ToString(CV.DefaultDateFormat);

            if (!entSTU_STudent.ContactNo.IsNull)
                txtContactNo.Text = entSTU_STudent.ContactNo.Value.ToString();
        }
    }

    #endregion 14.0 FillControls By PK 

    #region 15.0 Save Button Event 

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                STU_StudentBAL balSTU_Student = new STU_StudentBAL();
                STU_StudentENT entSTU_STudent = new STU_StudentENT();

                #region 15.1 Validate Fields 

                String ErrorMsg = String.Empty;
                if (txtStudentName.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Student Name");
                if (txtEnrollmentNo.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Enrollment No");
                if (ddlCurrentSem.SelectedIndex == 0)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Current Sem");
                if (txtEmailPersonal.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Email Personal");
                if (ddlGender.SelectedIndex == 0)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Gender");
                if (txtContactNo.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Contact No");
                if (dtpBirthDate.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Birth Date");


                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
                    ucMessage.ShowError(ErrorMsg);

                    // Set the data-target attribute dynamically
                    btnSave.Attributes["data-target"] = "#view";
                    btnSave.Attributes["data-toggle"] = "modal";

                    // Use JavaScript to show the modal again
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "MasterPageView", "$('#view').modal('show');", true);

                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data 


                if (txtStudentName.Text.Trim() != String.Empty)
                    entSTU_STudent.StudentName = txtStudentName.Text.Trim();
                if (txtEnrollmentNo.Text.Trim() != String.Empty)
                    entSTU_STudent.EnrollmentNo = txtEnrollmentNo.Text.Trim();
                if (ddlCurrentSem.SelectedIndex > 0)
                    entSTU_STudent.CurrentSem = Convert.ToInt32(ddlCurrentSem.SelectedValue);

                if (txtEmailInstitute.Text.Trim() != String.Empty)
                    entSTU_STudent.EmailInstitute = txtEmailInstitute.Text.Trim();
                if (txtEmailPersonal.Text.Trim() != String.Empty)
                    entSTU_STudent.EmailPersonal = txtEmailPersonal.Text.Trim();
                if (ddlGender.SelectedIndex > 0)
                    entSTU_STudent.Gender = ddlGender.SelectedValue.Trim();

                if (dtpBirthDate.Text.Trim() != String.Empty)
                    entSTU_STudent.BirthDate = Convert.ToDateTime(dtpBirthDate.Text.Trim());
                if (txtRollNo.Text.Trim() != String.Empty)
                    entSTU_STudent.RollNo = Convert.ToInt32(txtRollNo.Text.Trim());
                if (txtContactNo.Text.Trim() != String.Empty)
                    entSTU_STudent.ContactNo = txtContactNo.Text.Trim();



                entSTU_STudent.UserID = Convert.ToInt32(Session["UserID"]);

                entSTU_STudent.Created = DateTime.Now;

                entSTU_STudent.Modified = DateTime.Now;


                #endregion 15.2 Gather Data 


                #region 15.3 Insert,Update,Copy 

                if (Request.QueryString["StudentID"] != null && Request.QueryString["Copy"] == null)
                {
                    entSTU_STudent.StudentID = CommonFunctions.DecryptBase64Int32(Request.QueryString["StudentID"]);
                    if (balSTU_Student.Update(entSTU_STudent))
                    {
                        
                        Response.Redirect("STU_StudentList.aspx");

                        
                    }
                    else
                    {
                        ucMessage.ShowError(balSTU_Student.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["StudentID"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balSTU_Student.Insert(entSTU_STudent))
                        {
                            ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                            ClearControls();
                        }
                    }
                }

                #endregion 15.3 Insert,Update,Copy

            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message);
            }
        }
    }

    #endregion 15.0 Save Button Event 

    #region 16.0 Clear Controls 

    private void ClearControls()
    {
        txtStudentName.Text = String.Empty;
        txtEnrollmentNo.Text = String.Empty;
        ddlCurrentSem.SelectedIndex = 0;
        txtEmailInstitute.Text = String.Empty;
        txtEmailPersonal.Text = String.Empty;
        ddlGender.SelectedIndex = 0;
        txtRollNo.Text = String.Empty;
        txtContactNo.Text = String.Empty;
        dtpBirthDate.Text = String.Empty;
        txtStudentName.Focus();
    }

    #endregion 16.0 Clear Controls 

}