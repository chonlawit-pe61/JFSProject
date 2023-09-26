$(function () {

    var componentName = 'caseinterviewbail';

    //Get Data
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#description' + componentName).val() == "" && $('#caseID' + componentName).val() != 0) {
            //Load data
            $.ajax({
                url: '/jfservices/caseapplicant/getcasetinterviewbail',
                method: 'POST',
                data: { caseID: $('#caseID' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    console.log(data);
                    if (data.Status) {
                        var frm = $('#frm' + componentName);
                        $('#description' + componentName).val(data.Data.Description)

                        if (data.Data.HasConfess) {
                            $("#hasconfess" + componentName).prop('checked', true);
                            $('#cause' + componentName).val(data.Data.Cause);
                            frm.find('#box-cause-' + componentName).removeClass('d-none');
                            $('#hcfvale' + componentName).val(data.Data.HasConfess);

                        } else {
                            $("#nothasconfess" + componentName).prop('checked', true);
                            $('#cause' + componentName).val(data.Data.Cause);
                            frm.find('#box-cause-' + componentName).removeClass('d-none');
                            $('#hcfvale' + componentName).val(data.Data.HasConfess);
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
        .off('keyup', '.js-text')
        .on('keyup', '.js-text', function (e) {
            console.log("Test");
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        // Save Data
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {

            var frm = $('#frm' + componentName);

            if (frm.validationEngine('validate')) {
                var caseinterviewData = {
                    CaseID: $('#caseID' + componentName).val(),
                    Description: $('#description' + componentName).val(),
                    HasConfess: $('#hcfvale' + componentName).val(),
                    Cause: $('#cause' + componentName).val()
                }

                $.ajax({
                    url: '/jfservices/caseapplicant/editcasetinterviewbail',
                    method: 'POST',
                    data: { req: caseinterviewData },
                    beforeSend: function () { },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            $('#caseID' + componentName).val(data.DataID);
                            SWSuccess.fire();
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

        })

        .off('change', 'input[name=hasconfess' + componentName + ']:radio')
        .on('change', 'input[name=hasconfess' + componentName + ']:radio', function (e) {

            var frm = $(this).closest('form');
            var reason = $(this).val();
            //console.log(reason);

            if (reason == 1) {
                frm.find('#box-cause-' + componentName).removeClass('d-none');
                frm.find('#cause' + componentName).focus();
                $('#hcfvale' + componentName).val(1);

            }
            else if (reason == 2) {
                frm.find('#box-cause-' + componentName).removeClass('d-none');
                frm.find('#cause' + componentName).focus();
                $('#hcfvale' + componentName).val(0);
            }
            else {
                frm.find('#box-cause-' + componentName).addClass('d-none');
            }


        });





});