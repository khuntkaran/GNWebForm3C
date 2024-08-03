<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPageView.master" AutoEventWireup="true" CodeFile="STU_StudentView.aspx.cs" Inherits="AdminPanel_Student_STU_Student_STU_StudentView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!-- BEGIN SAMPLE FORM PORTLET-->
    <div class="portlet light">
        <div class="portlet-title">
            <div class="caption">
                <asp:Label SkinID="lblViewFormHeaderIcon" ID="lblViewFormHeaderIcon" runat="server"></asp:Label>
                <span class="caption-subject font-green-sharp bold uppercase">Student </span>
            </div>
            <div class="tools">
                <asp:HyperLink ID="CloseButton" SkinID="hlClosemymodal" runat="server" ClientIDMode="Static"></asp:HyperLink>
            </div>
        </div>
        <div class="portlet-body form">
            <div class="form-horizontal" role="form">
                <table class="table table-bordered table-advance table-hover">
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblStudentName_XXXXX" Text="Student Name" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblStudentName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblEnrollmentNo_XXXXX" Text="Enrollment No" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEnrollmentNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblCurrentSem_XXXXX" Text="Current Sem" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCurrentSem" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblEmailInstitute_XXXXX" Text="Email Institute" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEmailInstitute" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblEmailPersonal_XXXXX" Text="Email Personal" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEmailPersonal" runat="server"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblGender_XXXXX" Text="Gender" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblGender" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblRollNo_XXXXX" Text="Roll No" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblRollNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblBirthDate_XXXXX" Text="Birth Date" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblBirthDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblContactNo_XXXXX" Text="Contact No" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblContactNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    

                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblUserID_XXXXX" Text="User" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblUserID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblCreated_XXXXX" Text="Created" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCreated" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblModified_XXXXX" Text="Modified" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblModified" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <!-- END SAMPLE FORM PORTLET-->
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

