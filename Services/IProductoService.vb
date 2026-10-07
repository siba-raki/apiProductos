Imports ApiProductos.Models

Namespace Services
    Public Interface IProductoService
        Function GetAllProductos() As IEnumerable(Of Producto)
        Function GetProductoById(id As Integer) As Producto
        Sub CreateProducto(producto As Producto)
        Sub UpdateProducto(producto As Producto)
        Sub DeleteProducto(id As Integer)
    End Interface
End Namespace
