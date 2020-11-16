$(document).ready(function () {

    DefineHours();

    ValidateError();

    $("#insertSubmit").click(function () {
        event.preventDefault();
        if ($("#textCity").val().length >= 2) {
            alertify.success('Cargado con exito');
            setTimeout(function () {
                $("#form-insert").submit();
            }, 1500);
        } else {
            alertify.error('Error al cargar');
            return false;
        };
    });

});


function DefineHours() {
    var fecha = new Date();
    var hora = fecha.getHours();
    if ((hora >= 21 || hora <= 6)) {
        $("#divWeather").css("background-image", "url(https://media.giphy.com/media/ZLdy2L5W62WGs/giphy.gif");
    } else {
        $("#divWeather").css("background-image, background-size", "url(https://media.giphy.com/media/o7R0zQ62m8Nk4/giphy.gif), cover");
    };
};

