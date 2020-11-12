
function myConfirm() {
    event.preventDefault();
    var ciudad = $("#ciudad").val();
    alertify.confirm("¿Realmente desea borrar la ciudad" + ciudad + "?",
        function () {
            alertify.success('Eliminado con exito');
            return true;
        },
        function () {
            alertify.error('Cancelado');
        });
};


