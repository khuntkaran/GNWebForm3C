<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="ACC_TransactionTranAddEdit.aspx.cs" Inherits="AdminPanel_Account_ACC_TransactionTran_ACC_TransactionTranAddEdit"
Title="TransactionTran AddEdit"%>
<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" Runat="Server">
	<asp:Label ID="lblPageHeader_XXXXX" Text="Transaction Tran " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Account" runat="server"></asp:Label></small>
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
		<asp:HyperLink ID="hlTransactionTran" runat="server" NavigateUrl="~/AdminPanel/Account/ACC_TransactionTran/ACC_TransactionTranList.aspx" Text="Transaction Tran List"></asp:HyperLink>
		<i class="fa fa-angle-right"></i>
	</li>
	<li class="active">
		<asp:Label ID="lblBreadCrumbLast" runat="server" Text="Transaction Tran Add/Edit"></asp:Label>
	</li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
		<!--Help Text-->
		<ucHelp:ShowHelp ID="ucHelp" runat="server" />
		<!--Help Text End-->
		<asp:ScriptManager ID="sm" runat="server">
		</asp:ScriptManager>
		<asp:UpdatePanel ID="upACC_TransactionTran" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
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
		<asp:Label ID="lblTransactionID_XXXXX" runat="server" Text="Transaction"></asp:Label>
	</label>
        <div class="col-md-5">
        	<asp:DropDownList ID="ddlTransactionID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
			<asp:RequiredFieldValidator ID="rfvTransactionID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlTransactionID" ErrorMessage="Select Transaction" InitialValue = "-99"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblSubTreatmentID_XXXXX" runat="server" Text="Sub Treatment"></asp:Label>
	</label>
        <div class="col-md-5">
        	<asp:DropDownList ID="ddlSubTreatmentID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblQuantity_XXXXX" runat="server" Text="Quantity"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter Quantity"></asp:TextBox>
			<asp:CompareValidator ID="cvQuantity" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Enter Valid Quantity" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Integer" ></asp:CompareValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblUnit_XXXXX" runat="server" Text="Unit"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtUnit" CssClass="form-control" runat="server"   PlaceHolder="Enter Unit"></asp:TextBox>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblRate_XXXXX" runat="server" Text="Rate"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtRate" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter Rate"></asp:TextBox>
			<asp:CompareValidator ID="cvRate" runat="server" ControlToValidate="txtRate" ErrorMessage="Enter Valid Rate" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Double" ></asp:CompareValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblAmount_XXXXX" runat="server" Text="Amount"></asp:Label>
	</label>
	<div class="col-md-9">
		<asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter Amount"></asp:TextBox>
			<asp:CompareValidator ID="cvAmount" runat="server" ControlToValidate="txtAmount" ErrorMessage="Enter Valid Amount" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Double" ></asp:CompareValidator>
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
										<asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Account/ACC_TransactionTran/ACC_TransactionTranList.aspx"></asp:HyperLink>
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
