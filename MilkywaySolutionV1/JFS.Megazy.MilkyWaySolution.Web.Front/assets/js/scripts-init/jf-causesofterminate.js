// Begin ข้อมูลการยุติ
$(function () {
    var componentName = 'causesofterminate';

   

    function getdata() {
        if ($('#applicantID' + componentName).val() != 0 && $('#state' + componentName).val() == 0) {
            //Load data
            //$('#isloadData-' + componentName).val(1);
            var frm = $('#frm' + componentName);
            $.ajax({
                url: '/jfscaseexpense/getcausesofterminate',
                method: 'POST',
                data: {
                    caseID: $('#caseID' + componentName).val(),
                    applicantID: $('#applicantID' + componentName).val(),
                    depID: $('#departmentID' + componentName).val(),
                },
                beforeSend: function () { },
                success: function (data) {
                    if (data.Status) {
                        var CaseTerminateRow = data.Data.CaseTerminateRow;
                        if (CaseTerminateRow != null) {
                            $('#state' + componentName).val(1)
                            $('#terminateID' + componentName).val(CaseTerminateRow.TerminateID);
                            $('#CausesOther' + componentName).val(CaseTerminateRow.CausesOther);

                        }
                        frm.find('.js--btsave' + componentName).show();
                        frm.find('.js--cancel' + componentName).show();
                    }

                }
                , error: function (err) {
                    console.log(err);
                }
            });

        } else { console.log('default') }

    };

    $('#modalTerminate').on('shown.bs.modal', function () {
        getdata();

    });


    
    $('#frm' + componentName)
        .off('keyup change ifChecked', '.js-text')
        .on('keyup change ifChecked', '.js-text', function (e) {
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
            // ยุติ
            var terminateID = $('#terminateID' + componentName + ' option:selected').val();
            var casecease = {
                CaseID: $('#caseID' + componentName).val(),
                ApplicantID: $('#applicantID' + componentName).val(),
                DepartmentID: $('#departmentID' + componentName).val(),
                TerminateID: terminateID,
                CausesOther: $('#CausesOther' + componentName).val(),
            }
            $.ajax({
                url: '/jfscaseexpense/savecausesofterminate',
                method: 'POST',
                data: {
                    reqcease: casecease,
                },
                beforeSend: function () { },
                success: function (data) {
                    if (data.Status) {
                        //$('#applicantID' + componentName).val(data.ID);
                        var frm = $('#frm' + componentName);
                        frm.find('.js--btsave' + componentName).hide();
                        frm.find('.js--cancel' + componentName).hide();
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
        




});
