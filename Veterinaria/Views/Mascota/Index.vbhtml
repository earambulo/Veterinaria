@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Plantillas/Dashboard.vbhtml"
End Code

<h2>Matenimiento de Mascotas</h2>
<button onclick="abrirModal()" type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#exampleModal">
    Nueva Mascota
</button>
<div id="DivMascota">

</div>

<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">

            <input type="hidden" class="form-control limpiar" id="txtRazaID">

            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Raza</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="mb-3">
                    <label for="cboCliente" class="form-label">Cliente</label>
                    <select class="form-select " id="cboCliente">
                    </select>
                </div>
                <div class="mb-3">
                    <label for="descripcion" class="form-label">Nombre Mascota</label>
                    <input type="text" class="form-control " id="txtNombreMascota">
                </div>
                <div class="mb-3">
                    <label for="cboRaza" class="form-label">Raza</label>
                    <select class="form-select " id="cboRaza">
                    </select>
                </div>
                <div class="mb-3">
                    <label for="Especie" class="form-label">Especie</label>
                    <select class="form-select " id="cboEspecie">
                    </select>
                </div>
                <div class="mb-3">
                    <label for="fechanacimiento" class="form-label">Fecha de Nacimiento</label>
                    <input type="date" class="form-control " id="txtFechaNacimiento">
                </div>
                <div class="mb-3">
                    <label for="esta_activo" class="form-label">Sexo</label>
                    <select class="form-select " id="cboSexo">
                        <option value="M">Macho</option>
                        <option value="H">Hembra</option>
                    </select>
                </div>

                <div class="mb-3">
                    <label for="esta_activo" class="form-label">Esta Activo?</label>
                    <select class="form-select limpiar" id="cboEstaActivo">
                        <option value="S">Si</option>
                        <option value="N">No</option>
                    </select>
                </div>

            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" id="btnCerrar" data-bs-dismiss="modal">Cerrar</button>
                <button type="button" class="btn btn-primary" onclick="Guardar()">Guardar</button>
            </div>
        </div>
    </div>
</div>

<script src="~/scripts/js/jquery-3.6.0.min.js"></script>
<script src="~/scripts/js/mascota.js"></script>