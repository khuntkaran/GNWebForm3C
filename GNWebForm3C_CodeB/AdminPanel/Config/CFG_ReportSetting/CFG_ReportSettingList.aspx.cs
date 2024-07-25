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

public partial class AdminPanel_CFG_ReportSetting_CFG_ReportSettingList : System.Web.UI.Page
{ 
    #region 11.0 Variables
	
    String FormName = "CFG_ReportSettingList";
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
        CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
				
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
	
        SqlString ReportHeaderFontType = SqlString.Null;
        SqlDecimal ReportHeaderFontSize = SqlDecimal.Null;
        SqlString ReportHeaderFontStyle = SqlString.Null;
        SqlString TableHeaderFontType = SqlString.Null;
        SqlDecimal TableHeaderFontSize = SqlDecimal.Null;
        SqlString TableHeaderFontStyle = SqlString.Null;
        SqlString TableRowFontType = SqlString.Null;
        SqlDecimal TableRowFontSize = SqlDecimal.Null;
        SqlString TableRowFontStyle = SqlString.Null;
        SqlString FooterFontType = SqlString.Null;
        SqlDecimal FooterFontSize = SqlDecimal.Null;
        SqlString FooterFontStyle = SqlString.Null;
        SqlInt32 HospitalID = SqlInt32.Null;
        Int32 Offset = (PageNo - 1) * PageRecordSize;
        Int32 TotalRecords = 0;
		Int32 TotalPages = 1;

		#endregion Parameters
		
        #region Gather Data
        
		if (txtReportHeaderFontType.Text.Trim() != String.Empty)
			ReportHeaderFontType = txtReportHeaderFontType.Text.Trim();

		if (txtReportHeaderFontSize.Text.Trim() != String.Empty)
			ReportHeaderFontSize = Convert.ToDecimal(txtReportHeaderFontSize.Text.Trim());

		if (txtReportHeaderFontStyle.Text.Trim() != String.Empty)
			ReportHeaderFontStyle = txtReportHeaderFontStyle.Text.Trim();

		if (txtTableHeaderFontType.Text.Trim() != String.Empty)
			TableHeaderFontType = txtTableHeaderFontType.Text.Trim();

		if (txtTableHeaderFontSize.Text.Trim() != String.Empty)
			TableHeaderFontSize = Convert.ToDecimal(txtTableHeaderFontSize.Text.Trim());

		if (txtTableHeaderFontStyle.Text.Trim() != String.Empty)
			TableHeaderFontStyle = txtTableHeaderFontStyle.Text.Trim();

		if (txtTableRowFontType.Text.Trim() != String.Empty)
			TableRowFontType = txtTableRowFontType.Text.Trim();

		if (txtTableRowFontSize.Text.Trim() != String.Empty)
			TableRowFontSize = Convert.ToDecimal(txtTableRowFontSize.Text.Trim());

		if (txtTableRowFontStyle.Text.Trim() != String.Empty)
			TableRowFontStyle = txtTableRowFontStyle.Text.Trim();

		if (txtFooterFontType.Text.Trim() != String.Empty)
			FooterFontType = txtFooterFontType.Text.Trim();

		if (txtFooterFontSize.Text.Trim() != String.Empty)
			FooterFontSize = Convert.ToDecimal(txtFooterFontSize.Text.Trim());

		if (txtFooterFontStyle.Text.Trim() != String.Empty)
			FooterFontStyle = txtFooterFontStyle.Text.Trim();

		if (ddlHospitalID.SelectedIndex > 0)
			HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);


        #endregion Gather Data

        CFG_ReportSettingBAL balCFG_ReportSetting = new CFG_ReportSettingBAL();

        DataTable dt = balCFG_ReportSetting.SelectPage(Offset, PageRecordSize, out TotalRecords);

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
                CFG_ReportSettingBAL balCFG_ReportSetting = new CFG_ReportSettingBAL();
                if (e.CommandArgument.ToString().Trim() != "")
                {                    
                    if (balCFG_ReportSetting.Delete(Convert.ToInt32(e.CommandArgument)))
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

        		SqlString ReportHeaderFontType = SqlString.Null;
        		SqlDecimal ReportHeaderFontSize = SqlDecimal.Null;
        		SqlString ReportHeaderFontStyle = SqlString.Null;
        		SqlString TableHeaderFontType = SqlString.Null;
        		SqlDecimal TableHeaderFontSize = SqlDecimal.Null;
        		SqlString TableHeaderFontStyle = SqlString.Null;
        		SqlString TableRowFontType = SqlString.Null;
        		SqlDecimal TableRowFontSize = SqlDecimal.Null;
        		SqlString TableRowFontStyle = SqlString.Null;
        		SqlString FooterFontType = SqlString.Null;
        		SqlDecimal FooterFontSize = SqlDecimal.Null;
        		SqlString FooterFontStyle = SqlString.Null;
        		SqlInt32 HospitalID = SqlInt32.Null;
		
        if (txtReportHeaderFontType.Text.Trim() != String.Empty)
        	ReportHeaderFontType = txtReportHeaderFontType.Text.Trim();

        if (txtReportHeaderFontSize.Text.Trim() != String.Empty)
        	ReportHeaderFontSize = Convert.ToDecimal(txtReportHeaderFontSize.Text.Trim());

        if (txtReportHeaderFontStyle.Text.Trim() != String.Empty)
        	ReportHeaderFontStyle = txtReportHeaderFontStyle.Text.Trim();

        if (txtTableHeaderFontType.Text.Trim() != String.Empty)
        	TableHeaderFontType = txtTableHeaderFontType.Text.Trim();

        if (txtTableHeaderFontSize.Text.Trim() != String.Empty)
        	TableHeaderFontSize = Convert.ToDecimal(txtTableHeaderFontSize.Text.Trim());

        if (txtTableHeaderFontStyle.Text.Trim() != String.Empty)
        	TableHeaderFontStyle = txtTableHeaderFontStyle.Text.Trim();

        if (txtTableRowFontType.Text.Trim() != String.Empty)
        	TableRowFontType = txtTableRowFontType.Text.Trim();

        if (txtTableRowFontSize.Text.Trim() != String.Empty)
        	TableRowFontSize = Convert.ToDecimal(txtTableRowFontSize.Text.Trim());

        if (txtTableRowFontStyle.Text.Trim() != String.Empty)
        	TableRowFontStyle = txtTableRowFontStyle.Text.Trim();

        if (txtFooterFontType.Text.Trim() != String.Empty)
        	FooterFontType = txtFooterFontType.Text.Trim();

        if (txtFooterFontSize.Text.Trim() != String.Empty)
        	FooterFontSize = Convert.ToDecimal(txtFooterFontSize.Text.Trim());

        if (txtFooterFontStyle.Text.Trim() != String.Empty)
        	FooterFontStyle = txtFooterFontStyle.Text.Trim();

        if (ddlHospitalID.SelectedIndex > 0)
        	HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);


        Int32 Offset = 0;

	if (ViewState["CurrentPage"] != null)
            	Offset = (Convert.ToInt32(ViewState["CurrentPage"]) - 1) * PageRecordSize;

        CFG_ReportSettingBAL balCFG_ReportSetting = new CFG_ReportSettingBAL();
        DataTable dtCFG_ReportSetting = balCFG_ReportSetting.SelectPage(Offset, PageRecordSize, out TotalReceivedRecord);
        if (dtCFG_ReportSetting != null && dtCFG_ReportSetting.Rows.Count > 0)
		{
            Session["ExportTable"] = dtCFG_ReportSetting;
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
		txtReportHeaderFontType.Text = String.Empty;
		txtReportHeaderFontSize.Text = String.Empty;
		txtReportHeaderFontStyle.Text = String.Empty;
		txtTableHeaderFontType.Text = String.Empty;
		txtTableHeaderFontSize.Text = String.Empty;
		txtTableHeaderFontStyle.Text = String.Empty;
		txtTableRowFontType.Text = String.Empty;
		txtTableRowFontSize.Text = String.Empty;
		txtTableRowFontStyle.Text = String.Empty;
		txtFooterFontType.Text = String.Empty;
		txtFooterFontSize.Text = String.Empty;
		txtFooterFontStyle.Text = String.Empty;
		ddlHospitalID.SelectedIndex = 0;
		CommonFunctions.BindEmptyRepeater(rpData);
       		Div_SearchResult.Visible = false;
        	Div_ExportOption.Visible = false;
        	lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
        	lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
    }

    #endregion 22.0 ClearControls
}
