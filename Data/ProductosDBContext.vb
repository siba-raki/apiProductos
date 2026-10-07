Imports Microsoft.EntityFrameworkCore
Imports ApiProductos.Models

Namespace Data
    Public Class ProductosDBContext
        Inherits DbContext

        Public Property Productos As DbSet(Of Producto)

        Public Sub New(options As DbContextOptions(Of ProductosDBContext))
            MyBase.New(options)
        End Sub

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
            modelBuilder.Entity(Of Producto)().ToTable("Productos")
        End Sub
    End Class
End Namespace
