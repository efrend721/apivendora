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

// Agregar controladores
/*builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});*/


builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Para mantener el formato original de las propiedades
});



var app = builder.Build();



app.UseAuthorization();
app.MapControllers();

app.Run();
