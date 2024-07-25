<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShowInfo.ascx.cs" Inherits="UserControl_ShowInfo" %>
<asp:MultiView ID="mvwSysMessage" runat="server" Visible="false" EnableViewState="false">
    <asp:View ID="vwError" runat="server">
        <div class="alert alert-danger margin-top-10">
            <i class="fa fa-times-circle"></i>
            <asp:Label ID="lblError" runat="server" EnableViewState="false" />
        </div>
    </asp:View>
    <asp:View ID="vwSuccess" runat="server">
        <div class="alert alert-success  margin-top-10">
            <i class="fa fa-check-circle"></i>
            <asp:Label ID="lblSuccess" runat="server" EnableViewState="false" />
        </div>
    </asp:View>
    <asp:View ID="vwInfo" runat="server">
        <div class="alert alert-info  margin-top-10">
            <i class="fa fa-info-circle"></i>
            <asp:Label ID="lblInfo" runat="server" EnableViewState="false" />
        </div>
    </asp:View>
</asp:MultiView> 