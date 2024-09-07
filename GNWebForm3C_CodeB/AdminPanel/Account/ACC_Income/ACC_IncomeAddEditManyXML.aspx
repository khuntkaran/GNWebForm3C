<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="ACC_IncomeAddEditManyXML.aspx.cs" Inherits="AdminPanel_Account_ACC_Income_ACC_IncomeAddEditManyXML" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Income " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Account" runat="server"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <asp:HyperLink ID="hlExpenseType" runat="server" NavigateUrl="~/AdminPanel/Account/Acc_Income/Acc_IncomeList.aspx" Text="Income List"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Income Add/Edit Many"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upACC_Income" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:UpdatePanel ID="upACC_Income2" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">

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
                                            <span class="required">*</span>
                                            <asp:Label ID="lblIncomeTypeID_XXXXX" runat="server" Text="Income Type"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:DropDownList ID="ddlIncomeTypeID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rvfIncomeTypeID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlIncomeTypeID" ErrorMessage="Select Income Type" InitialValue="-99"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-3 control-label">
                                            <span class="required">*</span>
                                            <asp:Label ID="lblFinYearID_XXXXX" runat="server" Text="Fin Year"></asp:Label>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:DropDownList ID="ddlFinYearID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rvfFinYearID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlFinYearID" ErrorMessage="Select Fin Year" InitialValue="-99"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="col-md-4">
                                            <asp:Button ID="btnShow" runat="server" SkinID="btnShow" OnClick="btnShow_Click" />
                                            <asp:HyperLink ID="hlCancel1" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Account/ACC_Income/ACC_IncomeList.aspx"></asp:HyperLink>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </label>
	
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <div class="row">
                        <div class="col-md-12">
                            <ucMessage:ShowMessage ID="ShowMessage1" runat="server" ViewStateMode="Disabled" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="portlet light" runat="server" id="Div_ShowResult" visible="false">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <asp:Label SkinID="lblSearchResultHeaderIcon" runat="server"></asp:Label>
                                        <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                                        <label class="control-label">&nbsp;</label>
                                    </div>

                                </div>

                                <div class="portlet-body">
                                    <div class="row" runat="server">
                                        <div class="col-md-12">
                                            <div id="TableContent">
                                                <table class="table table-border    ed table-advanced table-striped table-hover" id="sample_1">
                                                    <%-- Table Header --%>
                                                    <thead>
                                                        <tr class="TRDark">
                                                            <th class="text-center" style="width: 20px;">
                                                                <asp:Label ID="lblIsSelected" runat="server" Text="IsSelected"></asp:Label>
                                                            </th>
                                                            <th class="text-center" style="width: 20px;">
                                                                <asp:Label ID="lbhSerialNo" runat="server" Text="Sr."></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label ID="lbhIncomeDate" runat="server" Text="Income Date"></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label ID="lbhAmount" runat="server" Text="Amount"></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label ID="lbhNote" runat="server" Text="Note"></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label ID="lblUser" runat="server" Text="User"></asp:Label>
                                                            </th>

                                                        </tr>
                                                    </thead>
                                                    <%-- END Table Header --%>

                                                    <tbody>
                                                        <asp:Repeater ID="rpData" runat="server" OnItemDataBound="rpData_ItemDataBound">
                                                            <ItemTemplate>
                                                                <%-- Table Rows --%>
                                                                <tr class="odd gradeX">
                                                                    <td class="text-center">
                                                                        <asp:CheckBox runat="server" ID="chkIsSelected" Checked='<%#Eval("IncomeDate").ToString().Trim() == String.Empty ? false : true %>' />
                                                                    </td>
                                                                    <td class="text-center">
                                                                        <%#Container.ItemIndex+1 %>
                                                                    </td>
                                                                    <td>

                                                                        <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                                                            <span class="input-group-btn">
                                                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                                                            </span>
                                                                            <asp:TextBox ID="dtpIncomeDate" CssClass="form-control" Value='<%#Eval("IncomeDate") %>' runat="server" placeholder="Income Date"></asp:TextBox>
                                                                        </div>
                                                                        <asp:HiddenField ID="hdIncomeID" runat="server" Value='<%#Eval("IncomeID") %>' />
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtAmount" CssClass="form-control" onkeypress="return IsPositiveInteger(event)" runat="server" Text='<%#Eval("Amount") %>' PlaceHolder="Enter Amount"></asp:TextBox>

                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtNote" CssClass="form-control" runat="server" Text='<%#Eval("Note") %>' PlaceHolder="Enter Note"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        
                                                                            <asp:DropDownList ID="ddlUserID" CssClass="form-control select2me" runat="server" ></asp:DropDownList>
                                                                        
                                                                    </td>
                                                                </tr>
                                                                <%-- END Table Rows --%>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="form-actions" runat="server">
                                            <div class="row">
                                                <div class="col-md-offset-1 col-md-9">
                                                    <asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" SkinID="lbtnAddRow" Visible="true">
                                                    </asp:LinkButton>
                                                    <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                                                    <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Account/ACC_Income/ACC_IncomeList.aspx"></asp:HyperLink>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
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
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>


