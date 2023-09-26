// Begin การไกล่เกลี่ย
$(function () {

    var componentName = 'casedesire';

    function getcasecourtbail(caseID,applicantID) {
        $.ajax({
            url: '/jfscaseexpense/getcaseexpense',
            method: 'POST',
            data: { applicantID: $('#applicantID' + componentName).val() },
            beforeSend: function () { },
            success: function (data) {
                var dateApprovel = null;
                console.log(data);
                $('#state' + componentName).val(1);
                $.each(data.Data.ExpenseRow, function (index, datas) {
                    $('#expnsehead' + datas.ExpenseID).show();
                    $('#expnse' + datas.ExpenseID).show();
                    $('#amount' + componentName + datas.ExpenseID).removeClass('d-none');
                    $('#amount' + componentName + datas.ExpenseID).val(datas.ApproveAmount);

                    dateApprovel = datas.ApproveDate;

                });
                
                if (jfcasetype == 2) {

                }



                //$('#applicantID' + componentName).val(data.Data.ApplicantID);
                //$('#caseID' + componentName).val(data.Data.CaseID);

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
        var frm = $('#frm' + componentName);
        if ($('#applicantID' + componentName).val() != 0 && $('#state'+componentName).val() == 0) {
            //Load data
            var jfcasetype = $('#jfcasetypeID' + componentName).val();

            $.ajax({
                url: '/jfscaseexpense/getcaseexpense',
                method: 'POST',
                data: { applicantID: $('#applicantID' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    var dateApprovel = null;
                    console.log(data);
                    $('#state' + componentName).val(1);
                    $.each(data.Data.ExpenseRow, function (index, datas) {
                        $('#expnsehead' + datas.ExpenseID).show();
                        $('#expnse' + datas.ExpenseID).show();
                        $('#amount' + componentName + datas.ExpenseID).removeClass('d-none');
                        $('#amount' + componentName + datas.ExpenseID).val(datas.RequestAmount);

                        dateApprovel = datas.ApproveDate;

                    });                   
                    if (jfcasetype == 2) {

                    }



                    //$('#applicantID' + componentName).val(data.Data.ApplicantID);
                    //$('#caseID' + componentName).val(data.Data.CaseID);

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
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) { Common.swcithTabIcon(this); });


    $('#frm' + componentName)
        .off('keyup ifChanged change', '.js-text')
        .on('keyup ifChanged change', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        }).off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {
            console.log('Test');
            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {

                var jfcasetype = $('#jfcasetypeID' + componentName).val();

                
                    var caseExpense = [];
                    

                    $('input[name=amount' + componentName + ']').map(function (e) {

                        if (!$(this).hasClass("d-none")) {
                            caseExpense.push({
                                ApplicantID: $("#applicantID" + componentName).val(),
                                CaseID: $("#caseID" + componentName).val(),
                                RequestAmount: $(this).val(),
                                ExpenseID: $(this).data("id"),
                               

                            })
                        }
                    });
              
                
                if (jfcasetype == 2) {
                    var BailStatusID = $('input[name=result' + componentName + ']:checked').val();
                    var CourtReleaseDate = $('#dateBail' + componentName).val();
                    var CaseCourtBail = null;
                    CaseCourtBail = {
                        ApplicantID: $("#applicantID" + componentName).val(),
                        CaseID: $("#caseID" + componentName).val(),
                        BailStatusID: BailStatusID,
                        CourtReleaseDateStr: CourtReleaseDate,
                    }
                             $.ajax({
                                url: '/jfscaseexpense/savecaseexpensedataamountandcourt',
                                method: 'POST',
                                data: {
                                    caseExpense: caseExpense,
                                    applicantID: $('#applicantID' + componentName).val(),
                                    caseCourt: CaseCourtBail,

                                },
                                beforeSend: function () {
                                },
                                success: function (data) {
                                    console.log(data);
                                    if (data.Status) {
                                        //$('#applicantID' + componentName).val(data.ID);

                                        SWSuccess.fire();
                                    }
                                }
                                , error: function (err) {
                                    if (err.status == 401) {
                                        window.location.reload();
                                    }
                                }
                            });

                            frm.find('.js--btsave' + componentName).hide();
                            frm.find('.js--cancel').hide();
                      
                }
                else {
                            $.ajax({
                                url: '/jfscaseexpense/savecaseexpensedataamount',
                                method: 'POST',
                                data: {
                                    caseExpense: caseExpense,
                                    applicantID: $('#applicantID' + componentName).val(),
                                   

                                },
                                beforeSend: function () {
                                },
                                success: function (data) {
                                    console.log(data);
                                    if (data.Status) {
                                        //$('#applicantID' + componentName).val(data.ID);

                                        SWSuccess.fire();
                                    }
                                }
                                , error: function (err) {
                                    if (err.status == 401) {
                                        window.location.reload();
                                    }
                                }
                            });
                            frm.find('.js--btsave' + componentName).hide();
                            frm.find('.js--cancel').hide();
                      
                }


            }

        });



});
