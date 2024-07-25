using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace GNForm3C
{
    public class CSSClass
    {
        #region System Configuration

        public static string ModalCSSClassIFrame = "GNModalIFrame";
        public static string ModalCSSClass = "modalButton";

        #endregion System Configuration

        #region Pagination Class
        public static String PaginationButton = "pagination_button";
        public static String PaginationButtonActive = "pagination_button active";
        public static String PaginationButtonDisabled = "";
        #endregion Pagination Class

        #region Status Labels
        public static string StatusLabelSuccess = "label label-sm label-success btn-circle";
        public static string StatusLabelDanger = "label label-sm label-danger btn-circle";
        public static string StatusLabelWarning = "label label-sm label-warning btn-circle";
        public static string StatusLabelInfo = "label label-sm label-info btn-circle";
        public static string StatusLabelDefault = "label label-sm label-default btn-circle";

        public static string alertsuccess = "alert alert-success";
        public static string alertinfo = "alert alert-info";
        public static string alertwarning = "alert alert-warning";
        public static string alertdanger = "alert alert-danger";
        public static string badgeinfo = "badge badge-info";
        public static string badgesuccess = "badge badge-success";
        public static string badgedanger = "badge badge-danger";
        public static string badgewarning = "badge badge-warning";
        public static string btncircleSuccessSmall = "btn btn-circle btn-xs btn-success";
        public static string btncircleDangerSmall = "btn btn-circle btn-xs btn-danger";
        public static string btncircleWarningSmall = "btn btn-circle btn-xs btn-warning";
        public static string btnLock = ModalCSSClass + " btn default btn-xs red";
        public static string btnUnlock = ModalCSSClass + " btn default btn-xs green";

        public static string btnsmdefault = "btn btn-sm btn-default";
        public static string btnsmprimary = "btn btn-sm btn-primary";
        public static string btnsmsuccess = "btn btn-sm btn-success";
        public static string btnsminfo = "btn btn-sm btn-info";
        public static string btnsmwarning = "btn btn-sm btn-warning";
        public static string btnsmdanger = "btn btn-sm btn-danger";        


        public static string bgtdSuccess = "success";
        public static string bgtddanger = "danger";
        public static string bgtdwarning = "warning";
        public static string bgtdactive = "active";
        public static string LabelSuccess = "label label-success";
        public static string LabelDanger = "label label-danger";
        public static string LabelWarning = "label label-warning";
        public static string LabelInfo = "label label-info";
        public static string LabelDefault = "label label-default";

        public static string LabelSuccess_Small = "label label-success label-sm";
        public static string LabelDanger_Small = "label label-danger  label-sm";
        public static string LabelWarning_Small = "label label-warning  label-sm";
        public static string LabelInfo_Small = "label label-info  label-sm";
        public static string LabelDefault_Small = "label label-default  label-sm";

        #endregion Status Labels

        #region ToDo

        public static string divToDoGreen = "todo-tasklist-item todo-tasklist-item-border-green";
        public static string divToDoBlue = "todo-tasklist-item todo-tasklist-item-border-blue";
        public static string divToDoRed = "todo-tasklist-item todo-tasklist-item-border-red";

        #endregion ToDo

        #region TrueFalse
        public static string True = "fa fa-check";
        public static string False = "fa fa-remove";
        #endregion TrueFalse

        #region Font Color
        public static string FontRed = "font-red-flamingo";
        public static string FontGreen = "font-green";
        #endregion Font Color

        #region TextColor
        public static string textGreen = "text-success";
        public static string textRed = "text-danger";
        #endregion TextColor

        #region BadgeColor

        public static string badgeRed = "badge bg-red-thunderbird";

        #endregion BadgeColor

        #region Document Icon class
        public static string DownloadIcon = "fa fa-download";
        public static string ExcelIcon = "fa fa-file-excel-o";
        public static string WordIcon = "fa fa-file-word-o";
        public static string PDFIcon = "fa fa-file-pdf-o";
        public static string TXTIcon = "fa fa-file-text";

        public static string ImageIcon = "fa fa-image";

        #endregion Document Icon class

        public CSSClass()
        {

        }

        #region Exam Dashboard Tile Color Class
        public static string TileRed = "tile bg-red-sunglo";
        public static string TileBlue = "tile bg-blue-steel";
        public static string TileGreen = "tile bg-green-meadow";
        public static string Tiledoubledown = "double-down";
        public static string Tiledouble = "double";
        #endregion Exam Dashboard Tile Color Class

        #region PrintCSS

        public static string PrintCSS = @"<style>

                                                  @page {
                                    size: landscape;
                                }

                                @media print {
                                    @page {
                                        size: landscape;
                                    }
                                }
                                
                                body {
                                font-size: 11px;
                                line-height: 1.42857143 !important;
                                }

                                label {
                                display: inline-block;
                                max-width: 100%;
                                margin-bottom: 5px;
                                font-size: 14px;
                                    }
                                
                                .RecessColor {
                                    background-color: #f2f2f2 !important;
                                    height: 10px !important;
                                }
                                
                                .LABColor {
                                    background-color: #f2f2f2 !important;
                                }

                                .BackgroundGray {
                                    background-color: #e6e6e6 !important;
                                }

                                .landScape {
                                    width: 100%;
                                    height: 100%;
                                    margin: 0% 0% 0% 0%;
                                    filter: progid:DXImageTransform.Microsoft.BasicImage(Rotation=3);
                                }

                                @page

                                .print-landscape-a4 {
                                    margin: 3cm;
                                    size: A4 landscape;
                                }

                                @media print and (width: 21cm) and (height: 29.7cm) {
                                    @page

                                    .print-landscape-a4 {
                                        margin: 3cm;
                                        size: A4 landscape;
                                    }
                                }

                               @media print {
                                        body {
                                            -webkit-print-color-adjust: exact;
                                        }
                                    }

                                    .btn {
                                    border-width: 0;
                                    padding: 7px 14px;
                                    font-size: 14px;
                                    outline: none !important;
                                    background-image: none !important;
                                    filter: none;
                                    -webkit-box-shadow: none;
                                    -moz-box-shadow: none;
                                    box-shadow: none;
                                    text-shadow: none;
                                }

                                .pull-right {
                                    float: right!important;
                                }
                        
                                .btn.blue-stripe {
                                        border-left: 3px solid #3598dc;
                                    }
                                    .btn.default {
                                        color: #333333;
                                        background-color: #E5E5E5;
                                    }
                                    .table .btn {
                                        margin-top: 0px;
                                        margin-left: 0px;
                                        margin-right: 5px;
                                    }
                                    .table .btn {
                                        margin-right: 0px !important;
                                    }

                            
                                tr {
                                    display: table-row;
                                    vertical-align: top;
                                    border-color: inherit;
                                }


                                .table-bordered-black {
                                    border: 1px solid #000000 !important;
                                }

                                    .table-bordered-black > thead > tr > th,
                                    .table-bordered-black > tbody > tr > th,
                                    .table-bordered-black > tfoot > tr > th,
                                    .table-bordered-black > thead > tr > td,
                                    .table-bordered-black > tbody > tr > td,
                                    .table-bordered-black > tfoot > tr > td {
                                        border: 1px solid #000000 !important;
                                        }
                                hr {
                                        margin: 10px 0;
                                        border: 0;
                                        border-top: 1px solid #eee;
                                        border-bottom: 0;
                                   }

                                table {
                                        width: 100%;
                                        max-width: 100%
                                        border-spacing: 0;
                                        border-collapse: collapse; 
                                    }
                               .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
                                    padding: 7px !important;
                                    }
                                   
                                .Width175 {
                                    width: 175px !important;
                                }

                                .text-center {
                                    text-align: center !important;
                                    vertical-align: middle !important;  
                                }
                                
                                .text-vertical-center {
                                    vertical-align: middle !important;  
                                }   
                        
                                 .text-nowrap {
                                    white-space: nowrap;
                                }

                                .Width150 {
                                    width: 150px !important;
                                }

                                .Width200 {
                                    width: 200px !important;
                                }

                                .Width100 {
                                    width: 100px !important;
                                }

                                .height70 {
                                    height: 70px !important;
                                }

                                .font10 {
                                    font-size: 10px !important;
                                }

                                .font11 {
                                    font-size: 11px !important;
                                }
                                
                                .font18 {
                                    font-size: 18px !important;
                                }
                                .font25 {
                                    font-size: 25px !important;
                                }

                                .font12 {
                                    font-size: 12px !important;
                                }  </style>";


        #endregion PrintCSS

        public static string RecessColor = "#e6e6e6";

        public static string StudentAbsentRowCssClass = "danger";

        public static String MarkAbsentCSSClass = "bg-yellow  font-white";
        public static String MarkFailCSSClass = "bg-red-pink font-white";

        public static String MarkAbsentCSSClassLabel = "bg-yellow label font-white";
        public static String MarkFailCSSClassLabel = "bg-red-pink font-white label";

        public static class HostelBedStatus
        {
            public static class FontColor
            {
                public static String NotInUse = "font-grey-gallery";
                public static String Reserved = "font-blue-madison";
                public static String Vacant = "font-green";
            }

            public static class Button
            {
                public static String NotInUse = "btn grey-gallery";
                public static String Reserved = "btn blue-madison";
                public static String Vacant = "btn green";
            }
        }

        public static class GNTextColor
        {
            public static String Red = "font-red-intense";
        }
    }
}