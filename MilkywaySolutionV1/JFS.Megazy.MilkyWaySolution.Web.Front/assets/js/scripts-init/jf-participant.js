
$(function () {
    
    var componentName = 'participant';
    $(document).ready(function () {
        $('#frm' + componentName)
            .off('click', '.js--add' + componentName)
            .on('click', '.js--add' + componentName, function () {
                const $this = $(this);
                const type = $this.data('type');
                if (type == 1) {
                    const tbody = $this.closest('.card-body').find('#tbofficers' + componentName + ' tbody');
                    const template = Handlebars.compile($('#tmpl-listofficers').html());
                    length = tbody.find('tr').length + 1;
                    tbody.append(template({ rank: length }));
                    
                } else {
                    const tbody = $this.closest('.card-body').find('#tbLecturers' + componentName + ' tbody');
                    const template = Handlebars.compile($('#tmpl-listlecturers').html());
                    length = tbody.find('tr').length + 1;
                    tbody.append(template({ rank: length }));
                }

            })
            .off('click', '.js--delete' + componentName)
            .on('click', '.js--delete' + componentName, function () {
                const $this = $(this);
                const type = $this.data('type');
                if (type == 1) {
                    const tbody = $this.closest('.card-body').find('#tbofficers' + componentName + ' tbody');
                    if ($this.closest('tr').find('.js--fullname' + componentName).val() != '' && $this.closest('tr').find('.js--responsibility' + componentName).val()) {
                        $this.closest('.form-row').find('.js--btsave').show();
                        $this.closest('.form-row').find('.js--cancel').show();
                    }
                    $this.closest('tr').remove();
                    tbody.find('.js--rowrank' + componentName).each(function (i) {
                        $(this).html((i + 1));
                    });

                } else {
                    const tbody = $this.closest('.card-body').find('#tbLecturers' + componentName + ' tbody');
                    if ($this.closest('tr').find('.js--lecfullname' + componentName).val() != '' && $this.closest('tr').find('.js--subject' + componentName).val()) {
                        $this.closest('.form-row').find('.js--btsave').show();
                        $this.closest('.form-row').find('.js--cancel').show();
                    }
                    $this.closest('tr').remove();
                    tbody.find('.js--rowranklec' + componentName).each(function (i) {
                        $(this).html((i + 1));
                    });
                }

            })
            .off('click', '#btsave' + componentName)
            .on('click', '#btsave' + componentName, function () {
                var officers = [];
                var lecturers = [];
                const $this = $(this);
                $('#tbofficers' + componentName + ' tbody').find('tr').each(function () {
                    officers.push({
                        OfficerName: $(this).find('.js--fullname' + componentName).val(),
                        Responsibility: $(this).find('.js--responsibility' + componentName).val()
                    });
                });
                $('#tbLecturers' + componentName + ' tbody').find('tr').each(function () {
                    lecturers.push({
                        LecturerName: $(this).find('.js--lecfullname' + componentName).val(),
                        Subject: $(this).find('.js--subject' + componentName).val(),
                        Time: $(this).find('.js--time' + componentName).val()
                    });
                });
                var data = {
                    participantofficers: officers,
                    participantLecturers: lecturers,
                    Participant: $('#Participant' + componentName).val(),
                    Observer: $('#Observer' + componentName).val()
                }
                var req = {
                    CaseID: $('#caseID' + componentName).val(),
                    MetaID: $('#metaID' + componentName).val(),
                    caseProjectParticipant: data
                }
                console.log(req)
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
    });
});

