$(function () {

    var componentName = 'marital';
    $(document).ready(function () {
      
        $('#card-' + componentName).on('expanded.lte.widget', function (e) {
            Common.swcithTabIcon(this);
            $body = $(this).find('.card-body div').first();
            //MaritalStatusID
            var frm = $('#frm' + componentName);
            var maritalStatusID = $(':radio[name=rdomarital]').is(':checked') ? $(':radio[name=rdomarital]:checked').val() : 0
            if (maritalStatusID > 1) {
                $('.wrap-toggledisplay').slideDown();
            }
            if (!$(':radio[name=rdomarital]').is(':checked') && $('#applicantID' + componentName).val() != 0) {
                //Load data
                $.ajax({
                    url: '/jfservices/applicant/getmarital',
                    method: 'POST',
                    data: { applicantID: $('#applicantID' + componentName).val() },
                    beforeSend: function () { },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            $(':radio[name=rdomarital][value=' + data.Data.ApplicantMaritalData.MaritalStatusID + ']').iCheck('check');
                            if (data.Data.ApplicantMaritalData.MaritalStatusID > 1) {
                                $('#partnerName' + componentName).val(data.Data.ApplicantFamilySpouseData.Name);
                                $('#age' + componentName).val(data.Data.ApplicantFamilySpouseData.Age);                               
                                $('#TelephonNumber' + componentName).val(data.Data.ApplicantFamilySpouseData.TelephoneNo);
                                $('#Career' + componentName).val(data.Data.ApplicantFamilySpouseData.Career);
                                $('#Income' + componentName).val(data.Data.ApplicantIncomeData.Income);
                                $('#IncomeUnit' + componentName).val(data.Data.ApplicantIncomeData.IncomeUnit);

                                $('#HouseNo' + componentName).val(data.Data.ApplicantFamilySpouseData.AddressResponse.HouseNo);
                                $('#VillageNo' + componentName).val(data.Data.ApplicantFamilySpouseData.AddressResponse.VillageNo);
                                $('#Soi' + componentName).val(data.Data.ApplicantFamilySpouseData.AddressResponse.Soi);
                                $('#Street' + componentName).val(data.Data.ApplicantFamilySpouseData.AddressResponse.Street);
                                $('#Province' + componentName).val(data.Data.ApplicantFamilySpouseData.AddressResponse.ProvinceID);
                                $('#Province' + componentName).next('.select2').find('.select2-selection__rendered').html($('#Province' + componentName+' option:selected').text());
                                if (data.Data.ApplicantFamilySpouseData.AddressResponse.DistrictID != "") {
                                   // console.log(data.Data.ApplicantFamilySpouseData.AddressResponse.DistrictID, data.Data.ApplicantFamilySpouseData.AddressResponse.SubdistrictID);
                                    $('#Province' + componentName).trigger('change', [data.Data.ApplicantFamilySpouseData.AddressResponse.DisctrictID, data.Data.ApplicantFamilySpouseData.AddressResponse.SubdistrictID]);
                                }
                                //$('#District' + componentName).val(data.Data.ApplicantFamilySpouseData.AddressResponse.District);
                                //$('#SubDistrict' + componentName).val(data.Data.ApplicantFamilySpouseData.AddressResponse.SubDistrict);
                                $('#PostCode' + componentName).val(data.Data.ApplicantFamilySpouseData.AddressResponse.PostCode);
                                setTimeout(function () { $('#additionalMaritalStatus').val(data.Data.ApplicantMaritalData.AdditionalMaritalStatus);
                                }, 1000);

                                $('#child' + componentName).val(data.Data.ApplicantMaritalData.NumberOfChild);

                                var temp = Handlebars.compile($('#tmpl-listedit' + componentName).html());
                                $('.wrap-child' + componentName).html(temp(data.Data.ApplicantFamilyChildData));

                                

                            }
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

        //$(':radio[name=rdomarital]').click(function () {
        //    console.log($(':radio[name=rdomarital]:checked').val());
        //    $.ajax({
        //        url: '/jfservices/applicant/getmaritalchild',
        //        method: 'POST',
        //        data: { parentID: $(this).val() },
        //        beforeSend: function () { },
        //        success: function (data) {
        //            console.log(data);
        //            if (data.Status) {
        //                $('.wrap-toggledisplay').show();
        //                $('#maritalChild').html('<option value="" disabled selected>เลือก</option>');
        //                $.each(data.Data, function (i, item) {
        //                    $('#maritalChild').append('<option value="' + item.MaritalStatusID + '">' + item.MaritalStatusName + '</option>');
        //                });
        //            } else {
        //                $('.wrap-toggledisplay').hide();
        //            }
        //        }
        //        , error: function (err) {
        //            console.log(err);
        //        }
        //    });
        //});
        $('#frm' + componentName)
            .off('keyup change', '.js-text')
            .on('keyup change', '.js-text', function (e) {
                var frm = $(this).closest('form');
                frm.find('.js--btsave' + componentName).show();
                frm.find('.js--cancel').show();
            })
            .off('change', '#child' + componentName)
            .on('change', '#child' + componentName, function (e) {
                //var frm = $(this).closest('form');
                //frm.find('.js--btsavemarital').show();
                //frm.find('.js--cancel').show();
                if ($(this).val() != 0) {
                    var childNo = $(this).val();
                    if (childNo > 2)
                        childNo = 2;
                    $('.wrap-child' + componentName).html('');
                    var arrChild = [];
                    for (i = 1; i <= childNo; i++) {
                        arrChild.push(i);
                    }                  
                    var temp = Handlebars.compile($('#tmpl-list' + componentName).html());
                    $('.wrap-child' + componentName).html(temp(arrChild));
                } else {
                    $('.wrap-child' + componentName).html('');
                }
            })
            .off('select2:open', '.multiselect-dropdown-plaintext')
            .on('select2:open', '.multiselect-dropdown-plaintext', function (e) {
                $('.js--btsave' + componentName).show();
                $('.js--cancel').show();
            }).off('focus', '.js-postcode')
            .on('focus', '.js-postcode', function (event) {
                $(this).data('preval', $(this).val());
            }).off('blur', '.js-postcode')
            .on('blur', '.js-postcode', function (e) {
                if ($.trim($(this).val()).length == 5 &&
                    ($(this).val() != $(this).data('preval'))) {
                    var el = $(this).closest('.card-body');
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
                                el.find('.js-district').removeAttr('disabled');
                                //อำเภอ
                                var temp = Handlebars.compile($('#tmpl-lissubdistrict' + componentName).html());
                                el.find('.js-subdistrict').html(temp(data.Data.SubDistrict));
                                el.find('.js-subdistrict').removeAttr('disabled');

                            }
                        },
                        error: function (err) {
                        }
                    });
                } //end if
            }).off('change', '.js-province')
            .on('change', '.js-province', function (e, para, para2) {
                if (typeof para !== "undefined") {
                    handleChange($(this), setDistrict(para, para2));
                } else {
                    handleChange($(this));
                }
            }).off('change', '.js-district')
            .on('change', '.js-district', function (e) {
                var el = $(this).closest('.card-body');
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
            }).off('change', '.js-subdistrict')
            .on('change', '.js-subdistrict', function (e) {
                var el = $(this).closest('.card-body');
                el.find('.js-postcode').val($(this).find(':selected').data('postcode'));
            })
            .off('ifChecked', ':radio[name=rdomarital]')
            .on('ifChecked', ':radio[name=rdomarital]', function (e) {
                var frm = $(this).closest('form');
                frm.find('.js--btsave' + componentName).show();
                frm.find('.js--cancel').show();
                $.ajax({
                    url: '/jfservices/applicant/getmaritalchild',
                    method: 'POST',
                    data: { parentID: $(this).val() },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            $('.wrap-toggledisplay').slideDown();
                            $('#additionalMaritalStatus').html('<option value="" disabled selected>เลือก</option>');
                            $.each(data.Data, function (i, item) {
                                $('#additionalMaritalStatus').append('<option value="' + item.MaritalStatusID + '">' + item.MaritalStatusName + '</option>');
                            });
                        } else {
                            $('.wrap-toggledisplay').slideUp();
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });
            })
            .off('change', '#Income' + componentName)
            .on('change', '#Income' + componentName, function (e) {
                if ($(this).val() == 0) {
                    $('#IncomeUnit' + componentName).attr('disabled', true);
                } else { $('#IncomeUnit' + componentName).attr('disabled', false); }
            }).off('click', '.js--cancel')
            .on('click', '.js--cancel', function (e) {
                $('.js--btsave' + componentName).hide();
                $(this).hide();
            })
            .off('click', '.js--btsave' + componentName)
            .on('click', '.js--btsave' + componentName, function (e) {

                var frm = $('#frm' + componentName);
                if (frm.validationEngine('validate')) {
                    console.log("test");
                    if ($(':radio[name=rdomarital]').is(':checked')) {
                        var applicantMarital = {
                            ApplicantID: $('#applicantID' + componentName).val(),
                            MaritalStatusID: $(':radio[name=rdomarital]:checked').val(),
                            NumberOfChild: $('#child' + componentName).length ? $('#child' + componentName).val() : 0,
                            AdditionalMaritalStatus: $('.wrap-toggledisplay').is(':visible') ? $('#additionalMaritalStatus').val() : null,
                        }
                        console.log(applicantMarital);
                        var applicantFamily = [];
                        if ($('.wrap-toggledisplay').is(':visible')) {
                            applicantFamily.push({
                                ApplicantID: $('#applicantID' + componentName).val(),
                                GroupName: 'SPOUSE',
                                Name: $('#partnerName' + componentName).val(),
                                Age: $('#age' + componentName).val(),
                                TelephoneNo: $('#TelephonNumber' + componentName).val(),
                                Career: $('#Career' + componentName).val(),
                                //AddressLine: $('#partnerName' + componentName).val(),
                                AddressRequest: {
                                    Address1: $('#HouseNo' + componentName).val(),
                                    HouseNo: $('#HouseNo' + componentName).val(),
                                    VillageNo: $('#VillageNo' + componentName).val(),
                                    Soi: $('#Soi' + componentName).val(),
                                    Street: $('#Street' + componentName).val(),
                                    ProvinceID: $('#Province' + componentName).val(),
                                    DisctrictID: $('#District' + componentName).val(),
                                    SubdistrictID: $('#SubDistrict' + componentName).val(),
                                    PostCode: $('#PostCode' + componentName).val(),
                                }
                            });
                            // var address = 
                            var applicantFamilyIncome = {
                                Income: $('#Income' + componentName).val(),
                                IncomeUnit: $('#IncomeUnit' + componentName).val(),
                            }
                            //Child
                            if ($('#child' + componentName).val() != 0) {
                                for (var i = 1; i <= $('#child' + componentName).val(); i++) {
                                    if ($('#childName' + componentName + i).val() != '') {
                                        applicantFamily.push({
                                            ApplicantID: $('#applicantID' + componentName).val(),
                                            GroupName: 'CHILDREN',
                                            Name: $('#childName' + componentName + i).val(),
                                            Age: $('#childAge' + componentName + i).val(),
                                            TelephoneNo: $('#childTelephonNumber' + componentName + i).val(),
                                            Career: $('#childCareer' + componentName + i).val(),
                                            AddressLine: $('#childAddressLine' + componentName + i).val(),
                                            //AddressRequest: {}
                                        });
                                    }

                                }
                            }

                        }
                        var maritalData = {
                            ApplicantMaritalData: applicantMarital,
                            ApplicantFamilyData: applicantFamily,
                            ApplicantIncomeData: applicantFamilyIncome,
                        }
                        console.log(applicantFamilyIncome);
                        //console.log(applicantMarital,applicantFamily, applicantFamilyIncome);
                          //RADIO MARITAL
                        
                                $.ajax({
                                    url: '/jfservices/applicant/editmarital',
                                    method: 'POST',
                                    data: { req: maritalData },
                                    beforeSend: function () { },
                                    success: function (data) {
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
                        frm.find('.header-icon').remove();
                        
                    }
                }

            }).off('click', '.js--copy')
            .on('click', '.js--copy', function (e) {
                e.preventDefault()
               
                SWConfirm.fire({ title: 'คุณต้องการคัดลอกข้อมูลที่อยู่ใช่หรือไม่' }).then((result) => {
                    if (result.value) {
                       var addrTxt = $('#HouseNo' + componentName).val()+" "+
                            $('#VillageNo' + componentName).val() + " " +
                            $('#Street' + componentName).val() + " " +
                           $('#District' + componentName + ' option:selected').text() + " " +
                           $('#SubDistrict' + componentName + ' option:selected').text() + " " +
                           $('#Province' + componentName +' option:selected').text() + " " +
                            $('#PostCode' + componentName).val();
                       
                        $('#childAddressLinemarital' + $(this).data('id')).val(addrTxt);
                    }
                });
            });

    });

    function handleChange(elem, callback) {

        var el = elem.closest('.card-body');
        $.ajax({
            url: '/jfservices/address/getdistrictlist',
            method: 'POST',
            data: { id: elem.val() },
            beforeSend: function () { },
            success: function (data) {
                if (data.Status) {

                    var temp = Handlebars.compile($('#tmpl-lisdistrict'+componentName).html());
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
            $('#District' + componentName).removeAttr('disabled');
            $('#District' + componentName).val(para);
            $('#District' + componentName).trigger('change');
            setSubDistrict(para2);
        }, 2000);
    }
    function setSubDistrict(para) {
        setTimeout(function () {
            $('#SubDistrict' + componentName).removeAttr('disabled');
            $('#SubDistrict' + componentName).val(para);
        }, 2000);
    }
});
