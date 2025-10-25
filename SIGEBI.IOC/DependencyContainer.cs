using Microsoft.Extensions.DependencyInjection;
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


        }
    }
}