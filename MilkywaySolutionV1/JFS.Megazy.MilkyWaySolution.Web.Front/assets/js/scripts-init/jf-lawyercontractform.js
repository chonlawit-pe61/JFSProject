$(function () {
    var componentName = 'lawyercontractform';
    if ($('#SelectedDistrict' + componentName).val() != "0") {
        setTimeout(function () {
            $('#Province' + componentName).trigger('change', [$('#SelectedDistrict' + componentName).val(), $('#SelectedSubDistrict' + componentName).val()]);
        }, 2000);
    }

    $("#smartwizard").on("showStep", function (e, anchorObject, stepNumber, stepDirection) {
        // Enable finish button only on last step
        var frm = $('#frm' + componentName);
        if (stepNumber == 4) {

            
            var formstep1 = 'lawyerselect';
            var formstep2 = 'lawyerinfomation';
            var formstep3 = 'lawyerdetail';
            var formstep4 = 'presoncontract';
            // Step1
            $('#LawyerID' + componentName).val($('#lawyerID' + formstep1).val());
            $('#LawyerTitle' + componentName).val($('#Title' + formstep1).val());
            $('#LawyerFirstName' + componentName).val($('#FirstName' + formstep1).val());
            $('#LawyerLastName' + componentName).val($('#LastName' + formstep1).val());


            // Step2
            console.log("Test");
            $('#location' + componentName).val($('#DepartmentName' + formstep2).val());
            $('#FromDate' + componentName).val($('#FromDate' + formstep2).val());
            $('#ProxyID' + componentName).val($('#ProxyID' + formstep2).val());
            $('#ProxyTitle' + componentName).val($('#ProxyTitle' + formstep2).val());
            $('#ProxyFirstName' + componentName).val($('#ProxyFirstName' + formstep2).val());
            $('#ProxyLastName' + componentName).val($('#ProxyLastName' + formstep2).val());
            $('#ProxyPosition' + componentName).val($('#ProxyPosition' + formstep2).val());
            $('#ProxyBook' + componentName).val($('#ProxyBook' + formstep2).val());
            //$('#ProxyDate' + componentName).val($('#ProxyDate' + formstep2).val());
            //$('#IssuedAt' + componentName).val($('#IssuedAt' + formstep2).val());

            //Step3       
            $('input[name=amount' + formstep3 + ']').map(function (e) {
                console.log($(this));
                var amount = parseFloat($(this).val().replace(/,/g, ''));
                $('#amount' + componentName + $(this).data('id')).val($(this).val());
            });

            //Step4
            $('#HelperTitle' + componentName).val($('#ProxyTitle' + formstep2).val());
            $('#HelperFirstName' + componentName).val($('#ProxyFirstName' + formstep2).val());
            $('#HelperLastName' + componentName).val($('#ProxyLastName' + formstep2).val());
            $('#Witness1ID' + componentName).val($('#Witness1ID' + formstep4).val());
            $('#WitnessTitle1' + componentName).val($('#WitnessTitle1' + formstep4).val());
            $('#WitnessFirstName1' + componentName).val($('#WitnessFirstName1' + formstep4).val());
            $('#WitnessLastName1' + componentName).val($('#WitnessLastName1' + formstep4).val());
            $('#Witness2ID' + componentName).val($('#Witness2ID' + formstep4).val());
            $('#WitnessTitle2' + componentName).val($('#WitnessTitle2' + formstep4).val());
            $('#WitnessFirstName2' + componentName).val($('#WitnessFirstName2' + formstep4).val());
            $('#WitnessLastName2' + componentName).val($('#WitnessLastName2' + formstep4).val());

        }



    })

    $('#frm' + componentName)
        .off('click', '#bt-genform' + componentName)
        .on('click', '#bt-genform' + componentName, function (e) {
            
            var FormDate = $('#FromDate' + componentName).val();
            var projecproxydetail = null;
            var applicantextension = {
                ApplicantID: $('#applicantID' + componentName).val(),
                IssuedAt: $('#IssuedAt' + componentName).val(),
            }
            var persondetail = null;
           
            var witness = [];
            for (var i = 1; i <= 2; i++) {
                var witnessdata = {
                    PersonID: $('#Witness' + i + 'ID' + componentName).val(),
                    Title: $('#WitnessTitle' + i + componentName).val(),
                    FirstName: $('#WitnessFirstName' + i + componentName).val(),
                    LastName: $('#WitnessLastName' + i + componentName).val(),
                }
                witness.push(witnessdata);
            }
            console.log("witness", witness);
            var wage = [];
            $('input[name=amount' + componentName + ']').map(function (e) {
                //console.log($(this));                
                var amount = parseFloat($(this).val().replace(/,/g, ''));
                var wagedata = {
                    WangeID: $(this).data('id'),
                    Amount: $(this).val(),
                }
                wage.push(wagedata);
            });
            helper = {
                PersonID: $('#ProxyID' + componentName).val(),
                Title: $('#ProxyTitle' + componentName).val(),
                FirstName: $('#ProxyFirstName' + componentName).val(),
                LastName: $('#ProxyLastName' + componentName).val(),
                Position: $('#ProxyPosition' + componentName).val(),

            }

            console.log($('#applicantID' + componentName).val());
            console.log($('#caseID' + componentName).val())
            console.log($('#departmentID' + componentName).val())
            console.log($('#jfcasetypeID' + componentName).val())
            console.log($('#formID' + componentName).val())
            console.log($('#LawyerID' + componentName).val())
            console.log(helper)
            console.log(wage)
         

            $.ajax({
                url: '/jfservices/creatcontractlawyer',
                method: 'POST',
                data: {

                    applicantID: $('#applicantID' + componentName).val(),
                    caseID: $('#caseID' + componentName).val(),
                    departmentID: $('#departmentID' + componentName).val(),
                    jfcasetypeID: $('#jfcasetypeID' + componentName).val(),
                    formID: $('#formID' + componentName).val(),
                    lawyerID: $('#LawyerID' + componentName).val(),
                    wage: wage,
                    helper: helper,
                    witness: witness,
                    formdate: FormDate,
                    location: $('#location' + componentName).val(),
                    PowerOfAttorney: $('#ProxyBook' + componentName).val(),
                },
                beforeSend: function () {

                    $('#btn-genform').attr("disabled", true).html('สร้างเอกสาร...');
                    SWLoading.fire({
                    });

                },
                success: function (data) {

                    $('#btn-genform').attr("disabled", false).html('สัญญาการได้รับเงินช่วยเหลือ');


                    console.log(data);

                    if (data.Status) {
                        SWSuccess.fire({
                            title: 'สร้างสัญญาการได้รับเงินช่วยเหลือ',
                            onClose: () => {
                                //$('#btn-genform').attr("disabled", false).html('สัญญาการได้รับเงินช่วยเหลือ');
                                window.location.href = "/applicant/details/?id=" + $('#applicantID' + componentName).val() + '&caseID=' + $('#caseID' + componentName).val() + '&depid=' + $('#departmentID' + componentName).val();
                            }
                        });


                    }
                    else {

                        SWError.fire({
                            title: 'ไม่สามารถสร้างสร้างสัญญาการได้รับเงินช่วยเหลือ',
                            onClose: () => {
                                $('#btn-genform').attr("disabled", false).html('สัญญาการได้รับเงินช่วยเหลือ');
                            }
                        });
                    }

                }, error: function (err) {
                    if (err.status == 401) {
                        window.location.reload();
                    }
                    if (err.status) {
                        SWError.fire({
                            title: 'ไม่สามารถสร้างสร้างสัญญาการได้รับเงินช่วยเหลือ',
                            onClose: () => {
                                $('#btn-genform').attr("disabled", false).html('สัญญาการได้รับเงินช่วยเหลือ');
                            }
                        });
                    }
                }
            });



        });



});