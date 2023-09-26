
$(function () {

    var componentName = 'allocatebudget';
    $(document).ready(function () {
        
        $('#cd' + componentName).on('show.bs.collapse', function () {
            $('#totalamount' + componentName).text(SumAmount())
        })
        $('#frm' + componentName)
            .off('click', '#btsave' + componentName)
            .on('click', '#btsave' + componentName, function () {
                const $this = $(this);
                const lastlen = $('#td' + componentName).find('tbody tr').length - 1;
                const caseID = $('#caseID' + componentName).val();
                const applicantID = $('#applicantID' + componentName).val();
                $('#text' + componentName).val($('#result' + componentName).val())
                var expense = [];
                var expenseEx = [];
                let check = 1;
                $('#td' + componentName).find('tbody tr').each(function (i) {
                    if ($(this).find('.js--pricethreshold' + componentName).val() != '' && $(this).find('.js--unit' + componentName).val() != '') {
                        expense.push({
                            CaseID: caseID,
                            ApplicantID: applicantID,
                            ExpenseID: $(this).data('id')
                        });
                        expenseEx.push({
                            CaseID: caseID,
                            ApplicantID: applicantID,
                            ExpenseID: $(this).data('id'),
                            PriceThreshold: $(this).find('.js--pricethreshold' + componentName).val(),
                            Unit: $(this).find('.js--unit' + componentName).val(),
                            Amount: parseFloat($(this).find('.js--amount' + componentName).text().replace(',', '')),
                            Remark: $(this).find('.js--remark' + componentName).val()
                        });
                    }

                    if (lastlen == (check)) {
                        return false;
                    }
                    check++;
                })
                
                var req = {
                    ExpenseEx: expenseEx,
                    Expense: expense
                }
                //console.log(req)
                SWConfirm.fire().then((result) => {
                    if (result.value) {
                        $.ajax({
                            url: '/form/saveexpense',
                            method: 'POST',
                            data: { req: req },
                            beforeSend: function () { },
                            success: function (data) {
                                console.log(data)
                                if (data.Status) {
                                    SWSuccess.fire({
                                        onClose: () => {
                                            $this.closest('.form-row').find('.js--btsave').hide();
                                            $this.closest('.form-row').find('.js--cancel').hide();
                                        }
                                    });
                                }
                            }
                            , error: function (err) {
                                console.log(err);
                            }
                        });
                    }
                });
            })
            .off('keyup', '.js--unit' + componentName + ', .js--pricethreshold' + componentName)
            .on('keyup', '.js--unit' + componentName + ', .js--pricethreshold' + componentName, function () {
                const $this = $(this);
                let pricethreshold = $this.closest('tr').find('.js--pricethreshold' + componentName).val();
                let unit = $this.closest('tr').find('.js--unit' + componentName).val();
                let result = (pricethreshold == '' ? 0 : pricethreshold) * (unit == '' ? 0 : unit);

                $this.closest('tr').find('.js--amount' + componentName).text(Common.formatNumber(result));
                setTimeout(function () { $('#totalamount' + componentName).text(SumAmount()); }, 200);
                
            })
    })
    function SumAmount() {
        const lastlen = $('#td' + componentName).find('tbody tr').length - 1;
        let check = 1;
        let result = 0;
        
        $('#td' + componentName).find('tbody tr').each(function (i) {
            result += parseFloat(concatnumber($(this).find('.js--amount' + componentName).text()));
            if (lastlen == (check)) {
                return false;
            }
            check ++;
        })
        return Common.formatNumber(result);
    }
    function concatnumber(numstr) {
        let arr = numstr.split(',');
        let num = '';
        $.each(arr, function (i, v) {
            num += v;
        })
        return num;
    }
});

