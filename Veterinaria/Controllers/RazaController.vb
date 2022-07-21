Imports System.Web.Mvc

Namespace Controllers
    Public Class RazaController
        Inherits Controller
        Dim db As VeterinariaEntities = New VeterinariaEntities
        ' GET: Raza
        Function Index() As ActionResult
            Return View()
        End Function


        Function ListarRazas() As JsonResult
            Dim Lista = From raza In db.Raza
                        Select New With
                                    {
                                        raza.RazaID,
                                        raza.Descripcion,
                                        raza.EstaActivo
                                    }

            Return New JsonResult With {
            .Data = Lista,
            .JsonRequestBehavior = JsonRequestBehavior.AllowGet
            }
        End Function

        <HttpPost()>
        Function Guardar(objRaza As Raza) As Int32
            Dim respuesta As Integer = 0
            Try
                If objRaza.RazaID = 0 Then
                    db.Raza.Add(objRaza)
                    db.SaveChanges()
                    respuesta = 1
                Else
                    Dim registro = (From raza In db.Raza
                                    Where raza.RazaID = objRaza.RazaID
                                    Select raza).First()
                    registro.Descripcion = objRaza.Descripcion
                    registro.EstaActivo = objRaza.EstaActivo
                    db.SaveChanges()
                    respuesta = 1
                End If

            Catch ex As Exception
                Return respuesta
            End Try

            Return respuesta
        End Function

        <HttpPost()>
        Function Eliminar(id As Integer) As Int32
            Dim respuesta As Integer = 0
            Try
                Dim objRaza As New Raza
                objRaza = db.Raza.Find(id)
                db.Raza.Remove(objRaza)
                db.SaveChanges()
                respuesta = 1
            Catch ex As Exception
                Return respuesta
            End Try

            Return respuesta
        End Function

        Function RecuperarRaza(id As Integer) As JsonResult
            Dim Lista = From raza In db.Raza
                        Where raza.RazaID = id
                        Select New With
                                    {
                                        raza.RazaID,
                                        raza.Descripcion,
                                        raza.EstaActivo
                                    }

            Return New JsonResult With {
            .Data = Lista,
            .JsonRequestBehavior = JsonRequestBehavior.AllowGet
            }
        End Function

    End Class
End Namespace