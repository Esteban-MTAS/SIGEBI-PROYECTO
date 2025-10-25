namespace SIGEBI.Application.Dtos.Prestamos
{
    public class CrearPrestamoDto
    {
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }
        public int RegistradoPor { get; set; } // Bibliotecario
        public DateTime FechaDevolucion { get; set; }
    }
}