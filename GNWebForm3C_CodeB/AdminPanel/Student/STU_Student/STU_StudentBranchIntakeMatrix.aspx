<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="STU_StudentBranchIntakeMatrix.aspx.cs" Inherits="AdminPanel_Student_STU_Student_STU_StudentBranchIntakeMatrix" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Branch Intake Matrix" runat="server"></asp:Label>
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
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Branch Intake"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="upMasterDashboard" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:UpdatePanel ID="upMasterDashboard2" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
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

                        <div class="portlet-body form" style="display: block;">
                            <div class="" role="form">
                                <div class="form-body">
                                    <div class="table-responsive">
                                        <div id="TableContent1">
                                            <asp:Label runat="server" ID="Label1"></asp:Label>
                                            <table class="table table-bordered table-advanced table-striped " id="tblIncomeList">
                                                <%-- Table Header --%>
                                                <thead>
                                                    <tr class="TRDark">
                                                        <asp:Repeater ID="rpAddmissionYearHead" runat="server">
                                                            <ItemTemplate>
                                                                <th class="text-center">
                                                                    <asp:Label ID="lblMonth" runat="server" Text='<%#Container.DataItem %>'></asp:Label>
                                                                </th>
                                                            </ItemTemplate>
                                                        </asp:Repeater>

                                                    </tr>
                                                </thead>
                                                <%-- END Table Header --%>

                                                <tbody>
                                                    <asp:Repeater ID="rpIntakeData" runat="server" OnItemDataBound="rpIntake_ItemDataBound">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td class="text-center">
                                                                    <%# Eval("Branch") %>
                                                                </td>
                                                                <asp:Repeater ID="rpAddmissionYearBody" runat="server" OnItemDataBound="rpAddmissionYearBody_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <td class="text-right form-group">
                                                                            <div class="form-group">
                                                                                <asp:TextBox ID="TextBoxTemplate" CssClass="form-control" runat="server"  onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter Intake"></asp:TextBox>
                                                                                <%--                                                                                <asp:RequiredFieldValidator ID="rvfContactNo" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Enter Contact No"></asp:RequiredFieldValidator>--%>
                                                                            </div>
                                                                        </td>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-actions">
                                    <div class="row">
                                        <div class="col-md-offset-3 col-md-9">
                                            <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                                            <asp:Button ID="btnClear" runat="server" SkinID="btnClear" Text="Clear" OnClick="btnClear_Click" />
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
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>
