using apivendora.Data;
using Microsoft.EntityFrameworkCore;
using apivendora.Services.Inventario;
using apivendora.Services.Ventas;
using apivendora.Services.Productos;
using apivendora.Services.Usuarios;
using apivendora.Services.Finanzas;
using apivendora.Repositories.Productos;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Security.Cryptography.X509Certificates;




var builder = WebApplication.CreateBuilder(args);

// Agregar conexión MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 36))));

// Agregar servicios
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<BarrasService>();
builder.Services.AddScoped<CajeraService>();
builder.Services.AddScoped<ConsultaService>();
builder.Services.AddScoped<DefacturaService>();
builder.Services.AddScoped<FacturaService>();
builder.Services.AddScoped<FormapagoService>();
builder.Services.AddScoped<ImpuestoService>();
builder.Services.AddScoped<LaboratorioService>();
builder.Services.AddScoped<MformapagoService>();
builder.Services.AddScoped<MtransaccionService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<ProveedorService>();
builder.Services.AddScoped<RecogidaService>();
builder.Services.AddScoped<SaldosService>();
builder.Services.AddScoped<TinventarioService>();
builder.Services.AddScoped<ILaboratorioRepository, LaboratorioRepository>();
builder.Services.AddScoped<IBarrasRepository, BarrasRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();


// Agregar controladores
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Para mantener el formato original de las propiedades
});

//Escuchasr en puertos 5259 y 5260
// Habilitar HTTPS en el puerto 5260
// Habilitar HTTP en el puerto 5259
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5259); // HTTP normal

    var cert = new X509Certificate2("/etc/ssl/apivendora/apivendora.pfx", "1234");

    options.ListenAnyIP(5260, listenOptions =>
    {
        listenOptions.UseHttps(cert);
    });
});


var app = builder.Build();

app.UseMiddleware<apivendora.Middleware.ErrorHandlingMiddleware>();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.MapControllers();
app.Run();
