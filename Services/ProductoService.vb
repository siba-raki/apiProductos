Imports ApiProductos.Models
Imports ApiProductos.Repositories

Namespace Services
    Public Class ProductoService
        Implements IProductoService

        Private ReadOnly _repository As IProductoRepository

        Public Sub New(repository As IProductoRepository)
            _repository = repository
        End Sub

        Public Function GetAllProductos() As IEnumerable(Of Producto) Implements IProductoService.GetAllProductos
            Return _repository.GetAll()
        End Function

        Public Function GetProductoById(id As Integer) As Producto Implements IProductoService.GetProductoById
            Return _repository.GetById(id)
        End Function

        Public Sub CreateProducto(producto As Producto) Implements IProductoService.CreateProducto
            _repository.Create(producto)
        End Sub

        Public Sub UpdateProducto(producto As Producto) Implements IProductoService.UpdateProducto
            _repository.Update(producto)
        End Sub

        Public Sub DeleteProducto(id As Integer) Implements IProductoService.DeleteProducto
            _repository.Delete(id)
        End Sub
    End Class
End Namespace
