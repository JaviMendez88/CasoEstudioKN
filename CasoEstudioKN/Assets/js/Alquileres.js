$(document).ready(function () {

    $("#ddlCasa").change(function () {
        var idCasa = $(this).val();

        if (!idCasa) {
            $("#txtPrecio").val("");
            return;
        }

        $.get(urlObtenerPrecio, { idCasa: idCasa }, function (data) {
            $("#txtPrecio").val(data);
        });
    });

});