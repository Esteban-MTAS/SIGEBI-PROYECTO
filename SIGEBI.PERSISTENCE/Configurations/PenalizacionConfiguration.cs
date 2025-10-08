using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Persistence.Configurations
{
    public class PenalizacionConfiguration : IEntityTypeConfiguration<Penalizacion>
    {
        public void Configure(EntityTypeBuilder<Penalizacion> builder)
        {
            builder.ToTable("Penalizacion");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Monto)
                   .HasColumnType("decimal(10,2)")
                   .IsRequired();

            builder.Property(p => p.Motivo)
                   .HasMaxLength(200);

            builder.Property(p => p.Estado)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.FechaAplicacion)
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(p => p.Usuario)
                   .WithMany(u => u.Penalizaciones)
                   .HasForeignKey(p => p.UsuarioId);

            builder.HasOne(p => p.Prestamo)
                   .WithMany(pr => pr.Penalizaciones)
                   .HasForeignKey(p => p.PrestamoId);
        }
    }
}

