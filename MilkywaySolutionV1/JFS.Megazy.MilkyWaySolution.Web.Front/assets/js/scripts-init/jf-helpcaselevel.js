
$(function () {
    var componentName = 'helpcaselevel';
    $('#frminterviewfactconflict').hide();
    $('#card-' + componentName).on('expanded.lte.widget', function (event) {
        Common.swcithTabIcon(this);
        var frm = $(this).closest('form');
        // console.log(Common.formatNumber(9090.90));
        if (!$(':radio[name=rdohelpcaselevel]').is(':checked') && $('#caseID' + componentName).val() != 0) {
            $.ajax({
                url: '/jfservices/caseapplicant/getcaselevelcasetype',
                method: 'POST',
                data: { caseID: $('#caseID' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    if (data.Status) {
                        $(':radio[name=rdohelpcaselevel' + componentName +'][value=' + data.Data.HelpCaseLevelID + ']').iCheck('check');
                        $(':radio[name=rdocasetype][value=' + data.Data.CaseTypeID + ']').iCheck('check');
                        if ($(':radio[name=rdocasetype]:checked').val() == 1) {

                            $('#frminterviewfactconflict').show();
                            $('#frminterviewfactconflict').find('#show-interviewfactconflict').click();
                        }
                        // if (data.Data.ApplicantMaritalData.MaritalStatusID > 1) {
                        $('#OtherHelpCaseLevel' + componentName).val(data.Data.HelpCaseLevelOther);
                        $('#OtherCaseType' + componentName).val(data.Data.CaseTypeOther);
                        // }
                        frm.find('.js--btsave' + componentName).hide();
                        frm.find('.js--cancel').hide();
                    }
                }
                , error: function (err) {
                    console.log(err);
                }
            });


        }// end of check html length
    });
    //Card 
    //Common.CollapsedCard(this);
    $('#card-' + componentName).on('collapsed.lte.widget', function (event) { Common.swcithTabIcon(this); });


    $('#frm' + componentName)
        .off('keyup', '.js--text')
        .on('keyup', '.js--text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        }).off('ifChecked', ':radio[name=rdohelpcaselevel' + componentName +']')
        .on('ifChecked', ':radio[name=rdohelpcaselevel'+componentName+']', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();

            if ($(this).data('isother') == 'True') {
                $('.js--otherhelpcaselevel').show();
            } else {
                
                $('.js--otherhelpcaselevel').hide();
                $('#OtherHelpCaseLevel'+componentName).val("");
            }
        })
        .off('ifChecked', ':radio[name=rdocasetype]')
        .on('ifChecked', ':radio[name=rdocasetype]', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();



            if ($(this).data('isother') == 'True') {
                $('.js--othercasetype').show();
            } else {
                $('.js--othercasetype').hide();
                $('#OtherCaseType' + componentName).val("");
            }
            if ($(':radio[name=rdocasetype]:checked').val() == 1) {
                //console.log("Show");
                $('#frminterviewfactconflict').show();
                $('#frminterviewfactconflict').collapse('show');
                //$('#frminterviewfactconflict').find('#show-interviewfactconflict').click();

            }
            else {
                //console.log("Hide");
                $('#frminterviewfactconflict').hide();
                //$('#frminterviewfactconflict').collapse('hide');
                //$('#frminterviewfactconflict').find('#show-interviewfactconflict').click();
            }

        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {

            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {
                var data = {
                    CaseID: $('#caseID' + componentName).val(),
                }
                if ($(':radio[name=rdohelpcaselevel' + componentName +']').is(':checked')) {
                    data.HelpCaseLevelID = $(':radio[name=rdohelpcaselevel'+componentName+']:checked').val();
                    data.HelpCaseLevelOther = $('#OtherHelpCaseLevel' + componentName).is(":visible") ? $('#OtherHelpCaseLevel' + componentName).val() : null;
                }
                if ($(':radio[name=rdocasetype]').is(':checked')) {
                    data.CaseTypeID = $(':radio[name=rdocasetype]:checked').val();
                    data.CaseTypeOther = $('#OtherCaseType' + componentName).is(":visible") ? $('#OtherCaseType' + componentName).val() : null;
                }

                $.ajax({
                    url: '/jfservices/caseapplicant/editcaselevelcasetype',
                    method: 'POST',
                    data: { req: data, applicantID: $('#applicantIDhelpcaselevel').val() },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            //$('#caseID' + componentName).val(data.ID);
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
