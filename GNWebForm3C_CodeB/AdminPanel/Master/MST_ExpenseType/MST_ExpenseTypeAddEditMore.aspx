<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="MST_ExpenseTypeAddEditMore.aspx.cs" Inherits="AdminPanel_Master_MST_ExpenseType_MST_ExpenseTypeAddEditMore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Expense Type " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Master" runat="server"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="cntBreadcrumb" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <asp:HyperLink ID="hlExpenseType" runat="server" NavigateUrl="~/AdminPanel/Master/MST_ExpenseType/MST_ExpenseTypeList.aspx" Text="Expense Type List"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Expense Type Add/Edit More"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>

            <asp:UpdatePanel ID="upMST_ExpenseType" runat="server" EnableViewState="true" UpdateMode="Always">
                <Triggers>
                </Triggers>
                <ContentTemplate>
                    <div class="row">
                        <div class="col-md-12">
                            <ucMessage:ShowMessage ID="ucMessage" runat="server" />
                            <ucMessage:ShowMessage ID="ucMessage2" runat="server" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" SkinID="VS" />
                        </div>
                    </div>
                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">
                                <asp:Label ID="lblFormHeaderIcon" runat="server" SkinID="lblFormHeaderIcon"></asp:Label>
                                <span class="caption-subject font-green-sharp bold uppercase">
                                    <asp:Label ID="lblFormHeader" runat="server" Text=""></asp:Label>
                                </span>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <div role="form">
                                <div class="form-body">
                                    <div class="row">
                                        <div class="col-md-3 text-start">
                                            <label class=" control-label">
                                                <span class="required">*</span>
                                                <asp:Label ID="lblExpenseType_XXXXX" runat="server" Text="Expense Type"></asp:Label>
                                            </label>
                                        </div>
                                        <div class="col-md-3 text-start">
                                            <label class=" control-label">
                                                <span class="required">*</span>
                                                <asp:Label ID="lblHospitalID_XXXXX" runat="server" Text="Hospital"></asp:Label>
                                            </label>
                                        </div>
                                        <div class="col-md-3 text-start">
                                            <label class=" control-label">
                                                <asp:Label ID="lblRemarks_XXXXX" runat="server" Text="Remarks"></asp:Label>
                                            </label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-plus"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtExpenseType" runat="server" CssClass="form-control" PlaceHolder="Enter Expense Type"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="rfvExpenseType" visible="true" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtExpenseType" ErrorMessage="Enter Expense Type"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-plus"></i>
                                                    </span>
                                                    <asp:DropDownList ID="ddlHospitalID" runat="server" CssClass="form-control select2me">
                                                    </asp:DropDownList>
                                                    <%--<asp:RequiredFieldValidator ID="rfvHospitalID" visible="true" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlHospitalID" ErrorMessage="Select Hospital" InitialValue="-99"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">

                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-plus"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" PlaceHolder="Enter Remarks"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:LinkButton ID="btnAddMore" runat="server" OnClick="btnAddMore_Click" SkinID="lbtnAddMore" Visible="true">
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnUpdate" runat="server" SkinID="lbtnUpdate" Visible="false" OnClick="btnUpdate_Click">
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="form-actions"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">
                <Triggers>
                </Triggers>
                <ContentTemplate>
                    <div class="row">
                        <div class="col-md-12">
                            <ucMessage:ShowMessage ID="ShowMessage1" runat="server" ViewStateMode="Disabled" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div id="Div_ShowResult" runat="server" class="portlet light" visible="false ">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <asp:Label runat="server" SkinID="lblSearchResultHeaderIcon"></asp:Label>
                                        <asp:Label ID="lblSearchResultHeader" runat="server" SkinID="lblResultHeaderText"></asp:Label>
                                        <label class="control-label">
                                            &nbsp;</label>
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div id="Div_SearchResult" runat="server" class="row">
                                        <div class="col-md-12">
                                            <div id="TableContent">
                                                <table id="sample_1" class="table table-bordered table-advanced table-striped table-hover">
                                                    <%-- Table Header --%>
                                                    <thead>
                                                        <tr class="TRDark">
                                                            <th class="text-center">
                                                                <asp:Label ID="lbhSerialNo" runat="server" Text="Sr No."></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label ID="lbhExpenseTypeID" runat="server" Text="Expense Type"></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label ID="lbhHospitalID" runat="server" Text="Hospital"></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label ID="lblRemarksID" runat="server" Text="Remarks"></asp:Label>
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
                                                                    <td class="text-center"><%#Container.ItemIndex+1 %></td>
                                                                    <td>
                                                                        <asp:Label ID="lblExpenseType" runat="server" Text='<%#Eval("ExpenseType") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblHospital" runat="server" Text='<%#Eval("Hospital") %>'></asp:Label>
                                                                        <asp:HiddenField ID="hfHospitalID" runat="server" Value='<%#Eval("HospitalID") %>' />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="text-nowrap text-center">
                                                                        <asp:LinkButton ID="lbtnEdit" runat="server" CommandArgument="<%#Container.ItemIndex %>" CommandName="EditRecord" SkinID="lbtnEdit">
                                                                        </asp:LinkButton>
                                                                        <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument="<%#Container.ItemIndex %>" CommandName="DeleteRecord" OnClientClick="javascript:return confirm('Are you sure you want to delete record ? ');" SkinID="Delete">
                                                                        </asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <%-- END Table Rows --%>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                </table>
                                            </div>
                                            <div runat="server" class="form-actions">
                                                <div class="row">
                                                    <div class="col-md-offset-3 col-md-9">
                                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" SkinID="btnSave" />
                                                        <asp:HyperLink ID="hlCancel" runat="server" NavigateUrl="~/AdminPanel/Master/MST_ExpenseType/MST_ExpenseTypeList.aspx" SkinID="hlCancel"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAddMore" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <%-- Loading  --%>
    <asp:UpdateProgress ID="upr" runat="server">
        <ProgressTemplate>
            <div class="divWaiting">
                <asp:Label ID="lblWait" runat="server" Text="Please wait... " />
                <asp:Image ID="imgWait" runat="server" SkinID="UpdatePanelLoding" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%-- END Loading  --%>
</asp:Content>


