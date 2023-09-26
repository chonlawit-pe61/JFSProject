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
Common.DatetThaiFullFormat = function (datetime) {
    // var moment = require('moment');
    //ต้อง include file moment-with-locales.min.js ไว้ก่อน timezone
    moment.locale('th');
    return moment(datetime).isValid() ? 'วัน' + moment(datetime).format('dddd') + 'ที่ ' + moment(datetime).format('Do MMMM') + ' พ.ศ. ' + parseInt(moment(datetime).year() + 543) : null;
};
Common.frontendDatetimeFormat = function (datetime) {
    return moment(datetime).isValid() ? moment(datetime).format("DD/MM/YYYY HH:mm") : "-";
};

Common.backendDatetimeFormat = function (datetime) {
    return moment(datetime).isValid() ? moment(datetime).format("YYYY-MM-DD") : null;
};
Common.commaSeparateNumber = function(val) {
    while (/(\d+)(\d{3})/.test(val.toString())) {
        val = val.toString().replace(/(\d+)(\d{3})/, '$1' + ',' + '$2');
    }
    return val;
}
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
    var day = stringDate.substring(0, 2);
    var month = stringDate.substring(3, 5);
    var year = stringDate.substring(6, 10);
    var date = new Date(year, month, day);
    return date;
};
Common.JSONDate = function (dateStr) {
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
    var m, day;
    jsonDate = dateStr;
    var d = new Date(parseInt(jsonDate.substr(6)));
    day = d.getDate();
    return day
};
Common.JSONYear = function (dateStr) {
    var m, day;
    jsonDate = dateStr;
    var d = new Date(parseInt(jsonDate.substr(6)));
    return parseInt(d.getFullYear())
};
Common.JSONShortMonth = function (dateStr) {
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
    console.log(dateStr);
    var m, day,monthtext='';
    var month = ["","มกราคม","กุมภาพันธ์","มีนาคม","เมษายน","พฤษภาคม","มิถุนายน","กรกฎาคม","สิงหาคม","กันยายน","ตุลาคม","พฤศจิกายน","ธันวาคม"]
    jsonDate = dateStr;
    var d = new Date(parseInt(jsonDate.substr(6)));
    m = d.getMonth()+1;
   // if (m < 10)
    monthtext = month[m];
    if (d.getDate() < 10)
        day = d.getDate()
    else
        day = d.getDate();
    return d.getFullYear() != 1 ? (day + ' ' + monthtext + ' ' + parseInt(d.getFullYear() + 543)) : "";
};
Common.JSONShortDateThai = function (dateStr) {
   // console.log(dateStr);
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
Common.JSONDateEng = function (dateStr) {
    //console.log(dateStr);
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
    if ($(obj).find(".fa-chevron-down").length) {
        $(obj).find(".fa-chevron-down").removeClass("fa-chevron-down").addClass("fa-chevron-up");
    } else {
        $(obj).find(".fa-chevron-up").removeClass("fa-chevron-up").addClass("fa-chevron-down");
    }
}
Common.CollapsedCard = function (obj) {
    Common.swcithTabIcon($(obj).closest('.card'));
}


// ------------------------------------------------------- //
//   Home Full Slider
// ------------------------------------------------------ //

//Common.header = document.getElementById("nav-fixtop");
//Common.appheader = $('.app-header')[0].offsetHeight;
//Common.ScrollFix = function () {
//    // Get the header   
//    if (Common.header !== null) {
//        var sticky = Common.header.offsetTop - Common.appheader;
//        console.log(window.pageYOffset ,sticky)
//        if (window.pageYOffset > sticky) {
//            var xtop = Common.appheader;
//            Common.header.classList.add("fixednav");
//            Common.header.style.top = xtop +"px";
//        } else {
//            Common.header.classList.remove("fixednav");
//            Common.header.removeAttribute("style");
//        }
//    }
//};

