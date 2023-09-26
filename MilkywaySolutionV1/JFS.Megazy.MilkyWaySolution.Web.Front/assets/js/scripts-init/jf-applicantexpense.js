// ค่าใช้จ่ายของผู้รับความช่วยเหลือ
$(function () {

    var componentName = 'applicantexpense';

    var componentNameId = $('#' + componentName + '-Id').val();



    renderApplicantExpense();


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

            $('#editdescription').val($(tr).find('.editdescription').html());
            $('#editamount').val($(tr).find('.editamount').html());            
            $('#editexpenseid').val(id);

        }
        else {

            $('#editdescription').val('');
            $('#editamount').val('');            
            $('#editcrimid').val(-1);
        }

    });


    // GetData Applicantexpense
    function renderApplicantExpense() {
        var tbody = $('#tb' +componentName);
        tbody.html('');
        $.ajax({
            type: 'POST',
            url: '/applicantexpense/getapplicantexpense',
            data: {
                appcantId: parseInt(componentNameId),
            },
            beforeSend: function () {
                tbody.html('<tr class="text-center"><td colspan="3"><i class="fa fa-spinner fa-pulse fa-fw"></i><span class="sr-only">Loading..</span></td></tr>')
            },
            success: function (data) {
                //console.log(data);
                if (data.Status) {                    

                    tbody.remove('tr');

                    if (data.Data.length > 0) {

                        var temp = Handlebars.compile($('#tmpl-list' + componentName).html());
                        tbody.html(temp(data.Data));


                    } else {

                        tbody.html('<tr class="text-center"><td colspan="3">ไม่พบข้อมูลที่ค้นหา</td></tr>');
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
        .off('click', '#btsave' + componentName)
        .on('click', '#btsave' + componentName, function (e) {

                    var appcantexRow = {
                        ApplicantID: parseInt(componentNameId),
                        Description: $("#description").val(),
                        Amount: $("#amount").val(),
                        
                    }
                    console.log(appcantexRow);
                    $.ajax({
                        type: 'POST',
                        url: '/applicantexpense/saveapplicantexpense',
                        data: { appcantexRow: appcantexRow },
                        beforeSend: function () { },
                        success: function (data) {
                            console.log(data.Data);
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


        }).off('click', '.js--cancel')
        .on('click', '.js--cancel', function (e) {
            $('.js--btsave' + componentName).hide();
            $(this).hide();
        })
        .off('click', '#bteditsave-' + componentName)
        .on('click', '#bteditsave-' + componentName, function (e) {
         
                var id = $('#editexpenseid').val();
                var appcantexRow = {
                    ExpenseID: id,
                    ApplicantID: parseInt(componentNameId),
                    Description: $("#editdescription").val(),
                    Amount: $("#editamount").val(),

                }
                
                console.log(appcantexRow);
                $.ajax({
                    url: '/applicantexpense/saveapplicantexpense',
                    method: 'POST',
                    data: { appcantexRow: appcantexRow },
                    beforeSend: function () { },
                    success: function (data) {
                        console.log(data.Data);
                        if (data.Status) {
                            SWSuccess.fire({
                                onClose: () => {
                                    //window.location.reload();
                                }
                            });
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

