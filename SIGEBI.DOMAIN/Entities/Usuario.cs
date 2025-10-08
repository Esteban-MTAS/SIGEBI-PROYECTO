using SIGEBI.Domain.Base;
namespace SIGEBI.Domain.Entities
{
    public class Usuario : AuditEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }   // Bibliotecario, Usuario, Administrador
        public string Estado { get; set; }

        // Relaciones
        public ICollection<Prestamo> Prestamos { get; set; }
        public ICollection<Penalizacion> Penalizaciones { get; set; }
        public ICollection<Reporte> ReportesGenerados { get; set; }
        public ICollection<Notificacion> Notificaciones { get; set; }
    }
}

