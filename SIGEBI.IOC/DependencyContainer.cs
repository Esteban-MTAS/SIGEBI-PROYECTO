using Microsoft.Extensions.DependencyInjection;
using SIGEBI.Application.Interfaces;
using SIGEBI.Application.Services;
using SIGEBI.Domain.Repository;
using SIGEBI.Persistence;
using SIGEBI.Persistence.Context;
using SIGEBI.Persistence.Repositories;

namespace SIGEBI.IOC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // DbContext
            services.AddDbContext<SIGEBIDbContext>();

            // Repositorios
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILibroRepository, LibroRepository>();
            services.AddScoped<IPrestamoRepository, PrestamoRepository>();
            services.AddScoped<IPenalizacionRepository, PenalizacionRepository>();
            services.AddScoped<IReporteRepository, ReporteRepository>();
            services.AddScoped<INotificacionesRepository, NotificacionRepository>();


            services.AddScoped<ILibroService, LibroService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPrestamoService, PrestamoService>();
            services.AddScoped<IPenalizacionService, PenalizacionService>();
            services.AddScoped<INotificacionService, NotificacionService>();
            services.AddScoped<IReporteService, ReporteService>();

        }
    }
}