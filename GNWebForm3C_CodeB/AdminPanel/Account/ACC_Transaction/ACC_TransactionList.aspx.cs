using GNForm3C;
using GNForm3C.BAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;

public partial class AdminPanel_ACC_Transaction_ACC_TransactionList : System.Web.UI.Page
{ 
    #region 11.0 Variables
	
    String FormName = "ACC_TransactionList";
    static Int32 PageRecordSize = CV.PageRecordSize;//Size of record per page
	Int32 PageDisplaySize = CV.PageDisplaySize;
    Int32 DisplayIndex = CV.DisplayIndex;
	
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
            
            lblSearchHeader.Text = CV.SearchHeaderText;
            lblSearchResultHeader.Text = CV.SearchResultHeaderText;
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
			
            #endregion 12.2 Set Default Value

            Search(1);

	    #region 12.3 Set Help Text
            ucHelp.ShowHelp("Help Text will be shown here");
            #endregion 12.3 Set Help Text
        }
    }
	
    #endregion 12.0 Page Load Event   

	#region 13.0 FillLabels 

	private void FillLabels(String FormName)
	{
	}
		
	#endregion 
	
    #region 14.0 DropDownList

    #region 14.1 Fill DropDownList
	
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListTreatmentID(ddlTreatmentID);
        CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
        CommonFillMethods.FillSingleDropDownListFinYearID(ddlFinYearID);
        CommonFillMethods.FillDropDownListReceiptTypeID(ddlReceiptTypeID);
				
        CommonFunctions.GetDropDownPageSize(ddlPageSizeBottom);
        ddlPageSizeBottom.SelectedValue = PageRecordSize.ToString();
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
		#region Parameters
	
        SqlString Patient = SqlString.Null;
        SqlInt32 TreatmentID = SqlInt32.Null;
        SqlDecimal Amount = SqlDecimal.Null;
        SqlInt32 SerialNo = SqlInt32.Null;
        SqlString ReferenceDoctor = SqlString.Null;
        SqlInt32 Count = SqlInt32.Null;
        SqlInt32 ReceiptNo = SqlInt32.Null;
        SqlDateTime Date = SqlDateTime.Null;
        SqlDateTime DateOfAdmission = SqlDateTime.Null;
        SqlDateTime DateOfDischarge = SqlDateTime.Null;
        SqlDecimal Deposite = SqlDecimal.Null;
        SqlDecimal NetAmount = SqlDecimal.Null;
        SqlInt32 NoOfDays = SqlInt32.Null;
        SqlInt32 HospitalID = SqlInt32.Null;
        SqlInt32 FinYearID = SqlInt32.Null;
        SqlInt32 ReceiptTypeID = SqlInt32.Null;
        Int32 Offset = (PageNo - 1) * PageRecordSize;
        Int32 TotalRecords = 0;
		Int32 TotalPages = 1;

		#endregion Parameters
		
        #region Gather Data
        
		if (txtPatient.Text.Trim() != String.Empty)
			Patient = txtPatient.Text.Trim();

		if (ddlTreatmentID.SelectedIndex > 0)
			TreatmentID = Convert.ToInt32(ddlTreatmentID.SelectedValue);

		if (txtAmount.Text.Trim() != String.Empty)
			Amount = Convert.ToDecimal(txtAmount.Text.Trim());

		if (txtSerialNo.Text.Trim() != String.Empty)
			SerialNo = Convert.ToInt32(txtSerialNo.Text.Trim());

		if (txtReferenceDoctor.Text.Trim() != String.Empty)
			ReferenceDoctor = txtReferenceDoctor.Text.Trim();

		if (txtCount.Text.Trim() != String.Empty)
			Count = Convert.ToInt32(txtCount.Text.Trim());

		if (txtReceiptNo.Text.Trim() != String.Empty)
			ReceiptNo = Convert.ToInt32(txtReceiptNo.Text.Trim());

		if (dtpDate.Text.Trim() != String.Empty)
			Date = Convert.ToDateTime(dtpDate.Text.Trim());

		if (dtpDateOfAdmission.Text.Trim() != String.Empty)
			DateOfAdmission = Convert.ToDateTime(dtpDateOfAdmission.Text.Trim());

		if (dtpDateOfDischarge.Text.Trim() != String.Empty)
			DateOfDischarge = Convert.ToDateTime(dtpDateOfDischarge.Text.Trim());

		if (txtDeposite.Text.Trim() != String.Empty)
			Deposite = Convert.ToDecimal(txtDeposite.Text.Trim());

		if (txtNetAmount.Text.Trim() != String.Empty)
			NetAmount = Convert.ToDecimal(txtNetAmount.Text.Trim());

		if (txtNoOfDays.Text.Trim() != String.Empty)
			NoOfDays = Convert.ToInt32(txtNoOfDays.Text.Trim());

		if (ddlHospitalID.SelectedIndex > 0)
			HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

		if (ddlFinYearID.SelectedIndex > 0)
			FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);

		if (ddlReceiptTypeID.SelectedIndex > 0)
			ReceiptTypeID = Convert.ToInt32(ddlReceiptTypeID.SelectedValue);


        #endregion Gather Data

        ACC_TransactionBAL balACC_Transaction = new ACC_TransactionBAL();

        DataTable dt = balACC_Transaction.SelectPage(Offset, PageRecordSize, out TotalRecords, Patient, TreatmentID);

        if(PageRecordSize == 0 && dt.Rows.Count > 0)
        {
            PageRecordSize = dt.Rows.Count;
            TotalPages = (int)Math.Ceiling((double)((decimal)TotalRecords / Convert.ToDecimal(PageRecordSize)));
        }
        else        
            TotalPages = (int)Math.Ceiling((double)((decimal)TotalRecords / Convert.ToDecimal(PageRecordSize)));        

        if (dt != null && dt.Rows.Count > 0)
        {
            Div_SearchResult.Visible = true;
			Div_ExportOption.Visible = true;
            rpData.DataSource = dt;
            rpData.DataBind();

            if (PageNo > TotalPages)            
                PageNo = TotalPages;
				
            ViewState["TotalPages"] = TotalPages;
			ViewState["CurrentPage"] = PageNo;
			
            CommonFunctions.BindPageList(TotalPages, TotalRecords, PageNo, PageDisplaySize, DisplayIndex, rpPagination, liPrevious, lbtnPrevious, liFirstPage, lbtnFirstPage, liNext, lbtnNext, liLastPage, lbtnLastPage);
            
            lblRecordInfoBottom.Text = CommonMessage.PageDisplayMessage(Offset, dt.Rows.Count, TotalRecords, PageNo, TotalPages);
			lblRecordInfoTop.Text = CommonMessage.PageDisplayMessage(Offset, dt.Rows.Count, TotalRecords, PageNo, TotalPages);			
			
            lbtnExportExcel.Visible = true;
			if (TotalRecords <= CV.SmallestPageSize)
            {
                Div_Pagination.Visible = false;
                Div_GoToPageNo.Visible = false;
                Div_PageSize.Visible = false;
            }
            else
            {
                Div_Pagination.Visible = true;
                Div_GoToPageNo.Visible = true;
                Div_PageSize.Visible = true;
            }
		}
		
        else if (TotalPages < PageNo && TotalPages > 0)        
            Search(TotalPages);
			
        else
        {
            Div_SearchResult.Visible = false;
            lbtnExportExcel.Visible = false;
			
            ViewState["TotalPages"] = 0;
			ViewState["CurrentPage"] = 1;
			
			rpData.DataSource = null;
            rpData.DataBind();
			
            lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
            lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
			
            CommonFunctions.BindPageList(0, 0, PageNo, PageDisplaySize, DisplayIndex, rpPagination, liPrevious, lbtnPrevious, liFirstPage, lbtnFirstPage, liNext, lbtnNext, liLastPage, lbtnLastPage);
            
            ucMessage.ShowError(CommonMessage.NoRecordFound());
        }
    }

    #endregion 15.2 Search Function

    #endregion 15.0 Search

    #region 16.0 Repeater Events

    #region 16.1 Item Command Event
	
    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            try
            {
                ACC_TransactionBAL balACC_Transaction = new ACC_TransactionBAL();
                if (e.CommandArgument.ToString().Trim() != "")
                {                    
                    if (balACC_Transaction.Delete(Convert.ToInt32(e.CommandArgument)))
                    {
                        ucMessage.ShowSuccess(CommonMessage.DeletedRecord());

                        if (ViewState["CurrentPage"] != null)
                        {
                            int Count = rpData.Items.Count;

                            if (Count == 1 && Convert.ToInt32(ViewState["CurrentPage"]) != 1)
                                ViewState["CurrentPage"] = (Convert.ToInt32(ViewState["CurrentPage"]) - 1);
                            Search(Convert.ToInt32(ViewState["CurrentPage"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message.ToString());
            }
        }
    }
	
    #endregion 16.1 Item Command Event    

    #endregion 16.0 Repeater Events

    #region 17.0 Pagination   

    #region 17.1 Pagination Events

    #region ItemDataBound Event
	
    protected void rpPagination_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lb = (LinkButton)e.Item.FindControl("lbtnPageNo");
            HtmlGenericControl hgc = (HtmlGenericControl)e.Item.FindControl("liPageNo");
            if (Convert.ToInt32(ViewState["CurrentPage"]) == Convert.ToInt32(lb.CommandArgument))
	    {
                hgc.Attributes["class"] = CSSClass.PaginationButtonActive;
		lb.Enabled = false;
	    }
            else            
                hgc.Attributes["class"] = CSSClass.PaginationButton;            
        }
    }
	
    #endregion ItemDataBound Event

    #region PageChange Event
	
    protected void PageChange_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        int Value = Convert.ToInt32(lbtn.CommandArgument);
        String Name = lbtn.CommandName.ToString();

        if (Name == "PageNo" || Name == "FirstPage")        
            Search(Value);        
        
        else if (Name == "PreviousPage")        
            Search(Convert.ToInt32(ViewState["CurrentPage"]) - Value);
			
        else if (Name == "NextPage")        
            Search(Convert.ToInt32(ViewState["CurrentPage"]) + Value);
			
        else if (Name == "LastPage")        
            Search(Convert.ToInt32(ViewState["TotalPages"]));
			
        else if (Name == "GoPageNo")
        {
            if (txtPageNo.Text.Trim() == String.Empty)
            {
                ucMessage.ShowError(CommonMessage.ErrorRequiredField("Page No"));
                return;
            }
            else
            {
                Value = Convert.ToInt32(txtPageNo.Text);
                if (Value > Convert.ToInt32(ViewState["TotalPages"]))
                {
                    ucMessage.ShowError(CommonMessage.ErrorInvalidField("Page No"));
                    return;
                }
                Search(Value);
            }
        }
    }
	
    #endregion PageChange Event

    #endregion 17.1 Pagination Events

    #endregion 17.0 Pagination

    #region 18.0 Button Delete Click Event
	
	
    #endregion 18.0 Button Delete Click Event

	#region 19.0 Export Data

    #region 19.1 Excel Export Button Click Event
	
    protected void lbtnExport_Click(object sender, EventArgs e)
    {
		LinkButton lbtn = (LinkButton)(sender);
		String ExportType = lbtn.CommandArgument.ToString();
	
        int TotalReceivedRecord = 0;

        		SqlString Patient = SqlString.Null;
        		SqlInt32 TreatmentID = SqlInt32.Null;
        		SqlDecimal Amount = SqlDecimal.Null;
        		SqlInt32 SerialNo = SqlInt32.Null;
        		SqlString ReferenceDoctor = SqlString.Null;
        		SqlInt32 Count = SqlInt32.Null;
        		SqlInt32 ReceiptNo = SqlInt32.Null;
        		SqlDateTime Date = SqlDateTime.Null;
        		SqlDateTime DateOfAdmission = SqlDateTime.Null;
        		SqlDateTime DateOfDischarge = SqlDateTime.Null;
        		SqlDecimal Deposite = SqlDecimal.Null;
        		SqlDecimal NetAmount = SqlDecimal.Null;
        		SqlInt32 NoOfDays = SqlInt32.Null;
        		SqlInt32 HospitalID = SqlInt32.Null;
        		SqlInt32 FinYearID = SqlInt32.Null;
        		SqlInt32 ReceiptTypeID = SqlInt32.Null;
		
        if (txtPatient.Text.Trim() != String.Empty)
        	Patient = txtPatient.Text.Trim();

        if (ddlTreatmentID.SelectedIndex > 0)
        	TreatmentID = Convert.ToInt32(ddlTreatmentID.SelectedValue);

        if (txtAmount.Text.Trim() != String.Empty)
        	Amount = Convert.ToDecimal(txtAmount.Text.Trim());

        if (txtSerialNo.Text.Trim() != String.Empty)
        	SerialNo = Convert.ToInt32(txtSerialNo.Text.Trim());

        if (txtReferenceDoctor.Text.Trim() != String.Empty)
        	ReferenceDoctor = txtReferenceDoctor.Text.Trim();

        if (txtCount.Text.Trim() != String.Empty)
        	Count = Convert.ToInt32(txtCount.Text.Trim());

        if (txtReceiptNo.Text.Trim() != String.Empty)
        	ReceiptNo = Convert.ToInt32(txtReceiptNo.Text.Trim());

        if (dtpDate.Text.Trim() != String.Empty)
        	Date = Convert.ToDateTime(dtpDate.Text.Trim());

        if (dtpDateOfAdmission.Text.Trim() != String.Empty)
        	DateOfAdmission = Convert.ToDateTime(dtpDateOfAdmission.Text.Trim());

        if (dtpDateOfDischarge.Text.Trim() != String.Empty)
        	DateOfDischarge = Convert.ToDateTime(dtpDateOfDischarge.Text.Trim());

        if (txtDeposite.Text.Trim() != String.Empty)
        	Deposite = Convert.ToDecimal(txtDeposite.Text.Trim());

        if (txtNetAmount.Text.Trim() != String.Empty)
        	NetAmount = Convert.ToDecimal(txtNetAmount.Text.Trim());

        if (txtNoOfDays.Text.Trim() != String.Empty)
        	NoOfDays = Convert.ToInt32(txtNoOfDays.Text.Trim());

        if (ddlHospitalID.SelectedIndex > 0)
        	HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

        if (ddlFinYearID.SelectedIndex > 0)
        	FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);

        if (ddlReceiptTypeID.SelectedIndex > 0)
        	ReceiptTypeID = Convert.ToInt32(ddlReceiptTypeID.SelectedValue);


        Int32 Offset = 0;

	if (ViewState["CurrentPage"] != null)
            	Offset = (Convert.ToInt32(ViewState["CurrentPage"]) - 1) * PageRecordSize;

        ACC_TransactionBAL balACC_Transaction = new ACC_TransactionBAL();
        DataTable dtACC_Transaction = balACC_Transaction.SelectPage(Offset, PageRecordSize, out TotalReceivedRecord, Patient, TreatmentID);
        if (dtACC_Transaction != null && dtACC_Transaction.Rows.Count > 0)
		{
            Session["ExportTable"] = dtACC_Transaction;
            Response.Redirect("~/Default/Export.aspx?ExportType=" + ExportType);
        }	
	}
	
	#endregion 19.1 Excel Export Button Click Event
	
	#endregion 19.0 Export Data   
	
	#region 20.0 Cancel Button Event
	
    protected void btnClear_Click(object sender, EventArgs e)
    {
		ClearControls();
    }
	
    #endregion 20.0 Cancel Button Event

    #region 21.0 ddlPageSize Selected Index Changed Event

    protected void ddlPageSizeBottom_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageRecordSize = Convert.ToInt32(ddlPageSizeBottom.SelectedValue);
        Search(Convert.ToInt32(ViewState["CurrentPage"]));
    }

    protected void ddlPageSizeTop_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPageSizeBottom.SelectedValue = PageRecordSize.ToString();
        Search(Convert.ToInt32(ViewState["CurrentPage"]));
    }

    #endregion 21.0 ddlPageSize Selected Index Changed Event

	#region 22.0 ClearControls

    private void ClearControls()
    {
		txtPatient.Text = String.Empty;
		ddlTreatmentID.SelectedIndex = 0;
		txtAmount.Text = String.Empty;
		txtSerialNo.Text = String.Empty;
		txtReferenceDoctor.Text = String.Empty;
		txtCount.Text = String.Empty;
		txtReceiptNo.Text = String.Empty;
		dtpDate.Text = String.Empty;
		dtpDateOfAdmission.Text = String.Empty;
		dtpDateOfDischarge.Text = String.Empty;
		txtDeposite.Text = String.Empty;
		txtNetAmount.Text = String.Empty;
		txtNoOfDays.Text = String.Empty;
		ddlHospitalID.SelectedIndex = 0;
		ddlFinYearID.SelectedIndex = 0;
		ddlReceiptTypeID.SelectedIndex = 0;
		CommonFunctions.BindEmptyRepeater(rpData);
       		Div_SearchResult.Visible = false;
        	Div_ExportOption.Visible = false;
        	lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
        	lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
    }

    #endregion 22.0 ClearControls
}
