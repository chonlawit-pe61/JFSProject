$(function () {
    var componentName = 'projectdetailcontract';
    
    $("#smartwizard").on("leaveStep", function (e, anchorObject, stepNumber, stepDirection) {

        var formID = $("#form-step-" + stepNumber).find('form').attr('id');
        var frm = $('#' + formID);
        if (stepDirection === 'forward') {
            console.log("SumAmount");
            console.log(formID);
            console.log(componentName);
            var status = frm.validationEngine('validate');
            var approved = parseFloat($('#Approved' + componentName).val());
            var amountsum = parseFloat($('#amountsum' + componentName).val());
            if (approved != amountsum && formID === ('frm' + componentName)) {
                
                SWMoney.fire({
                    onClose: () => {
                        
                    }
                });
                return false;
                
            }
            else {

                return true;
            }
        }


    });
    $("#smartwizard").on("showStep", function (e, anchorObject, stepNumber, stepDirection) {

        $.ajax({
            url: '/jfservices/getwage',
            method: 'POST',
            data: {

                applicantID: $('#applicantID' + componentName).val(),
                caseID: $('#caseID' + componentName).val(),
                formID: 29,

            },
            beforeSend: function () {
            },
            success: function (data) {

                console.log(data);

                if (data.Status) {
                  
                    $.each(data.Data, function (key, value) {
                        $('#amount' + componentName + value.WangeID).val(value.Amount).trigger('change');
                    });
                }
               

            }, error: function (err) {
                if (err.status == 401) {
                    window.location.reload();
                }
               
            }
        });


    });

    $('#frm' + componentName)
        .off('change', '.js-amount'+componentName)
        .on('change', '.js-amount'+componentName, function (e) {
            var frm = $(this).closest('form');

            var totalamount = 0;
            $('input[name=amount' + componentName + ']').map(function (e) {
                //console.log($(this));                
                    var amount = parseFloat($(this).val().replace(/,/g, ''));
                    if (amount != NaN && amount > 0) {
                        totalamount = parseFloat(totalamount) + parseFloat(amount);
                    }

                
            });

            //console.log("amount = ",amount);
            console.log("totalamount = ", totalamount);

            $('#amountsum' + componentName).val(Common.formatNumber(totalamount));

        })




});