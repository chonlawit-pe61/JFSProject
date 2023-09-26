// Begin การไกล่เกลี่ย
$(function () {
    var componentName = 'casestore';


    function getdata() {

        if ($('#applicantID' + componentName).val() != 0 && $('#state' + componentName).val() == 0) {
            //Load data
            //$('#isloadData-' + componentName).val(1);
            var frm = $('#frm' + componentName);
            //console.log(frm);
            $.ajax({
                url: '/jfscaseexpense/getcasestore',
                method: 'POST',
                data: {
                    caseID: $('#caseID' + componentName).val(),
                    applicantID: $('#applicantID' + componentName).val(),

                },
                beforeSend: function () { },
                success: function (data) {


                    console.log(data);
                    if (data.Status) {
                        var CaseRepositoryRow = data.Data.CaseRepositoryRow;
                        //var CaseCeaseRow = data.Data.CaseCeaseRow;
                        //if (CaseCeaseRow != null) {
                        //    $('#state' + componentName).val(1)
                        //    $('#cause' + componentName).val(CaseCeaseRow.CausesOfCloseID);
                        //    $('#CeaseDate' + componentName).val(Common.JSONDate(CaseCeaseRow.CeaseDate));
                        //    $('#CausesOther' + componentName).val(CaseCeaseRow.CausesOther);

                        //}
                        console.log(CaseRepositoryRow);
                        if (CaseRepositoryRow != null) {
                            $('#state' + componentName).val(1)
                            if (CaseRepositoryRow.Status) {
                                $('#savedoc' + componentName).iCheck('check');
                            }
                            else {
                                $('#notsavedoc' + componentName).iCheck('check');
                            }
                            //$('#RepositoryDate' + componentName).val(Common.JSONDate(CaseRepositoryRow.RepositoryDate));
                            $('#Location' + componentName).val(CaseRepositoryRow.Location);
                            $('#note' + componentName).val(CaseRepositoryRow.Note);
                        }


                        frm.find('.js--btsave' + componentName).hide();
                        frm.find('.js--cancel' + componentName).hide();
                    }




                }
                , error: function (err) {
                    console.log(err);
                }
            });

        } else { console.log('default') }

    };

    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        var applicant = $('#applicantID' + componentName).val();
        //console.log(reason);
        if (applicant != 0 && $('#state' + componentName).val() == 0) {

            //Load data
            $.ajax({
                url: '/jfscaseexpense/getcasestore',
                method: 'POST',
                data: {
                    caseID: $('#caseID' + componentName).val(),
                    applicantID: $('#applicantID' + componentName).val(),

                },
                beforeSend: function () { },
                success: function (data) {


                    console.log(data);
                    if (data.Status) {
                        var CaseRepositoryRow = data.Data.CaseRepositoryRow;
                        //var CaseCeaseRow = data.Data.CaseCeaseRow;
                        //if (CaseCeaseRow != null) {
                        //    $('#state' + componentName).val(1)
                        //    $('#cause' + componentName).val(CaseCeaseRow.CausesOfCloseID);
                        //    $('#CeaseDate' + componentName).val(Common.JSONDate(CaseCeaseRow.CeaseDate));
                        //    $('#CausesOther' + componentName).val(CaseCeaseRow.CausesOther);

                        //}
                        console.log(CaseRepositoryRow);
                        if (CaseRepositoryRow != null) {
                            $('#state' + componentName).val(1)
                            if (CaseRepositoryRow.Status) {
                                $('#savedoc' + componentName).iCheck('check');
                            }
                            else {
                                $('#notsavedoc' + componentName).iCheck('check');
                            }
                            //$('#RepositoryDate' + componentName).val(Common.JSONDate(CaseRepositoryRow.RepositoryDate));
                            $('#Location' + componentName).val(CaseRepositoryRow.Location);
                            $('#note' + componentName).val(CaseRepositoryRow.Note);
                        }

                        var frm = $('frm'+componentName);
                        frm.find('.js--btsave' + componentName).hide();
                        frm.find('.js--cancel').hide();
                    }




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
    
        .off('keyup change ifChanged', '.js-text')
        .on('keyup change ifChanged', '.js-text', function (e) {
            var frm = $('#frm' + componentName);
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel' + componentName).show();
        })
        .off('click', '.js--cancel' + componentName)
        .on('click', '.js--cancel' + componentName, function (e) {
            var frm = $('#frm' + componentName);
            frm.find('.js--btsave' + componentName).hide();
            frm.find('.js--cancel' + componentName).hide();
        })

        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {


            // จัดเก็บเอกสาร
            var savedoc = null;
            var saveDocCheck = $('input[name="savedoc' + componentName + '"' + ']').is(':checked');
            if (saveDocCheck) {
                statusdoc = parseInt($('input[name="savedoc' + componentName + '"' + ']:checked').val());
                savedoc = statusdoc
            }
            var CaseRepository = null;
            CaseRepository = {
                CaseID: $('#caseID' + componentName).val(),
                ApplicantID: $('#applicantID' + componentName).val(),
                //RepositoryDateStr: $('#RepositoryDate' + componentName).datepicker({ dateFormat: 'dd/MM/yyyy' }).val(),
                Status: savedoc,
                Location: $('#Location' + componentName).val(),
                Note: $('#note' + componentName).val(),
            }

            console.log(CaseRepository);



            $.ajax({
                url: '/jfscaseexpense/savecasestore',
                method: 'POST',
                data: {

                    reqrepo: CaseRepository,

                },
                beforeSend: function () { },
                success: function (data) {

                    if (data.Status) {
                        //$('#applicantID' + componentName).val(data.ID);
                        var frm = $('#frm' + componentName);
                        frm.find('.js--btsave' + componentName).hide();
                        frm.find('.js--cancel' + componentName).hide();
                        frm.find('.header-icon').hide();
                        SWSuccess.fire();
                    } else {

                        SWError.fire();
                    }

                }
                , error: function (err) {
                    console.log(err);
                }
            });





        })
        .off('ifChecked', ':radio[name=savedoc' + componentName + ']')
        .on('ifChecked', ':radio[name=savedoc' + componentName + ']', function (e) {
            var frm = $('#frm' + componentName);
            if ($(this).val() == 1) {
                frm.find('.RepositoryDate').show();
                frm.find('.Location').show();
                frm.find('.note').show();
            }
            else {
                frm.find('.RepositoryDate').hide();
                frm.find('.Location').hide();
                frm.find('.note').hide();
            }

        });






});
