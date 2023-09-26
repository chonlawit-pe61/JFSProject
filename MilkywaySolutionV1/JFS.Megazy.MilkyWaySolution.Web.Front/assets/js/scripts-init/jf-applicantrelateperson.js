$(function () {

    var componentName = 'applicantrelateperson';

    //Get Data
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if (!$(':radio[name=rdosex'+componentName+']').is(':checked') && $('#applicantID' + componentName).val() != 0) {
            //Load data
            $.ajax({
                url: '/jfservices/getapplicantrelatedperson',
                method: 'POST',
                data: {
                    applicantID: $('#applicantID' + componentName).val(),
                    caseID: $('#caseID' + componentName).val(),
                },
                beforeSend: function () { },
                success: function (data) {
                    if (data.Status) {
                        var frm = $('#frm' + componentName);
                        var relate = ["", 'Second'];
                        for (var i = 0; i < relate.length; i++) {
                            //Person
                            $('#' + relate[i] + 'contactpersonID' +componentName).val(data.Data.Person[i].PersonID);
                            $('#' + relate[i] + 'Title' + componentName).val(data.Data.Person[i].Title).trigger('change');
                            $('#' + relate[i] + 'FirstName' + componentName).val(data.Data.Person[i].FirstName);
                            $('#' + relate[i] + 'LastName' + componentName).val(data.Data.Person[i].LastName);
                            $(':radio[name=' + relate[i]+'rdosex' + componentName + '][value=' + data.Data.Person[i].GenderCode + ']').iCheck('check');
                            
                           //Address
                            $('#' + relate[i] + 'addressID'+componentName).val(data.Data.Address[i].AddressID);
                            $('#' + relate[i] + 'HouseNo'+componentName).val(data.Data.Address[i].HouseNo);
                            $('#' + relate[i] + 'VillageNo'+componentName).val(data.Data.Address[i].VillageNo);
                            $('#' + relate[i] + 'Soi'+componentName).val(data.Data.Address[i].Soi);
                            $('#' + relate[i] + 'Street' + componentName).val(data.Data.Address[i].Street);
                            $('#' + relate[i] + 'Province' + componentName).val(data.Data.Address[i].ProvinceID).trigger('change', [data.Data.Address[i].DisctrictID, data.Data.Address[i].SubdistrictID]);
                            //setDistrictPerson(data.Data.Address[i].DistrictID, data.Data.Address[i].SubDistrictID, relate[i])
                            //$('#' + relate[i] + 'Province' + componentName).next('.select2').find('.select2-selection__rendered').html($('#' + relate[i] + 'Province' + componentName+ ' option:selected').text());
                            //if (data.Data.Address[i].DistrictID != "") {
                            //    $('#' + relate[i] + 'Province' + componentName).trigger('change', [data.Data.Address[i].DisctrictID, data.Data.Address[i].SubdistrictID]);
                            //}
                            
                            $('#' + relate[i] + 'PostCode' + componentName).val(data.Data.Address[i].PostCode);
                           

                            //Relate
                            $('#' + relate[i] + 'TelephonNumber' + componentName).val(data.Data.Relate[i].TelephoneNumber);
                            $('#' + relate[i] + 'RelatedAs' + componentName).val(data.Data.Relate[i].RelatedAs);

                            if (data.Data.Address.length == 1 && data.Data.Person.length == 1 && data.Data.Relate.length ==1) {
                                break;
                            }
                            else {
                                frm.find('.wrap-relatedSecond').show();
                                frm.find('.js--addrelate'+componentName).hide();
                                frm.find('.js--deleterealate'+componentName).show();
                            }
                        }
                       
                        
                    }
                }
                , error: function (err) {
                    console.log(err);
                }
            });

        }
    });

    //Card 
    //Common.CollapsedCard(this);
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) { Common.swcithTabIcon(this); });
    if ($('#SelectedDistrict'+componentName).val() != "0") {
        $('#Province'+componentName).trigger('change', [$('#SelectedDistrict'+componentName).val(), $('#SelectedSubDistrict'+componentName).val()]);
    }
    if ($('#SelectedSecondDistrict'+componentName).val() != "0") {
        $('#SecondProvince' + componentName).trigger('change', [$('#SelectedSecondDistrict'+componentName).val(), $('#SelectedSecondSubDistrict'+componentName).val()]);
    }

    $('#frm' + componentName)
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
                
                if ($(this).attr('id') == "Province" + componentName) { handleChange($(this), setDistrictPerson(para, para2, '')); }
                if ($(this).attr('id') == "SecondProvince" + componentName) { handleChange($(this), setDistrictPerson(para, para2, 'Second')); }
                
            } else {
                handleChange($(this));
            }
        })
        .off('change', '.js-district')
        .on('change', '.js-district', function (e) {
            var el = $(this).closest('.address');
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
            var el = $(this).closest('.address');
            el.find('.js-postcode').val($(this).find(':selected').data('postcode'));
        })
        .off('keyup change ifChecked', '.js-text')
        .on('keyup change ifChecked', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        .off('click', '.js--addrelate'+componentName)
        .on('click', '.js--addrelate' + componentName, function (e) {
            var frm = $('#frm' + componentName);
            $('.wrap-relatedSecond').show();
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
            frm.find('.js--deleterealate' + componentName).show();
            $('.js--addrelate' + componentName).hide();
            $('#isdelete' + componentName).val(0);
        })
        .off('click', '.js--deleterealate' + componentName)
        .on('click', '.js--deleterealate' + componentName, function (e) {
            var frm = $('#frm' + componentName);
            $('.wrap-relatedSecond').hide();
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
            $('.js--deleterealate' + componentName).hide();
            frm.find('.js--addrelate' + componentName).show();

            //if ($(':radio[name=Secondrdosex' + componentName + ']').is(':checked')) {                
            //    $(':radio[name=Secondrdosex' + componentName + ']:checked').iCheck('uncheck');
            //}

            //$('#SecondTitle' + componentName).val('');
            //$('#SecondFirstName' + componentName).val('');
            //$('#SecondLastName' + componentName).val('');
            //$('#SecondHouseNo' + componentName).val('');
            //$('#SecondVillageNo' + componentName).val('');
            //$('#SecondSoi' + componentName).val('');
            //$('#SecondStreet' + componentName).val('');
            //$('#SecondProvince' + componentName).val(0).trigger('change', 0, 0);
            //$('#SecondDistrict' + componentName).prop("disabled", true);
            //$('#SecondSubDistrict' + componentName).prop("disabled", true);
            //$('#SecondTelephonNumber' + componentName).val('');
            //$('#SecondRelatedAs' + componentName).val('');
            //$('#SecondPostCode' + componentName).val('');
            //$('#SelectedSecondDistrict' + componentName).val(0);
            //$('#SelectedSecondSubDistrict' + componentName).val(0);
            //$('#isdelete' + componentName).val(1);

            
        })
        // Save Data
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {
            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {
                var relate = ['#', '#Second'];
                var arrRelated = ['', 'Second'];
                var ArrayContactPersonDataRequest = [];
                for (var i = 0; i < relate.length; i++) {
                    if ($(".wrap-related" + arrRelated[i]).is(":visible")) {
                        // if ($(relate[i] + 'Title' + componentName).val() != "") { }
                        var ContactPersonDataRequest = {};
                        ContactPersonDataRequest.RelatedPersonData = {
                            ContactPersonID: $(relate[i] + 'contactpersonID' + componentName).val(),
                            CaseID: $('#caseID' + componentName).val(),
                            ApplicantID: $('#applicantID' + componentName).val(),
                            PersonRoleID: 1,
                            TelephoneNumber: $(relate[i] + 'TelephonNumber' + componentName).val(),
                            RelatedAs: $(relate[i] + 'RelatedAs' + componentName).val(),
                            AddressID: $(relate[i] + 'addressID' + componentName).val(),
                        }
                        ContactPersonDataRequest.PersonData = {
                            PersonID: $(relate[i] + 'contactpersonID' + componentName).val(),
                            Title: $(relate[i] + 'Title' + componentName).val(),
                            FirstName: $(relate[i] + 'FirstName' + componentName).val(),
                            LastName: $(relate[i] + 'LastName' + componentName).val(),
                            GenderCode: $(':radio[name=' + arrRelated[i] + 'rdosex' + componentName + ']:checked').val(),
                        }
                        ContactPersonDataRequest.AddressData = {
                            AddressID: $(relate[i] + 'addressID' + componentName).val(),
                            HouseNo: $(relate[i] + 'HouseNo' + componentName).val(),
                            VillageNo: $(relate[i] + 'VillageNo' + componentName).val(),
                            Soi: $(relate[i] + 'Soi' + componentName).val(),
                            Street: $(relate[i] + 'Street' + componentName).val(),
                            ProvinceID: $(relate[i] + 'Province' + componentName).val(),
                            DisctrictID: $(relate[i] + 'District' + componentName).val(),
                            SubdistrictID: $(relate[i] + 'SubDistrict' + componentName).val(),
                            PostCode: $(relate[i] + 'PostCode' + componentName).val(),
                        }
                        ArrayContactPersonDataRequest.push(ContactPersonDataRequest);
                    }
                }              

                $.ajax({
                    url: '/jfservices/saveapplicantrelatedperson',
                    method: 'POST',
                    data: {
                        caseID: $('#caseID' + componentName).val(),
                        applicantID: $('#applicantID' + componentName).val(),
                        req: ArrayContactPersonDataRequest
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            if (data.Data.length) {
                                for (var i = 0; i < data.Data.length; i++) {
                                    $(relate[i] + 'contactpersonID' + componentName).val(data.Data[i].PersonID);
                                    $(relate[i] + 'addressID' + componentName).val(data.Data[i].AddressID);
                                }
                            }
                            SWSuccess.fire();
                        }
                    }, error: function (err) {
                        console.log(err);
                        if (err.status == 401) {
                            window.location.reload();
                        }
                    }
                })
                frm.find('.js--btsave' + componentName).hide();
                frm.find('.js--cancel').hide();
                frm.find('.header-icon').remove();
            }
        })       

    function handleChange(elem, callback) {

        var el = elem.closest('.address');
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

    function setDistrictPerson(para, para2, elId) {
        // console.log(para, 'xxxx', para2,elId);
        setTimeout(function () {
            $('#' + elId + 'District' +componentName).removeAttr('disabled');
            $('#' + elId + 'District'+componentName).val(para);
            $('#' + elId + 'District'+componentName).trigger('change');
            setSubDistrictPerson(para2, elId);
        }, 2000);
    }
    function setSubDistrictPerson(para, elId) {
        //console.log('รหัสตำบล',para)
        setTimeout(function () {
            $('#' + elId + 'SubDistrict'+componentName).removeAttr('disabled');
            $('#' + elId + 'SubDistrict'+componentName).val(para);
        }, 2000);
    }


});