// Begin ข้อมูลการคืนเงิน
$(function () {
    var componentName = 'caserefund';
    modalLoad();
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);

    });
    //Card 
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) { Common.swcithTabIcon(this); });


    $('body')
        .off('click', '#btsendsms' + componentName)
        .on('click', '#btsendsms' + componentName, function (e) {

        }).off('click', '#btsendemail' + componentName)
        .on('click', '#btsendemail' + componentName, function (e) {
            var frm = $('#frmnotify-email' + componentName);
            if (frm.validationEngine('validate')) {
                $(this).attr('disabled', 'disabled');
                $.ajax({
                    url: '/messaging/emailnotifydecisionresult',
                    method: 'POST',
                    data: {
                        emailTo: $('#emailnoti' + componentName).val(),
                        applicantID: $('#applicantID' + componentName).val(),
                        caseID: $('#caseID' + componentName).val(),
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            SWSuccess.fire({ title: 'ส่งอีเมลเรียบร้อยแล้ว' });
                        }
                        $('#btsendemail' + componentName).removeAttr('disabled');
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });

            }
        });

    $('#frm' + componentName)
        .off('change', '.js--text')
        .on('change', '.js--text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        }).off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        });

    $('#frmrequest' + componentName)
        .off('click', '#btsave' + componentName)
        .on('click', '#btsave' + componentName, function (e) {
            var frm = $('#frmrequest' + componentName);
            if (frm.validationEngine('validate')) {
                var data = {
                    TrakingRefundID: 0,
                    ContractID: $('#contractIDcasedetail').val(),
                    Note: $('#Note' + componentName).val(),
                    Description: $('#Description' + componentName).val(),
                    Amount: $('#RequestAmount' + componentName).val(),
                    ReceiveAmount: $('#ReceiveAmount' + componentName).val(),
                    ReceivedDateStr: $('#ReceivedDate' + componentName).val(),
                    RefundStatusID: 1,
                }
                //console.log(NotifyDecisionResult);
                $.ajax({
                    url: '/jfservices/savetrackingrefund',
                    method: 'POST',
                    data: { req: data },
                    beforeSend: function () {
                    },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            SWSuccess.fire();
                            getTrackingRefund($('#contractIDcasedetail').val())
                            $('#addrefund' + componentName).modal('hide')
                        }
                    }
                    , error: function (err) {
                        if (err.status == 401) {
                            window.location.reload();
                        }
                    }
                });

                frm.find('.header-icon').remove();
                frm.find('.js--btsave' + componentName).hide();
                frm.find('.js--cancel').hide();
            }
        });

    $('#addrefund' + componentName).on('shown.bs.modal', function () {
        $(".input-decimal").inputmask({ alias: "decimal", groupSeparator: ",", rightAlign: true, autoGroup: true, autoUnmask: true });
        $('#ReceivedDate' + componentName).datepicker({
            language: 'th-TH', autoclose: true
        });
        $('#ReceivedDate' + componentName).on('change', function (ev) {
            $(this).datepicker('hide');
        });
    })
    function modalLoad() {
        var temp = Handlebars.compile($('#tmpl-modalrefund').html());
        $('body').append(temp());
    }


});

//record.Amount = item.Amount;
//record.ContractID = item.ContractID;
//record.Description = item.Description;
//record.Note = item.Note;
//record.ReceivedAmount = item.ReceivedAmount;
//record.ReceivedDate = item.ReceivedDate;
//record.ReceivedDateStr = Utility.ConvertDateToThaiString(item.ReceivedDate);
//record.RefundStatusID = item.RefundStatusID;
//record.TrakingRefundID = item.TrakingRefundID;
function getTrackingRefund(contractID) {
    var componentName = 'caserefund';
    let tbody = $('#tbcaserefund tbody');
    if ($('#contractIDcasedetail').length && $('#contractIDcasedetail').val() == 0) {
    }
    $('.js--contractno').html('(เลขที่สัญญา: ' + $('#contractNocasedetail').val() + ')');
        $.ajax({
            url: '/jfservices/gettrackingrefundbycontract',
            method: 'POST',
            data: {
                contractID: contractID
            },
            beforeSend: function () { },
            success: function (data) {
                console.log(data);   
                if (data.Status) {
                    tbody.find('tr').remove();
                    if (data.Data.length != 0) {
                        for (var i = 0; i < data.Data.length; i++) {                        
                            var htmtb = '<tr><td class="text-center">' + (i + 1) + '</td><td>' + data.Data[i].Description+'</td>' +
                                '<td class="text-right">' + Common.formatNumber(data.Data[i].Amount) +'</td>' +
                                '<td>' + data.Data[i].RequestDateStr +'</td>' +
                                '<td class="text-right">' + Common.formatNumber(data.Data[i].ReceivedAmount) +'</td>' +
                                '<td>' + data.Data[i].ReceivedDateStr +'</td>' +
                                '<td>' + data.Data[i].RefundStatusName +'</td>' +
                            '<td>' + data.Data[i].Note +'</td>' +
                            '</tr>';
                            tbody.append(htmtb);
                        }
                    } else {
                        tbody.html('<tr class="text-center"><td colspan="8">ไม่พบข้อมูล</td></tr>');
                    }
                } else {
                    tbody.html('<tr class="text-center"><td colspan="8">เกิดข้อผิดพลาด ให้รีเฟรชหน้าใหม่</td></tr>');
                }
                
            }
            , error: function (err) {
                console.log(err);
            }
        });
    

}