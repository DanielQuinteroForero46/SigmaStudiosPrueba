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
        Departamento: ($("#departamento").val() == "Seleccionar") ? "" : $("#departamento").val(),
        Ciudad: ($("#ciudad").val() == "Seleccionar") ? "" : $("#ciudad").val(),
        Nombre: $("#nombre").val(),
        Correo: $("#correo").val(),
    }

    $.ajax({
        url: "/Home/GuardarVisitante",
        type: "POST",
        data: JSON.stringify(visitante),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            regResponse = new RegisterResponse(result);
            var descripcionID = "";
            if (regResponse.Success) descripcionID = "\nID del Visitante: " + regResponse.getVisitanteId();

            alert(regResponse.getMensage() + descripcionID);
        },
        error: function (errorMessage) {
            console.log(errorMessage.responseText);
        }
    });
}

class RegisterResponse {
    constructor(response) {
        response && Object.assign(this, response);
    }

    getMensage() {
        return this.Mensaje;
    }

    getSuccess() {
        return this.Success;
    }

    getVisitanteId() {
        return this.VisitanteId;
    }
}