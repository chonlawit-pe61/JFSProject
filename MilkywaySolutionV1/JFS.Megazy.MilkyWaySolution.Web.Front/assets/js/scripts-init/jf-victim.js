// Begin ผู้รับมอบอำนาจ
$(function () {
    var componentName = 'victim';
    $('#card-' + componentName).on('expanded.lte.widget', function (event) {
        Common.swcithTabIcon(this);
        // console.log(Common.formatNumber(9090.90));

        $body = $(this).find('.card-body div').first();
        if (!$(':radio[name=rdohasmitigate]').is(':checked') && $('#caseID' + componentName).val() != 0) {
            //Load data
            $.ajax({
                url: '/jfscaseexpense/getcasevictim',
                method: 'POST',
                data: { caseID: $('#caseID' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    var frm = $('#frm' + componentName);
                    console.log(data);
                    if (data.Status) {

                        if (data.Data != null) {
                            $('#victimID' + componentName).val(data.Data.victim.VictimID);
                            if (data.Data.victim.HasContact == true) {
                                $('#ContactYes').iCheck('check');
                              
                                $('#Name' + componentName).val(data.Data.victim.VictimDisputantName);
                                $('#age' + componentName).val(data.Data.victim.VictimDisputantAge);
                                $('#TelephonNumber' + componentName).val(data.Data.victim.VictimDisputantTelNo);
                                $('#HouseNo' + componentName).val(data.Data.address.HouseNo);
                                $('#VillageNo' + componentName).val(data.Data.address.VillageNo);
                                $('#Soi' + componentName).val(data.Data.address.Soi);
                                $('#Street' + componentName).val(data.Data.address.Street);
                                $('#Province' + componentName).val(data.Data.address.ProvinceID).trigger('change', [data.Data.address.DisctrictID, data.Data.address.SubdistrictID]);
                                //$('#Province' + componentName).next('.select2').find('.select2-selection__rendered').html($('#Province' + componentName + ' option:selected').text());
                                //if (data.Data.address.DistrictID != "") {
                                //    // console.log(data.Data.ApplicantFamilySpouseData.AddressResponse.DistrictID, data.Data.ApplicantFamilySpouseData.AddressResponse.SubdistrictID);
                                //    $('#Province' + componentName).trigger('change', [data.Data.address.DisctrictID, data.Data.address.SubdistrictID]);
                                //}
                                //$('#District' + componentName).val(data.Data.ApplicantFamilySpouseData.AddressResponse.District);
                                //$('#SubDistrict' + componentName).val(data.Data.ApplicantFamilySpouseData.AddressResponse.SubDistrict);
                                $('#PostCode' + componentName).val(data.Data.address.PostCode);
                            }
                            else {
                                $('#AdditionalContactInfo' + componentName).val(data.Data.victim.AdditionalContactInfo);
                                $('#ContactNo').iCheck('check');
                            }
                            if (data.Data.victim.HasMitigate) {
                                $('#MitigateYes').iCheck('check');
                                $('#AdditionalMitigateInfo' + componentName).val(data.Data.victim.AdditionalMitigateInfo);

                            } else {
                                $('#MitigateNo').iCheck('check');
                              
                            }
                            frm.find('.js--btsave' + componentName).hide();
                            frm.find('.js--cancel').hide();
                        }


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
    $('#card-' + componentName).on('collapsed.lte.widget', function (event) { Common.swcithTabIcon(this); });


    $('#frm' + componentName)
        .off('keyup change ', '.js--text')
        .on('keyup change ', '.js--text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        }).off('ifChecked', ':radio[name=rdohasmitigate]')
        .on('ifChecked', ':radio[name=rdohasmitigate]', function (e) {
            var frm = $(this).closest('form');
            console.log(this.value);
            if (this.value == 1) {
                $('.js--additionalmitigateinfo').show();
            }
            else {
                $('.js--additionalmitigateinfo').hide();
                $('#AdditionalMitigateInfo' + componentName).val('');
            }

            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();



        })
        .off('ifChecked', ':radio[name=rdoIsContact]')
        .on('ifChecked', ':radio[name=rdoIsContact]', function (e) {
            var frm = $(this).closest('form');

            console.log(this.value);
            if (this.value == 1) {
                $('.js--additionalcontactinfo').hide();
                $('.addressVictim').show();
                $('#AdditionalContactInfo' + componentName).val('');
            }
            else {
                $('.js--additionalcontactinfo').show();
                $('.addressVictim').hide();


            }

            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();

        })
        .off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {

            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {
                var AdditionalContactInfo = null;
                var AdditionalMitigateInfo = null;
                var HasContact;
                var HasMitigate;
                if ($(':radio[name=rdoIsContact]:checked').val() == 1) {
                    HasContact = true;
                }
                else {                 
                    AdditionalContactInfo = $('#AdditionalContactInfo' + componentName).val();
                    HasContact = false;
                }
                if ($(':radio[name=rdohasmitigate]:checked').val() == 1) {
                    HasMitigate = true;
                    AdditionalMitigateInfo = $('#AdditionalMitigateInfo' + componentName).val();
                }
                else {
                    HasMitigate = false;
                }
                var CaseVictim = {
                    VictimID: $('#victimID' + componentName).val(),
                    CaseID: $('#caseID' + componentName).val(),
                    HasContact: HasContact,
                    AdditionalContactInfo: AdditionalContactInfo,
                    HasMitigate: HasMitigate,
                    AdditionalMitigateInfo: AdditionalMitigateInfo,
                    AddressID: $('#addressID' + componentName).val(),
                    VictimDisputantAge: $('#age' + componentName).val(),
                    VictimDisputantTelNo: $('#TelephonNumber' + componentName).val(),
                    VictimDisputantName: $('#Name' + componentName).val(),
                }
                var Address = {
                    HouseNo: $('#VillageNo' + componentName).val(),
                    VillageNo: $('#HouseNo' + componentName).val(),
                    Soi: $('#Soi' + componentName).val(),
                    Street: $('#Street' + componentName).val(),
                    ProvinceID: $('#Province' + componentName).val(),
                    DisctrictID: $('#District' + componentName).val(),
                    SubdistrictID: $('#SubDistrict' + componentName).val(),
                    PostCode: $('#PostCode' + componentName).val(),
                }
                console.log(CaseVictim);
                var frm = $('#frm' + componentName);


                $.ajax({
                    url: '/jfscaseexpense/savecasevictim',
                    method: 'POST',
                    data: {
                        caseVictimRow: CaseVictim,
                        address: Address,
                        applicantID: $('#applicantIDvictim').val()
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            $('#victimID' + componentName).val(data.DataID);
                            $('#addressID' + componentName).val(data.Ref1);
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


        })
        .off('focus', '.js-postcode')
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
