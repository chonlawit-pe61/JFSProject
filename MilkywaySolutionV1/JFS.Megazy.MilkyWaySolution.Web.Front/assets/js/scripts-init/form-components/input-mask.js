// Forms Input Mask

$( document ).ready(function() {
    $(".input-mask-trigger").inputmask();
    $(".input-decimal").inputmask({ alias: "decimal", groupSeparator: ",", rightAlign: true, autoGroup: true, autoUnmask: true });
    $(".input-tel").inputmask({ mask: "99-99999999", placeholder:" "});
    $(".input-email").inputmask({ alias: "email"});

});