<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPageView.master" AutoEventWireup="true" CodeFile="STU_StudentAddEditPopUp.aspx.cs" Inherits="AdminPanel_Student_STU_Student_STU_StudentAddEditPopUp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" runat="Server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upSTU_Student" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        
        <contenttemplate>
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
                    <div class="tools">
                        <asp:HyperLink ID="CloseButton" SkinID="hlClosemymodal" runat="server" ClientIDMode="Static"></asp:HyperLink>
                    </div>
                </div>


                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblStudentName_XXXXX" runat="server" Text="Student Name"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtStudentName" CssClass="form-control" runat="server" PlaceHolder="Enter Student Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblEnrollmentNo_XXXXX" runat="server" Text="Enrollment No"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtEnrollmentNo" CssClass="form-control" runat="server" PlaceHolder="Enter Enrollment No"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblCurrentSem_XXXXX" runat="server" Text="Current Sem"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlCurrentSem" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblEmailInstitute_XXXXX" runat="server" Text="Email Institute"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtEmailInstitute" CssClass="form-control" runat="server" PlaceHolder="Enter Email Institute"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblEmailPersonal_XXXXX" runat="server" Text="Email Personal"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtEmailPersonal" CssClass="form-control" runat="server" PlaceHolder="Enter Email Personal"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlGender" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblRollNo_XXXXX" runat="server" Text="Roll No"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtRollNo" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter RollNo"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblBirthDate_XXXXX" runat="server" Text="Birth Date"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                                        <asp:TextBox ID="dtpBirthDate" CssClass="form-control" runat="server" placeholder="Birth Date"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblContactNo" runat="server" Text="Contact No"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtContactNo" CssClass="form-control" runat="server" PlaceHolder="Enter Contact No"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                                    <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Student/STU_Student/STU_StudentList.aspx"></asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </contenttemplate>
    </asp:UpdatePanel>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="Server">
    <script>
        $(document).keyup(function (e) {
            if (e.keyCode == 27) {
                ;
                $("#CloseButton").trigger("click");
            }
        });
    </script>
</asp:Content>


