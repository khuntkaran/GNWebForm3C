<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="LedgerReportByFinYearHospital.aspx.cs" Inherits="AdminPanel_Report_Ledger_LedgerReportByFinYearHospital" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    Report file
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="rvIncomeList" runat="server" Width="100%" Height="600px" ProcessingMode="Local">
        <LocalReport ReportPath="AdminPanel/Report/Ledger/RPT_LedgerReportByFinYearHospital.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

