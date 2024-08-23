<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <!-- costom css My-->
    <link href="Default/CSS/login.css" rel="stylesheet" />


    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <link href="../assets/global/plugins/select2/css/select2.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/select2/css/select2-bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL STYLES -->
    <link href="../assets/global/css/components.min.css" rel="stylesheet" id="style_components" type="text/css" />
    <link href="../assets/global/css/plugins.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="../assets/pages/css/login.min.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL STYLES -->




    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />

    <!-- BEGIN GLOBAL MANDATORY STYLES -->

    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/font-awesome/css/font-awesome.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/simple-line-icons/simple-line-icons.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/bootstrap/css/bootstrap.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />

    <!-- END GLOBAL MANDATORY STYLES -->

    <!-- BEGIN PAGE LEVEL PLUGINS -->

    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />

    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/bootstrap-timepicker/css/bootstrap-timepicker.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />

    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/select2/css/select2.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/select2/css/select2-bootstrap.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />

    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/datatables/datatables.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/animate/animate.css?V=2_20200225") %>" rel="stylesheet" />

    <!-- END PAGE LEVEL PLUGINS -->


    <!-- BEGIN THEME GLOBAL STYLES -->
    <link href="<%=ResolveClientUrl("~/Default/assets/global/css/components.min.css?V=2_20200225") %>" rel="stylesheet" id="style_components" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/global/css/plugins.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->

    <!-- BEGIN THEME LAYOUT STYLES -->
    <link href="<%=ResolveClientUrl("~/Default/assets/layouts/layout/css/layout.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/assets/layouts/layout/css/themes/darkblue.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" id="style_color" />
    <link href="<%=ResolveClientUrl("~/Default/assets/layouts/layout/css/custom.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <!-- END THEME LAYOUT STYLES -->


</head>
<body style="background-color: dark">
    <form id="form1" runat="server">

        <div class="row">
            <div class="container">
                <div class="col-md-2"></div>
                <div class="col-md-8">

                    <div class="portlet light rounded-3">
                        <div class="portlet-title">
                            <div class="caption">
                                <span class="caption-subject font-green-sharp bold uppercase">
                                    <h3 class="bold">Login</h3>
                                </span>
                            </div>
                        </div>
                        <div class="portlet-body">

                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Image ImageUrl="~/Default/assets/global/img/login.png" runat="server" CssClass="img-responsive" />
                                </div>

                                <div class="col-md-6 margin-top-20">
                                    <div class="margin-bottom-20">
                                        <label class=" control-label">
                                            <i class="glyphicon glyphicon-user icon"></i>
                                            <asp:Label ID="Label1" CssClass="labal" runat="server" Text="UserName"></asp:Label>
                                        </label>
                                        <div class="margin-top-5">
                                            <asp:TextBox ID="txtUsername" CssClass="form-control rounded-3" runat="server" PlaceHolder="Enter UserName"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="font-sm" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtUserName" ErrorMessage="Enter UserName"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class=" margin-bottom-20">
                                        <label class=" control-label">
                                            <i class="glyphicon glyphicon-lock icon"></i>
                                            <asp:Label ID="Label3" CssClass="labal" runat="server" Text="Password"></asp:Label>
                                        </label>
                                        <div class="margin-top-5">
                                            <asp:TextBox ID="txtPassword" CssClass="form-control rounded-3" runat="server" PlaceHolder="Enter Password" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="font-sm" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-actions">

                                        <div class="btn-container">

                                            <asp:LinkButton runat="server" ID="lbtnLogin" CssClass="btn col-md-12 margin-bottom-25 rounded-4 " OnClick="lbtnLogin_Click">
                                Login&nbsp;&nbsp;<i class="fa fa-arrow-circle-right"></i>
                                            </asp:LinkButton>
                                        </div>


                                    </div>

                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
    </form>
</bod>
</html>
