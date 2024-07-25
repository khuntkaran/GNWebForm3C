﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="MasterDashboard.aspx.cs" Inherits="AdminPanel_MasterDashboard" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="MasterDashboard" runat="server"></asp:Label>
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
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="MasterDashboard"></asp:Label>
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
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
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
                        <div class="portlet-body form">
                            <div class="form-horizontal" role="form">
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <span class="required">*</span>
                                            <asp:Label ID="lblHospitalID_XXXXX" runat="server" Text="Hospital"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvHospitalID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlHospitalID" ErrorMessage="Select Hospital" InitialValue="-99"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Button ID="btnShow" runat="server" SkinID="btnShow" OnClick="btnShow_Click" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

            <div runat="server" id="Div_ShowResult" visible="false">

                <asp:UpdatePanel ID="upCount" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">

                    <ContentTemplate>

                        <div class="portlet light">
                            <div class="portlet-title">
                                <div class="caption font-green">
                                    <i class="fa fa-line-chart font-green"></i>
                                    <span class="caption-subject bold uppercase">This Year Overview</span>
                                </div>
                                <div class="tools"></div>
                            </div>
                            <div class="portlet-body form">
                                <div class="form-horizontal" role="form">
                                    <div class="form-body">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                                <a class="dashboard-stat dashboard-stat-v2 blue" href="Account/ACC_Income/ACC_IncomeList.aspx">
                                                    <div class="visual">
                                                        <i class="fa fa-comments"></i>
                                                    </div>
                                                    <div class="details">
                                                        <div class="number">
                                                            <asp:Label runat="server" ID="lblTotalIncome"></asp:Label>
                                                        </div>
                                                        <div class="desc">Incomes </div>
                                                    </div>
                                                </a>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                                <a class="dashboard-stat dashboard-stat-v2 red" href="Account/ACC_Expense/ACC_ExpenseList.aspx">
                                                    <div class="visual">
                                                        <i class="fa fa-list"></i>
                                                    </div>
                                                    <div class="details">
                                                        <div class="number">
                                                            <asp:Label runat="server" ID="lblTotalExpense"></asp:Label>
                                                        </div>
                                                        <div class="desc">Expenses</div>
                                                    </div>
                                                </a>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                                <a class="dashboard-stat dashboard-stat-v2 green" href="Account/ACC_Transaction/ACC_TransactionList.aspx">
                                                    <div class="visual">
                                                        <i class="fa fa-shopping-cart"></i>
                                                    </div>
                                                    <div class="details">
                                                        <div class="number">
                                                            <asp:Label runat="server" ID="lblTotalPatientAmount"></asp:Label>
                                                        </div>
                                                        <div class="desc">Total Patient Amount </div>
                                                    </div>
                                                </a>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                    </ContentTemplate>
                </asp:UpdatePanel>

                <%--<asp:GridView ID="gvIncomeData" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                    <Columns>
                        <asp:BoundField DataField="Day" HeaderText="Day" />
                        <asp:BoundField DataField="January" HeaderText="January" />
                        <asp:BoundField DataField="February" HeaderText="February" />
                        <asp:BoundField DataField="March" HeaderText="March" />
                        <asp:BoundField DataField="April" HeaderText="April" />
                        <asp:BoundField DataField="May" HeaderText="May" />
                        <asp:BoundField DataField="June" HeaderText="June" />
                        <asp:BoundField DataField="July" HeaderText="July" />
                        <asp:BoundField DataField="August" HeaderText="August" />
                        <asp:BoundField DataField="September" HeaderText="September" />
                        <asp:BoundField DataField="October" HeaderText="October" />
                        <asp:BoundField DataField="November" HeaderText="November" />
                        <asp:BoundField DataField="December" HeaderText="December" />
                    </Columns>
                </asp:GridView>--%>


                <asp:UpdatePanel ID="UpList" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <div class="portlet">
                            <div class="portlet-body form">
                                <div class="form-horizontal" role="form">
                                    <div class="form-body">
                                        <div class="row ">
                                            <div class="col-md-12">
                                                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                <div class="portlet box blue">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <i class="fa fa-bullhorn "></i>This Year INCOMES 
                                                        </div>
                                                        <div class="tools">
                                                            <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body" style="display: block;">
                                                        <div class="table-responsive">
                                                            <div id="TableContent1">
                                                                <table class="table table-bordered table-advanced table-striped table-hover" id="sample11">
                                                                    <%-- Table Header --%>
                                                                    <thead>
                                                                        <tr class="TRDark">
                                                                            <th class="text-center">Date
                                                                            </th>
                                                                            <asp:Repeater ID="rpIncomeMonth" runat="server">
                                                                                <ItemTemplate>
                                                                                    <th class="text-center">
                                                                                        <asp:Label ID="lblMonth" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                                                                                    </th>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>

                                                                        </tr>
                                                                    </thead>
                                                                    <%-- END Table Header --%>
                                                                    <tbody>
                                                                        <asp:Repeater ID="rpIncomeData" runat="server">
                                                                            <%--OnItemDataBound="rpIncome_ItemDataBound"--%>
                                                                            <ItemTemplate>
                                                                                <tr>
                                                                                    <!-- Example Date Column -->
                                                                                    <td class="text-center">
                                                                                        <%# Eval("Day") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("January") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("February") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("March") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("April") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("May") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("June") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("July") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("August") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("September") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("October") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("November") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("December") %>
                                                                                    </td>
                                                                                    <%-- <!-- Inner Repeater for Months -->

                                                                    <asp:Repeater ID="rpMonthValues" runat="server">
                                                                        <ItemTemplate>
                                                                            <td class="text-center">
                                                                                <%# Container.DataItem %>
                                                                                <!-- Display value for month -->
                                                                                <!-- Use the month name from the outer repeater -->
                                                                                <!-- Replace with your actual data field -->
                                                                            </td>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>--%>
                                                                                </tr>
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>

                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row ">
                                            <div class="col-md-12">
                                                <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                <div class="portlet box red">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <i class="fa fa-bullhorn "></i>This Year Expense 
                                                        </div>
                                                        <div class="tools">
                                                            <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body" style="display: block;">
                                                        <div class="table-responsive">
                                                            <div id="TableContent1">
                                                                <table class="table table-bordered table-advanced table-striped table-hover" id="sample11">
                                                                    <%-- Table Header --%>
                                                                    <thead>
                                                                        <tr class="TRDark">
                                                                            <th class="text-center">Date
                                                                            </th>
                                                                            <asp:Repeater ID="rpExpenseMonth" runat="server">
                                                                                <ItemTemplate>
                                                                                    <th class="text-center">
                                                                                        <asp:Label ID="lblMonth" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                                                                                    </th>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>

                                                                        </tr>
                                                                    </thead>
                                                                    <%-- END Table Header --%>
                                                                    <tbody>
                                                                        <asp:Repeater ID="rpExpenseData" runat="server">
                                                                            <ItemTemplate>
                                                                                <tr>
                                                                                    <!-- Example Date Column -->
                                                                                    <td class="text-center">
                                                                                        <%# Eval("Day") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("January") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("February") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("March") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("April") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("May") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("June") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("July") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("August") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("September") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("October") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("November") %>
                                                                                    </td>
                                                                                    <td class="text-center">
                                                                                        <%# Eval("December") %>
                                                                                    </td>
                                                                                </tr>
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>

                                                                    </tbody>
                                                                </table>
                                                            </div>
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

                

                <asp:UpdatePanel ID="upTreatment" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <div class="portlet-body table-both-scroll">
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption font-green">
                                        <i class="fa fa-line-chart font-green"></i>
                                        <span class="caption-subject bold uppercase">Treatment Type Summary (This Year)</span>
                                    </div>
                                    <div class="tools"></div>
                                </div>
                                <div class="portlet-body">
                                    <div class="tab-content">

                                        <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                            <%-- Table Header --%>
                                            <thead>
                                                <tr class="TRDark">
                                                    <th class="text-center" style="width: 20px;">
                                                        <asp:Label ID="lblSrNo" runat="server" Text="Sr."></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhTreatmentType" runat="server" Text="Treatment Type"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="lbhPatientCount" runat="server" Text="Patient Count"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="lbhIncomeAmount" runat="server" Text="Income Amount"></asp:Label>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <%-- END Table Header --%>

                                            <tbody>
                                                <asp:Repeater ID="rpTreatmentTypeData" runat="server">
                                                    <ItemTemplate>
                                                        <%-- Table Rows --%>
                                                        <tr class="odd gradeX">
                                                            <td class="text-center">
                                                                <%#Container.ItemIndex+1 %>
                                                            </td>
                                                            <td class="text-center">
                                                                <%#Eval("TreatmentType") %>
                                                            </td>
                                                            <td>
                                                                <%#Eval("PatientCount") %>
                                                            </td>
                                                            <td>
                                                                <%#Eval("IncomeAmount") %>
                                                            </td>
                                                        </tr>
                                                        <%-- END Table Rows --%>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>

                </asp:UpdatePanel>


            </div>
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

