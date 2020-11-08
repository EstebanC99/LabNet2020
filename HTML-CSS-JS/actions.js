$(document).ready(function(){
    $(".PersonalInput").change(function(){
        if ($(this).val().length > 2 || ($(this).val() > 0) && (Number.parseInt($(this).val()))){
            ChangeColor($(this), true);
        }else {
            ChangeColor($(this), false);
        }
    })
});

function ChangeColor(element, valido){
    if(valido){
        element.css("border", "none")
    }else {
        element.css("border-bottom", "1px solid rgba(255, 0, 0, 0.6)");
    }

}
