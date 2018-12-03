$(document).on("click", ".btnDelete", function () {

    $('#playerId').val($(this).data('playerid'));
    $('#deleteModal').modal('show');
});