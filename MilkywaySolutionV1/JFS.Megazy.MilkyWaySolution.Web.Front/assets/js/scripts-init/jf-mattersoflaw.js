$(function () {

    var componentName = 'mattersoflaw';

    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        if ($('#isloadData-' + componentName).val() == 0) {
            //Load data
            $('#isloadData-' + componentName).val(1);
            var frm = $(this).closest('form');
            //console.log(frm);
            $.ajax({
                url: '/mattersoflaw/getcasemattersoflawcheck',
                method: 'POST',
                data: { applicantID: $('#applicantID' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {

                    console.log('getmattersoflaw');
                    console.log(data);

                    if (data.Data != null) {

                        $.each(data.Data, function (key, value) {  
                            $('input[name="cklaw' + componentName + '"]').filter('#cklaw' + value.MattersOfLawID).iCheck('check');
                        });

                        frm.find('.js--btsave' + componentName).hide();
                        frm.find('.js--cancel').hide();

                    }

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
    })

    $('#frm' + componentName)
        .off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (e) {

            var frm = $('#frm' + componentName);
            if (frm.validationEngine('validate')) {



                //ข้อกฎหมาย
                var mattersoflawData = [];
                var itemCheck = $('input[name="cklaw' + componentName + '"]:checked');
                itemCheck.each(function () {

                    mattersoflawData.push(parseInt(this.value));
                });
                console.log(mattersoflawData);

                $.ajax({
                    url: '/mattersoflaw/savemattersoflawcheck',
                    method: 'POST',
                    data: {
                        req: mattersoflawData,
                        applicantID: $('#applicantID' + componentName).val(),
                        caseID: $('#caseID' + componentName).val()
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            SWSuccess.fire();
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });

                frm.find('.js--btsave' + componentName).hide();
                frm.find('.js--cancel').hide();
                frm.find('.header-icon').remove();
            }
           

        })
        .off('ifClicked', 'input[name="cklaw' + componentName + '"]')
        .on('ifClicked', 'input[name="cklaw' + componentName + '"]', function (e) {
            var frm = $('#frm' + componentName);

            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();

        });
});