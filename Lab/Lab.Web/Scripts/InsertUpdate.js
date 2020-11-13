$(document).ready(function () {
    $("#cityText").change(function () {

        if ($(this).val().length < 2) {
            $(this).css({
                "border-color": "red",
                "border-width": "1px"
            });
            $(".text-danger").show();
        } else {
            $(this).css("border-color", "lightgreen");
            $(".text-danger").hide();
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

