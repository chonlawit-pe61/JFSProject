
// ส่วนหัวของการขอรับความช่วยเหลือ
$(function () {

    // var componentName = 'caseheader';
    $('#department').trigger('change');
    $('body')
        .off('change', '#caseCategory')
        .on('change', '#caseCategory', function (e) {
            $.ajax({
                url: '/jfservices/category/getcasesubcategory',
                method: 'POST',
                data: { id: $(this).val() },
                beforeSend: function () { },
                success: function (data) {
                    //if (data.Status) {
                    //    $('#casesubCategory').html('<option value="" disabled selected>เลือก</option>');
                    //    $.each(data.Data, function (i, item) {
                    //        $('#casesubCategory').append('<option value="' + item.CaseSubCategoryID + '">' + item.CaseSubCategoryName + '</option>');
                    //    });
                    //}
                    console.log("test");
                    console.log(data);

                    if (data.Status) {
                        if (data.Data.length != 0) {
                            var temp = Handlebars.compile($('#tmpl-lissubcategory').html());
                            $('#casesubCategory').html(temp(data.Data));
                            $('#casesubCategory').removeAttr("disabled", "disabled");
                            $('#casesubCategory').select2({
                                theme: "bootstrap4",
                                width: "100%"
                            });
                        } else {
                            $('#casesubCategory').val(null).trigger('change')
                            $('#casesubCategory').select2({
                                placeholder: '-'
                            });
                            $('#casesubCategory').prop("disabled", true);
                        }
                    }





                }
                , error: function (err) {
                    console.log(err);
                }
            });

        }).off('change', '#department')
        .on('change', '#department', function (e) {
            if ($('#CaseOwnerDepartmentID').length) {
                   $('#CaseOwnerDepartmentID').val($(this).val()).trigger('change');
            }

        }).off('change', '.js-requestamount')
        .on('change', '.js-requestamount', function (e) {
            var amount = parseFloat($('#RequestAmount').val().replace(/,/g, ''));
            console.log("amount = ", amount);
            if (amount != NaN && amount > 0) {
                $('#RequestAmount').val(amount);
            }

        })
    

});

