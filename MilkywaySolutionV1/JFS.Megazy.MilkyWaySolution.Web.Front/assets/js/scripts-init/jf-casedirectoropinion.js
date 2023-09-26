$(function () {
    var componentName = 'casedirectoropinion';
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
    function GetCaseExpenseDirectorOpinion(applicantID) {
        var res;;
        $.ajax({
            url: '/jfscaseexpense/getcaseexpenseconsideration',
            method: 'POST',
            data: {
                applicantID: applicantID,
                subofficerroleID: 2,//2:นิติกร
                officerroleID: $('#OfficerRoleID' + componentName).val(),
                
            },
            beforeSend: function () { },
            success: function (data) {
                console.log('GetCaseExpenseDirectorOpinion')
                console.log(data);
                $('#approvedID' + componentName).val(data.DataID);
                if (data.Data.Old != null) {
                    //$('#box-attach-' + componentName).show();
                    
                    $.each(data.Data.Old, function (key, value) {
                        //console.log("test");
                        if ($('#tr' + componentName + value.ExpenseID).data('target') == 'True') {
                            $('#tdexpense' + componentName + value.ExpenseID).removeClass('d-none');
                            $('#tbamount' + componentName + value.ExpenseID).removeClass('d-none');
                            $('#tbnote' + componentName + value.ExpenseID).removeClass('d-none');
                            $('#tboldamount' + componentName + value.ExpenseID).removeClass('d-none');
                            $('#oldamount' + componentName + value.ExpenseID).val(value.Amount).attr("disabled", "disabled");
                            if (data.Data.New == null) {
                                $('#amount' + componentName + value.ExpenseID).val(value.Amount);
                            }
                            GetCaseApplicantExpenseOther($('#applicantID' + componentName).val(), $('#caseID' + componentName).val(), value.ExpenseID);
                        } else {

                            $('#tdexpense' + componentName + value.ExpenseID).removeClass('d-none');
                            $('#tbamount' + componentName + value.ExpenseID).removeClass('d-none');
                            $('#tbnote' + componentName + value.ExpenseID).removeClass('d-none');
                            $('#tboldamount' + componentName + value.ExpenseID).removeClass('d-none');
                            $('#oldamount' + componentName + value.ExpenseID).val(value.Amount).attr("disabled", "disabled");
                            if (data.Data.New == null) {
                                $('#amount' + componentName + value.ExpenseID).val(value.Amount);
                            }
                            //$('#note' + componentName + value.ExpenseID).val(value.Note);

                        }

                    });
                    
                    
                    //GetOfficerApprovedExpenseList(applicantID);
                }
                if (data.Data.New != null) {
                    $.each(data.Data.New, function (key, value) {
                        $('#amount' + componentName + value.ExpenseID).val(value.Amount);
                        $('#note' + componentName + value.ExpenseID).val(value.Note);
                    });
                }
                if (data.Data.Row != null) {
                    $('#TotalAmount' + componentName).val(Common.formatNumber(data.Data.Row.TotalAmount));
                }
            }
            , error: function (err) {
                console.log(err);
            }
        });
    }
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#applicantID' + componentName).val() != 0 && $('#Remark' + componentName).val() == '') {
            //$('#isloadData-' + componentName).val(1);
            var frm = $(this).closest('form');
            $.ajax({
                url: '/jfservices/getcaseapplicantopinion',
                method: 'POST',
                data: {
                    applicantID: $('#applicantID' + componentName).val(),
                    officerRoleID: $('#OfficerRoleID' + componentName).val(),
                    IsAppeal: ($('#isappeal' + componentName).val() == 1 ? true : false),
                },
                beforeSend: function () { },
                success: function (data) {
                    console.log(data)
                    if (data.Data != null) {
                        $('input[name=rdoDirectorOpinion]').filter('#rdoDirectorOpinion' + data.Data.OpinionID).iCheck('check');
                        $('#AdditionalOpinion' + componentName).val(data.Data.AdditionalOpinion);
                        $('#Remark' + componentName).val(data.Data.Remark);

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
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        var frm = $(this).closest('form');
        frm.find('.js--btsave' + componentName).hide();
        frm.find('.js--cancel').hide();
    });

    $('#frm' + componentName)
        .off('keyup change ifChecked', '.js-text')
        .on('keyup change ifChecked', '.js-text', function (e) {
            var frm = $('#frm' + componentName);
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('ifChecked', 'input[name=rdoDirectorOpinion]:radio')
        .on('ifChecked', 'input[name=rdoDirectorOpinion]:radio', function (e) {
            //6 = เห็นพ้องตามเจ้าหน้าที่
            if ($(this).val() == "6") {
                $('#boxApprove' + componentName).show();
                $.ajax({
                    url: '/jfscaseexpense/getcaseamountapproved',
                    method: 'POST',
                    data: {
                        applicantID: $('#applicantID' + componentName).val(),
                        prevOfficerroleID: 2,
                        currOfficerroleID: $('#OfficerRoleID' + componentName).val(),
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            $('#PreTotalAmount' + componentName).val(data.Data.PreTotalAmount);
                            if (data.Data.TotalAmount != 0) {
                                $('#TotalAmount' + componentName).val(data.Data.TotalAmount);
                            } else {
                                $('#TotalAmount' + componentName).val(data.Data.PreTotalAmount);
                            }
                            $('#note' + componentName).val(data.Data.Remark);
                            $('#approvedID' + componentName).val(data.Data.ApprovedID);
                        }                       
                        //if (data.Data.Old != null) {                            
                        //    //GetOfficerApprovedExpenseList(applicantID);
                        //}
                        //if (data.Data.New != null) {
                        //    $.each(data.Data.New, function (key, value) {
                        //        $('#amount' + componentName + value.ExpenseID).val(value.Amount);
                        //        $('#note' + componentName + value.ExpenseID).val(value.Note);
                        //    });
                        //}
                        //if (data.Data.Row != null) {
                        //    $('#TotalAmount' + componentName).val(Common.formatNumber(data.Data.Row.TotalAmount));
                        //}
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });
                //$('.amount').show()
                //var frm = $('#frm' + componentName);
                //frm.find('.js--btsave' + componentName).show();
                //frm.find('.js--cancel').show();
            } else {
                $('#boxApprove' + componentName).hide();
           }
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {
            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {
                var opinionData = null;
                var opinionCheck = $('input[name="rdoDirectorOpinion"]').is(':checked');
                if (opinionCheck) {
                    var opinionID = parseInt($('input[name="rdoDirectorOpinion"]:checked').val());
                    opinionData = opinionID;
                }
                var AdditionalOpinion = $('#AdditionalOpinion' + componentName).val();
                applicantOpinionData = {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    OfficerRoleID: $('#OfficerRoleID' + componentName).val(),                   
                    OpinionID: opinionData,
                    AdditionalOpinion: AdditionalOpinion,
                    Remark: $('#Remark' + componentName).val(),
                }
                var caseExpenseApprov = [];
                var appdata = null
                var IsFinalApproved = false;
                if ($('#termID' + componentName).val() == 3) {
                    IsFinalApproved = true;
                }
                else {
                    IsFinalApproved = false;
                }
                if (opinionID == 6) {
                    appdata = {
                        ApprovedID: $('#approvedID' + componentName).val(),
                        CaseID: $('#caseID' + componentName).val(),
                        ApplicantID: $('#applicantID' + componentName).val(),
                        OfficerRoleID: $('#OfficerRoleID' + componentName).val(),
                        TotalAmount: $('#TotalAmount' + componentName).val().replace(/,/g, ''),
                        Note: $('#note' + componentName).val(),
                        IsFinalApproved: IsFinalApproved,
                    }
                }
                else {
                    
                    caseExpenseApprov = null;
                    $('input[name=amount' + componentName + ']').map(function (e) {
                        //console.log($(this));
                        if (!$(this).hasClass("d-none")) {
                            $(this).val(0);
                            $('#note' + componentName + $(this).data('id')).val("");
                        }
                    });
                    appdata = {
                        ApprovedID: $('#approvedID' + componentName).val(),
                        CaseID: $('#caseID' + componentName).val(),
                        ApplicantID: $('#applicantID' + componentName).val(),
                        OfficerRoleID: $('#OfficerRoleID' + componentName).val(),
                        TotalAmount: $('#TotalAmount' + componentName).val().replace(/,/g, ''),
                        Note: $('#note' + componentName).val(),
                        IsFinalApproved: IsFinalApproved,
                    }
                }
                $.ajax({
                    url: '/jfservices/savecasedirectoropinion',
                    method: 'POST',
                    data: {
                        applicantOpinionData: applicantOpinionData,
                        caseExpenseApprov: caseExpenseApprov,
                        appdata: appdata,
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            $('#approvedID' + componentName).val(data.DataID);
                            
                            SWSuccess.fire();
                        } else {

                            SWError.fire();
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });                                  
                frm.find('.js--btsave' + componentName).hide();
                frm.find('.js--cancel').hide();
                frm.find('.header-icon').remove();            }
        });
});
     //.off('change', '.js-amount')
     //   .on('change', '.js-amount', function (e) {
     //       var totalamount = 0;
     //       $('input[name=amount' + componentName + ']').map(function (e) {
     //           if (!$(this).hasClass("d-none")) {
     //               var amount = parseFloat($(this).val().replace(/,/g, ''));
     //               if (amount != NaN && amount > 0) {
     //                   totalamount = parseFloat(totalamount) + parseFloat(amount);
     //               }
     //           }
     //       });
     //       $('#TotalAmount' + componentName).val(Common.formatNumber(totalamount));
     //   })