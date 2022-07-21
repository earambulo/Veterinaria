var total = 0;
var cont = 0;
subtotal = [];
array_producto_id = [];
array_cantidad = [];

function ListarProductos() {
    $.get("/Venta/ListarProductos", function (data) {
        console.log(JSON.stringify(data));
        cargarComboProducto(data);
    })
}

function cargarComboProducto(data) {
    console.log(data);
    var contenido = "";
    contenido += ' <option data-precio="0" value="#">Seleccione un producto..</option>';

    var fila;
    for (var i = 0; i < data.length; i++) {
        fila = data[i];
        contenido += ' <option data-precio="' + fila.Precio + '" value="' + fila.ProductoID +'">'+fila.Nombre+'</option>';
    }

    document.getElementById("cboProducto").innerHTML = contenido;
}

var precio = 0;

$("#cboProducto").change(function (event) {
    precio = $('option:selected', this).data('precio');
})

function agregarDetalle() {

    var row = "";
    var productoId = document.getElementById("cboProducto").value;
    var nombreProducto = $("#cboProducto option:selected").text();
    var cantidadProducto = document.getElementById("txtCantidad").value;

    if (productoId == '#') {
        alert("Debe seleccionar un producto")
        return
    }

    if (cantidadProducto <= 0 || cantidadProducto=="") {
        alert("La cantidad debe ser mayor a 0")
        return
    }

    array_producto_id[cont] = productoId;
    array_cantidad[cont] = cantidadProducto;
    subtotal[cont] = precio * cantidadProducto;
    total += subtotal[cont];



    console.log("ProductoID: " + productoId);
    console.log("Nombre producto: " + nombreProducto);
    console.log("Cantidad producto: " + cantidadProducto);
    console.log("Precio: " + precio);

    row = `
            <tr id="${"fila-"+cont}">
                <td>${nombreProducto}</td>
                <td>${precio}</td>
                <td>${cantidadProducto}</td>
                <td>${subtotal[cont]}</td>
            </tr>
            `;
    $("#detalleVenta").append(row);

    cont++;
    document.getElementById("total").innerHTML = total;
    document.getElementById("btnCerrar").click();
    document.getElementById("cboProducto").value = "#";
    document.getElementById("txtCantidad").value = 0;

}


function Alerta(titulo, mensaje) {
    document.getElementById("ModalTitulo").innerHTML = titulo;
    document.getElementById("ModalMensaje").innerHTML = mensaje;
    $("#ModalAlerta").modal('show')

}


function EliminarDetalleVenta() {
    for (var i = 0; i < array_producto_id.length; i++) {
        $("#fila-" + i).remove();
    }
    array_producto_id = [];
    array_cantidad = [];
    subtotal = [];
    total = 0;
    document.getElementById("total").innerHTML = total;
}

function Guardar() {

    var fecha_venta = document.getElementById("txtFechaVenta").value;
    var cliente_id = document.getElementById("cboCliente").value;

    if (fecha_venta== "") {
        Alerta("Atencion","Debe ingresar fecha de venta");
        return
    }

    if (array_producto_id.length <= 0) {
        Alerta("Atencion","Debe agregar un detalle de venta");
        return
    }

    $.ajax({
        type: "POST",
        url: "Venta/Guardar",
        contentType: false,
        processData: false,
        headers: {
            "Content-Type":"application/json"
        },
        data: JSON.stringify({
            "FechaVenta": fecha_venta,
            "ClienteID": cliente_id,
            "Productos": array_producto_id,
            "Cantidad": array_cantidad,
        }),
        success: function (data) {
            if (data == 0) {
                alert("Se ha producido un error.")
            }
            else {
                EliminarDetalleVenta();
                Alerta("Atención","Se ha registrado correctamente")
            }
        }

    })
}