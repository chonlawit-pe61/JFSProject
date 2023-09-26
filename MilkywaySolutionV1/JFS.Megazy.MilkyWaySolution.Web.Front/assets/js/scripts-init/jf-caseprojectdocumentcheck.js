// Begin การไกล่เกลี่ย
$(function () {




    var componentName = 'caseprojectdocumentcheck';


    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#isloadData-' + componentName).val() == 0) {
            //Load data
            $('#isloadData-' + componentName).val(1);
            var frm = $(this).closest('form');
            //console.log(frm);
            $.ajax({
                url: '/jfscaseserviceproject/getcaseprojectdocumentcheck',
                method: 'POST',
                data: { caseID: $('#caseProjectID-' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {


                    console.log('getcaseprojectdocumentcheck');
                    console.log(data);


                    if (data.Data != null) {

                        $.each(data.Data, function (key, value) {
                            //CharacteristicID
                            $('input[name=ckDocument]').filter('#ckDocument' + value.DocumentID).iCheck('check');
                            if (value.Remark) {
                                console.log(value.Remark);
                                $('#divOtherDocument').val(value.Remark);
                                $('.divOtherDocument').show();
                                $('.divOtherDocument').appendTo('#box-document-' + value.DocumentID);

                            }
                        });

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
        //.off('ifChecked', 'input[name="ckCharacter"]')
        //.on('ifChecked', 'input[name="ckCharacter"]', function (e) {


        //    if ($(this).val() == 4) {
        //        var id = $(this).val();
        //        $('.divOtherCharacter').toggle();
        //        $('.divOtherCharacter').appendTo('#box-characteristics-' + id);
        //    }

        //})

        //.off('ifUnchecked', 'input[name="ckCharacter"]')
        //.on('ifUnchecked', 'input[name="ckCharacter"]', function (e) {


        //    if ($(this).val() == 4) {

        //        $('.divOtherCharacter').val('').hide();

        //    }

        //})
        .off('ifClicked', 'input[name="ckDocument"]')
        .on('ifClicked', 'input[name="ckDocument"]', function (e) {


            if ($(this).data('isother') == "True") {

                var id = $(this).val();

                $('.divOtherDocument').toggle();
                $('#box-document-' + id).append($('.divOtherDocument'));
            }

        })

        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {

            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {

                //$('#sourceFundKey-' + index).val(value.SourceFundID);

                        //เอกสารโครงการ
                        var caseProjectDocumentCheckData = [];
                        var documentCheck = $('input[name="ckDocument"]:checked');

                        documentCheck.each(function () {
                            var isother = $(this).data('isother');
                            var passIsother = JSON.parse(isother.toLowerCase());
                            caseProjectDocumentCheckData.push({
                                DocumentID: this.value,
                                Remark: passIsother ? $('#divOtherDocument').val() : "",
                            });
                        });

                        

                        $.ajax({
                            url: '/jfscaseserviceproject/savecaseprojectdocumentcheck',
                            method: 'POST',
                            data: {
                                req: caseProjectDocumentCheckData,
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
