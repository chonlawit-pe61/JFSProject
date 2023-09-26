$(function () {

    var componentName = 'applicantattachfile';

    

    //Get Data
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        var applicant = $('#applicantID' + componentName).val();
        var state = $('#state' + componentName).val();
        var casedata = $('#caseID' + componentName).val();
        var jfcasetype = $('#jfcasetypeID' + componentName).val();
        //console.log(reason);
        if ((applicant != 0 && state == 0) && (jfcasetype != 0)) {

            //Load data
            $.ajax({
                url: '/applicantattachfile/getreasonandapplicantattachfile',
                method: 'POST',
                data: {
                    applicantID: $('#applicantID' + componentName).val(),                    
                    jfcasetypeID: $('#jfcasetypeID' + componentName).val(),
                },
                beforeSend: function () { },
                success: function (data) {
                    var frm = $('#frm' + componentName);
                    console.log("archival = ", data);
                    if (data.Status) {
                        $('#box-attach-' + componentName).removeClass('d-none');
                        $.each(data.Data.archivalCopyMapJFCaseTypeRow, function (index, value) {
                            $('#tr' + componentName + value.ArchivalCopyID).show(); 
                            //$('#chacfile' + componentName + value.ArchivalCopyID).iCheck('check');
                            //console.log('test');
                        });
                        $.each(data.Data.applicantAttachFileRow, function (index, value) {
                            console.log("testCheck");
                            $('#note' + componentName + value.ArchivalCopyID).val(value.Remark);
                            $('#chacfile' + componentName + value.ArchivalCopyID).iCheck('check');
                        });
                    }
                    $('#state' + componentName).val(1);
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

    // ModalAdd
    $('#btadd' + componentName).on('show.bs.modal', function (event) {

        var button = $(event.relatedTarget) // Button that triggered the modal
        var recipient = button.data('whatever') // Extract info from data-* attributes
        var modal = $(this)
        modal.find('.modal-title').text('New message to ' + recipient)
        modal.find('.modal-body input').val(recipient)
    });


    $('#frm' + componentName)

        //.off('change', 'input[name=remark'+componentName+']')
        //.on('change', 'input[name=remark' + componentName +']', function (e) {

        //    var frm = $(this).closest('form');

        //    frm.find('.js--cancel').show();
        //    frm.find('.js--btsave' + componentName).show();


        //})
        //.off('ifCheck', 'input[name=chacfile' + componentName +']')
        //.on('ifCheck', 'input[name=chacfile' + componentName +']', function (e) {

        //    var frm = $(this).closest('form');

        //    frm.find('.js--cancel').show();
        //    frm.find('.js--btsave' + componentName).show();


        //})
        .off('keyup change ifChecked', '.js-text')
        .on('keyup change ifChecked', '.js-text', function (e) {

            var frm = $(this).closest('form');

            frm.find('.js--cancel').show();
            frm.find('.js--btsave' + componentName).show();


        })
        .off('click', '.js--btsave'+componentName)
        .on('click', '.js--btsave'+componentName, function (e) {
            var frm = $(this).closest('form');

            if (frm.validationEngine('validate')) {
                var req = [];
               
                $('input[name=chacfile' + componentName + ']:checkbox').map(function (e) {
                    if ($(this).prop("checked")) {
                        var id = $(this).val();
                        //console.log(id);
                        req.push({     
                            ArchivalCopyID: $(this).val(),
                            ApplicantID: $("#applicantID" + componentName).val(),
                            Remark: $('#note' + componentName + id).val(),
                           
                        })
                    }
                });
                console.log("req = ",req);

                $.ajax({
                    url: '/applicantattachfile/saveapplicantattachfile',
                    method: 'POST',
                    data: {
                        applicantID: $("#applicantID" + componentName).val(),
                        req: req
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        console.log(data);
                        if (data.Status) {
                            
                            SWSuccess.fire();
                            frm.find('.js--btsave').hide();
                            frm.find('.js--cancel').hide();
                            frm.find('.header-icon').remove();
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });
            }
        });




});