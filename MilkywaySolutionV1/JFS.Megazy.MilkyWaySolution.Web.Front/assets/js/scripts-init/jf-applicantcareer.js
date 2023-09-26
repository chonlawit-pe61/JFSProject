$(function () {
    var componentName = 'applicantcareer';    
    var setCareerID;
    var CareerID;
    var career, assets, supcareer;
    function isBigEnough(element) {
        return element.IncomeID == setCareerID;        
    }
    //Get Data
    $('#card-' + componentName).on('expanded.lte.widget', function (e) {
        Common.swcithTabIcon(this);
        $body = $(this).find('.card-body div').first();
        var applicant = $('#applicantID' + componentName).val(); 
        if (applicant != 0 && $('#state' + componentName).val() == 0) {
            $.ajax({
                url: '/applicantcareer/getapplicantcareer',
                method: 'POST',
                data: {
                    applicantID: $('#applicantID' + componentName).val(),
                    
                },
                beforeSend: function () { },
                success: function (data) {
                    var frm = $('#frm' + componentName);
                    $('#state' + componentName).val(1);                    
                    //console.log("ApplicantCareer");
                    console.log("ApplicantCareer",data.Data);
                    if (data.Data == null) {
                        //console.log("No Career");
                        $('#checkcareer').show();
                        $('#checknocareer').show();
                        frm.find('.js--cancel').hide();
                        frm.find('.js--btsave' + componentName).hide();    
                    }
                    else {
                        if ((data.Data.hascareer != null && data.Data.hascareer.length > 1) && data.Data.nocareer == null) {
                            $.each(data.Data.hascareer, function (index, items) {
                                setCareerID = items.IncomeID;
                                var ca = data.Data.career.filter(isBigEnough);
                                if (items.IsPermanent == true) {
                                    // check career and supcarceer
                                    $('#carceerradio' + componentName).iCheck('check');
                                    $('#supcarceerradio' + componentName).iCheck('check');

                                    $('#position' + componentName).val(items.OcupationPosition);
                                    $('#income' + componentName).val(items.Income);
                                    $('#incomeID' + componentName).val(items.IncomeID);
                                    $('#yearsexperience' + componentName).val(items.YearsExperience);
                                    $('#workplace' + componentName).val(items.WorkPlace);
                                    $('#telno' + componentName).val(items.TelphoneNo);
                                    $('#incomeunit' + componentName).val(items.IncomeUnit);
                                    frm.find('#divcareer').show();
                                    frm.find('#divsuppcareer').show();
                                    frm.find('#divradiosuppcareer').show();
                                    //console.log("Test TRUE");
                                    if (ca != null) {
                                        $('#career' + componentName).val(ca[0].CareerID);
                                    }

                                }
                                else if (items.IsPermanent == false) {
                                    $('#supincomeunit' + componentName).val(items.IncomeUnit);
                                    $('#supincome' + componentName).val(items.Income);
                                    $('#supincomeID' + componentName).val(items.IncomeID);
                                    $('#supworkplace' + componentName).val(items.WorkPlace);
                                    $('#supyearsexperience' + componentName).val(items.YearsExperience);
                                    $('#suptelno' + componentName).val(items.TelphoneNo);

                                    if (ca != null) {
                                        $('#supcareer' + componentName).val(ca[0].CareerID);
                                    }

                                }

                            });
                            frm.find('.js--cancel').hide();
                            frm.find('.js--btsave' + componentName).hide();    


                        }
                        else if ((data.Data.hascareer != null && data.Data.hascareer.length == 1) && data.Data.nocareer == null) {

                            $('#carceerradio' + componentName).iCheck('check');
                            $('#nosupcarceerradio' + componentName).iCheck('check');

                            frm.find('#divcareer').show();
                            frm.find('#divradiosuppcareer').show();

                            console.log("nosupcarceer");
                            console.log(data.Data.hascareer);                       

                            $.each(data.Data.hascareer, function (index, items) {
                                //setCareerID = items.IncomeID;
                                //var ca = data.Data.career.filter(isBigEnough);
                                //console.log('ca = ', ca);
                                console.log(items);
                                if (items.IsPermanent == true) {
                                    $('#position' + componentName).val(items.OcupationPosition);
                                    $('#income' + componentName).val(items.Income);
                                    $('#incomeID' + componentName).val(items.IncomeID);
                                    $('#yearsexperience' + componentName).val(items.YearsExperience);
                                    $('#workplace' + componentName).val(items.WorkPlace);
                                    $('#telno' + componentName).val(items.TelphoneNo);
                                    $('#incomeunit' + componentName).val(items.IncomeUnit);
                                    
                                    frm.find('#divcareer').show();
                                    console.log("Test TRUE");
                                    console.log(data.Data.career);
                                    if (data.Data.career != null) {
                                        $('#career' + componentName).val(data.Data.career[0].CareerID);
                                    }


                                }
                            })
                            frm.find('.js--cancel').hide();
                            frm.find('.js--btsave' + componentName).hide(); 
                            

                        }
                        else if (data.Data.nocareer != null && data.Data.hascareer == null) {
                            //console.log('Testnocareer');
                            $('#nocarceerradio' + componentName).iCheck('check');
                            frm.find('#divoncareer').show();
                            $.each(data.Data.nocareer, function (index, items) {
                                $('#case' + componentName).val(items.Cause);
                                $('#supportby' + componentName).val(items.SupportBy);
                                $('#onincomeunit' + componentName).val(items.IncomeUnit);
                                $('#onincome' + componentName).val(items.Income);
                                $('#onicomeID' + componentName).val(items.NoIncomeID);

                            });
                            frm.find('.js--cancel').hide();
                            frm.find('.js--btsave' + componentName).hide();    
                        }
                        if (data.Data.asset != null) {
                            console.log("Asset");
                            console.log(data.Data.asset);

                            $.each(data.Data.asset, function (index, items) {
                                $('#assetID' + componentName).val(items.AssetID);
                                if (items.Asset == "" || items.Asset == null) {
                                    $('#notassetradio' + componentName).iCheck('check');
                                }
                                else {
                                    $('#assetradio' + componentName).iCheck('check');
                                    $('#divasset').show();
                                    $('#asset' + componentName).val(items.Asset);
                                    //console.log($('#assetid' + componentName).val());
                                }

                            });
                            frm.find('.js--cancel').hide();
                            frm.find('.js--btsave' + componentName).hide();  
                        }
                        if (data.Data.expense != null) {
                            var temp = Handlebars.compile($('#tmpl-lisaddexp-' + componentName).html());
                            console.log("expense")
                            //counter = data.Data.expense.length;
                            $('#counter' + componentName).val(data.Data.expense.length);
                            if ($('#counter' + componentName).val() >= 5) {
                                frm.find('#addfield' + componentName).hide();
                            }
                            else {
                                frm.find('#addfield' + componentName).show();
                            }
                            
                            $.each(data.Data.expense, function (index, value) {
                                index++;
                                var DataSend = { Expense: value, Count: index };
                                $('#divexpense').append(temp(DataSend));
                                counter = index;
                            });
                            
                            
                          
                            
                            //console.log($.map(data.Data.expense))


                            frm.find('.js--cancel').hide();
                            frm.find('.js--btsave' + componentName).hide(); 
                        }
                    } 

                    $(".input-decimal").inputmask({ alias: "decimal", groupSeparator: ",", rightAlign: true, autoGroup: true, autoUnmask: true });
                }
                , error: function (err) {
                    console.log(err);
                }
            });
        } 
    });
    //Card 
    //Common.CollapsedCard(this);
    $('#card-' + componentName).on('collapsed.lte.widget', function (e) { Common.swcithTabIcon(this); });
    $('#frm' + componentName)
        .off('keyup change', '.js-text')
        .on('keyup', '.js-text', function (e) {
            var frm = $(this).closest('form');
            frm.find('.js--cancel').show();
            frm.find('.js--btsave' + componentName).show();            
        })
        .off('select2:open', '.js--select')
        .on('select2:open', '.js--select', function (e) {
            $('.js--btsave' + componentName).show();
            $('.js--cancel').show();
        })
        .off('change', '.js--select')
        .on('change', '.js--select', function (e) {
            $('.js--btsave' + componentName).show();
            $('.js--cancel').show();
        })
        .off('click', '.js--remove')
        .on('click', '.js--remove', function (e) {
            var expenseID = $(this).data('id');   
            SWDelfirm.fire().then((result) => {
                //var frm = $(this).closest('form'); 
                if (result.value) {
                    var frm = $('#frm' + componentName)
                    var $item = $('#divexpense div[data-count=' + $(this).data("count") + ']');
                    $item.closest("div").fadeOut("normal", function () {
                        $item.remove();
                    });
                    $.ajax({
                        type: 'POST',
                        url: '/applicantcareer/deleteexpense',
                        data: {
                            expenseID: expenseID,
                            applicantID: $('#applicantID' + componentName).val(),
                        },
                        beforeSend: function () { },
                        success: function (data) {
                            if (data.Status) {
                                SWSuccess.fire({
                                    title: 'ลบข้อมูลค่าใช้จ่ายสำเร็จ',
                                    onClose: () => {
                                        $('.expense').remove();
                                        var temp = Handlebars.compile($('#tmpl-lisaddexp-' + componentName).html());
                                        $.each(data.Data, function (index, value) {
                                            index++;
                                            var DataSend = { Expense: value, Count: index };
                                            $('#divexpense').append(temp(DataSend));
                                            counter = index;
                                        });

                                        $('#counter' + componentName).val(data.Data.length);

                                        if ($('#counter' + componentName).val() >= 5) {
                                            frm.find('#addfield'+componentName).hide();
                                        }
                                        else {
                                            frm.find('#addfield'+componentName).show();
                                        }
                                        frm.find('.js--cancel').hide();
                                        frm.find('.js--btsave' + componentName).hide();
                                    }
                                });
                            }
                            else {
                                $('.expense').remove();                               
                                var temp = Handlebars.compile($('#tmpl-lisaddexp-' + componentName).html());
                                $.each(data.Data, function (index, value) {
                                    index++;
                                    var DataSend = { Expense: value, Count: index };
                                    $('#divexpense').append(temp(DataSend));
                                    counter = index;
                                });
                                $('#counter' + componentName).val(data.Data.length);

                                if ($('#counter' + componentName).val() >= 5) {
                                    frm.find('#addfield'+componentName).hide();
                                }
                                else {
                                    frm.find('#addfield'+componentName).show();
                                }
                                frm.find('.js--cancel').hide();
                                frm.find('.js--btsave' + componentName).hide();
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            SWError.fire({

                            });
                        }
                    });
                    
                }
                
            });            
            //console.log(counter);  
        })
        .off('ifChecked', ':radio[name=carceer' + componentName + ']')
        .on('ifChecked', ':radio[name=carceer' + componentName + ']' , function (e) {
            var frm = $(this).closest('form');
            career = $(this).val();
            if ($(this).val() == 1) {
                $('#divcareer').show();
                $('#divradiosuppcareer').show();
                $('#divoncareer').hide();
            }
            else {
                $('#divcareer').hide();
                $('#divoncareer').show();
                $('#divradiosuppcareer').hide();
            }
            frm.find('.js--cancel').show();
            frm.find('.js--btsave' + componentName).show();        
        })
        .off('ifChecked', ':radio[name=supcarceer' + componentName + ']')
        .on('ifChecked', ':radio[name=supcarceer' + componentName + ']', function (e) {
            var frm = $(this).closest('form');
            supcareer = $(this).val();
            if ($(this).val() == 1) {
                $('#divsuppcareer').show();
            }
            else {
                $('#divsuppcareer').hide();
            }
            frm.find('.js--cancel').show();
            frm.find('.js--btsave' + componentName).show();
        })
        .off('ifChecked', ':radio[name=asset' + componentName + ']')
        .on('ifChecked', ':radio[name=asset' + componentName + ']', function (e) {
            var frm = $(this).closest('form');
            assets = $(this).val();
            //console.log($(this).val());
            if ($(this).val() == 1) {
                $('#divasset').show();
            }
            else {
                $('#divasset').hide();
            }
            frm.find('.js--cancel').show();
            frm.find('.js--btsave' + componentName).show(); 
        })
        .off('click', '.js--btsave'+componentName)
        .on('click', '.js--btsave' + componentName, function (e) {  
            var frm = $(this).closest('form');
            if (frm.validationEngine('validate')) {
                var applicantID = $('#applicantID' + componentName).val();
                var incomeID = $('#incomeID' + componentName).val();
                var supincomeID = $('#supincomeID' + componentName).val();
                var onicomeID = $('#onicomeID' + componentName).val();
                var assetID = $('#assetID' + componentName).val();
                var careerdata = {
                    IncomeID: incomeID,
                    CareerID: $('#career' + componentName).val(),
                }
                //console.log("careerdata", careerdata);
                var ispermanent
                if (supcareer == 1) {
                    ispermanent = true;
                }
                else {
                    ispermanent = false;
                }
                var applicantcareer = {
                    IncomeID: incomeID,
                    ApplicantID: applicantID,
                    IsPermanent: ispermanent,
                    OcupationPosition: $('#position' + componentName).val(),
                    Income: parseInt($('#income' + componentName).val()),
                    IncomeUnit: $('#incomeunit' + componentName).val(),
                    WorkPlace: $('#workplace' + componentName).val(),
                    TelphoneNo: $('#telno' + componentName).val(),
                    YearsExperience: $('#yearsexperience' + componentName).val(),
                }
                var supcareerdata = {
                    IncomeID: supincomeID,
                    CareerID: $('#supcareer' + componentName).val(),
                }
                var applicantsupcareer = {
                    IncomeID: supincomeID,
                    ApplicantID: applicantID,
                    IsPermanent: false,
                    OcupationPosition: null,
                    Income: parseInt($('#supincome' + componentName).val()),
                    IncomeUnit: $('#supincomeunit' + componentName).val(),
                    WorkPlace: $('#supworkplace' + componentName).val(),
                    TelphoneNo: $('#suptelno' + componentName).val(),
                    YearsExperience: $('#supyearsexperience' + componentName).val(),
                }
                var applicantnocareer = {
                    NoIncomeID: onicomeID,
                    ApplicantID: applicantID,
                    Cause: $('#case' + componentName).val(),
                    SupportBy: $('#supportby' + componentName).val(),
                    Income: parseInt($('#onincome' + componentName).val()),
                    IncomeUnit: $('#onincomeunit' + componentName).val(),
                }
                var applicantasset = {
                    AssetID: assetID,
                    ApplicantID: applicantID,
                    Asset: $('#asset' + componentName).val(),
                }
                var applicantexpense = [];
                const items = document.querySelectorAll("#divexpense .expense ");
                items.forEach(function (data, index) {
                    index++;
                    applicantexpense.push({
                        ApplicantID: applicantID,
                        Description: $("#expdesc-" + index).val(),
                        Amount: $("#expPermonth-" + index).val(),
                        ExpenseID: $("#expenseID-" + index).val(),
                    });
                });
                applicantdata = {
                    ApplicantID: applicantID,
                    Career: careerdata,
                    SupCareer: supcareerdata,
                    ApplicantIncome: applicantcareer,
                    ApplicantSupIncome: applicantsupcareer,
                    ApplicantOnincome: applicantnocareer,
                    ApplicantAsset: applicantasset,
                    ApplicantExpense: applicantexpense,
                    careerstatus: career,
                    supcareerstatus: supcareer,
                    assetstatus: assets,
                }
                $.ajax({
                    type: 'POST',
                    url: '/applicantcareer/saveapplicantdata',
                    data: { applicantdata: applicantdata },
                    beforeSend: function () { },
                    success: function (data) {
                        if (data.Status) {                            
                            //$('#expenseID-' + $(this).data('id')).remove();
                            SWSuccess.fire({                                
                                onClose: () => {
                                    console.log(data);
                                    $('#incomeID' + componentName).val(data.Data.incomeID);
                                    $('#supincomeID' + componentName).val(data.Data.supincomeID);
                                    $('#onicomeID' + componentName).val(data.Data.onincomeID);
                                    $('#assetID' + componentName).val(data.Data.assetID);
                                    $('.expense').remove();
                                    if (data.Data.expenseID != null) {
                                        var temp = Handlebars.compile($('#tmpl-lisaddexp-' + componentName).html());
                                        $('#counter' + componentName).val(data.Data.expenseID.length);
                                        if ($('#counter' + componentName).val() < 5) {
                                            frm.find('#addfield'+componentName).show();
                                        }
                                        else {
                                            frm.find('#addfield'+componentName).hide();
                                        }
                                        $.each(data.Data.expenseID, function (index, value) {
                                            index++;
                                            var DataSend = { Expense: value, Count: index };
                                            $('#divexpense').append(temp(DataSend));
                                            counter = index;
                                        });
                                    }
                                    
                                }
                            });
                        }
                        else {
                            SWError.fire({

                            });
                        }
                    },
                    error: function (err) {
                        console.log(err);
                        SWError.fire({

                        });
                    }
                });

                frm.find('.js--btsave' + componentName).hide();
                frm.find('.js--cancel').hide();
                frm.find('.header-icon').remove();
            }     
        })
    $('#addfield'+componentName).click(function () {        
        var count = $('#counter' + componentName).val();
        count++;
        $('#counter' + componentName).val(count);
        var frm = $('#frm' + componentName);
        var temp = Handlebars.compile($('#tmpl-lisaddexp-' + componentName).html());
        $('#divexpense').append(temp({ Count: count }));
        if (count >= 5) {
            frm.find('#addfield'+componentName).hide();           
            return false;
        } else {
            frm.find('#addfield' + componentName).show();
        } 
        $(".input-decimal").inputmask({ alias: "decimal", groupSeparator: ",", rightAlign: true, autoGroup: true, autoUnmask: true });
        frm.find('.js--cancel').show();
        frm.find('.js--btsave' + componentName).show();
        
    });

    





});