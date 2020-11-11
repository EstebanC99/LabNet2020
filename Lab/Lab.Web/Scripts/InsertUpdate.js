$(document).ready(function () {
    $("#city-text").val($("#city-label").val())
    $("#city-text").change(function () {
        if ($(this).val().length < 2) {
            $(this).css("border-color", "red");
        } else {
            $(this).css("border-color", "blue");
        }
        $("#city-label").val($(this).val());
    })
});

