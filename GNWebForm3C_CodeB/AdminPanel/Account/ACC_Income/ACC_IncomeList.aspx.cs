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

public partial class AdminPanel_ACC_Income_ACC_IncomeList : System.Web.UI.Page
{ 
    #region 11.0 Variables
	
    String FormName = "ACC_IncomeList";
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

    #endregion 13.0 FillLabels

    #region 14.0 DropDownList

    #region 14.1 Fill DropDownList

    private void FillDropDownList()
    {

        CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);

        ddlFinYearID.Items.Insert(0, new ListItem("Select Fin Year", "-99"));
        ddlIncomeTypeID.Items.Insert(0, new ListItem("Select Income Type", "-99"));
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
	
        SqlInt32 IncomeTypeID = SqlInt32.Null;
        SqlDecimal Amount = SqlDecimal.Null;
        SqlDateTime IncomeDate = SqlDateTime.Null;
        SqlInt32 HospitalID = SqlInt32.Null;
        SqlInt32 FinYearID = SqlInt32.Null;
        Int32 Offset = (PageNo - 1) * PageRecordSize;
        Int32 TotalRecords = 0;
		Int32 TotalPages = 1;

		#endregion Parameters
		
        #region Gather Data
        
		if (ddlIncomeTypeID.SelectedIndex > 0)
			IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);

		if (txtAmount.Text.Trim() != String.Empty)
			Amount = Convert.ToDecimal(txtAmount.Text.Trim());

		if (dtpIncomeDate.Text.Trim() != String.Empty)
			IncomeDate = Convert.ToDateTime(dtpIncomeDate.Text.Trim());

		if (ddlHospitalID.SelectedIndex > 0)
			HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
        else if (Session["HospitalID"] != null)
        {
            HospitalID = Convert.ToInt32(Session["HospitalID"]);
            ddlHospitalID.SelectedValue = HospitalID.ToString();
            Session.Remove("HospitalID");
        }

		if (ddlFinYearID.SelectedIndex > 0)
			FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);


        #endregion Gather Data

        ACC_IncomeBAL balACC_Income = new ACC_IncomeBAL();

        DataTable dt = balACC_Income.SelectPage(Offset, PageRecordSize, out TotalRecords, IncomeTypeID, Amount, IncomeDate, HospitalID, FinYearID);

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
                ACC_IncomeBAL balACC_Income = new ACC_IncomeBAL();
                if (e.CommandArgument.ToString().Trim() != "")
                {                    
                    if (balACC_Income.Delete(Convert.ToInt32(e.CommandArgument)))
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
	
    public void DeleteAll(object sender, EventArgs e)
    {
        foreach (RepeaterItem items in rpData.Items)
        {
            try
            {
                #region FindControl
                
                HiddenField Hdfiled = (HiddenField)items.FindControl("hdIncomeID");
                CheckBox chkIsSelected = (CheckBox)items.FindControl("chkIsSelected");
                #endregion FindControl

                if (Hdfiled.Value != string.Empty)
                {
                    if (chkIsSelected.Checked)
                    {
                        #region 18.1 Delete Data
                            ACC_IncomeBAL balACC_Income = new ACC_IncomeBAL();
                            
                                if (balACC_Income.Delete(Convert.ToInt32(Hdfiled.Value)))
                                {
                                    ucMessage.ShowSuccess(CommonMessage.DeletedRecord());
                                }
                        #endregion 18.1 Delete Data
                    }
                }
            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message);
            }
        }
        Search(1);
    }
	
    #endregion 18.0 Button Delete Click Event

	#region 19.0 Export Data

    #region 19.1 Excel Export Button Click Event
	
    protected void lbtnExport_Click(object sender, EventArgs e)
    {
		LinkButton lbtn = (LinkButton)(sender);
		String ExportType = lbtn.CommandArgument.ToString();
	
        int TotalReceivedRecord = 0;

        		SqlInt32 IncomeTypeID = SqlInt32.Null;
        		SqlDecimal Amount = SqlDecimal.Null;
        		SqlDateTime IncomeDate = SqlDateTime.Null;
        		SqlInt32 HospitalID = SqlInt32.Null;
        		SqlInt32 FinYearID = SqlInt32.Null;
		
        if (ddlIncomeTypeID.SelectedIndex > 0)
        	IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);

        if (txtAmount.Text.Trim() != String.Empty)
        	Amount = Convert.ToDecimal(txtAmount.Text.Trim());

        if (dtpIncomeDate.Text.Trim() != String.Empty)
        	IncomeDate = Convert.ToDateTime(dtpIncomeDate.Text.Trim());

        if (ddlHospitalID.SelectedIndex > 0)
        	HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

        if (ddlFinYearID.SelectedIndex > 0)
        	FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);


        Int32 Offset = 0;

	    if (ViewState["CurrentPage"] != null)
            	Offset = (Convert.ToInt32(ViewState["CurrentPage"]) - 1) * PageRecordSize;

        ACC_IncomeBAL balACC_Income = new ACC_IncomeBAL();
        DataTable dtACC_Income = balACC_Income.SelectPage(Offset, PageRecordSize, out TotalReceivedRecord, IncomeTypeID, Amount, IncomeDate, HospitalID, FinYearID);
        if (dtACC_Income != null && dtACC_Income.Rows.Count > 0)
		{
            Session["ExportTable"] = dtACC_Income;
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
        ddlFinYearID.Items.Clear();
        ddlFinYearID.Items.Insert(0, new ListItem("Select Fin Year", "-99"));
        ddlIncomeTypeID.Items.Clear();
        ddlIncomeTypeID.Items.Insert(0, new ListItem("Select Income Type", "-99"));
		txtAmount.Text = String.Empty;
		dtpIncomeDate.Text = String.Empty;
		ddlHospitalID.SelectedIndex = 0;
		ddlFinYearID.SelectedIndex = 0;
		CommonFunctions.BindEmptyRepeater(rpData);
       		Div_SearchResult.Visible = false;
        	Div_ExportOption.Visible = false;
        	lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
        	lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
    }

    #endregion 22.0 ClearControls

    #region 23.0 Fill Finyear Dropdown From Hopital
    protected void ddlHospitalID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlHospitalID.SelectedIndex >0)
        {
            ddlIncomeTypeID.SelectedIndex = 0;  
            SqlInt32 HospitalID = SqlInt32.Null;

            HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
            CommonFillMethods.FillDropDownListFinYearIDByHospitalID(ddlFinYearID, HospitalID);

        }
        else
        {
            ddlFinYearID.Items.Clear();
            ddlFinYearID.Items.Insert(0, new ListItem("Select Fin Year", "-99"));
            ddlIncomeTypeID.Items.Clear();
            ddlIncomeTypeID.Items.Insert(0, new ListItem("Select Income Type", "-99"));

        }
    }
    #endregion 23.0 Fill Finyear Dropdown From Hopital

    #region 24.0 Fill IncomeType Dropdown From Finyear
    protected void ddlFinYearID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFinYearID.SelectedIndex > 0)
        {
            SqlInt32 FinYearID = SqlInt32.Null;
            SqlInt32 HospitalID = SqlInt32.Null;

            FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);
            HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
            CommonFillMethods.FillDropDownListIncomeTypeIDByFinYearID(ddlIncomeTypeID, FinYearID, HospitalID);
            
        }
        else
        {
            ddlIncomeTypeID.Items.Clear();
            ddlIncomeTypeID.Items.Insert(0, new ListItem("Select Income Type", "-99"));     
        }
    }
    #endregion 24.0 Fill IncomeType Dropdown From Finyear

}