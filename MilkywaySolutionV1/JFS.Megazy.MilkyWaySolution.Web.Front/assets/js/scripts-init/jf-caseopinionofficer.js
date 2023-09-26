$(function () {
    var componentName = 'caseopinionofficer';
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#applicantID' + componentName).val() != 0 && $('#caseopinionFull' + componentName).val() == '') {
            //Load data
            //$('#isloadData-' + componentName).val(1);
            var frm = $(this).closest('form');
            //console.log(frm);
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
                    if (data.Data != null) {
                        
                            $('#caseopinionFull' + componentName).val(data.Data.Comment);
                            $('#caseopinionShort' + componentName).val(data.Data.ShortComment);
                            $('#OpinionID' + componentName).val(data.Data.OpinionID);
                            $('#startOfficerOpinionDate' + componentName).val(Common.JSONDate(data.Data.IssueDate));
                            $('#endOfficerOpinionDate' + componentName).val(Common.JSONDate(data.Data.CompleteDate));
                            //if (!(data.Data.IssueDate == "/Date(-62135596800000)/" && !(data.Data.CompleteDate == "/Date(-62135596800000)/"))) {
                            //    $('#startOfficerOpinionDate' + componentName).val(Common.JSONDate(data.Data.IssueDate));
                            //    $('#endOfficerOpinionDate' + componentName).val(Common.JSONDate(data.Data.CompleteDate));
                            //} else {
                            //    $('#startOfficerOpinionDate' + componentName).val('');
                            //    $('#endOfficerOpinionDate' + componentName).val('');
                            //}
                       
                        
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
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {

            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {

                var Data = {
                    ApplicantID: $('#applicantID' + componentName).val(),
                    IsAppeal: ($('#isappeal' + componentName).val() == 1 ? true : false),
                    OfficerRoleID: $('#OfficerRoleID' + componentName).val(),
                    OpinionID: $('#OpinionID' + componentName).val(),
                    Comment: $('#caseopinionFull' + componentName).val(),
                    ShortComment: $('#caseopinionShort' + componentName).val(),
                    IssueDateStr: $('#startOfficerOpinionDate' + componentName).datepicker({ dateFormat: 'dd/MM/yyyy' }).val(),
                    CompleteDateStr: $('#endOfficerOpinionDate' + componentName).datepicker({ dateFormat: 'dd/MM/yyyy' }).val(),

                }
                                     


                        $.ajax({
                            url: '/jfservices/savecaseopinionofficer',
                            method: 'POST',
                            data: {
                                req: Data,
                                //applicantOpinionData2: applicantOpinionData2,

                            },
                            beforeSend: function () { },
                            success: function (data) {

                                if (data.Status) {
                                    //$('#applicantID' + componentName).val(data.ID);
                                    var frm = $('#frm' + componentName);
                                    frm.find('.js--btsave' + componentName).hide();
                                    frm.find('.js--cancel').hide();
                                    frm.find('.header-icon').remove();
                                    SWSuccess.fire();
                                } else {

                                    SWError.fire();
                                }

                            }
                            , error: function (err) {
                                console.log(err);
                            }
                        });


                  


            }
        });



});