<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="CFG_SoftwareConfigurationList.aspx.cs" Inherits="AdminPanel_CFG_SoftwareConfiguration_CFG_SoftwareConfigurationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
	<asp:Label ID="lblPageHeader_XXXXX" runat="server" Text="Software Configuration"></asp:Label>
	<small><asp:Label ID="lblPageHeaderInfo_XXXXX" runat="server" Text="Config"></asp:Label></small>
	<span class="pull-right">
        	<small>
	            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        	</small>
	</span>	
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
		<i class="fa fa-home"></i>
        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="SoftwareConfiguration"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>

    <%-- Search --%> 
    <asp:UpdatePanel ID="upApplicationFeature" runat="server">
        <ContentTemplate>			
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Label SkinID="lblSearchHeaderIcon" runat="server"></asp:Label>
                        <asp:Label ID="lblSearchHeader" SkinID="lblSearchHeaderText" runat="server"></asp:Label>
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse pull-right"></a>
                    </div>
                </div>
                <div class="portlet-body form">
                    <div role="form">
                        <div class="form-body">
							<div class="row">
								<div class="col-md-4">
									<div class="form-group">
										<div class="input-group">
											<span class="input-group-addon">
												<i class="fa fa-search"></i>
											</span>
											<asp:TextBox ID="txtSaveMessage_NoMessageJustClosetheform" CssClass="First form-control" runat="server"  PlaceHolder="Enter Save Message_ No Message Just Closetheform"></asp:TextBox>
										</div>
									</div>
								</div>
								<div class="col-md-4">
									<div class="form-group">
										<div class="input-group">
											<span class="input-group-addon">
												<i class="fa fa-search"></i>
											</span>
											<asp:TextBox ID="txtSaveMessage_ShowMessageClosetheform" CssClass="form-control" runat="server"  PlaceHolder="Enter Save Message_ Show Message Closetheform"></asp:TextBox>
										</div>
									</div>
								</div>
								<div class="col-md-4">
									<div class="form-group">
										<div class="input-group">
											<span class="input-group-addon">
												<i class="fa fa-search"></i>
											</span>
											<asp:TextBox ID="txtSaveMessage_ShowMessageAskforOtherRecord" CssClass="form-control" runat="server"  PlaceHolder="Enter Save Message_ Show Message Askfor Other Record"></asp:TextBox>
										</div>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-md-4">
									<div class="form-group">
										<div class="input-group">
											<span class="input-group-addon">
												<i class="fa fa-search"></i>
											</span>
											<asp:TextBox ID="txtShortcutKeys_EditOnEnterKeyinListPage" CssClass="form-control" runat="server"  PlaceHolder="Enter Shortcut Keys_ Edit On Enter Keyin List Page"></asp:TextBox>
										</div>
									</div>
								</div>
								<div class="col-md-4">
									<div class="form-group">
										<div class="input-group">
											<span class="input-group-addon">
												<i class="fa fa-search"></i>
											</span>
											<asp:TextBox ID="txtShortcutKeys_DoubleClicK" CssClass="form-control" runat="server"  PlaceHolder="Enter Shortcut Keys_ Double Clic K"></asp:TextBox>
										</div>
									</div>
								</div>
								<div class="col-md-4">
									<div class="form-group">
										<div class="input-group">
											<span class="input-group-addon">
												<i class="fa fa-search"></i>
											</span>
									       	<asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
										</div>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-md-4">
									<div class="form-group">
										<div class="input-group">
											<span class="input-group-addon">
												<i class="fa fa-search"></i>
											</span>
											<asp:TextBox ID="txtWeeklyBackupPassword" CssClass="form-control" runat="server"  PlaceHolder="Enter Weekly Backup Password"></asp:TextBox>
										</div>
									</div>
								</div>
							</div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-9">
                                    <asp:Button ID="btnSearch" SkinID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnClear" runat="server" SkinID="btnClear" Text="Clear" OnClick="btnClear_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- End Search --%>

    <%-- List --%>
    <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ucMessage" runat="server" ViewStateMode="Disabled" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">
                                <asp:Label SkinID="lblSearchResultHeaderIcon" runat="server"></asp:Label>
                                <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                                <label class="control-label">&nbsp;</label>
                                <label class="control-label pull-right">
                                    <asp:Label ID="lblRecordInfoTop" Text="No entries found" CssClass="pull-right" runat="server"></asp:Label>
                                </label>
                            </div>
                            <div class="tools">
                                 <div>
									<asp:HyperLink SkinID="hlAddNew" ID="hlAddNew" NavigateUrl="~/AdminPanel/Config/CFG_SoftwareConfiguration/CFG_SoftwareConfigurationAddEdit.aspx" runat="server"></asp:HyperLink>
                                    <div class="btn-group" runat="server" id="Div_ExportOption" visible="false">
                                        <button class="btn dropdown-toggle" data-toggle="dropdown">
                                            Export <i class="fa fa-angle-down"></i>
                                        </button>
                                        <ul class="dropdown-menu pull-right">
                                            <li>
                                                <asp:LinkButton ID="lbtnExportPDF" runat="server" CommandArgument="PDF" OnClick="lbtnExport_Click">PDF</asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lbtnExportExcel" runat="server" CommandArgument="Excel" OnClick="lbtnExport_Click">Excel</asp:LinkButton>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row" runat="server" id="Div_SearchResult" visible="false">
                                <div class="col-md-12">
                                    <div id="TableContent">
                                        <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                            <%-- Table Header --%>
                                            <thead>
                                                <tr class="TRDark">
                                                    <th><asp:Label ID="lbhSaveMessage_NoMessageJustClosetheform" runat="server" Text="Save Message_ No Message Just Closetheform"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhSaveMessage_ShowMessageClosetheform" runat="server" Text="Save Message_ Show Message Closetheform"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhSaveMessage_ShowMessageAskforOtherRecord" runat="server" Text="Save Message_ Show Message Askfor Other Record"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhShortcutKeys_AddOnNumPadPlusKeyinListPage" runat="server" Text="Shortcut Keys_ Add On Num Pad Plus Keyin List Page"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhShortcutKeys_EditOnEnterKeyinListPage" runat="server" Text="Shortcut Keys_ Edit On Enter Keyin List Page"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhShortcutKeys_ViewOnSpaceBarKeyinListPage" runat="server" Text="Shortcut Keys_ View On Space Bar Keyin List Page"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhShortcutKeys_DeleteOnDeleteKeyinListPage" runat="server" Text="Shortcut Keys_ Delete On Delete Keyin List Page"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhShortcutKeys_DoubleClicK" runat="server" Text="Shortcut Keys_ Double Clic K"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhShortcutKeys_IsAskConfirmationBeforeEscape" runat="server" Text="Shortcut Keys_ Is Ask Confirmation Before Escape"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhIsEnterAsTAB" runat="server" Text="Is Enter As TAB"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhIsSendError" runat="server" Text="Is Send Error"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhIsShowUserNameinListPage" runat="server" Text="Is Show User Namein List Page"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhIsShowModifiedinListPage" runat="server" Text="Is Show Modifiedin List Page"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhAllowIncrementalSearchinGrid" runat="server" Text="Allow Incremental Searchin Gr"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhHospitalID" runat="server" Text="Hospital"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhWeeklyBackupPassword" runat="server" Text="Weekly Backup Password"></asp:Label>
                                                    </th>
                                                    <th><asp:Label ID="lbhIsActive" runat="server" Text="Is Active"></asp:Label>
                                                    </th>
													<th class="nosortsearch text-nowrap text-center">
														<asp:Label ID="lbhAction" runat="server" Text="Action"></asp:Label>
													</th>
                                                </tr>
                                            </thead>
                                            <%-- END Table Header --%>

                                            <tbody>
                                                <asp:Repeater ID="rpData" runat="server" OnItemCommand="rpData_ItemCommand">
                                                    <ItemTemplate>
                                                        <%-- Table Rows --%>
                                                        <tr class="odd gradeX">
                                                            <td>
                                                            <asp:HyperLink ID="hlViewSoftwareConfigurationID" NavigateUrl='<%# "~/AdminPanel/Config/CFG_SoftwareConfiguration/CFG_SoftwareConfigurationView.aspx?SoftwareConfigurationID=" + GNForm3C.CommonFunctions.EncryptBase64(Eval("SoftwareConfigurationID").ToString()) %>' data-target="#viewiFrameReg" CssClass="modalButton" data-toggle="modal" runat="server"><%#Eval("SaveMessage_NoMessageJustClosetheform") %></asp:HyperLink>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("SaveMessage_ShowMessageClosetheform") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("SaveMessage_ShowMessageAskforOtherRecord") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("ShortcutKeys_AddOnNumPadPlusKeyinListPage") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("ShortcutKeys_EditOnEnterKeyinListPage") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("ShortcutKeys_ViewOnSpaceBarKeyinListPage") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("ShortcutKeys_DeleteOnDeleteKeyinListPage") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("ShortcutKeys_DoubleClicK") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("ShortcutKeys_IsAskConfirmationBeforeEscape") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("IsEnterAsTAB") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("IsSendError") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("IsShowUserNameinListPage") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("IsShowModifiedinListPage") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("AllowIncrementalSearchinGrid") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("HospitalID") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("WeeklyBackupPassword") %>
                                                            </td>
                                                            <td>
                                                            	<%#Eval("IsActive") %>
                                                            </td>
                                                            <td class="text-nowrap text-center">
                                                                <asp:HyperLink ID="hlView" SkinID="View" NavigateUrl='<%# "~/AdminPanel/Config/CFG_SoftwareConfiguration/CFG_SoftwareConfigurationView.aspx?SoftwareConfigurationID=" + GNForm3C.CommonFunctions.EncryptBase64(Eval("SoftwareConfigurationID").ToString()) %>' data-target="#viewiFrameReg" data-toggle="modal" runat="server"></asp:HyperLink>
								<asp:HyperLink ID="hlEdit" SkinID="Edit" NavigateUrl='<%# "~/AdminPanel/Config/CFG_SoftwareConfiguration/CFG_SoftwareConfigurationAddEdit.aspx?SoftwareConfigurationID=" + GNForm3C.CommonFunctions.EncryptBase64(Eval("SoftwareConfigurationID").ToString()) %>' runat="server"></asp:HyperLink>
                                                                <asp:LinkButton ID="lbtnDelete" runat="server"
                                                                    SkinID="Delete"
                                                                    OnClientClick="javascript:return confirm('Are you sure you want to delete record ? ');"
                                                                    CommandName="DeleteRecord"
                                                                    CommandArgument='<%#Eval("SoftwareConfigurationID") %>'>
                                                                </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <%-- END Table Rows --%>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                    
                                    <%-- Pagination --%>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label class="control-label">
                                                <asp:Label ID="lblRecordInfoBottom" Text="No entries found" runat="server"></asp:Label></label>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="dataTables_paginate paging_simple_numbers" runat="server" id="Div_Pagination">
                                                <ul class="pagination">
                                                    <li class="paginate_button previous disabled" id="liFirstPage" runat="server">
                                                        <asp:LinkButton ID="lbtnFirstPage" Enabled="false" OnClick="PageChange_Click" CommandName="FirstPage" CommandArgument="1" runat="server"><i class="fa fa-angle-double-left"></i></asp:LinkButton></li>
                                                    <li class="paginate_button previous disabled" id="liPrevious" runat="server">
                                                        <asp:LinkButton ID="lbtnPrevious" Enabled="false" OnClick="PageChange_Click" CommandArgument="1" CommandName="PreviousPage" runat="server"><i class="fa fa-angle-left"></i></asp:LinkButton></li>
                                                    <asp:Repeater ID="rpPagination" runat="server" OnItemDataBound="rpPagination_ItemDataBound">
                                                        <ItemTemplate>
                                                            <li>
                                                                <li class="paginate_button" id="liPageNo" runat="server">
                                                                    <asp:LinkButton ID="lbtnPageNo" runat="server" OnClick="PageChange_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PageNo")%>' CommandName="PageNo"><%# DataBinder.Eval(Container.DataItem, "PageNo")%></asp:LinkButton></li>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <li class="paginate_button next disabled" id="liNext" runat="server">
                                                        <asp:LinkButton ID="lbtnNext" Enabled="false" OnClick="PageChange_Click" CommandArgument="1" CommandName="NextPage" runat="server"><i class="fa fa-angle-right"></i></asp:LinkButton></li>
                                                    <li class="paginate_button previous disabled" id="liLastPage" runat="server">
                                                        <asp:LinkButton ID="lbtnLastPage" Enabled="false" OnClick="PageChange_Click" CommandName="LastPage" CommandArgument="-99" runat="server"><i class="fa fa-angle-double-right"></i></asp:LinkButton></li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="col-md-3 pull-right">
                                            <div class="btn-group" runat="server" id="Div_GoToPageNo">                                                
                                                <asp:TextBox ID="txtPageNo" placeholder="Page No" onkeypress="return IsNumeric(event)" runat="server" CssClass="pagination-panel-input form-control input-xsmall input-inline col-md-4" MaxLength="9"></asp:TextBox>
                                                <asp:LinkButton ID="lbtnGoToPageNo" runat="server" CssClass="btn btn-default input-inline col-md-4" CommandName="GoPageNo" CommandArgument="0" OnClick="PageChange_Click">Go</asp:LinkButton>
                                            </div>
                                            <div class="btn-group pull-right" runat="server" id="Div_PageSize">
                                                <label class="control-label">Page Size</label>
                                                <asp:DropDownList ID="ddlPageSizeBottom" AutoPostBack="true" CssClass="form-control input-xsmall" runat="server" OnSelectedIndexChanged="ddlPageSizeBottom_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                    </div>
                                    <%-- END Pagination --%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END EXAMPLE TABLE PORTLET-->
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
            <asp:PostBackTrigger ControlID="lbtnExportExcel" />
	    <asp:PostBackTrigger ControlID="lbtnExportPDF" />
        </Triggers>
    </asp:UpdatePanel>
    <%-- END List --%>

    <%-- Loading  --%>
    <asp:UpdateProgress ID="upr" runat="server">
        <ProgressTemplate>
            <div class="divWaiting">
                <asp:Label ID="lblWait" runat="server" Text=" Please wait... " />
                <asp:Image ID="imgWait" runat="server" SkinID="UpdatePanelLoding" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%-- END Loading  --%>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
    <script>

        $(window).keydown(function (e) {
            GNWebKeyEvents(e.keyCode, '<%=hlAddNew.ClientID%>', '<%=btnSearch.ClientID%>');
        });

        SearchGridUI('<%=btnSearch.ClientID%>', 'sample_1', 1);
    </script>
</asp:Content>
