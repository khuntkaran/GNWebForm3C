<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucHelp.ascx.cs" Inherits="UserControl_ucHelp" %>
<asp:MultiView ID="mvwSysMessage" runat="server">
    <asp:View ID="vwHelp" runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="note note-info DivHelp g-mb-5" id="HelpDiv" runat="server">
                    <%--<h4 class="block">Help</h4>--%>
                    <p>
                        <asp:Label ID="lblHelp" runat="server" />
                    </p>
                </div>
            </div>
        </div>
    </asp:View>

</asp:MultiView>