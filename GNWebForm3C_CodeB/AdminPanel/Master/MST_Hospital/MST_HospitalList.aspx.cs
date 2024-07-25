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

public partial class AdminPanel_MST_Hospital_MST_HospitalList : System.Web.UI.Page
{ 
    #region 11.0 Variables
	
    String FormName = "MST_HospitalList";
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

            Search(1);
			
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
	
        SqlString Hospital = SqlString.Null;
        SqlString PrintName = SqlString.Null;
        SqlString PrintLine1 = SqlString.Null;
        SqlString PrintLine2 = SqlString.Null;
        SqlString PrintLine3 = SqlString.Null;
        SqlString FooterName = SqlString.Null;
        SqlString ReportHeaderName = SqlString.Null;
        Int32 Offset = (PageNo - 1) * PageRecordSize;
        Int32 TotalRecords = 0;
		Int32 TotalPages = 1;

		#endregion Parameters
		
        #region Gather Data
        
		if (txtHospital.Text.Trim() != String.Empty)
			Hospital = txtHospital.Text.Trim();

		if (txtPrintName.Text.Trim() != String.Empty)
			PrintName = txtPrintName.Text.Trim();

		if (txtPrintLine1.Text.Trim() != String.Empty)
			PrintLine1 = txtPrintLine1.Text.Trim();

		if (txtPrintLine2.Text.Trim() != String.Empty)
			PrintLine2 = txtPrintLine2.Text.Trim();

		if (txtPrintLine3.Text.Trim() != String.Empty)
			PrintLine3 = txtPrintLine3.Text.Trim();

		if (txtFooterName.Text.Trim() != String.Empty)
			FooterName = txtFooterName.Text.Trim();

		if (txtReportHeaderName.Text.Trim() != String.Empty)
			ReportHeaderName = txtReportHeaderName.Text.Trim();


        #endregion Gather Data

        MST_HospitalBAL balMST_Hospital = new MST_HospitalBAL();

        DataTable dt = balMST_Hospital.SelectPage(Offset, PageRecordSize, out TotalRecords, Hospital, PrintName, PrintLine1, PrintLine2, PrintLine3, FooterName, ReportHeaderName);

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

            foreach(RepeaterItem rpcount in rpData.Items)
            {
                HyperLink hlExpCount = (HyperLink)rpcount.FindControl("hlExpCount");
                HyperLink hlExpCountEdit = (HyperLink)rpcount.FindControl("hlExpCountEdit");
                if (hlExpCount.Text.Trim() == "0")
                {
                    hlExpCount.NavigateUrl = null;
                    hlExpCountEdit.Visible = false;
                }   

            }

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
                MST_HospitalBAL balMST_Hospital = new MST_HospitalBAL();
                if (e.CommandArgument.ToString().Trim() != "")
                {                    
                    if (balMST_Hospital.Delete(Convert.ToInt32(e.CommandArgument)))
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

        		SqlString Hospital = SqlString.Null;
        		SqlString PrintName = SqlString.Null;
        		SqlString PrintLine1 = SqlString.Null;
        		SqlString PrintLine2 = SqlString.Null;
        		SqlString PrintLine3 = SqlString.Null;
        		SqlString FooterName = SqlString.Null;
        		SqlString ReportHeaderName = SqlString.Null;
		
        if (txtHospital.Text.Trim() != String.Empty)
        	Hospital = txtHospital.Text.Trim();

        if (txtPrintName.Text.Trim() != String.Empty)
        	PrintName = txtPrintName.Text.Trim();

        if (txtPrintLine1.Text.Trim() != String.Empty)
        	PrintLine1 = txtPrintLine1.Text.Trim();

        if (txtPrintLine2.Text.Trim() != String.Empty)
        	PrintLine2 = txtPrintLine2.Text.Trim();

        if (txtPrintLine3.Text.Trim() != String.Empty)
        	PrintLine3 = txtPrintLine3.Text.Trim();

        if (txtFooterName.Text.Trim() != String.Empty)
        	FooterName = txtFooterName.Text.Trim();

        if (txtReportHeaderName.Text.Trim() != String.Empty)
        	ReportHeaderName = txtReportHeaderName.Text.Trim();


        Int32 Offset = 0;

	if (ViewState["CurrentPage"] != null)
            	Offset = (Convert.ToInt32(ViewState["CurrentPage"]) - 1) * PageRecordSize;

        MST_HospitalBAL balMST_Hospital = new MST_HospitalBAL();
        DataTable dtMST_Hospital = balMST_Hospital.SelectPage(Offset, PageRecordSize, out TotalReceivedRecord, Hospital, PrintName, PrintLine1, PrintLine2, PrintLine3, FooterName, ReportHeaderName);
        if (dtMST_Hospital != null && dtMST_Hospital.Rows.Count > 0)
		{
            Session["ExportTable"] = dtMST_Hospital;
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
		txtHospital.Text = String.Empty;
		txtPrintName.Text = String.Empty;
		txtPrintLine1.Text = String.Empty;
		txtPrintLine2.Text = String.Empty;
		txtPrintLine3.Text = String.Empty;
		txtFooterName.Text = String.Empty;
		txtReportHeaderName.Text = String.Empty;
		CommonFunctions.BindEmptyRepeater(rpData);
       		Div_SearchResult.Visible = false;
        	Div_ExportOption.Visible = false;
        	lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
        	lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
    }

    #endregion 22.0 ClearControls
}
