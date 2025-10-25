using SIGEBI.Domain.Base;
namespace SIGEBI.Domain.Entities
{

    public abstract class AuditEntity
    {
        public string? CreadoPor { get; set; }
        public string? ActualizadoPor { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }

    public class Notificacion : AuditEntity
    {
        public int Id { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaEnvio { get; set; }
        public bool Leido { get; set; }

        // Relaciones
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}