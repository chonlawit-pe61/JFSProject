$(function () {

    var componentName = 'appeal';


    $('#card-requester' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
       
        
    });
    $('#card-committee' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        

    });
    $('#card-lawyer' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        

    });


    $('#card-requester' + componentName).on('collapsed.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        var frm = $(this).closest('form');
        var applicant = $('#applicantID' + componentName).val();
        //console.log(reason);
        if (applicant != 0 && $('#state' + componentName).val() == 0) {

            //Load data
           

        } else { console.log('default') }
        frm.find('.js--btsaverequester' + componentName).hide();
        frm.find('.js--cancel').hide();
    });
    $('#card-committee' + componentName).on('collapsed.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        var frm = $(this).closest('form');
        frm.find('.js--btsavecommittee' + componentName).hide();
        frm.find('.js--cancel').hide();
    });
    $('#card-lawyer' + componentName).on('collapsed.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        var frm = $(this).closest('form');
        frm.find('.js--btsavecommittee' + componentName).hide();
        frm.find('.js--cancel').hide();
    });


    $('#frmrequester' + componentName)
        .off('keyup change ifChanged', '.js-text')
        .on('keyup change ifChanged', '.js-text', function (e) {
            var frm = $('#frmrequester' + componentName);
            frm.find('.js--btsaverequester' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('click', '.js--btsaverequester' + componentName)
        .on('click', '.js--btsaverequester' + componentName, function (e) {
            var frm = $('#frmrequester' + componentName);
            if (frm.validationEngine('validate')) {
                var caseAppealData = {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    CaseID: $('#caseID' + componentName).val(),
                    DepartmentID: $('#departmentID' + componentName).val(),
                    AppealName: $('#appealName').val(),
                    AppealDate: $('#appealDate').val(),
                    AppealDateStr: $('#appealDate').val(),
                    AdditionalIssue: $('#appealDescription').val(),
                    AdditionalFactsInIssue: $('#appealFactDescription').val(),
                    AdditionalOfficerOpinion: $('#appealOfficerOpinion').val(),
                }
                $.ajax({
                    url: '/jfservices/savecaseappeal',
                    method: 'POST',
                    data: {
                        req: caseAppealData,
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            frm.find('.js--btsaverequester' + componentName).hide();
                            frm.find('.js--cancel').hide();
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
            }
        });
    $('#frmcommittee' + componentName)
        .off('keyup change ifChanged', '.js-text')
        .on('keyup change ifChanged', '.js-text', function (e) {
            var frm = $('#frmcommittee' + componentName);
            frm.find('.js--btsavecommittee' + componentName).show();
            frm.find('.js--cancel').show();
        }).off('click', '.js--btsavecommittee' + componentName)
        .on('click', '.js--btsavecommittee' + componentName, function (e) {
            var frm = $('#frmcommittee' + componentName);
            if (frm.validationEngine('validate')) {
                var rdoname = 'rdoCommitteeOpinion' + componentName;
                var opinionCheck = $('input[name=' + rdoname + ']').is(':checked');
                if (opinionCheck) {
                    var opinionID = parseInt($('input[name=' + rdoname + ']:checked').val());
                    opinionData = opinionID;

                }
                var applicantOpinionData = {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    OfficerRoleID: 8,//8=committee
                    IsAppeal: true,
                    OpinionID: opinionID,
                    Remark: $('#RemarkCommittee' + componentName).val(),
                }
                //console.log(applicantOpinionData1)
                $.ajax({
                    url: '/jfservices/savecaseapplicantappeal',
                    method: 'POST',
                    data: {
                        req: applicantOpinionData,
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            frm.find('.js--btsave' + componentName).hide();
                            frm.find('.js--cancel').hide();
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
            }
        });
    $('#frmlawyer' + componentName)
        .off('keyup change ifChanged', '.js-text')
        .on('keyup change ifChanged', '.js-text', function (e) {
            var frm = $('#frmlawyer' + componentName);
            frm.find('.js--btsavelawyer' + componentName).show();
            frm.find('.js--cancel').show();
        }).off('click', '.js--btsavelawyer' + componentName)
        .on('click', '.js--btsavelawyer' + componentName, function (e) {
            var frm = $('#frmlawyer' + componentName);
            if (frm.validationEngine('validate')) {
                var rdoname = 'rdoOfficerOpinion' + componentName;
                var opinionCheck = $('input[name=' + rdoname + ']').is(':checked');
                if (opinionCheck) {
                    var opinionID = parseInt($('input[name=' + rdoname + ']:checked').val());
                    opinionData = opinionID;
                }
                var applicantOpinionData1 = {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    OfficerRoleID: 2,//2=lawyer
                    IsAppeal: true,
                    OpinionID: opinionID,
                    Remark: $('#Remark' + componentName).val(),
                }
                //console.log(applicantOpinionData1)
                $.ajax({
                    url: '/jfservices/savecaseapplicantappeal',
                    method: 'POST',
                    data: {
                        req: applicantOpinionData1,
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            frm.find('.js--btsavelawyer' + componentName).hide();
                            frm.find('.js--cancel').hide();
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
            }
        });

});