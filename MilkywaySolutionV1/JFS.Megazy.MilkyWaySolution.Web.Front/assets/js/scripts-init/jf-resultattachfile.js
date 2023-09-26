
$(function () {

    var componentName = 'resultattachfile';

    $(document).ready(function () {
        
        $('#cd' + componentName).on('show.bs.collapse', function () {
            
        })
        $('#frm' + componentName)
            .off('click', '#btsave' + componentName)
            .on('click', '#btsave' + componentName, function () {
                const $this = $(this);                
                var req = {
                }
                //console.log(req)
                SWConfirm.fire().then((result) => {
                    if (result.value) {
                        $.ajax({
                            url: '/form/saveexpense',
                            method: 'POST',
                            data: { req: req },
                            beforeSend: function () { },
                            success: function (data) {
                                if (data.Status) {
                                    SWSuccess.fire({
                                        onClose: () => {
                                            $this.closest('.form-row').find('.js--btsave').hide();
                                            $this.closest('.form-row').find('.js--cancel').hide();
                                        }
                                    });
                                }
                            }
                            , error: function (err) {
                                console.log(err);
                            }
                        });
                    }
                });
            })
            .off('click', '#btn-add-attach-file' + componentName)
            .on('click', '#btn-add-attach-file' + componentName, function (e) {
                $('#form-edit-docs' + componentName).slideDown('slow');
                $('input[name="lableFile"]').focus();
            })
            .off('click', '#cancels-docs' + componentName)
            .on('click', '#cancels-docs' + componentName, function (e) {
                e.preventDefault();
                $('#fileDocs' + componentName).val('');
                $('#lableFile' + componentName).val('');
                $('#description' + componentName).val('');
                $('#attachFileID' + componentName).val(0);
                $('#form-edit-docs' + componentName).slideUp('slow');

            })
            .off('click', '#btnsave-docs' + componentName)
            .on('click', '#btnsave-docs' + componentName, function (event) {
                event.preventDefault();

                if ($('#form-edit-docs' + componentName).validationEngine('validate')) {
                    var caseID = $('#caseID' + componentName).val();
                    var applicantID = $('#applicantID' + componentName).val();
                    var lableFile = $('#lableFile' + componentName).val();
                    var attachFileID = $('#attachFileID' + componentName).val();
                    var description = $('#description' + componentName).val();
                    var attachFileData = {
                        CaseID: caseID,
                        ApplicantID: applicantID,
                        AttachFileID: attachFileID,
                        LableFile: lableFile,
                        Description: description
                    }
                    //console.log(JSON.stringify(attachFileData))
                    var data = new FormData();
                    //data.append('workStepID', workStepID);
                    data.append('resultAttachfileData', JSON.stringify(attachFileData));
                    var regex = new RegExp("^.*\.(pdf|PDF|doc|docx|DOCX)$");
                    var fileupload = document.getElementById('fileupload' + componentName);

                    if (regex.test(fileupload.value.toLowerCase())) {
                        //Check whether HTML5 is supported.
                        if (typeof (fileupload.files) != "undefined") {
                            var maxSize = $(fileupload).data('max-size');
                            var fileSize = fileupload.files[0].size;
                            if (maxSize > fileSize) {
                                data.append('fileToUpload', fileupload.files[0]);
                                WebUpload.uploadFile(data, '/upload/resultattachfileuploads', $('#progressBar'), function (e) {
                                    var data = JSON.parse(e);

                                    //console.log("data", data)

                                    if (data.Status) {
                                        SWSuccess.fire({
                                            onClose: () => {
                                                $('#attachFileID' + componentName).val(0);
                                                $('#lableFile' + componentName).val('');
                                                $('#description' + componentName).val('');
                                                $('#fileupload' + componentName).val('');
                                                $('#form-edit-docs' + componentName).slideUp('slow');
                                                const temp = Handlebars.compile($('#tmpl-' + componentName).html())
                                                $('#boxdocs' + componentName).append(temp(data.Data));
                                            }
                                        });
                                    }

                                });
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
            .off('change', '#fileupload' + componentName)
            .on('change', '#fileupload' + componentName, function (event) {
                WebUpload.fileSelected(this);
            })
            .off('click', '.js--delete-doc')
            .on('click', '.js--delete-doc', function (e) {
                e.preventDefault();
                const $this = $(this);
                SWConfirm.fire({ 'title': 'ยืนยันการลบข้อมูล' }).then((result) => {
                    if (result.value) {
                        const attachfileID = $this.data('attachfileid');
                        $.ajax({
                            url: '/upload/deleteresultattachfile',
                            method: 'POST',
                            data: {
                                id: attachfileID,
                            },
                            beforeSend: function () { },
                            success: function (data) {
                                if (data.Status) {
                                    SWSuccess.fire({
                                        'title': 'ลบข้อมูลสำเร็จ',
                                        onClose: () => {
                                            $('#box-attachfile-' + attachfileID).remove();

                                        }
                                    });
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
    })

});

