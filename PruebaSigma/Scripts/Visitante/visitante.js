$(document).ready(function () {
    obtenerDepartamentos();
    //Evento generado al seleccionar el departamento para cargar las ciudades correspondiente
    $('#departamento').change(function () {
        obtenerCiudades($('#departamento').val());
    });

    //Evento generado al seleccionar "Enviar":
    $('#form-visitante').submit(function (e) {
        e.preventDefault();
        guardarInfoVisitante();
    });
});


guardarInfoVisitante = () => {
    //Obtener datos del formulario:
    var visitante = {
        Departamento: ($("#departamento").val() == "Seleccionar") ? "" : $("#departamento").val(),
        Ciudad: ($("#ciudad").val() == "Seleccionar") ? "" : $("#ciudad").val(),
        Nombre: $("#nombre").val(),
        Correo: $("#correo").val(),
    }

    //Enviar información del visitante al Backend (Las validaciones de campos se hacen allí)
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
            if (regResponse.Success) descripcionID = "ID del Visitante: " + regResponse.getVisitanteId();

            mostrarAlert("Señor usuario", [regResponse.getMensage(), descripcionID]);
        },
        error: function (errorMessage) {
            console.log(errorMessage.responseText);
        }
    });
}

//Estructura de la respuesta obtenida por el Backend:
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