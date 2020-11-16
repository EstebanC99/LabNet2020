$(document).ready(function () {

    DefineHours();

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