$(document).ready(function () {
    obtenerDepartamentos();

    $('#departamento').change(function () {
        obtenerCiudades($('#departamento').val());
    });

    $('#form-visitante').submit(function (e) {
        e.preventDefault();
        guardarInfoVisitante();
    });
});


guardarInfoVisitante = () => {
    var visitante = {
        Departamento: $('#departamento').val(),
        Ciudad: $('#ciudad').val(),
        Nombre: $('#nombre').val(),
        Correo: $('#correo').val(),
    }

    $.ajax({
        url: "/Home/GuardarVisitante",
        type: "POST",
        data: JSON.stringify(visitante),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
        },
        error: function (errorMessage) {
            console.log(errorMessage.responseText);
        }
    });
}