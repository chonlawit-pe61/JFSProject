$(function () {

    var componentName = 'applicanteducationlevel';

    //Get Data
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#applicantID' + componentName).val() != 0) {
            //Load data
            $.ajax({
                url: '/applicanteducationlevel/geteducationlevel',
                method: 'POST',
                data: { applicantID: $('#applicantID' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    
                    if (data.Status) {
                        console.log(data.Status);
                        console.log(data.Data)
                        var frm = $('#frm' + componentName);
                        frm.find('#edu' + componentName).val(data.Data.EducationLevelID);
                        
                        if (data.Data.EducationLevelID == 99) {
                            
                            $("#" + componentName + '-' + data.Data.EducationLevelID).iCheck('check');
                            frm.find('#box-education-' + componentName).removeClass('d-none');
                            frm.find('#education' + componentName).focus();
                            frm.find('#education' + componentName).val(data.Message);
                        }
                        else if (data.Data.EducationLevelID != 99){
                            $("#" + componentName + '-' + data.Data.EducationLevelID).iCheck('check');
                            frm.find('#box-education-' + componentName).addClass('d-none');
                        }
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
        .off('keyup change', '.js-text')
        .on('keyup change' , '.js-text', function (e) {            
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('ifToggled', '.js-radio')
        .on('ifToggled', '.js-radio', function (e) {            
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        }).off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        }).off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {

            var frm = $('#frm' + componentName);

            if (frm.validationEngine('validate')) {
                var applicanteducationData = {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    EducationLevelID: $('#edu' + componentName).val(),
                    Education: $('#education' + componentName).val(),
                    
                }
                //console.log(applicanteducationData);
                      $.ajax({
                            url: '/applicanteducationlevel/editapplicanteducationlevel',
                            method: 'POST',
                            data: { req: applicanteducationData },
                            beforeSend: function () { },
                            success: function (data) {
                                console.log(data);
                                if (data.Status) {
                                    $('#applicantID' + componentName).val(data.DataID);
                                    SWSuccess.fire();
                                }
                            }
                            , error: function (err) {
                                console.log(err);
                            }
                        });

                        frm.find('.js--btsave' + componentName).hide();
                        frm.find('.js--cancel').hide();
          
            }

        }).off('ifChecked', 'input[name=educationLevel' + componentName + ']:radio')
        .on('ifChecked', 'input[name=educationLevel' + componentName + ']:radio', function (e) {

            var frm = $(this).closest('form');
            var reason = $(this).val();
            //console.log(reason);

            if (reason == 99) {
                frm.find('#box-education-' + componentName).removeClass('d-none');
                frm.find('#education' + componentName).focus();
                frm.find('#edu' + componentName).val(reason);
            }
            else {
                frm.find('#box-education-' + componentName).addClass('d-none');
                frm.find('#edu' + componentName).val(reason);
                
            }           


        });
});