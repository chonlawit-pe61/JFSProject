$(function () {
    var componentName = 'guaranteeform';


    $("#smartwizard").on("showStep", function (e, anchorObject, stepNumber, stepDirection) {
        // Enable finish button only on last step
        var frm = $('#frm' + componentName);
        if (stepNumber == 2) {

            
            var formstep1 = 'infromationguarantee';
            var formstep2 = 'personcontract';
            // Step1
            $('#location' + componentName).val($('#location' + formstep1).val());
            $('#FromDate' + componentName).val($('#FromDate' + formstep1).val());
            $('#GuaranteeID' + componentName).val($('#GuaranteeID' + formstep1).val());
            $('#GuaranteeTitle' + componentName).val($('#GuaranteeTitle' + formstep1).val());
            $('#GuaranteeFirstName' + componentName).val($('#GuaranteeFirstName' + formstep1).val());
            $('#GuaranteeLastName' + componentName).val($('#GuaranteeLastName' + formstep1).val());
            $('#GuaranteecardID' + componentName).val($('#GuaranteecardID' + formstep1).val());
            $('#GuaranteeIssuedAt' + componentName).val($('#GuaranteeIssuedAt' + formstep1).val());
            $('#GuaranteeAddressID' + componentName).val($('#GuaranteeAddressID' + formstep1).val());
            $('#GuaranteeHouseNo' + componentName).val($('#GuaranteeHouseNo' + formstep1).val());
            $('#GuaranteeVillageNo' + componentName).val($('#GuaranteeVillageNo' + formstep1).val());
            $('#GuaranteeSoi' + componentName).val($('#GuaranteeSoi' + formstep1).val());
            $('#GuaranteeStreet' + componentName).val($('#GuaranteeStreet' + formstep1).val());
            $('#GuaranteeProvinceID' + componentName).val($('#GuaranteeProvince' + formstep1).val());
            $('#GuaranteeDistrictID' + componentName).val($('#GuaranteeDistrict' + formstep1).val());
            $('#GuaranteeSubDistrictID' + componentName).val($('#GuaranteeSubDistrict' + formstep1).val());
            $('#GuaranteeProvince' + componentName).val($('#GuaranteeProvince' + formstep1).find(':selected').data('name'));
            $('#GuaranteeDistrict' + componentName).val($('#GuaranteeDistrict' + formstep1).find(':selected').data('name'));
            $('#GuaranteeSubDistrict' + componentName).val($('#GuaranteeSubDistrict' + formstep1).find(':selected').data('name'));
            $('#GuaranteePostCode' + componentName).val($('#GuaranteePostCode' + formstep1).val());
            $('#GuaranteeDateOfBirth' + componentName).val($('#GuaranteeDateOfBirth' + formstep1).val());
            $('#GuaranteeNationalityID' + componentName).val($('#GuaranteeNationality' + formstep1).val());
            $('#GuaranteeNationality' + componentName).val($('#GuaranteeNationality' + formstep1).find(':selected').data('name'));
            $('#GuaranteeRaceID' + componentName).val($(':radio[name=GuaranteeRace'+ formstep1 +']:checked').val());
            $('#GuaranteeRace' + componentName).val($(':radio[name=GuaranteeRace' + formstep1 + ']:checked').data('name'));

            // Step 2
            $('#Witness1ID' + componentName).val($('#Witness1ID' + formstep2).val());
            $('#WitnessTitle1' + componentName).val($('#WitnessTitle1' + formstep2).val());
            $('#WitnessFirstName1' + componentName).val($('#WitnessFirstName1' + formstep2).val());
            $('#WitnessLastName1' + componentName).val($('#WitnessLastName1' + formstep2).val());
            $('#Witness2ID' + componentName).val($('#Witness2ID' + formstep2).val());
            $('#WitnessTitle2' + componentName).val($('#WitnessTitle2' + formstep2).val());
            $('#WitnessFirstName2' + componentName).val($('#WitnessFirstName2' + formstep2).val());
            $('#WitnessLastName2' + componentName).val($('#WitnessLastName2' + formstep2).val());
            $('#GuaranteeMaritalID' + componentName).val($('#GuaranteeMaritalID' + formstep2).val());
            $('#GuaranteeMaritalTitle' + componentName).val($('#GuaranteeMaritalTitle' + formstep2).val());
            $('#GuaranteeMaritalFirstName' + componentName).val($('#GuaranteeMaritalFirstName' + formstep2).val());
            $('#GuaranteeMaritalLastName' + componentName).val($('#GuaranteeMaritalLastName' + formstep2).val());
           
        }



    })

    $('#frm' + componentName)
        .off('click', '#bt-genform' + componentName)
        .on('click', '#bt-genform' + componentName, function (e) {
          
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
            var guaranteemarital = {
                PersonID: $('#GuaranteeMaritalID' + componentName).val(),
                Title: $('#GuaranteeMaritalTitle' + componentName).val(),
                FirstName: $('#GuaranteeMaritalFirstName' + componentName).val(),
                LastName: $('#GuaranteeMaritalLastName' + componentName).val(),
            }
            var guaranteeData = null;
            guaranteeData = {
                Guarantee : {
                    PersonID: $('#GuaranteeID' + componentName).val(),
                    Title: $('#GuaranteeTitle' + componentName).val(),
                    FirstName: $('#GuaranteeFirstName' + componentName).val(),
                    LastName: $('#GuaranteeLastName' + componentName).val(),
                    CardID: $('#GuaranteecardID' + componentName).val(),
                    RaceID: $('#GuaranteeRaceID' + componentName).val(),
                    NationalityID: $('#GuaranteeNationalityID' + componentName).val(),
                    DateOfBirthStr: $('#GuaranteeDateOfBirth' + componentName).val(),
                    IssuedAt: $('#GuaranteeIssuedAt' + componentName).val()
                },
                GuaranteeAddress : {
                    AddressID: $('#GuaranteeAddressID' + componentName).val(),
                    HouseNo: $('#GuaranteeHouseNo' + componentName).val(),
                    VillageNo: $('#GuaranteeVillageNo' + componentName).val(),
                    Soi: $('#GuaranteeSoi' + componentName).val(),
                    Street: $('#GuaranteeStreet' + componentName).val(),
                    ProvinceID: $('#GuaranteeProvinceID' + componentName).val(),
                    DisctrictID: $('#GuaranteeDistrictID' + componentName).val(),
                    SubdistrictID: $('#GuaranteeSubDistrictID' + componentName).val(),
                    PostCode: $('#GuaranteePostCode' + componentName).val(),
                }
            }

            console.log("guaranteemarital", guaranteemarital);
            console.log("guaranteeData", guaranteeData);

            $.ajax({
                url: '/jfservices/creatguaranteeform',
                method: 'POST',
                data: {

                    applicantID: $('#applicantID' + componentName).val(),
                    caseID: $('#caseID' + componentName).val(),
                    departmentID: $('#departmentID' + componentName).val(),
                    jfcasetypeID: $('#jfcasetypeID' + componentName).val(),
                    formID: $('#formID' + componentName).val(),
                    formdate: $('#FromDate' + componentName).val(),
                    location: $('#location' + componentName).val(),
                    witness: witness,
                    guaranteemarital: guaranteemarital,
                    guaranteeData: guaranteeData


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