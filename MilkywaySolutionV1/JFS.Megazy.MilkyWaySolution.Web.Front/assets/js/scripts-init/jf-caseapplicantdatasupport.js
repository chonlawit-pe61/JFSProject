// Begin การไกล่เกลี่ย
$(function () {

    var componentName = 'caseapplicantdatasupport';



    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        //console.log($('#applicantID' + componentName).val());
        var frm = $('#frm' + componentName);
        if ($('#applicantID' + componentName).val() != 0 && $('#ApplicantSummary' + componentName).val() == '') {
            //Load data
            //console.log($('#applicantID' + componentName).val());
            $.ajax({
                url: '/jfscaseexpense/getcaseapplicantofficeropinion',
                method: 'POST',
                data: {
                    applicantID: $('#applicantID' + componentName).val(),
                    status: false,
                },
                beforeSend: function () { },
                success: function (data) {
                    console.log(data);
                    if (data.Status == true) {  
                        var value = data.Data.CaseApplicantOpinionRow;
                        
                        $('#ApplicantSummary' + componentName).val(value.ApplicantSummary).trigger('input');
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
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) { Common.swcithTabIcon(this); });


    $('#frm' + componentName)
        .off('keyup ifChanged', '.js-text')
        .on('keyup ifChanged', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        }).off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {

            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {
                
                var CaseApplicantOfficerOpinion = {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    ApplicantSummary: $('#ApplicantSummary' + componentName).val(),
                }
                $.ajax({
                    url: '/jfscaseexpense/savecaseapplicantofficeropinion',
                    method: 'POST',
                    data: {
                        req: CaseApplicantOfficerOpinion
                    },
                    beforeSend: function () {
                    },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            //$('#applicantID' + componentName).val(data.ID);

                            SWSuccess.fire();
                        }
                    }
                    , error: function (err) {
                        if (err.status == 401) {
                            window.location.reload();
                        }
                    }
                });

                frm.find('.js--btsave' + componentName).hide();
                frm.find('.js--cancel').hide();
                frm.find('.header-icon').remove();
                   
            }

        });



});
