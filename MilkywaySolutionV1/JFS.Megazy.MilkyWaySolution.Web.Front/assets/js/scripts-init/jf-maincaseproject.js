// Begin การไกล่เกลี่ย
$(function () {


    var componentName = 'maincaseproject';


    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#isloadData-' + componentName).val() == 0) {
            //Load data
            $('#isloadData-' + componentName).val(1);
            var frm = $(this).closest('form');
            console.log(frm);
            $.ajax({
                url: '/jfscaseserviceproject/getmaincaseppoject',
                method: 'POST',
                data: { caseID: $('#caseProjectID-' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    console.log(data);
                    if (data.Data != null) {
                        $('#objectiveToHelp-' + componentName).val(data.Data.ObjectiveToHelp);
                        $('#projectInAction-' + componentName).val(data.Data.ProjectInAction);
                        $('#projectObjective-' + componentName).val(data.Data.ProjectObjective);
                        $('#portfolio-' + componentName).val(data.Data.Portfolio);
                        $('#projectResult-' + componentName).val(data.Data.ProjectResult);
                        $('#projectTarget-' + componentName).val(data.Data.ProjectTarget);
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
    });

    $('#frm' + componentName)

        .off('keyup', '.js-text')
        .on('keyup', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        .off('ifChecked', ':radio[name=rdoProposerType]')
        .on('ifChecked', ':radio[name=rdoProposerType]', function (e) {
            //var frm = $(this).closest('form');
            if ($(this).val() == 7) {
                $('.divOtherProposerType').show();
            } else {
                $('.divOtherProposerType').hide().val('');
            }
            //frm.find('.js--cancel').show();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {

            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {

                //ผู้caseProjectData
                var caseProjectData = {
                    ObjectiveToHelp: $('#objectiveToHelp-' + componentName).val(), //วัตถุประสงค์ที่ขอรับความช่วยเหลือ
                    ProjectInAction: $('#projectInAction-' + componentName).val(), //กิจกรรมหรือโครงการที่ดำเนินการอยู่ในปัจจุบัน (โดยสรุป)
                    ProjectObjective: $('#projectObjective-' + componentName).val(), //วัตถุประสงค์โครงการ (โดยสรุป)
                    Portfolio: $('#portfolio-' + componentName).val(),
                    ProjectResult: $('#projectResult-' + componentName).val(),
                    ProjectTarget: $('#projectTarget-' + componentName).val(),
                }

                $.ajax({
                    url: '/jfscaseserviceproject/savemaincaseproject',
                    method: 'POST',
                    data: {
                        req: caseProjectData,
                        caseID: $('#caseProjectID-' + componentName).val()
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            $('#applicantID' + componentName).val(data.ID);
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
