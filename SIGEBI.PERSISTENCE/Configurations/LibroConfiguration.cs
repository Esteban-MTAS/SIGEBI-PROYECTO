using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Persistence.Configurations
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libro");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Titulo)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(l => l.Autor)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(l => l.ISBN)
                   .HasMaxLength(20);


            builder.Property(l => l.FechaRegistro)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}


