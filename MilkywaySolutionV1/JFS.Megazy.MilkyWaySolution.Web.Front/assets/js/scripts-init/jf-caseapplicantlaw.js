// Begin การไกล่เกลี่ย
$(function () {

    var componentName = 'caseapplicantlaw';



    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        //console.log('Test');
        //console.log($('#applicantID' + componentName).val());
        if ($('#applicantID' + componentName).val() != 0 && $('#state'+componentName).val() ==0) {
            //Load data           
            var frm = $(this).closest('form');
            //console.log(frm);
            //console.log($('#applicantID' + componentName).val());
            $.ajax({
                url: '/jfscaseexpense/getcaseapplicantofficeropinion',
                method: 'POST',
                data: {
                    applicantID: $('#applicantID' + componentName).val(),
                    status: true,
                },
                beforeSend: function () { },
                success: function (data) {

                    console.log(data);

                    if (data.Data.CaseMattersOfLawRow != null) {
                        $.each(data.Data.CaseMattersOfLawRow, function (key, value) {
                            $('#table' + componentName).show();
                            $('#td' + componentName + value.MattersOfLawID).show();
                        });
                        $('#state' + componentName).val(1)

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
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) { Common.swcithTabIcon(this); });


    $('#frm' + componentName)
        .off('keyup ifChanged', '.js-text')
        .on('keyup ifChanged', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        }).off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        //.off('click', '.js--btsave' + componentName)
        //.on('click', '.js--btsave' + componentName, function (e) {

        //    var frm = $('#frm' + componentName);
        //    if (frm.validationEngine('validate')) {

        //        var caselaw = {
        //            ApplicantID: $('#applicantID' + componentName).val(),
        //            Consideration: $('#Consideration' + componentName).val(),
                    
        //        }
        //        console.log(caselaw);


        //        SWConfirm.fire().then((result) => {
        //            if (result.value) {
        //                $.ajax({
        //                    url: '/jfscaseexpense/savecaseapplicantofficeropinion',
        //                    method: 'POST',
        //                    data: {
        //                        req: caselaw
        //                    },
        //                    beforeSend: function () {
        //                    },
        //                    success: function (data) {
        //                        console.log(data);
        //                        if (data.Status) {
        //                            //$('#applicantID' + componentName).val(data.ID);

        //                            SWSuccess.fire();
        //                        }
        //                    }
        //                    , error: function (err) {
        //                        console.log(err);
        //                    }
        //                });

        //                frm.find('.js--btsave' + componentName).hide();
        //                frm.find('.js--cancel').hide();
        //            }
        //        });
        //    }

        //});



});
