// Begin การไกล่เกลี่ย
$(function () {


    var componentName = 'caseprojectapplicant';


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
                url: '/jfscaseserviceproject/getcaseppojectapplicant',
                method: 'POST',
                data: { caseID: $('#caseProjectID-' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    console.log(data);
                    if (data.Data != null) {

                        var caseApplicant = data.Data.CaseApplicantRow;
                        var caseProject = data.Data.CaseProjectRow;
                        var projectAddress = data.Data.ProjectAddressData.ProjectAddress;
                        var address = data.Data.ProjectAddressData.Address;

                        //caseApplicant
                        $('#applicantID-' + componentName).val(caseApplicant.ApplicantID);
                        $('#firstName-' + componentName).val(caseApplicant.FirstName);
                        $('#lastName-' + componentName).val(caseApplicant.LastName);
                        $('#title-' + componentName).val(caseApplicant.Title);

                        if (caseApplicant.Gender == 'M') {

                            $('#rdomale-' + componentName).iCheck('check');
                        } else {
                            $('#rdofemale-' + componentName).iCheck('check');
                        }
                        
                        //caseProject
                        $('#proposerEN').val(caseProject.ProposerEN);
                        $('input:radio[name=rdoProposerType]').filter('#rdoProposerType' + caseProject.ProposerTypeID).iCheck('check');
                        if (caseProject.ProposerTypeOther != null || caseProject.ProposerTypeOther != '') {
                            $('#divOtherProposerType').show();
                            $('#otherProposerType').val(caseProject.ProposerTypeOther);
                        }


                        
                        //projectAddress
                        $('#telephonNumber-' + componentName).val(projectAddress.TelephoneNo);
                        $('#faxNumber-' + componentName).val(projectAddress.FaxNo);
                        $('#email-' + componentName).val(projectAddress.Email);

                        //address
                        $('#addressID-' + componentName).val(address.AddressID)
                        $('#houseNo-' + componentName).val(address.HouseNo);
                        $('#villageNo-' + componentName).val(address.VillageNo);
                        $('#street-' + componentName).val(address.Street);
                        $('#province-' + componentName).val(address.ProvinceID);
                        $('#province-' + componentName).next('.select2').find('.select2-selection__rendered').html($('#province-' + componentName + ' option:selected').text());
                        if (address.DisctrictID > 0) {
                            $('#province-' + componentName).trigger('change', [address.DisctrictID, address.SubdistrictID]);
                        }

                        $('#postCode-' + componentName).val(address.PostCode);

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
        .off('ifChecked', ':radio[name=rdoProposerType]')
        .on('ifChecked', ':radio[name=rdoProposerType]', function (e) {
            //var frm = $(this).closest('form');
            if ($(this).val() == 7) {
                $('.divOtherProposerType').show();
            } else {
                $('.divOtherProposerType').hide().val('');
            }
            //frm.find('.js--cancel').show();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {
          
            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {
                
                //ผู้ขอ
                var caseApplicantData = {
                    ApplicantID: $('#applicantID-' + componentName).val(),
                    Gender: $('.checked input[name="rdosex-' + componentName +'"]').val(),
                    Title: $('#title-' + componentName).val(),
                    FirstName: $('#firstName-' + componentName).val(),
                    LastName: $('#lastName-' + componentName).val(),
                }//หนึ่งคดีมีได้หลายคน

                var caseProjectData = {
                    ProposerTypeID: $('.checked input[name="rdoProposerType"]').val(),
                    ProposerTypeOther: $('#otherProposerType').val(),
                    ProposerEN: $('#ProposerEN').val() //ชื่อผู้เสนอโครงการ(ภาษาอังกฤษ)
                  
                }

                //ที่อยู่
                var projectAddressData = {

                    ProjectAddress: {
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
                    },
                }

                var data = {
                    CaseApplicantData: caseApplicantData,
                    CaseProjectData: caseProjectData,
                    ProjectAddressData: projectAddressData
                }

                        $.ajax({
                            url: '/jfscaseserviceproject/savecaseprojectapplicant',
                            method: 'POST',
                            data: {
                                req: data,
                                caseID: $('#caseProjectID-' + componentName).val()
                            },
                            beforeSend: function () { },
                            success: function (data) {
                                console.log(data);
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
                   
            }

        });



});
