$(function () {

    var componentName = 'applicantbail';

    //Get Data
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#applicantID' + componentName).val() != 0) {
            if ($('#box-bail-' + componentName + ' div.form-group').length == 0) { }
                //Load data
                $.ajax({
                    url: '/applicantbail/getapplicantbail',
                    method: 'POST',
                    data: { applicantID: $('#applicantID' + componentName).val() },
                    beforeSend: function () { },
                    success: function (data) {
                        var frm = $('#frm' + componentName);
                        if (data.Status) {
                            $.each(data.Data, function (i, item) {

                                $(':radio[name=rdostatusapplicantbail' + data.Data[i].BailOutLevelID +'][value=' + data.Data[i].BailStatusID + ']').iCheck('check');
                                if (data.Data[i].BailStatusID == 2) {
                                    $('#des' + componentName + data.Data[i].BailOutLevelID).removeClass('d-none');
                                    $('#cdes' + componentName + data.Data[i].BailOutLevelID).val(data.Data[i].Description);
                                }
                                $(':radio[name=rdocourtapplicantbail][value=' + data.Data[i].BailID + ']').iCheck('check');

                            });
                        } 
                        frm.find('.js--btsave').hide();
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
        .off('keyup', '.js-text')
        .on('keyup', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave').show();
            frm.find('.js--cancel').show();
        })
        .off('ifChecked', 'input[name^=rdostatus]:radio')
        .on('ifChecked', 'input[name^=rdostatus]:radio', function (e) {
            var frm = $(this).closest('.wrap-bail');
            var value = $(this).val();
            if (value == 1) {
                frm.find('#des' + componentName + $(this).data('level')).addClass('d-none');
            }
            else {
                frm.find('#des' + componentName + $(this).data('level')).removeClass('d-none');
                frm.find('#des' + componentName + $(this).data('level')).focus();
            }
            $(this).closest('form').find('.js--btsave').show();
            $(this).closest('form').find('.js--cancel').show();
        })
        .off('click', '.js--btsave')
        .on('click', '.js--btsave', function (e) {
            var frm = $(this).closest('form');
            var applicantBailRow = [];
            if (frm.validationEngine('validate')) {
                $('#box-bail-' + componentName).find('.wrap-bail').each(function () {
                    var level = $(this).data('level');
                    var rdoStatus = $(this).find('input[name^=rdostatus]:radio');
                    if (rdoStatus.is(':checked')) {
                        var rowData = {};
                        rowData.BailID = $(this).find('input[id^=bailID]').val();
                        rowData.ApplicantID = $("#applicantID" + componentName).val()
                        rowData.BailStatusID = $(this).find('input[name^=rdostatus]:radio:checked').val();
                        if ($('#des' + componentName + level).is(':visible')) {
                            rowData.Description = $('#cdes' + componentName + level).val();
                        }
                        var rdoCourt = $(this).find('input[name^=rdocourtapplicantbail]:radio');
                        if (rdoCourt.length) {
                            if ($(':radio[name=rdocourtapplicantbail]:checked')) {
                                rowData.BailID = $(':radio[name=rdocourtapplicantbail]:checked').val();
                            }
                        }
                        applicantBailRow.push(rowData);
                    }
                })
                //  console.log(applicantBailRow);
                $.ajax({
                    url: '/applicantbail/editapplicantbail',
                    method: 'POST',
                    data: { data: applicantBailRow },
                    beforeSend: function () { },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            $('#applicantID' + componentName).val(data.DataID);
                            SWSuccess.fire();
                            frm.find('.js--btsave').hide();
                            frm.find('.js--cancel').hide();
                            frm.find('.header-icon').remove();
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });
            }

        })
        .off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave').hide();
            $(this).hide();
        });
});

