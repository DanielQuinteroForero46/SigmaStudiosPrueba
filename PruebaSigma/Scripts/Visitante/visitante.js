$(document).ready(function () {
    obtenerDepartamentos();

    $('#departamento').change(function () {
        obtenerCiudades($('#departamento').val());
    });
});