// SweetAlerts2

//SweetAlert2
//const SWNoti = Swal.mixin({
//    // toast: true,
//    //position: 'top-end',
//    showConfirmButton: true,
//    cancelButtonText: 'ยกเลิก',
//    confirmButtonText: 'ยืนยัน'
//});
const SWConfirm = Swal.mixin({
    showConfirmButton: true,
    title: 'ยืนยันบันทึกข้อมูล ?',
    icon: 'warning',
    cancelButtonText: 'ยกเลิก',
    confirmButtonText: 'ยืนยัน',
    showCancelButton: true,
    customClass: {
        confirmButton: 'btn btn-sm btn-primary p-2 mr-3',
        cancelButton: 'btn btn-sm btn-secondary p-2'
    },
    buttonsStyling: false
});
const SWChangeWorkStep = Swal.mixin({
    showConfirmButton: true,
    title: 'เปลี่ยนแปลงขั้นตอน ?',
    icon: 'warning',
    cancelButtonText: 'ยกเลิก',
    confirmButtonText: 'ยืนยัน',
    showCancelButton: true,
    customClass: {
        confirmButton: 'btn btn-sm btn-primary p-2 mr-3',
        cancelButton: 'btn btn-sm btn-secondary p-2'
    },
    buttonsStyling: false
});
const SWBackWorkStep = Swal.mixin({
    showConfirmButton: true,
    title: 'ย้อนขั้นตอน ?',
    icon: 'warning',
    cancelButtonText: 'ยกเลิก',
    confirmButtonText: 'ยืนยัน',
    showCancelButton: true,
    customClass: {
        confirmButton: 'btn btn-sm btn-primary p-2 mr-3',
        cancelButton: 'btn btn-sm btn-secondary p-2'
    },
    buttonsStyling: false
});
const SWDelfirm = Swal.mixin({
    showConfirmButton: true,
    title: 'ยืนยันลบข้อมูล ?',
    icon: 'warning',
    cancelButtonText: 'ยกเลิก',
    confirmButtonText: 'ยืนยัน',
    showCancelButton: true,
    customClass: {
        confirmButton: 'btn btn-sm btn-primary p-2 mr-3',
        cancelButton: 'btn btn-sm btn-secondary p-2'
    },
    buttonsStyling: false
});
const SWSuccess = Swal.mixin({
    icon: 'success',
    title: 'บันทึกเรียบร้อยแล้ว',
    showConfirmButton: false,
    timer: 1500
});
const SWError = Swal.mixin({
    icon: 'error',
    title: 'เกิดข้อผิดพลาด ลองใหม่อีกครั้ง',
    showConfirmButton: false,
    timer: 1500
});
const SWWarning = Swal.mixin({
    icon: 'warning',
    title: 'คุณแน่ใจที่จะใช้ข้อมูลนี้?',
    text: "โปรดตรวจสอบเพื่อให้แน่ใจว่าคุณจะใช้ขข้อมูลนี้",
    showConfirmButton: false,
    timer: 1500
});
const SWLoading = Swal.mixin({
    title: 'กำลังสร้างเอกสาร',
    allowEscapeKey: false,
    allowOutsideClick: false,    
    onOpen: () => {
        swal.showLoading();
    }
});
const SWMoney = Swal.mixin({
    icon: 'warning',
    title: 'จำนวนเงินที่อนุมัติกับที่ระบุไม่ตรงเท่ากัน',
    showConfirmButton: false,
    timer: 2000
});
const SWTranfirm = Swal.mixin({
    showConfirmButton: true,
    title: 'ต้องการสร้างรายการเบิกเงิน ?',
    icon: 'warning',
    cancelButtonText: 'ยกเลิก',
    confirmButtonText: 'ยืนยัน',
    showCancelButton: true,
    customClass: {
        confirmButton: 'btn btn-sm btn-primary p-2 mr-3',
        cancelButton: 'btn btn-sm btn-secondary p-2'
    },
    buttonsStyling: false
});


$( document ).ready(function() {

    $('.btn-show-swal').each(function () {
        $(this).click(function () {

            var alertType = $(this).attr('data-type');

            Swal({
                title: 'Type: ' + alertType,
                text: 'Do you want to continue',
                type: alertType,
                confirmButtonText: 'Cool'
            });

        });
    });

    $('.btn-show-swal-basic').click(function () {

        Swal({
            text: 'The Internet?',
            title: 'That thing is still around?',
            type: 'question',
        });

    });

    $('.btn-show-swal-basic-2').click(function () {

        Swal({
            type: 'error',
            title: 'Oops...',
            text: 'Something went wrong!',
            footer: '<a href>Why do I have this issue?</a>'
        });

    });

    $('.btn-show-swal-basic-3').click(function () {

        Swal({
            title: 'Custom animation with Animate.css',
            animation: false,
            customClass: 'animated lightSpeedIn'
        });

    });

});