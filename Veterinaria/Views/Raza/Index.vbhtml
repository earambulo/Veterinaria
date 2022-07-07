@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Plantillas/Dashboard.vbhtml"
End Code

<h2>Mantenimiento de Razas</h2>
<button onclick="AbrirModal()" type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#exampleModal">
    Nueva Raza
</button>

<div id="DivRaza">

</div>

<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">

            <input type="text" class="form-control" id="txtRazaID">

            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Raza</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="mb-3">
                    <label for="descripcion" class="form-label">Descripcion</label>
                    <input type="text" class="form-control" id="txtDescripcion">
                </div>

                <div class="modal-body">
                    <label for="esta_activo" class="form-label">Esta Activo?</label>
                    <select class="form-select" id="cboEstaActivo">
                        <option value="S">Si</option>
                        <option value="N">No</option>
                    </select>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                <button type="button" class="btn btn-primary" onclick="Guardar()">Guardar</button>
            </div>
        </div>
    </div>
</div>

<script src="~/Scripts/JS/jquery-3.6.0.min.js"></script>
<script src="~/Scripts/JS/raza.js"></script>