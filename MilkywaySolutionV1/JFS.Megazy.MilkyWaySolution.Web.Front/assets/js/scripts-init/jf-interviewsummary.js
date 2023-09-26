$(function () {
    var componentName = 'interviewsummary';
    $('#card-' + componentName).on('expanded.lte.widget', function (event) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#description' + componentName).val() == "" && $('#applicantID' + componentName).val() != 0) {
            //Load data
            $.ajax({
                url: '/jfservices/caseapplicant/getcasetinterviewsummary',
                method: 'POST',
                data: { applicantID: $('#applicantID' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    console.log(data);
                    if (data.Status) {
                        $('#description' + componentName).val(data.Data.Description).trigger('input')
                    }
                }
                , error: function (err) {
                    if (err.status == 401) {
                        window.location.reload();
                    }
                }
            });
        } else { console.log('default') }
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
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (event) {

            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {
                var data = {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    Description: $('#description' + componentName).val()
                }
                $.ajax({
                    url: '/jfservices/caseapplicant/editapplicantinterviewsummary',
                    method: 'POST',
                    data: { req: data },
                    beforeSend: function () { },
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
        }).off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        });
});
