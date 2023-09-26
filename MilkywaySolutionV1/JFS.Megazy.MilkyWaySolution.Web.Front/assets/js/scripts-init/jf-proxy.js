// Begin ผู้รับมอบอำนาจ
$(function () {

    var componentName = 'proxy';
    

    function getDistictByProvinceID(provinceid, districtid, elementID) {

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


    function getSubDistictByDistrictID(districtid, subDistrictid, elementID) {

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




    //
    function handleChange(elem, callback) {

        var el = elem.closest('.card-body');
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

    function getreligionOther(proxyID) {
        
        $.ajax({
            url: '/proxy/getreligionother',
            method: 'POST',
            data: { proxyID: proxyID },
            beforeSend: function () { },
            success: function (data) {
                if (data.Status) {
                   
                    $('#religionother' + componentName).val(data.Data.ReligionOther);

                }
            }
            , error: function (err) {
                console.log(err);
            }
        });
    }
    var frm;

    $('#card-' + componentName).on('expanded.lte.widget', function (event) {
        Common.swcithTabIcon(this);

        frm = $(this).closest('form');
        //GetData
        $body = $(this).find('.card-body div').first();        
        if ($('#applicantID' + componentName).val() != 0 && !$(':radio[name=rdosex'+componentName+']').is(':checked')) {
            $('#applicantID' + componentName).val();
            $('#caseID' + componentName).val();
            $('#state' + componentName).val(1);
            console.log($('#caseID' + componentName).val());
            //Load data
            $.ajax({
                url: '/proxy/getproxy',
                method: 'POST',
                data: {
                    applicantID: $('#applicantID' + componentName).val()
                },
                beforeSend: function () { },
                success: function (data) {
                    console.log(data)

                    if (data.Data != 0) {
                        if (data.Data.ProxyDataDetail.Gender == 'm') {
                            $('#rdomale' + componentName).iCheck('check');
                        }
                        else if (data.Data.ProxyDataDetail.Gender == 'f') {
                            $('#rdofemale' + componentName).iCheck('check');
                        }
                        $('#applicantID' + componentName).val(data.Data.ProxyDataDetail.ApplicantID);
                        $('#caseID' + componentName).val(data.Data.ProxyDataDetail.CaseID);
                        $('#proxyID' + componentName).val(data.Data.ProxyDataDetail.ProxyID);             
                        
                        $('#Title' + componentName).val(data.Data.ProxyDataDetail.Title);
                        if ($('#Title' + componentName).val() != data.Data.ProxyDataDetail.Title) {
                            console.log($('#Title' + componentName).val());
                            var datatitle = data.Data.ProxyDataDetail.Title;
                            var o = $("<option/>", { value: datatitle, text: datatitle });
                            $('#Title' + componentName).append(o);
                            $('#Title' + componentName).val(datatitle).trigger('change');
                            
                        }
                        else {
                            $('#Title' + componentName).val(datatitle).trigger('change');
                        }

                        $('#FirstName' + componentName).val(data.Data.ProxyDataDetail.FirstName);
                        $('#LastName' + componentName).val(data.Data.ProxyDataDetail.LastName);
                        $('#cardID' + componentName).val(data.Data.ProxyDataDetail.CardID);
                        $('#dateOfBirth' + componentName).val(Common.JSONDate(data.Data.ProxyDataDetail.DateOfBirth));
                        $('#Nationality' + componentName).val(data.Data.ProxyDataDetail.NationalityID).trigger('change');
                        $('#rdorace'+ componentName + data.Data.ProxyDataDetail.RaceID).iCheck('check');
                        $('#rdoreligion'+ componentName + data.Data.ProxyDataDetail.ReligionID).iCheck('check');
                        $('#relatedas' + componentName).val(data.Data.ProxyDataDetail.RelatedAs);

                        if (data.Data.ProxyDataDetail.ReligionID == 4) {
                            console.log("Religion");
                            getreligionOther($('#proxyID' + componentName).val());
                        }

                        $.each(data.Data.ProxAddress, function (index, values) {


                            if (values.IsPresentAddress == true && values.IsPermanentAddress == false) {
                                var addressid = values.AddressID;
                                $.each(data.Data.Address, function (index, data) {
                                    if (addressid == data.AddressID) {
                                        $('#CurrentaddressID' + componentName).val(data.AddressID)
                                        $('#CurrentHouseNo' + componentName).val(data.HouseNo);
                                        $('#CurrentVillageNo' + componentName).val(data.VillageNo);
                                        $('#CurrentStreet' + componentName).val(data.Street);
                                        $('#CurrentProvince' + componentName).val(data.ProvinceID).trigger('change');
                                        if (data.DisctrictID != "") {
                                            //console.log(data.DisctrictID, data.SubdistrictID);
                                            setTimeout(function () {
                                                getDistictByProvinceID(data.ProvinceID, data.DisctrictID, "CurrentDistrict" + componentName);
                                            }, 2000);
                                            setTimeout(function () {
                                                getSubDistictByDistrictID(data.DisctrictID, data.SubdistrictID, "CurrentSubDistrict" + componentName);
                                            }, 2000);
                                            
                                            

                                        }
                                        $('#CurrentPostCode' + componentName).val(data.PostCode);

                                    }

                                });
                                $('#CurrentTelephonNumber' + componentName).val(values.TelephoneNo);
                                $('#CurrentStay' + componentName).val(values.Stay);
                                $('#CurrentStayUnit' + componentName).val(values.StayUnit);
                                $('#CurrentrdoAddrType'+ componentName + values.AddressTypeID).iCheck('check');
                            }
                            else if (values.IsPresentAddress == false && values.IsPermanentAddress == true) {
                                //console.log("ที่อยู่ตามภูมิลำเนา")
                                var addressid = values.AddressID;
                                $.each(data.Data.Address, function (index, data) {
                                    if (addressid == data.AddressID) {
                                        $('#addressID' + componentName).val(data.AddressID)
                                        $('#HouseNo' + componentName).val(data.HouseNo);
                                        $('#VillageNo' + componentName).val(data.VillageNo);
                                        $('#Street' + componentName).val(data.Street);
                                        $('#Province' + componentName).val(data.ProvinceID).trigger('change');
                                        if (data.DisctrictID != "") {
                                            //console.log(data.DisctrictID, data.SubdistrictID);
                                            setTimeout(function () {
                                                getDistictByProvinceID(data.ProvinceID, data.DisctrictID, "District" + componentName);
                                            }, 2000);
                                            setTimeout(function () {
                                                getSubDistictByDistrictID(data.DisctrictID, data.SubdistrictID, "SubDistrict" + componentName);
                                            }, 2000);
                                            
                                            

                                        }
                                        $('#PostCode' + componentName).val(data.PostCode);

                                    }

                                });

                                $('#TelephonNumber' + componentName).val(values.TelephoneNo);
                                $('#Stay' + componentName).val(values.Stay);
                                $('#StayUnit' + componentName).val(values.StayUnit);
                                $('#rdoAddrType'+componentName + values.AddressTypeID).iCheck('check');
                            }

                            else if (values.IsPresentAddress == true && values.IsPermanentAddress == true) {                                
                                var addressid = values.AddressID;
                                $.each(data.Data.Address, function (index, data) {
                                    if (addressid == data.AddressID) {
                                        
                                        $('#addressID' + componentName).val(data.AddressID);
                                        $('#HouseNo' + componentName).val(data.HouseNo);
                                        $('#VillageNo' + componentName).val(data.VillageNo);
                                        $('#Street' + componentName).val(data.Street);
                                        $('#Province' + componentName).val(data.ProvinceID);
                                        $('#CurrentaddressID' + componentName).val(data.AddressID)
                                        $('#CurrentHouseNo' + componentName).val(data.HouseNo);
                                        $('#CurrentVillageNo' + componentName).val(data.VillageNo);
                                        $('#CurrentStreet' + componentName).val(data.Street);
                                        $('#CurrentProvince' + componentName).val(data.ProvinceID).trigger('change');
                                        if (data.DisctrictID != "") {
                                            //console.log(data.DisctrictID, data.SubdistrictID);
                                            getDistictByProvinceID(data.ProvinceID, data.DisctrictID, "District" + componentName);
                                            getSubDistictByDistrictID(data.DisctrictID, data.SubdistrictID, "SubDistrict" + componentName);
                                            getDistictByProvinceID(data.ProvinceID, data.DisctrictID, "CurrentDistrict" + componentName);
                                            getSubDistictByDistrictID(data.DisctrictID, data.SubdistrictID, "CurrentSubDistrict" + componentName);

                                        }
                                        $('#PostCode' + componentName).val(data.PostCode);
                                        $('#CurrentPostCode' + componentName).val(data.PostCode);

                                    }

                                });

                                $('#TelephonNumber' + componentName).val(values.Telephon);
                                $('#Stay' + componentName).val(values.Stay);
                                $('#StayUnit' + componentName).val(values.StayUnit);
                                $('#rdoAddrType' + componentName+ values.AddressTypeID).iCheck('check');
                                $('#CurrentTelephonNumber' + componentName).val(values.Telephon);
                                $('#CurrentStay' + componentName).val(values.Stay);
                                $('#CurrentStayUnit' + componentName).val(values.StayUnit);
                                $('#CurrentrdoAddrType' +componentName+ values.AddressTypeID).iCheck('check');
                            }

                            $('#copy' + componentName).val(1);
                            console.log("Copy Get Data = ", $('#copy' + componentName).val());

                        });
                        
                        frm.find('.js--btsave' + componentName).hide();
                        frm.find('.js--cancel').hide();

                    }

                }
                , error: function (err) {
                    console.log(err);
                }
            });



        }
        else { console.log('default') }
    });
    //Card 
    //Common.CollapsedCard(this);
    $('#card-' + componentName).on('collapsed.lte.widget', function (event) { Common.swcithTabIcon(this); });


    $('#frm' + componentName)
        .off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        
        .off('keyup change click ifChanged', '.js--proxydetail')
        .on('keyup change click ifChanged', '.js--proxydetail', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        }).off('keyup change click ifChanged', '.js--text')
        .on('keyup change click ifChanged', '.js--text', function (e) {

            var frm = $(this).closest('form');            
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('keyup change ifChanged', '.js--text--current')
        .on('keyup change ifChanged', '.js--text--current', function (e) {

            var frm = $(this).closest('form');                        
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (event) {

            if ($('#frm' + componentName).validationEngine('validate')) {

                var proxyadd = ["", "Current"]
                var proxydetail = {
                    ProxyID: $('#proxyID' + componentName).val(),
                    CaseID: $('#caseID' + componentName).val(),
                    ApplicantID: $('#applicantID' + componentName).val(),
                    Title: $('#Title' + componentName).val(),
                    FirstName: $('#FirstName' + componentName).val(),
                    LastName: $('#LastName' + componentName).val(),
                    CardID: $('#cardID' + componentName).val(),
                    DateOfBirth: $('#dateOfBirth' + componentName).datepicker({ dateFormat: 'dd/MM/yyyy' }).val(),
                    Gender: $(':radio[name=rdosex' + componentName + ']:checked').val(),
                    RaceID: $(':radio[name=rdorace' + componentName + ']:checked').val(),
                    ReligionID: $(':radio[name=rdoreligion' + componentName + ']:checked').val(),
                    NationalityID: $('#Nationality' + componentName).val(),
                    RelatedAs: $('#relatedas' + componentName).val(),
                }

                console.log('----proxydetail-----');
                console.log(proxydetail);
                var proxyaddressdetail = [];
                var addressproxy = [];


                for (var i = 0; i < proxyadd.length; i++) {

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
                    proxyaddressdetail.push({
                        AddressID: $('#' + proxyadd[i] + 'addressID' + componentName).val(),
                        AddressTypeID: $(':radio[name=' + proxyadd[i] + 'rdoAddrType' + componentName + ']:checked').val(),
                        Stay: $('#' + proxyadd[i] + 'Stay' + componentName).val(),
                        StayUnit: $('#' + proxyadd[i] + 'StayUnit' + componentName).val(),
                        TelephoneNo: $('#' + proxyadd[i] + 'TelephonNumber' + componentName).val(),
                        IsPresentAddress: present,
                        IsPermanentAddress: premanent,
                    });
                    addressproxy.push({
                        AddressID: $('#' + proxyadd[i] + 'addressID' + componentName).val(),
                        HouseNo: $('#' + proxyadd[i] + 'HouseNo' + componentName).val(),
                        VillageNo: $('#' + proxyadd[i] + 'VillageNo' + componentName).val(),
                        Street: $('#' + proxyadd[i] + 'Street' + componentName).val(),
                        ProvinceID: $('#' + proxyadd[i] + 'Province' + componentName).val(),
                        DisctrictID: $('#' + proxyadd[i] + 'District' + componentName).val(),
                        SubdistrictID: $('#' + proxyadd[i] + 'SubDistrict' + componentName).val(),
                        PostCode: $('#' + proxyadd[i] + 'PostCode' + componentName).val(),
                    });


                }
                var religionother = '';
                var isReligionOther = $(':radio[name=rdoreligion'+componentName+']:checked').data('isother')
                if (isReligionOther == 1) {
                    religionother = $('#religionother'+componentName).val();
                }

                var data = {

                    ProxyDataDetail: proxydetail,
                    ProxAddress: proxyaddressdetail,
                    Address: addressproxy,
                }
                console.log(data);

                $.ajax({
                    type: 'POST',
                    url: '/proxy/editorsave',
                    data: {
                        req: data,
                        depID: $('#departmentID' + componentName).val(),
                        religionother: religionother,
                    },

                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {

                            if ($("#isRedirect").val() == "1") {
                                window.location.href = "/applicant/details/?id=" + data.Data + '&caseID=' + data.DataID + '&depid=' + $('#departmentID' + componentName).val();

                            } else {
                                //SWSuccess.fire({
                                //    onClose: () => {
                                //        window.location.reload();
                                //    }
                                //});
                                SWSuccess.fire();
                            }

                        }
                        else {
                            SWError.fire({

                            });
                        }
                    },
                    error: function (err) {
                        console.log(err);
                        SWError.fire({

                        });
                    }
                });
                var frm = $('#frm' + componentName);
                frm.find('.js--btsave' + componentName).hide();
                frm.find('.js--cancel').hide();



            }
            
        })
        .off('ifChecked', 'input[name=rdoreligion'+componentName+']:radio')
        .on('ifChecked', 'input[name=rdoreligion'+componentName+']:radio', function (e) {
            //alert(1);
            var frm = $('#frm'+componentName);
            var religionid = $(this).val();
            var isOther = $(this).data('isother');
            //console.log("religion = ", religionid);
            if (isOther == 1) {
                frm.find('.religionother').show();
            } else {
                frm.find('.religionother').hide();
            }
        })
        .off('click', '.js-copy')
        .on('click', '.js-copy', function (e) {
            e.preventDefault()
            $('#copy' + componentName).val(1);
            console.log("Copy js-copy = ", $('#copy' + componentName).val());
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
                    if ($(':radio[name=rdoAddrType'+componentName + ']').is(':checked')) {
                        var vl = $(':radio[name=rdoAddrType' + componentName + ']:checked').val();
                        $(':radio[name=CurrentrdoAddrType' + componentName + '][value=' + vl + ']').iCheck('check');
                    }
                    $('#CurrentProvince' + componentName).val($('#Province' + componentName).val());

                    getDistictByProvinceID($('#Province' + componentName).val(), $('#District' + componentName).val(), "CurrentDistrict" + componentName);
                    getSubDistictByDistrictID($('#District' + componentName).val(), $('#SubDistrict' + componentName).val(), "CurrentSubDistrict" + componentName);
                    $('#CurrentPostCode' + componentName).val($('#PostCode' + componentName).val());
                    
                }
            });
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
        }).off('change', '.js-subdistrict')
        .on('change', '.js-subdistrict', function (e) {
            var el = $(this).closest('.card-body');
            el.find('.js-postcode').val($(this).find(':selected').data('postcode'));
        });

});