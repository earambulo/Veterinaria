'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Producto
    Public Property ProductoID As Integer
    Public Property Nombre As String
    Public Property Precio As Decimal
    Public Property Stock As Integer

    Public Overridable Property DetalleVenta As ICollection(Of DetalleVenta) = New HashSet(Of DetalleVenta)

End Class
