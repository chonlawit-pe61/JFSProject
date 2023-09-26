// Begin เหตุผลที่จะได้รับความช่วยเหลือ
$(function () {
    var componentName = 'helpreason';
    $('#card-' + componentName).on('expanded.lte.widget', function (event) {
        Common.swcithTabIcon(this);
        // console.log(Common.formatNumber(9090.90));
        $body = $(this).find('.card-body div').first();
        if ($('#description' + componentName).val() == "" && $('#applicantID' + componentName).val() != 0) {
            //Load data
            // applicantAttrID Fix 1: Ref Table ApplicantAttribute
            $.ajax({
                url: '/jfservices/caseapplicant/getapplicantadditionalinfo',
                method: 'POST',
                data: { applicantID: $('#applicantID' + componentName).val(), applicantAttrID: 1 },
                beforeSend: function () { },
                success: function (data) {
                    if (data.Status) {
                        $('#description' + componentName).val(data.Data.ApplicantAttrVal).trigger('input')
                    }
                }
                , error: function (err) {
                    console.log(err);
                }
            });

        }
    });
    //Card 
    //Common.CollapsedCard(this);
    $('#card-' + componentName).on('collapsed.lte.widget', function (event) { Common.swcithTabIcon(this); });


    $('#frm' + componentName)
        .off('keyup', '.js-text')
        .on('keyup', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        }).off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {

            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {
                var data = {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    ApplicantAttrVal: $('#description' + componentName).val(),
                    ApplicantAttrID: 1 //Fix 1: Ref Table ApplicantAttribute 
                }
                $.ajax({
                    url: '/jfservices/caseapplicant/editapplicantadditionalinfo',
                    method: 'POST',
                    data: { req: data },
                    beforeSend: function () { },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {

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

        }).off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        });

});
