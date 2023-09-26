// Begin การไกล่เกลี่ย
$(function () {

    var componentName = 'drug';
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#description' + componentName).val() == "" && $('#applicantID' + componentName).val() != 0) {
            //Load data
            $.ajax({
                url: '/jfservices/caseapplicant/getdrug',
                method: 'POST',
                data: { applicantID: $('#applicantID' + componentName).val() },
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
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) { Common.swcithTabIcon(this); });


    $('#frm' + componentName)
        .off('keyup', '.js-text')
        .on('keyup', '.js-text', function (e) {
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
                var drugData = {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    Description: $('#description' + componentName).val()
                }
                //var card = $('#cardID').val();
                //var cardID = card.replace(/-/g, '');
                //console.log('cardID = ', cardID);

                //$('#cardID').val('1865453595751');
                $.ajax({
                    url: '/jfservices/caseapplicant/editdrug',
                    method: 'POST',
                    data: { req: drugData },
                    beforeSend: function () { },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            $('#applicantID' + componentName).val(data.ID);
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
