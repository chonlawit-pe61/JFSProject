$(function () {
    var componentName = 'casechiefopinion';
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#applicantID' + componentName).val() != 0 && !$(':radio[name=rdochiefOpinion]').is(':checked')) {
            //Load data
            console.log($('#isappeal' + componentName).val());
            var frm = $(this).closest('form');
            $.ajax({
                url: '/jfservices/getcasechiefopinion',
                method: 'POST',
                data: {
                    applicantID: $('#applicantID' + componentName).val(),
                    officerRoleID: $('#OfficerRoleID' + componentName).val(),
                    IsAppeal: ($('#isappeal' + componentName).val() == 1 ? true : false),                    

                },
                beforeSend: function () { },
                success: function (data) {

                    console.log(data);

                    if (data.Data != null) {
                        $('input[name=rdochiefOpinion]').filter('#rdochiefOpinion' + data.Data.OpinionID).iCheck('check');
                        $('#Remark' + componentName).val(data.Data.Remark).trigger('input');
                        

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
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        var frm = $(this).closest('form');
        frm.find('.js--btsave' + componentName).hide();
        frm.find('.js--cancel').hide();
    });


    $('#frm' + componentName)

        .off('keyup change ifChanged', '.js-text')
        .on('keyup change ifChanged', '.js-text', function (e) {
            var frm = $('#frm' + componentName);
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {
            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {
    
                        //var applicantOpinionData = [];
                        var opinionCheck = $('input[name="rdochiefOpinion"]').is(':checked');
                        if (opinionCheck) {
                            var opinionID = parseInt($('input[name="rdochiefOpinion"]:checked').val());
                            opinionData = opinionID;

                        }
                        var applicantOpinionData1 = {
                            ApplicantID: $('#applicantID' + componentName).val(),
                            OfficerRoleID: $('#OfficerRoleID' + componentName).val(),
                            IsAppeal: ($('#isappeal' + componentName).val() == 1 ? true : false), 
                            OpinionID: opinionData,
                            Remark: $('#Remark' + componentName).val(),
                        }
                        $.ajax({
                            url: '/jfservices/savecaseopinionofficer',
                            method: 'POST',
                            data: {
                                req: applicantOpinionData1,
                            },
                            beforeSend: function () { },
                            success: function (data) {

                                if (data.Status) {
                                    SWSuccess.fire();
                                } else {

                                    SWError.fire();
                                }

                            }
                            , error: function (err) {
                                if (err.status == 401) {
                                    window.location.reload();
                                }
                            }
                        });
                var frm = $('#frm' + componentName);
                frm.find('.header-icon').remove();
                frm.find('.js--btsave' + componentName).hide();
                frm.find('.js--cancel').hide();
            }
        });

});