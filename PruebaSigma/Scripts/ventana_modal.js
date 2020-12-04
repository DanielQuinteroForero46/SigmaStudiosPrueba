//MOSTRAR VENTANA EMERGENTE PERSONALIZADA:
function mostrarAlert(titulo, informacion) {
    var tit = crearElemento("h4", { class: "modal-tit" }, [titulo]);
    var header = crearElemento("div", { class: "modal-header" }, [tit]);

    var span = crearElemento("span", { class: "close" }, ["&times;"]);
    header.appendChild(span);

    header.style.background = "#FC427B";

    var body = crearElemento("div", { class: "modal-body" });
    //Agregar párrafos al cuerpo de la ventana
    for (var i = 0; i < informacion.length; i++) {
        var info = crearElemento("p", { class: "modal-info", id: "p" + i }, [informacion[i]]);
        body.appendChild(info);
    }

    var divVentana = crearElemento("div", { class: "modal-content text-center", id: "modal-content" }, [header, body]);

    var divAlerta = crearElemento("div", { id: "miModal", class: "modal" }, [divVentana]);

    //Agregar botón para cerrar modal:
    var btnCerrar = crearElemento("button", { id: "btn-cerrar", class: "btn btn-sm btn-cerrar" }, ["Aceptar"]);
    divVentana.appendChild(btnCerrar);

    document.body.appendChild(divAlerta);
    var modal = document.getElementById("miModal");
    modal.style.display = "block";

    /*Evento para cerrar el modal (x)*/
    document.getElementsByClassName("close")[0].onclick = function () {
        document.body.removeChild(document.getElementById("miModal"));
    };
    /*Evento para cerrar el modal (botón)*/
    document.getElementsByClassName("btn-cerrar")[0].onclick = function () {
        document.body.removeChild(document.getElementById("miModal"));
    };

}