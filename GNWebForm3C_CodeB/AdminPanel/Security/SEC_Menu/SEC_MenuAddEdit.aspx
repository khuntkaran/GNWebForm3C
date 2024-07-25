<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="SEC_MenuAddEdit.aspx.cs" Inherits="AdminPanel_Security_SEC_Menu_SEC_MenuAddEdit"
Title="Menu AddEdit"%>
<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" Runat="Server">
	<asp:Label ID="lblPageHeader_XXXXX" Text="Menu " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Security" runat="server"></asp:Label></small>
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
		<asp:HyperLink ID="hlMenu" runat="server" NavigateUrl="~/AdminPanel/Security/SEC_Menu/SEC_MenuList.aspx" Text="Menu List"></asp:HyperLink>
		<i class="fa fa-angle-right"></i>
	</li>
	<li class="active">
		<asp:Label ID="lblBreadCrumbLast" runat="server" Text="Menu Add/Edit"></asp:Label>
	</li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
		<!--Help Text-->
		<ucHelp:ShowHelp ID="ucHelp" runat="server" />
		<!--Help Text End-->
		<asp:ScriptManager ID="sm" runat="server">
		</asp:ScriptManager>
		<asp:UpdatePanel ID="upSEC_Menu" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
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
		<asp:Label ID="lblParentMenuID_XXXXX" runat="server" Text="Parent Menu"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtParentMenuID" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter Parent Menu"></asp:TextBox>
			<asp:CompareValidator ID="cvParentMenuID" runat="server" ControlToValidate="txtParentMenuID" ErrorMessage="Enter Valid Parent Menu" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Integer" ></asp:CompareValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblMenuName_XXXXX" runat="server" Text="Menu Name"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtMenuName" CssClass="form-control" runat="server"   PlaceHolder="Enter Menu Name"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvMenuName" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtMenuName" ErrorMessage="Enter Menu Name"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblMenuDisplayName_XXXXX" runat="server" Text="Menu Display Name"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtMenuDisplayName" CssClass="form-control" runat="server"   PlaceHolder="Enter Menu Display Name"></asp:TextBox>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblFormName_XXXXX" runat="server" Text="Form Name"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtFormName" CssClass="form-control" runat="server"   PlaceHolder="Enter Form Name"></asp:TextBox>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblSequence_XXXXX" runat="server" Text="Sequence"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtSequence" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter Sequence"></asp:TextBox>
			<asp:CompareValidator ID="cvSequence" runat="server" ControlToValidate="txtSequence" ErrorMessage="Enter Valid Sequence" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Integer" ></asp:CompareValidator>
	<asp:RequiredFieldValidator ID="rfvSequence" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtSequence" ErrorMessage="Enter Sequence"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblRemarks_XXXXX" runat="server" Text="Remarks"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" TextMode = "MultiLine" PlaceHolder="Enter Remarks"></asp:TextBox>
	</div>
</div>
							</div>
							<div class="form-actions">
								<div class="row">
									<div class="col-md-offset-3 col-md-9">
										<asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
										<asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Security/SEC_Menu/SEC_MenuList.aspx"></asp:HyperLink>
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
