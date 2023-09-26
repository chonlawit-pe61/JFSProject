$(function () {
    var componentName = 'attachfile';
    var currentWorkStep = 0;
    $('#frm' + componentName)
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (event) {

            SWConfirm.fire().then((result) => {
                if (result.value) {
                    SWSuccess.fire()
                }
            });


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
        .off('click', '.js--add-' + componentName)
        .on('click', '.js--add-' + componentName, function (e) {
            e.preventDefault();
            var worksetp = $(this).data('step');
            $('#setpid' + componentName).val(worksetp);

        })
        .off('click', '.js--edit-' + componentName)
        .on('click', '.js--edit-' + componentName, function (e) {
            e.preventDefault();          

            var attachFileID = $(this).data('attachfileid');
            var lableFile = $(this).data('lablefile');
            var description = $(this).data('description');
            var worksetp = $(this).data('worksetp');

            $('#EditlableFile' + componentName).val(lableFile).focus();
            $('#Editdescription' + componentName).val(description);
            $('#EditattchFileID' + componentName).val(attachFileID);
            $('#EditWorkSetpID' + componentName).val(worksetp);
            //$('#EditfileDocs' + componentName).val(attachFileID);

        });

    $('#frm-add' + componentName)
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (event) {
            if ($('#frm-add' + componentName).validationEngine('validate')) {
                var caseID = $('#caseID' + componentName).val();
                var applicantID = $('#applicantID' + componentName).val();
                var attachFileID = $('#attachFileID' + componentName).val();
                var lableFile = $('#lableFile' + componentName).val();
                var description = $('#description' + componentName).val();
                var workStepID = $('#setpid' + componentName).val();
                currentWorkStep = workStepID;
                var caseAttachFileData = {
                    CaseID: caseID,
                    ApplicantID: applicantID,
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
                            WebUpload.uploadFile(data, '/filesupload/filecaseuploads', $('#progressBar'), showAttachfile);
                        } else {
                            WebUpload.fileSelected(fileupload);
                            toastr.error('ไฟล์มีขนาดใหญ่')
                        }
                        $(fileupload).val('');
                    }
                } else {
                    toastr.error('กรุณาเลือกไฟล์')
                    $(fileupload).val('');
                }
            }
        });

    $('#frm-edit' + componentName)
        .off('click', '.js--btsave' + componentName)
        .on('click', '.js--btsave' + componentName, function (event) {

            if ($('#frm-edit' + componentName).validationEngine('validate')) {

                var caseID = $('#frm'+componentName).find('#caseID' + componentName).val();
                var applicantID = $('#frm' + componentName).find('#applicantID' + componentName).val();
                var attachFileID = $('#EditattchFileID' + componentName).val();
                var lableFile = $('#EditlableFile' + componentName).val();
                var description = $('#Editdescription' + componentName).val();
                var workStepID = $('#EditWorkSetpID' + componentName).val();
                currentWorkStep = workStepID;
                var caseAttachFileData = {
                    CaseID: caseID,
                    applicantID: applicantID,
                    AttachFileID: attachFileID,
                    WorkStepID: workStepID,
                    LableFile: lableFile,
                    Description: description
                }
                $.ajax({
                    url: '/jfservices/editcaseattachfile',
                    method: 'POST',
                    data: { caseAttachFileData: caseAttachFileData },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {
                            SWSuccess.fire();
                            $('#boxDocs' + componentName + workStepID).html('');

                            if (data.Data != null) {

                                var temp = Handlebars.compile($('#tmpl-caseattachfile').html());
                                $.each(data.Data, function (index, value) {
                                    $('#boxDocs' + componentName + workStepID).append(temp(value));
                                });
                            }
                            //$('#fileDocs' + componentName).val('');
                            $('#lableFile' + componentName).val('');
                            $('#description' + componentName).val('');
                            $('#modalEditfile').modal('hide');
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });
               
            }


        });
    function checkFileExtension(fileName) {
        var extension = fileName.split('.').pop();
        return extension;
    }
    function showAttachfile(response) {
        var data = JSON.parse(response);
        if (data.Status) {
            SWSuccess.fire();
            $('#boxDocs' + componentName).html('');
            if (data.Data != null) {
                var temp = Handlebars.compile($('#tmpl-caseattachfile').html());
                $('#boxDocs' + componentName + currentWorkStep).html(temp(data.Data));
            }
            $('#fileDocs' + componentName).val('');
            $('#lableFile' + componentName).val('');
            $('#description' + componentName).val('');
        } else {
            SWError.fire();
        }
        $('#modalAddfile').modal('hide');
    }

    //function savedocumentFile(base64result, fileExtension, caseAttachFileData, status) {

    //    console.log('caseAttachFileData = ', caseAttachFileData);
    //    $.ajax({
    //        url: '/jfservices/savecaseattachfile',
    //        method: 'POST',
    //        data: {
    //            file: base64result,
    //            fileExtension: fileExtension,
    //            caseAttachFileData: caseAttachFileData
    //        },            
    //        beforeSend: function () { },
    //        success: function (data) {
    //            //$('.js-docs-btn').show();
    //            if (data.Status) {

    //                //getLawyerAttachFile();
    //                SWSuccess.fire();
    //                var worksetpID = caseAttachFileData.WorkStepID;

    //                $('#boxDocs' + componentName + worksetpID).html('');

    //                if (data.Data != null) {

    //                    var temp = Handlebars.compile($('#tmpl-caseattachfile').html());
    //                    $.each(data.Data, function (index, value) {
    //                        $('#boxDocs' + componentName +  worksetpID).append(temp(value));
    //                    });
    //                }


    //                $('#fileDocs' + componentName).val('');
    //                $('#lableFile' + componentName).val('');
    //                $('#description' + componentName).val('');
    //                if (status) {
    //                    $('#modalAddfile').modal().toggle('close');
    //                }
    //                else {
    //                    $('#modalEditfile').modal().toggle('close');

    //                }
                    

    //            } else {
    //                SWError.fire();
    //            }
    //        }
    //        , error: function (err) {
    //            if (err.status == 401) {
    //                window.location.reload();
    //            }
    //        }
    //    });

    //}

});
