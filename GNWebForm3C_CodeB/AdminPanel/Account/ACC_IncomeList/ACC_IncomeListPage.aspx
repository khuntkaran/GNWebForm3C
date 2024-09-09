<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="ACC_IncomeListPage.aspx.cs" Inherits="AdminPanel_Account_ACC_IncomeList_ACC_IncomeListPage" %>

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
                                            <table class="table table-bordered table-advanced table-striped">
                                                <thead>
                                                    <tr class="TRDark">
                                                        <th style="width: 5%;" class="text-center">Action</th>
                                                        <th>Hospital</th>
                                                        <th>PrintName</th>
                                                        <th>PrintLine1</th>
                                                        <th>Remarks</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>

                                        <ItemTemplate>
                                            <tr>
                                                <td class="text-center">
                                                    <asp:Button ID="btnShowFinYears" runat="server" CssClass="btn btn-transparent rounded btn-xs btn-outline green-jungle active tooltips rounded-button" ClientIDMode="Static" Text="+" CommandName="LoadFinYears" CommandArgument='<%# Eval("HospitalID") %>' />
                                                </td>
                                                <td><%# Eval("Hospital") %></td>
                                                <td><%# Eval("PrintName") %></td>
                                                <td><%# Eval("PrintLine1") %></td>
                                                <td><%# Eval("Remarks") %></td>
                                                <asp:HiddenField ID="hdnHospitalID" runat="server" Value='<%# Eval("HospitalID") %>' />
                                            </tr>
                                            <asp:Panel ID="pnlFinYears" runat="server" Visible="false">
                                                <!-- Financial Year Repeater -->
                                                <tr id="" display="none">
                                                    <td></td>
                                                    <td colspan="4">
                                                        <div>
                                                            <asp:Repeater ID="rptFinYears" runat="server" OnItemCommand="rptFinYears_ItemCommand">
                                                                <HeaderTemplate>
                                                                    <table class="table table-bordered table-striped">
                                                                        <thead>
                                                                            <tr class="TRDark">
                                                                                <th style="width: 5%;" class="text-center">Action</th>

                                                                                <th>Financial Year</th>
                                                                                <th>FromDate</th>
                                                                                <th>ToDate</th>
                                                                                <th>Remarks</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                </HeaderTemplate>

                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Button ID="btnShowIncomes" runat="server" class="text-center" CssClass="btn btn-transparent rounded btn-xs btn-outline green-jungle active tooltips rounded-button" Text="+" CommandName="LoadIncomes" CommandArgument='<%# Eval("FinYearID") %>' />
                                                                        </td>
                                                                        <td><%# Eval("FinYearName") %></td>
                                                                        <td><%# Eval("FromDate",GNForm3C.CV.DefaultDateFormatForGrid) %></td>
                                                                        <td><%# Eval("ToDate",GNForm3C.CV.DefaultDateFormatForGrid) %></td>
                                                                        <td><%# Eval("Remarks") %></td>

                                                                    </tr>

                                                                    <asp:Panel ID="pnlIncomes" runat="server" Visible="false">
                                                                        <!-- Income Repeater -->
                                                                        <tr>
                                                                            <td></td>
                                                                            <td colspan="4">
                                                                                <asp:Repeater ID="rptIncomes" runat="server">
                                                                                    <HeaderTemplate>
                                                                                        <table class="table table-bordered table-advanced table-striped table-hover">
                                                                                            <thead>
                                                                                                <tr class="TRDark">
                                                                                                    <th class="text-center">Sr.</th>
                                                                                                    <th>Income Type</th>
                                                                                                    <th class="text-right">Amount</th>
                                                                                                    <th>Date</th>
                                                                                                    <th>Note</th>
                                                                                                </tr>
                                                                                            </thead>
                                                                                            <tbody>
                                                                                    </HeaderTemplate>

                                                                                    <ItemTemplate>
                                                                                        <tr>
                                                                                            <td class="text-center"><%# Container.ItemIndex+1 %></td>
                                                                                            <td><%# Eval("IncomeType") %></td>
                                                                                            <td class="text-right"><%# Eval("Amount",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint) %></td>
                                                                                            <td><%# Eval("IncomeDate",GNForm3C.CV.DefaultDateFormatForGrid) %></td>
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


</script>
</asp:Content>
