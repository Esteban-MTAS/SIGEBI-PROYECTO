using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nombre)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Rol)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Estado)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.FechaRegistro)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
