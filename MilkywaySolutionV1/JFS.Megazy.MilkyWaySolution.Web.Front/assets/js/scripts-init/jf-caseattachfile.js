// Begin การไกล่เกลี่ย
$(function () {

    var componentName = 'caseattachfile';


    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        var frm = $('#frm' + componentName);
        //if ((!$(':radio[name=rdoComplicate]').is(':checked')) && $('#applicantID' + componentName).val() != 0) {
            //Load data
            //if ($('#isloadData-' + componentName).val() == 0) {
              
            //    $('#isloadData-' + componentName).val(1);

                $.ajax({
                    url: '/jfservices/getcaseattachfile',
                    method: 'POST',
                    data: {
                        applicantID: $('#applicantID' + componentName).val(),
                        caseID: $('#caseID' + componentName).val(),
                        workStepID: $('#workStepID').val()
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        $('#box-docs-' + componentName).html('');
                        if (data.Data != null) {
                            var temp = Handlebars.compile($('#tmpl-caseattachfile').html());
                            $.each(data.Data, function (index, value) {
                                $('#box-docs-' + componentName).append(temp(value));
                            });
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
               });

            //} else { console.log('default') }

        //} else { console.log('default') }
    });
    //Card 
    //Common.CollapsedCard(this);
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $('#fileDocs' + componentName).val('');
        $('#lableFile' + componentName).val('');
        $('#description' + componentName).val('');
        $('#attachFileID' + componentName).val(0);
    });

    $('#frm' + componentName)
        .off('click', '#btn-add-attach-file' + componentName)
        .on('click', '#btn-add-attach-file' + componentName, function (e) {
            $('#form-edit-docs' + componentName).show();
        })
        .off('click', '#cancels-docs' + componentName)
        .on('click', '#cancels-docs' + componentName, function (e) {
            e.preventDefault();
            $('#fileDocs' + componentName).val('');
            $('#lableFile' + componentName).val('');
            $('#description' + componentName).val('');
            $('#attachFileID' + componentName).val(0);
            $('#form-edit-docs' + componentName).hide();

        })
        .off('click', '.js--delete-' + componentName)
        .on('click', '.js--delete-' + componentName, function (e) {
            e.preventDefault();
            SWConfirm.fire({ 'title': 'ยืนยันการลบข้อมูล' }).then((result) => {
                if (result.value) {
                    var caseID = $(this).data('caseid');
                    var attachfileID = $(this).data('attachfileid');
                    var applicantID = $(this).data('applicantid');
                    $.ajax({
                        url: '/jfservices/deletecaseattachfile',
                        method: 'POST',
                        data: {
                            caseID: caseID,
                            applicantID: applicantID,
                            attachFileID: attachfileID,
                        },
                        beforeSend: function () { },
                        success: function (data) {
                            if (data.Status) {
                                $('#box-attachfile-' + attachfileID).remove();
                                SWSuccess.fire({ 'title': 'ลบข้อมูลสำเร็จ' });
                            } else {

                                SWError.fire();
                            }
                        }
                        , error: function (err) {
                            if (err.status == 401) {
                                window.location.reload();
                            }
                        }
                    });

                }

            });

        })
        .off('click', '.js--edit-' + componentName)
        .on('click', '.js--edit-' + componentName, function (e) {
            e.preventDefault();

            $('#form-edit-docs' + componentName).show();

            var attachFileID = $(this).data('attachfileid');
            var lableFile = $(this).data('lablefile');
            var description = $(this).data('description');

            $('#lableFile' + componentName).val(lableFile).focus();
            $('#description' + componentName).val(description);
            $('#attachFileID' + componentName).val(attachFileID);

        })
        .off('click', '#btnsave-docs' + componentName)
        .on('click', '#btnsave-docs' + componentName, function (event) {
            if ($('#frm' + componentName).validationEngine('validate')) {
                var caseID = $('#caseID' + componentName).val();
                var applicantID = $('#applicantID' + componentName).val();
                var attachFileID = $('#attachFileID' + componentName).val();
                var lableFile = $('#lableFile' + componentName).val();
                var description = $('#description' + componentName).val();
                var workStepID = $('#workStepID').val();
                var caseAttachFileData = {
                    CaseID: caseID,
                    applicantID: applicantID,
                    AttachFileID: attachFileID,
                    WorkStepID: workStepID,
                    LableFile: lableFile,
                    Description: description
                }
                var data = new FormData();
                //data.append('workStepID', workStepID);
                data.append('caseAttachFileData', JSON.stringify(caseAttachFileData));
                var regex = new RegExp("^.*\.(pdf|PDF|doc|DOCX|jpg|JPG|png|JPEG)$");
                var fileupload = document.getElementById('fileupload');
                if (regex.test(fileupload.value.toLowerCase())) {
                    //Check whether HTML5 is supported.
                    if (typeof (fileupload.files) != "undefined") {
                        var maxSize = $(fileupload).data('max-size');
                        var fileSize = fileupload.files[0].size;
                        if (maxSize > fileSize) {
                            data.append('fileToUpload', fileupload.files[0]);
                            WebUpload.uploadFile(data, '/upload/filecaseuploads', $('#progressBar'), showAttachfile);
                        } else {
                            WebUpload.fileSelected(fileupload);
                            toastr.error('ไฟล์มีขนาดใหญ่')
                            $(fileupload).val('');
                        }
                    }
                } else {
                    toastr.error('กรุณาเลือกไฟล์')
                    $(fileupload).val('');
                }


            }

        })
        .off('change', '#fileupload')
        .on('change', '#fileupload', function (event) {
            WebUpload.fileSelected(this);
        });

    function checkFileExtension(fileName) {
        var extension = fileName.split('.').pop();
        return extension;
    }
    function showAttachfile(response) {
        var data = JSON.parse(response);
        if (data.Status) {
            SWSuccess.fire();
            $('#box-docs-' + componentName).html('');
            if (data.Data != null) {
                var temp = Handlebars.compile($('#tmpl-caseattachfile').html());
                $.each(data.Data, function (index, value) {
                    $('#box-docs-' + componentName).append(temp(value));
                });
            }
            $('#fileDocs' + componentName).val('');
            $('#lableFile' + componentName).val('');
            $('#description' + componentName).val('');
        } else {
            SWError.fire();
        }
    }
    function savedocumentFile(base64result, fileExtension, caseAttachFileData) {
        $.ajax({
            url: '/jfservices/savecaseattachfile',
            method: 'POST',
            data: {
                file: base64result,
                fileExtension: fileExtension,
                caseAttachFileData: caseAttachFileData
            },
            beforeSend: function () {$('#btnsave-docs' + componentName).html('กำลังอัปโหลดไฟล์...'); },
            success: function (data) {
                //$('.js-docs-btn').show();
                $('#btnsave-docs' + componentName).html('บันทึก');
                if (data.Status) {
                    //getLawyerAttachFile();
                    SWSuccess.fire();
                    $('#box-docs-' + componentName).html('');
                    if (data.Data != null) {
                        var temp = Handlebars.compile($('#tmpl-caseattachfile').html());
                        $.each(data.Data, function (index, value) {
                            $('#box-docs-' + componentName).append(temp(value));
                        });
                    }
                    $('#fileDocs' + componentName).val('');
                    $('#lableFile' + componentName).val('');
                    $('#description' + componentName).val('');
                } else {
                    SWError.fire();
                }
            }
            , error: function (err) {
                if (err.status == 401) {
                    window.location.reload();
                }
            }
        });

    }


});
