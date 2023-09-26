$(function () {
    var componentName = 'caseschedule';
    $(document).ready(function () {
        $('#cd' + componentName).on('show.bs.collapse', function () {

        })
        $('#frm' + componentName)
            .off('ifChanged', '[name="ckIsBreak"]')
            .on('ifChanged', '[name="ckIsBreak"]', function () {
                const $this = $(this);
                const ele1 = $this.closest('tr').find('.js--activity' + componentName);
                const ele2 = $this.closest('tr').find('.js--lecturer' + componentName);
                if ($this.is(':checked')) {
                    ele1.prop('disabled', true);
                    ele2.prop('disabled', true);
                } else {
                    ele1.prop('disabled', false);
                    ele2.prop('disabled', false);
                }


            })
            .off('click', '#btadd' + componentName)
            .on('click', '#btadd' + componentName, function () {
                const tbody = $('#tb' + componentName + ' tbody');
                const template = Handlebars.compile($('#tmpl-listcaseschedule').html());
                length = tbody.find('tr').length + 1;
                tbody.append(template({ rank: length }));
                setTimeout(function () {
                    $('.icheck').iCheck({
                        checkboxClass: 'icheckbox_flat-grey',
                        radioClass: 'iradio_flat-grey'
                    });
                }, 100);
            })
            .off('click', '.js--delete' + componentName)
            .on('click', '.js--delete' + componentName, function () {
                const $this = $(this);
                if ($this.closest('tr').find('.js--time' + componentName).val() != '' && $this.closest('tr').find('.js--activity' + componentName).val()) {
                    $this.closest('.form-row').find('.js--btsave').show();
                    $this.closest('.form-row').find('.js--cancel').show();
                }
                $this.closest('tr').remove();
                const tbody = $('#tb' + componentName + ' tbody');
                tbody.find('.js--rowrank' + componentName).each(function (i) {
                   $(this).html((i + 1));
                });

            })
            .off('click', '#btsave' + componentName)
            .on('click', '#btsave' + componentName, function () {
                var data = [];
                const $this = $(this);
                const tbody = $('#tb' + componentName + ' tbody');
                tbody.find('tr').each(function () {
                    data.push({
                        Time: $(this).find('.js--time' + componentName).val(),
                        Activity: $(this).find('[name="ckIsBreak"]').is(':checked') ? 'พัก ' + $(this).find('.js--time' + componentName).val() : $(this).find('.js--activity' + componentName).val(),
                        Lecturer: $(this).find('.js--lecturer' + componentName).val(),
                        IsBreak: $(this).find('[name="ckIsBreak"]').is(':checked')
                    });
                });
                var req = {
                    CaseID: $('#caseID' + componentName).val(),
                    MetaID: $('#metaID' + componentName).val(),
                    caseProjectSchedule: data
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
    });

});