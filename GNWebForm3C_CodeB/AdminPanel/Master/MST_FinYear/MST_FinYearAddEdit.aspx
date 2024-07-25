<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="MST_FinYearAddEdit.aspx.cs" Inherits="AdminPanel_Master_MST_FinYear_MST_FinYearAddEdit"
Title="FinYear AddEdit"%>
<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" Runat="Server">
	<asp:Label ID="lblPageHeader_XXXXX" Text="Fin Year " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Master" runat="server"></asp:Label></small>
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
		<asp:HyperLink ID="hlFinYear" runat="server" NavigateUrl="~/AdminPanel/Master/MST_FinYear/MST_FinYearList.aspx" Text="Fin Year List"></asp:HyperLink>
		<i class="fa fa-angle-right"></i>
	</li>
	<li class="active">
		<asp:Label ID="lblBreadCrumbLast" runat="server" Text="Fin Year Add/Edit"></asp:Label>
	</li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
		<!--Help Text-->
		<ucHelp:ShowHelp ID="ucHelp" runat="server" />
		<!--Help Text End-->
		<asp:ScriptManager ID="sm" runat="server">
		</asp:ScriptManager>
		<asp:UpdatePanel ID="upMST_FinYear" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
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
		<asp:Label ID="lblFinYearName_XXXXX" runat="server" Text="Fin Year Name"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtFinYearName" CssClass="form-control" runat="server"   PlaceHolder="Enter Fin Year Name"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvFinYearName" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtFinYearName" ErrorMessage="Enter Fin Year Name"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblFromDate_XXXXX" runat="server" Text="From Date"></asp:Label>
	</label>
	<div class="col-md-5">
		<div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
			<asp:TextBox ID="dtpFromDate" CssClass="form-control" runat="server" placeholder="From Date"></asp:TextBox>
                        <span class="input-group-btn">
                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                        </span>
                </div>
			<asp:RequiredFieldValidator ID="rfvFromDate" runat="server" ControlToValidate="dtpFromDate" ErrorMessage="Enter From Date" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblToDate_XXXXX" runat="server" Text="To Date"></asp:Label>
	</label>
	<div class="col-md-5">
		<div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
			<asp:TextBox ID="dtpToDate" CssClass="form-control" runat="server" placeholder="To Date"></asp:TextBox>
                        <span class="input-group-btn">
                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                        </span>
                </div>
			<asp:RequiredFieldValidator ID="rfvToDate" runat="server" ControlToValidate="dtpToDate" ErrorMessage="Enter To Date" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
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
										<asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Master/MST_FinYear/MST_FinYearList.aspx"></asp:HyperLink>
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
