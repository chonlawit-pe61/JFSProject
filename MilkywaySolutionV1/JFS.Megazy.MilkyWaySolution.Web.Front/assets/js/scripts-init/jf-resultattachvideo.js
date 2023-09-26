$(function () {

    var componentName = 'resultattachvideo';

    $(document).ready(function () {

        $('#carouselExampleIndicators').carousel('pause');

        $('#cdvideo' + componentName).on('show.bs.collapse', function () {
            Common.swcithTabIcon(this);
            $body = $(this).find('.card-body div div').first();
            var frm = $('#frmvideo' + componentName);
            if ($('#caseID' + componentName).val() != 0) {
                $.ajax({
                    url: '/upload/getresultattachvideo',
                    method: 'POST',
                    data: {
                        id: $('#caseID' + componentName).val(),
                    },
                    beforeSend: function () { },
                    success: function (data) {
                        //$('#videoshow' + componentName).html('');
                        if (data.Data != null) {

                            var temp = Handlebars.compile($('#tmpl-video' + componentName).html());

                            $('#videoview' + componentName).html(temp(data.Data));

                        }
                    }
                    , error: function (err) {
                        console.log(err);
                    }
                });
            }
        })

        $('body')
            .off('click', '#btn-add-video')
            .on('click', '#btn-add-video', function (e) {            
                e.preventDefault();
                $('#form-edit-video').slideDown('slow');
                //$("#form-edit-video").animate({ scrollTop: document.body.scrollHeight }, "slow");
                $("html, body").animate({ scrollTop: document.body.scrollHeight }, "slow");
                $('input[name="urlVideo"]').focus();
            })
            .off('click', '#cancels-video')
            .on('click', '#cancels-video', function (e) {
                e.preventDefault();
                $('#url_video').val('');
                $('#name_video').val('');
                $('#description_video').val(0);
                $('#form-edit-video').slideUp('slow');
            })
            .off('change', '#url_video')
            .on('change', '#url_video', function (e) {
                var newval = '',
                    $this = $(this);

                if (is_url($this.val())) {
                    if (newval = $this.val().match(/(\?|&)v=([^&#]+)/)) {

                        $this.val("https://www.youtube.com/embed/" + newval.pop());

                    } else if (newval = $this.val().match(/(\.be\/)+([^\/]+)/)) {

                        $this.val("https://www.youtube.com/embed/" + newval.pop());

                    } else if (newval = $this.val().match(/(\embed\/)+([^\/]+)/)) {

                        $this.val("https://www.youtube.com/embed/" + newval.pop().replace('?rel=0', ''));
                    }
                }
                else {
                    toastr.error('กรุณาระบุ URL ที่ต้องการบันทึก')
                }

            })
            .off('click', '.remove-video')
            .on('click', '.remove-video', function (e) {
                var metaID = $(this).data('metaid');
                var caseID = $(this).data('caseid');
                
                const $ele = $(this);
                SWConfirm.fire({ 'title': 'ยืนยันการลบวิดีโอ ?' }).then((result) => {
                    if (result.value) {
                        $.ajax({
                            url: '/upload/deleteresultattachvideo',
                            method: 'POST',
                            data: {
                                metaID: metaID,
                                caseID: caseID,
                            },
                            beforeSend: function () { },
                            success: function (data) {
                                if (data.Status) {
                                    SWSuccess.fire({
                                        'title': 'ลบวิดีโอสำเร็จ', onClose: () => {
                                            //window.location.reload()
                                            $ele.closest('.js-video').remove();
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
            .off('click', '#btnsave-video')
            .on('click', '#btnsave-video', function (e) {
                var projectresultattachvideo = {
                    URLVideo: $("#url_video").val(),
                    VideoName: $('#name_video').val(),
                    Description: $('#description_video').val(),
                }
                var req = {
                    CaseId: $("#caseID" + componentName).val(),
                    projectResultAttachVideo: projectresultattachvideo
                }

                var checkURLVideo = is_url($("#url_video").val());

                if ($('#frmvideo' + componentName).validationEngine('validate') && checkURLVideo) {
                    SWConfirm.fire().then((result) => {
                        if (result.value) {
                            $.ajax({
                                url: '/form/savematevalue',
                                method: 'POST',
                                data: { req: req },
                                success: function (data) {
                                    if (data.Status) {
                                        $('#url_video').val('');
                                        $('#name_video').val('');
                                        $('#description_video').val('');
                                        var temp = Handlebars.compile($('#tmpl-videoadd' + componentName).html());
                                        $('#videoview' + componentName).append(temp(data.Data));
                                        //window.location.reload();
                                    }
                                }
                            });
                            
                        }
                    });
                }
                else {
                    toastr.error('กรุณาระบุ URL ที่ต้องการบันทึก')
                }
            })


        function is_url(str) {
            regexp = /^(?:(?:https?|ftp):\/\/)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})))(?::\d{2,5})?(?:\/\S*)?$/;
            if (regexp.test(str)) {
                return true;
            }
            else {
                return false;
            }

            
        }

    })

});