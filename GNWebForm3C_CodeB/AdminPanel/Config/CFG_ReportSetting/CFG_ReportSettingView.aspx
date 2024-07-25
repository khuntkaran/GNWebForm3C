<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default/MasterPageView.master" CodeFile="CFG_ReportSettingView.aspx.cs" Inherits="AdminPanel_Config_CFG_ReportSetting_CFG_ReportSettingView" Title="Report Setting View"%>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
	<!-- BEGIN SAMPLE FORM PORTLET-->
	<div class="portlet light">
		<div class="portlet-title">
			<div class="caption">
				<asp:Label SkinID="lblViewFormHeaderIcon" ID="lblViewFormHeaderIcon" runat="server"></asp:Label>
				<span class="caption-subject font-green-sharp bold uppercase">Report Setting</span>
			</div>
			<div class="tools">
				<asp:HyperLink ID="CloseButton" SkinID="hlClosemymodal" runat="server" ClientIDMode="Static"></asp:HyperLink>
			</div>
		</div>
		<div class="portlet-body form">
		<div class="form-horizontal" role="form">
		<table class="table table-bordered table-advance table-hover">
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblReportHeaderFontType_XXXXX" Text="Report Header Font Type" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblReportHeaderFontType" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblReportHeaderFontSize_XXXXX" Text="Report Header Font Size" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblReportHeaderFontSize" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblReportHeaderFontStyle_XXXXX" Text="Report Header Font Style" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblReportHeaderFontStyle" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblTableHeaderFontType_XXXXX" Text="Table Header Font Type" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblTableHeaderFontType" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblTableHeaderFontSize_XXXXX" Text="Table Header Font Size" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblTableHeaderFontSize" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblTableHeaderFontStyle_XXXXX" Text="Table Header Font Style" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblTableHeaderFontStyle" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblTableRowFontType_XXXXX" Text="Table Row Font Type" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblTableRowFontType" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblTableRowFontSize_XXXXX" Text="Table Row Font Size" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblTableRowFontSize" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblTableRowFontStyle_XXXXX" Text="Table Row Font Style" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblTableRowFontStyle" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblFooterFontType_XXXXX" Text="Footer Font Type" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblFooterFontType" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblFooterFontSize_XXXXX" Text="Footer Font Size" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblFooterFontSize" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblFooterFontStyle_XXXXX" Text="Footer Font Style" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblFooterFontStyle" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblIsPrintDate_XXXXX" Text="Is Print Date" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblIsPrintDate" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblIsPrintDateWithTime_XXXXX" Text="Is Print Date With Time" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblIsPrintDateWithTime" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblIsPrintUserName_XXXXX" Text="Is Print User Name" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblIsPrintUserName" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblHospitalID_XXXXX" Text="Hospital" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblHospitalID" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblRemarks_XXXXX" Text="Remarks" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblRemarks" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblUserID_XXXXX" Text="User" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblUserID" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblCreated_XXXXX" Text="Created" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblCreated" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblModified_XXXXX" Text="Modified" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblModified" runat="server"></asp:Label>
				</td>
			</tr>
		</table>
	</div>
</div>
</div>
<!-- END SAMPLE FORM PORTLET-->
</asp:Content>
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" Runat="Server">
<script>
$(document).keyup(function (e) {
if (e.keyCode == 27) {;
	$("#CloseButton").trigger("click");
}
});
</script>
</asp:Content>
