 // Begin อาชีพ
$(function () {

        var componentName = 'occupation';
        $('#card-' + componentName).on('expanded.lte.widget', function (event) {
            Common.swcithTabIcon(this);
            // console.log(Common.formatNumber(9090.90));
            $body = $(this).find('.card-body div').first();
            if ($body.html().length < 3) {


            }// end of check html length
        });
        //Card 
        //Common.CollapsedCard(this);
        $('#card-' + componentName).on('collapsed.lte.widget', function (event) { Common.swcithTabIcon(this); });


    $('#frm'+componentName)
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
