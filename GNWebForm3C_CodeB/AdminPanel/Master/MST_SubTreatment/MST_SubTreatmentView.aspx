<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default/MasterPageView.master" CodeFile="MST_SubTreatmentView.aspx.cs" Inherits="AdminPanel_Master_MST_SubTreatment_MST_SubTreatmentView" Title="Sub Treatment View"%>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
	<!-- BEGIN SAMPLE FORM PORTLET-->
	<div class="portlet light">
		<div class="portlet-title">
			<div class="caption">
				<asp:Label SkinID="lblViewFormHeaderIcon" ID="lblViewFormHeaderIcon" runat="server"></asp:Label>
				<span class="caption-subject font-green-sharp bold uppercase">Sub Treatment</span>
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
				<asp:Label ID="lblSubTreatmentName_XXXXX" Text="Sub Treatment Name" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblSubTreatmentName" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblSequenceNo_XXXXX" Text="Sequence No" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblSequenceNo" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblRate_XXXXX" Text="Rate" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblRate" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblIsInGrid_XXXXX" Text="Is In Grid" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblIsInGrid" runat="server"></asp:Label>
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
				<asp:Label ID="lblIsPerDay_XXXXX" Text="Is Per Day" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblIsPerDay" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblDefaultUnit_XXXXX" Text="Default Unit" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblDefaultUnit" runat="server"></asp:Label>
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
