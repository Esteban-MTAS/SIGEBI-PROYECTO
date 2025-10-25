using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence;
using SIGEBI.Persistence.Context;
using SIGEBI.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de DbContext con SQL Server
builder.Services.AddDbContext<SIGEBIDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Registro de repositorios (Inyección de dependencias)
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();
builder.Services.AddScoped<IPrestamoRepository, PrestamoRepository>();
builder.Services.AddScoped<IPenalizacionRepository, PenalizacionRepository>();
builder.Services.AddScoped<IReporteRepository, ReporteRepository>();
builder.Services.AddScoped<INotificacionesRepository, NotificacionRepository>();


// 3. Servicios de controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();