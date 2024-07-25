<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="MST_SubTreatmentAddEdit.aspx.cs" Inherits="AdminPanel_Master_MST_SubTreatment_MST_SubTreatmentAddEdit"
    Title="SubTreatment AddEdit" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Sub Treatment " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Master" runat="server"></asp:Label></small>
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
        <asp:HyperLink ID="hlSubTreatment" runat="server" NavigateUrl="~/AdminPanel/Master/MST_SubTreatment/MST_SubTreatmentList.aspx" Text="Sub Treatment List"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Sub Treatment Add/Edit"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upMST_SubTreatment" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
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
                                    <asp:Label ID="lblSubTreatmentName_XXXXX" runat="server" Text="Sub Treatment Name"></asp:Label>
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtSubTreatmentName" CssClass="form-control" runat="server" PlaceHolder="Enter Sub Treatment Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSubTreatmentName" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtSubTreatmentName" ErrorMessage="Enter Sub Treatment Name"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblSequenceNo_XXXXX" runat="server" Text="Sequence No"></asp:Label>
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtSequenceNo" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter Sequence No"></asp:TextBox>
                                    <asp:CompareValidator ID="cvSequenceNo" runat="server" ControlToValidate="txtSequenceNo" ErrorMessage="Enter Valid Sequence No" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Integer"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblRate_XXXXX" runat="server" Text="Rate"></asp:Label>
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtRate" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter Rate"></asp:TextBox>
                                    <asp:CompareValidator ID="cvRate" runat="server" ControlToValidate="txtRate" ErrorMessage="Enter Valid Rate" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Double"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblIsInGrid_XXXXX" runat="server" Text=" "></asp:Label>
                                </label>
                                <div class="col-md-8">
                                    <div class="input-group">
                                        <div class="icheck-inline">
                                            <label>
                                                <asp:CheckBox ID="cbIsInGrid" runat="server" Text="Is In Gr" /></label>
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
                                    <asp:RequiredFieldValidator ID="rfvHospitalID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlHospitalID" ErrorMessage="Select Hospital" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblIsPerDay_XXXXX" runat="server" Text=" "></asp:Label>
                                </label>
                                <div class="col-md-8">
                                    <div class="input-group">
                                        <div class="icheck-inline">
                                            <label>
                                                <asp:CheckBox ID="cbIsPerDay" runat="server" Text="Is Per Day" /></label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblDefaultUnit_XXXXX" runat="server" Text="Default Unit"></asp:Label>
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtDefaultUnit" CssClass="form-control" runat="server" PlaceHolder="Enter Default Unit"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblRemarks_XXXXX" runat="server" Text="Remarks"></asp:Label>
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" PlaceHolder="Enter Remarks"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                                    <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Master/MST_SubTreatment/MST_SubTreatmentList.aspx"></asp:HyperLink>
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
