// คำร้องขอปล่อยชั่วคราว
$(function () {

    var componentName = 'caseescapesupport';

    $('#card-' + componentName).on('expanded.lte.widget', function (event) {
        Common.swcithTabIcon(this);
        var frm = $(this).closest('form');
        $body = $(this).find('.card-body div').first();
        //console.log($('#caseID' + componentName).val());        
        
        if ($('#name' + componentName).val() == "" && $('#caseID' + componentName).val() != 0) {
            //Load data
            $.ajax({
                url: '/jfscaseescapesupport/getgurantreecase',
                method: 'POST',
                data: {
                    caseID: $('#caseID' + componentName).val(),
                    applicantID: $('#applicantID' + componentName).val()
                },

                beforeSend: function () { },
                success: function (data) {
                    console.log(data);
                    if (data.Status) {
                        var caseesc = data.Data.CaseEscapeSupportRow;
                        $('#escapesupportID' + componentName).val(caseesc.GuaranteeID);
                        $('#name' + componentName).val(caseesc.Name);
                        $('#position' + componentName).val(caseesc.Position);
                        $('#relation' + componentName).val(caseesc.Relation);
                        $('#title' + componentName).val(caseesc.Title).trigger("change");;
                        $('#subjection' + componentName).val(caseesc.Subjection);
                        var offhis = data.Data.OffenseHistoryRow;
                        if (offhis.HistoryStatus == true) {
                            $('#historystatusradio' + componentName).iCheck('check');
                            $('#conductdetail' + componentName).val(offhis.ConductDetail);
                            $('#offensedetail' + componentName).val(offhis.OffenseDetail);
                        }
                        else {
                            $('#nohistorystatusradio' + componentName).iCheck('check');
                            $('#conductdetail' + componentName).val(offhis.ConductDetail);
                        }
                        var esc = data.Data.EscapeRow;
                        if (esc.EscapeStatus == true) {
                            $('#escapestatusradio' + componentName).iCheck('check');
                            $('#detail' + componentName).val(esc.Detail);
                        }
                        else {
                            $('#noescapestatusradio' + componentName).iCheck('check');
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
    $('#card-' + componentName).on('collapsed.lte.widget', function (event) { Common.swcithTabIcon(this); });


    $('#frm' + componentName)
        .off('keyup ifChange', '.js-text')
        .on('keyup ifChange', '.js-text', function (e) {
            var frm = $(this).closest('form');
            //console.log('Test escapestatus');
            //console.log($('input[name = escapestatus' + componentName + ']:checked').val());
            //console.log('Test historystatus');
            //console.log($('input[name = historystatus' + componentName + ']:checked').val());
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (event) {
            var frm = $(this).closest('form');

            if ($('#frm' + componentName).validationEngine('validate')) {

                var caseEscapeSupportRow;
                var escapeRow;
                var offenseHistoryRow;
                var caseEscapeDataRespon;

                CaseGuaranteeRow = {
                    CaseID: $('#caseID' + componentName).val(),
                    ApplicantID: $('#applicantID' + componentName).val(),
                    GuaranteeID: $('#escapesupportID' + componentName).val(),
                    Title: $('#title' + componentName).val(),
                    Subjection: $('#subjection' + componentName).val(),
                    Name: $('#name' + componentName).val(),
                    Position: $('#position' + componentName).val(),
                    Relation: $('#relation' + componentName).val(),
                }
                if ($('input[name = historystatus' + componentName + ']:checked').val() == 1) {
                    offenseHistoryRow = {
                        HistoryStatus: true,
                        OffenseDetail: $('#offensedetail' + componentName).val(),
                        ConductDetail: $('#conductdetail' + componentName).val(),
                    }
                }
                else {
                    offenseHistoryRow = {
                        HistoryStatus: false,
                        ConductDetail: $('#conductdetail' + componentName).val(),
                    }
                }
                if ($('input[name = escapestatus' + componentName + ']:checked').val() == 1) {
                    escapeRow = {
                        EscapeStatus: true,
                        Detail: $('#detail' + componentName).val(),
                    }
                    console.log('testif')
                    console.log($('input[name = escapestatus' + componentName + ']:checked').val());
                }
                else {
                    console.log('testelse')
                    console.log($('input[name = escapestatus' + componentName + ']:checked').val());
                    escapeRow = {
                        EscapeStatus: false,                        
                    }
                    
                }
                //console.log('-------------caseEscapeSupportRow-------------');
                //console.log(caseEscapeSupportRow);
                //console.log('-------------offenseHistoryRow-------------');
                //console.log(offenseHistoryRow);
                //console.log('-------------escapeRow-------------');
                //console.log(escapeRow);



                caseEscapeDataRespon = {
                    CaseEscapeSupportRow: CaseGuaranteeRow,
                    EscapeRow: escapeRow,
                    OffenseHistoryRow: offenseHistoryRow,
                }
                console.log("caseEscapeDataRespon", caseEscapeDataRespon);


                
                $.ajax({
                    type: 'POST',
                    url: '/jfscaseescapesupport/savecaseescapesupport',
                    data: { caseEscapeDataRespon: caseEscapeDataRespon },

                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            SWSuccess.fire({
                                //onClose: () => {
                                //    window.location.reload();
                                //}
                            });
                        }
                        else {
                            SWError.fire({

                            });
                        }
                    },
                    error: function (err) {
                        console.log(err);
                        SWError.fire({

                        });
                    }
                });

                        frm.find('.js--btsave' + componentName).hide();
                frm.find('.js--cancel').hide();
                frm.find('.header-icon').remove();
                   
            }
        }).off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        .off('ifChecked', ':radio[name=historystatus' + componentName + ']')
        .on('ifChecked', ':radio[name=historystatus' + componentName + ']', function (e) {

            var frm = $(this).closest('form');
            supcareer = $(this).val();
            console.log($(this).val());
            if ($(this).val() == 1) {
                $('.divoffense').show();            
            }
            else {
                $('.divoffense').hide();
            }
            frm.find('.js--cancel').show();
            frm.find('.js--btsave' + componentName).show();

        })
        .off('ifChecked', ':radio[name=escapestatus' + componentName + ']')
        .on('ifChecked', ':radio[name=escapestatus' + componentName + ']', function (e) {

            var frm = $(this).closest('form');
            supcareer = $(this).val();
            console.log($(this).val());
            if ($(this).val() == 1) {
                $('.divescape').show();
               
            }
            else {                
                $('.divescape').hide();
            }
            frm.find('.js--cancel').show();
            frm.find('.js--btsave' + componentName).show();

        });

});
