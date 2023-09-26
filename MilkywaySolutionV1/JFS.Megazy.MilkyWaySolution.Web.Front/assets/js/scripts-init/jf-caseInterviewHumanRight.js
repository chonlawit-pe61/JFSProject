$(function () {

    var componentName = 'caseinterviewhumanright';

    $('#card-' + componentName).on('expanded.lte.widget', function (event) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#description' + componentName).val() == "" && $('#applicantID' + componentName).val() != 0) {
            //Load data
            $.ajax({
                url: '/jfservices/getcaseinterviewhumanright',
                method: 'POST',
                data: {
                    caseID: $('#caseID' + componentName).val(),
                    applicantID: $('#applicantID' + componentName).val(),
                },
                beforeSend: function () { },
                success: function (data) {
                    console.log(data);
                    if (data.Status) {
                        $('#description' + componentName).val(data.Data.Description)
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
               
                $.ajax({
                    url: '/jfservices/savecaseinterviewhumanright',
                    method: 'POST',
                    data: {
                        caseID: $('#caseID' + componentName).val(),
                        applicantID: $('#applicantID' + componentName).val(),
                        description: $('#description' + componentName).val()
                    },
                    beforeSend: function () { },
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
