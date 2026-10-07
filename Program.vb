Imports Microsoft.AspNetCore.Builder
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.EntityFrameworkCore
Imports ApiProductos.Data
Imports ApiProductos.Repositories
Imports ApiProductos.Services

Module Program
    Sub Main(args As String())
        Dim builder = WebApplication.CreateBuilder(args)

        builder.Services.AddDbContext(Of ProductosDBContext)(Sub(options)
            options.UseSqlServer("Server=localhost;Database=ProductosDB;User Id=sa;Password=tu_password;TrustServerCertificate=True;")
        End Sub)

        builder.Services.AddScoped(Of IProductoRepository, ProductoRepository)()
        builder.Services.AddScoped(Of IProductoService, ProductoService)()

        builder.Services.AddControllers()
        builder.Services.AddEndpointsApiExplorer()

        Dim app = builder.Build()

        app.MapControllers()

        app.Run()
    End Sub
End Module
