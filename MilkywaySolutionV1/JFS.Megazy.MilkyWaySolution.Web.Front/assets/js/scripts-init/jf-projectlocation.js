 // Begin สถานที่จัดโครงการ
$(function () {
    var componentName = 'projectlocation';
    //Get Data
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        var caseID = $('#caseID' + componentName).val();
        console.log(caseID, $('#addressID' + componentName).val());
        if (caseID != 0 && $('#addressID' + componentName).val() == 0) {
            //Load data
            $.ajax({
                url: '/jfscaseserviceproject/getprojectlocation',
                method: 'POST',
                data: {
                    caseID: caseID,
                },
                beforeSend: function () { },
                success: function (data) {
                    var frm = $('#frm' + componentName);
                    console.log(data);
                    if (data.Data != null) {
                        $('#addressID' + componentName).val(data.Data.ProjectLocation.AddressID);
                        $('#LocationName' + componentName).val(data.Data.ProjectLocation.LocationName);
                        $('#Province' + componentName).val(data.Data.Address.ProvinceID);
                       // $('#Province' + componentName).next('.select2').find('.select2-selection__rendered').html($('#Province' + componentName + ' option:selected').text());
                        $('#Province' + componentName).trigger('change', [data.Data.Address.DisctrictID, data.Data.Address.SubdistrictID]);                       
                        if (data.Data.Address.DisctrictID != "") {
                           // console.log(data.Data.Address.DisctrictID, data.Data.Address.SubdistrictID);
                            getDistictByProvinceIDapplicantdetail(data.Data.Address.ProvinceID, data.Data.Address.DisctrictID, "District" + componentName);
                            getSubDistictByDistrictIDapplicantdetail(data.Data.Address.DisctrictID, data.Data.Address.SubdistrictID, "SubDistrict" + componentName);

                        }
                        $('#PostCode' + componentName).val(data.Data.Address.PostCode);

                    } else {
                        frm.find('.js--cancel').hide();
                        frm.find('.js--btsave' + componentName).hide();
                    }

                }
                , error: function (err) {
                    console.log(err);
                }
            });

        } else { console.log('default') }
    });
    
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) { Common.swcithTabIcon(this); });
    $(document).ready(function () {

        $('#frm' + componentName)
            .off('keyup ifChecked change', '.js-text')
            .on('keyup ifChecked change', '.js-text', function (e) {
                var frm = $(this).closest('form');               
                frm.find('.js--btsave' + componentName).show();
                frm.find('.js--cancel').show();
            })
            .off('select2:open', '.multiselect-dropdown-plaintext')
            .on('select2:open', '.multiselect-dropdown-plaintext', function (e) {
                $('.js--btsave' + componentName).show();
                $('.js--cancel').show();
            }).off('click', '.js--cancel')
            .on('click', '.js--cancel', function (e) {
                $('.js--btsave' + componentName).hide();
                $(this).hide();
            })
            .off('click', '.js--btsave' + componentName)
            .on('click', '.js--btsave' + componentName, function (e) {
                e.preventDefault();
                //--เริ่มต้นตรวจสอบค่า
                if ($('#frm' + componentName).validationEngine('validate')){
                    //ที่อยู่
                    var projectLocaAddressData = {
                        ProjectLocation: {
                            CaseID: $('#caseID' + componentName).val(),
                            LocationName: $('#LocationName' + componentName).val()
                        },
                        AddressRow: {
                           // HouseNo: $('#HouseNo').val(),
                            //VillageNo: $('#VillageNo').val(),
                           // Street: $('#Street' + componentName).val(),
                            AddressID: $('#addressID' + componentName).val(),
                            ProvinceID: $('#Province' + componentName).val(),
                            DisctrictID: $('#District' + componentName).val(),
                            SubdistrictID: $('#SubDistrict' + componentName).val(),
                            PostCode: $('#PostCode' + componentName).val()
                        },
                    }
                    $.ajax({
                        url: '/jfscaseserviceproject/savelocationaddress',
                        method: 'POST',
                        data: { req: projectLocaAddressData },
                        beforeSend: function () { },
                        success: function (data) {
                            console.log(data);
                            if (data.Status) {
                                SWSuccess.fire();
                            }
                            $('.js--btsave' + componentName).hide();
                            $('.js--cancel').hide();
                        }
                        , error: function (err) {
                            if (err.status == 401) {
                                window.location.reload();
                            }
                        }
                    });

                }
                //else {
                //    SWError.fire();
                //}//--Validate

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
                        //console.log(data);
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
                    var temp = Handlebars.compile($('#tmpl-lisdistrict' + componentName).html());
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
                    var temp = Handlebars.compile($('#tmpl-lissubdistrict' + componentName).html());
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
});