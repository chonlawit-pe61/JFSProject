// Begin การไกล่เกลี่ย
$(function () {

    var componentName = 'casecomplicate';

    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        var frm = $('#frm' + componentName);
        if ((!$(':checkbox[name=chkComplicate]').is(':checked')) && $('#applicantID' + componentName).val() != 0) {
            //Load data
            if ($('#isloadData-' + componentName).val() == 0) {
                //Load data
                $('#isloadData-' + componentName).val(1);
                $.ajax({
                    url: '/jfservices/getcasecomplicate',
                    method: 'POST',
                    data: { applicantID: $('#applicantID' + componentName).val() },
                    beforeSend: function () { },
                    success: function (data) {

                        if (data.Data != null) {

                            $.each(data.Data, function (key, value) {
                                $('input[name=chkComplicate]').filter('#chkComplicate' + value.ComplicateID).iCheck('check');
                                var isOther = $('#chkComplicate' + value.ComplicateID).data('isother');
                                if (isOther == 1) {
                                    $('#complicateOther' + componentName).val(value.ComplicateOtherNote).attr('disabled', false);
                                } else {
                                    $('#complicateOther' + componentName).val('').attr('disabled', true);
                                }

                            });
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
        .off('ifChecked', ':checkbox[name=chkComplicate]')
        .on('ifChecked', ':checkbox[name=chkComplicate]', function (e) {

            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
            var isother = $(this).data('isother');
            
            if (isother == 1) {
                $('#complicateOther' + componentName).attr('disabled', false).addClass('validate[required]');
            }
            else {
                $('#complicateOther' + componentName).attr('disabled', true).val('').removeClass('validate[required]');
            }
        })
        .off('ifUnchecked', ':checkbox[name=chkComplicate]')
        .on('ifUnchecked', ':checkbox[name=chkComplicate]', function (e) {

            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
            var isother = $(this).data('isother');

            if (isother == 1) {
              
                $('#complicateOther' + componentName).attr('disabled', true).val('').removeClass('validate[required]');
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

                var complicateData = [];
                var complicate = $('input[name="chkComplicate"]:checked');
                complicate.each(function () {
                    var isOther = $(this).data('isother');
                    complicateData.push({
                        ComplicateID: parseInt(this.value),
                        ComplicateOtherNote: isOther == 1 ? $('#complicateOther' + componentName).val() : ""
                    })
                });

                console.log(complicateData);

                $.ajax({
                    url: '/jfservices/savecasecomplicate',
                    method: 'POST',
                    data: {
                        complicateData: complicateData,
                        applicantID: $('#applicantID' + componentName).val(),
                        caseID: $('#caseID' + componentName).val(),
                    },
                    beforeSend: function () {
                    },
                    success: function (data) {
                      
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
