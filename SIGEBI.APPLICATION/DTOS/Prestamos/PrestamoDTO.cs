namespace SIGEBI.Application.Dtos.Prestamos
{
    public class PrestamoDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }
        public int RegistradoPor { get; set; } // Bibliotecario
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Estado { get; set; } // Activo, Devuelto, Vencido
    }

    namespace SIGEBI.Application.Dtos.Prestamos
    {
        public class ActualizarPrestamoDto
        {
            public int Id { get; set; }
            public DateTime? FechaDevolucion { get; set; }
            public string Estado { get; set; } // Activo, Devuelto, Vencido
        }
    }
}