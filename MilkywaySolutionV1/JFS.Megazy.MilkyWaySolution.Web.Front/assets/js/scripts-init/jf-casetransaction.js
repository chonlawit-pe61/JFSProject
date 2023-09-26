// Begin การไกล่เกลี่ย
$(function () {



    var componentName = 'casetransaction';


    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#isloadData-' + componentName).val() == 0) {
            //Load data
            $('#isloadData-' + componentName).val(1);
            var frm = $(this).closest('form');

            $.ajax({
                url: '/transaction/getcasetransaction',
                method: 'POST',
                data: {
                    caseID: $('#caseID' + componentName).val(),
                    applicantID: $('#applicantID' + componentName).val()
                },
                beforeSend: function () { },
                success: function (data) {


                    console.log('getcasetransaction');
                    console.log(data);

                    $('#box-' + componentName).html('');
                    if (data.Data != null) {
                        var temp = Handlebars.compile($('#tmpl-casetransaction').html());

                        var status = "";

                        $.each(data.Data, function (key, value) {

                           
                            if (value.TransactionStatusID == 1) {
                                status = "รอส่งให้ผ่านการเงิน";
                            } else if (value.TransactionStatusID == 2) {
                                status = "รอการอนุมัติจากฝ่ายการเงิน";
                            } else {
                                status = "อนุมัติแล้ว";
                            }

                            var dataItem = { value: value, status: status };

                            $('#box-' + componentName).append(temp(dataItem));
                        });



                    }
                }
                , error: function (err) {
                    console.log(err);
                }
            });



        } else {
            console.log('default')
        }




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

        .off('click', '#js--cancel' + componentName)
        .on('click', '#js--cancel' + componentName, function (e) {
            e.preventDefault();
            var frm = $(this).closest('form');
            $('.js--btsave' + componentName).hide();
            frm.find('#frm-create-transaction').hide(500);
        })
        .off('click', '#btn-add-transaction')
        .on('click', '#btn-add-transaction', function (e) {
            e.preventDefault();
            $('#frm-create-transaction').show(500);
            $('#transactionType').focus();
            $('.js--btsave' + componentName).show();
        })        //.off('ifChecked', 'input[name="ckCharacter"]')
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


            //if ($(this).data('isother') == "True") {

            //    var id = $(this).val();

            //    $('.divOtherDocument').toggle();
            //    $('#box-document-' + id).append($('.divOtherDocument'));
            //}

        })

        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {

            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {

                //$('#sourceFundKey-' + index).val(value.SourceFundID);

                        //เอกสารโครงการ
                        var transactionData = {
                            //TransactionType: $('#transactionType' + componentName).val(),
                            RefApplicantID : $('#applicantID' + componentName).val(),
                            RefCaseID: $('#caseID' + componentName).val(),
                            RefContractID: $('#refContractID' + componentName).val(),
                            TotalAmount: $('#totalAmount' + componentName).val(),
                            Note: $('#note' + componentName).val(),
                            //CreateDateStr: $('#createDate' + componentName).val()
                        }

                        
                        $.ajax({
                            url: '/transaction/savecasetransaction',
                            method: 'POST',
                            data: {
                                data: transactionData
                            },
                            beforeSend: function () { },
                            success: function (data) {
                                console.log(data);
                                if (data.Status) {
                                    //$('#applicantID' + componentName).val(data.ID);
                                    SWSuccess.fire();
                                    window.location.href = "/transaction/index?transactionID=" + data.DataID;
                                }
                            }
                            , error: function (err) {
                                if (err.status == 401) {
                                    window.location.reload();
                                }
                            }
                        });

                        //frm.find('.js--btsave' + componentName).hide();
                        //frm.find('.js--cancel').hide();
                  
            }

        });



});
