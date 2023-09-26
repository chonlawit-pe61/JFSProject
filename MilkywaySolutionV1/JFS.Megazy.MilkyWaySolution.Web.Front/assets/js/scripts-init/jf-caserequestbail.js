// คำร้องขอปล่อยชั่วคราว
$(function () {

    var componentName = 'caserequestbail';

    $('#card-' + componentName).on('expanded.lte.widget', function (event) {
        Common.swcithTabIcon(this);
        var frm = $(this).closest('form');
        $body = $(this).find('.card-body div').first();
        console.log($('#caseID' + componentName).val());
        console.log($(':radio[name=request' + componentName + ']:checked').val());

        if (!$(':radio[name=request' + componentName + ']').is(':checked') && $('#caseID' + componentName).val() != 0) {
            //Load data
            $.ajax({
                url: '/jfscaserequestbail/getcaserequestbail',
                method: 'POST',
                data: {
                    caseID: $('#caseID' + componentName).val(),
                    applicantID: $('#applicantID' + componentName).val()
                },

                beforeSend: function () { },
                success: function (data) {
                    console.log(data);
                    if (data.Status) {
                        if (data.Data.RequestStatus == true) {
                            $('#amount' + componentName).val(data.Data.NumberOfRequest);
                            $('#courtdecree' + componentName).val(data.Data.CourtDecree);
                            $('#requestradio' + componentName).iCheck('check');
                        }
                        else {
                            $('#cause' + componentName).val(data.Data.Cause);
                            $('#onrequestradio' + componentName).iCheck('check');

                        }
                        
                        
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
        .off('keyup input ifChange', '.js-text')
        .on('keyup input ifChange', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })        
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (event) {
            var frm = $(this).closest('form');

            if ($('#frm' + componentName).validationEngine('validate')) {

                if ($(':radio[name=request' + componentName + ']:checked').val() == 1) {

                    var caseRequestBail = {
                        CaseID: $('#caseID' + componentName).val(),
                        ApplicantID: $('#applicantID' + componentName).val(),
                        NumberOfRequest: $('#amount' + componentName).val(),
                        CourtDecree: $('#courtdecree' + componentName).val(),
                        RequestStatus: true,

                    }



                } else {
                    var caseRequestBail = {
                        CaseID: $('#caseID' + componentName).val(),
                        ApplicantID: $('#applicantID' + componentName).val(),
                        Cause: $('#cause' + componentName).val(),
                        RequestStatus: false,

                    }

                }





                $.ajax({
                    type: 'POST',
                    url: '/jfscaserequestbail/savecaserequestbail',
                    data: { caseRequestBailRow: caseRequestBail },

                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            SWSuccess.fire();
                            //{
                            //    onClose: () => {
                            //        window.location.reload();
                            //    }
                            //}
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
        })
        .off('ifChecked', ':radio[name=request' + componentName + ']')
        .on('ifChecked', ':radio[name=request' + componentName + ']', function (e) {

            var frm = $(this).closest('form');
            supcareer = $(this).val();
            console.log($(this).val());
            if ($(this).val() == 1) {
                $('#divrequest').show();
                $('#divonrequest').hide();
                $('#cause' + componentName).val('');

            }
            else {
                $('#divonrequest').show();
                $('#divrequest').hide();
                $('#amount' + componentName).val(0);
                $('#courtdecree' + componentName).val('');
            }
            frm.find('.js--cancel').show();
            frm.find('.js--btsave' + componentName).show();

        });

});
