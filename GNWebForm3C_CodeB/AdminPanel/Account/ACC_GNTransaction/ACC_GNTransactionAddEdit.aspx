<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="ACC_GNTransactionAddEdit.aspx.cs" Inherits="AdminPanel_Account_ACC_GNTransaction_ACC_GNTransactionAddEdit" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Transaction " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Account" runat="server"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="cntBreadcrumb" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <asp:HyperLink ID="hlTransaction" runat="server" NavigateUrl="~/AdminPanel/Account/ACC_GNTransaction/ACC_GNTransactionList.aspx" Text="Transaction List"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Transaction Add/Edit"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upACC_GNTransaction" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">

        <ContentTemplate>
            <div class="row">

                <div  class="col-md-8">
                    <div class="row">
                        <div class="col-md-12" >
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <ucMessage:ShowMessage ID="ucMessage" runat="server" />
                                    <asp:ValidationSummary ID="ValidationSummary1" SkinID="VS" runat="server" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSavePatient" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
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
                                            <asp:Label ID="lblFinYearID_XXXXX" runat="server" Text="Fin Year"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:DropDownList ValidationGroup="vgTransaction" ID="ddlFinYearID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ValidationGroup="vgTransaction" ID="rfvFinYearID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlFinYearID" ErrorMessage="Select Fin Year" InitialValue="-99"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <span class="required">*</span>
                                            <asp:Label ID="lblHospitalID_XXXXX" runat="server" Text="Hospital"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:DropDownList ValidationGroup="vgTransaction" ID="ddlHospitalID" CssClass="form-control select2me" runat="server" AutoPostBack="true" OnSelectedIndexChanged="FillTreatmentCombobox"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ValidationGroup="vgTransaction" ID="rfvHospitalID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlHospitalID" ErrorMessage="Select Hospital" InitialValue="-99"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <span class="required">*</span>
                                            <asp:Label ID="lblPatientID_XXXXX" runat="server" Text="Patient"></asp:Label>
                                        </label>
                                        <asp:UpdatePanel ID="upPatientDDL" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="col-md-5">
                                                    <asp:DropDownList ID="ddlPatientID" CssClass="form-control select2me" runat="server"  AutoPostBack="true"  OnSelectedIndexChanged="FillPatientView"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ValidationGroup="vgTransaction" ID="rfvPatientID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlPatientID" ErrorMessage="Select Patient" InitialValue="-99"></asp:RequiredFieldValidator>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnSavePatient" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <div class="col-md-2">
                                            <button type="button" class="btn btn-primary" onclick="toggleAddPatientForm()">
                                                Add
                                            </button>
                                        </div>
                                    </div>

                                    <asp:Panel ID="pnlAddPatient" runat="server" CssClass="collapse" ClientIDMode="Static">
                                        <asp:UpdatePanel ID="upPatient" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="well" role="form">

                                                    <div class="form-group row">
                                                        <label class="col-md-3 control-label" for="txtPatientName">Patient Name</label>
                                                        <div class="col-md-5">
                                                            <asp:TextBox ValidationGroup="vgPatient" ID="txtPatientName" runat="server" CssClass="form-control" placeholder="Enter Patient Name"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ValidationGroup="vgPatient" ID="RequiredFieldValidator2" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtPatientName" ErrorMessage="Enter Patient Name"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 control-label" for="txtAge">Age</label>
                                                        <div class="col-md-5">
                                                            <asp:TextBox ValidationGroup="vgPatient" ID="txtAge" runat="server" CssClass="form-control" onkeypress="return IsPositiveInteger(event)" placeholder="Enter Age"></asp:TextBox>
                                                            <asp:CompareValidator ValidationGroup="vgPatient" ID="CompareValidator1" runat="server" ControlToValidate="txtAge" ErrorMessage="Enter Age" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Integer"></asp:CompareValidator>
                                                            <asp:RequiredFieldValidator ValidationGroup="vgPatient" ID="RequiredFieldValidator3" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtAge" ErrorMessage="Enter Amount"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 control-label" for="dtpDOB">Date of Birth</label>
                                                        <div class="col-md-5">
                                                            <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                                                                <asp:TextBox ValidationGroup="vgPatient" ID="dtpDOB" CssClass="form-control" runat="server" placeholder="Date"></asp:TextBox>
                                                                <span class="input-group-btn">
                                                                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                                                </span>
                                                            </div>
                                                            <asp:RequiredFieldValidator ValidationGroup="vgPatient" ID="rfvDOB" runat="server" ControlToValidate="dtpDOB" ErrorMessage="Enter DOB" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 control-label" for="txtMobileNo">Mobile No</label>
                                                        <div class="col-md-5">
                                                            <asp:TextBox ValidationGroup="vgPatient" ID="txtMobileNo" runat="server" CssClass="form-control" onkeypress="return IsPositiveInteger(event)" placeholder="Enter Mobile No"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ValidationGroup="vgPatient" ID="RequiredFieldValidator1" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Enter MobileNo"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <label class="col-md-3 control-label" for="txtPrimaryDesc">Primary Description</label>
                                                        <div class="col-md-5">

                                                            <asp:TextBox ValidationGroup="vgPatient" ID="txtPrimaryDesc" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" placeholder="Enter Primary Description"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ValidationGroup="vgPatient" ID="rfvPrimaryDesc" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtPrimaryDesc" ErrorMessage="Enter Primary Description"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                    <div class="form-group row">
                                                        <div class="col-md-offset-3 col-md-9">
                                                            <asp:Button ValidationGroup="vgPatient" ID="btnSavePatient" OnClick="btnSavePatient_Click" runat="server" CssClass="btn btn-primary" Text="Save" EnableViewState="false" AutoPostBack="true" />

                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:Panel>


                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <span class="required">*</span>
                                            <asp:Label ID="lblTreatmentID_XXXXX" runat="server" Text="Treatment"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:UpdatePanel ID="upTreatmentID" runat="server" UpdateMode="Conditional">

                                                <ContentTemplate>
                                                    <asp:DropDownList ValidationGroup="vgTransaction" ID="ddlTreatmentID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ValidationGroup="vgTransaction" ID="rfvTreatmentID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlTreatmentID" ErrorMessage="Select Treatment" InitialValue="-99"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlHospitalID" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <asp:Label ID="lblQuantity_XXXXX" runat="server" Text="Quantity"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:TextBox ValidationGroup="vgTransaction" ID="txtQuantity" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter Quantity"></asp:TextBox>
                                            <asp:CompareValidator ValidationGroup="vgTransaction" ID="cvQuantity" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Enter Quantity" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Integer"></asp:CompareValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <span class="required">*</span>
                                            <asp:Label ID="lblAmount_XXXXX" runat="server" Text="Amount"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:TextBox ValidationGroup="vgTransaction" ID="txtAmount" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter Amount"></asp:TextBox>
                                            <asp:CompareValidator ValidationGroup="vgTransaction" ID="cvAmount" runat="server" ControlToValidate="txtAmount" ErrorMessage="Enter Valid Amount" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Double"></asp:CompareValidator>
                                            <asp:RequiredFieldValidator ValidationGroup="vgTransaction" ID="rfvAmount" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtAmount" ErrorMessage="Enter Amount"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <span class="required">*</span>
                                            <asp:Label ID="lblDate_XXXXX" runat="server" Text="Date"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                                                <asp:TextBox ValidationGroup="vgTransaction" ID="dtpDate" CssClass="form-control" runat="server" placeholder="Date" ReadOnly="true"></asp:TextBox>
                                                <span class="input-group-btn">
                                                    <button class="btn default" type="button" disabled><i class="fa fa-calendar"></i></button>
                                                </span>
                                            </div>
                                            <asp:RequiredFieldValidator ValidationGroup="vgTransaction" ID="rfvDate" runat="server" ControlToValidate="dtpDate" ErrorMessage="Enter Date" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <asp:Label ID="lblDateOfAdmission_XXXXX" runat="server" Text="Date Of Admission"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                                                <asp:TextBox ValidationGroup="vgTransaction" ID="dtpDateOfAdmission" CssClass="form-control" runat="server" placeholder="Date Of Admission" ReadOnly="true"></asp:TextBox>
                                                <span class="input-group-btn">
                                                    <button class="btn default" type="button" disabled><i class="fa fa-calendar"></i></button>
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
                                                <asp:TextBox ValidationGroup="vgTransaction" ID="dtpDateOfDischarge" CssClass="form-control" runat="server" placeholder="Date Of Discharge"></asp:TextBox>
                                                <span class="input-group-btn">
                                                    <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <asp:Label ID="lblReferenceDoctor_XXXXX" runat="server" Text="Reference Doctor"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:TextBox ValidationGroup="vgTransaction" ID="txtReferenceDoctor" CssClass="form-control" runat="server" PlaceHolder="Enter Reference Doctor"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <asp:Label ID="lblReceiptTypeID_XXXXX" runat="server" Text="Receipt Type"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:DropDownList ValidationGroup="vgTransaction" ID="ddlReceiptTypeID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <asp:Label ID="lblDeposite_XXXXX" runat="server" Text="Deposite"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:TextBox ValidationGroup="vgTransaction" ID="txtDeposite" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter Deposite"></asp:TextBox>
                                            <asp:CompareValidator ValidationGroup="vgTransaction" ID="cvDeposite" runat="server" ControlToValidate="txtDeposite" ErrorMessage="Enter Valid Deposite" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Double"></asp:CompareValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <asp:Label ID="lblNetAmount_XXXXX" runat="server" Text="Net Amount"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:TextBox ValidationGroup="vgTransaction" ID="txtNetAmount" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="0" ReadOnly="true"></asp:TextBox>
                                            <asp:CompareValidator ValidationGroup="vgTransaction" ID="cvNetAmount" runat="server" ControlToValidate="txtNetAmount" ErrorMessage="Enter Valid Net Amount" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Double"></asp:CompareValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <asp:Label ID="lblRemarks_XXXXX" runat="server" Text="Remarks"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:TextBox ValidationGroup="vgTransaction" ID="txtRemarks" CssClass="form-control" runat="server" TextMode="MultiLine" PlaceHolder="Enter Remarks"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <asp:Label ID="lblCount_XXXXX" runat="server" Text="Count"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:TextBox ValidationGroup="vgTransaction" ID="txtCount" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter Count"></asp:TextBox>
                                            <asp:CompareValidator ValidationGroup="vgTransaction" ID="cvCount" runat="server" ControlToValidate="txtCount" ErrorMessage="Enter Valid Count" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Integer"></asp:CompareValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-actions">
                                    <div class="row">
                                        <div class="col-md-offset-3 col-md-9">
                                            <asp:Button ValidationGroup="vgTransaction" ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                                            <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Account/ACC_GNTransaction/ACC_GNTransactionList.aspx"></asp:HyperLink>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <ucPatient:ShowPatient ID="ucPatient" runat="server" />
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlPatientID"  />
            <asp:AsyncPostBackTrigger ControlID="btnSavePatient" EventName="Click"  />
        </Triggers>
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


<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" runat="Server">
    <script> 
        function toggleAddPatientForm() {
            $('#pnlAddPatient').collapse('toggle');
        }
    </script>
</asp:Content>