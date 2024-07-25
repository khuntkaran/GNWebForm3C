<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="SEC_UserAddEdit.aspx.cs" Inherits="AdminPanel_Security_SEC_User_SEC_UserAddEdit"
Title="User AddEdit"%>
<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" Runat="Server">
	<asp:Label ID="lblPageHeader_XXXXX" Text="User " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Security" runat="server"></asp:Label></small>
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
		<asp:HyperLink ID="hlUser" runat="server" NavigateUrl="~/AdminPanel/Security/SEC_User/SEC_UserList.aspx" Text="User List"></asp:HyperLink>
		<i class="fa fa-angle-right"></i>
	</li>
	<li class="active">
		<asp:Label ID="lblBreadCrumbLast" runat="server" Text="User Add/Edit"></asp:Label>
	</li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
		<!--Help Text-->
		<ucHelp:ShowHelp ID="ucHelp" runat="server" />
		<!--Help Text End-->
		<asp:ScriptManager ID="sm" runat="server">
		</asp:ScriptManager>
		<asp:UpdatePanel ID="upSEC_User" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
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
	<span class="required">*</span>
		<asp:Label ID="lblUserName_XXXXX" runat="server" Text="User Name"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"   PlaceHolder="Enter User Name"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvUserName" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtUserName" ErrorMessage="Enter User Name"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblPassword_XXXXX" runat="server" Text="Password"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"   PlaceHolder="Enter Password"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvPassword" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblHospitalID_XXXXX" runat="server" Text="Hospital"></asp:Label>
	</label>
        <div class="col-md-5">
        	<asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
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
										<asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Security/SEC_User/SEC_UserList.aspx"></asp:HyperLink>
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
