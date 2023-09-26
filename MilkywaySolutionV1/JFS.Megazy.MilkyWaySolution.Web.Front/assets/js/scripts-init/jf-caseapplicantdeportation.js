// Begin การไกล่เกลี่ย
$(function () {

    var componentName = 'caseapplicantdeportation';



    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        var frm = $('#frm' + componentName);
        if ($('#applicantID' + componentName).val() != 0 && $('#Circumstance' + componentName).val() == '') {
            //Load data
            $.ajax({
                url: '/jfscaseexpense/getcaseapplicantofficeropinion',
                method: 'POST',
                data: {
                    applicantID: $('#applicantID' + componentName).val(),
                    status: false,
                },
                beforeSend: function () { },
                success: function (data) {
                    if (data.Status) {
                        $('#Circumstance' + componentName).val(data.Data.CaseApplicantOpinionRow.Circumstance).trigger('input');                      
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
                    Circumstance: $('#Circumstance' + componentName).val(),
                }
                $.ajax({
                    url: '/jfscaseexpense/savecaseapplicantdeportation',
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
                        console.log(err);
                    }
                });

                frm.find('.js--btsave' + componentName).hide();
                frm.find('.js--cancel').hide();
                frm.find('.header-icon').remove();

            }

        });



});
