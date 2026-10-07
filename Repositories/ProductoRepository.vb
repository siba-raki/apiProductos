Imports ApiProductos.Data
Imports ApiProductos.Models
Imports Microsoft.EntityFrameworkCore

Namespace Repositories
    Public Class ProductoRepository
        Implements IProductoRepository

        Private ReadOnly _context As ProductosDBContext

        Public Sub New(context As ProductosDBContext)
            _context = context
        End Sub

        Public Function GetAll() As IEnumerable(Of Producto) Implements IProductoRepository.GetAll
            Return _context.Productos.ToList()
        End Function

        Public Function GetById(id As Integer) As Producto Implements IProductoRepository.GetById
            Return _context.Productos.Find(id)
        End Function

        Public Sub Create(producto As Producto) Implements IProductoRepository.Create
            _context.Productos.Add(producto)
            _context.SaveChanges()
        End Sub

        Public Sub Update(producto As Producto) Implements IProductoRepository.Update
            _context.Entry(producto).State = EntityState.Modified
            _context.SaveChanges()
        End Sub

        Public Sub Delete(id As Integer) Implements IProductoRepository.Delete
            Dim producto = _context.Productos.Find(id)
            If producto IsNot Nothing Then
                _context.Productos.Remove(producto)
                _context.SaveChanges()
            End If
        End Sub
    End Class
End Namespace
