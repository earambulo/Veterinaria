Listar();

function Listar() {
    $.get("/mascota/ListarMascotas", function (data) {
        // alert(JSON.stringify(data));
        crearListado(data);
    })
}


function crearListado(data) {
    var contenido = "";
    contenido += "<table class='table table-hover table-bordered'>";
    contenido += "<tr>";
    contenido += "<th>Cliente</th>";
    contenido += "<th>Mascota</th>";
    contenido += "<th>Raza</th>";
    contenido += "<th>Especie</th>";
    contenido += "<th>Fecha de Nacimiento</th>";
    contenido += "<th>Sexo</th>";
    contenido += "<th>Acciones</th>";
    contenido += "</tr>";

    var fila;
    for (var i = 0; i < data.length; i++) {
        fila = data[i];
        contenido += "<tr>";
        contenido += "<td>" + fila.Cliente + "</td>";
        contenido += "<td>" + fila.Nombre + "</td>";
        contenido += "<td>" + fila.Raza + "</td>";
        contenido += "<td>" + fila.Especie + "</td>";
        contenido += "<td>" + fila.FechaNacimiento + "</td>";
        contenido += "<td>" + fila.Sexo + "</td>";
        contenido += `<td>

                        <button data-bs-toggle="modal" onclick="abrirModal(${fila.MascotaID})" data-bs-target="#exampleModal" class="btn btn-primary bi bi-pencil-square"></button>
                        <button onclick='Eliminar(${fila.MascotaID})' class="btn btn-danger bi bi-trash-fill"></button>

                 
                       </td>
                    `
        contenido += "</tr>";
    }
    contenido += "</table>";
    document.getElementById("DivMascota").innerHTML = contenido;
}

function abrirModal() {

    //$.get("/mascota/ListarClientes", function (data) {

    cargarClientes();
    cargarRazas();
    cargarEspecies();
    //  })
}

function cargarClientes() {
    $.get("/mascota/ListarClientes", function (data) {
        contenido = "";
        document.getElementById("cboCliente").innerHTML = contenido;
        for (var i = 0; i < data.length; i++) {
            fila = data[i];
            contenido += " <option value='" + fila.ClienteID + "'>" + fila.NombreApelllido + "</option>";
            console.log(fila);
        }
        document.getElementById("cboCliente").innerHTML = contenido;
    })
}

function cargarRazas() {
    $.get("/mascota/ListarRazas", function (data) {
        contenido = "";
        document.getElementById("cboRaza").innerHTML = contenido;
        for (var i = 0; i < data.length; i++) {
            fila = data[i];
            contenido += " <option value='" + fila.RazaID + "'>" + fila.Descripcion + "</option>";
            console.log(fila);
        }
        document.getElementById("cboRaza").innerHTML = contenido;
    })
}

function cargarEspecies() {
    $.get("/mascota/ListarEspecies", function (data) {
        contenido = "";
        document.getElementById("cboEspecie").innerHTML = contenido;
        for (var i = 0; i < data.length; i++) {
            fila = data[i];
            contenido += " <option value='" + fila.EspecieID + "'>" + fila.Descripcion + "</option>";
            console.log(fila);
        }
        document.getElementById("cboEspecie").innerHTML = contenido;
    })
}

function Guardar() {

    var mascota_id = 0;
    var nombre = document.getElementById("txtNombreMascota").value;
    var cliente = document.getElementById("cboCliente").value;
    var raza = document.getElementById("cboRaza").value;
    var especie = document.getElementById("cboEspecie").value;
    var sexo = document.getElementById("cboSexo").value;
    var fecha_nacimiento = document.getElementById("txtFechaNacimiento").value;
    var esta_activo = document.getElementById("cboEstaActivo").value;
    var frm = new FormData();
    frm.append("MascotaID", mascota_id);
    frm.append("ClienteID", cliente);
    frm.append("Nombre", nombre);
    frm.append("RazaID", raza);
    frm.append("FechaNacimiento", fecha_nacimiento);
    frm.append("Sexo", sexo);
    frm.append("EspecieID", especie);
    frm.append("EstaActivo", esta_activo);
    $.ajax({
        type: "POST",
        url: "Mascota/Guardar",
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


