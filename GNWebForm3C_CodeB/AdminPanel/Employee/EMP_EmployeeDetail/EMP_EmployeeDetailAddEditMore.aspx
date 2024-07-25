<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="EMP_EmployeeDetailAddEditMore.aspx.cs" Inherits="AdminPanel_Employee_EMP_EmployeeDetail_EMP_EmployeeDetailAddEditMore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" Runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Employee Detail" runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Employee" runat="server"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" Runat="Server">
     <li>
     <i class="fa fa-home"></i>
     <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
     <i class="fa fa-angle-right"></i>
 </li>
 <li>
     <asp:HyperLink ID="hlEmployeeName" runat="server" NavigateUrl="~/AdminPanel/Employee/EMP_EmployeeDetail/EMP_EmployeeDetailList.aspx" Text="Employee Detail List"></asp:HyperLink>
     <i class="fa fa-angle-right"></i>
 </li>
 <li class="active">
     <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Employee Detail Add/Edit More"></asp:Label>
 </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" Runat="Server">
         <!--Help Text-->
 <ucHelp:ShowHelp ID="ucHelp" runat="server" />
 <!--Help Text End-->
 <asp:ScriptManager ID="sm" runat="server">
 </asp:ScriptManager>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
     <ContentTemplate>

         <asp:UpdatePanel ID="upMST_EmployeeName" runat="server" EnableViewState="true" UpdateMode="Always">
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
                                             <asp:Label ID="lblEmployeeName_XXXXX" runat="server" Text="Expense Type"></asp:Label>
                                         </label>
                                     </div>
                                     <div class="col-md-3 text-start">
                                         <label class=" control-label">
                                             <span class="required">*</span>
                                             <asp:Label ID="lblEmployeeTypeID_XXXXX" runat="server" Text="Employee Type"></asp:Label>
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
                                                 <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control" PlaceHolder="Enter Expense Type"></asp:TextBox>
                                                 <%--<asp:RequiredFieldValidator ID="rfvEmployeeName" visible="true" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtEmployeeName" ErrorMessage="Enter Expense Type"></asp:RequiredFieldValidator>--%>
                                             </div>
                                         </div>
                                     </div>
                                     <div class="col-md-3">
                                         <div class="form-group">
                                             <div class="input-group">
                                                 <span class="input-group-addon">
                                                     <i class="fa fa-plus"></i>
                                                 </span>
                                                 <asp:DropDownList ID="ddlEmployeeTypeID" runat="server" CssClass="form-control select2me">
                                                 </asp:DropDownList>
                                                 <%--<asp:RequiredFieldValidator ID="rfvEmployeeTypeID" visible="true" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlEmployeeTypeID" ErrorMessage="Select EmployeeType" InitialValue="-99"></asp:RequiredFieldValidator>--%>
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
                                                             <asp:Label ID="lbhEmployeeNameID" runat="server" Text="Expense Type"></asp:Label>
                                                         </th>
                                                         <th>
                                                             <asp:Label ID="lbhEmployeeTypeID" runat="server" Text="EmployeeType"></asp:Label>
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
                                                                     <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName") %>'></asp:Label>
                                                                 </td>
                                                                 <td>
                                                                     <asp:Label ID="lblEmployeeType" runat="server" Text='<%#Eval("EmployeeType") %>'></asp:Label>
                                                                     <asp:HiddenField ID="hfEmployeeTypeID" runat="server" Value='<%#Eval("EmployeeTypeID") %>' />
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
                                                     <asp:HyperLink ID="hlCancel" runat="server" NavigateUrl="~/AdminPanel/Employee/EMP_EmployeeDetail/EMP_EmployeeDetailList.aspx" SkinID="hlCancel"></asp:HyperLink>
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
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

