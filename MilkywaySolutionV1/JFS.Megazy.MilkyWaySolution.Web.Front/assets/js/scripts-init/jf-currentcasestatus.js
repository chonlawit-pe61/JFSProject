// Begin สถานะคดี เก็บข้อมูลคดีดำ คดีแดง
$(function () {
    var componentName = 'currentcasestatus';

    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        //console.log($('#applicantID' + componentName).val());
        var frm = $('#frm' + componentName);
        if ($('#applicantID' + componentName).val() != 0 && !$(':radio[name=rdohelpcaselevel'+componentName+']').is(':checked')) {
            //Load data
            //console.log($('#applicantID' + componentName).val());
            $.ajax({
                url: '/jfscaseexpense/getcurrentcasestatus',
                method: 'POST',
                data: {
                    applicantID: $('#applicantID' + componentName).val(),
                    caseID: $('#caseID' + componentName).val()
                },
                beforeSend: function () { },
                success: function (data) {
                    if (data.Status) {
                        console.log(data.Data);
                        if (data.Data != null) {
                            $('#currentstatuscaseID' + componentName).val(data.Data.CurrentStatusCaseID);                            
                            $(':radio[name=rdohelpcaselevel'+componentName+'][value=' + data.Data.HelpCaseLevelID + ']').iCheck('check');
                            $(':radio[name=rdocasetype'+componentName+'][value=' + data.Data.CaseTypeID + ']').iCheck('check');
                            $('#OtherHelpCaseLevel' + componentName).val(data.Data.HelpCaseLevelOther);
                            $('#OtherCaseType' + componentName).val(data.Data.CaseTypeOther);
                            $('#court' + componentName).val(data.Data.CourID).trigger('change');
                            $('#rednumber' + componentName).val(data.Data.CaseRedNo);
                            $('#blacknumber' + componentName).val(data.Data.CaseBlackNo);
                            $('#Judgement' + componentName).val(data.Data.Judgement);                            
                            $(':radio[name=casestatus' + componentName + '][value=' + data.Data.ApplicantStatus + ']').iCheck('check');
                            $('#charge' + componentName).val(data.Data.Charge);
                            $('#litiganttitle' + componentName).val(data.Data.LitigantTitle).trigger('change');
                            $('#litigantname' + componentName).val(data.Data.LitigantName);
                            

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
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) { Common.swcithTabIcon(this); });


    $('#frm' + componentName)
        .off('keyup ifChanged change', '.js-text')
        .on('keyup ifChanged change', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        }).off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        .off('ifChecked', ':radio[name=rdohelpcaselevelcurrentcasestatus]')
        .on('ifChecked', ':radio[name=rdohelpcaselevelcurrentcasestatus]', function (e) {
            
            if ($(this).data('isother') == 'True') {
                $('.js--otherhelpcaselevel').show();
            } else {
                $('.js--otherhelpcaselevel').hide();
                $('#OtherHelpCaseLevel' + componentName).val('');
            }
            
        })
        .off('ifChecked', ':radio[name=rdocasetypecurrentcasestatus]')
        .on('ifChecked', ':radio[name=rdocasetypecurrentcasestatus]', function (e) {
            
            if ($(this).data('isother') == 'True') {
                $('.js--othercasetype').show();
            } else {
                $('#OtherCaseType'+componentName).val('');
                $('.js--othercasetype').hide();
            }
           

        })
        .off('ifChecked', ':radio[name=casestatuscurrentcasestatus]')
        .on('ifChecked', ':radio[name=casestatuscurrentcasestatus]', function (e) {

            if ($(this).val() == 'PL') {
                $(":radio[name='litigantstatuscurrentcasestatus'][value='DE']").iCheck('check')
               
            } else if ($(this).val() == 'DE') {

                $(":radio[name='litigantstatuscurrentcasestatus'][value='PL']").iCheck('check')
            }


        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {
            
            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {

                
                var helpcaselevelID;
                helpcaselevelID = $('input[name = rdohelpcaselevel' + componentName + ']:checked').val();
                var casetypeID;
                casetypeID = $('input[name = rdocasetype' + componentName + ']:checked').val();
                
                var currentcasestatus;
                currentcasestatus = {
                    CurrentStatusCaseID: $('#currentstatuscaseID' + componentName).val(),
                    CaseID: $('#caseID' + componentName).val(),
                    ApplicantID: $('#applicantID' + componentName).val(),
                    CourID: $('#court' + componentName).val(),
                    HelpCaseLevelID: helpcaselevelID,
                    CaseTypeID: casetypeID,
                    HelpCaseLevelOther: $('#OtherHelpCaseLevel' + componentName).val(),
                    CaseTypeOther: $('#OtherCaseType' + componentName).val(),
                    CaseRedNo: $('#rednumber' + componentName).val(),
                    CaseBlackNo: $('#blacknumber' + componentName).val(),
                    Judgement: $('#Judgement' + componentName).val(),
                    ApplicantStatus: $('input[name = casestatus' + componentName + ']:checked').val(),
                    Charge: $('#charge' + componentName).val(),
                    LitigantTitle: $('#litiganttitle' + componentName).val(),
                    LitigantName: $('#litigantname' + componentName).val(),

                }

                console.log(currentcasestatus);


                $.ajax({
                    url: '/jfscaseexpense/savecurrentcasestatus',
                    method: 'POST',
                    data: {
                        req: currentcasestatus
                    },
                    beforeSend: function () {
                    },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            SWSuccess.fire({
                                onClose: () => {
                                    $('#currentstatuscaseID' + componentName).val(data.DataID)
                                }
                            });
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });

                frm.find('.js--btsave' + componentName).hide();
                frm.find('.js--cancel').hide();
                frm.find('.header-icon').remove();
            }
            

        });



});
