$(function () {
    var componentName = 'contractform';
    if ($('#SelectedDistrict' + componentName).val() != "0") {
        setTimeout(function () {
            $('#Province' + componentName).trigger('change', [$('#SelectedDistrict' + componentName).val(), $('#SelectedSubDistrict' + componentName).val()]);
        }, 2000);
    }
    
    $("#smartwizard").on("showStep", function (e, anchorObject, stepNumber, stepDirection) {
        // Enable finish button only on last step
        var frm = $('#frm' + componentName);
        if (stepNumber == 3) {

            // Step1
            var formstep1 = 'infromationcontract';
            var formstep2 = 'persondetailcontract';
            var formstep3 = 'personcontract';
            console.log("Test");
            $('#location' + componentName).val($('#location' + formstep1).val());
            $('#FromDate' + componentName).val($('#FromDate' + formstep1).val());
            $('#ProxyID' + componentName).val($('#ProxyID' + formstep1).val());
            $('#ProxyTitle' + componentName).val($('#ProxyTitle' + formstep1).val());
            $('#ProxyFirstName' + componentName).val($('#ProxyFirstName' + formstep1).val());
            $('#ProxyLastName' + componentName).val($('#ProxyLastName' + formstep1).val());
            $('#ProxyPosition' + componentName).val($('#ProxyPosition' + formstep1).val());    
            $('#ProxyBook' + componentName).val($('#ProxyBook' + formstep1).val());
            //$('#ProxyDate' + componentName).val($('#ProxyDate' + formstep1).val());
            $('#IssuedAt' + componentName).val($('#IssuedAt' + formstep1).val());

            if ($('#jfcasetypeID').val() == 2) {
                $.ajax({
                    url: '/jfscaseexpense/getcurrentcasestatus',
                    method: 'POST',
                    data: {
                        applicantID: $('#applicantID').val(),
                        caseID: $('#caseID').val()
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            console.log(data.Data);
                            if (data.Data != null) {
                                $('#currentstatuscaseID' + componentName).val(data.Data.CurrentStatusCaseID);
                                if (data.Data.ApplicantStatus == "PL") {
                                    $('#ApplicantStatus' + componentName).val("โจทก์");
                                    $('#LitigantStatus' + componentName).val("จำเลย");
                                }
                                else {
                                    $('#ApplicantStatus' + componentName).val("จำเลย");
                                    $('#LitigantStatus' + componentName).val("โจทก์");
                                }

                                $('#court' + componentName).val(data.Data.CourID).trigger('change');
                                $('#rednumber' + componentName).val(data.Data.CaseRedNo);
                                $('#blacknumber' + componentName).val(data.Data.CaseBlackNo);
                                $('#charge' + componentName).val(data.Data.Charge);
                                $('#LitigantName' + componentName).val(data.Data.LitigantName);
                                $('#LitigantTitle' + componentName).val(data.Data.LitigantTitle);

                            }
                        }
                        frm.find('.js--btsave' + componentName).hide();
                        frm.find('.js--cancel').hide();
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });
            }


            //Step2        
            $('input[name=amount' + formstep2 + ']').map(function (e) {
                console.log($(this));                
                var amount = parseFloat($(this).val().replace(/,/g, ''));
                $('#amount' + componentName + $(this).data('id')).val($(this).val());
            });




            if ($('#jfcasetypeID').val() == 2) {

                   
                $('#GID' + componentName).val($('#ShelterID' + formstep2).val());
                $('#GTitel' + componentName).val($('#ShelterTitle' + formstep2).val());
                $('#GFirstName' + componentName).val($('#ShelterFirstName' + formstep2).val());
                $('#GLastName' + componentName).val($('#ShelterLastName' + formstep2).val());
                $('#GRelate' + componentName).val($('#ShelterRelated' + formstep2).val());
                $('#GHouseNo' + componentName).val($('#ShelterHouseNo' + formstep2).val());
                $('#GVillageNo' + componentName).val($('#ShelterVillageNo' + formstep2).val());
                $('#GSoi' + componentName).val($('#ShelterShelterSoi' + formstep2).val());
                $('#GStreet' + componentName).val($('#ShelterStreet' + formstep2).val());
                $('#GProvince' + componentName).val($('#ShelterProvince' + formstep2).find(':selected').data('name'));
                $('#GDistrict' + componentName).val($('#ShelterDistrict' + formstep2).find(':selected').data('name'));
                $('#GSubDistrict' + componentName).val($('#ShelterSubDistrict' + formstep2).find(':selected').data('name'));
                $('#GPostCode' + componentName).val($('#ShelterPostCode' + formstep2).val());
                $('#ProvinceID' + componentName).val($('#ShelterProvince' + formstep2).val());
                $('#DistrictID' + componentName).val($('#ShelterDistrict' + formstep2).val());
                $('#SubdistrictID' + componentName).val($('#ShelterSubDistrict' + formstep2).val());
                $('#GarrnateeID' + componentName).val($('#GarrnateeID' + formstep2).val());
                $('#GarrnateeTitle' + componentName).val($('#GarrnateeTitle' + formstep2).val());
                $('#GarrnateeFirstName' + componentName).val($('#GarrnateeFirstName' + formstep2).val());
                $('#GarrnateeLastName' + componentName).val($('#GarrnateeLastName' + formstep2).val());

            }

            

            //Step3
            $('#HelperTitle' + componentName).val($('#ProxyTitle' + formstep1).val());
            $('#HelperFirstName' + componentName).val($('#ProxyFirstName' + formstep1).val());
            $('#HelperLastName' + componentName).val($('#ProxyLastName' + formstep1).val());
            $('#Witness1ID' + componentName).val($('#Witness1ID' + formstep3).val());
            $('#WitnessTitle1' + componentName).val($('#WitnessTitle1' + formstep3).val());
            $('#WitnessFirstName1' + componentName).val($('#WitnessFirstName1' + formstep3).val());
            $('#WitnessLastName1' + componentName).val($('#WitnessLastName1' + formstep3).val());
            $('#Witness2ID' + componentName).val($('#Witness2ID' + formstep3).val());
            $('#WitnessTitle2' + componentName).val($('#WitnessTitle2' + formstep3).val());
            $('#WitnessFirstName2' + componentName).val($('#WitnessFirstName2' + formstep3).val());
            $('#WitnessLastName2' + componentName).val($('#WitnessLastName2' + formstep3).val());

        }



    })

    $('#frm' + componentName)
        .off('click', '#bt-genform' + componentName)
        .on('click', '#bt-genform' + componentName, function (e) {
            var office = {
                Title: $('#ProxyTitle' + componentName).val(),
                Name: $('#ProxyFirstName' + componentName).val() + "  " + $('#ProxyLastName' + componentName).val(),
                Book: $('#ProxyBook' + componentName).val(),
                Date: $('#ProxyDate' + componentName).val(),
                Position: $('#ProxyPosition' + componentName).val(),
                Location: $('#location' + componentName).val(),
                FormDate: $('#FromDate' + componentName).val(),
            }

            var projecproxydetail = null;
            var applicantextension = {
                ApplicantID: $('#applicantID' + componentName).val(),               
                IssuedAt: $('#IssuedAt' + componentName).val(),
            }
            var persondetail = null;
            if ($('#jfcasetypeID' + componentName).val() == 2) {
                var shelteraddress = null;
                var shelterdata = null;
                var garrantee = null;
                shelterdata = {
                    PersonID: $('#GID' + componentName).val(),
                    Title: $('#GTitel' + componentName).val(),
                    FirstName: $('#GFirstName' + componentName).val(),
                    LastName: $('#GLastName' + componentName).val(),
                    Relate: $('#GRelate' + componentName).val(),
                    GenderCode: 'N/A',
                }
                shelteraddress = {
                    AddressID: $('#GAddressID' + componentName).val(),
                    HouseNo: $('#GHouseNo' + componentName).val(),
                    VillageNo: $('#GVillageNo' + componentName).val(),
                    Soi: $('#GSoi' + componentName).val(),
                    Street: $('#GStreet' + componentName).val(),
                    ProvinceID: $('#ProvinceID' + componentName).val(),
                    DisctrictID: $('#DistrictID' + componentName).val(),
                    SubdistrictID: $('#SubdistrictID' + componentName).val(),
                    PostCode: $('#GPostCode' + componentName).val(),
                }
                garrantee = {
                    PersonID: $('#GarrnateeID' + componentName).val(),
                    Title: $('#GarrnateeTitle' + componentName).val(),
                    FirstName: $('#GarrnateeFirstName' + componentName).val(),
                    LastName: $('#GarrnateeLastName' + componentName).val(),
                }
                persondetail = {
                    Garrantee: garrantee,
                    Shelter: shelterdata,
                    ShelterAddress: shelteraddress,
                }
            }
            

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



            $.ajax({
                url: '/jfservices/creatcontractfrommoney',
                method: 'POST',
                data: {

                    applicantID: $('#applicantID' + componentName).val(),
                    caseID: $('#caseID' + componentName).val(),
                    departmentID: $('#departmentID' + componentName).val(),
                    jfcasetypeID: $('#jfcasetypeID' + componentName).val(),
                    formID: $('#formID' + componentName).val(),
                    office: office,
                    applicantextension: applicantextension,
                    projecproxydetail: projecproxydetail,
                    personRows: witness,
                    guatantor: persondetail,
                    wage: wage,
                    helper: helper,

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