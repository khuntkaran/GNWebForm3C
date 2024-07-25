<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default/MasterPageView.master" CodeFile="CFG_SoftwareConfigurationView.aspx.cs" Inherits="AdminPanel_Config_CFG_SoftwareConfiguration_CFG_SoftwareConfigurationView" Title="Software Configuration View"%>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
	<!-- BEGIN SAMPLE FORM PORTLET-->
	<div class="portlet light">
		<div class="portlet-title">
			<div class="caption">
				<asp:Label SkinID="lblViewFormHeaderIcon" ID="lblViewFormHeaderIcon" runat="server"></asp:Label>
				<span class="caption-subject font-green-sharp bold uppercase">Software Configuration</span>
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
				<asp:Label ID="lblSaveMessage_NoMessageJustClosetheform_XXXXX" Text="Save Message_ No Message Just Closetheform" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblSaveMessage_NoMessageJustClosetheform" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblSaveMessage_ShowMessageClosetheform_XXXXX" Text="Save Message_ Show Message Closetheform" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblSaveMessage_ShowMessageClosetheform" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblSaveMessage_ShowMessageAskforOtherRecord_XXXXX" Text="Save Message_ Show Message Askfor Other Record" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblSaveMessage_ShowMessageAskforOtherRecord" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblShortcutKeys_AddOnNumPadPlusKeyinListPage_XXXXX" Text="Shortcut Keys_ Add On Num Pad Plus Keyin List Page" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblShortcutKeys_AddOnNumPadPlusKeyinListPage" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblShortcutKeys_EditOnEnterKeyinListPage_XXXXX" Text="Shortcut Keys_ Edit On Enter Keyin List Page" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblShortcutKeys_EditOnEnterKeyinListPage" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblShortcutKeys_ViewOnSpaceBarKeyinListPage_XXXXX" Text="Shortcut Keys_ View On Space Bar Keyin List Page" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblShortcutKeys_ViewOnSpaceBarKeyinListPage" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblShortcutKeys_DeleteOnDeleteKeyinListPage_XXXXX" Text="Shortcut Keys_ Delete On Delete Keyin List Page" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblShortcutKeys_DeleteOnDeleteKeyinListPage" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblShortcutKeys_DoubleClicK_XXXXX" Text="Shortcut Keys_ Double Clic K" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblShortcutKeys_DoubleClicK" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblShortcutKeys_IsAskConfirmationBeforeEscape_XXXXX" Text="Shortcut Keys_ Is Ask Confirmation Before Escape" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblShortcutKeys_IsAskConfirmationBeforeEscape" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblIsEnterAsTAB_XXXXX" Text="Is Enter As TAB" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblIsEnterAsTAB" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblIsSendError_XXXXX" Text="Is Send Error" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblIsSendError" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblIsShowUserNameinListPage_XXXXX" Text="Is Show User Namein List Page" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblIsShowUserNameinListPage" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblIsShowModifiedinListPage_XXXXX" Text="Is Show Modifiedin List Page" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblIsShowModifiedinListPage" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblAllowIncrementalSearchinGrid_XXXXX" Text="Allow Incremental Searchin Grid" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblAllowIncrementalSearchinGrid" runat="server"></asp:Label>
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
				<asp:Label ID="lblWeeklyBackupPath_XXXXX" Text="Weekly Backup Path" runat="server"></asp:Label>
				</td>
				<td>
				<asp:HyperLink ID="hlWeeklyBackupPath" download runat="server" Visible="false"><i runat="server" class="fa fa-download" id="iWeeklyBackupPath"></i> Download</asp:HyperLink>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblWeeklyBackupPassword_XXXXX" Text="Weekly Backup Password" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblWeeklyBackupPassword" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="TDDarkView">
				<asp:Label ID="lblIsActive_XXXXX" Text="Is Active" runat="server"></asp:Label>
				</td>
				<td>
				<asp:Label ID="lblIsActive" runat="server"></asp:Label>
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
