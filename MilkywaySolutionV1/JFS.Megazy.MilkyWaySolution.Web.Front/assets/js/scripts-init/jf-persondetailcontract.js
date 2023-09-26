
$(function () {

    var componentName = 'persondetailcontract';
    //var selectedistrict = $('#SelectedDistrict' + componentName).val();
    if ($('#SelectedDistrict' + componentName).val() != "0") {
        setTimeout(function () {
          
            $('#ShelterProvince' + componentName).trigger('change', [$('#SelectedDistrict' + componentName).val(), $('#SelectedSubDistrict' + componentName).val()]);
        }, 2000);
    }
    $("#smartwizard").on("leaveStep", function (e, anchorObject, stepNumber, stepDirection) {

        var formID = $("#form-step-" + stepNumber).find('form').attr('id');
        var frm = $('#' + formID);
        if (stepDirection === 'forward') {
            console.log("SumAmount");
            console.log(formID);
            console.log(componentName);
            var status = frm.validationEngine('validate');
            var approved = parseFloat($('#Approved' + componentName).val());
            var amountsum = parseFloat($('#amountsum' + componentName).val());
            if (approved != amountsum && formID === ('frm' + componentName)) {

                SWMoney.fire({
                    onClose: () => {

                    }
                });
                return false;

            }
            else {

                return true;
            }
        }


    });

    $("#smartwizard").on("showStep", function (e, anchorObject, stepNumber, stepDirection) {
        
        $.ajax({
            url: '/jfservices/getwage',
            method: 'POST',
            data: {

                applicantID: $('#applicantID' + componentName).val(),
                caseID: $('#caseID' + componentName).val(),
                formID: $('#formID' + componentName).val(),

            },
            beforeSend: function () {
            },
            success: function (data) {

                console.log(data);

                if (data.Status) {

                    $.each(data.Data, function (key, value) {
                        $('#amount' + componentName + value.WangeID).val(value.Amount).trigger('change');
                    });
                }


            }, error: function (err) {
                if (err.status == 401) {
                    window.location.reload();
                }

            }
        });


    });


    $(document).ready(function () {


        $('#frm' + componentName)
            .off('keyup change', '.js-text')
            .on('keyup change', '.js-text', function (e) {
                var frm = $(this).closest('form');
                frm.find('.js--btsave' + componentName).show();
                frm.find('.js--cancel').show();
            })
            .off('select2:open', '.multiselect-dropdown-plaintext')
            .on('select2:open', '.multiselect-dropdown-plaintext', function (e) {
                $('.js--btsave' + componentName).show();
                $('.js--cancel').show();
            })
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
                console.log(para);
                if (typeof para !== "undefined") {
                    console.log("test");
                    handleChange($(this), setDistrict(para, para2));
                } else {
                    console.log("Nodata");
                    console.log($(this));
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
                            el.find('.js-subdistrict').removeAttr('disabled');

                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });
            })
            .off('change', '.js-subdistrict')
            .on('change', '.js-subdistrict', function (e) {
                var el = $(this).closest('.address');
                el.find('.js-postcode').val($(this).find(':selected').data('postcode'));
            })
            .off('click', '#btcopyproxyaddress')
            .on('click', '#btcopyproxyaddress', function (e) {
                $.ajax({
                    url: '/jfservices/getproxydata',
                    method: 'POST',
                    data: { applicantID: $('#applicantID').val() },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {

                            $('#ShelterTitle' + componentName).val(data.Data.ProxyDataDetail.Title);
                            if ($('#ShelterTitle' + componentName).val() != data.Data.ProxyDataDetail.Title) {
                                console.log($('#ShelterTitle' + componentName).val());
                                var datatitle = data.Data.ProxyDataDetail.Title;
                                var o = $("<option/>", { value: datatitle, text: datatitle });
                                $('#ShelterTitle' + componentName).append(o);
                                $('#ShelterTitle' + componentName).val(datatitle).trigger('change').attr('disabled', 'disabled');

                            }
                            else {
                                $('#ShelterTitle' + componentName).val(data.Data.ProxyDataDetail.Title).trigger('change').attr('disabled', 'disabled');
                            }

                            $('#ShelterFirstName' + componentName).val(data.Data.ProxyDataDetail.FirstName).attr('disabled', 'disabled');
                            $('#ShelterLastName' + componentName).val(data.Data.ProxyDataDetail.LastName).attr('disabled', 'disabled');
                            $('#ShelterRelated' + componentName).val(data.Data.ProxyDataDetail.RelatedAs).attr('disabled', 'disabled');
                            $('#ShelterAddressID' + componentName).val(data.Data.Address.AddressID).attr('disabled', 'disabled');
                            $('#ShelterHouseNo' + componentName).val(data.Data.Address.HouseNo).attr('disabled', 'disabled');
                            $('#ShelterVillageNo' + componentName).val(data.Data.Address.VillageNo).attr('disabled', 'disabled');
                            $('#ShelterSoi' + componentName).val(data.Data.Address.Soi).attr('disabled', 'disabled');
                            $('#ShelterStreet' + componentName).val(data.Data.Address.Street).attr('disabled', 'disabled');
                            $('#ShelterProvince' + componentName).val(data.Data.Address.ProvinceID).attr('disabled', 'disabled');
                            //$('#ShelterProvince' + componentName).next('.select2').find('.select2-selection__rendered').html($('#ShelterProvince' + componentName + ' option:selected').text());
                            if (data.Data.Address.DistrictID != "") {
                                // console.log(data.Data.ApplicantFamilySpouseData.AddressResponse.DistrictID, data.Data.ApplicantFamilySpouseData.AddressResponse.SubdistrictID);
                                $('#ShelterProvince' + componentName).trigger('change', [data.Data.Address.DisctrictID, data.Data.Address.SubdistrictID]);
                            }
                            //$('#District' + componentName).val(data.Data.ApplicantFamilySpouseData.AddressResponse.District);
                            //$('#SubDistrict' + componentName).val(data.Data.ApplicantFamilySpouseData.AddressResponse.SubDistrict);
                            $('#ShelterPostCode' + componentName).val(data.Data.Address.PostCode).attr('disabled', 'disabled');
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });

            })
            .off('change', '.js-amount' + componentName)
            .on('change', '.js-amount' + componentName, function (e) {
                var frm = $(this).closest('form');

                var totalamount = 0;
                $('input[name=amount' + componentName + ']').map(function (e) {
                    //console.log($(this));                
                    var amount = parseFloat($(this).val().replace(/,/g, ''));
                    if (amount != NaN && amount > 0) {
                        totalamount = parseFloat(totalamount) + parseFloat(amount);
                    }


                });

                //console.log("amount = ",amount);
                console.log("totalamount = ", totalamount);

                $('#amountsum' + componentName).val(Common.formatNumber(totalamount));

            });






    });

    function handleChange(elem, callback) {

        var el = elem.closest('.address');
        console.log("elem Value",elem.val());
        $.ajax({
            url: '/jfservices/address/getdistrictlist',
            method: 'POST',
            data: { id: elem.val() },
            beforeSend: function () { },
            success: function (data) {
                if (data.Status) {
                    console.log(data.Data);
                    var temp = Handlebars.compile($('#tmpl-lisdistrict' + componentName).html());
                    el.find('.js-district').html(temp(data.Data));
                    el.find('.js-district').removeAttr('disabled');
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
            $('#ShelterDistrict' + componentName).removeAttr('disabled');
            $('#ShelterDistrict' + componentName).val(para);
            $('#ShelterDistrict' + componentName).trigger('change');
            setSubDistrict(para2);
        }, 2000);
    }
    function setSubDistrict(para) {
        setTimeout(function () {
            $('#ShelterSubDistrict' + componentName).removeAttr('disabled');
            $('#ShelterSubDistrict' + componentName).val(para);
        }, 2000);
    }
});