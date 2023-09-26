$(function () {
    var componentName = 'lawyerselect';

    $("#smartwizard").on("showStep", function (e, anchorObject, stepNumber, stepDirection) {
        //Enable finish button only on last step
        var done = $("#form-step-" + stepNumber).data('done');
        console.log("TestStepFist");

        if ((stepNumber == 3 || stepNumber == 4) && done == 1) {
            $('#next-btn').attr("disabled", true);
            $('#next-btn').html('เสร็จสิ้น');

        } else {
            $('#next-btn').attr("disabled", false);
            $('#next-btn').html('ถัดไป');
        }
        if (stepNumber == 0) {
            $('#prev-btn').attr("disabled", true);
            $('#prev-btn').addClass('d-none');

        }
        else {
            $('#prev-btn').attr("disabled", false);
            $('#prev-btn').removeClass('d-none');
        }
    });
   
    $('#frm' + componentName)
        .off('click', '.js--lawyer')
        .on('click', '.js--lawyer', function (e) {
            e.preventDefault();
            var url = '/applicant/lawyercaseselect/?id=' + $(this).data('appid') + '&caseid=' + $(this).data('id') + '&depid=' + $(this).data('depid') + '&formid=' + $(this).data('formid');
            //console.log(url);
            window.location.href = url;
        })
        .off('click', '.js--contract')
        .on('click', '.js--contract', function (e) {
            e.preventDefault();
            var url = '/applicant/contract/?id=' + $(this).data('appid') + '&caseid=' + $(this).data('id') + '&depid=' + $(this).data('depid') + '&formid=' + $(this).data('formid');
            console.log(url);
            window.location.href = url;
        })
        
});