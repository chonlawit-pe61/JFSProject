// คำร้องขอปล่อยชั่วคราว
$(function () {

    var componentName = 'othercase';
    $(document).ready(function () {

        //setTimeout(function () {
        //    $(".multiselect-dropdown").select2({
        //        theme: "bootstrap4"
        //    });

        //}, 2000);


        $('#frm' + componentName)
            .off('click', '.js--cancel')
            .on('click', '.js--cancel', function (e) {
                $('.js--btsave' + componentName).hide();
                $(this).hide();
            })
            .off('click', '.js--btsave' + componentName)
            .on('click', '.js--btsave' + componentName, function (event) {

                SWConfirm.fire().then((result) => {
                    if (result.value) {
                        SWSuccess.fire()
                    }
                });


            });


    });

});
