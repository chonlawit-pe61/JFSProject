
$(function () {

    var componentName = 'infromationguarantee';
    var selectedistrict = $('#SelectGuaranteeDistrict' + componentName).val();


    $(document).ready(function () {
        if ($('#SelectGuaranteeDistrict' + componentName).val() != "0") {
            setTimeout(function () {
                console.log(selectedistrict);
                $('#GuaranteeProvince' + componentName).trigger('change', [$('#SelectGuaranteeDistrict' + componentName).val(), $('#SelectGuaranteeSubDistrict' + componentName).val(),]);
            }, 2000);


        }


        $('#frm' + componentName)
            .off('click', '.js--contract')
            .on('click', '.js--contract', function (e) {
                e.preventDefault();
                var url = '/applicant/contract/?id=' + $(this).data('appid') + '&caseid=' + $(this).data('id') + '&depid=' + $(this).data('depid') + '&formid=' + $(this).data('formid');
                //console.log(url);
                window.location.href = url;
            })
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
            })
            .off('change selected', '.js-province')
            .on('change selected', '.js-province', function (e, para, para2) {
                console.log("TestchangeProvince");
                if (typeof para !== "undefined") {
                    console.log(para, para2, "xxxTestparaxxx");
                    if ($(this).attr('id') == "Province" + componentName) { handleChange($(this), setDistrict(para, para2, '')); }
                    if ($(this).attr('id') == "GuaranteeProvince" + componentName) { handleChange($(this), setDistrict(para, para2, 'Guarantee')); }
                } else {
                    console.log("test");
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
            }).off('change', '.js-subdistrict')
            .on('change', '.js-subdistrict', function (e) {
                var el = $(this).closest('.address');
                el.find('.js-postcode').val($(this).find(':selected').data('postcode'));
            });


        $('#frmcontract')
            .off('click', '#next-btn')
            .on('click', '#next-btn', function (e) {
                //var frm = $('frm' + componentName);
                if ($('#frmcontract').validationEngine('validate')) { }
                //var data = {
                //    Location: $('#location' + componentName).val(),
                //    FromDate: $('#FromDate' + componentName).val(),
                //    ProxyTitle: $('#ProxyTitle' + componentName).val(),
                //    ProxyName: $('#ProxyName' + componentName).val(),
                //    ProxyBook: $('#ProxyBook' + componentName).val(),
                //    ProxyDate: $('#ProxyDate' + componentName).val(),
                //}
                //console.log('Data = ', data);

            });


    });

    function handleChange(elem, callback) {

        var el = elem.closest('.address');
        console.log("el", el);
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
    function setDistrict(para, para2, elId) {
        console.log(para, 'xxxx', para2,elId);
        setTimeout(function () {
            $('#' + elId + 'District'+componentName).removeAttr('disabled');
            $('#' + elId + 'District'+componentName).val(para);
            $('#' + elId + 'District'+componentName).trigger('change');
            setSubDistrict(para2, elId);
        }, 2000);
    }
    function setSubDistrict(para, elId) {
        console.log('รหัสตำบล',para)
        setTimeout(function () {
            $('#' + elId + 'SubDistrict'+componentName).removeAttr('disabled');
            $('#' + elId + 'SubDistrict'+componentName).val(para);
        }, 2000);
    }
});