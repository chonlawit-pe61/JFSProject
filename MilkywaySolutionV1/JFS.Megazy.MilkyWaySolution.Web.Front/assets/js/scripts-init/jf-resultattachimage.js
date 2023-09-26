
$(function () {

    var componentName = 'resultattachimage';

    $(document).ready(function () {

        var cropper;

        $('#carouselExampleIndicators').carousel('pause');

        $('#cd-img' + componentName).on('show.bs.collapse', function () {
            Common.swcithTabIcon(this);
            $body = $(this).find('.card-body div div').first();
            var frm = $('#frm' + componentName);
            var regex = new RegExp("^.*\.(JPEG|JPG|PNG|jpeg|jpg|png)$");
            if ($('#caseID' + componentName).val() != 0) {

                $.ajax({
                    url: '/upload/getresultattachimage',
                    method: 'POST',
                    data: {
                        caseID: $('#caseID' + componentName).val(),
                        applicantID: $('#applicantID' + componentName).val(),

                    },
                    beforeSend: function () { },
                    success: function (data) {
                        //console.log(data.Data)
                        $('#imageshow' + componentName).html('');
                        if (data.Data != null) {
                            var arr = new Array();
                            for (var i = 0; i < data.Data.length; i++)
                            {
                                if (regex.test(data.Data[i].FileType)) {
                                    arr.push(data.Data[i]);
                                }
                            }

                            var temp = Handlebars.compile($('#tmpl-img' + componentName).html());
                            $('#imgview' + componentName).html(temp(arr));
                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });

            }
        })

        $('body')
            .off('click', '.js--slideUp')
            .on('click', '.js--slideUp', function (e) {
                const $ele = $(this);
                if ($ele.data('fadein') == 0) {
                    $ele.closest('.carousel-item').find('.caption-bg').fadeIn();
                    $ele.find('i').removeClass('fa-angle-up');
                    $ele.find('i').addClass('fa-angle-down');
                    $ele.removeClass('btn-outline-dark');
                    $ele.addClass('btn-outline-light');
                    $ele.data('fadein', 1);
                } else {
                    $ele.closest('.carousel-item').find('.caption-bg').fadeOut();
                    $ele.find('i').removeClass('fa-angle-down');
                    $ele.find('i').addClass('fa-angle-up');
                    $ele.removeClass('btn-outline-light');
                    $ele.addClass('btn-outline-dark');
                    $ele.data('fadein', 0);
                }
            })
            .off('click', '.js--btratio')
            .on('click', '.js--btratio', function (e) {

                var ratio = 0;
                if ($(this).data('ratio') == 1) {
                    ratio = 0;
                }
                else if ($(this).data('ratio') == 2) {
                    ratio = 16 / 9;
                }
                else if ($(this).data('ratio') == 3) {
                    ratio = 9 / 16;
                }
                if (cropper != null) {
                    cropper.destroy();
                }
                cropper = null;
                cropper = new Cropper(image, {
                    aspectRatio: ratio,
                    viewMode: 1,
                    preview: '.preview'
                });
            })

        $('#frmimage' + componentName)
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
            .off('change', '#fileupload' + componentName)
            .on('change', '#fileupload' + componentName, function (event) {
                WebUpload.fileSelected(this);
            })
            .off('click', '.remove-img')
            .on('click', '.remove-img', function (e) {
                var attachfileID = $(this).data('attachfileid');

                const $ele = $(this);
                SWConfirm.fire({ 'title': 'ยืนยันการลบรูปภาพ ?' }).then((result) => {
                    if (result.value) {
                        $.ajax({
                            url: '/upload/deleteresultattachfile',
                            method: 'POST',
                            data: {
                                id: attachfileID
                            },
                            beforeSend: function () { },
                            success: function (data) {
                                if (data.Status) {
                                    SWSuccess.fire({
                                        'title': 'ลบรูปภาพสำเร็จ', onClose: () => {
                                            //window.location.reload()
                                            $ele.closest('.js-img').remove();
                                            //if ($('.carousel-item').prev().length > 0) {
                                            //    $('.carousel-item').prev().addClass('active');
                                            //}
                                            //else if ($('.carousel-item').next().length > 0) {
                                            //    $('.carousel-item').next().addClass('active');
                                            //}
                                            //else {
                                            //    $('.carousel-item').first().addClass('active');
                                            //}

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

        $('#frmimagemodal')
            .off('click', '#btsaveImage' + componentName)
            .on('click', '#btsaveImage' + componentName, function (e) {
                var req = {
                    CaseId: $("#caseID" + componentName).val(),
                    ApplicantID: $("#applicantID" + componentName).val(),
                    LableFile: $('#labelFile_img' + componentName).val(),
                    Description: $('#description_img' + componentName).val(),
                }

                if (cropper != null) {
                    if ($('#frmimage' + componentName).validationEngine('validate')) {
                        SWConfirm.fire().then((result) => {
                            if (result.value) {
                                var base64data = null;
                                canvas = cropper.getCroppedCanvas();
                                canvas.toBlob(function (blob) {
                                    var reader = new FileReader();
                                    reader.readAsDataURL(blob);
                                    reader.onloadend = function () {
                                        base64data = reader.result;

                                        $.ajax({
                                            url: '/upload/saveresultattachimage',
                                            method: 'POST',
                                            data: { base64Img: base64data, imageData: req },
                                            success: function (data) {

                                                $('#previewImage' + componentName).modal('hide');
                                                //var temp = Handlebars.compile($('#tmpl-imagefile' + componentName).html());
                                                //var temp2 = Handlebars.compile($('#tmpl-navcarousel' + componentName).html());
                                                //$('.carousel-item').removeClass('.active')
                                                //$('#navcarousel' + componentName).find('li').removeClass('.active')
                                                //$('#imageshow' + componentName).append(temp({ index: $('.carousel-item').length, value: data.Data }));
                                                //$('#navcarousel' + componentName).append(temp2({ i: $('.carousel-item').length }));
                                                //$('#gallery' + componentName).show();
                                                
                                                var temp = Handlebars.compile($('#tmpl-imgadd' + componentName).html());
                                                $('#imgview' + componentName).append(temp(data.Data));
                                                window.location.reload
                                                $('#collapseOne' + componentName).show();
                                            }
                                        });

                                    };
                                });
                            }
                        });

                    }
                }
                else {
                    toastr.error('กรุณาเลือกขนาดภาพที่ต้องการบันทึก')
                }
            })

        const image = document.getElementById('sample_image');
        $('#fileimage' + componentName).change(function (event) {
            var files = event.target.files;
            var regex = new RegExp("^.*\.(JPEG|JPG|PNG|png|jpg|jpeg)$");
            if (regex.test(files[0].name)) {
                var type = event.target.getAttribute('data-type');
                var done = function (url) {
                    image.src = url;
                    $('#previewImage' + componentName).modal('show', { type: type });
                };
                if (files && files.length > 0) {
                    reader = new FileReader();
                    reader.onload = function (event) {
                        done(reader.result);
                    };
                    reader.readAsDataURL(files[0]);
                }
            }
            else {
                toastr.error('กรุณาเลือกไฟล์รูปภาพ')
            }
        });

        $('#previewImage' + componentName).on('shown.bs.modal', function (e) {

        }).on('hidden.bs.modal', function () {
            if (cropper != null) {
                cropper.destroy();
            }
            cropper = null;
            $('#sample_image').val('');
            $('#labelFile_img' + componentName).val('');
            $('#description_img' + componentName).val('');
        });

        Handlebars.registerHelper('check', function (index) {
            let text = '';
            if (index == 0) {
                text = 'active';
            }
            return new Handlebars.SafeString(text);
        });
        Handlebars.registerHelper('checknull', function (txt) {
            let text = '';
            if (txt == null) {
                text = 'display:none !important;';
            }
            return new Handlebars.SafeString(text);
        });
    });

});

