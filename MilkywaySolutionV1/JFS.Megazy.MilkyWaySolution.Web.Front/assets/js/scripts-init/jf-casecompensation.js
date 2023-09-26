// Begin การไกล่เกลี่ย
$(function () {

    var componentName = 'casecompensation';



    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        var frm = $('#frm' + componentName);
        if ((!$(':radio[name=rdoCompnsation]').is(':checked')) && $('#applicantID' + componentName).val() != 0) {
            //Load data
            if ($('#isloadData-' + componentName).val() == 0) {
                //Load data
                $('#isloadData-' + componentName).val(1);

                $.ajax({
                    url: '/jfservices/getcasecompensation',
                    method: 'POST',
                    data: { applicantID: $('#applicantID' + componentName).val() },
                    beforeSend: function () { },
                    success: function (data) {
                        console.log(data);


                        if (data.Data != null) {

                            $('input[name=rdoCompnsation]').filter('#rdoCompnsation' + data.Data.CompensationID).iCheck('check');

                            var isOther = $('#rdoCompnsation' + data.Data.CompensationID).data('isother');

                            if (isOther == 1) {
                                $('#compensationOther' + componentName).val(data.Data.CompensationOtherNote).attr('disabled', false);
                            } else {
                                $('#compensationOther' + componentName).val('').attr('disabled', true);
                            }

                        }
                        //$('input[name=radioName]:checked')
                        frm.find('.js--btsave' + componentName).hide();
                        frm.find('.js--cancel').hide();
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });

            }


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
        })
        .off('ifChecked', ':radio[name=rdoCompnsation]')
        .on('ifChecked', ':radio[name=rdoCompnsation]', function (e) {

            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
            var isother = $(this).data('isother');
            
            if (isother == 1) {
                $('#compensationOther' + componentName).attr('disabled', false).addClass('validate[required]');
            }
            else {
                $('#compensationOther' + componentName).attr('disabled', true).val('').removeClass('validate[required]');
            }
        })
       
        .off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {
           
            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {

                var compensation = $('input[name="rdoCompnsation"]:checked');

                var compensationOther = '';
                var isOther = compensation.data('isother');

                if (isOther) {
                    compensationOther = $('#compensationOther' + componentName).val();
                }

                var compensationData = {
                    CaseID: $('#caseID' + componentName).val(),
                    CompensationID: parseInt(compensation.val()),
                    CompensationOtherNote: compensationOther
                };
                $.ajax({
                    url: '/jfservices/savecasecompensation',
                    method: 'POST',
                    data: {
                        compensationData: compensationData,
                        applicantID: $('#applicantID' + componentName).val(),
                        

                    },
                    beforeSend: function () {
                    },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {

                            SWSuccess.fire();
                        } else {

                            SWError.fire();
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
