Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace Models
    <Table("Productos")>
    Public Class Producto
        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        Public Property Id As Integer

        <Required>
        <MaxLength(100)>
        Public Property Nombre As String

        <Required>
        Public Property Precio As Decimal

        <MaxLength(500)>
        Public Property Descripcion As String

        Public Property Stock As Integer
    End Class
End Namespace
