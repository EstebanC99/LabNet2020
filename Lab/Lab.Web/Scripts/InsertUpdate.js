$(document).ready(function () {
    $("#cityText").change(function () {
        if ($(this).val().length < 2) {
            $(this).css({
                "border-color": "red",
                "border-width": "1px"});
        } else {
            $(this).css("border-color", "blue");
        }
    })
    

});

