
var ComponentsDateTimePickers=function() {

    var handleDatePickers=function() {

        if(jQuery().datepicker) {
            $('.date-picker').datepicker({
                rtl: App.isRTL(),
                orientation: "left",
                autoclose: true,
                todayHighlight: true
            });
            //$('body').removeClass("modal-open"); // fix bug when inline picker is used in modal
        }

        /* Workaround to restrict daterange past date select: http://stackoverflow.com/questions/11933173/how-to-restrict-the-selectable-date-ranges-in-bootstrap-datepicker */

        // Workaround to fix datepicker position on window scroll
        $(document).scroll(function() {
            $('#form_modal2 .date-picker').datepicker('place'); //#modal is the id of the modal
        });
    }

    var handleTimePickers=function() {

        if(jQuery().timepicker) {
            $('.timepicker-default').timepicker({
                autoclose: true,
                showSeconds: true,
                minuteStep: 1
            });

            $('.timepicker-no-seconds').timepicker({
                autoclose: true,
                minuteStep: 5,
                defaultTime: null
            });

            $('.timepicker-24').timepicker({
                autoclose: true,
                minuteStep: 5,
                showSeconds: false,
                showMeridian: false
            });

            // handle input group button click
            $('.timepicker').parent('.input-group').on('click', '.input-group-btn', function(e) {
                e.preventDefault();
                $(this).parent('.input-group').find('.timepicker').timepicker('showWidget');
            });

            // Workaround to fix timepicker position on window scroll
            $(document).scroll(function() {
                $('#form_modal4 .timepicker-default, #form_modal4 .timepicker-no-seconds, #form_modal4 .timepicker-24').timepicker('place'); //#modal is the id of the modal
            });
        }
    }


    var handleDatetimePicker=function() {

        if(!jQuery().datetimepicker) {
            return;
        }



        $(".form_meridian_datetime").datetimepicker({
            isRTL: App.isRTL(),
            format: "dd-mm-yyyy hh:mm P",
            showMeridian: true,
            autoclose: true,
            fontAwesome: true,
            pickerPosition: (App.isRTL()?"bottom-right":"bottom-left"),
            todayBtn: true,
            todayHighlight: true
        });

        $('body').removeClass("modal-open"); // fix bug when inline picker is used in modal

        // Workaround to fix datetimepicker position on window scroll
        $(document).scroll(function() {
            $('#form_modal1 .form_datetime, #form_modal1 .form_advance_datetime, #form_modal1 .form_meridian_datetime').datetimepicker('place'); //#modal is the id of the modal
        });


    }

    return {
        //main function to initiate the module
        init: function() {
            handleDatePickers();
            handleTimePickers();
            handleDatetimePicker();
        }
    };

}();


var InitMain=function() {
    return {
        //main function to initiate the module
        init: function() {
            UI_Select2.init();
            ComponentsDateTimePickers.init();
            $(function() {
                $('[data-toggle="tooltip"]').tooltip()
            })

            // Aadhar No Validation By Keyur
            $(document).ready(function() {
                var AadharNo;
                var LeftPart;
                $(".GNAadharNo").keydown(function(event) {
                    var txtCurrentControl=$(this);

                    if(txtCurrentControl.val().length==4) {
                        AadharNo=txtCurrentControl.val().slice(0, 4);
                        AadharNo+=" ";
                        txtCurrentControl.val(AadharNo);
                    }


                    if(txtCurrentControl.val().length==9) {
                        LeftPart=txtCurrentControl.val().slice(0, 5);
                        AadharNo=txtCurrentControl.val().slice(5, 9);
                        AadharNo+=" ";
                        AadharNo=LeftPart+AadharNo;
                        txtCurrentControl.val(AadharNo);
                    }
                });
            });

            /* To Select Option On Tab in Select2 */

            $("body").on('select2:closing', function (e) {
                // save in case we want it
                var $sel2 = $(e.target).data("select2");
                var $sel = $sel2.$element;
                var $selDropdown = $sel2.$results.find(".select2-results__option--highlighted")
                var newValue = $selDropdown.data("data").element.value;

                // must be closed by a mouse or keyboard - listen when that event is finished
                // this must fire once and only once for every possible menu close 
                // otherwise the handler will be sitting around with unintended side affects
                $("html").once('keyup mouseup', function (e) {

                    // if close was due to a tab, use the highlighted value
                    var KEYS = { UP: 38, DOWN: 40, TAB: 9, ENTER : 13 }
                    if (e.keyCode === KEYS.TAB || e.keyCode === KEYS.ENTER) {
                        if (newValue != undefined) {
                            $sel.val(newValue);
                            $sel.trigger('change');
                            $sel.focus();
                        }
                    }

                });

            });

            $.fn.once = function (events, callback) {
                return this.each(function () {
                    $(this).on(events, myCallback);
                    function myCallback(e) {
                        $(this).off(events, myCallback);
                        callback.call(this, e);
                    }
                });
            };

            /* To Select Option On Tab in Select2 */


        }
    };

}();