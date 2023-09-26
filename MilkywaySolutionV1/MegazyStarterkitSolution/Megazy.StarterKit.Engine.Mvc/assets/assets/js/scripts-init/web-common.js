var Common = Common || {};
// page : array path chain
// ["home", "index"] => "home/index"
Common.windowRedirection = function (page) {
    var pagePath = "";

    if (page != undefined) {
        pagePath = page.join("/");
    }
    window.location = "//" + window.location.host + "/" + pagePath.toLowerCase();
};

Common.windowRefresh = function () {
    location.reload(true);
};

Common.windowHistoryBack = function () {
    history.go(-1);
};


/***********************************************************/
/******************** Validation Engine ********************/
Common.ajaxValidationCallback = function (status, form, json, options) {

    if (status === true) {
        alert("the form is valid!");
        // uncomment these lines to submit the form to form.action
        // form.validationEngine('detach');
        // form.submit();
        // or you may use AJAX again to submit the data
    }
};

Common.initValidator = function ($form, callback) {
    var checkAjaxField = callback == undefined ? false : true;
    var validatorOption = {
        showArrowOnRadioAndCheckbox: true,
        scroll: false,
        fadeDuration: 0,
        autoHidePrompt: true,
        promptPosition: "bottomLeft"
    };


    if (checkAjaxField) {
        validatorOption.ajaxFormValidation = true;
        validatorOption.ajaxFormValidationMethod = 'post';
        validatorOption.onAjaxFormComplete = callback;

        $form.validationEngine(validatorOption);

        $form.bind("jqv.field.result", function (event, field, errorFound, prompText) {
            var $field = $(field);

            if ($field.attr("data-check-ajax-request") != undefined && $field.attr("data-callback-function") != undefined) {
                if ($field.attr("data-check-ajax-request") === "true") {

                    // call function that set act like callback function
                    eval($field.attr("data-callback-function") + "('" + $field.attr("id") + "', '" + prompText + "')");
                }
            }
        });
    } else {
        $form.validationEngine(validatorOption);
    }
};

Common.showErrors = function ($input, message, validate, type) {
    $input
        .validationEngine('showPrompt', (message !== "" ? message : Common.allRules[validate][type]), 'red', "topLeft", true);
};

Common.HideErrors = function ($input) {
    $input.validationEngine('hide');
};

Common.hideAllErrors = function ($form) {
    $form.validationEngine('hideAll');
};

Common.isValidForm = function ($form) {
    // $form.validationEngine('hideAll');
    return $form.validationEngine('validate');
};

Common.onFormChange = function ($form) {
    var $button = $form.find('button[type="submit"]');
    if ($button.length > 0) {
        $button.attr('disabled', !Common.isValidForm($form));
    }
};
/******************* END Validation Engine *****************/
/***********************************************************/


/***********************************************************/
/********************** Scroll Effect **********************/
Common.scrollToTop = function () {
    $('html, body')
    .animate({
        scrollTop: $(document.body).offset().top
    }, 'slow');
};

Common.scrollToForm = function () {
    $('html, body')
    .animate({
        scrollTop: $(".panel-separator:visible:last").offset().top
    }, 'slow');
};
/******************** END Scroll Effect ********************/
/***********************************************************/
Common.getRandomIntInclusive = function (min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
Common.isSupportDownloadAttribute = function () {
    // When used on an anchor, this attribute signifies that the browser should download the resource
    // the anchor points to rather than navigate to it.
    var a = document.createElement('a');
    return (typeof a.download != "undefined");
};

Common.getObjectFromForm = function ($form) {
    var obj = {};
    $.each(JSON.parse(JSON.stringify($form.serializeArray())), function (idx, val) {
        obj[val.name] = val.value;
    });

    return obj;
};

Common.defaultBlankData = function (text) {
    return (text === undefined || text === null || text === "") ? "-" : text;
};

Common.defaultEmptyString = function (text) {
    return (text === undefined || text === null || text === "") ? "" : text;
};

Common.getEpochTime = function () {
    return (new Date).getTime();
};
Common.pad2 = function (n) { return n < 10 ? '0' + n : n }
Common.DateIsValid= function(d){
        return d instanceof Date && !isNaN(d);
}
Common.frontendDatetimeFormat = function (date) {
    if (Common.DateIsValid(date)) {
        return (Common.pad2(date.getDate()) + '/' + Common.pad2(date.getMonth() + 1) +'/'+date.getFullYear().toString() + ' ' + Common.pad2(date.getHours())+':' + Common.pad2(date.getMinutes()) +':'+ Common.pad2(date.getSeconds()));
    } else {
        return "";
    }
};
Common.DatetThaiFullFormat = function (datetime) {
    // var moment = require('moment');
    //ต้อง include file moment-with-locales.min.js ไว้ก่อน timezone
    moment.locale('th');
    return moment(datetime).isValid() ? 'วัน' + moment(datetime).format('dddd') + 'ที่ ' + moment(datetime).format('Do MMMM') + ' พ.ศ. ' + parseInt(moment(datetime).year() + 543) : null;
};
Common.backendDatetimeFormat = function (date) {
    //let [month, date, year]    = new Date().toLocaleDateString("en-US").split("/")
    if (Common.DateIsValid(date)) {
        return (date.getFullYear().toString() + '-' + Common.pad2(date.getMonth() + 1) + '-' + Common.pad2(date.getDate())  );
    } else {
        return null;
    }
};
Common.ThaiDateFormat = function (date) {
    if (Common.DateIsValid(date)) {
        let ddmmyyy = (Common.pad2(date.getDate()) + '/' + Common.pad2(date.getMonth() + 1) + '/' + date.getFullYear().toString());
        if (ddmmyyy != '01/01/0001') {
            return (Common.pad2(date.getDate()) + '/' + Common.pad2(date.getMonth() + 1) + '/' + (date.getFullYear()+543).toString());
        } else {
            return '';
        }        
    } else {
        return '';
    }
};
Common.commaSeparateNumber = function(val) {
    while (/(\d+)(\d{3})/.test(val.toString())) {
        val = val.toString().replace(/(\d+)(\d{3})/, '$1' + ',' + '$2');
    }
    return val;
}
Common.backendDatetimeFormatThai = function (date) {
    if (Common.DateIsValid(date)) {
        let ddmmyyy = (Common.pad2(date.getDate()) + '/' + Common.pad2(date.getMonth() + 1) + '/' + date.getFullYear().toString());
        if (ddmmyyy != '01/01/0001') {
            return (Common.pad2(date.getDate()) + '/' + Common.pad2(date.getMonth() + 1) + '/' + date.getFullYear().toString());
        } else {
            return null;
        }
    } else {
        return null;
    }
};
Common.formatNumber = function (num) {
    self.decimals = 2;
self.options = {
    useGrouping: true, // 1,000,000 vs 1000000
    separator: ',', // character to use as a separator
    decimal: '.', // character to use as a decimal
    prefix: '', // optional text before the result
    suffix: '', // optional text after the result
};
    var neg = (num < 0),
        x, x1, x2, x3, i, len;
    num = Math.abs(num).toFixed(self.decimals);
    num += '';
    x = num.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? self.options.decimal + x[1] : '';
    if (self.options.useGrouping) {
        x3 = '';
        for (i = 0, len = x1.length; i < len; ++i) {
            if (i !== 0 && ((i % 3) === 0)) {
                x3 = self.options.separator + x3;
            }
            x3 = x1[len - i - 1] + x3;
        }
        x1 = x3;
    }

    return (neg ? '-' : '') + self.options.prefix + x1 + x2 + self.options.suffix;
}
Common.convertStringToJSDateFormat = function (stringDate) {
    if ((dateStr === undefined || dateStr === null || dateStr === "")) return "";
    var day = stringDate.substring(0, 2);
    var month = stringDate.substring(3, 5);
    var year = stringDate.substring(6, 10);
    var date = new Date(year, month, day);
    return date;
};
Common.convertStringThaiToJSDateFormat = function (dateStr) {
    console.log(dateStr);
    if ((dateStr === undefined || dateStr === null || dateStr === "")) return "";
    var day = dateStr.substring(0, 2);
    var month = dateStr.substring(3, 5);
    var year = dateStr.substring(6, 10);
    var year = year - 543;
    var date = new Date(month + '/' + day+'/'+year);
    return date;
};
Common.convertStringThaiToJSDateStr = function (dateStr) {

    if ((dateStr === undefined || dateStr === null || dateStr === "")) return "";
    var day = dateStr.substring(0, 2);
    var month = dateStr.substring(3, 5);
    var year = dateStr.substring(6, 10);
    var year = year - 543;
    var strDate = year + '-' + month + '-' + day;

    return strDate;
};
Common.JSONDate = function (dateStr) {
    if ((dateStr === undefined || dateStr === null || dateStr === "")) return "";
    var m, day;
    jsonDate = dateStr;
    var d = new Date(parseInt(jsonDate.substr(6)));
    m = d.getMonth() + 1;
    if (m < 10)
        m = '0' + m
    if (d.getDate() < 10)
        day = '0' + d.getDate()
    else
        day = d.getDate();
    return d.getFullYear() != 1 ? (day + '/' + m + '/' + parseInt(d.getFullYear())) : "";
};
Common.JSONDay = function (dateStr) {
    if ((dateStr === undefined || dateStr === null || dateStr === "")) return "";
    var m, day;
    jsonDate = dateStr;
    var d = new Date(parseInt(jsonDate.substr(6)));
    day = d.getDate();
    return day
};
Common.JSONYear = function (dateStr) {
    if ((dateStr === undefined || dateStr === null || dateStr === "")) return "";
    var m, day;
    jsonDate = dateStr;
    var d = new Date(parseInt(jsonDate.substr(6)));
    return parseInt(d.getFullYear())
};
Common.JSONShortMonth = function (dateStr) {
    if ((dateStr === undefined || dateStr === null || dateStr === "")) return "";
    var m, day, monthtext = '';
    var month = ["", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
    jsonDate = dateStr;
    var d = new Date(parseInt(jsonDate.substr(6)));
    m = d.getMonth() + 1;
    // if (m < 10)
    monthtext = month[m];
    return monthtext
};
Common.JSONDateThai = function (dateStr) {
    if (dateStr === undefined || dateStr === null || dateStr === "") {
        return '';
    } else {
        var m, day, monthtext = '';
        var month = ["", "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม"]
        jsonDate = dateStr;
        var d = new Date(parseInt(jsonDate.substr(6)));
        m = d.getMonth() + 1;
        // if (m < 10)
        monthtext = month[m];
        if (d.getDate() < 10)
            day = d.getDate()
        else
            day = d.getDate();
        return d.getFullYear() != 1 ? (day + ' ' + monthtext + ' ' + parseInt(d.getFullYear() + 543)) : "";
    }
};
Common.JSONDateTimeISOThai = function (dateStr) {
    //if (moment(dateStr).isValid()) return "";
    var date = moment(dateStr).format('DD-MM-YYYY');
    var m, day, monthtext = '';    
    var month = ["", "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม"]
    return moment(dateStr).format('D') + ' ' + month[moment(dateStr).format('M')] + ' ' + moment(dateStr).add(543, 'years').format('YYYY');
};
Common.JSONShortDateThai = function (dateStr) {
   // console.log(dateStr);
    if ((dateStr === undefined || dateStr === null || dateStr === "")) return "";
    var m, day, monthtext = '';
    var month = ["", "ม.ค.", "ก.พ.", "มี.ค.", "เม.ย.", "พ.ค.", "มิ.ย.", "ก.ค.", "ส.ค.", "ก.ย.", "ต.ค.", "พ.ย.", "ธ.ค."]
    jsonDate = dateStr;
    var d = new Date(parseInt(jsonDate.substr(6)));
     m = d.getMonth() + 1;
    // if (m < 10)
    monthtext = month[m];
    if (d.getDate() < 10)
        day = d.getDate()
    else
        day = d.getDate();
    return d.getFullYear() != 1 ? (day + ' ' + monthtext + ' ' + parseInt(d.getFullYear() + 543)) : "";
};

Common.DateStringDateThai = function (dateStr) {
    if ((dateStr === undefined || dateStr === null || dateStr === "")) return "";
    var m, day, monthtext = '';
    var month = ["", "ม.ค.", "ก.พ.", "มี.ค.", "เม.ย.", "พ.ค.", "มิ.ย.", "ก.ค.", "ส.ค.", "ก.ย.", "ต.ค.", "พ.ย.", "ธ.ค."]
    var d = new Date(dateStr);
    m = d.getMonth() + 1;
    // if (m < 10)
    monthtext = month[m];
    if (d.getDate() < 10)
        day = d.getDate()
    else
        day = d.getDate();
    return d.getFullYear() != 1 ? (day + ' ' + monthtext + ' ' + parseInt(d.getFullYear() + 543)) : "";
};
//ค.ศ.Ex:"2550/03/30" to "30 มีนาคม 2550"
Common.IDCardDateToDateThai = function (dateStr) {
    if ((dateStr === undefined || dateStr === null || dateStr === "")) return "";
    dateStr = dateStr.toString();
    var dd, yyyy, monthtext = '';
    var month = ["", "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม"]
    var len = dateStr.toString().length;
    if (len == 8) {
        yyyy = dateStr.substring(0, 4);
        mm = dateStr.substring(4, 6);
        m = parseInt(mm);
        monthtext = month[m];
        dd = parseInt(dateStr.substring(6, 8));
    } else if (len == 6) {
        yyyy = dateStr.substring(0, 4);
        mm = dateStr.substring(4, 6);
        m = parseInt(mm);
        monthtext = month[m];
    } else if (len == 4) {
        yyyy = dateStr.substring(0, 4);
    }
    return Common.defaultBlankData(dd) + '  ' + Common.defaultBlankData(monthtext) + '  ' + Common.defaultBlankData(yyyy.toString());
};
//พ.ศ.Ex: "2550/03/30" to "30/03/2550"
Common.IDCardDateThaiToDateDDMMYYY = function (dateStr) {
    console.log(dateStr);
    if ((dateStr === undefined || dateStr === null || dateStr === "")) return "";
    dateStr = dateStr.toString();
    var dd, yyyy;
    var len = dateStr.toString().length;
    if (len == 8) {
        yyyy = parseInt(dateStr.substring(0, 4));
        mm = dateStr.substring(4, 6);
        dd = dateStr.substring(6, 8);
    } else if (len == 6) {
        yyyy = parseInt(dateStr.substring(0, 4));
        mm = dateStr.substring(4, 6);
    } else if (len == 4) {
        yyyy = parseInt(dateStr.substring(0, 4));
    }
    return Common.defaultBlankData(dd) + '/' + Common.defaultBlankData(mm) + '/' + Common.defaultBlankData(yyyy);
};
//พ.ศ.Ex: "2550/03/30" to "30/03/2007"
Common.IDCardDateThaiToDateEN = function (dateStr) {
    if ((dateStr === undefined || dateStr === null || dateStr === "")) return "";
    dateStr = dateStr.toString();
    var dd, yyyy, monthtext = '';
    var len = dateStr.toString().length;
    if (len == 8) {
        yyyy = parseInt(dateStr.substring(0, 4)) - 543;
        mm = dateStr.substring(4, 6);
        dd = dateStr.substring(6, 8);
    } else if (len == 6) {
        yyyy = parseInt(dateStr.substring(0, 4)) - 543;
        mm = dateStr.substring(4, 6);
    } else if (len == 4) {
        yyyy = parseInt(dateStr.substring(0, 4)) - 543;
    }
    return Common.defaultBlankData(dd) + '/' + Common.defaultBlankData(mm) + '/' + Common.defaultBlankData(yyyy);
};
Common.JSONDateEng = function (dateStr) {
    if ((dateStr === undefined || dateStr === null || dateStr === "")) return "";
    var m, day, monthtext = '';
    var month = ["", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
    jsonDate = dateStr;
    var d = new Date(parseInt(jsonDate.substr(6)));
    m = d.getMonth() + 1;
    // if (m < 10)
    monthtext = month[m];
    if (d.getDate() < 10)
        day = '0' + d.getDate()
    else
        day = d.getDate();
    return d.getFullYear() != 1 ? (day + ' ' + monthtext + ' ' + parseInt(d.getFullYear())) : "";
};

Common.JSONDateWithTimeThai = function (dateStr) {
    if ((dateStr === undefined || dateStr === null || dateStr === "")) return "";
    var monthtext = '';
    var month = ["", "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม"]
    jsonDate = dateStr;
    var d = new Date(parseInt(jsonDate.substr(6)));
    var m, day;
    m = d.getMonth() + 1;
    monthtext = month[m];
    if (m < 10)
        m = '0' + m
    if (d.getDate() < 10)
        day = '0' + d.getDate()
    else
        day = d.getDate();
    var formattedDate = day + " " + monthtext + " " + parseInt(d.getFullYear() + 543);
    var hours = (d.getHours() < 10) ? "0" + d.getHours() : d.getHours();
    var minutes = (d.getMinutes() < 10) ? "0" + d.getMinutes() : d.getMinutes();
    var formattedTime = hours + ":" + minutes;
    formattedDate = formattedDate + "  " + formattedTime;
    return d.getFullYear() != 1 ? formattedDate : "";
};
Common.JSONDateWithTime = function (dateStr) {
    if ((dateStr === undefined || dateStr === null || dateStr === "")) return "";
    jsonDate = dateStr;
    var d = new Date(parseInt(jsonDate.substr(6)));
    var m, day;
    m = d.getMonth() + 1;
    if (m < 10)
        m = '0' + m
    if (d.getDate() < 10)
        day = '0' + d.getDate()
    else
        day = d.getDate();
    var formattedDate = day + "/" + m + "/" + d.getFullYear();
    var hours = (d.getHours() < 10) ? "0" + d.getHours() : d.getHours();
    var minutes = (d.getMinutes() < 10) ? "0" + d.getMinutes() : d.getMinutes();
    var formattedTime = hours + ":" + minutes;
    formattedDate = formattedDate + " " + formattedTime;
    return formattedDate;
};
Common.GetDate = function () {
    var d = new Date();
    var month = d.getMonth() + 1;
    var day = d.getDate();
    return  (day < 10 ? '0' : '') + day+ '/' +
        (month < 10 ? '0' : '') + month + '/' +
        d.getFullYear();
    //return d.getFullYear() + '/' +
    //    (month < 10 ? '0' : '') + month + '/' +
    //    (day < 10 ? '0' : '') + day;
}
//console.log(moment().subtract(1, 'years').format('L'));
Common.DiffDays = function(dt2, dt1) {

    var diff = (dt2.getTime() - dt1.getTime()) / 1000;
    diff /= (60 * 60 * 24);
    return Math.round(diff);

}
// Convert a data URI to blob
Common.dataURItoBlob = function (dataURI, fileType) {
    var byteString = atob(dataURI.split(',')[1]);
    var ab = new ArrayBuffer(byteString.length);
    var ia = new Uint8Array(ab);
    for (var i = 0; i < byteString.length; i++) {
        ia[i] = byteString.charCodeAt(i);
    }
    return new Blob([ab], {
        type: (fileType != undefined ? fileType : 'image/png')
    });
};

Common.init = function () {
    Common.allRules = $.validationEngineLanguage.allRules;
};

Common.getParameterByName = function (name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
     results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
};
Common.LandArea = {};
Common.ConversionSqrMateToRaiNganWah = function (sqrMate)
{
    var rai = 0, ngan = 0, sqrWah = 0;
    if (sqrMate > 0) {
        rai = Math.floor(sqrMate / 1600);
        ngan = Math.floor(((sqrMate / 1600) - rai) * 4);
        sqrWah = (sqrMate / 4) - ((rai * 400) + (ngan * 100));
        sqrWah = Math.round(sqrWah * 100) / 100;
    }
    return Common.LandArea = { rai: rai, ngan: ngan, wah: sqrWah };      
 };

Common.GetFriendlyTitle = function (title) {
    var encodedUrl = title.toString().toLowerCase();
    encodedUrl = encodedUrl.split(/\&+/).join("-and-");
    encodedUrl = encodedUrl.split(/[^a-z0-9ก-๙]/).join("-");
    encodedUrl = encodedUrl.split(/-+/).join("-");
    encodedUrl = encodedUrl.trim('-');
    return encodedUrl;
};
Common.swcithTabIcon = function (obj) {
    //if ($(obj).find(".fa-chevron-down").length) {
    //    $(obj).find(".fa-chevron-down").removeClass("fa-chevron-down").addClass("fa-chevron-up");
    //} else {
    //    $(obj).find(".fa-chevron-up").removeClass("fa-chevron-up").addClass("fa-chevron-down");
    //}
}
Common.CollapsedCard = function (obj) {
    Common.swcithTabIcon($(obj).closest('.card'));
}

