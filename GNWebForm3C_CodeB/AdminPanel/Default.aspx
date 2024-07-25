<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="AdminPanel_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Dashboard" runat="server"></asp:Label>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li class="active">
    <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Home"></asp:Label>
</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upCount" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption font-green">
                        <i class="fa fa-line-chart font-green"></i>
                        <span class="caption-subject bold uppercase">Total Overview</span>
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
                                                <asp:Label runat="server" ID="lblIncomeCount"></asp:Label>
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
                                                <asp:Label runat="server" ID="lblExpenseCount"></asp:Label>
                                            </div>
                                            <div class="desc">Expenses</div>
                                        </div>
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <a class="dashboard-stat dashboard-stat-v2 green" href="Master/MST_Hospital/MST_HospitalList.aspx">
                                        <div class="visual">
                                            <i class="fa fa-shopping-cart"></i>
                                        </div>
                                        <div class="details">
                                            <div class="number">
                                                <asp:Label runat="server" ID="lblHospitalCount"></asp:Label>
                                            </div>
                                            <div class="desc">Hospitals </div>
                                        </div>
                                    </a>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <a class="dashboard-stat dashboard-stat-v2 purple" href="Master/MST_FinYear/MST_FinYearList.aspx">
                                        <div class="visual">
                                            <i class="fa fa-globe"></i>
                                        </div>
                                        <div class="details">
                                            <div class="number">
                                                <asp:Label runat="server" ID="lblFinyearCount"></asp:Label>
                                            </div>
                                            <div class="desc">Finyears </div>
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

    <asp:UpdatePanel ID="UpList" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="portlet">
                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                    <div class="portlet box blue">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-bullhorn "></i>RECENT 10 INCOMES
                                            </div>
                                            <div class="tools">
                                                <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                                                <a href="Account/ACC_Income/ACC_IncomeList.aspx"><i class="fa fa-edit font-white"></i></a>
                                            </div>
                                        </div>
                                        <div class="portlet-body" style="display: block;">
                                            <div class="table-responsive">
                                                <div id="TableContent1">
                                                    <table class="table table-bordered table-advanced table-striped table-hover" id="sample11">
                                                        <%-- Table Header --%>
                                                        <thead>
                                                            <tr class="TRDark">
                                                                <th class="text-center" style="width: 20px;">
                                                                    <asp:Label ID="lbhSerialNo" runat="server" Text="Sr."></asp:Label>
                                                                </th>
                                                                <th class="text-center">
                                                                    <asp:Label ID="lblIncomeDate" runat="server" Text="Income Date"></asp:Label>
                                                                </th>
                                                                <th class="text-center">
                                                                    <asp:Label ID="lblIncomeHospital" runat="server" Text="Hospital"></asp:Label>
                                                                </th>
                                                                <th class="text-center">
                                                                    <asp:Label ID="lblIncomeType" runat="server" Text="IncomeType"></asp:Label>
                                                                </th>
                                                                <th class="text-right">
                                                                    <asp:Label ID="lblIncomeAmount" runat="server" Text="Amount"></asp:Label>
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <%-- END Table Header --%>
                                                        <tbody>
                                                            <asp:Repeater ID="rpIncome" runat="server">
                                                                <ItemTemplate>
                                                                    <%-- Table Rows --%>
                                                                    <tr class="odd gradeX">
                                                                        <td class="text-center">
                                                                            <%#Container.ItemIndex+1 %>
                                                                        </td>
                                                                        <td class="text-center">
                                                                            <%#Eval("IncomeDate", GNForm3C.CV.DefaultDateFormatForGrid) %>
                                                                        </td>
                                                                        <td class="text-center">
                                                                            <%#Eval("Hospital") %>
                                                                        </td>
                                                                        <td class="text-center">
                                                                            <%#Eval("IncomeType") %>
                                                                        </td>
                                                                        <td class="text-right">
                                                                            <%#Eval("Amount",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint) %>
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
                                </div>
                                <div class="col-md-6">
                                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                    <div class="portlet box red">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-bullhorn "></i>RECENT 10 EXPENSE
                                            </div>
                                            <div class="tools">
                                                <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                                                <a href="Account/ACC_Expense/ACC_ExpenseList.aspx"><i class="fa fa-edit font-white"></i></a>
                                            </div>
                                        </div>
                                        <div class="portlet-body" style="display: block;">
                                            <div class="table-responsive">
                                                <div id="TableContent2">
                                                    <table class="table table-bordered table-advanced table-striped table-hover" id="sample12">
                                                        <%-- Table Header --%>
                                                        <thead>
                                                            <tr class="TRDark">
                                                                <th class="text-center" style="width: 20px;">
                                                                    <asp:Label ID="lblSrNo" runat="server" Text="Sr."></asp:Label>
                                                                </th>
                                                                <th class="text-center">
                                                                    <asp:Label ID="lblExpenseDate" runat="server" Text="Expense Date"></asp:Label>
                                                                </th>
                                                                <th class="text-center">
                                                                    <asp:Label ID="lblExpenseHospital" runat="server" Text="Hospital"></asp:Label>
                                                                </th>
                                                                <th class="text-center">
                                                                    <asp:Label ID="lblExpenseType" runat="server" Text="ExpenseType"></asp:Label>
                                                                </th>
                                                                <th class="text-right">
                                                                    <asp:Label ID="lblExpenseAmount" runat="server" Text="Amount"></asp:Label>
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <%-- END Table Header --%>
                                                        <tbody>
                                                            <asp:Repeater ID="rpExpense" runat="server">
                                                                <ItemTemplate>
                                                                    <%-- Table Rows --%>
                                                                    <tr class="odd gradeX">
                                                                        <td class="text-center">
                                                                            <%#Container.ItemIndex+1 %>
                                                                        </td>
                                                                        <td class="text-center">
                                                                            <%#Eval("ExpenseDate", GNForm3C.CV.DefaultDateFormatForGrid) %>
                                                                        </td>
                                                                        <td class="text-center">
                                                                            <%#Eval("Hospital") %>
                                                                        </td>
                                                                        <td class="text-center">
                                                                            <%#Eval("ExpenseType") %>
                                                                        </td>
                                                                        <td class="text-right">
                                                                            <%#Eval("Amount",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint) %>
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
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpLinks" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="portlet">
                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                    <div class="portlet box green">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-external-link "></i></i>Quick Links
                                            </div>
                                            <div class="tools">
                                                <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                                            </div>

                                        </div>
                                        <div class="portlet-body" style="display: block;">
                                            <div class="tools ">
                                                <ul class="nav nav-tabs">
                                                    <li class="active">
                                                        <a href="#tab_1_1" class="active menu-toggler font-green" data-toggle="tab" aria-expanded="false">List Pages</a>
                                                    </li>
                                                    <li class="">
                                                        <a href="#tab_1_2" class="font-green" data-toggle="tab" aria-expanded="true">Add Pages </a>
                                                    </li>
                                                </ul>
                                            </div>
                                            <div class="portlet-body table-both-scroll">
                                                <div class="portlet light ">
                                                    <div class="portlet-body">
                                                        <!--BEGIN TABS-->
                                                        <div class="tab-content">
                                                            <div class=" active tab-pane " id="tab_1_1">
                                                                <div class="tiles">
                                                                    <a href="Master/MST_ExpenseType/MST_ExpenseTypeList.aspx">
                                                                        <div class="tile bg-blue">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-list"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Expense Type </div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Master/MST_FinYear/MST_FinYearList.aspx">
                                                                        <div class="tile bg-red">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-list"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Financial Year</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Master/MST_Hospital/MST_HospitalList.aspx">
                                                                        <div class="tile bg-green">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-list"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Hospital</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Master/MST_IncomeType/MST_IncomeTypeList.aspx">
                                                                        <div class="tile bg-purple">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-list"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">MstIncome</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Master/MST_SubTreatment/MST_SubTreatmentList.aspx">
                                                                        <div class="tile bg-yellow">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-list"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Sub Treatment</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Master/MST_Treatment/MST_TreatmentList.aspx">
                                                                        <div class="tile bg-blue">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-list"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Treatment</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Master/MST_ReceiptType/MST_ReceiptTypeList.aspx">
                                                                        <div class="tile bg-red">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-list"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">ReceiptType</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Account/ACC_Expense/ACC_ExpenseList.aspx">
                                                                        <div class="tile bg-green">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-list"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Expenses</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Account/ACC_Income/ACC_IncomeList.aspx">
                                                                        <div class="tile bg-purple">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-list"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">AccIncome</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Account/ACC_Transaction/ACC_TransactionList.aspx">
                                                                        <div class="tile bg-yellow">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-list"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Transaction</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Account/ACC_TransactionTran/ACC_TransactionTranList.aspx">
                                                                        <div class="tile bg-blue">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-list"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Transaction Tran</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Config/CFG_ReportSetting/CFG_ReportSettingList.aspx">
                                                                        <div class="tile bg-red">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-list"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Report Setting</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Config/CFG_SoftwareConfiguration/CFG_SoftwareConfigurationList.aspx">
                                                                        <div class="tile bg-green">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-list"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Software Configuration</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Security/SEC_Menu/SEC_MenuList.aspx">
                                                                        <div class="tile bg-purple">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-list"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Security Menu</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Security/SEC_User/SEC_UserList.aspx">
                                                                        <div class="tile bg-yellow">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-list"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Security User</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                </div>
                                                            </div>
                                                            <div class="tab-pane " id="tab_1_2">
                                                                <div class="tiles">
                                                                    <a href="Master/MST_ExpenseType/MST_ExpenseTypeAddEdit.aspx">
                                                                        <div class="tile bg-blue">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-edit"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Expense Type </div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Master/MST_FinYear/MST_FinYearAddEdit.aspx">
                                                                        <div class="tile bg-red">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-edit"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Financial Year</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Master/MST_Hospital/MST_HospitalAddEdit.aspx">
                                                                        <div class="tile bg-green">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-edit"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Hospital</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Master/MST_IncomeType/MST_IncomeTypeAddEdit.aspx">
                                                                        <div class="tile bg-purple">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-edit"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">MstIncome</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Master/MST_SubTreatment/MST_SubTreatmentAddEdit.aspx">
                                                                        <div class="tile bg-yellow">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-edit"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Sub Treatment</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Master/MST_Treatment/MST_TreatmentAddEdit.aspx">
                                                                        <div class="tile bg-blue">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-edit"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Treatment</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Master/MST_ReceiptType/MST_ReceiptTypeAddEdit.aspx">
                                                                        <div class="tile bg-red">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-edit"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">ReceiptType</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Account/ACC_Expense/ACC_ExpenseAddEdit.aspx">
                                                                        <div class="tile bg-green">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-edit"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Expenses</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Account/ACC_Income/ACC_IncomeAddEdit.aspx">
                                                                        <div class="tile bg-purple">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-edit"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">AccIncome</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Account/ACC_Transaction/ACC_TransactionAddEdit.aspx">
                                                                        <div class="tile bg-yellow">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-edit"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Transaction</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Account/ACC_TransactionTran/ACC_TransactionTranAddEdit.aspx">
                                                                        <div class="tile bg-blue">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-edit"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Transaction Tran</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Config/CFG_ReportSetting/CFG_ReportSettingAddEdit.aspx">
                                                                        <div class="tile bg-red">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-edit"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Report Setting</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Config/CFG_SoftwareConfiguration/CFG_SoftwareConfigurationAddEdit.aspx">
                                                                        <div class="tile bg-green">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-edit"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Software Configuration</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Security/SEC_Menu/SEC_MenuAddEdit.aspx">
                                                                        <div class="tile bg-purple">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-edit"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Security Menu</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                    <a href="Security/SEC_User/SEC_UserAddEdit.aspx">
                                                                        <div class="tile bg-yellow">
                                                                            <div class="tile-body">
                                                                                <i class="fa fa-edit"></i>
                                                                            </div>
                                                                            <div class="tile-object">
                                                                                <div class="name">Security User</div>
                                                                                <div class="number"></div>
                                                                            </div>
                                                                        </div>
                                                                    </a>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <!--END TABS-->
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="portlet">
                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                    <div class="portlet box yellow">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <i class="fa fa-h-square "></i></i>Hospital Wise ExpenseType TabView
                                            </div>
                                            <div class="tools">
                                                <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                                            </div>
                                        </div>
                                        <div class="portlet-body" style="display: block;">
                                            <div class="tools ">
                                                <ul class="nav nav-tabs">
                                                    <asp:Repeater ID="rpCol" runat="server">
                                                        <ItemTemplate>
                                                            <li class='<%#Container.ItemIndex == 0 ? "active" : ""%>'>
                                                                <asp:LinkButton ID="lbtnCol" runat="server" href='<%#"#tab_Inc_" + Eval("HospitalID").ToString()%>' Text='<%#Eval("Hospital") %>' data-toggle="tab"></asp:LinkButton>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>
                                            <div class="portlet-body table-both-scroll">
                                                <div class="portlet light ">
                                                    <div class="portlet-body">
                                                        <div class="tab-content">
                                                            <asp:Repeater ID="rpActive" runat="server">
                                                                <ItemTemplate>
                                                                    <div class='<%#Container.ItemIndex == 0 ? "tab-pane active" : "tab-pane"%>' id='<%#"tab_Inc_" + Eval("HospitalID").ToString()%>'>
                                                                        <asp:HiddenField ID="hfHospitalID" runat="server" Value='<%#Eval("HospitalID")%>' />
                                                                        <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                                                            <%-- Table Header --%>
                                                                            <thead>
                                                                                <tr class="TRDark">
                                                                                    <th>
                                                                                        <asp:Label ID="lbhExpenseTypeID" runat="server" Text="Expense Type"></asp:Label>
                                                                                    </th>
                                                                                    <th class="text-right">
                                                                                        <asp:Label ID="lbhAmount" runat="server" Text="Amount"></asp:Label>
                                                                                    </th>
                                                                                    <th class="text-center">
                                                                                        <asp:Label ID="lbhExpenseDate" runat="server" Text="Expense Date"></asp:Label>
                                                                                    </th>
                                                                                    <th>
                                                                                        <asp:Label ID="lbhHospitalID" runat="server" Text="Hospital"></asp:Label>
                                                                                    </th>
                                                                                    <th>
                                                                                        <asp:Label ID="lbhFinYearID" runat="server" Text="Fin Year"></asp:Label>
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <%-- END Table Header --%>

                                                                            <tbody>
                                                                                <asp:Repeater ID="rpData" runat="server">
                                                                                    <ItemTemplate>
                                                                                        <%-- Table Rows --%>
                                                                                        <tr class="odd gradeX">
                                                                                            <td>
                                                                                                <asp:HyperLink ID="hlViewExpenseID" NavigateUrl='<%# "~/AdminPanel/Account/ACC_Expense/ACC_ExpenseView.aspx?ExpenseID=" + GNForm3C.CommonFunctions.EncryptBase64(Eval("ExpenseID").ToString()) %>' data-target="#viewiFrameReg" CssClass="modalButton" data-toggle="modal" runat="server"><%#Eval("ExpenseType") %></asp:HyperLink>
                                                                                            </td>
                                                                                            <td class="text-right">
                                                                                                <%#Eval("Amount",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint) %>
                                                                                            </td>
                                                                                            <td class="text-center">
                                                                                                <%#Eval("ExpenseDate", GNForm3C.CV.DefaultDateFormatForGrid) %>
                                                                                            </td>
                                                                                            <td>
                                                                                                <%#Eval("Hospital") %>
                                                                                            </td>
                                                                                            <td>
                                                                                                <%#Eval("FinYearName") %>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <%-- END Table Rows --%>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
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
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

