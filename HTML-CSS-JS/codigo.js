$(document).ready(function(){

    $(".inputPersonal").change(function(){
        if ($(this).val().length > 2 || ($(this).val() > 0) && (Number.parseInt($(this).val()))){
            ChangeColor($(this), true);
        }else {
            ChangeColor($(this), false);
        }
    })

    $("#submit").click(function(){
        if (ValidateFields()){
            var nombreYApellido = $("#firstName").val() + ", " + $("#lastName").val();
            var edad = $("#age").val();
            var genero = $("input:radio[name=gender]:checked").val();
            alert("Registro exitoso \rNombre y apellido: " + nombreYApellido + "\rEdad: "+ edad + "\rGenero: " + genero);
            ClearEverything();
        }else{
            alert("CAMPOS INCOMPLETOS!!");
        };
    });

    $("#cancel").click(function(){
        ClearEverything();
        alert("REGISTRO CANCELADO");
    })

});

function ChangeColor(element, valido){
    if(valido){
        element.css("border-color", "rgba(0, 0, 0, 0.205)");
    }else {
        element.css("border-color", "rgba(255, 0, 0, 0.6)");
    }

}
function ValidateNombre() {
    if($("#firstName").val().length < 2){
        ChangeColor($("#firstName"), false);
        return false;
    } else {
        return true;
    }
}
function ValidateApellido() {
    if($("#lastName").val().length <2){
        ChangeColor($("#lastName"), false);
        return false;
    } else {
        return true;
    }
}
function ValidateEdad() {
    var edad = $("#age").val();
    if( edad < 1 || edad >120){
        ChangeColor($("#age"), false);
        return false;
    } else {
        return true;
    }
}
function ValidateGender() {
    return $("input:radio[name=gender]").is(":checked");  
}
function ClearEverything() {
    $("input:radio[name=gender]").attr(":checked", "false");
    $(".inputPersonal").val("");
    $(".inputPersonal").css("border-color", "rgba(0, 0, 0, 0.205)");
}

function ValidateFields () {
    var available = (ValidateNombre() & ValidateApellido() & ValidateEdad() & ValidateGender())
    return available;
}
