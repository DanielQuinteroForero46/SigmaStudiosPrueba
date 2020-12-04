let distribucionGeo = new Map();

obtenerDepartamentos = () => {
    $('#departamento').append($("<option></option>").text("Cargando..."));

    $.ajax({
        url: "/Home/ObtenerDepartamentos",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            distribucionGeo = new Map(Object.entries(JSON.parse(result)));
            //console.log(distribucionGeo);
            cargarDepartamentos();
        },
        error: function (errorMessage) {
            console.log(errorMessage.responseText);
        }
    });
}

cargarDepartamentos = () => {
    $('#departamento').find('option').remove().end().append($("<option></option>").text("Seleccionar"));
    distribucionGeo.forEach((value, key) => {
        var option = $("<option></option>").text(key).val(key);
        $('#departamento').append(option);
    });
}

obtenerCiudades = (departamento) => {
    $('#ciudad').find('option').remove().end().append($("<option></option>").text("Seleccionar"));
    departamento = distribucionGeo.get(departamento);
    if (departamento != undefined) {
        departamento.forEach((ciudad) => {
            var option = $("<option></option>").text(ciudad).val(ciudad);
            $('#ciudad').append(option);
        });
    }
}