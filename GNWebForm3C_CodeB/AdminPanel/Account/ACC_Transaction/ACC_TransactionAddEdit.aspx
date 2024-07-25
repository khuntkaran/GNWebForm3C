<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="ACC_TransactionAddEdit.aspx.cs" Inherits="AdminPanel_Account_ACC_Transaction_ACC_TransactionAddEdit"
Title="Transaction AddEdit"%>
<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" Runat="Server">
	<asp:Label ID="lblPageHeader_XXXXX" Text="Transaction " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Account" runat="server"></asp:Label></small>
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
		<asp:HyperLink ID="hlTransaction" runat="server" NavigateUrl="~/AdminPanel/Account/ACC_Transaction/ACC_TransactionList.aspx" Text="Transaction List"></asp:HyperLink>
		<i class="fa fa-angle-right"></i>
	</li>
	<li class="active">
		<asp:Label ID="lblBreadCrumbLast" runat="server" Text="Transaction Add/Edit"></asp:Label>
	</li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
		<!--Help Text-->
		<ucHelp:ShowHelp ID="ucHelp" runat="server" />
		<!--Help Text End-->
		<asp:ScriptManager ID="sm" runat="server">
		</asp:ScriptManager>
		<asp:UpdatePanel ID="upACC_Transaction" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
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
		<asp:Label ID="lblPatient_XXXXX" runat="server" Text="Patient"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtPatient" CssClass="form-control" runat="server"   PlaceHolder="Enter Patient"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvPatient" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtPatient" ErrorMessage="Enter Patient"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblTreatmentID_XXXXX" runat="server" Text="Treatment"></asp:Label>
	</label>
        <div class="col-md-5">
        	<asp:DropDownList ID="ddlTreatmentID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
			<asp:RequiredFieldValidator ID="rfvTreatmentID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlTreatmentID" ErrorMessage="Select Treatment" InitialValue = "-99"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblAmount_XXXXX" runat="server" Text="Amount"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter Amount"></asp:TextBox>
			<asp:CompareValidator ID="cvAmount" runat="server" ControlToValidate="txtAmount" ErrorMessage="Enter Valid Amount" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Double" ></asp:CompareValidator>
	<asp:RequiredFieldValidator ID="rfvAmount" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtAmount" ErrorMessage="Enter Amount"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblSerialNo_XXXXX" runat="server" Text="Serial No"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtSerialNo" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter Serial No"></asp:TextBox>
			<asp:CompareValidator ID="cvSerialNo" runat="server" ControlToValidate="txtSerialNo" ErrorMessage="Enter Valid Serial No" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Integer" ></asp:CompareValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblReferenceDoctor_XXXXX" runat="server" Text="Reference Doctor"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtReferenceDoctor" CssClass="form-control" runat="server"   PlaceHolder="Enter Reference Doctor"></asp:TextBox>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblCount_XXXXX" runat="server" Text="Count"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtCount" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter Count"></asp:TextBox>
			<asp:CompareValidator ID="cvCount" runat="server" ControlToValidate="txtCount" ErrorMessage="Enter Valid Count" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Integer" ></asp:CompareValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblReceiptNo_XXXXX" runat="server" Text="Receipt No"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtReceiptNo" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter Receipt No"></asp:TextBox>
			<asp:CompareValidator ID="cvReceiptNo" runat="server" ControlToValidate="txtReceiptNo" ErrorMessage="Enter Valid Receipt No" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Integer" ></asp:CompareValidator>
	<asp:RequiredFieldValidator ID="rfvReceiptNo" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtReceiptNo" ErrorMessage="Enter Receipt No"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblDate_XXXXX" runat="server" Text="Date"></asp:Label>
	</label>
	<div class="col-md-5">
		<div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
			<asp:TextBox ID="dtpDate" CssClass="form-control" runat="server" placeholder="Date"></asp:TextBox>
                        <span class="input-group-btn">
                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                        </span>
                </div>
			<asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="dtpDate" ErrorMessage="Enter Date" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblDateOfAdmission_XXXXX" runat="server" Text="Date Of Admission"></asp:Label>
	</label>
	<div class="col-md-5">
		<div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
			<asp:TextBox ID="dtpDateOfAdmission" CssClass="form-control" runat="server" placeholder="Date Of Admission"></asp:TextBox>
                        <span class="input-group-btn">
                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                        </span>
                </div>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblDateOfDischarge_XXXXX" runat="server" Text="Date Of Discharge"></asp:Label>
	</label>
	<div class="col-md-5">
		<div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
			<asp:TextBox ID="dtpDateOfDischarge" CssClass="form-control" runat="server" placeholder="Date Of Discharge"></asp:TextBox>
                        <span class="input-group-btn">
                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                        </span>
                </div>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblDeposite_XXXXX" runat="server" Text="Deposite"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtDeposite" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter Deposite"></asp:TextBox>
			<asp:CompareValidator ID="cvDeposite" runat="server" ControlToValidate="txtDeposite" ErrorMessage="Enter Valid Deposite" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Double" ></asp:CompareValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblNetAmount_XXXXX" runat="server" Text="Net Amount"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtNetAmount" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter Net Amount"></asp:TextBox>
			<asp:CompareValidator ID="cvNetAmount" runat="server" ControlToValidate="txtNetAmount" ErrorMessage="Enter Valid Net Amount" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Double" ></asp:CompareValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblNoOfDays_XXXXX" runat="server" Text="No Of Days"></asp:Label>
	</label>
	<div class="col-md-5">  
		<asp:TextBox ID="txtNoOfDays" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)"  PlaceHolder="Enter No Of Days"></asp:TextBox>
			<asp:CompareValidator ID="cvNoOfDays" runat="server" ControlToValidate="txtNoOfDays" ErrorMessage="Enter Valid No Of Days" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type = "Integer" ></asp:CompareValidator>
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
	<span class="required">*</span>
		<asp:Label ID="lblFinYearID_XXXXX" runat="server" Text="Fin Year"></asp:Label>
	</label>
        <div class="col-md-5">
        	<asp:DropDownList ID="ddlFinYearID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
			<asp:RequiredFieldValidator ID="rfvFinYearID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlFinYearID" ErrorMessage="Select Fin Year" InitialValue = "-99"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	<label class="col-md-3 control-label">
		<asp:Label ID="lblReceiptTypeID_XXXXX" runat="server" Text="Receipt Type"></asp:Label>
	</label>
        <div class="col-md-5">
        	<asp:DropDownList ID="ddlReceiptTypeID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
	</div>
</div>
							</div>
							<div class="form-actions">
								<div class="row">
									<div class="col-md-offset-3 col-md-9">
										<asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
										<asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Account/ACC_Transaction/ACC_TransactionList.aspx"></asp:HyperLink>
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
