<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="MST_HospitalAddEdit.aspx.cs" Inherits="AdminPanel_Master_MST_Hospital_MST_HospitalAddEdit"
Title="Hospital AddEdit"%>
<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" Runat="Server">
	<asp:Label ID="lblPageHeader_XXXXX" Text="Hospital " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Master" runat="server"></asp:Label></small>
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
		<asp:HyperLink ID="hlHospital" runat="server" NavigateUrl="~/AdminPanel/Master/MST_Hospital/MST_HospitalList.aspx" Text="Hospital List"></asp:HyperLink>
		<i class="fa fa-angle-right"></i>
	</li>
	<li class="active">
		<asp:Label ID="lblBreadCrumbLast" runat="server" Text="Hospital Add/Edit"></asp:Label>
	</li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
		<!--Help Text-->
		<ucHelp:ShowHelp ID="ucHelp" runat="server" />
		<!--Help Text End-->
		<asp:ScriptManager ID="sm" runat="server">
		</asp:ScriptManager>
		<asp:UpdatePanel ID="upMST_Hospital" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
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
		<asp:Label ID="lblHospital_XXXXX" runat="server" Text="Hospital"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtHospital" CssClass="form-control" runat="server"   PlaceHolder="Enter Hospital"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvHospital" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtHospital" ErrorMessage="Enter Hospital"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblPrintName_XXXXX" runat="server" Text="Print Name"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtPrintName" CssClass="form-control" runat="server"   PlaceHolder="Enter Print Name"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvPrintName" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtPrintName" ErrorMessage="Enter Print Name"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblPrintLine1_XXXXX" runat="server" Text="Print Line1"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtPrintLine1" CssClass="form-control" runat="server"   PlaceHolder="Enter Print Line1"></asp:TextBox>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblPrintLine2_XXXXX" runat="server" Text="Print Line2"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtPrintLine2" CssClass="form-control" runat="server"   PlaceHolder="Enter Print Line2"></asp:TextBox>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblPrintLine3_XXXXX" runat="server" Text="Print Line3"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtPrintLine3" CssClass="form-control" runat="server"   PlaceHolder="Enter Print Line3"></asp:TextBox>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblFooterName_XXXXX" runat="server" Text="Footer Name"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtFooterName" CssClass="form-control" runat="server"   PlaceHolder="Enter Footer Name"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvFooterName" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtFooterName" ErrorMessage="Enter Footer Name"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblReportHeaderName_XXXXX" runat="server" Text="Report Header Name"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtReportHeaderName" CssClass="form-control" runat="server"   PlaceHolder="Enter Report Header Name"></asp:TextBox>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblRemarks_XXXXX" runat="server" Text="Remarks"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" TextMode = "MultiLine" PlaceHolder="Enter Remarks"></asp:TextBox>
	</div>
</div>
							</div>
							<div class="form-actions">
								<div class="row">
									<div class="col-md-offset-3 col-md-9">
										<asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
										<asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Master/MST_Hospital/MST_HospitalList.aspx"></asp:HyperLink>
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
