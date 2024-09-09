﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="ACC_IncomeListPage.aspx.cs" Inherits="AdminPanel_Account_ACC_IncomeList_ACC_IncomeListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" runat="server" Text="Income List"></asp:Label>
    <small>
        <asp:Label ID="lblPageHeaderInfo_XXXXX" runat="server" Text="Account"></asp:Label></small>
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
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Income List"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>

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
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row" runat="server" id="Div_SearchResult">
                                <div class="col-md-12">
                                    <!-- Nested Repeater for Hospitals, Financial Years, and Incomes -->
                                    <asp:Repeater ID="rptHospitals" runat="server" OnItemCommand="rptHospitals_ItemCommand">
                                        <HeaderTemplate>
                                            <table class="table table-bordered  ">
                                                <thead>
                                                    <tr>
                                                        <th style="width: 5%;">Action</th>
                                                        <th>Hospital</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>

                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnShowFinYears" runat="server" ClientIDMode="Static" Text="+" CommandName="LoadFinYears" CommandArgument='<%# Eval("HospitalID") %>' />
                                                </td>
                                                <td><%# Eval("Hospital") %></td>
                                                <asp:HiddenField ID="hdnHospitalID" runat="server" Value='<%# Eval("HospitalID") %>' />
                                            </tr>
                                            <asp:Panel ID="pnlFinYears" runat="server" Visible="false">
                                                <!-- Financial Year Repeater -->
                                                <tr id="" display="none">
                                                    <td></td>
                                                    <td colspan="">
                                                        <div>
                                                            <asp:Repeater ID="rptFinYears" runat="server" OnItemCommand="rptFinYears_ItemCommand">
                                                                <HeaderTemplate>
                                                                    <table class="table table-bordered">
                                                                        <thead>
                                                                            <tr>
                                                                                <th style="width: 5%;">Action</th>

                                                                                <th>Financial Year</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                </HeaderTemplate>

                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button ID="btnShowIncomes" runat="server" Text="+" CommandName="LoadIncomes" CommandArgument='<%# Eval("FinYearID") %>' />
                                                                        </td>
                                                                        <td><%# Eval("FinYearName") %></td>

                                                                    </tr>

                                                                    <asp:Panel ID="pnlIncomes" runat="server" Visible="false">
                                                                        <!-- Income Repeater -->
                                                                        <tr>
                                                                            <td></td>
                                                                            <td colspan="">
                                                                                <asp:Repeater ID="rptIncomes" runat="server">
                                                                                    <HeaderTemplate>
                                                                                        <table class="table table-bordered">
                                                                                            <thead>
                                                                                                <tr>
                                                                                                    <th>Income Type</th>
                                                                                                    <th>Amount</th>
                                                                                                    <th>Date</th>
                                                                                                    <th>Note</th>
                                                                                                </tr>
                                                                                            </thead>
                                                                                            <tbody>
                                                                                    </HeaderTemplate>

                                                                                    <ItemTemplate>
                                                                                        <tr>
                                                                                            <td><%# Eval("IncomeType") %></td>
                                                                                            <td><%# Eval("Amount") %></td>
                                                                                            <td><%# Eval("IncomeDate") %></td>
                                                                                            <td><%# Eval("Note") %></td>
                                                                                        </tr>
                                                                                    </ItemTemplate>

                                                                                    <FooterTemplate>
                                                                                        </tbody>
                                                                                </table>
                                                                                    </FooterTemplate>
                                                                                </asp:Repeater>
                                                                            </td>
                                                                        </tr>
                                                                    </asp:Panel>
                                                                </ItemTemplate>

                                                                <FooterTemplate>
                                                                    </tbody>
                                                                </table>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                        </ItemTemplate>

                                        <FooterTemplate>
                                            </tbody>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END EXAMPLE TABLE PORTLET-->
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
    <%-- END List --%>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
    <script type="text/javascript">
        function toggleButton(btnId, targetDivId) {
            console.log(btnId.value)
            console.log(targetDivId)
            var targetDiv = targetDivId;
            var btn = btnId;

            //if (!targetDiv || !btn) {
            //    console.error("Element not found for either button or div");
            //    return;
            //}

            if (btn.value == "+") {
                //document.getElementById(targetDivId).style.display = "block";
                btn.value = "-";  // Change + to -
            } else {
                // document.getElementById(targetDivId).style.display = "none";
                btn.value = "+";  // Change - back to +
            }
        }

    </script>
</asp:Content>
