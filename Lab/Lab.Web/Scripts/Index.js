
function myConfirm() {
    event.preventDefault();
    alertify.confirm("¿Realmente desea borrar la ciudad?",
        function () {
            alertify.success('Eliminado con exito')
            return true;
        },
        function () {
            alertify.error('Cancelado')
            return true;
        });
    return true;
};


