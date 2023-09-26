// คำร้องขอปล่อยชั่วคราว
$(function () {

    var componentName = 'applicantdetail';
    function getDistictByProvinceIDapplicantdetail(provinceid, districtid, elementID) {

        $('#' + elementID).html('');

        $.ajax({
            url: '/jfservices/address/getdistrictlist',
            method: 'POST',
            data: { id: provinceid },
            beforeSend: function () {
                //$('#SubDistrict').html('Loading...')
            },
            success: function (data) {
                //console.log(data);
                if (data.Status) {
                    var temp = Handlebars.compile($('#tmpl-lisdistrict').html());
                    $('#' + elementID).html(temp(data.Data));
                    $('#' + elementID).removeAttr('disabled');
                    $('#' + elementID).val(districtid);
                }
            }
            , error: function (err) {
                console.log(err);
            }
        });
    }


    function getSubDistictByDistrictIDapplicantdetail(districtid, subDistrictid, elementID) {

        $('#' + elementID).html('');

        $.ajax({
            url: '/jfservices/address/getsubdistrictlist',
            method: 'POST',
            data: { id: districtid },
            beforeSend: function () {
                //$('#SubDistrict').html('Loading...')
            },
            success: function (data) {
                //console.log(data);
                if (data.Status) {
                    var temp = Handlebars.compile($('#tmpl-lissubdistrict').html());
                    $('#' + elementID).html(temp(data.Data));
                    $('#' + elementID).removeAttr('disabled');
                    $('#' + elementID).val(subDistrictid);

                }
            }
            , error: function (err) {
                console.log(err);
            }
        });
    }


    function getDataApplicant() {
        //console.log($('#caseID' + componentName).val());
        //console.log($('#applicantID' + componentName).val());
        //var frm = $('#frm');
        //if ($('#Title' + componentName).val() == "" && $('#applicantID' + componentName).val() != 0) {
        //    //Load data
        //    $.ajax({
        //        url: '/applicantdetail/getapplicantdetail',
        //        method: 'POST',
        //        data: {

        //            applicantID: $('#applicantID' + componentName).val()
        //        },

        //        beforeSend: function () { },
        //        success: function (data) {

        //            console.log(data);
        //            var app = data.Data.Applicant;
        //            var edu = data.Data.Education;
        //            $('#Title' + componentName).val(app.Title);
        //            $('#FirstName' + componentName).val(app.FirstName);
        //            $('#LastName' + componentName).val(app.LastName);
        //            $('#cardID' + componentName).val(app.CardID);
        //            $('#dateOfBirth' + componentName).val(Common.JSONDate(app.DateOfBirth));
        //            $('#Nationality' + componentName).val(app.NationalityID).trigger('change');
        //            $('#rdorace' + componentName + app.RaceID).iCheck('check');
        //            $('#rdoreligion' + componentName + app.ReligionID).iCheck('check');
        //            if (app.Gender == 'f') {
        //                $('#rdomale' + componentName).iCheck('check');
        //            }
        //            else {
        //                $('#rdofemale' + componentName).iCheck('check');
        //            }
        //            if (edu.EducationLevelID == 99) {
        //                $('#education' + componentName).val(edu.EducationLevelID).trigger('change');
        //                $('#educationOther' + componentName).val(edu.EducationOther);
        //                frm.find('.diveduother').show();

        //            }
        //            else {
        //                $('#education' + componentName).val(edu.EducationLevelID).trigger('change');
        //                frm.find('.diveduother').hide();
        //            }
        //            var address = data.Data.Address;
        //            $.each(address, function (index, values) {
        //                var addressstate = ["", "Current"];
        //                $('#' + addressstate[index] + 'addressID' + componentName).val(values.AddressID)
        //                $('#' + addressstate[index] + 'HouseNo' + componentName).val(values.HouseNo);
        //                $('#' + addressstate[index] + 'VillageNo' + componentName).val(values.VillageNo);
        //                $('#' + addressstate[index] + 'Street' + componentName).val(values.Street);
        //                $('#' + addressstate[index] + 'Province' + componentName).val(values.ProvinceID).trigger('change');
        //                if (values.DisctrictID != "") {
        //                    //console.log(data.DisctrictID, data.SubdistrictID);
        //                    //$('#' + addressstate[index] + 'Province' + componentName).trigger('change', [values.DisctrictID, values.SubdistrictID]);
        //                    setTimeout(function () {
        //                        getDistictByProvinceIDapplicantdetail(values.ProvinceID, values.DisctrictID, addressstate[index] + "District" + componentName);
        //                    }, 2000);
        //                    setTimeout(function () {
        //                        getSubDistictByDistrictIDapplicantdetail(values.DisctrictID, values.SubdistrictID, addressstate[index] + "SubDistrict" + componentName);
        //                    }, 2000);
                            

        //                }
        //                $('#' + addressstate[index] + 'PostCode' + componentName).val(values.PostCode);
        //                $('#' + addressstate[index] + 'TelephonNumber' + componentName).val(values.TelephoneNo);
        //                $('#' + addressstate[index] + 'Stay' + componentName).val(values.Stay);
        //                $('#' + addressstate[index] + 'StayUnit' + componentName).val(values.StayUnit);
        //                $('#' + addressstate[index] + 'rdoAddrType' + componentName + values.AddressTypeID).iCheck('check');



                        
        //            });
        //            frm.find('.js--btsave' + componentName).hide();
        //            frm.find('.js--cancel').hide();
        //        }
        //        , error: function (err) {
        //            console.log(err);
        //        }
        //    });

        //} else { console.log('default') }
       // console.log(frm);
        var frm = $('#frm' + componentName);
        $body = $(this).find('.card-body div').first();
        console.log($('#caseID' + componentName).val());
        console.log($('#applicantID' + componentName).val());
        if ($('#Title' + componentName).val() == "" && $('#applicantID' + componentName).val() != 0) {
            //Load data
            $.ajax({
                url: '/applicantdetail/getapplicantdetail',
                method: 'POST',
                data: {

                    applicantID: $('#applicantID' + componentName).val()
                },

                beforeSend: function () { },
                success: function (data) {

                    console.log(data);
                    var app = data.Data.Applicant;
                    var edu = data.Data.Education;
                    $('#Title' + componentName).val(app.Title);
                    $('#FirstName' + componentName).val(app.FirstName);
                    $('#LastName' + componentName).val(app.LastName);
                    $('#cardID' + componentName).val(app.CardID);
                    $('#dateOfBirth' + componentName).val(Common.JSONDate(app.DateOfBirth));
                    $('#Nationality' + componentName).val(app.NationalityID).trigger('change');
                    $('#rdorace' + componentName + app.RaceID).iCheck('check');
                    $('#rdoreligion' + componentName + app.ReligionID).iCheck('check');
                    if (app.Gender == 'f') {
                        $('#rdomale' + componentName).iCheck('check');
                    }
                    else {
                        $('#rdofemale' + componentName).iCheck('check');
                    }
                    if (edu.EducationLevelID == 99) {
                        $('#education' + componentName).val(edu.EducationLevelID).trigger('change');
                        $('#educationOther' + componentName).val(edu.EducationOther);
                        frm.find('.diveduother').show();

                    }
                    else {
                        $('#education' + componentName).val(edu.EducationLevelID).trigger('change');
                       // frm.find('.diveduother').hide();
                    }
                    var address = data.Data.Address;
                    $.each(address, function (index, values) {
                        var addressstate = ["", "Current"];
                        $('#' + addressstate[index] + 'addressID' + componentName).val(data.AddressID)
                        $('#' + addressstate[index] + 'HouseNo' + componentName).val(data.HouseNo);
                        $('#' + addressstate[index] + 'VillageNo' + componentName).val(data.VillageNo);
                        $('#' + addressstate[index] + 'Street' + componentName).val(data.Street);
                        $('#' + addressstate[index] + 'Province' + componentName).val(data.ProvinceID).trigger('change');
                        if (data.DisctrictID != "") {
                            //console.log(data.DisctrictID, data.SubdistrictID);

                            getDistictByProvinceIDapplicantdetail(data.ProvinceID, data.DisctrictID, + addressstate[index] + "District" + componentName);
                            getSubDistictByDistrictIDapplicantdetail(data.DisctrictID, data.SubdistrictID, + addressstate[index] + "SubDistrict" + componentName);

                        }
                        $('#' + addressstate[index] + 'PostCode' + componentName).val(data.PostCode);
                        //$('#CurrentTelephonNumber' + componentName).val(values.Telephon);
                        $('#' + addressstate[index] + 'Stay' + componentName).val(values.Stay);
                        $('#' + addressstate[index] + 'StayUnit' + componentName).val(values.StayUnit);
                        $('#' + addressstate[index] + 'rdoAddrType' + componentName + values.AddressTypeID).iCheck('check');



                        //        });
                        //        //$('#CurrentTelephonNumber' + componentName).val(values.Telephon);
                        //        $('#CurrentStay' + componentName).val(values.Stay);
                        //        $('#CurrentStayUnit' + componentName).val(values.StayUnit);
                        //        $('#CurrentrdoAddrType' + componentName + values.AddressTypeID).iCheck('check');
                        //    if (values.IsPresentAddress == true && values.IsPermanentAddress == false) {
                        //        var addressid = values.AddressID;
                        //        $.each(data.Data.Address, function (index, data) {
                        //            if (addressid == data.AddressID) {                                    
                        //                $('#CurrentaddressID' + componentName).val(data.AddressID)
                        //                $('#CurrentHouseNo' + componentName).val(data.HouseNo);
                        //                $('#CurrentVillageNo' + componentName).val(data.VillageNo);
                        //                $('#CurrentStreet' + componentName).val(data.Street);
                        //                $('#CurrentProvince' + componentName).val(data.ProvinceID).trigger('change');
                        //                if (data.DisctrictID != "") {
                        //                    //console.log(data.DisctrictID, data.SubdistrictID);

                        //                    getDistictByProvinceIDapplicantdetail(data.ProvinceID, data.DisctrictID, "CurrentDistrict" + componentName);
                        //                    getSubDistictByDistrictIDapplicantdetail(data.DisctrictID, data.SubdistrictID, "CurrentSubDistrict" + componentName);

                        //                }
                        //                $('#CurrentPostCode' + componentName).val(data.PostCode);

                        //            }

                        //        });
                        //        //$('#CurrentTelephonNumber' + componentName).val(values.Telephon);
                        //        $('#CurrentStay' + componentName).val(values.Stay);
                        //        $('#CurrentStayUnit' + componentName).val(values.StayUnit);
                        //        $('#CurrentrdoAddrType' + componentName + values.AddressTypeID).iCheck('check');
                        //    }
                        //    else if (values.IsPresentAddress == false && values.IsPermanentAddress == true) {
                        //        //console.log("ที่อยู่ตามภูมิลำเนา")
                        //        var addressid = values.AddressID;
                        //        $.each(data.Data.Address, function (index, data) {
                        //            if (addressid == data.AddressID) {
                        //                $('#addressID' + componentName).val(data.AddressID)
                        //                $('#HouseNo' + componentName).val(data.HouseNo);
                        //                $('#VillageNo' + componentName).val(data.VillageNo);
                        //                $('#Street' + componentName).val(data.Street);
                        //                $('#Province' + componentName).val(data.ProvinceID).trigger('change');
                        //                if (data.DisctrictID != "") {
                        //                    //console.log(data.DisctrictID, data.SubdistrictID);

                        //                    getDistictByProvinceIDapplicantdetail(data.ProvinceID, data.DisctrictID, "District" + componentName);
                        //                    getSubDistictByDistrictIDapplicantdetail(data.DisctrictID, data.SubdistrictID, "SubDistrict" + componentName);

                        //                }
                        //                $('#PostCode' + componentName).val(data.PostCode);

                        //            }

                        //        });

                        //        //$('#TelephonNumber' + componentName).val(values.Telephon);
                        //        $('#Stay' + componentName).val(values.Stay);
                        //        $('#StayUnit' + componentName).val(values.StayUnit);
                        //        $('#rdoAddrType' + componentName + values.AddressTypeID).iCheck('check');
                        //    }

                        //    console.log("test", index++);
                        //});





                        frm.find('.js--btsave' + componentName).hide();
                        frm.find('.js--cancel').hide();
                    });
                }
                , error: function (err) {
                    console.log(err);
                }
            });

        } else { console.log('default') }
    }
    
    $('#card-' + componentName).on(function (event) {
       
        getDataApplicant();
       
    });
    //Card 
    //Common.CollapsedCard(this);
    
    $(document).ready(function () {
        getDataApplicant();
    });

    $('#frm' + componentName)
        .off('keyup change ifChecked', '.js-text')
        .on('keyup change ifChecked', '.js-text', function (e) {
            var frm = $(this).closest('form');
            console.log($('#education' + componentName).val());

            if ($('#education' + componentName).val() == 99) {
                frm.find('.diveduother').show();
            }
            else {
                frm.find('.diveduother').hide();
            }
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (event) {
            var frm = $(this).closest('form');
            if ($('#frm' + componentName).validationEngine('validate')) {

                        var appadd = ["", "Current"]
                        var caseApplicantData = {
                            ApplicantID: $('#applicantID' + componentName).val(),
                            CardID: $('#cardID'+ componentName).val(),
                            Title: $('#Title' + componentName).val(),
                            FirstName: $('#FirstName' + componentName).val(),
                            LastName: $('#LastName' + componentName).val(),
                            //RequestAmount: $('#RequestAmount').val(),
                            //HasProxy: 0,
                        }//หนึ่งคดีมีได้หลายคน
                        var caseApplicantExtensionData = {
                            ApplicantID: $('#applicantID' + componentName).val(),
                            Gender: $(':radio[name=rdosex' + componentName + ']').is(':checked') ? $(':radio[name=rdosex' + componentName +']:checked').val() : 'm',
                            DateOfBirth: $('#dateOfBirth' + componentName).datepicker({ dateFormat: 'dd/MM/yyyy' }).val(),
                            RaceID: $(':radio[name=rdorace]').is(':checked') ? $(':radio[name=rdorace]:checked').val() : 1,
                            ReligionID: $(':radio[name=rdoreligion]').is(':checked') ? $(':radio[name=rdoreligion]:checked').val() : 1,
                            NationalityID: $('#Nationality' + componentName).val()
                        }

                        
                        var appaddressdetail = [];
                        var adddetail = []


                        for (var i = 0; i < appadd.length; i++) {

                            var present;
                            var premanent;
                            if (i == 0) {
                                present = false;
                                premanent = true
                            }
                            else {
                                present = true;
                                premanent = false
                            }
                            appaddressdetail.push({
                                AddressID: $('#' + appadd[i] + 'addressID' + componentName).val(),
                                AddressTypeID: $(':radio[name=' + appadd[i] + 'rdoAddrType' + componentName + ']:checked').val(),
                                Stay: $('#' + appadd[i] + 'Stay' + componentName).val(),
                                StayUnit: $('#' + appadd[i] + 'StayUnit' + componentName).val(),
                                TelephonNumber: $('#' + appadd[i] + 'TelephonNumber' + componentName).val(),
                                IsPresentAddress: present,
                                IsPermanentAddress: premanent,
                            });
                            adddetail.push({
                                AddressID: $('#' + appadd[i] + 'addressID' + componentName).val(),
                                HouseNo: $('#' + appadd[i] + 'HouseNo' + componentName).val(),
                                VillageNo: $('#' + appadd[i] + 'VillageNo' + componentName).val(),
                                Street: $('#' + appadd[i] + 'Street' + componentName).val(),
                                ProvinceID: $('#' + appadd[i] + 'Province' + componentName).val(),
                                DisctrictID: $('#' + appadd[i] + 'District' + componentName).val(),
                                SubdistrictID: $('#' + appadd[i] + 'SubDistrict' + componentName).val(),
                                PostCode: $('#' + appadd[i] + 'PostCode' + componentName).val(),
                            });


                        }


                        var data = {
                            CaseApplicantData: caseApplicantData,
                            CaseApplicantExtensionData: caseApplicantExtensionData,
                        }
                        console.log(data);

                        //$.ajax({
                        //    type: 'POST',
                        //    url: '/proxy/editorsave',
                        //    data: { req: data },

                        //    beforeSend: function () { },
                        //    success: function (data) {
                        //        if (data.Status) {
                        //            SWSuccess.fire({
                        //                onClose: () => {
                        //                    window.location.reload();
                        //                }
                        //            });
                        //        }
                        //        else {
                        //            SWError.fire({

                        //            });
                        //        }
                        //    },
                        //    error: function (err) {
                        //        console.log(err);
                        //        SWError.fire({

                        //        });
                        //    }
                        //});

                        frm.find('.js--btsave' + componentName).hide();
                        frm.find('.js--cancel').hide();


            }

            
            
        })
        .off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        .off('ifChecked', ':radio[name=historystatus' + componentName + ']')
        .on('ifChecked', ':radio[name=historystatus' + componentName + ']', function (e) {

            var frm = $(this).closest('form');
            supcareer = $(this).val();
            console.log($(this).val());
            if ($(this).val() == 1) {
                $('.divoffense').show();
            }
            else {
                $('.divoffense').hide();
            }
            frm.find('.js--cancel').show();
            frm.find('.js--btsave' + componentName).show();

        })
        .off('ifChecked', ':radio[name=escapestatus' + componentName + ']')
        .on('ifChecked', ':radio[name=escapestatus' + componentName + ']', function (e) {

            var frm = $(this).closest('form');
            supcareer = $(this).val();
            console.log($(this).val());
            if ($(this).val() == 1) {
                $('.divescape').show();

            }
            else {
                $('.divescape').hide();
            }
            frm.find('.js--cancel').show();
            frm.find('.js--btsave' + componentName).show();

        })
        .off('focus', '.js-postcode')
        .on('focus', '.js-postcode', function (event) {
            $(this).data('preval', $(this).val());
        })
        .off('blur', '.js-postcode')
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
                            var temp = Handlebars.compile($('#tmpl-lisdistrict').html());
                            el.find('.js-district').html(temp(data.Data.District));
                            el.find('.js-district').removeAttr('disabled');
                            //อำเภอ
                            var temp = Handlebars.compile($('#tmpl-lissubdistrict').html());
                            el.find('.js-subdistrict').html(temp(data.Data.SubDistrict));
                            el.find('.js-subdistrict').removeAttr('disabled');

                        }
                    },
                    error: function (err) {
                    }
                });
            } //end if
        })
        .off('change', '.js-province')
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
                    //console.log(data);
                    if (data.Status) {
                        var temp = Handlebars.compile($('#tmpl-lissubdistrict').html());
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
            var el = $(this).closest('.card-body');
            el.find('.js-postcode').val($(this).find(':selected').data('postcode'));
        })
        .off('click', '.js-copy')
        .on('click', '.js-copy', function (e) {
            e.preventDefault()
            var frm = $(this).closest('form');
            SWConfirm.fire({ title: 'คุณต้องการคัดลอกข้อมูลที่อยู่ตามภูมิลำนำใช่หรือไม่' }).then((result) => {
                if (result.value) {
                    $('#CurrentDistrict' + componentName).attr('disabled', 'disabled');
                    $('#CurrentSubDistrict' + componentName).attr('disabled', 'disabled');
                    $('#CurrentHouseNo' + componentName).val($('#HouseNo' + componentName).val());
                    $('#CurrentVillageNo' + componentName).val($('#VillageNo' + componentName).val());
                    $('#CurrentStreet' + componentName).val($('#Street' + componentName).val());
                    $('#CurrentStay' + componentName).val($('#Stay' + componentName).val());
                    $('#CurrentStayUnit' + componentName).val($('#StayUnit' + componentName).val());
                    $('#CurrentPostCode' + componentName).val($('#PostCode').val());
                    $('#CurrentTelephonNumber' + componentName).val($('#TelephonNumber' + componentName).val());
                    if ($(':radio[name=rdoAddrType' + componentName + ']').is(':checked')) {
                        var vl = $(':radio[name=rdoAddrType' + componentName + ']:checked').val();
                        $(':radio[name=CurrentrdoAddrType' + componentName + '][value=' + vl + ']').iCheck('check');
                    }
                    $('#CurrentProvince' + componentName).val($('#Province' + componentName).val());

                    getDistictByProvinceID($('#Province' + componentName).val(), $('#District' + componentName).val(), "CurrentDistrict" + componentName);
                    getSubDistictByDistrictID($('#District' + componentName).val(), $('#SubDistrict' + componentName).val(), "CurrentSubDistrict" + componentName);
                    $('#CurrentPostCode' + componentName).val($('#PostCode' + componentName).val());
                    
                    frm.find('.js--cancel').show();
                    frm.find('.js--btsave' + componentName).show();

                }
            });


        });




    function handleChange(elem, callback) {

        var el = elem.closest('#card-' + componentName);
        $.ajax({
            url: '/jfservices/address/getdistrictlist',
            method: 'POST',
            data: { id: elem.val() },
            beforeSend: function () { },
            success: function (data) {
                if (data.Status) {

                    var temp = Handlebars.compile($('#tmpl-lisdistrict').html());
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
        //console.log(para, 'xxxx', para2);
        setTimeout(function () {
            $('#CurrentDistrict').removeAttr('disabled');
            $('#CurrentDistrict').val(para);
            $('#CurrentDistrict').trigger('change');
            setSubDistrict(para2);
        }, 2000);
    }
    function setSubDistrict(para) {
        setTimeout(function () {
            $('#CurrentSubDistrict').removeAttr('disabled');
            $('#CurrentSubDistrict').val(para);
        }, 2000);
    }

});
