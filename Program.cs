using apivendora.Data;
using apivendora.Services;
using Microsoft.EntityFrameworkCore;

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



var app = builder.Build();

app.UseMiddleware<apivendora.Middleware.ErrorHandlingMiddleware>();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.MapControllers();
app.Run();
