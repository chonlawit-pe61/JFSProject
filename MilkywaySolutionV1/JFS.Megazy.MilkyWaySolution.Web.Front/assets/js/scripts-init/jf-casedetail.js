$(function () {
    var componentName = 'casedetail';

    //function getprovince(provinceID) {
    //    $.ajax({
    //        url: '/jfservices/getprovince',
    //        method: 'POST',
    //        data: {
    //            provinceID: provinceID,
    //        },
    //        beforeSend: function () { },
    //        success: function (data) {
    //            $('#province' + componentName).val(data.Data.ProvinceName);                
    //            var frm = $('#frm' + componentName);
    //            frm.find('.js--btsave' + componentName).show();
    //            frm.find('.js--cancel').show();
    //        }
    //        , error: function (err) {
    //            console.log(err);
    //        }
    //    });
    //}
    //Card 
    //Common.CollapsedCard(this);
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        var frm = $(this).closest('form');



        frm.find('.js--btsave' + componentName).hide();
        frm.find('.js--cancel').hide();
    });
   
    $('#frm' + componentName)
        //.off('keyup change ifChecked', '.js-text')
        //.on('keyup change ifChecked', '.js-text', function (e) {
        //    var frm = $('#frm' + componentName);
        //    frm.find('.js--btsave' + componentName).show();
        //    frm.find('.js--cancel').show();
        //})
        //.off('change', '.js-province')
        //.on('change', '.js-province', function (e) {
        //    var frm = $('#frm' + componentName);
        //    console.log("Test");
        //    var provinceID = $('#department' + componentName).find(':selected').data("id");
        //    $('#provinceID' + componentName).val(provinceID);  
        //   // getprovince(provinceID);
        //    frm.find('.js--btsave' + componentName).show();
        //    frm.find('.js--cancel').show();
        //})        
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {

            if ($('#frm' + componentName).validationEngine('validate')) {

                var data = {
                    ContractID: $('#contractID' + componentName).val(),
                    CourtOrderID: parseInt($('input[name="rdoCourtResult"]:checked').val()),
                    ResultID: parseInt($('input[name="rdorefund"]:checked').val()),
                    CourtOrderAmount: $('#amountrefund' + componentName).val(),
                    CourtLocation: $('#CourtLocation' + componentName +' :selected').text(),
                    JudgmentDateStr: $('#date' + componentName).val(),
                    Note: $('#Note' + componentName).val()
                };
                console.log(data);
                 $.ajax({
                     url: '/jfservices/savecontractcasefollowup',
                    method: 'POST',
                     data: {
                         req: data,
                         applicantID: $('#applicantID' + componentName).val()
                     },
                    beforeSend: function () { },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            SWSuccess.fire();
                            if ($('#amountrefund' + componentName).val() > 0) {
                                loadCaseRefund(true);
                                getTrackingRefund($('#contractID' + componentName).val())
                            } else {
                                loadCaseRefund(false);
                            }
                        } else {
                            SWError.fire();
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });
                //SWConfirm.fire().then((result) => {
                //    if (result.value) {
                //        SWSuccess.fire()
                //    }
                //});

            }
       
          
     //    CourtOrderName = frow.CourtOrderName,
                        //        ContractID = frow.ContractID,
                        //        CourtLocation = frow.CourtLocation,
                        //        CourtOrderAmount = frow.CourtOrderAmount,
                        //        CourtOrderID = frow.CourtOrderID,
                        //        Note = frow.Note,
                        //        ResultID = frow.ResultID,
                        //        ResultName = frow.ResultName
                        //};
                        //if (!frow.IsJudgmentDateNull) {
                        //    res.FollowUpData.JudgmentDate = frow.JudgmentDate;
                        //    res.FollowUpD


            //SWConfirm.fire().then((result) => {
            //    if (result.value) {

            //        var opinionData = null;
            //        var opinionCheck = $('input[name="rdoDirectorOpinion"]').is(':checked');
            //        if (opinionCheck) {
            //            var opinionID = parseInt($('input[name="rdoDirectorOpinion"]:checked').val());
            //            opinionData = opinionID;

            //        }
            //        var AdditionalOpinion = $('#AdditionalOpinion' + componentName).val();
            //        var Remark = $('#Remark' + componentName).val();


            //        console.log('opinionData = ', opinionData);
            //        console.log('AdditionalOpinion = ', AdditionalOpinion);
            //        console.log('Remark = ', Remark);
            //        applicantOpinionData = {
            //            ApplicantID: $('#applicantID' + componentName).val(),
            //            OfficerRoleID: $('#OfficerRoleID' + componentName).val(),
            //            OpinionID: opinionData,
            //            AdditionalOpinion: AdditionalOpinion,
            //            Remark: Remark,

            //        }
            //        console.log(applicantOpinionData)

            //        $.ajax({
            //            url: '/jfservices/savecasedirectoropinion',
            //            method: 'POST',
            //            data: {
            //                applicantOpinionData: applicantOpinionData,

            //            },
            //            beforeSend: function () { },
            //            success: function (data) {

            //                if (data.Status) {
            //                    //$('#applicantID' + componentName).val(data.ID);
            //                    var frm = $('#frm' + componentName);
            //                    frm.find('.js--btsave' + componentName).hide();
            //                    frm.find('.js--cancel').hide();
            //                    SWSuccess.fire();
            //                } else {

            //                    SWError.fire();
            //                }

            //            }
            //            , error: function (err) {
            //                if (err.status == 401) {
        //    window.location.reload();
        //}
            //            }
            //        });


            //    }
            //});



        });
   
});
function getFollowUpLawyerInContract() {
    var componentName = 'casedetail';
    if ($('#contractIDcasedetail').length && $('#contractIDcasedetail').val() == 0) {

        $.ajax({
            //GetJudgeDetail
            url: '/jfservices/getfollowuplawyerincontract',
            method: 'POST',
            data: {
                applicantID: $('#applicantID' + componentName).val()
                , caseID: $('#caseID' + componentName).val()
            },
            beforeSend: function () { },
            success: function (data) {
                console.log(data);
                if (data.Status) {
                    if (data.Data.LaywerID != 0) {
                       $('#contractIDcasedetail').val(data.Data.ContractID);
                        $('#laywerIDcasedetail').val(data.Data.LaywerID);
                        $('#contractNocasedetail').val(data.Data.ContractNo);
                        var htm = '<div><span  class="text-muted pr-2">เลขที่สัญญา:</span>' + data.Data.ContractNo + '</div>';
                        htm += '<div><span  class="text-muted pr-2">ทนาย:</span>' + data.Data.LawyerFirstName + ' ' + data.Data.LawyerLastName + '</div><div class="divider"></div>';
                        $('#lawyercaseinfo').html(htm);
                        if (data.Data.CaseData) {
                            var cased = data.Data.CaseData;
                            $('#blacknumber' + componentName).val(cased.CaseBlackNo);
                            $('#rednumber' + componentName).val(cased.CaseRedNo);
                            $('#CourtLocation' + componentName).val(cased.CourID).trigger('change');
                        }
                        if (data.Data.FollowUpData) {
                            var fl = data.Data.FollowUpData;
                            $(':radio[name=rdorefund][value=' + fl.CourtOrderID + ']').iCheck('check');
                            $(':radio[name=rdoCourtResult][value=' + fl.ResultID + ']').iCheck('check');
                            //    CourtOrderName = frow.CourtOrderName,
                            //        ContractID = frow.ContractID,
                            //        CourtLocation = frow.CourtLocation,
                            //        CourtOrderAmount = frow.CourtOrderAmount,
                            //        CourtOrderID = frow.CourtOrderID,
                            //        Note = frow.Note,
                            //        ResultID = frow.ResultID,
                            //        ResultName = frow.ResultName
                            //};
                            //if (!frow.IsJudgmentDateNull) {
                            //    res.FollowUpData.JudgmentDate = frow.JudgmentDate;
                            //    res.FollowUpData.JudgmentDateStr = Utility.ConvertDateToThaiLongDate(frow.JudgmentDate);


                            $('#Note' + componentName).val(fl.Note).trigger('input');
                            $('#amountrefund' + componentName).val(fl.CourtOrderAmount);
                            $('#date' + componentName).val(Common.JSONDate(fl.JudgmentDate));
                            $('#date' + componentName).datepicker({ defaultDate: Common.JSONDate(fl.JudgmentDate) });
                            if (fl.CourtOrderAmount > 0) {
                                loadCaseRefund(true);
                                getTrackingRefund($('#contractID' + componentName).val())

                            } else {
                                loadCaseRefund(false);
                            }

                        }
                    } else {
                        $('#lawyercaseinfo').html('<div class="text-primary">ไม่มีข้อมูลสัญญา</div>');
                    }
                }
            }
            , error: function (err) {
                console.log(err);
            }
        });
    }

}
function loadCaseRefund(isShow) {
    if (isShow) {
        $('#frmcaserefund').show();
    } else {
        $('#frmcaserefund').hide();
    }
   
}
