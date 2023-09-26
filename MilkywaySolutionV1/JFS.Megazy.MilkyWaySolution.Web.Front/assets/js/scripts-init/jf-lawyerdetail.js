$(function () {

    var componentName = 'lawyerdetail';

    $("#smartwizard").on("showStep", function (e, anchorObject, stepNumber, stepDirection) {

        if ($('#Approved' + componentName).val() != 0) {
            console.log("Test");
            var wageID = [[4, 5, 6], [7, 8, 9]];
            var amount = $('#Approved' + componentName).val();

            if ($('#formid' + componentName).val() == 6) {
                $('#amount' + componentName + wageID[0][0]).val(amount * 0.3);
                $('#amount' + componentName + wageID[0][1]).val(amount * 0.3);
                $('#amount' + componentName + wageID[0][2]).val(amount * 0.4).trigger('change');                
            }
            else if ($('#formid' + componentName).val() == 7) {
                $('#amount' + componentName + wageID[1][0]).val(amount * 0.3);
                $('#amount' + componentName + wageID[1][1]).val(amount * 0.3);
                $('#amount' + componentName + wageID[1][2]).val(amount * 0.4).trigger('change');
            }
        }

    });
    $("#smartwizard").on("leaveStep", function (e, anchorObject, stepNumber, stepDirection) {

        var formID = $("#form-step-" + stepNumber).find('form').attr('id');
        var frm = $('#' + formID);
        if (stepDirection === 'forward') {
           
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
    

    

    $('#frm' + componentName)
        .off('change', '.js-amount' + componentName)
        .on('change', '.js-amount' + componentName, function (e) {
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
        //.off('change', '.js-wage')
        //.on('change', '.js-wage', function (e) {
        //    console.log("Testjs");
        //    var frm = $(this).closest('form');
        //    var wageID = [[4, 5, 6], [7, 8, 9]];
        //    var amount = $('#Approved' + componentName).val();
        //    console.log(amount);
        //    if ($('#formID' + componentName).val() == 6) {
        //        $('#amount' + componentName + wageID[0][0]).val(amount*0.3);
        //        $('#amount' + componentName + wageID[0][1]).val(amount*0.3);
        //        $('#amount' + componentName + wageID[0][2]).val(amount*0.4);
        //    }
        //    else if ($('#formID' + componentName).val() == 7) {

        //    }

        //})


    
});