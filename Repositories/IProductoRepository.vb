Imports ApiProductos.Models

Namespace Repositories
    Public Interface IProductoRepository
        Function GetAll() As IEnumerable(Of Producto)
        Function GetById(id As Integer) As Producto
        Sub Create(producto As Producto)
        Sub Update(producto As Producto)
        Sub Delete(id As Integer)
    End Interface
End Namespace
