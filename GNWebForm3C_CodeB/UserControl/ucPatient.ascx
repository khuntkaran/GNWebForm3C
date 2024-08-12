<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPatient.ascx.cs" Inherits="UserControl_ucPatient" %>

<asp:MultiView ID="mvwPatient" runat="server" Visible="false" EnableViewState="false">
    <asp:View ID="vwPatient" runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="portlet light">
                    <div class="portlet-title ">
                        <div class="caption">
                            <span class="caption-subject font-green-sharp bold uppercase">
                                <i class="fa fa-user font-green-sharp"></i>Patient Details
                            </span>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="row">
                            <div class="col-md-12">
                                <ul class="nav">
                                    <li class="text-center margin-bottom-10 margin-top-10">
                                        <asp:Image ID="imhPatient" runat="server" Height="180" CssClass=" img-circle imgStudentPhoto" AlternateText="Patient Image" EnableViewState="false" ImageUrl="https://www.gnwebsoft.com/Default/assets/img-gnweb/Slider_Round_Image.png" />

                                    </li>
                                </ul>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div id="ctl00_cphPageContent_ucStudentInfoCompact_divBottom" class="table-responsive">
                                    <table class="table">
                                        <tbody>
                                            <tr class="text-center">
                                                <td class="text-center sbold" colspan="2">
                                                    <h4>
                                                        <asp:Label EnableViewState="false" ID="lblucTitle" class="bold font-blue-soft text-center gn-label" runat="server"></asp:Label>

                                                    </h4>
                                                    <small>
                                                        <span id="lblAddmit" title="" class="label label-sm label-success sbold" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Status Date : 03-10-2021">On Roll</span>

                                                    </small>
                                                </td>
                                            </tr>




                                            <tr>
                                                <th class="gn-view-label-header text-right text-nowrap">Patient Name :</th>
                                                <td class="gn-view-label-value">
                                                    <asp:Label EnableViewState="false" runat="server" ID="lblucPatientName" title="" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Patient Name"></asp:Label>

                                                </td>
                                            </tr>

                                            <tr>
                                                <th class="gn-view-label-header text-right text-nowrap">Age :</th>
                                                <td class="gn-view-label-value">
                                                    <asp:Label EnableViewState="false" runat="server" ID="lblucPatietAge" title="" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Patient Age"></asp:Label>

                                                </td>
                                            </tr>

                                            <tr>
                                                <th class="gn-view-label-header text-right text-nowrap">Date of Birth :</th>
                                                <td class="gn-view-label-value">
                                                    <asp:Label EnableViewState="false" ID="lblucDOB" runat="server" title="" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Patient DOB"></asp:Label>

                                                </td>
                                            </tr>

                                            <tr>
                                                <th class="gn-view-label-header text-right text-nowrap">Mobile No. :</th>
                                                <td class="gn-view-label-value">
                                                    <asp:Label EnableViewState="false" ID="lblucMobileNo" runat="server" title="" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="<i class='fa fa-phone'></i> Patient Mobile No."></asp:Label>

                                                </td>
                                            </tr>

                                            <tr>
                                                <th class="gn-view-label-header text-right text-nowrap">Primary Description :</th>
                                                <td class="gn-view-label-value">
                                                    <asp:Label EnableViewState="false" ID="lblucPrimaryDesc" runat="server" title="" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Primary Description"> </asp:Label>

                                                </td>
                                            </tr>

                                        </tbody>

                                    </table>


                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </asp:View>
</asp:MultiView>