// Forms Multi Select

$( document ).ready(function() {

    setTimeout(function () {

        $(".multiselect-dropdown").select2({
            theme: "bootstrap4",
            width: "100%"
        });
        $(".multiselect-dropdown-other").select2({
            theme: "bootstrap4",
            width: "100%",
            maximumInputLength: 250,
            tags: true
        });
        $(".multiselect-dropdown-plaintext").select2({
            theme: "plaintext",
            width: "100%"
        });
        $('#example-single').multiselect({
            inheritClass: true
        });

        $('#example-multi').multiselect({
            inheritClass: true
        });

        $('#example-multi-check').multiselect({
            inheritClass: true
        });

    }, 2000);

});