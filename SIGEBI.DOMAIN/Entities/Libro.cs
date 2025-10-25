using SIGEBI.Domain.Base;
namespace SIGEBI.Domain.Entities
{
    public class Libro : AuditEntity
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public int CantidadTotal { get; set; }
        public int CantidadDisponible { get; set; }
        public string? ISBN { get; set; }


        // Relaciones
        public ICollection<Prestamo> Prestamos { get; set; }
    }
}