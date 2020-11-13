$(document).ready(function () {
    $("#cityText").change(function () {

        if ($(this).val().length < 2) {
            $(this).fadeIn().css({
                "border-color": "#F44336",
                "border-width": "1px"
            });
            $(".text-danger").fadeIn().show();
        } else {
            $(this).css("border-color", "#4CAF50");
            $(".text-danger").fadeOut("slow");
        }
    });


    $(".text-danger").hide();


    $("input[type=submit]").click(function () {
        event.preventDefault();
        if ($("#cityText").val().length >= 2) {
            alertify.success('Cargado con exito');
            $("#form-insert").submit();
        } else {
            alertify.error('Error al cargar');
            return false;
        };
    });

});

