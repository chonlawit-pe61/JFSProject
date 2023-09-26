// Begin การไกล่เกลี่ย
$(function () {


    

    var componentName = 'caseprojectcharacteristics';
    

    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#isloadData-' + componentName).val() == 0) {
            //Load data
        $('#isloadData-' + componentName).val(1);
        //var frm = $(this).closest('form');
        //console.log(frm);
            $.ajax({
                url: '/jfscaseserviceproject/getcaseprojectcharacteristics',
                method: 'POST',
                data: { caseID: $('#caseProjectID-' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {


                    console.log('getcaseprojectcharacteristics');
                    console.log(data);
                    
                        //$('#postCode-' + componentName).val(address.PostCode);
                    if (data.Data != null) {

                        $.each(data.Data, function (key, value) {
                            //CharacteristicID
                            $('input[name=ckCharacter]').filter('#ckCharacter' + value.CharacteristicID).iCheck('check');
                            if (value.Remark) {
                                console.log(value.Remark);
                                $('#OtherCharacter').val(value.Remark);
                                $('.divOtherCharacter').show();
                                $('.divOtherCharacter').appendTo('#box-characteristics-' + value.CharacteristicID);
                                
                            }
                        });
                        var frm = $('#frm' + componentName);
                        frm.find('.js--btsave' + componentName).hide();
                        frm.find('.js--cancel').hide();
                    }


                    //$('input:radio[name=rdoProposerType]').filter('#rdoProposerType' + caseProject.ProposerTypeID).iCheck('check');

              
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
        var frm = $(this).closest('form');
        frm.find('.js--btsave' + componentName).hide();
        frm.find('.js--cancel').hide();
    });

    $('#frm' + componentName)
        
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
        .off('ifChecked', 'input[name="ckCharacter"]')
        .on('ifChecked', 'input[name="ckCharacter"]', function (e) {


            if ($(this).val() == 4) {
                var id = $(this).val();
                $('.divOtherCharacter').toggle();
                $('.divOtherCharacter').appendTo('#box-characteristics-' + id);
            }

        })

        .off('ifUnchecked', 'input[name="ckCharacter"]')
        .on('ifUnchecked', 'input[name="ckCharacter"]', function (e) {


            if ($(this).val() == 4) {

                $('.divOtherCharacter').val('').hide();

            }

        })
        
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {
          
            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {

                //$('#sourceFundKey-' + index).val(value.SourceFundID);

                        //ลักษณะโครงการที่ขอรับเงิน
                        var caseProjectCharacteristicsData = [];
                        var characteristics = $('input[name="ckCharacter"]:checked');
                        characteristics.each(function () {
                            caseProjectCharacteristicsData.push({
                                CharacteristicID: parseInt(this.value),
                                Remark: parseInt(this.value) == 4 ? $('#OtherCharacter').val() : ""
                            })
                        });
                        
                        $.ajax({
                            url: '/jfscaseserviceproject/savecaseprojectcharacteristics',
                            method: 'POST',
                            data: {
                                req: caseProjectCharacteristicsData,
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
