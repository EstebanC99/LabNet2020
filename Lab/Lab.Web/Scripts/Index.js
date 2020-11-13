
function conf() {
    var obj = $(event.target);
    var loc = $(obj).attr('href');
    var ob = $(obj).closest('tr');
    alertify.confirm("¿Realmente desea eliminar la ciudad?", function (e) {
        if (e) {
            $(ob).css('visibility', 'hidden');
            alertify.success("Eliminado", 0);
            setTimeout(function () {
                document.location.href = loc;
            }, 1500);
        } else {
            alertify.error("Cancelado", 0);
        }
    }).set('modal', false).pin();

    return false;
};
