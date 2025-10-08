using SIGEBI.Domain.Base;
namespace SIGEBI.Domain.Entities
{
    public class Penalizacion : AuditEntity
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; } // Pendiente, Pagada
        public DateTime FechaAplicacion { get; set; }

        // Relaciones
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int PrestamoId { get; set; }
        public Prestamo Prestamo { get; set; }
    }
}

