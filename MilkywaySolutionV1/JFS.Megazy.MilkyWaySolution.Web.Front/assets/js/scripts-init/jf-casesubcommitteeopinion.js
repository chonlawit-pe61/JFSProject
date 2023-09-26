$(function () {
    var componentName = 'casesubcommitteeopinion';   
    function getmatterlistbyjfcase() {

        $.ajax({
            url: '/jfservices/getmatterlistbyjfcase',
            method: 'POST',
            data: { jfCaseType: $('#jfcasetypeid' + componentName).val() },
            beforeSend: function () { },
            success: function (data) {
                console.log(data);
                if (data.Status) {
                   
                    var temp = Handlebars.compile($('#tmpl-list-casesubcommitteeopinion').html());

                    $('#list-law-' + componentName).html(temp(data.Data.Matter));

                    $('input[type="checkbox"], input[type="radio"]').iCheck({
                        checkboxClass: 'icheckbox_flat-grey',
                        radioClass: 'iradio_flat-grey'
                    });

                    //$.each(mattersOfLawOpinion, function (key, value) {
                    //    alert(key + ": " + value);
                    //});

                    


                }
            }
            , error: function (err) {
                console.log(err);
            }
        });
    }
    async function asyncSetMattersOfLaw(data) {
        console.log('calling');
        await SetMattersOfLaw(data);
    }
    function SetMattersOfLaw(data) {
        //data.Data.MattersOfLawOpinion
        $.each(data, function (key, value) {
            console.log(key + ": " + value.MatterID);
            $('input[name=chkBracket' + componentName + ']').filter('#chkBracket' + componentName + '-' + value.BracketID + '-' + value.MatterID).iCheck('check');
        });
      
    }
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#applicantID' + componentName).val() != 0 && !$('input[name="rdoSubcommitteeOpinion"]').is(':checked')) {
            var frm = $('#frm' + componentName);
            var mattersOfLawOpinion = [];
            getmatterlistbyjfcase();
            $.ajax({
                url: '/jfservices/getsubcommittee',
                method: 'POST',
                data: {
                    caseID: parseInt($('#caseID' + componentName).val()),
                    applicantID: parseInt($('#applicantID' + componentName).val()),
                    officerRoleID: parseInt($('#OfficerRoleID' + componentName).val()),
                    IsAppeal: ($('#isappeal' + componentName).val() == 1 ? true : false),
                    IsReview: false,//สามารถเปลี่ยนค่านี้ true หากเป็นกรณีทบทวน
                    IsAdditional: false,//สามารถเปลี่ยนค่านี้ true หากเป็นกรณีเพิ่มเติม
                },
                beforeSend: function () { },
                success: function (data) {
                    console.log("rdoSubcommitteeOpinion");
                    console.log(data);

                    if (data.Data.CaseApplicantOpinion != null) {
                        $('input[name=rdoSubcommitteeOpinion]').filter('#rdoSubcommitteeOpinion' + data.Data.CaseApplicantOpinion.OpinionID).iCheck('check');
                        $('#AdditionalOpinion' + componentName).val(data.Data.CaseApplicantOpinion.AdditionalOpinion);
                        $('#Remark' + componentName).val(data.Data.CaseApplicantOpinion.Remark);
                        if (data.Data.MinitesRow.MeetingDate) { $('#meetingDate' + componentName).val(Common.JSONDate(data.Data.MinitesRow.MeetingDate)); }
                        $('#meetingResults' + componentName).val(data.Data.MinitesRow.MeetingResults);
                        $('#times' + componentName).val(data.Data.MinitesRow.Times);
                        $('#meetingPlace' + componentName).val(data.Data.MinitesRow.MeetingPlace);
                        $('#subnote' + componentName).val(data.Data.MinitesRow.Note);

                    }

                    var metterData = data.Data.MattersOfLawOpinion;
                    if (metterData != null) {
                        if (metterData.length > 0) {
                            //SetMattersOfLaw(metterData);

                            asyncSetMattersOfLaw(metterData)
                        }
                       
                    }
                    
                    frm.find('.js--btsave' + componentName).hide();
                    frm.find('.js--cancel').hide();

                }
                , error: function (err) {
                    console.log(err);
                }
            });

            //metter
            
            
            console.log('sfsdfsd');
            console.log(mattersOfLawOpinion);
             //metter

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
        .off('ifChecked', 'input[name=rdoSubcommitteeOpinion]:radio')
        .on('ifChecked', 'input[name=rdoSubcommitteeOpinion]:radio', function (e) {
            console.log($(this).val());
            if ($(this).val() == 1 || $(this).val() == 2) {
                $('#box-attach-' + componentName).show();
                //GetCaseExpenseConsideration($('#applicantID' + componentName).val());
                $('#state' + componentName).val(1);
                if ($('#state' + componentName).val() == 0) { }
                // $('.amount').show()
                $.ajax({
                    url: '/jfscaseexpense/getcaseamountapproved',
                    method: 'POST',
                    data: {
                        applicantID: $('#applicantID' + componentName).val(),
                        prevOfficerroleID: 2,//2: นิติกร
                        currOfficerroleID: $('#OfficerRoleID' + componentName).val(),
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        console.log('GetCaseApplicantExpense')
                        console.log(data);

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
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });
                var frm = $('#frm' + componentName);
                frm.find('.js--btsave' + componentName).show();
                frm.find('.js--cancel').show();
            } else {
                $('.amount').hide();
                $('#box-attach-' + componentName).hide();
            }
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {
           if ($('#frm' + componentName).validationEngine('validate')) {

                var caseMeetingMinutes = {
                    CaseID: $('#caseID' + componentName).val()
                    , ApplicantID: $('#applicantID' + componentName).val()
                    //, IsReview: $('#' + componentName).val()
                    //, IsAdditional: $('#' + componentName).val()
                    , MeetingDateStr: $('#meetingDate' + componentName).val()
                    , MeetingResults: $('#meetingResults' + componentName).val()
                    , Times: $('#times' + componentName).val()
                    , MeetingPlace: $('#meetingPlace' + componentName).val()
                    , Note: $('#subnote' + componentName).val()
                };

                var opinionData = null;
                var opinionCheck = $('input[name="rdoSubcommitteeOpinion"]').is(':checked');
                if (opinionCheck) {
                    var opinionID = parseInt($('input[name="rdoSubcommitteeOpinion"]:checked').val());
                    opinionData = opinionID;

                }
              //  var AdditionalOpinion = $('#AdditionalOpinion' + componentName).val();
               var IsFinalApproved = true;//Fix 
                applicantOpinionData = {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    OfficerRoleID: $('#OfficerRoleID' + componentName).val(),
                    IsAppeal: ($('#isappeal' + componentName).val() == 1 ? true : false),
                    OpinionID: opinionData,
                    //AdditionalOpinion: $('#meetingResults' + componentName).val(),
                    Comment: $('#meetingResults' + componentName).val(),
                    Remark:  $('#subnote' + componentName).val(),
                    IssueDateStr: $('#meetingDate' + componentName).val(),
                    CompleteDateStr: $('#meetingDate' + componentName).val(),
                    IsFinalApproved: IsFinalApproved,
                }
                
                var caseExpenseApprov = [];
                var appdata = null
                //if ($('#termID' + componentName).val() != 3) {
                //    IsFinalApproved = true;
                //}
                //else {
                //    IsFinalApproved = false;
                //}
                if (opinionID == 1 || opinionID == 2) {                  
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

                 var caseMattersOfLawOpinionData = [];
                 var caseMattersOfLawOpinionCheck = $('input[name="chkBracket' + componentName + '"]:checked');
                    caseMattersOfLawOpinionCheck.each(function () {
                        var matterid = $(this).data('matterid');
                        var bracketid = $(this).data('bracketid');                       
                        caseMattersOfLawOpinionData.push({
                                    CaseID: parseInt($('#caseID' + componentName).val()),
                                    AppicantID: parseInt($('#applicantID' + componentName).val()),
                                    OfficerRoleID: parseInt($('#OfficerRoleID' + componentName).val()),
                                    BracketID: bracketid,
                                    MatterID: matterid
                                });
                    });
                $.ajax({
                    url: '/jfservices/savesubcommittee',
                    method: 'POST',
                    data: {
                        applicantOpinionData: applicantOpinionData,
                        caseMeetingMinutes: caseMeetingMinutes,
                        caseExpenseApprov: caseExpenseApprov,
                        appdata: appdata,
                        caseMattersOfLawOpinionData: caseMattersOfLawOpinionData
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            $('#approvedID' + componentName).val(data.DataID);
                            var frm = $('#frm' + componentName);
                            frm.find('.js--btsave' + componentName).hide();
                            frm.find('.js--cancel').hide();
                            frm.find('.header-icon').remove();
                            SWSuccess.fire({
                                onClose: () => {
                                    window.location.reload();
                                }});
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
          }

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

});


