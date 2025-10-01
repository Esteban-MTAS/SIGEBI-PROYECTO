using Microsoft.EntityFrameworkCore;
using SIGEBI.DOMAIN.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SIGEBI.Infrastructure.Persistence.Context
{
    public class SIGEBIDbContext : DbContext
    {
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Penalizacion> Penalizaciones { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ConfiguracionSistema> ConfiguracionSistema { get; set; }

        public SIGEBIDbContext(DbContextOptions<SIGEBIDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SIGEBIDbContext).Assembly);
        }
    }
}