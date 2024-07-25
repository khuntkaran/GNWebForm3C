<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPageView.master" AutoEventWireup="true" CodeFile="EMP_EmployeeDetailView.aspx.cs" Inherits="AdminPanel_Employee_EMP_EmployeeDetail_EMP_EmployeeDetailView" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
        	<!-- BEGIN SAMPLE FORM PORTLET-->
				<div class="portlet light">
					<div class="portlet-title">
						<div class="caption">
							<asp:Label SkinID="lblViewFormHeaderIcon" ID="lblViewFormHeaderIcon" runat="server"></asp:Label>
							<span class="caption-subject font-green-sharp bold uppercase">Employee Detail</span>
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
							<asp:Label ID="lblEmployeeName_XXXXX" Text="Employee Name" runat="server"></asp:Label>
							</td>
							<td>
							<asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
							</td>
						</tr>
						<tr>
							<td class="TDDarkView">
							<asp:Label ID="lblEmployeeType_XXXXX" Text="Employee Type" runat="server"></asp:Label>
							</td>
							<td>
							<asp:Label ID="lblEmployeeType" runat="server"></asp:Label>
							</td>
						</tr>
						<tr>
							<td class="TDDarkView">
							<asp:Label ID="lblRemarks_XXXXX" Text="Remarks" runat="server"></asp:Label>
							</td>
							<td>
							<asp:Label ID="lblRemarks" runat="server"></asp:Label>
							</td>
						</tr>
						<tr>
							<td class="TDDarkView">
							<asp:Label ID="lblUserName_XXXXX" Text="User" runat="server"></asp:Label>
							</td>
							<td>
							<asp:Label ID="lblUserName" runat="server"></asp:Label>
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
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" Runat="Server">
    <script>
        $(document).keyup(function (e) {
        if (e.keyCode == 27) {;
	        $("#CloseButton").trigger("click");
        }
        });
    </script>
</asp:Content>

