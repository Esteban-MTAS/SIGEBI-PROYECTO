using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Persistence.Configurations
{
    public class ReporteConfiguration : IEntityTypeConfiguration<Reporte>
    {
        public void Configure(EntityTypeBuilder<Reporte> builder)
        {
            builder.ToTable("Reporte");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Tipo)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(r => r.FechaGeneracion)
                   .IsRequired();

            builder.Property(r => r.Datos)
                   .HasColumnType("nvarchar(max)");

            builder.HasOne(r => r.Usuario)
                   .WithMany(u => u.ReportesGenerados)
                   .HasForeignKey(r => r.GeneradoPor);
        }
    }
}

