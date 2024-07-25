<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default/MasterPageView.master" CodeFile="ACC_TransactionView.aspx.cs" Inherits="AdminPanel_Account_ACC_Transaction_ACC_TransactionView" Title="Transaction View"%>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
	<!-- BEGIN SAMPLE FORM PORTLET-->
	<div class="portlet light">
		<div class="portlet-title">
			<div class="caption">
				<asp:Label SkinID="lblViewFormHeaderIcon" ID="lblViewFormHeaderIcon" runat="server"></asp:Label>
				<span class="caption-subject font-green-sharp bold uppercase">Transaction</span>
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
				<asp:Label ID="lblPatient_XXXXX" Text="Patient" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblPatient" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblTreatmentID_XXXXX" Text="Treatment" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblTreatmentID" runat="server"></asp:Label>
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
				<asp:Label ID="lblSerialNo_XXXXX" Text="Serial No" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblSerialNo" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblReferenceDoctor_XXXXX" Text="Reference Doctor" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblReferenceDoctor" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblCount_XXXXX" Text="Count" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblCount" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblReceiptNo_XXXXX" Text="Receipt No" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblReceiptNo" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblDate_XXXXX" Text="Date" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblDate" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblDateOfAdmission_XXXXX" Text="Date Of Admission" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblDateOfAdmission" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblDateOfDischarge_XXXXX" Text="Date Of Discharge" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblDateOfDischarge" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblDeposite_XXXXX" Text="Deposite" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblDeposite" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblNetAmount_XXXXX" Text="Net Amount" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblNetAmount" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblNoOfDays_XXXXX" Text="No Of Days" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblNoOfDays" runat="server"></asp:Label>
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
				<asp:Label ID="lblReceiptTypeID_XXXXX" Text="Receipt Type" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblReceiptTypeID" runat="server"></asp:Label>
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
