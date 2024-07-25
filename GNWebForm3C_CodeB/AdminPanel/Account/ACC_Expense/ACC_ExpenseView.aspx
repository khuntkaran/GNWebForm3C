<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default/MasterPageView.master" CodeFile="ACC_ExpenseView.aspx.cs" Inherits="AdminPanel_Account_ACC_Expense_ACC_ExpenseView" Title="Expense View"%>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
	<!-- BEGIN SAMPLE FORM PORTLET-->
	<div class="portlet light">
		<div class="portlet-title">
			<div class="caption">
				<asp:Label SkinID="lblViewFormHeaderIcon" ID="lblViewFormHeaderIcon" runat="server"></asp:Label>
				<span class="caption-subject font-green-sharp bold uppercase">Expense</span>
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
				<asp:Label ID="lblExpenseTypeID_XXXXX" Text="Expense Type" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblExpenseTypeID" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblAmount_XXXXX" Text="Amount" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblAmount" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblExpenseDate_XXXXX" Text="Expense Date" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblExpenseDate" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblNote_XXXXX" Text="Note" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblNote" runat="server"></asp:Label>
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
				<asp:Label ID="lblFinYearID_XXXXX" Text="Fin Year" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblFinYearID" runat="server"></asp:Label>
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
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblTagName_XXXXX" Text="TagName" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblTagName" runat="server"></asp:Label>
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
