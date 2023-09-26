
$(function () {

    var componentName = 'followupresults';
    $(document).ready(function () {
        if ($('#textResult' + componentName).val() != '' || $('#textResult' + componentName).val() != null) {
            $('#result' + componentName).val($('#textResult' + componentName).val()).trigger('input');
        }
        $('#frm' + componentName)
            .off('click', '#btsave' + componentName)
            .on('click', '#btsave' + componentName, function () {
                $('#text' + componentName).val($('#result' + componentName).val())
                var req = {
                    CaseID: $('#caseID' + componentName).val(),
                    MetaID: $('#metaID' + componentName).val(),
                    MetaValue: $('#result' + componentName).val()
                }
                SWConfirm.fire().then((result) => {
                    if (result.value) {
                        $.ajax({
                            url: '/form/savematevalue',
                            method: 'POST',
                            data: { req: req },
                            beforeSend: function () { },
                            success: function (data) {
                                console.log(data)
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
    })
});

