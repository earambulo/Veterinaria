Listar();

function Listar() {
    $.get("/raza/ListarRazas", function (data) {
        // alert(JSON.stringify(data));
        crearListado(data);
    })
}



function crearListado(data) {
    console.log(data);
    var contenido = "";
    contenido += "<table class='table table-hover table-bordered'>";
    contenido += "<tr>";
    contenido += "<th>Cod. Raza</th>";
    contenido += "<th>Descripción</th>";
    contenido += "<th>Esta Activo?</th>";
    contenido += "<th>Acciones</th>";
    contenido += "</tr>";

    var fila;
    for (var i = 0; i < data.length; i++) {
        fila = data[i];
        contenido += "<tr>";
        contenido += "<td>" + fila.RazaID + "</td>";
        contenido += "<td>" + fila.Descripcion + "</td>";
        contenido += "<td>" + fila.EstaActivo + "</td>";
        contenido += `<td>

                        <button data-bs-toggle="modal" onclick="abrirModal(${fila.RazaID})" data-bs-target="#exampleModal" class="btn btn-primary bi bi-pencil-square"></button>
                        <button onclick='Eliminar(${fila.RazaID})' class="btn btn-danger bi bi-trash-fill"></button>

                 
                       </td>
                    `
        contenido += "</tr>";
    }
    contenido += "</table>";
    document.getElementById("DivRaza").innerHTML = contenido;
}



function abrirModal(id) {
    if (id != undefined) {
        $.get("/raza/RecuperarRaza/" + id, function (data) {
            document.getElementById("txtRazaID").value = data[0].RazaID;
            document.getElementById("txtDescripcion").value = data[0].Descripcion;
            document.getElementById("cboEstaActivo").value = data[0].EstaActivo;

        })
    }
    Limpiar();
}

function Limpiar() {
    var elementosClaseLimpiar = document.getElementsByClassName("limpiar");
    var elementos = elementosClaseLimpiar.length;
    for (var i = 0; i < elementos; i++) {
        elementosClaseLimpiar[i].value = "";
    }
}

function Eliminar(id) {
    //alert(id);
    var frm = new FormData();
    frm.append("id", id);
    $.ajax({
        type: "POST",
        url: "raza/Eliminar",
        contentType: false,
        processData: false,
        data: frm,
        success: function (data) {
            if (data == 0) {
                alert("Se ha producido un error.")
            }
            else {
                Listar();
                alert("Registro eliminado")
            }
        }

    })
}
function Guardar() {

    var raza_id = document.getElementById("txtRazaID").value;
    var descripcion = document.getElementById("txtDescripcion").value;
    var esta_activo = document.getElementById("cboEstaActivo").value;
    var frm = new FormData();
    frm.append("RazaID", raza_id);
    frm.append("Descripcion", descripcion);
    frm.append("EstaActivo", esta_activo);
    $.ajax({
        type: "POST",
        url: "raza/Guardar",
        contentType: false,
        processData: false,
        data: frm,
        success: function (data) {
            if (data == 0) {
                alert("Se ha producido un error.")
            }
            else {
                Listar();
                alert("Se ha registrado correctamente")
                document.getElementById("btnCerrar").click();
            }
        }

    })
}