// Begin การไกล่เกลี่ย
$(function () {
    var componentName = 'caseresult';
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        var frm = $('#frm' + componentName);
        if ($('#applicantID' + componentName).val() != 0 && $('#result' + componentName).val() == '') {
            validateNotify();
            $.ajax({
                url: '/jfservices/getfinalapproved',
                method: 'POST',
                data: {
                    caseID: $('#caseID' + componentName).val(),
                    isAppeal: $('#isappeal' + componentName).val(),
                },
                beforeSend: function () { },
                success: function (data) {
                    console.log(data);
                    var temp = Handlebars.compile($('#tmpl-decisionresult').html());
                    $('#decisionresult').html(temp(data.Data));
                    $('#result' + componentName).val(data.Data.ShortDescription);
                    if (data.Data.NotifyDateStr != null && data.Data.NotifyDateStr != "") {
                    $('#dateResult' + componentName).val(Common.JSONDate(data.Data.NotifyDate));
                        $('#dateResult' + componentName).attr('disabled', 'disabled')
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
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) { Common.swcithTabIcon(this); });


    $('body')
        .off('click', '#btsendsms' + componentName)
        .on('click', '#btsendsms' + componentName, function (e) {
            var frm = $('#frmnotify-sms' + componentName);
            if (frm.validationEngine('validate')) {
                $(this).attr('disabled', 'disabled');
                $.ajax({
                    url: '/messaging/smsnotifydecisionresult',
                    method: 'post',
                    data: {
                        telephonno: $('#smsnumbernoti' + componentName).val(),
                        applicantID: $('#applicantID' + componentName).val(),
                        caseID: $('#caseID' + componentName).val(),
                    },
                    beforesend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            SWSuccess.fire({ title: 'ส่งข้อความเรียบร้อยแล้ว' });
                            $('#btsendsms' + componentName).removeAttr('disabled');
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });
          }
        }).off('click', '#btsendemail' + componentName)
        .on('click', '#btsendemail' + componentName, function (e) {
            var frm = $('#frmnotify-email' + componentName);
            if (frm.validationEngine('validate')) {
                $(this).attr('disabled', 'disabled');
                $.ajax({
                    url: '/messaging/emailnotifydecisionresult',
                    method: 'POST',
                    data: {
                        emailTo: $('#emailnoti' + componentName).val(),
                        applicantID: $('#applicantID' + componentName).val(),
                        caseID: $('#caseID' + componentName).val(),
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            SWSuccess.fire({ title: 'ส่งอีเมลเรียบร้อยแล้ว' });
                        }
                        $('#btsendemail' + componentName).removeAttr('disabled');
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });

            }
        });

    $('#frm' + componentName)
        .off('change', '.js--text')
        .on('change', '.js--text', function (e) {
            var frm = $(this).closest('form');
            console.log('js--text');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        }).off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        .off('click', '#btnsendresult')
        .on('click', '#btnsendresult', function (e) {
            //if ($('#hasOpinion').val() == 0) {
            //    alert('please select term and consideration');
            //} else {
            $('#modalnotifyresult').modal('show');
            // }

        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {
            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {
                var NotifyDecisionResultData= {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    CaseID: $('#caseID' + componentName).val(),
                    NotifyDateStr: $('#dateResult' + componentName).val(),
                }
                //console.log(NotifyDecisionResult);
                $.ajax({
                    url: '/jfservices/savedatenotifydecisionresult',
                    method: 'POST',
                    data: { req: NotifyDecisionResultData},
                    beforeSend: function () {
                    },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            SWSuccess.fire();
                        }
                    }
                    , error: function (err) {
                        if (err.status == 401) {
                            window.location.reload();
                        }
                    }
                });

                frm.find('.header-icon').remove();
                frm.find('.js--btsave' + componentName).hide();
                frm.find('.js--cancel').hide();
            }


        });
    function validateNotify() {
        if ($('#workStepID').length) {
           //6 แจ้งผล
          
                if ($('#workStepProgress option:last-child').val() == 6) {
                $('#btnsendresult').show();
                var temp = Handlebars.compile($('#tmpl-modalnotifyresult').html());
                $('body').append(temp());
            } else {
                $('#btnsendresult').hide();
            }
        }
    }


});
