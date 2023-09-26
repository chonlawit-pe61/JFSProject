$(function () {

    var componentName = 'caseconsideration';
    //$(document).ready(function () {
    //    $(".input-decimal").inputmask({ alias: "decimal", groupSeparator: ",", rightAlign: true, autoGroup: true, autoUnmask: true});
    //});
    function GetCaseApplicantOpinion(applicantID, officerRoleID) {
        var res;
        $.ajax({
            url: '/jfservices/getcaseapplicantopinion',
            method: 'POST',
            data: {
                applicantID: applicantID,
                officerRoleID: officerRoleID,
                IsAppeal: ($('#isappeal' + componentName).val() == 1 ? true : false),
            },
            beforeSend: function () { },
            success: function (data) {
               if (data.Data != null) {                    
                    $('input[name=rdoOfficerOpinion]').filter('#rdoOfficerOpinion' + data.Data.OpinionID).iCheck('check');
                    //$('input[name=rdoTerm]').filter('#rdoTerm' + data.Data.TermID).iCheck('check');
                    $('#Remark' + componentName).val(data.Data.Remark);

                }
            }
            , error: function (err) {
                console.log(err);
            }
        });

        return res;
    }
    function GetOfficerApprovedExpenseList(applicantID) {
        $.ajax({
            url: '/jfscaseexpense/officerapprovedexpenselist',
            method: 'POST',
            data: {
                applicantID: applicantID,                
            },
            beforeSend: function () { },
            success: function (data) {
                if (data.Ref1 != null) {
                    $('#TotalAmount' + componentName).val(Common.formatNumber(data.Ref1));
                }
                if (data.Data != null) {
                    $('#approvedID' + componentName).val(data.DataID);
                    $.each(data.Data, function (key,value) {
                        console.log(value.ExpenseID);
                        $('#amount' + componentName + value.ExpenseID).val(value.Amount);
                        $('#note' + componentName + value.ExpenseID).val(value.Note);

                    });
                    var frm = $('#frm' + componentName);
                    frm.find('.js--btsave' + componentName).hide();
                    frm.find('.js--cancel').hide();
                }


            }
            , error: function (err) {
                console.log(err);
            }
        });
    }
    function GetCaseApplicantExpense(applicantID) {
        var res;

        $.ajax({
            url: '/jfscaseexpense/getcaseexpense',
            method: 'POST',
            data: {
                applicantID: applicantID,
                status: true,
            },
            beforeSend: function () { },
            success: function (data) {
                if (data.Data.ExpenseRow != null) {
                    $('#box-attach-' + componentName).show();
                    $('.amount').show();                    
                    $.each(data.Data.ExpenseRow, function (key, value) {                       
                        if ($('#tr' + componentName + value.ExpenseID).data('target') == 'True') {
                            $('#tdexpense' + componentName + value.ExpenseID).removeClass('d-none');
                            $('#tbamount' + componentName + value.ExpenseID).removeClass('d-none');
                            $('#tbnote' + componentName + value.ExpenseID).removeClass('d-none');
                            GetCaseApplicantExpenseOther($('#applicantID' + componentName).val(), $('#caseID' + componentName).val(), value.ExpenseID);
                        }
                        else {
                            $('#tdexpense' + componentName + value.ExpenseID).removeClass('d-none');
                            $('#tbamount' + componentName + value.ExpenseID).removeClass('d-none');
                            $('#tbnote' + componentName + value.ExpenseID).removeClass('d-none');
                        }

                    });
                    GetOfficerApprovedExpenseList(applicantID);
                } 

            }
            , error: function (err) {
                console.log(err);
            }
        });


    }
    function GetCaseApplicantExpenseOther(applicantID, caseID, expenseID) {
        $.ajax({
            url: '/jfscaseexpense/getcaseexpenseother',
            method: 'POST',
            data: {
                applicantID: applicantID,
                caseID: caseID,
                
            },
            beforeSend: function () { },
            success: function (data) {
                console.log('GetCaseExpenseOther')
                console.log(data);

                if (data.Status) {
                    //var temp = Handlebars.compile($('#tmpl-list-' + componentName).html());
                    $('#expense' + componentName + expenseID).append("<span> เช่น " + data.Data.ExpenseOther + "</span>");

                    
                }
                var frm = $('#frm' + componentName);
                frm.find('.js--btsave' + componentName).hide();
                frm.find('.js--cancel').hide();
            }
            , error: function (err) {
                console.log(err);
            }
        });
    }

    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#applicantID' + componentName).val() != 0 && $('#caseID' + componentName).val() != 0 && $('#isloadData-' + componentName).val() == 0 ) {
            //Load data
            $('#isloadData-' + componentName).val(1);
           // var frm = $(this).closest('form');
            //console.log(frm);
            $.ajax({
                url: '/jfservices/getcaseapplicantofficeropinion',
                method: 'POST',
                data: {
                    applicantID: $('#applicantID' + componentName).val(),
                    caseID: $('#caseID' + componentName).val(),
                    
                },
                beforeSend: function () { },
                success: function (data) {

                    if (data.Data.OfficerOpinionRow != null) {
                        $('#consideration' + componentName).val(data.Data.OfficerOpinionRow.Consideration).trigger('input');
                        $('#hasOpinion').val(1);
                    }
                    if (data.Data.CaseTermRow != null) {
                        $('input[name=rdoTerm]').filter('#rdoTerm' + data.Data.CaseTermRow.TemID).iCheck('check');
                        $('input[name=rdoFinalApprove]').filter('#rdoFinalApprove' + data.Data.CaseTermRow.FinalApproveID).iCheck('check');
                    }
                    GetCaseApplicantOpinion($('#applicantID' + componentName).val(), 2);
                    //GetCaseApplicantExpense($('#applicantID' + componentName).val());
                    

                    
                }
                , error: function (err) {
                    console.log(err);
                }
            });
            validateNotify();
        }
      // else { console.log('default') }

    });
    //Card 
    //Common.CollapsedCard(this);
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        var frm = $(this).closest('form');
        frm.find('.js--btsave' + componentName).hide();
        frm.find('.js--cancel').hide();
    });

    $('body')
        .off('click', '#btsendsms')
        .on('click', '#btsendsms', function (e) {
            var frm = $('#frmnotify-sms');
            if (frm.validationEngine('validate')) {
                $(this).attr('disabled', 'disabled');
                $.ajax({
                    url: '/messaging/smsnotifyofficerfinalapprove',
                    method: 'post',
                    data: {
                        telephonno: $('#smsnumbernoti').val(),
                        applicantID: $('#applicantID' + componentName).val(),
                        departmentID: $('#departmentID').val(),
                    },
                    beforesend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            SWSuccess.fire({ title: 'ส่งข้อความเรียบร้อยแล้ว' });
                            $('#btsendsms').removeAttr('disabled');
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });

            }
        }).off('click', '#btsendemail')
        .on('click', '#btsendemail', function (e) {
            var frm = $('#frmnotify-email');
            if (frm.validationEngine('validate')) {
                $(this).attr('disabled', 'disabled');
                 $.ajax({
                     url: '/messaging/emailnotifyofficerfinalapprove',
                    method: 'POST',
                     data: {
                         emailTo: $('#emailnoti').val(),
                         applicantID: $('#applicantID' + componentName).val(),
                         departmentID: $('#departmentID').val(),
                     },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            SWSuccess.fire({title:'ส่งอีเมลเรียบร้อยแล้ว'});
                        }
                        $('#btsendemail').removeAttr('disabled');
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });
               
            }
        });
    $('#frm' + componentName)
        .off('keyup change ifChecked', '.js-text')
        .on('keyup change ifChecked', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('change', '.js-amount')
        .on('change', '.js-amount', function (e) {
            var frm = $(this).closest('form');

            var totalamount = 0;
            $('input[name=amount' + componentName + ']').map(function (e) {
                //console.log($(this));
                if (!$(this).hasClass("d-none")) {
                    var amount = parseFloat($(this).val().replace(/,/g, ''));
                    if (amount != NaN && amount > 0) {                       
                        totalamount = parseFloat(totalamount) + parseFloat(amount);
                    }

                }
            });            
            $('#TotalAmount' + componentName).val(Common.formatNumber(totalamount));
           
        })
        .off('ifChecked', 'input[name=rdoOfficerOpinion]:radio')
        .on('ifChecked', 'input[name=rdoOfficerOpinion]:radio', function (e) {
            var frm = $('#frm' + componentName);
            if ($(this).val() == "1") {
                
                if ($('#state' + componentName).val() == 0) {
                    if ($('#jfcasetypeID' + componentName).val() != 2) {
                        GetCaseApplicantExpense($('#applicantID' + componentName).val());
                    }
                    else {
                        $('#box-attach-' + componentName).show();
                        $('[name=tr' + componentName + ']').map(function (e) {
                            console.log('testtrname');
                            console.log($(this).data('count'));
                            console.log("Data-ID");
                            console.log($(this).data('id'));
                            if ($(this).data('count') == 2) {
                                $('#tdexpense' + componentName + $(this).data('id')).removeClass('d-none');
                                $('#tbamount' + componentName + $(this).data('id')).removeClass('d-none');
                                $('#tbnote' + componentName + $(this).data('id')).removeClass('d-none');
                                GetOfficerApprovedExpenseList($('#applicantID' + componentName).val());
                            }


                        });
                        $('.amount').show();
                    }
                    $('#state' + componentName).val(1);
                }
                else {
                    $('#box-attach-' + componentName).show();
                    //$('#tr' + componentName + 13).show();
                    $('[name=tr' + componentName + ']').map(function (e) {
                        console.log('testtrname');
                        console.log($(this).data('count'));
                        console.log("Data-ID");
                        console.log($(this).data('id'));
                        if ($(this).data('count') == 2) {
                            $('#tdexpense' + componentName + $(this).data('id')).removeClass('d-none');
                            $('#tbamount' + componentName + $(this).data('id')).removeClass('d-none');
                            $('#tbnote' + componentName + $(this).data('id')).removeClass('d-none');
                            GetOfficerApprovedExpenseList($('#applicantID' + componentName).val());
                        }


                    });
                    $('.amount').show();
                }
               
            } else {
                
                $('#box-attach-' + componentName).hide();
                $('.amount').hide();
            }
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
            
        })
        .off('click', '#btnotify')
        .on('click', '#btnotify', function (e) {
                $('#modalnotify').modal('show');
           
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {

            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {

                var caseApplicantOfficerOpinionData = {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    Consideration: $('#consideration' + componentName).val()
                }                
                var opinionData = null;
                var opinionCheck = $('input[name="rdoOfficerOpinion"]').is(':checked');
                if (opinionCheck) {
                    var opinionID = parseInt($('input[name="rdoOfficerOpinion"]:checked').val());
                   
                }
                opinionData = {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    OpinionID: opinionID,                    
                    OfficerRoleID: 2,                    
                    Remark: $('#Remark' + componentName).val(),
                }


                var termCheck = $('input[name="rdoTerm"]').is(':checked');
                if (termCheck) {
                    var termID = parseInt($('input[name="rdoTerm"]:checked').val());
                    
                }
                var finalCheck = $('input[name="rdoFinalApprove"]').is(':checked');
                if (finalCheck) {
                    var finalID = parseInt($('input[name="rdoFinalApprove"]:checked').val());
                    CaseTerm = {
                        CaseID: $('#caseID' + componentName).val(),
                        TemID: termID,
                        FinalApproveID: finalID,
                    }
                }


                var caseExpenseApprov = [];
                //var expenseID = []
                if (opinionData.OpinionID == 1) {
                    //console.log("OpinionID = ", TermData.OpinionID);
                    $('input[name=amount' + componentName + ']').map(function (e) {
                        //console.log($(this));
                        if (!$(this).hasClass("d-none")) {
                            if ($(this).val() != 0) {
                                caseExpenseApprov.push({
                                    ApprovedID: $('#approvedID' + componentName).val(),
                                    ExpenseID: $(this).data('id'),
                                    Amount: $(this).val().replace(/,/g, ''),
                                    Note: ($(this).val() != 0 ? $('#notecaseconsideration' + $(this).data('id')).val() : "")
                                });
                            }

                        }
                    });
                }
                else {
                    caseExpenseApprov = null;
                    $('input[name=amount' + componentName + ']').map(function (e) {
                        //console.log($(this));
                        if (!$(this).hasClass("d-none")) {
                            $(this).val(0);
                            $('#notecaseconsideration' + $(this).data('id')).val("");
                        }
                    });
                }      $.ajax({
                            url: '/jfservices/savecaseapplicantofficeropinionext',
                            method: 'POST',
                            data: {
                                officerOpinionData: caseApplicantOfficerOpinionData,
                                officerApprovedExpenseData: {
                                    ApprovedID: $('#approvedID' + componentName).val(),
                                    CaseID: $('#caseID' + componentName).val(),
                                    ApplicantID: $('#applicantID' + componentName).val(),
                                    OfficerRoleID:2,
                                    TotalAmount: $('#TotalAmount' + componentName).val().replace(/,/g, ''),
                                    //ApproveDateStr:,
                                    IsFinalApproved: false,
                                    Note:'',
                                },
                                approvelist: caseExpenseApprov,
                                opinionData: opinionData,
                                caseterm: CaseTerm,
                                },
                            beforeSend: function () { },
                            success: function (data) {
                                if (data.Status) {
                                    $('#approvedID' + componentName).val(data.DataID);
                                    frm.find('.js--btsave' + componentName).hide();
                                    frm.find('.js--cancel').hide();
                                    frm.find('.header-icon').remove();
                                    SWSuccess.fire();
                                } else {

                                    SWError.fire();
                                }

                            }
                            , error: function (err) {
                                if (err.status == 401) {
                                    window.location.reload();
                                }
                            }
                        });


                
                validateNotify();
            }

        });
    function validateNotify() {
        if ($('#workStepID').length) {
             //4 ทำความเห็น
            if ($('#workStepProgress option:last-child').val() <= 4) {
                $('#btnotify').show();
                var temp = Handlebars.compile($('#tmpl-modalnotify').html());
                $('body').append(temp());
            } else {
                $('#btnotify').hide();
            }
        }
    }



});