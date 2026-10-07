Imports Microsoft.AspNetCore.Mvc
Imports ApiProductos.Models
Imports ApiProductos.Services

Namespace Controllers
    <ApiController>
    <Route("api/[controller]")>
    Public Class ProductosController
        Inherits ControllerBase

        Private ReadOnly _service As IProductoService

        Public Sub New(service As IProductoService)
            _service = service
        End Sub

        <HttpGet>
        Public Function GetAll() As IEnumerable(Of Producto)
            Return _service.GetAllProductos()
        End Function

        <HttpGet("{id}")>
        Public Function GetById(id As Integer) As Object
            Dim producto = _service.GetProductoById(id)
            If producto Is Nothing Then
                Return NotFound(New With {.mensaje = $"No se encontro el producto con id {id}"})
            End If
            Return Ok(New With {.mensaje = "Producto obtenido exitosamente", .producto = producto})
        End Function

        <HttpPost>
        Public Function Create(<FromBody> producto As Producto) As Object
            _service.CreateProducto(producto)
            Return CreatedAtAction(NameOf(GetById), New With {.id = producto.Id}, New With {.mensaje = "Producto creado exitosamente", .producto = producto})
        End Function

        <HttpPut("{id}")>
        Public Function Update(id As Integer, <FromBody> producto As Producto) As Object
            If id <> producto.Id Then
                Return BadRequest(New With {.mensaje = "El id del producto no coincide con el id proporcionado"})
            End If
            Dim existente = _service.GetProductoById(id)
            If existente Is Nothing Then
                Return NotFound(New With {.mensaje = $"No se encontro el producto con id {id}"})
            End If
            _service.UpdateProducto(producto)
            Return Ok(New With {.mensaje = "Producto actualizado exitosamente", .producto = producto})
        End Function

        <HttpDelete("{id}")>
        Public Function Delete(id As Integer) As Object
            Dim producto = _service.GetProductoById(id)
            If producto Is Nothing Then
                Return NotFound(New With {.mensaje = $"No se encontro el producto con id {id}"})
            End If
            _service.DeleteProducto(id)
            Return Ok(New With {.mensaje = "Producto eliminado exitosamente"})
        End Function
    End Class
End Namespace
