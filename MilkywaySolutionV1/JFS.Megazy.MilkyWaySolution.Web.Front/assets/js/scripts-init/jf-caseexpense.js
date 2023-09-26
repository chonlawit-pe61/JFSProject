// Begin การไกล่เกลี่ย
$(function () {

    var componentName = 'caseexpense';



    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        var frm = $('#frm' + componentName);
        if ((!$(':radio[name=rdohelpcaselevel]').is(':checked')) && $('#applicantID' + componentName).val() != 0) {
            //Load data
            $.ajax({
                url: '/jfscaseexpense/getcaseexpense',
                method: 'POST',
                data: { applicantID: $('#applicantID' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    console.log(data);
                    $.each(data.Data.ExpenseRow, function (index, datas) {
                        $('#Expense' + componentName + datas.ExpenseID).iCheck('check');
                    });
                    //$('#applicantID' + componentName).val(data.Data.ApplicantID);
                    //$('#caseID' + componentName).val(data.Data.CaseID);
                    if (data.Data.CaseExpenseOtherRow != null) {
                        $('#expenseOther').show();
                        $('#OtherExpense' + componentName).val(data.Data.CaseExpenseOtherRow.ExpenseOther);
                    }
                    //$('input[name=radioName]:checked')
                    frm.find('.js--btsave' + componentName).hide();
                    frm.find('.js--cancel').hide();
                }
                , error: function (err) {
                    console.log(err);
                }
            });

        } else { console.log('default') }
    });
    //Card 
    //Common.CollapsedCard(this);
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) { Common.swcithTabIcon(this); });


    $('#frm' + componentName)
        .off('keyup', '.js-text')
        .on('keyup', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('ifChecked', ':checkbox[name=ckExpensecaseexpense]')
        .on('ifChecked', ':checkbox[name=ckExpensecaseexpense]', function (e) {

            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
            if ($(this).data('interval') == 'True') {

                $('#expenseOther').removeClass('d-none');
            }
            else {
                $('#expenseOther').addClass('d-none');
            }
        })
        .off('ifUnchecked', ':checkbox[name=ckExpensecaseexpense]')
        .on('ifUnchecked', ':checkbox[name=ckExpensecaseexpense]', function (e) {

            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
            if ($(this).data('interval') == 'True') {
                $('#OtherExpense' + componentName).val(null);
                $('#expenseOther').addClass('d-none');

            }

        })
        .off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {
            //console.log('Test');
            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {

                //console.log('#caseID').val();
                var caseExpense = [];
                var documentCheck = $('input[name="ckExpense' + componentName + '"]:checked');

                documentCheck.each(function () {
                    var expenseID = this.value;
                    //console.log("ExpenseID = ",expenseID);
                    caseExpense.push({
                        CaseID: $('#caseID' + componentName).val(),
                        ExpenseID: $('#Expense' + componentName + expenseID).val(),
                        ApplicantID: $('#applicantID' + componentName).val(),
                    });
                });
                console.log(caseExpense);
                var caseExpenseOther = {
                    CaseID: $('#caseID' + componentName).val(),
                    ExpenseOther: $('#OtherExpense' + componentName).val(),
                    ApplicantID: $('#applicantID' + componentName).val(),
                }
                console.log(caseExpenseOther);

                $.ajax({
                    url: '/jfscaseexpense/savecaseexpensedata',
                    method: 'POST',
                    data: {
                        caseExpense: caseExpense,
                        applicantID: $('#applicantID' + componentName).val(),
                        caseExpenseOther: caseExpenseOther
                    },
                    beforeSend: function () {
                    },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            //$('#applicantID' + componentName).val(data.ID);

                            SWSuccess.fire({
                                onClose: () => { }
                            });
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
                frm.find('.header-icon').remove();
            }

        });



});
