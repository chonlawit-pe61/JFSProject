
Handlebars.registerHelper('formatePriceNumber', function (val) {
    return Common.commaSeparateNumber(val);
});
Handlebars.registerHelper('formatePrice', function (val) {
    return numeral(val).format('(0.0 a)');  //Common.commaSeparateNumber(val);
});
Handlebars.registerHelper('index', function (val) {
    return val + 1;  //Common.commaSeparateNumber(val);
});
(function () {
    function checkCondition(v1, operator, v2) {
        switch (operator) {
            case '==':
                return (v1 == v2);
            case '===':
                return (v1 === v2);
            case '!==':
                return (v1 !== v2);
            case '<':
                return (v1 < v2);
            case '<=':
                return (v1 <= v2);
            case '>':
                return (v1 > v2);
            case '>=':
                return (v1 >= v2);
            case '&&':
                return (v1 && v2);
            case '||':
                return (v1 || v2);
            default:
                return false;
        }
    }

    Handlebars.registerHelper('ifCond', function (v1, operator, v2, options) {
        return checkCondition(v1, operator, v2)
            ? options.fn(this)
            : options.inverse(this);
    });
}());
Handlebars.registerHelper('FormateDate', function (date) {
    return Common.frontendDatetimeFormat(date);
});
Handlebars.registerHelper('compare', function (lvalue, rvalue, options) {

    if (arguments.length < 3)
        throw new Error("Handlerbars Helper 'compare' needs 2 parameters");

    var operator = options.hash.operator || "==";

    var operators = {
        '==': function (l, r) { return l == r; },
        '===': function (l, r) { return l === r; },
        '!=': function (l, r) { return l != r; },
        '<': function (l, r) { return l < r; },
        '>': function (l, r) { return l > r; },
        '<=': function (l, r) { return l <= r; },
        '>=': function (l, r) { return l >= r; },
        'typeof': function (l, r) { return typeof l === r; }
    }

    if (!operators[operator])
        throw new Error("Handlerbars Helper 'compare' doesn't know the operator " + operator);

    var result = operators[operator](lvalue, rvalue);

    if (result) {
        return options.fn(this);
    } else {
        return options.inverse(this);
    }

});
Handlebars.registerHelper('JSONDate', function (title) {
    return Common.JSONDate(title);
});
Handlebars.registerHelper('JSONDateThai', function (title) {
    return Common.JSONDateThai(title);
});
Handlebars.registerHelper('JSONDateEng', function (title) {
    return Common.JSONDateEng(title);
});
Handlebars.registerHelper('JSONShortDateThai', function (title) {
    return Common.JSONShortDateThai(title);
});
Handlebars.registerHelper('JSONDateWithTimeThai', function (title) {
    return Common.JSONDateWithTimeThai(title);
});
Handlebars.registerHelper('GetFriendlyTitle', function (title) {
    return Common.GetFriendlyTitle(title);
});
Handlebars.registerHelper("RowNumber", function (value, options) {
    return parseInt(value) + 1;
});
Handlebars.registerHelper('JSONDateTimeISOThai', function (title) {
    return Common.JSONDateTimeISOThai(title);
});
Handlebars.registerHelper('KPI', function (currenworkstepid,lastworkstepid,lastkpiday) {
    let text = '';
  
    if (currenworkstepid > 0 && currenworkstepid <= lastworkstepid) {
        if (lastkpiday >= 14 && lastkpiday <= 19) {
            text = '<i class="icon ion-android-alert text-warning" data-toggle="tooltip" title="ใกล้กึงกำหนด KPI (' + lastkpiday+' วัน)"></i>';
        } else if (lastkpiday >= 20) {
            text = '<i class="icon ion-android-alert text-danger" data-toggle="tooltip" title="เกินกำหนด KPI (ผ่านมาแล้ว' + lastkpiday +' วัน)"></i>';
        }
    }
    return new Handlebars.SafeString(text);
});
Handlebars.registerHelper('OverDue', function (d) {
    let text = '';
        if (d > 0 && d <= 14) {
            text = '<i class="icon ion-android-alert text-warning" title="ใกล้กึงกำหนดรายงานตัว (' + d + ' วัน)"></i>';
        } else if (d <= -1) {
            text = '<i class="icon ion-android-alert text-danger" title="เกินกำหนดรายงานตัว (ผ่านมาแล้ว' + Math.abs(d) + ' วัน)"></i>';
        }
    return new Handlebars.SafeString(text);
});
Handlebars.registerHelper('defaultBlankData', function (text) {
    return Common.defaultBlankData(text);
});
Handlebars.registerHelper('IDCardDateToDateThai', function (text) {
    return Common.IDCardDateToDateThai(text);
});
Handlebars.registerHelper('IDCardDateThaiToDateEN', function (text) {
    return Common.IDCardDateThaiToDateEN(text);
});
Handlebars.registerHelper('IDCardDateThaiToDateDDMMYYY', function (text) {
    return Common.IDCardDateThaiToDateDDMMYYY(text);
});
