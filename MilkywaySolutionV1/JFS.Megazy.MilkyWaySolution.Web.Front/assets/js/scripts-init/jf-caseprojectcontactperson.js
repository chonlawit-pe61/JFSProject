// Begin การไกล่เกลี่ย
$(function () {


    var componentName = 'caseprojectcontactperson';

    function handleChange(elem, callback) {

        var el = elem.closest('.card-body');
        $.ajax({
            url: '/jfservices/address/getdistrictlist',
            method: 'POST',
            data: { id: elem.val() },
            beforeSend: function () { },
            success: function (data) {
                if (data.Status) {

                    var temp = Handlebars.compile($('#tmpl-lisdistrict-' + componentName).html());
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
            $('#district-' + componentName).removeAttr('disabled');
            $('#district-' + componentName).val(para);
            $('#district-' + componentName).trigger('change');
            setSubDistrict(para2);
        }, 1000);
    }
    function setSubDistrict(para) {
        setTimeout(function () {
            $('#subDistrict-' + componentName).removeAttr('disabled');
            $('#subDistrict-' + componentName).val(para);
        }, 1000);
    }


    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#isloadData-' + componentName).val() == 0) {
            //Load data
        $('#isloadData-' + componentName).val(1);
        var frm = $(this).closest('form');
        console.log(frm);
            $.ajax({
                url: '/jfscaseserviceproject/getcaseppojectcontactperson',
                method: 'POST',
                data: { caseID: $('#caseProjectID-' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    console.log(data);

                    var address = data.Data.Address;
                    var contact = data.Data.ProjectContactPerson;
                    $('#contactID-' + componentName).val(contact.ContactID);
                    $('#fname-' + componentName).val(contact.FirstName);
                    $('#lname-' + componentName).val(contact.LastName);
                    $('#telephonNumber-' + componentName).val(contact.TelephoneNo);
                    $('#faxNumber-' + componentName).val(contact.FaxNo);
                    $('#email-' + componentName).val(contact.Email);
                    $('#houseNo-' + componentName).val(address.HouseNo);
                    $('#villageNo-' + componentName).val(address.VillageNo);
                    $('#street-' + componentName).val(address.Street);

                    $('#addressID-' + componentName).val(address.AddressID)
                    $('#province-' + componentName).val(address.ProvinceID);
                    $('#province-' + componentName).next('.select2').find('.select2-selection__rendered').html($('#province-' + componentName + ' option:selected').text());
                    if (address.DisctrictID > 0) {
                     $('#province-' + componentName).trigger('change', [address.DisctrictID, address.SubdistrictID]);
                    }
                    
                    $('#postCode-' + componentName).val(address.PostCode);

                }
                , error: function (err) {
                    console.log(err);
                }
            });

        } else { console.log('default')}
    });
    //Card 
    //Common.CollapsedCard(this);
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) {
        Common.swcithTabIcon(this);
    });


    $('#frm' + componentName)
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
                    if (data.Status) {
                        var temp = Handlebars.compile($('#tmpl-lissubdistrict-' + componentName).html());
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
        .off('keyup', '.js-text')
        .on('keyup', '.js-text', function (e) {
            var frm = $(this).closest('form');
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
                
                //ผู้ประสานงานโครงการ
                var projectContactPersonData = {

                    ProjectContactPerson: {
                        ContactID: $('#contactID-' + componentName).val(),
                        FirstName: $('#fname-' + componentName).val(),
                        FirstName: $('#fname-' + componentName).val(),
                        LastName: $('#lname-' + componentName).val(),
                        Email: $('#email-' + componentName).val(),
                        TelephoneNo: $('#telephonNumber-' + componentName).val(),
                        FaxNo: $('#faxNumber-' + componentName).val(),
                    },

                    AddressRow: {
                        AddressID: $('#addressID-' + componentName).val(),
                        HouseNo: $('#houseNo-' + componentName).val(),
                        VillageNo: $('#villageNo-' + componentName).val(),
                        Street: $('#street-' + componentName).val(),
                        ProvinceID: $('#province-' + componentName).val(),
                        DisctrictID: $('#district-' + componentName).val(),
                        SubdistrictID: $('#subDistrict-' + componentName).val(),
                        PostCode: $('#postCode-' + componentName).val()
                    }
                }


                        $.ajax({
                            url: '/jfscaseserviceproject/saveprojectcontactperson',
                            method: 'POST',
                            data: {
                                req: projectContactPersonData,
                                caseID: $('#caseProjectID-' + componentName).val()
                            },
                            beforeSend: function () { },
                            success: function (data) {
                                console.log(data);
                                if (data.Status) {
                                    $('#applicantID' + componentName).val(data.ID);
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
              }

        });



});
