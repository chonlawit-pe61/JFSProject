// ผู้ให้ความช่วยเหลือค่าใช้จ่าย
$(function () {

    var componentName = 'applicantnoincome';

    var componentNameId = $('#' + componentName + '-Id').val();



    renderApplicantNoIncome();


    // SaveEvent


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


    //$('#card-title-' + componentName).text('test');

    //$('body')
    //    .off('click', '.js--btsave' + componentName)
    //    .on('click', '.js--btsave' + componentName, function (event) {

    //        SWConfirm.fire().then((result) => {
    //            if (result.value) {
    //                SWSuccess.fire()
    //            }
    //        });


    //    });

    // Modal Add
    $('#btadd' + componentName).on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var recipient = button.data('whatever') // Extract info from data-* attributes
        // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.

        var modal = $(this)
        modal.find('.modal-title').text('New message to ' + recipient)
        modal.find('.modal-body input').val(recipient)
    });

    // Modal Edit
    $('#btedit' + componentName).on('show.bs.modal', function (event) {
        //console.log("ModalEdit");
        var button;
        button = $(event.relatedTarget)
        var id = $(button).data('id');
        //var modal = $(this)
        //console.log(id);
        var tr = $(button).closest('tr');
        if (id > -1) {

            $('#editcause').val($(tr).find('.editcause').html());
            $('#editsupportby').val($(tr).find('.editsupportby').html());
            $('#editincome').val($(tr).find('.editincome').html());
            $('#editincomeunit').val($(tr).find('.editincomeunit').html());
            $('#editnoincomeid').val(id);

        }
        else {

            $('#editcause').val('');
            $('#editsupportby').val('');
            $('#editincome').val('');
            $('#editincomeunit').val('');
            $('#editnoincomeid').val(-1);
        }

    });

    // GetData ApplicantNoIncome
    function renderApplicantNoIncome() {
        var tbody = $('#tb' + componentName);
        tbody.html('');
        $.ajax({
            type: 'POST',
            url: '/applicantnoincome/getapplicantnoincome',
            data: {
                appcantId: parseInt(componentNameId),
            },
            beforeSend: function () {
                tbody.html('<tr class="text-center"><td colspan="4"><i class="fa fa-spinner fa-pulse fa-fw"></i><span class="sr-only">Loading..</span></td></tr>')
            },
            
            success: function (data) {
                //console.log(data);
                if (data.Status) {

                    tbody.remove('tr');

                    if (data.Data.length > 0) {

                        var temp = Handlebars.compile($('#tmpl-list' + componentName).html());
                        tbody.html(temp(data.Data));


                    } else {

                        tbody.html('<tr class="text-center"><td colspan="4">ไม่พบข้อมูลที่ค้นหา</td></tr>');
                    }

                }
            },
            error: function (err) {
                console.log(err);
            }
        });

    }


    // Save
    $('#frm' + componentName)
        .off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        .off('click', '#btsave' + componentName)
        .on('click', '#btsave' + componentName, function (e) {
       
                    var tbody = $('#tb' + componentName);

                    var appcantnoRow = {
                        ApplicantID: parseInt(componentNameId),
                        Cause: $("#cause").val(),
                        SupportBy: $("#supportby").val(),
                        Income: $("#income").val(),
                        IncomeUnit: $("#incomeunit").val(),

                    }
                    $.ajax({
                        type: 'POST',
                        url: '/applicantnoincome/saveapplicantnoincome',
                        data: { appcantnoRow: appcantnoRow },
                        beforeSend: function () { },
                        success: function (data) {
                            if (data.Status) {
                                SWSuccess.fire({
                                    onClose: () => {
                                        window.location.reload();                                 
                                    }
                                });
                            }
                            else {
                                SWError.fire({

                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            SWError.fire({

                            });
                        }
                    });
              
        })
        .off('click', '#bteditsave-' + componentName)
        .on('click', '#bteditsave-' + componentName, function (e) {
           
                var id = $('#editnoincomeid').val();
                appcantnoRow = {
                    NoIncomeID: id,
                    ApplicantID: parseInt(componentNameId),
                    Cause: $("#editcause").val(),
                    SupportBy: $("#editsupportby").val(),
                    Income: $("#editincome").val(),
                    IncomeUnit: $("#editincomeunit").val(),

                }
                $.ajax({
                    url: '/applicantnoincome/saveapplicantnoincome',
                    method: 'POST',
                    data: { appcantnoRow: appcantnoRow },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            SWSuccess.fire({
                                onClose: () => {
                                    window.location.reload();
                                }
                            });
                            //window.location.reload();
                        }
                        else {
                            SWError.fire({});
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });
        });

});

