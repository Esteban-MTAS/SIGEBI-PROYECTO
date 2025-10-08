using SIGEBI.Domain.Base;
namespace SIGEBI.Domain.Entities
{
    public class Prestamo : AuditEntity
    {
        public int Id { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Estado { get; set; } // Activo, Devuelto, Vencido

        // Relaciones
        public int LibroId { get; set; }
        public Libro Libro { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int RegistradoPor { get; set; }
        public Usuario Bibliotecario { get; set; }

        public ICollection<Penalizacion> Penalizaciones { get; set; }
    }
}

