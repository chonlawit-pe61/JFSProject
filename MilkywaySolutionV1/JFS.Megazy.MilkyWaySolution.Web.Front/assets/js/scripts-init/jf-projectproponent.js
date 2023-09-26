
$(function () {

    var componentName = 'projectproponent';
    $(document).ready(function () {
        $('#frm' + componentName)
            .off('click', '#btsave' + componentName)
            .on('click', '#btsave' + componentName, function () {
                const $this = $(this);
                const caseID = $('#caseID' + componentName).val();
                var projectProponent = {
                    Fullname: $('#fullName' + componentName).val(),
                    Position: $('#position' + componentName).val(),
                    Telephone: $('#TelephoneNo' + componentName).val(),
                    Email: $('#Email' + componentName).val(),
                    Line: $('#Line' + componentName).val()
                }
                var req = {
                    CaseID: caseID,
                    MetaID: $('#metaID' + componentName).val(),
                    projectProponent: projectProponent
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

