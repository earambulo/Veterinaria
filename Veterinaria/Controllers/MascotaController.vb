Imports System.Web.Mvc
Imports System.Data.Objects.SqlClient
Namespace Controllers
    Public Class MascotaController
        Inherits Controller
        Dim db As VeterinariaEntities = New VeterinariaEntities

        ' GET: Mascota
        Function Index() As ActionResult
            Return View()
        End Function

        Function ListarMascotas() As JsonResult
            Dim Lista = From mascota In db.Mascota
                        Join raza In db.Raza On raza.RazaID Equals mascota.RazaID
                        Join cliente In db.Cliente On cliente.CiudadID Equals mascota.ClienteID
                        Join especie In db.Especie On especie.EspecieID Equals mascota.EspecieID
                        Select New With
                                    {
                                        mascota.MascotaID,
                                        mascota.RazaID,
                                        mascota.Nombre,
                                        mascota.ClienteID,
            .FechaNacimiento = mascota.FechaNacimiento,
                                        mascota.Sexo,
                                        .Raza = raza.Descripcion,
                                        .Cliente = cliente.NombreApelllido,
                                        .Especie = especie.Descripcion
                                    }

            Return New JsonResult With {
            .Data = Lista,
            .JsonRequestBehavior = JsonRequestBehavior.AllowGet
            }
        End Function

        Function ListarClientes() As JsonResult
            Dim Lista = From cliente In db.Cliente
                        Select New With
                                    {
                                        cliente.ClienteID,
                                        cliente.NombreApelllido
                                    }

            Return New JsonResult With {
            .Data = Lista,
            .JsonRequestBehavior = JsonRequestBehavior.AllowGet
            }
        End Function

        Function ListarRazas() As JsonResult
            Dim Lista = From raza In db.Raza
                        Select New With
                                    {
                                        raza.RazaID,
                                        raza.Descripcion
                                    }

            Return New JsonResult With {
            .Data = Lista,
            .JsonRequestBehavior = JsonRequestBehavior.AllowGet
            }
        End Function
        Function ListarEspecies() As JsonResult
            Dim Lista = From especie In db.Especie
                        Select New With
                                    {
                                        especie.EspecieID,
                                        especie.Descripcion
                                    }

            Return New JsonResult With {
            .Data = Lista,
            .JsonRequestBehavior = JsonRequestBehavior.AllowGet
            }
        End Function

        <HttpPost()>
        Function Guardar(objMascota As Mascota) As Int32
            Dim respuesta As Integer = 0
            Try
                If objMascota.MascotaID = 0 Then
                    db.Mascota.Add(objMascota)
                    db.SaveChanges()
                    respuesta = 1
                Else
                    Dim registro = (From mascota In db.Mascota
                                    Where mascota.MascotaID = objMascota.MascotaID
                                    Select mascota).First()
                    registro.RazaID = objMascota.RazaID
                    registro.ClienteID = objMascota.ClienteID
                    registro.EstaActivo = objMascota.EstaActivo
                    db.SaveChanges()
                    respuesta = 1
                End If

            Catch ex As Exception
                Return respuesta
            End Try

            Return respuesta
        End Function
    End Class
End Namespace