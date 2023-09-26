// Begin การไกล่เกลี่ย
$(function () {


    var componentName = 'caseprojectsourcefund';

    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#isloadData-' + componentName).val() == 0) {
            //Load data
        $('#isloadData-' + componentName).val(1);
        var frm = $(this).closest('form');
        console.log(frm);
            $.ajax({
                url: '/jfscaseserviceproject/getcaseprojectsourcefund',
                method: 'POST',
                data: { caseID: $('#caseProjectID-' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    console.log(data);
                    
                        //$('#postCode-' + componentName).val(address.PostCode);
                    if (data.Data != null) {

                        $.each(data.Data, function (key, value) {

                            const index = (key + 1);
                            //console.log((key + 1) + ": " + value.SourceFundID);
                            //console.log((key + 1) + ": " + value.SourceFundName);
                            $('#sourceFundKey-' + index).val(value.SourceFundID);
                            $('#sourceFundName-' + index).val(value.SourceFundName);
                            $('#sourceFundAmount-' + index).val(value.Amount);
                        });
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
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        var frm = $(this).closest('form');
        frm.find('.js--btsave' + componentName).hide();
        frm.find('.js--cancel').hide();
    });

    $('#frm' + componentName)
        
        .off('keyup change ifChecked mouseup', '.js-text')
        .on('keyup change ifChecked mouseup', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
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

                //$('#sourceFundKey-' + index).val(value.SourceFundID);

                var caseProjectSourceFund = [];

                $(".sourceFund").each(function () {
                    caseProjectSourceFund.push({
                        SourceFundID: $(this).find('.js--sourceFundID').val(),
                        SourceFundName: $(this).find('.js--sourceFundName').val(),
                        Amount: $(this).find('.js--amount').val()
                    });
                });

                        $.ajax({
                            url: '/jfscaseserviceproject/savecaseprojectsourcefund',
                            method: 'POST',
                            data: {
                                req: caseProjectSourceFund,
                                caseID: $('#caseProjectID-' + componentName).val()
                            },
                            beforeSend: function () { },
                            success: function (data) {
                                console.log(data);
                                if (data.Status) {
                                    //$('#applicantID' + componentName).val(data.ID);
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
                  
            }

        });



});
