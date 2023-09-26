$(function () {

    var componentName = 'interviewfactconflict';
 
    $('#card-' + componentName).on('expanded.lte.widget', function (event) {
        Common.swcithTabIcon(this);
        var frm = $(this).closest('form');
        $body = $(this).find('.card-body div').first();
        if ($('#Charge' + componentName).val() == "" && $('#applicantID' + componentName).val() != 0) {
            //Load data
            $.ajax({
                url: '/jfservices/caseapplicant/getapplicantinterviewbail',
                method: 'POST',
                data: { applicantID: $('#applicantID' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    if (data.Status) {
                        console.log(data.Data);
                        var ApplicantInterviewBailData = data.Data.ApplicantInterviewBailData
                        $('#CriminalDate' + componentName).val(Common.JSONDate(ApplicantInterviewBailData.IssueDate))
                        $('#Officer' + componentName).val(ApplicantInterviewBailData.OfficerOrDepartment)
                        $('#Arrest' + componentName).val(ApplicantInterviewBailData.ArrestName)
                        //$('#ArrestWith' + componentName).val(data.Data.ArrestWith)
                        $(':radio[name=arrestwith' + componentName + '][value=' + (ApplicantInterviewBailData.ArrestWithStatus == true ? 1 : 0) + ']').iCheck('check');
                        $('#Charge' + componentName).val(ApplicantInterviewBailData.Charge)
                        $('#Penalty' + componentName).val(ApplicantInterviewBailData.Penalty)
                        if (data.Data.AccusedTellCode !== "") {
                            $(':radio[name=rdoaccusedtellcode][value=' + ApplicantInterviewBailData.AccusedTellCode + ']').iCheck('check');
                        }
                        $('#Testimony' + componentName).val(ApplicantInterviewBailData.Testify)
                        var newVal = new Option(ApplicantInterviewBailData.CaptureAs,0, true, true);
                        // Append it to the select
                        $('#dlprison' + componentName).append(newVal).trigger('change');   

                        if (data.Data.CaseArrestWithRow != null) {
                            $('.arrestwith').remove();
                            var temp = Handlebars.compile($('#tmpl-list-' + componentName).html());
                            console.log("CaseArrestWithRow");
                            console.log(data.Data.CaseArrestWithRow);
                            //counter = data.Data.expense.length;
                            $('#counter' + componentName).val(data.Data.CaseArrestWithRow.length);
                            if ($('#counter' + componentName).val() < 5) {
                                frm.find('#addfield'+componentName).show();
                            }
                            else {
                                frm.find('#addfield'+componentName).hide();
                            }

                            $.each(data.Data.CaseArrestWithRow, function (index, value) {
                                index++;
                                var DataSend = { ArrestWith: value, Count: index };
                                $('#divarrestwith').append(temp(DataSend));
                                counter = index;
                            });
                        }
                        //$('#dlprison' + componentName).trigger("change");
                        //$('#CaptureAs' + componentName).val(data.Data.CaptureAs)
                    }

                    frm.find('.js--btsave' + componentName).hide();
                    frm.find('.js--cancel').hide();
                }
                , error: function (err) {
                    console.log(err);
                }
            });

        } else { console.log('default') }
    });
    //Card 
    //Common.CollapsedCard(this);
    $('#card-' + componentName).on('collapsed.lte.widget', function (event) { Common.swcithTabIcon(this); });


    $('#frm' + componentName)
        .off('keyup ifChanged change', '.js-text')
        .on('keyup ifChanged change', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        //.off('ifChecked', ':radio[name=rdoaccusedtellcode]')
        //.on('ifChecked', ':radio[name=rdoaccusedtellcode]', function (e) {
        //    var frm = $(this).closest('form');
        //    frm.find('.js--btsave' + componentName).show();
        //    frm.find('.js--cancel').show();
        //})
        .off('ifChecked', ':radio[name=arrestwith' + componentName + ']')
        .on('ifChecked', ':radio[name=arrestwith' + componentName + ']', function (e) {
            var frm = $(this).closest('form');
            arrestwith = $(this).val();
            //console.log($(this).val());
            if ($(this).val() == 1) {
                $('#divarrestwith').show();
                $('#addfield' + componentName).show();
                var count = $('#counter' + componentName).val();
                count++;
                $('#counter' + componentName).val(count);
                if (count < 5) {
                    var frm = $('#frm' + componentName);
                    var temp = Handlebars.compile($('#tmpl-list-' + componentName).html());
                    var dataSend = { Count: count }
                    $('#divarrestwith').append(temp(dataSend));
                }
            }
            else {
                $('#divarrestwith').hide();
                $('#addfield' + componentName).hide();
            }
            frm.find('.js--cancel').show();
            frm.find('.js--btsave' + componentName).show();


        })
        .off('click', '.js--remove')
        .on('click', '.js--remove', function (e) {

           
            console.log("DataID Delete");
            var arrestwithID = $(this).data('id');
            
            
           
            console.log(arrestwithID);

            SWDelfirm.fire().then((result) => {
                //var frm = $(this).closest('form');                

                if (result.value) {
                    var $item = $('#divarrestwith div[data-count=' + $(this).data("count") + ']');
                    $item.closest("div").fadeOut("normal", function () {
                        $item.remove();
                    });

                    $.ajax({
                        type: 'POST',
                        url: '/jfservices/caseapplicant/deletearrestwith',
                        data: {
                            arrestwithID: arrestwithID,
                            applicantID: $('#applicantID' + componentName).val(),
                        },

                        beforeSend: function () { },
                        success: function (data) {
                            var frm = $('#frm' + componentName);
                            console.log('data = ', data);
                            if (data.Status) {
                                
                                SWSuccess.fire({
                                    title: 'ลบข้อมูลค่าใช้จ่ายสำเร็จ',
                                    onClose: () => {
                                       
                                        $('.arrestwith').remove();
                                        var temp = Handlebars.compile($('#tmpl-list-' + componentName).html());
                                        $('#counter' + componentName).val(data.Data.length);
                                        $.each(data.Data, function (index, value) {
                                            index++;
                                            var DataSend = { ArrestWith: value, Count: index };
                                            $('#divarrestwith').append(temp(DataSend));
                                            counter = index;
                                        });
                                        if (data.Data.length >= 5) {
                                            console.log($('#counter' + componentName).val());
                                            frm.find('#addfield'+componentName).hide();
                                        }
                                        else {
                                            frm.find('#addfield'+componentName).show();
                                        }
                                        frm.find('.js--cancel').hide();
                                        frm.find('.js--btsave' + componentName).hide();
                                    }
                                });
                            }
                            else {
                                $('.arrestwith').remove();
                                $('#counter' + componentName).val(data.Data.length);
                                var temp = Handlebars.compile($('#tmpl-list-' + componentName).html());

                                $.each(data.Data, function (index, value) {
                                    index++;
                                    var DataSend = { ArrestWith: value, Count: index };
                                    $('#divarrestwith').append(temp(DataSend));
                                    counter = index;
                                });
                                if (data.Data.length >= 5) {
                                    //console.log("notdata = ", $('#counter' + componentName).val());
                                    frm.find('#addfield'+componentName).hide();
                                }
                                else {
                                    frm.find('#addfield'+componentName).show();
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
        
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (event) {

            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {
                var data = {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    IssueDateStr: $('#CriminalDate' + componentName).val(),
                    OfficerOrDepartment: $('#Officer' + componentName).val(),
                    ArrestName: $('#Arrest' + componentName).val(),
                    ArrestWithStatus: ($(':radio[name=arrestwith' + componentName +']:checked').val() == '1' ? true: false),
                    Charge: $('#Charge' + componentName).val(),
                    Penalty: $('#Penalty' + componentName).val(),
                    Testify: $('#Testimony' + componentName).val(),
                    CaptureAs: $('#dlprison' + componentName+' option:selected').text()// $('#CaptureAs' + componentName).val(),
                }
                if ($(':radio[name=rdoaccusedtellcode]').is(':checked')) {
                    data.AccusedTellCode = $(':radio[name=rdoaccusedtellcode]:checked').val();
                }

                var arrestwith = [];

                const items = document.querySelectorAll("#divarrestwith .arrestwith ");
                console.log(items);
                items.forEach(function (data, index) {
                    index++;
                    
                        arrestwith.push({
                            ApplicantID: $('#applicantID' + componentName).val(),
                            ArrestWithID: $("#arrestwithID-" + index).val(),
                            ArrestWith: $("#arrestwith-" + index).val(),

                        });
                    
                    


                });

                console.log(data);
                console.log(arrestwith);
                $.ajax({
                    url: '/jfservices/caseapplicant/editapplicantinterviewbail',
                    method: 'POST',
                    data: {
                        req: data,
                        arr: arrestwith
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            //$('#applicantID' + componentName).val(data.ID);
                            SWSuccess.fire({
                                onClose: () => {
                                    if (data.Data != null) {
                                        $('.arrestwith').remove();
                                        var temp = Handlebars.compile($('#tmpl-list-' + componentName).html());
                                        console.log("CaseArrestWithRow");
                                        console.log(data.Data);
                                        //counter = data.Data.expense.length;
                                        $('#counter' + componentName).val(data.Data.length);
                                        if ($('#counter' + componentName).val() < 5) {
                                            frm.find('#addfield' + componentName).show();
                                        }
                                        else {
                                            frm.find('#addfield' + componentName).hide();
                                        }

                                        $.each(data.Data, function (index, value) {
                                            index++;
                                            var DataSend = { ArrestWith: value, Count: index };
                                            $('#divarrestwith').append(temp(DataSend));
                                            counter = index;
                                        });
                                    }
                                    else {
                                        $('.arrestwith').remove();
                                    }


                                }
                            });
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });

                frm.find('.js--btsave' + componentName).hide();
                frm.find('.js--cancel').hide();
                frm.find('.header-icon').remove();
            }
        }).off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        });
    $('.js--addfield' + componentName).click(function () {
        //counter++;
        var count = $('#counter' + componentName).val();
        count++;
        $('#counter' + componentName).val(count);
        var frm = $('#frm' + componentName);
        var temp = Handlebars.compile($('#tmpl-list-' + componentName).html());
        var dataSend = { Count: count }
        $('#divarrestwith').append(temp(dataSend));
        console.log("addcounter = ", count);

        if (count >= 5) {
            frm.find('.js--addfield' + componentName).hide();
           

        } else {
            frm.find('.js--addfield' + componentName).show();
        }
        frm.find('.js--cancel').show();
        frm.find('.js--btsave' + componentName).show();


    });

});
