using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Persistence.Configurations
{
    public class PrestamoConfiguration : IEntityTypeConfiguration<Prestamo>
    {
        public void Configure(EntityTypeBuilder<Prestamo> builder)
        {
            builder.ToTable("Prestamo");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Estado)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.FechaPrestamo)
                   .IsRequired();

            builder.HasOne(p => p.Libro)
                   .WithMany(l => l.Prestamos)
                   .HasForeignKey(p => p.LibroId);

            builder.HasOne(p => p.Usuario)
                   .WithMany(u => u.Prestamos)
                   .HasForeignKey(p => p.UsuarioId);

            builder.HasOne(p => p.Bibliotecario)
                   .WithMany()
                   .HasForeignKey(p => p.RegistradoPor)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
