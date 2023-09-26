

$(function () {
    //import { internalApiVersion } from "../vendors/calendar";
    var componentName = 'applicantcrime';
    var crimeEditId;
    var counter = 0;

   // $('#dateApp').datepicker();

    //Get Data
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {        
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#applicantID' + componentName).val() != 0 && $('#state'+componentName).val() == 0){
            console.log("Test");
            //Load data
            $.ajax({
                url: '/applicantcrime/getapplicantcrime',
                method: 'POST',
                data: { applicantID: $('#applicantID' + componentName).val() },
                async: false,
                beforeSend: function () { },
                success: function (data) {
                    $('#state' + componentName).val(1);
                    var frm = $('#frm' + componentName);
                    console.log(data);
                    if (data.Data != null) {
                        
                        if (data.Data.length > 0) {
                            $('#counter' + componentName).val(data.Data.length);
                            $('#crimefess' + componentName).iCheck('check');
                            //frm.find('#box-crime-' + componentName).removeClass('d-none');
                            var temp = Handlebars.compile($('#tmpl-list-' + componentName).html());
                            $.each(data.Data, function (index, value) {
                                index += 1;
                                var date = Common.JSONDate(value.CrimeDate);
                                console.log(value.CrimeDate);
                                var dataSend = { Result: value, Count: index, Date: date };
                                $('#divcrime').append(temp(dataSend));
                                // Datepicker
                                $('#crimedata' + componentName + index).datepicker({ language: 'th-TH' });

                                if (index == 3) {
                                    return false;
                                }
                            });
                            if (data.Data.length < 3) {

                                frm.find('.js--btadd' + componentName).show();
                            }
                            else {
                                frm.find('.js--btadd' + componentName).hide();
                            }
                            frm.find('.js--btsave' + componentName).hide();
                            frm.find('.js--cancel').hide();

                        }
                        
                    }
                    else {
                        //getSectionTracking($('#applicantID' + componentName).val());
                        if ($('#save' + componentName).val()) {
                            $('#notcrimefess' + componentName).iCheck('check');
                        }
                        frm.find('.js--btsave' + componentName).hide();
                        frm.find('.js--cancel').hide();
                        frm.find('#hr' + componentName).hide();
                        //frm.find('#box-crime-' + componentName).addClass('d-none');
                        //console.log(data);
                    }
                    
                    
                    
                }
                , error: function (err) {
                    console.log(err);
                }
            });

        } else { console.log('default') }
        
    });



   
    //Card 
    //Common.CollapsedCard(this);

    $('#card-' + componentName).on('collapsed.lte.widget', function (e) { Common.swcithTabIcon(this); });


    $('#frm' + componentName)
        .off('keyup ifChecked change', '.js-text')
        .on('keyup ifChecked change', '.js-text', function (e) {
            var frm = $(this).closest('form');
            if ($(this).val() == 1) {
                if ($('#counter' + componentName).val() <= 3) {
                    var fm = $('frm' + componentName);
                    frm.find('#hr' + componentName).show();
                    frm.find('.js--btadd' + componentName).show();
                }
            }
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('ifChecked', '.js-radio')
        .on('ifChecked', '.js-radio', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btadd' + componentName).show();

        })


        .off('ifChanged', 'input[name=crimefess' + componentName + ']:radio')
        .on('ifChecked', 'input[name=crimefess' + componentName + ']:radio', function (e) {

            var frm = $(this).closest('form');
            var reason = $(this).val();
           

            if (reason == 1 && $('#counter' + componentName).val() == 0) {
                frm.find('#box-crime-' + componentName).addClass('d-none');
                var count = $('#counter' + componentName).val();
                count++;
                $('#counter' + componentName).val(count);
                var frm = $('#frm' + componentName);
                var temp = Handlebars.compile($('#tmpl-list-' + componentName).html());
                var dataSend = { Count: count }
                $('#divcrime').append(temp(dataSend));
                console.log("addcounter = ", count);
                $('#crimedata' + componentName + count).datepicker({ language: 'th-TH' });
            }
            else {
                var count = $('#counter' + componentName).val();
                frm.find('.crime').remove();
                frm.find('.js--btadd' + componentName).hide();
            }


        })
        .off('click', '.js--btdelete')
        .on('click', '.js--btdelete', function (e) {

            ////alert(1);
            //var frm = $(this).closest('form');
            //var count = $('#counter' + componentName).val();
            //count--;

            //$('#counter' + componentName).val(count);
            ////var crimeID = $(this).data('id');
            //console.log($('#counter' + componentName).val());
            //if ($('#counter' + componentName).val() < 3) {
            //    frm.find('.js--btadd' + componentName).show();
            //}
            //else {
            //    frm.find('.js--btadd' + componentName).hide();
            //}


            var crimeID = $(this).data("id");

            console.log(crimeID);
            
            SWDelfirm.fire().then((result) => {
                //var frm = $(this).closest('form');                

                if (result.value) {
                    var $item = $('#divcrime div[data-count=' + $(this).data("count") + ']');
                    $item.closest("div").fadeOut("normal", function () {
                        $item.remove();
                    });

                    $.ajax({
                        type: 'POST',
                        url: '/applicantcrime/deleteapplicantcrime',
                        data: {
                            crimeId: crimeID,
                            applicantID: $('#applicantID' + componentName).val(),
                        },

                        beforeSend: function () { },
                        success: function (data) {
                            var frm = $('#frm' + componentName);
                            if (data.Status) {
                                SWSuccess.fire({
                                    title: 'ลบข้อมูลการกระทำความผิดสำเร็จ',

                                    onClose: () => {
                                        $('.crime').remove();
                                        var temp = Handlebars.compile($('#tmpl-list-' + componentName).html());
                                        $('#counter' + componentName).val(data.Data.length);
                                        $.each(data.Data, function (index, value) {
                                            index++;
                                            var date = Common.JSONDate(value.CrimeDate);
                                            console.log(value.CrimeDate);
                                            var dataSend = { Result: value, Count: index, Date: date };
                                            $('#divcrime').append(temp(dataSend));
                                            // Datepicker
                                            $('#crimedata' + componentName + index).datepicker({ language: 'th-TH' });

                                            if (index == 3) {
                                                return false;
                                            }
                                        });                                       
                                        if (data.Data.length >= 3) {
                                            frm.find('.js--btadd' + componentName).hide();
                                        }
                                        else {
                                            frm.find('.js--btadd' + componentName).show();
                                        }                                        
                                        frm.find('.js--cancel').hide();
                                        frm.find('.js--btsave' + componentName).hide();
                                    }
                                });
                            }
                            else {
                                $('.crime').remove();
                                var temp = Handlebars.compile($('#tmpl-list-' + componentName).html());
                                $('#counter' + componentName).val(data.Data.length);
                                $.each(data.Data, function (index, value) {
                                    index++;
                                    var date = Common.JSONDate(value.CrimeDate);
                                    console.log(value.CrimeDate);
                                    var dataSend = { Result: value, Count: index, Date: date };
                                    $('#divcrime').append(temp(dataSend));
                                    // Datepicker
                                    $('#crimedata' + componentName + index).datepicker({ language: 'th-TH' });

                                    if (index == 3) {
                                        return false;
                                    }
                                });
                                if (data.Data.length >= 3) {
                                    frm.find('.js--btadd' + componentName).hide();
                                }
                                else {
                                    frm.find('.js--btadd' + componentName).show();
                                }
                                frm.find('.js--cancel').hide();
                                frm.find('.js--btsave' + componentName).hide();
                            }

                        },
                        error: function (err) {
                            console.log(err);
                            SWError.fire({

                            });
                        }
                    });


                }
            });
            

            





        })
        .off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            var frm = $(this).closest('form');
            $('.js--btsave' + componentName).hide();
            frm.hide();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {
            
            var frm = $(this).closest('form');

            if (frm.validationEngine('validate')) {

                var status = $('input[name="crimefess' + componentName + '"]:checked').val();

                var applicantcrime = [];
                $('input[name=crimedata]').map(function (e) {
                    //console.log($(this));
                    var count = $(this).data('count');
                    console.log("count");
                    console.log(count);
                    applicantcrime.push({
                        ApplicantID: $('#applicantID' + componentName).val(),
                        CrimeID: $(this).data('id'),
                        PoliceStation: $("#policestation" + componentName + count).val(),
                        Charge: $("#charge" + componentName + count).val(),
                        LegalConsequence: $("#legalconsequence" + componentName + count).val(),
                        CrimeDate: $("#crimedata" + componentName + count).val(),

                    });

                });

                //console.log('-----status-----');
                //console.log(status);
                //console.log('---------applicantcrime-------------');
                //console.log(applicantcrime);
                $.ajax({
                        type: 'POST',
                    url: '/applicantcrime/saveapplicantcrime',
                    data: {
                        status: status,                                               
                        applicantID: $('#applicantID' + componentName).val(),
                        req: applicantcrime, 
                    },

                        beforeSend: function () { },
                        success: function (data) {
                            if (data.Status) {
                                SWSuccess.fire({
                                    onClose: () => {
                                        console.log("Test Save NO reload");
                                        console.log(data);
                                        if (data.Data != null) {
                                            $('.crime').remove();
                                            $('#counter'+componentName).val(data.Data.length);
                                            console.log($('#counter'+componentName).val());
                                            var temp = Handlebars.compile($('#tmpl-list-' + componentName).html());
                                            
                                            $.each(data.Data, function (index, value) {
                                                index++;
                                                var date = Common.JSONDate(value.CrimeDate);
                                                console.log(value.CrimeDate);
                                                var dataSend = { Result: value, Count: index, Date: date };
                                                $('#divcrime').append(temp(dataSend));
                                                // Datepicker
                                                $('#crimedata' + componentName + index).datepicker({ language: 'th-TH' });

                                                if (index == 3) {
                                                    return false;
                                                }


                                            });
                                            console.log("DataLange")
                                            console.log(data.Data.length);
                                            if (data.Data.length < 3) {
                                                frm.find('.js--btadd' + componentName).show();
                                            }
                                            else {
                                                frm.find('.js--btadd' + componentName).hide();
                                            }
                                            frm.find('.header-icon').remove();
                                        }
                                        else {
                                            frm.find('.header-icon').remove();
                                        }
                                    }
                                });
                            }
                            else {
                                SWError.fire({

                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            SWError.fire({

                            });
                        }
                    });
                frm.find('.js--cancel').hide();
                frm.find('.js--btsave' + componentName).hide();


            }


        });
    
        
    $('.js--btadd'+componentName).click(function () {
        //counter++;
        var count = $('#counter' + componentName).val();
        count++;
        $('#counter' + componentName).val(count);
        var frm = $('#frm' + componentName);
        var temp = Handlebars.compile($('#tmpl-list-' + componentName).html());
        var dataSend = { Count: count }
        $('#divcrime').append(temp(dataSend));
        console.log("addcounter = ", count);
        $('#crimedata' + componentName + count).datepicker({ language: 'th-TH' });
        if (count >= 3) {
            frm.find('.js--btadd' + componentName).hide();
            frm.find('#hr' + componentName).remove();           
            
        } else {
            frm.find('.js--btadd' + componentName).show();
        }
        frm.find('.js--cancel').show();
        frm.find('.js--btsave' + componentName).show();
       
        
    });



});