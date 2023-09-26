// Begin การไกล่เกลี่ย
$(function () {

    var componentName = 'casecounsel';



    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        //console.log($('#applicantID' + componentName).val());
        var frm = $('#frm' + componentName);
        if ($('#applicantID' + componentName).val() != 0 && $('#ConselSummary' + componentName).val() == '') {
            //Load data
            //console.log($('#applicantID' + componentName).val());
            $.ajax({
                url: '/jfscaseexpense/getcasecounsel',
                method: 'POST',
                data: { applicantID: $('#applicantID' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    //console.log(data);
                    //$('#applicantID' + componentName).val(data.Data.ApplicantID);
                    $('#ConselSummary' + componentName).val(data.Data.ConselSummary);
                    $('#CunselTime' + componentName).val(data.Data.CunselTime);
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

                var caseCounselRow = {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    CunselTime: $('#CunselTime' + componentName).val(),
                    ConselSummary: $('#ConselSummary' + componentName).val(),
                }
                console.log(caseCounselRow);



                $.ajax({
                    url: '/jfscaseexpense/savecasecounsel',
                    method: 'POST',
                    data: {
                        caseCounselRow: caseCounselRow
                    },
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



});
