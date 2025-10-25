using Microsoft.EntityFrameworkCore;
using SIGEBI.Domain.Entities;
namespace SIGEBI.Persistence.Context
{
    public class SIGEBIDbContext : DbContext
    {
        public SIGEBIDbContext(DbContextOptions<SIGEBIDbContext> options)
            : base(options)
        {
        }

        // DbSets para cada entidad
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Penalizacion> Penalizaciones { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notificacion>().ToTable("Notificacion");

            // Opcional: restricciones de longitud
            modelBuilder.Entity<Notificacion>(entity =>
            {
                entity.Property(e => e.Mensaje).HasMaxLength(300).IsRequired();
                entity.Property(e => e.CreadoPor).HasMaxLength(100);
                entity.Property(e => e.ActualizadoPor).HasMaxLength(100);
            });

            // 🔹 Penalizacion
            modelBuilder.Entity<Penalizacion>().ToTable("Penalizacion");
            modelBuilder.Entity<Penalizacion>(entity =>
            {
                entity.Property(e => e.Motivo).HasMaxLength(300).IsRequired();
                entity.Property(e => e.Estado).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Monto).HasColumnType("decimal(10,2)");

                entity.HasOne(p => p.Usuario)
                      .WithMany(u => u.Penalizaciones)
                      .HasForeignKey(p => p.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Prestamo)
                      .WithMany(pr => pr.Penalizaciones)
                      .HasForeignKey(p => p.PrestamoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });



            // 🔹 Prestamo
            modelBuilder.Entity<Prestamo>().ToTable("Prestamo");
            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.Property(e => e.Estado).HasMaxLength(50).IsRequired();

                entity.HasOne(p => p.Usuario)
                      .WithMany(u => u.Prestamos)
                      .HasForeignKey(p => p.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Libro)
                      .WithMany(l => l.Prestamos)
                      .HasForeignKey(p => p.LibroId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Bibliotecario)
                      .WithMany()
                      .HasForeignKey(p => p.RegistradoPor)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 🔹 Libro
            modelBuilder.Entity<Libro>().ToTable("Libro");

            // 🔹 Usuario
            modelBuilder.Entity<Usuario>().ToTable("Usuario");

            // 🔹 Reporte
            modelBuilder.Entity<Reporte>().ToTable("Reporte");




            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SIGEBIDbContext).Assembly);

        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<AuditEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.FechaRegistro = DateTime.Now;
                    entry.Entity.CreadoPor = "Sistema";
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.FechaActualizacion = DateTime.Now;
                    entry.Entity.ActualizadoPor = "Sistema";
                }
            }

            return base.SaveChanges();
        }

    }



    }



