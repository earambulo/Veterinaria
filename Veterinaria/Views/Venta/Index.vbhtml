@ModelType IEnumerable(Of Cliente)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Plantillas/Dashboard.vbhtml"
End Code

<div class="card">
    <div class="card-body">
        <div class="mb-3 row">
            <label for="cliente" class="col-form-label">Cliente</label>
            <divc class="col-sm-10">
                <select class="form-select" id="cboCliente">
                    @For Each item In Model
                        @<option value="@item.ClienteID"> @item.NombreApelllido</option>
                    Next
                </select>

            </divc>
        </div>

        <div Class="mb-3 row">
            <Label for="fecha_venta" class="col-form-label">Fecha de Venta</Label>
            <divc Class="col-sm-10">
                <input type="date" Class="form-control" id="txtFechaVenta" />

            </divc>
        </div>
    </div>

</div>
<br />

<div Class="card">
    <div Class="card-header text-end">
        <Button onclick="ListarProductos()" type="button" Class="btn btn-success" data-bs-toggle="modal" data-bs-target="#exampleModal">
            Agregar
        </Button>
    </div>
    <Table Class="table table-bordered" id="detalleVenta">
        <thead>
            <tr>
                <th> Producto</th>
                <th> Precio</th>
                <th> Cantidad</th>
                <th> Sub-Total</th>
            </tr>
        </thead>
        <tbody>
        </tbody>
        <tfoot>
            <tr>
                <th colspan="3" Class="text-center">TOTAL</th>
                <th><h4 id="total"> Gs. 0</h4></th>
            </tr>

        </tfoot>

    </Table>

</div>
<Button onclick="Guardar()" Class="btn btn-primary">Guardar</Button>

<!-- Modal carga de detalle de venta-->

<div Class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div Class="modal-dialog">
        <div Class="modal-content">
            <div Class="modal-header">
                <h5 Class="modal-title" id="exampleModalLabel">Agregando Detalle</h5>
                <Button type="button" Class="btn-close" data-bs-dismiss="modal" aria-label="Close"></Button>
            </div>
            <div Class="modal-body">
                <div Class="mb-3">
                    <Label for="producto" class="form-label">Productos</Label>
                    <select Class="form-select" id="cboProducto">
                    </select>
                </div>
                <div Class="mb-3">
                    <Label for="cantidad" class="form-label">Cantidad</Label>
                    <input type="number" min="0" Class="form-control" id="txtCantidad" />
                </div>
            </div>
            <div Class="modal-footer">
                <Button id="btnCerrar" type="button" Class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</Button>
                <Button type="button" Class="btn btn-primary" onclick="agregarDetalle()">Guardar</Button>
            </div>
        </div>
    </div>
</div>


<!-- Modal de validacion-->
<div class="modal fade" id="ModalAlerta" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="ModalTitulo"></h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body" id="ModalMensaje">
                
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
            </div>
        </div>
    </div>
</div>


<script src="~/Scripts/JS/jquery-3.6.0.min.js"></script>
<script src="~/Scripts/JS/venta.js"></script>