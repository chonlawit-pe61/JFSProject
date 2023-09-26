// ข้อเท็จจริงเพิ่มเติม
$(function () {

    var componentName = 'caseinvestigate';

    $('#card-' + componentName).on('expanded.lte.widget', function (event) {
        Common.swcithTabIcon(this);
        var frm = $(this).closest('form');
        $body = $(this).find('.card-body div').first();
        console.log($('#caseID' + componentName).val());
        if ($('#description' + componentName).val() == "" && $('#caseID' + componentName).val() != 0) {
            //Load data
            $.ajax({
                url: '/jfscaseinvestigate/getcaseinvestigate',
                method: 'POST',
                data: {
                    caseID: $('#caseID' + componentName).val(),
                    applicantID: $('#applicantID' + componentName).val()
                },

                beforeSend: function () { },
                success: function (data) {
                    console.log(data);
                    if (data.Status) {
                        $('#description' + componentName).val(data.Data.Decription);
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
        .off('keyup', '.js-text')
        .on('keyup', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (event) {
            var frm = $(this).closest('form');

            if ($('#frm' + componentName).validationEngine('validate')) {
                var caseInvestigate = {
                    CaseID: $('#caseID' + componentName).val(),
                    ApplicantID: $('#applicantID' + componentName).val(),
                    Decription: $('#description' + componentName).val()

                }

                $.ajax({
                    type: 'POST',
                    url: '/jfscaseinvestigate/savecaseinvestigate',
                    data: { caseInvestigateRow: caseInvestigate },

                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            SWSuccess.fire({
                                onClose: () => {
                                    //window.location.reload();
                                }
                            });
                        }
                        else {
                            SWError.fire({

                            });
                        }
                    },
                    error: function (err) {
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
