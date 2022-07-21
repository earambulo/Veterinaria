Imports System.Web.Mvc

Namespace Controllers
    Public Class VentaController
        Inherits Controller
        Dim db As VeterinariaEntities = New VeterinariaEntities
        ' GET: Venta
        Function Index() As ActionResult
            Dim Lista As New List(Of Cliente)
            Lista = db.Cliente.ToList
            Return View(Lista)
        End Function

        Function ListarProductos() As JsonResult
            Dim Lista = From producto In db.Producto
                        Select New With
                                       {
                            producto.ProductoID,
                            producto.Nombre,
                            producto.Precio
                            }
            Return New JsonResult With {
            .Data = Lista,
            .JsonRequestBehavior = JsonRequestBehavior.AllowGet
            }
        End Function

        <HttpPost>
        Function Guardar(FechaVenta As Date, ClienteID As Integer, Productos() As Integer, Cantidad() As Integer) As Integer
            Dim respuesta As Integer = 0
            Using transaction As System.Data.Entity.DbContextTransaction = db.Database.BeginTransaction
                Try
                    Dim objVenta As New Venta
                    With objVenta
                        .ClienteID = ClienteID
                        .FechaVenta = FechaVenta
                    End With
                    db.Venta.Add(objVenta)
                    db.SaveChanges()

                    For f As Integer = 0 To Productos.Length - 1
                        Dim objDetalleVenta As New DetalleVenta
                        With objDetalleVenta
                            .VentaID = objVenta.VentaID
                            .ProductoID = Productos(f)
                            .Cantidad = Cantidad(f)
                        End With
                        db.DetalleVenta.Add(objDetalleVenta)
                        db.SaveChanges()
                    Next

                    transaction.Commit()

                    respuesta = 1
                Catch ex As Exception
                    Return respuesta
                    transaction.Rollback()
                End Try
                Return respuesta
            End Using

        End Function

    End Class
End Namespace