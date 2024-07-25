<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="CFG_ReportSettingAddEdit.aspx.cs" Inherits="AdminPanel_Config_CFG_ReportSetting_CFG_ReportSettingAddEdit"
Title="ReportSetting AddEdit"%>
<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" Runat="Server">
	<asp:Label ID="lblPageHeader_XXXXX" Text="Report Setting " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Config" runat="server"></asp:Label></small>
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
		<asp:HyperLink ID="hlReportSetting" runat="server" NavigateUrl="~/AdminPanel/Config/CFG_ReportSetting/CFG_ReportSettingList.aspx" Text="Report Setting List"></asp:HyperLink>
		<i class="fa fa-angle-right"></i>
	</li>
	<li class="active">
		<asp:Label ID="lblBreadCrumbLast" runat="server" Text="Report Setting Add/Edit"></asp:Label>
	</li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
		<!--Help Text-->
		<ucHelp:ShowHelp ID="ucHelp" runat="server" />
		<!--Help Text End-->
		<asp:ScriptManager ID="sm" runat="server">
		</asp:ScriptManager>
		<asp:UpdatePanel ID="upCFG_ReportSetting" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
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
		<asp:Label ID="lblReportHeaderFontType_XXXXX" runat="server" Text="Report Header Font Type"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtReportHeaderFontType" CssClass="form-control" runat="server"   PlaceHolder="Enter Report Header Font Type"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvReportHeaderFontType" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtReportHeaderFontType" ErrorMessage="Enter Report Header Font Type"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblReportHeaderFontSize_XXXXX" runat="server" Text="Report Header Font Size"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtReportHeaderFontSize" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter Report Header Font Size"></asp:TextBox>
			<asp:CompareValidator ID="cvReportHeaderFontSize" runat="server" ControlToValidate="txtReportHeaderFontSize" ErrorMessage="Enter Valid Report Header Font Size" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Double" ></asp:CompareValidator>
	<asp:RequiredFieldValidator ID="rfvReportHeaderFontSize" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtReportHeaderFontSize" ErrorMessage="Enter Report Header Font Size"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblReportHeaderFontStyle_XXXXX" runat="server" Text="Report Header Font Style"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtReportHeaderFontStyle" CssClass="form-control" runat="server"   PlaceHolder="Enter Report Header Font Style"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvReportHeaderFontStyle" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtReportHeaderFontStyle" ErrorMessage="Enter Report Header Font Style"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblTableHeaderFontType_XXXXX" runat="server" Text="Table Header Font Type"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtTableHeaderFontType" CssClass="form-control" runat="server"   PlaceHolder="Enter Table Header Font Type"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvTableHeaderFontType" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtTableHeaderFontType" ErrorMessage="Enter Table Header Font Type"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblTableHeaderFontSize_XXXXX" runat="server" Text="Table Header Font Size"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtTableHeaderFontSize" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter Table Header Font Size"></asp:TextBox>
			<asp:CompareValidator ID="cvTableHeaderFontSize" runat="server" ControlToValidate="txtTableHeaderFontSize" ErrorMessage="Enter Valid Table Header Font Size" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Double" ></asp:CompareValidator>
	<asp:RequiredFieldValidator ID="rfvTableHeaderFontSize" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtTableHeaderFontSize" ErrorMessage="Enter Table Header Font Size"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblTableHeaderFontStyle_XXXXX" runat="server" Text="Table Header Font Style"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtTableHeaderFontStyle" CssClass="form-control" runat="server"   PlaceHolder="Enter Table Header Font Style"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvTableHeaderFontStyle" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtTableHeaderFontStyle" ErrorMessage="Enter Table Header Font Style"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblTableRowFontType_XXXXX" runat="server" Text="Table Row Font Type"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtTableRowFontType" CssClass="form-control" runat="server"   PlaceHolder="Enter Table Row Font Type"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvTableRowFontType" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtTableRowFontType" ErrorMessage="Enter Table Row Font Type"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblTableRowFontSize_XXXXX" runat="server" Text="Table Row Font Size"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtTableRowFontSize" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter Table Row Font Size"></asp:TextBox>
			<asp:CompareValidator ID="cvTableRowFontSize" runat="server" ControlToValidate="txtTableRowFontSize" ErrorMessage="Enter Valid Table Row Font Size" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Double" ></asp:CompareValidator>
	<asp:RequiredFieldValidator ID="rfvTableRowFontSize" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtTableRowFontSize" ErrorMessage="Enter Table Row Font Size"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblTableRowFontStyle_XXXXX" runat="server" Text="Table Row Font Style"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtTableRowFontStyle" CssClass="form-control" runat="server"   PlaceHolder="Enter Table Row Font Style"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvTableRowFontStyle" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtTableRowFontStyle" ErrorMessage="Enter Table Row Font Style"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblFooterFontType_XXXXX" runat="server" Text="Footer Font Type"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtFooterFontType" CssClass="form-control" runat="server"   PlaceHolder="Enter Footer Font Type"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvFooterFontType" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtFooterFontType" ErrorMessage="Enter Footer Font Type"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblFooterFontSize_XXXXX" runat="server" Text="Footer Font Size"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtFooterFontSize" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter Footer Font Size"></asp:TextBox>
			<asp:CompareValidator ID="cvFooterFontSize" runat="server" ControlToValidate="txtFooterFontSize" ErrorMessage="Enter Valid Footer Font Size" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Double" ></asp:CompareValidator>
	<asp:RequiredFieldValidator ID="rfvFooterFontSize" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtFooterFontSize" ErrorMessage="Enter Footer Font Size"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblFooterFontStyle_XXXXX" runat="server" Text="Footer Font Style"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtFooterFontStyle" CssClass="form-control" runat="server"   PlaceHolder="Enter Footer Font Style"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvFooterFontStyle" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtFooterFontStyle" ErrorMessage="Enter Footer Font Style"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblIsPrintDate_XXXXX" runat="server" Text=" "></asp:Label>
	</label>
	<div class="col-md-8">
		<div class="input-group">
			<div class="icheck-inline">
				<label>
				<asp:CheckBox ID="cbIsPrintDate" runat="server" Text="Is Print Date" /></label>
			</div>
		</div>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblIsPrintDateWithTime_XXXXX" runat="server" Text=" "></asp:Label>
	</label>
	<div class="col-md-8">
		<div class="input-group">
			<div class="icheck-inline">
				<label>
				<asp:CheckBox ID="cbIsPrintDateWithTime" runat="server" Text="Is Print Date With Time" /></label>
			</div>
		</div>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblIsPrintUserName_XXXXX" runat="server" Text=" "></asp:Label>
	</label>
	<div class="col-md-8">
		<div class="input-group">
			<div class="icheck-inline">
				<label>
				<asp:CheckBox ID="cbIsPrintUserName" runat="server" Text="Is Print User Name" /></label>
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
										<asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Config/CFG_ReportSetting/CFG_ReportSettingList.aspx"></asp:HyperLink>
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
