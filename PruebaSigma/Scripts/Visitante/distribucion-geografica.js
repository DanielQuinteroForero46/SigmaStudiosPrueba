let distribucionGeo = new Map();

obtenerDepartamentos = () => {
    $('#departamento').append($("<option></option>").text("Cargando..."));

    $.ajax({
        url: "/Home/ObtenerDepartamentos",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.length > 0) {
                distribucionGeo = new Map(Object.entries(JSON.parse(result)));
                //console.log(distribucionGeo);
                cargarDepartamentos();
            }
        },
        error: function (errorMessage) {
            console.log(errorMessage.responseText);
        }
    });
}

cargarDepartamentos = () => {
    console.log(distribucionGeo);
    $('#departamento').find('option').remove().end().append($("<option></option>").text("Seleccionar"));
    distribucionGeo.forEach((value, key) => {
        var option = $("<option></option>").text(key).val(key);
        $('#departamento').append(option);
    });
}