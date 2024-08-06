<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="ACC_GNTransactionAddEdit.aspx.cs" Inherits="AdminPanel_Account_ACC_GNTransaction_ACC_GNTransactionAddEdit"
    Title="Transaction AddEdit" %>

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
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlHospitalID" />
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
                                    <asp:Label ID="lblFinYearID_XXXXX" runat="server" Text="Fin Year"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlFinYearID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvFinYearID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlFinYearID" ErrorMessage="Select Fin Year" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblHospitalID_XXXXX" runat="server" Text="Hospital"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlHospitalID_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvHospitalID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlHospitalID" ErrorMessage="Select Hospital" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblPatientID_XXXXX" runat="server" Text="Patient"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlPatientID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvPatientID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlPatientID" ErrorMessage="Select Patient" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <button type="button" class="btn btn-primary" onclick="addNewPatient">
                                        Add
                                   
                                    </button>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="Label1" runat="server" Text="Patient"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="DropDownList1" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlPatientID" ErrorMessage="Select Patient" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2">
                                    <div class="tools">
                                        <a href="javascript:;" class="collapse" data-original-title="" title="" onclick="togglePatientTableContent()"></a>
                                    </div>

                                </div>
                            </div>

                            <!-- Collapsible Form -->


                            <div class="portlet box blue">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-bullhorn "></i>This Year INCOMES 
                                    </div>
                                    <div class="tools">
                                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div id="newPatientForm" class="collapse">
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Patient Name</label>
                                            <div class="col-md-5">
                                                <input type="text" id="txtPatientName" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Age</label>
                                            <div class="col-md-5">
                                                <input type="text" id="txtAge" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Date of Birth</label>
                                            <div class="col-md-5">
                                                <input type="date" id="txtDOB" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Mobile Number</label>
                                            <div class="col-md-5">
                                                <input type="text" id="txtMobileNo" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">Primary Description</label>
                                            <div class="col-md-5">
                                                <input type="text" id="txtPrimaryDesc" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-offset-3 col-md-5">
                                                <button type="button" class="btn btn-success" onclick="submitNewPatient()">
                                                    Save
           
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblTreatmentID_XXXXX" runat="server" Text="Treatment"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlTreatmentID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvTreatmentID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlTreatmentID" ErrorMessage="Select Treatment" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <%--   <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblNoOfDays_XXXXX" runat="server" Text="No Of Days"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtNoOfDays" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter No Of Days"></asp:TextBox>
                                    <asp:CompareValidator ID="cvNoOfDays" runat="server" ControlToValidate="txtNoOfDays" ErrorMessage="Enter Valid No Of Days" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Integer"></asp:CompareValidator>
                                </div>
                            </div>--%>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblQuantity_XXXXX" runat="server" Text="Quantity"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter Quantity"></asp:TextBox>
                                    <asp:CompareValidator ID="cvQuantity" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Enter Quantity" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Integer"></asp:CompareValidator>
                                </div>
                            </div>
                            <%-- <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblRate_XXXXX" runat="server" Text="Rate"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtRate" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter Rate"></asp:TextBox>
                                    <asp:CompareValidator ID="cvRate" runat="server" ControlToValidate="txtRate" ErrorMessage="Enter Valid Rate" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Integer"></asp:CompareValidator>
                                </div>
                            </div>--%>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblAmount_XXXXX" runat="server" Text="Amount"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter Amount"></asp:TextBox>
                                    <asp:CompareValidator ID="cvAmount" runat="server" ControlToValidate="txtAmount" ErrorMessage="Enter Valid Amount" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Double"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="rfvAmount" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtAmount" ErrorMessage="Enter Amount"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblDate_XXXXX" runat="server" Text="Date"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                                        <asp:TextBox ID="dtpDate" CssClass="form-control" runat="server" placeholder="Date" ReadOnly="true"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button" disabled><i class="fa fa-calendar"></i></button>
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
                                        <asp:TextBox ID="dtpDateOfAdmission" CssClass="form-control" runat="server" placeholder="Date Of Admission" ReadOnly="true"></asp:TextBox>
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
                                        <asp:TextBox ID="dtpDateOfDischarge" CssClass="form-control" runat="server" placeholder="Date Of Discharge"></asp:TextBox>
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
                                    <asp:TextBox ID="txtReferenceDoctor" CssClass="form-control" runat="server" PlaceHolder="Enter Reference Doctor"></asp:TextBox>
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






                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblDeposite_XXXXX" runat="server" Text="Deposite"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtDeposite" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter Deposite"></asp:TextBox>
                                    <asp:CompareValidator ID="cvDeposite" runat="server" ControlToValidate="txtDeposite" ErrorMessage="Enter Valid Deposite" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Double"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblNetAmount_XXXXX" runat="server" Text="Net Amount"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtNetAmount" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="0" ReadOnly="true"></asp:TextBox>
                                    <asp:CompareValidator ID="cvNetAmount" runat="server" ControlToValidate="txtNetAmount" ErrorMessage="Enter Valid Net Amount" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Double"></asp:CompareValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblRemarks_XXXXX" runat="server" Text="Remarks"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" TextMode="MultiLine" PlaceHolder="Enter Remarks"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblCount_XXXXX" runat="server" Text="Count"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtCount" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter Count"></asp:TextBox>
                                    <asp:CompareValidator ID="cvCount" runat="server" ControlToValidate="txtCount" ErrorMessage="Enter Valid Count" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Integer"></asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                                    <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Account/ACC_GNTransaction/ACC_GNTransactionList.aspx"></asp:HyperLink>
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
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

