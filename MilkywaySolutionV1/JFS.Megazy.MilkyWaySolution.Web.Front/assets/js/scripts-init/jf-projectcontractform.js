$(function () {

    var componentName = 'projectcontractform';
    var selectedistrict = $('#SelectedDistrict' + componentName).val();
    if ($('#SelectedDistrict' + componentName).val() != "0") {
        setTimeout(function () {
            console.log(selectedistrict);
            $('#Province' + componentName).trigger('change', [$('#SelectedDistrict' + componentName).val(), $('#SelectedSubDistrict' + componentName).val()]);
        }, 2000);
    }



    $('#dateOfBirth'+componentName).datepicker({
        language: 'th-TH',
        endDate: moment().subtract(1, 'years').format('dd/mm/yyyy'),
    });

    
    $("#smartwizard").on("showStep", function (e, anchorObject, stepNumber, stepDirection) {
        // Enable finish button only on last step
        var frm = $('#frm' + componentName);
        if (stepNumber == 3) {

            var formstep1 = 'projectinfromationcontract';
            var formstep2 = 'projectdetailcontract';
            var formstep3 = 'personcontract';
            // Step1
            $('#location' + componentName).val($('#location' + formstep1).val());
            $('#FromDate' + componentName).val($('#FromDate' + formstep1).val());
            $('#ProxyID' + componentName).val($('#ProxyID' + formstep1).val());
            $('#ProxyTitle' + componentName).val($('#ProxyTitle' + formstep1).val());
            $('#ProxyFirstName' + componentName).val($('#ProxyFirstName' + formstep1).val());
            $('#ProxyLastName' + componentName).val($('#ProxyLastName' + formstep1).val());
            $('#ProxyBook' + componentName).val($('#ProxyBook' + formstep1).val());
            //$('#ProxyDate' + componentName).val($('#ProxyDate' + formstep1).val());    
            $('#ProxyPosition' + componentName).val($('#ProxyPosition' + formstep1).val());    
            if ($('#ProposerTyep' + componentName).val() != "1") {
                $('#PlaceName' + componentName).val($('#PlaceName' + formstep1).val());
                $('#Position' + componentName).val($('#Position' + formstep1).val());
                $('#Authorize' + componentName).val($('#Authorize' + formstep1).val());
                $('#AuthorizeDate' + componentName).val($('#AuthorizeDate' + formstep1).val());
            }            
            $('#Title' + componentName).val($('#Title' + formstep1).val());    
            $('#FirstName' + componentName).val($('#FirstName' + formstep1).val());    
            $('#LastName' + componentName).val($('#LastName' + formstep1).val());    
            $('#dateOfBirth' + componentName).val($('#dateOfBirth' + formstep1).val());    
            $('#cardID' + componentName).val($('#cardID' + formstep1).val());    
            $('#IssuedAt' + componentName).val($('#IssuedAt' + formstep1).val());    


            // Step2
            $('input[name=amount' + formstep2 + ']').map(function (e) {
                //console.log($(this));                
                var amount = parseFloat($(this).val().replace(/,/g, ''));
                $('#amount' + componentName + $(this).data('id')).val($(this).val());
            });



            // Step3
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



    });

    $('#frm' + componentName)
        .off('focus', '.js-postcode')
        .on('focus', '.js-postcode', function (event) {
            $(this).data('preval', $(this).val());
        })
        .off('blur', '.js-postcode')
        .on('blur', '.js-postcode', function (e) {
            if ($.trim($(this).val()).length == 5 &&
                ($(this).val() != $(this).data('preval'))) {
                var el = $(this).closest('.address');
                el.find('.js-province').html('');//  $('#Province').html('');
                el.find('.js-subdistrict').html('');//$('#SubDistrict').html('');
                el.find('.js-district').html('');//$('#District').html('');
                $.ajax({
                    url: '/jfservices/address/getaddresslistbypostcode',
                    method: 'POST',
                    data: {
                        postCode: $(this).val()
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            //จังหวัด
                            el.find('.js-province').html('<option value="' + data.Data.Province.ProvinceID + '">' + data.Data.Province.ProvinceName + '</option>');
                            //ตำบล
                            var temp = Handlebars.compile($('#tmpl-lisdistrict' + componentName).html());
                            el.find('.js-district').html(temp(data.Data.District));
                            //el.find('.js-district').removeAttr('disabled');
                            //อำเภอ
                            var temp = Handlebars.compile($('#tmpl-lissubdistrict' + componentName).html());
                            el.find('.js-subdistrict').html(temp(data.Data.SubDistrict));
                            //el.find('.js-subdistrict').removeAttr('disabled');

                        }
                    },
                    error: function (err) {
                    }
                });
            } //end if
        })
        .off('change selected', '.js-province')
        .on('change selected', '.js-province', function (e, para, para2) {
            console.log("TestchangeProvince");
            if (typeof para !== "undefined") {
                handleChange($(this), setDistrict(para, para2));
            } else {
                handleChange($(this));
            }
        }).off('change', '.js-district')
        .on('change', '.js-district', function (e) {
            console.log("Testdistrict")
            var el = $(this).closest('.address');
            $.ajax({
                url: '/jfservices/address/getsubdistrictlist',
                method: 'POST',
                data: { id: $(this).val() },
                beforeSend: function () { },
                success: function (data) {
                    if (data.Status) {
                        var temp = Handlebars.compile($('#tmpl-lissubdistrict' + componentName).html());
                        el.find('.js-subdistrict').html(temp(data.Data));
                        //el.find('.js-subdistrict').removeAttr('disabled');

                    }
                }
                , error: function (err) {
                    console.log(err);
                }
            });
        }).off('change', '.js-subdistrict')
        .on('change', '.js-subdistrict', function (e) {
            var el = $(this).closest('.address');
            el.find('.js-postcode').val($(this).find(':selected').data('postcode'));
        })
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
            if ($('#ProposerTyep' + componentName).val() != "1") {
                projecproxydetail = {
                    PlaceName: $('#PlaceName' + componentName).val(),
                    Position: $('#Position' + componentName).val(),
                    Authorize: $('#Authorize' + componentName).val(),
                    AuthorizeDate: $('#AuthorizeDate' + componentName).val(),
                }
            }
            var applicantextension = {
                ApplicantID: $('#applicantID' + componentName).val(),
                CardID: $('#cardID' + componentName).val(),
                DateOfBirthstr: $('#dateOfBirth' + componentName).val(),
                Gender: 'N/A',
                IssuedAt: $('#IssuedAt' + componentName).val(),
            }
            var witness = [];
            for (var i = 1; i <=2 ; i++) {
                var witnessdata = {
                    PersonID: $('#Witness'+i+'ID' + componentName).val(),
                    Title: $('#WitnessTitle'+i + componentName).val(),
                    FirstName: $('#WitnessFirstName'+i + componentName).val(),
                    LastName: $('#WitnessLastName'+i + componentName).val(),
                }
                witness.push(witnessdata);
            }
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
            var helper = null;
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
                    formID: $('#formID'+componentName).val(),
                    office: office,
                    applicantextension: applicantextension,
                    projecproxydetail: projecproxydetail,                      
                    personRows: witness,   
                    guatantor: null,
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

    function handleChange(elem, callback) {

        var el = elem.closest('.address');
        $.ajax({
            url: '/jfservices/address/getdistrictlist',
            method: 'POST',
            data: { id: elem.val() },
            beforeSend: function () { },
            success: function (data) {
                if (data.Status) {
                    var temp = Handlebars.compile($('#tmpl-lisdistrict' + componentName).html());
                    el.find('.js-district').html(temp(data.Data));
                    //el.find('.js-district').removeAttr('disabled');
                    el.find('.js-subdistrict').html('').attr('disabled', 'disabled');
                }
            }
            , error: function (err) {
                console.log(err);
            }
        });

        if (typeof callback === "function") {
            callback();
        }
    }
    function setDistrict(para, para2) {
        setTimeout(function () {
            //$('#District' + componentName).removeAttr('disabled');
            $('#District' + componentName).val(para);
            $('#District' + componentName).trigger('change');
            setSubDistrict(para2);
        }, 2000);
    }
    function setSubDistrict(para) {
        setTimeout(function () {
            //$('#SubDistrict' + componentName).removeAttr('disabled');
            $('#SubDistrict' + componentName).val(para);
        }, 2000);
    }


});