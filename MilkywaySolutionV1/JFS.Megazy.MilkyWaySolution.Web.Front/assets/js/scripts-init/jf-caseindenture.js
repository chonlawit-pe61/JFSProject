$(function () {
    var componentName = 'caseindenture';
    $('#card-' + componentName).on('expanded.lte.widget', function (event) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        var frm = $(this).closest('form');
        if ($('#isloadData-' + componentName).val() == 0) {
            $('#isloadData-' + componentName).val(1);
            $.ajax({
                url: '/jfservices/GetApplicantContract',
                method: 'POST',
                data: {
                    applicantID: $('#applicantID' + componentName).val(),
                    caseID: $('#caseID' + componentName).val() },
                beforeSend: function () { },
                success: function (data) {
                    if (data.Status) {
                        var temp = Handlebars.compile($('#tmpl-contractlist').html());
                        $('#contractlist').html(temp(data.Data));
                    }
                }
                , error: function (err) {
                    console.log(err);
                }
            });

           
        }
        frm.find('.js--btsave' + componentName).hide();
        frm.find('.js--cancel').hide();
    });

    $('#card-' + componentName).on('collapsed.lte.widget', function (event) { Common.swcithTabIcon(this); });
    $('#frm' + componentName)
        .off('click', '.js--contract')
        .on('click', '.js--contract', function (e) {
            e.preventDefault();
            var url = '/applicant/contract/?id=' + $(this).data('appid') + '&caseid=' + $(this).data('id') + '&depid=' + $(this).data('depid') + '&formid=' + $(this).data('formid');
            //console.log(url);
            window.location.href = url;
        })
        .off('click', '.js--lawyer')
        .on('click', '.js--lawyer', function (e) {
            e.preventDefault();
            var url = '/applicant/lawyercaseselect/?id=' + $(this).data('appid') + '&caseid=' + $(this).data('id') + '&depid=' + $(this).data('depid');
            //console.log(url);
            window.location.href = url;
        })
        .off('change', '#contractType' + componentName)
        .on('change', '#contractType' + componentName, function (e) {
            const id = $(this).val();
            if (id != 0) {
                $.get("/jfservices/getformmapattribute", { formID: id }, function (data) {
                    $("#box-contract").html('');
                    $("#box-contract").html(data);
                    getDataSet();
                    //console.log(data);
                })
            }
        })
        .off('keyup', '.js-text')
        .on('keyup', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--btsave' + componentName).show();
            frm.find('.js--cancel').show();
        })
        .off('click', '.js--number' + componentName)
        .on('click', '.js--number' + componentName, function (e) {
            //console.log("Test")
            if ($('#number' + componentName).val() != '') {
                $('#accusedtracking').show();
            }
            else {
                $('#accusedtracking').hide();
            }
        });
        //.off('click', '#btn-save-form')
        //.on('click', '#btn-save-form', function (event) {
        //    var mapAttributeData = [];
        //    var getData = $("#box-contract").find('.js--value');
        //    getData.each(function (index) {
        //        console.log(index + " -- " + $(this).val());
        //        //mapAttributeData.push({
        //        //    //QueueVersionID: $('#QueueVersionID').val(),
        //        //    FormID : index + 1,
        //        //    ApplicantID: 
        //        //    FormAttrID: 
        //        //    FormAttrVal:
        //        //    //LawyerID: $(this).data('id')
        //        //});
        //    });
        //    console.log(mapAttributeData);
        //});
    $('#frmaccusedtracking')
        .off('click', '.js--link' + componentName)
        .on('click', '.js--link' + componentName, function (e) {
            window.location.reload();

        });
    //numbercaseindenture
    function getDataSet() {
        $.ajax({
            url: '/jfservices/getdefaultvaluejfscontractform1',
            method: 'POST',
            data: {
                caseID: $('#caseID' + componentName).val(),
                applicantID: $('#applicantID' + componentName).val(),
            },
            beforeSend: function () { },
            success: function (data) {
                var allowed = $("#box-contract").find('.js--value');
                var dataset = Object.keys(data.Data);
                //console.log(" ------attralias--------- ");
                //console.log(data);
                console.log(dataset);
                allowed.each(function (index) {
                    $(this).val(data.Data[$(this).data('attralias')]);
                });
            }
            , error: function (err) {
                console.log(err);
            }
        });
    }
});