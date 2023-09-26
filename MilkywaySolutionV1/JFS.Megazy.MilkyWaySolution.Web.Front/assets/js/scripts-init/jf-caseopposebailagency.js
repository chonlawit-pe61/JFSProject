// คำร้องขอปล่อยชั่วคราว
$(function () {

    var componentName = 'caseopposebailagency';

    $('#card-' + componentName).on('expanded.lte.widget', function (event) {
        Common.swcithTabIcon(this);
        var frm = $(this).closest('form');
        $body = $(this).find('.card-body div').first();
        console.log($('#caseID' + componentName).val());
        console.log($(':radio[name=bailstatus' + componentName + ']:checked').val());

        if (!$(':radio[name=bailstatus' + componentName + ']').is(':checked') && $('#caseID' + componentName).val() != 0) {
            //Load data
            $.ajax({
                url: '/jfscaseopposebailagency/getcaseopposebailagency',
                method: 'POST',
                data: {
                    caseID: $('#caseID' + componentName).val(),
                    applicantID: $('#applicantID' + componentName).val()
                },

                beforeSend: function () { },
                success: function (data) {
                    console.log(data);
                    if (data.Status) {
                        if (data.Data.BailStatus == true) {
                            $('#opposeby' + componentName).val(data.Data.OpposeBy);
                            $('#description' + componentName).val(data.Data.Description);                            
                            $('#bailstatusradio' + componentName).iCheck('check');
                        }
                        else {                            
                            $('#nobailstatusradio' + componentName).iCheck('check');
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
        .off('keyup ifChange', '.js-text')
        .on('keyup ifChange', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (event) {
            var frm = $(this).closest('form');

            if ($('#frm' + componentName).validationEngine('validate')) {

                if ($(':radio[name=bailstatus' + componentName + ']:checked').val() == 1) {

                    var caseOpposeBail = {
                        CaseID: $('#caseID' + componentName).val(),
                        ApplicantID: $('#applicantID' + componentName).val(),
                        BailStatus: true,
                        Description: $('#description' + componentName).val(),
                        OpposeBy: $('#opposeby' + componentName).val(),



                    }
                } else {
                    var caseOpposeBail = {
                        CaseID: $('#caseID' + componentName).val(),
                        ApplicantID: $('#applicantID' + componentName).val(),
                        BailStatus: false,

                    }
                }





                $.ajax({
                    type: 'POST',
                    url: '/jfscaseopposebailagency/savecaseopposebailagency',
                    data: { caseOpposeBailAgencyRow: caseOpposeBail },

                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            SWSuccess.fire();
                            //SWSuccess.fire({
                            //    onClose: () => {
                            //        window.location.reload();
                            //    }
                            //});
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
        .off('ifChecked', ':radio[name=bailstatus' + componentName + ']')
        .on('ifChecked', ':radio[name=bailstatus' + componentName + ']', function (e) {

            var frm = $(this).closest('form');
            supcareer = $(this).val();
            console.log($(this).val());
            if ($(this).val() == 1) {
                $('.divoppose').show();
                //$('.divonrequest').hide();


            }
            else {
                $('#description' + componentName).val('');
                $('#opposeby' + componentName).val('');
                $('.divoppose').hide();
            }
            frm.find('.js--cancel').show();
            frm.find('.js--btsave' + componentName).show();

        });

});
