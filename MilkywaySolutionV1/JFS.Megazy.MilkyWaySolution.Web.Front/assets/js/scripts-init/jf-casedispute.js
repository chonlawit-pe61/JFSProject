$(function () {

    var componentName = 'casedispute';

    //Get Data
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#applicantID' + componentName).val() != 0) {
            //if ($('#box-case-' + componentName + ' div.form-group').length == 0) {
            //Load data
            $.ajax({
                url: '/casedispute/getcasedispute',
                method: 'POST',
                data: { caseID: $('#caseID' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    //console.log(data);
                    if (data.Status) {
                        var frm = $('#frm' + componentName);
                        $('#caseID' + componentName).val(data.Data.CaseID);
                        $('#court' + data.Data.CourtLevelID).iCheck('check');
                        if (data.Data.NotCommunicated) {
                            $('#court0').iCheck('check');

                        }
                        $('#VerdictOrCause').val(data.Data.VerdictOrCause);

                        if (data.Data.HasMediate) {
                            $('#hasmediate-yes-' + componentName).iCheck('check');
                            $('#mediatedby' + componentName).val(data.Data.MediatedBy)
                            $('#description' + componentName).val(data.Data.Description)

                        } else {
                            $('#hasmediate-no-' + componentName).iCheck('check');
                            //$('#box-mediatedby' + componentName).addClass('d-none');
                            //$('#box-description' + componentName).addClass('d-none');

                            if (data.Data.WantMediate) {
                                $('#wantmediate-yes-' + componentName).iCheck('check');
                                //$('#box-description-1-' + componentName).addClass('d-none');

                            } else {
                                $('#wantmediate-no-' + componentName).iCheck('check');
                                $('#description-1-' + componentName).val(data.Data.Description);
                            }

                        }
                        frm.find('.js--btsave').hide();
                        frm.find('.js--cancel').hide();
                    }

                }
                , error: function (err) {
                    console.log(err);
                }
            });

            //}

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
        .off('ifChecked', 'input[name=hasmediate' + componentName + ']:radio')
        .on('ifChecked', 'input[name=hasmediate' + componentName + ']:radio', function (e) {
            var frm = $(this).closest('form');
            var value = $(this).val();
            if (value == 1) {
                frm.find('#box-mediatedby-' + componentName).removeClass('d-none');
                frm.find('#box-wantmediate-' + componentName).addClass('d-none');
                frm.find('#box-description-' + componentName).removeClass('d-none');
                frm.find('#box-description-1-' + componentName).addClass('d-none');
                frm.find('#description-1-' + componentName).val('');
                frm.find('input[name=wantmediate' + componentName).iCheck('uncheck');
            }
            else {
                frm.find('#box-wantmediate-' + componentName).removeClass('d-none');
                frm.find('#box-mediatedby-' + componentName).addClass('d-none');
                frm.find('#box-description-' + componentName).addClass('d-none');
                frm.find('#description' + componentName).val('');
                frm.find('#mediatedby' + componentName).val('');
            }
            frm.find('.js--btsave').show();
            frm.find('.js--cancel').show();
        })
        .off('ifChecked', 'input[name=wantmediate' + componentName + ']:radio')
        .on('ifChecked', 'input[name=wantmediate' + componentName + ']:radio', function (e) {
            var frm = $(this).closest('form');
            var value = $(this).val();
            if (value == 1) {
                frm.find('#box-description-1-' + componentName).addClass('d-none');

            }
            else {

                frm.find('#box-description-1-' + componentName).removeClass('d-none');
            }
            frm.find('.js--btsave').show();
            frm.find('.js--cancel').show();
        }).off('ifChecked', 'input[name=courtlevel]:radio')
        .on('ifChecked', 'input[name=courtlevel]:radio', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave').show();
            frm.find('.js--cancel').show();
        })
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave').hide();
            $(this).hide();
        })
        .off('click', '.js--btsave')
        .on('click', '.js--btsave', function (e) {
            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {
                var casedisputeData = {
                    CaseID: $('#caseID' + componentName).val(),
                    CourtLevelID: $(":radio[name=courtlevel]").iCheck('check') ? $(':radio[name=courtlevel]:checked').val() : 0,
                    NotCommunicated: $(":radio[name=courtlevel]").iCheck('check') ? ($(':radio[name=courtlevel]:checked').val() == 0 ? true : false) : false,
                    VerdictOrCause: $("#VerdictOrCause").val(),
                    HasMediate: $('#hasmediate-yes-' + componentName).iCheck('update')[0].checked,
                    WantMediate: $('#wantmediate-yes-' + componentName).iCheck('update')[0].checked,
                    MediatedBy: $('#mediatedby' + componentName).val(),
                    Description: ($('#hasmediate-yes-' + componentName).iCheck('update')[0].checked ? $('#description' + componentName).val() : $('#description-1-' + componentName).val()),
                }
                $.ajax({
                    url: '/casedispute/editcasedispute',
                    method: 'POST',
                    data: {
                        data: casedisputeData,
                        caseID: $('#caseID' + componentName).val(),
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            SWSuccess.fire();
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });
                frm.find('.header-icon').remove();
                frm.find('.js--btsave').hide();
                frm.find('.js--cancel').hide();
            }
        })
});