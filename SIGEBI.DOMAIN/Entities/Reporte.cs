using SIGEBI.Domain.Base;
namespace SIGEBI.Domain.Entities
{
    public class Reporte : AuditEntity
    {
        public int Id { get; set; }
        public string Tipo { get; set; } // Libros, Prestamos, Penalizaciones
        public DateTime FechaGeneracion { get; set; }
        public string Datos { get; set; }

        // Relaciones
        public int GeneradoPor { get; set; }
        public Usuario Usuario { get; set; }
    }
}

