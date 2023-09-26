// Begin การไกล่เกลี่ย
$(function () {


    var componentName = 'caseprojectreferenceperson';

    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#isloadData-' + componentName).val() == 0) {
            //Load data
        $('#isloadData-' + componentName).val(1);
        var frm = $(this).closest('form');
        console.log(frm);
            $.ajax({
                url: '/jfscaseserviceproject/getcaseprojectreferenceperson',
                method: 'POST',
                data: { caseID: $('#caseProjectID-' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    console.log(data);
                    
                   
                    if (data.Data != null) {
                        $.each(data.Data, function (key, value) {
                            const index = (key + 1);
                            //console.log((key + 1) + ": " + value.SourceFundID);
                            //console.log((key + 1) + ": " + value.SourceFundName);
                            $('#personRefName' + index).val(value.RefPersonName);
                            $('#personRefTelephone' + index).val(value.RefPersonTelephonNo);
                            $('#personRefAddress' + index).val(value.RefPersonAddress);
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
        
        .off('keyup change mouseup', '.js-text')
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
          

                //$('#sourceFundKey-' + index).val(value.SourceFundID);

                var caseProjectReferencePerson = [];

            $(".personRefName").each(function () {
                var refName = $(this).find('.js--refPersonName').val();
                if (refName.trim() != "") {

                    caseProjectReferencePerson.push({
                        RefPersonName: $(this).find('.js--refPersonName').val(),
                        RefPersonAddress: $(this).find('.js--refPersonAddress').val(), 
                        RefPersonTelephonNo: $(this).find('.js--refPersonTelephonNo').val()
                    });
                        }
            });


            console.log(caseProjectReferencePerson);
                        $.ajax({
                            url: '/jfscaseserviceproject/savecaseprojectreferenceperson',
                            method: 'POST',
                            data: {
                                req: caseProjectReferencePerson,
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
                  
   
        });



});
