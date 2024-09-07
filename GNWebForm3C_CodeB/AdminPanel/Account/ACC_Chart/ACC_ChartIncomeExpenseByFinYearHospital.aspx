<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="ACC_ChartIncomeExpenseByFinYearHospital.aspx.cs" Inherits="AdminPanel_Account_ACC_Chart_ACC_ChartIncomeExpenseByFinYearHospital" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" runat="server" Text="Chart"></asp:Label>
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
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Income Expense By FinYear Hospital"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">

    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />


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
                                <asp:Label SkinID="" runat="server"></asp:Label>
                                <asp:Label ID="lblSearchResultHeader" SkinID="" Text="Chart" runat="server"></asp:Label>
                                <label class="control-label">&nbsp;</label>
                                <label class="control-label pull-right">
                                    <asp:Label ID="lblRecordInfoTop" Text="" CssClass="pull-right" runat="server"></asp:Label>
                                </label>
                            </div>

                        </div>
                        <div class="portlet-body">
                            <div class="row" runat="server" id="Div_SearchResult" visible="true">
                                <div class="col-md-12">
                                    <div id="form1" runat="server">
                                        <asp:Repeater ID="rptHospitalCharts" runat="server">
                                            <ItemTemplate>
                                                <div>
                                                    <!-- Assign a unique ID for the chart div based on HospitalID -->
                                                    <div id="chart_div_<%# Eval("HospitalID") %>" ></div>
                                                </div>
                                                <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
                                                <!-- Store the hospital data in a JavaScript array -->
                                                <script type="text/javascript">
                                                    // Store hospital data in a global array
                                                    window.hospitalChartsData = window.hospitalChartsData || [];
                                                    window.hospitalChartsData.push({
                                                        hospitalID: <%# Eval("HospitalID") %>,
                                                        hospitalName: '<%# Eval("Hospital") %>',
                                                        divID: 'chart_div_' + <%# Eval("HospitalID") %>
                                                    });
                                                </script>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>

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

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

    <script type="text/javascript">
        // Load the Google Charts library
        google.charts.load('current', { 'packages': ['corechart'] });

        // Callback after Google Charts is loaded
        google.charts.setOnLoadCallback(initializeCharts);

        function initializeCharts() {
            // Iterate over each hospital chart data and draw a chart for each
            window.hospitalChartsData.forEach(function (hospital) {
                drawChart(hospital.hospitalID, hospital.hospitalName, hospital.divID);
            });
        }

        function drawChart(hospitalID, hospitalName, divID) {
            // Call the Web Method using fetch
            fetch('http://localhost:36742/AdminPanel/Account/ACC_Chart/ACC_ChartIncomeExpenseByFinYearHospital.aspx/GetChartData', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json; charset=utf-8',
                    'Accept': 'application/json'
                },
                body: JSON.stringify({ hospitalID: hospitalID })
            })
                .then(response => response.json())
                .then(data => {
                    var chartData = JSON.parse(data.d); // Access the data.d property
                    var dataTable = new google.visualization.DataTable();

                    dataTable.addColumn('string', 'FinYearName');
                    dataTable.addColumn('number', 'TotalIncome');
                    dataTable.addColumn('number', 'TotalExpense');

                    chartData.forEach(function (item) {
                        dataTable.addRow([item.FinYearName, item.TotalIncome, item.TotalExpense]);
                    });

                    var options = {
                        title: 'Financial Data for ' + hospitalName,
                        chartArea: { width: '50%' },
                        hAxis: {
                            title: 'Financial Year',
                            minValue: 0
                        },
                        vAxis: {
                            title: 'Total'
                        }
                    };

                    var chart = new google.visualization.ColumnChart(document.getElementById(divID));
                    chart.draw(dataTable, options);
                })
                .catch(error => {
                    console.error('Error retrieving data:', error);
                });
        }

    </script>
</asp:Content >

