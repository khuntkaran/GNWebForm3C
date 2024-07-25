<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="CFG_SoftwareConfigurationAddEdit.aspx.cs" Inherits="AdminPanel_Config_CFG_SoftwareConfiguration_CFG_SoftwareConfigurationAddEdit"
Title="SoftwareConfiguration AddEdit"%>
<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" Runat="Server">
	<asp:Label ID="lblPageHeader_XXXXX" Text="Software Configuration " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Config" runat="server"></asp:Label></small>
	<span class="pull-right">
		<small>
			<asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
		</small>
	</span>
</asp:Content>
<asp:Content ID="cntBreadcrumb" ContentPlaceHolderID="cphBreadcrumb" Runat="Server">
	<li>
		<i class="fa fa-home"></i>
		<asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
		<i class="fa fa-angle-right"></i>
	</li>
	<li>
		<asp:HyperLink ID="hlSoftwareConfiguration" runat="server" NavigateUrl="~/AdminPanel/Config/CFG_SoftwareConfiguration/CFG_SoftwareConfigurationList.aspx" Text="Software Configuration List"></asp:HyperLink>
		<i class="fa fa-angle-right"></i>
	</li>
	<li class="active">
		<asp:Label ID="lblBreadCrumbLast" runat="server" Text="Software Configuration Add/Edit"></asp:Label>
	</li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
		<!--Help Text-->
		<ucHelp:ShowHelp ID="ucHelp" runat="server" />
		<!--Help Text End-->
		<asp:ScriptManager ID="sm" runat="server">
		</asp:ScriptManager>
		<asp:UpdatePanel ID="upCFG_SoftwareConfiguration" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
			<Triggers>
				<asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
			</Triggers>
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
		<asp:Label ID="lblSaveMessage_NoMessageJustClosetheform_XXXXX" runat="server" Text="Save Message_ No Message Just Closetheform"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtSaveMessage_NoMessageJustClosetheform" CssClass="form-control" runat="server"   PlaceHolder="Enter Save Message_ No Message Just Closetheform"></asp:TextBox>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblSaveMessage_ShowMessageClosetheform_XXXXX" runat="server" Text="Save Message_ Show Message Closetheform"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtSaveMessage_ShowMessageClosetheform" CssClass="form-control" runat="server"   PlaceHolder="Enter Save Message_ Show Message Closetheform"></asp:TextBox>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblSaveMessage_ShowMessageAskforOtherRecord_XXXXX" runat="server" Text="Save Message_ Show Message Askfor Other Record"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtSaveMessage_ShowMessageAskforOtherRecord" CssClass="form-control" runat="server"   PlaceHolder="Enter Save Message_ Show Message Askfor Other Record"></asp:TextBox>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblShortcutKeys_AddOnNumPadPlusKeyinListPage_XXXXX" runat="server" Text=" "></asp:Label>
	</label>
	<div class="col-md-8">
		<div class="input-group">
			<div class="icheck-inline">
				<label>
				<asp:CheckBox ID="cbShortcutKeys_AddOnNumPadPlusKeyinListPage" runat="server" Text="Shortcut Keys_ Add On Num Pad Plus Keyin List Page" /></label>
			</div>
		</div>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblShortcutKeys_EditOnEnterKeyinListPage_XXXXX" runat="server" Text="Shortcut Keys_ Edit On Enter Keyin List Page"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtShortcutKeys_EditOnEnterKeyinListPage" CssClass="form-control" runat="server"   PlaceHolder="Enter Shortcut Keys_ Edit On Enter Keyin List Page"></asp:TextBox>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblShortcutKeys_ViewOnSpaceBarKeyinListPage_XXXXX" runat="server" Text=" "></asp:Label>
	</label>
	<div class="col-md-8">
		<div class="input-group">
			<div class="icheck-inline">
				<label>
				<asp:CheckBox ID="cbShortcutKeys_ViewOnSpaceBarKeyinListPage" runat="server" Text="Shortcut Keys_ View On Space Bar Keyin List Page" /></label>
			</div>
		</div>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblShortcutKeys_DeleteOnDeleteKeyinListPage_XXXXX" runat="server" Text=" "></asp:Label>
	</label>
	<div class="col-md-8">
		<div class="input-group">
			<div class="icheck-inline">
				<label>
				<asp:CheckBox ID="cbShortcutKeys_DeleteOnDeleteKeyinListPage" runat="server" Text="Shortcut Keys_ Delete On Delete Keyin List Page" /></label>
			</div>
		</div>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblShortcutKeys_DoubleClicK_XXXXX" runat="server" Text="Shortcut Keys_ Double Clic K"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtShortcutKeys_DoubleClicK" CssClass="form-control" runat="server"   PlaceHolder="Enter Shortcut Keys_ Double Clic K"></asp:TextBox>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblShortcutKeys_IsAskConfirmationBeforeEscape_XXXXX" runat="server" Text=" "></asp:Label>
	</label>
	<div class="col-md-8">
		<div class="input-group">
			<div class="icheck-inline">
				<label>
				<asp:CheckBox ID="cbShortcutKeys_IsAskConfirmationBeforeEscape" runat="server" Text="Shortcut Keys_ Is Ask Confirmation Before Escape" /></label>
			</div>
		</div>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblIsEnterAsTAB_XXXXX" runat="server" Text=" "></asp:Label>
	</label>
	<div class="col-md-8">
		<div class="input-group">
			<div class="icheck-inline">
				<label>
				<asp:CheckBox ID="cbIsEnterAsTAB" runat="server" Text="Is Enter As TAB" /></label>
			</div>
		</div>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblIsSendError_XXXXX" runat="server" Text=" "></asp:Label>
	</label>
	<div class="col-md-8">
		<div class="input-group">
			<div class="icheck-inline">
				<label>
				<asp:CheckBox ID="cbIsSendError" runat="server" Text="Is Send Error" /></label>
			</div>
		</div>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblIsShowUserNameinListPage_XXXXX" runat="server" Text=" "></asp:Label>
	</label>
	<div class="col-md-8">
		<div class="input-group">
			<div class="icheck-inline">
				<label>
				<asp:CheckBox ID="cbIsShowUserNameinListPage" runat="server" Text="Is Show User Namein List Page" /></label>
			</div>
		</div>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblIsShowModifiedinListPage_XXXXX" runat="server" Text=" "></asp:Label>
	</label>
	<div class="col-md-8">
		<div class="input-group">
			<div class="icheck-inline">
				<label>
				<asp:CheckBox ID="cbIsShowModifiedinListPage" runat="server" Text="Is Show Modifiedin List Page" /></label>
			</div>
		</div>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblAllowIncrementalSearchinGrid_XXXXX" runat="server" Text=" "></asp:Label>
	</label>
	<div class="col-md-8">
		<div class="input-group">
			<div class="icheck-inline">
				<label>
				<asp:CheckBox ID="cbAllowIncrementalSearchinGrid" runat="server" Text="Allow Incremental Searchin Gr" /></label>
			</div>
		</div>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblHospitalID_XXXXX" runat="server" Text="Hospital"></asp:Label>
	</label>
        <div class="col-md-5">
        	<asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
			<asp:RequiredFieldValidator ID="rfvHospitalID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlHospitalID" ErrorMessage="Select Hospital" InitialValue = "-99"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblWeeklyBackupPath_XXXXX" runat="server" Text="Weekly Backup Path"></asp:Label>
	</label>
	<div class="col-md-5">
		<div class="fileinput fileinput-new" data-provides="fileinput">
			<div class="input-group input-large">
				<div class="form-control uneditable-input input-fixed input-medium" data-trigger="fileinput">
					<i class="fa fa-file fileinput-exists"></i>&nbsp; <span class="fileinput-filename"></span>
                                </div>
                                <span class="input-group-addon btn default btn-file">
					<span class="fileinput-new">Select file </span>
					<span class="fileinput-exists">Change </span>
					<asp:FileUpload ID="fuWeeklyBackupPath" runat="server" />
				</span>
                                <a href="javascript:;" class="input-group-addon btn red fileinput-exists" data-dismiss="fileinput">Remove </a>
			</div>
		</div>
	</div>
	<div class="col-md-4">
		<asp:HyperLink ID="hlWeeklyBackupPath" runat="server" Target="_blank" CssClass="btn btn-primary" Visible="false">
		 <i class="fa fa-download" id="icnWeeklyBackupPath" runat="server"></i>   Download
        	</asp:HyperLink>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblWeeklyBackupPassword_XXXXX" runat="server" Text="Weekly Backup Password"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtWeeklyBackupPassword" CssClass="form-control" runat="server"   PlaceHolder="Enter Weekly Backup Password"></asp:TextBox>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblIsActive_XXXXX" runat="server" Text=" "></asp:Label>
	</label>
	<div class="col-md-8">
		<div class="input-group">
			<div class="icheck-inline">
				<label>
				<asp:CheckBox ID="cbIsActive" runat="server" Text="Is Active" /></label>
			</div>
		</div>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblRemarks_XXXXX" runat="server" Text="Remarks"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server"   PlaceHolder="Enter Remarks"></asp:TextBox>
	</div>
</div>
							</div>
							<div class="form-actions">
								<div class="row">
									<div class="col-md-offset-3 col-md-9">
										<asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
										<asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Config/CFG_SoftwareConfiguration/CFG_SoftwareConfigurationList.aspx"></asp:HyperLink>
									</div>
								</div>
							</div>
						</div>
					</div>
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
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>
