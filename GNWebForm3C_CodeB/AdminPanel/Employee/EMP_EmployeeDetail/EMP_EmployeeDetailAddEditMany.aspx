<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="EMP_EmployeeDetailAddEditMany.aspx.cs" Inherits="AdminPanel_Employee_EMP_EmployeeDetail_EMP_EmployeeDetailAddEditMany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" Runat="Server">
     <asp:Label ID="lblPageHeader_XXXXX" Text="Employee Detail " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Employee" runat="server"></asp:Label></small>
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
     <asp:HyperLink ID="hlEmployeeName" runat="server" NavigateUrl="~/AdminPanel/Employee/EMP_EmployeeDetail/EMP_EmployeeDetailListMany.aspx" Text="Employee Detail List"></asp:HyperLink>
     <i class="fa fa-angle-right"></i>
 </li>
 <li class="active">
     <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Employee Detail Add/Edit"></asp:Label>
 </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" Runat="Server">
     <!--Help Text-->
 <ucHelp:ShowHelp ID="ucHelp" runat="server" />
 <!--Help Text End-->
 <asp:ScriptManager ID="sm" runat="server">
 </asp:ScriptManager>
 <asp:UpdatePanel ID="upEMP_EmployeeDetail" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
     <Triggers>
         <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
     </Triggers>
     <ContentTemplate>
         <asp:UpdatePanel ID="upEMP_EmployeeDetail2" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">

             <ContentTemplate>
                 <div class="row">
                     <div class="col-md-12">
                         <ucMessage:ShowMessage ID="ucMessage" runat="server" />
                         <asp:ValidationSummary ID="ValidationSummary1" SkinID="VS" runat="server" />
                     </div>
                 </div>

                 <div class="portlet light">
                     <div class="portlet-title">
                         <div class="caption">
                             <asp:Label SkinID="lblFormHeaderIcon" ID="lblFormHeaderIcon" runat="server"></asp:Label>
                             <span class="caption-subject font-green-sharp bold uppercase">
                                 <asp:Label ID="lblFormHeader" runat="server" Text=""></asp:Label>
                             </span>
                         </div>
                     </div>
                     <div class="portlet-body form">
                         <div class="form-horizontal" role="form">
                             <div class="form-body">
                                 <div class="form-group">
                                     <label class="col-md-3 control-label">
                                 </div>
                                 <div class="form-group">
                                     <label class="col-md-3 control-label">
                                         <span class="required">*</span>
                                         <asp:Label ID="lblEmployeeTypeID_XXXXX" runat="server" Text="EmployeeType"></asp:Label>
                                     </label>
                                     <div class="col-md-5">
                                         <asp:DropDownList ID="ddlEmployeeTypeID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="rfvEmployeeTypeID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlEmployeeTypeID" ErrorMessage="Select EmployeeType" InitialValue="-99"></asp:RequiredFieldValidator>
                                     </div>
                                     <div class="col-md-4">
                                         <asp:Button ID="btnShow" runat="server" SkinID="btnShow" OnClick="btnShow_Click" />
                                         <asp:HyperLink ID="hlCancel1" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Employee/EMP_EmployeeDetail/EMP_EmployeeDetailList.aspx"></asp:HyperLink>
                                     </div>
                                 </div>
                             </div>

                         </div>
                     </div>
                 </label>
		
             </ContentTemplate>
         </asp:UpdatePanel>

         <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">
             <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                 <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
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
                         <div class="portlet light" runat="server" id="Div_ShowResult" visible="false">
                             <div class="portlet-title">
                                 <div class="caption">
                                     <asp:Label SkinID="lblSearchResultHeaderIcon" runat="server"></asp:Label>
                                     <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                                     <label class="control-label">&nbsp;</label>
                                 </div>

                             </div>

                             <div class="portlet-body">
                                 <div class="row" runat="server">
                                     <div class="col-md-12">
                                         <div id="TableContent">
                                             <table class="table table-border    ed table-advanced table-striped table-hover" id="sample_1">
                                                 <%-- Table Header --%>
                                                 <thead>
                                                     <tr class="TRDark">
                                                         <th class="text-center" style="width: 20px;">
                                                             <asp:Label ID="lblIsSelected" runat="server" Text="IsSelected"></asp:Label>
                                                         </th>
                                                         <th class="text-center" style="width: 20px;">
                                                             <asp:Label ID="lbhSerialNo" runat="server" Text="Sr."></asp:Label>
                                                         </th>
                                                         <th>
                                                             <asp:Label ID="lbhEmployeeName" runat="server" Text="Employee Detail"></asp:Label>
                                                         </th>
                                                         <th>
                                                             <asp:Label ID="lbhRemarks" runat="server" Text="Remarks"></asp:Label>
                                                         </th>
                                                     </tr>
                                                 </thead>
                                                 <%-- END Table Header --%>

                                                 <tbody>
                                                     <asp:Repeater ID="rpData" runat="server">
                                                         <ItemTemplate>
                                                             <%-- Table Rows --%>
                                                             <tr class="odd gradeX">
                                                                 <td class="text-center">
                                                                     <asp:CheckBox runat="server" ID="chkIsSelected" Checked='<%#Eval("EmployeeName").ToString().Trim() == String.Empty ? false : true %>' />
                                                                 </td>
                                                                 <td class="text-center">
                                                                     <%#Container.ItemIndex+1 %>
                                                                 </td>
                                                                 <td>
                                                                     <asp:TextBox ID="txtEmployeeName" CssClass="form-control" runat="server" Text='<%#Eval("EmployeeName") %>' PlaceHolder="Enter Employee Detail"></asp:TextBox>
                                                                     <%--<asp:RequiredFieldValidator  ID="rfvEmployeeName" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtEmployeeName" ErrorMessage="Enter Employee Detail"></asp:RequiredFieldValidator>--%>
                                                                     <asp:HiddenField ID="hdEmployeeID" runat="server" Value='<%#Eval("EmployeeID ") %>' />
                                                                 </td>
                                                                 <td>
                                                                     <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" Text='<%#Eval("Remarks") %>' PlaceHolder="Enter Remarks"></asp:TextBox>
                                                                 </td>
                                                             </tr>
                                                             <%-- END Table Rows --%>
                                                         </ItemTemplate>
                                                     </asp:Repeater>
                                                 </tbody>
                                             </table>
                                         </div>
                                     </div>
                                     <div class="form-actions" runat="server">
                                         <div class="row">
                                             <div class="col-md-offset-1 col-md-9">
                                                 <asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" SkinID="lbtnAddRow" Visible="true">
                                                 </asp:LinkButton>
                                                 <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                                                 <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Employee/EMP_EmployeeDetail/EMP_EmployeeDetailList.aspx"></asp:HyperLink>
                                             </div>
                                         </div>
                                     </div>
                                 </div>
                             </div>
                         </div>
             </ContentTemplate>
         </asp:UpdatePanel>
     </ContentTemplate>
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

